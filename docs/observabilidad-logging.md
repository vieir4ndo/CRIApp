# Observabilidad y Logging Estructurado en CRIApp API

## Contexto y motivación

Una API REST en producción necesita mecanismos que permitan diagnosticar errores, rastrear el comportamiento del sistema y detectar problemas de seguridad sin necesidad de inspeccionar el código manualmente. Este principio se recoge en la literatura de ingeniería de software bajo el concepto de **observabilidad** (*observability*), definido como la capacidad de inferir el estado interno de un sistema a partir de sus salidas externas (logs, métricas, trazas).

En el contexto de CRIApp, la observabilidad responde a tres necesidades concretas:

1. **Diagnóstico operativo:** detectar cuándo y por qué falla un flujo de negocio (login incorrecto, recurso no encontrado, error inesperado).
2. **Seguridad:** registrar intentos de acceso inválidos (credenciales incorrectas, tokens expirados, accesos a recursos ajenos) para facilitar auditorías.
3. **Trazabilidad académica:** demostrar ante el tribunal que el sistema dispone de los mecanismos de monitorización propios de un entorno profesional.

---

## Decisiones de diseño

### Niveles de log adoptados

Se adoptó la convención estándar de ASP.NET Core (`Microsoft.Extensions.Logging`), usando únicamente dos niveles en capa de aplicación:

| Nivel | Cuándo usarlo |
|---|---|
| `LogWarning` | Situación esperada pero anómala: recurso no encontrado, validación fallida, intento de acceso no autorizado. No interrumpe el sistema pero indica uso incorrecto. |
| `LogError` | Excepción inesperada no controlada que interrumpe el flujo normal. Requiere atención inmediata. |

Se decidió **no usar `LogInformation`** en los servicios de negocio para evitar ruido en los logs de producción. Application Insights ya registra automáticamente todas las requests HTTP entrantes con su código de respuesta y duración, lo que hace redundante logar eventos de éxito.

### Logging estructurado (*structured logging*)

En lugar de concatenar mensajes de texto, se utiliza logging estructurado con plantillas y parámetros nombrados:

```csharp
// ❌ No estructurado — difícil de filtrar y buscar
_logger.LogWarning("El usuario " + userId + " no fue encontrado");

// ✅ Estructurado — los campos son indexables y buscables
_logger.LogWarning("User {UserId} not found", userId);
```

Los parámetros nombrados (`{UserId}`, `{Username}`, etc.) son capturados por Application Insights como propiedades independientes, lo que permite construir consultas del tipo:

```kusto
traces
| where customDimensions.UserId == "3f2a1b..."
| order by timestamp desc
```

---

## Implementación

### 1. Capa de aplicación — Servicios

Se inyecta `ILogger<T>` vía constructor en todos los servicios de negocio críticos. Los warnings se registran únicamente en los flujos de error controlado, justo antes de lanzar la excepción de dominio:

**`UserService`**
- Intento de registro con username ya existente
- Login fallido (credenciales incorrectas)
- Usuario no encontrado al buscar por id
- Solicitud de recuperación de contraseña para username desconocido
- Uso de código de recuperación inválido o expirado

**`ChildService`**
- Hijo no encontrado
- Hijo no pertenece al usuario autenticado

**`AnswerService`**
- Intento de responder con un hijo que no pertenece al usuario

**`QuestionService`**
- Pregunta no encontrada

**`CommentService`**
- Comentario no encontrado

**`ForumService`**
- Foro no encontrado (en consulta y en actualización)
- Foro no pertenece al usuario que intenta modificarlo

### 2. Capa de presentación — Controllers

Se añadió el método `ValidateAndLog` en `CriAppControllerBase`, la clase base de todos los controllers de la API:

```csharp
protected void ValidateAndLog(BaseRequest request)
{
    try
    {
        request.ValidateAndThrow();
    }
    catch (ValidationException ex)
    {
        Logger.LogWarning(
            "Validation failed on {Method} {Path}: {Errors}",
            HttpContext.Request.Method,
            HttpContext.Request.Path,
            string.Join("; ", ex.Errors));
        throw;
    }
}
```

Todos los controllers sustituyen `request.ValidateAndThrow()` por `ValidateAndLog(request)`. Esto permite registrar, con contexto de método HTTP y ruta, cualquier error de validación de entrada antes de que el middleware de errores lo procese.

El `ILogger` se resuelve de forma lazy desde `HttpContext.RequestServices`, evitando que todos los controllers tengan que declarar una dependencia explícita en su constructor.

### 3. Middleware de errores

El middleware `ErrorHandlerExtensions` registra con `LogError` todas las excepciones no controladas, incluyendo el método HTTP y la ruta de la request:

```csharp
logger.LogError(error,
    "Unhandled exception on {Method} {Path}",
    context.Request.Method,
    context.Request.Path);
```

---

## Integración con Application Insights

Todos los logs emitidos mediante `ILogger` son capturados automáticamente por Application Insights gracias a la línea:

```csharp
builder.Services.AddApplicationInsightsTelemetry();
```

Application Insights añade automáticamente a cada entrada de log:

- **`operation_Id`:** identificador único de la request HTTP, que permite correlacionar todos los eventos ocurridos durante una misma llamada.
- **`operation_ParentId`:** identificador de la operación padre, útil para trazar llamadas entre servicios.
- **Propiedades estructuradas:** los parámetros nombrados del mensaje (ej. `{UserId}`) se almacenan como campos indexables.

Esto permite realizar consultas en el portal Azure para responder preguntas como:

- ¿Cuántos intentos de login fallido se produjeron en las últimas 24 horas?
- ¿Qué excepción causó el error 500 en la llamada de las 14:32?
- ¿Qué flujos ejecutó el usuario con id X durante su sesión?

---

## Relación con buenas prácticas y bibliografía

La implementación sigue los principios del **Twelve-Factor App** (factor XI: *Logs*), que define los logs como flujos de eventos ordenados en el tiempo que deben escribirse en `stdout` sin que la aplicación gestione su almacenamiento. Application Insights actúa como el agregador externo que recoge ese flujo.

El uso de logging estructurado con plantillas está alineado con las recomendaciones de **Serilog** y la documentación oficial de Microsoft para ASP.NET Core, que desaconsejan la concatenación de strings en favor de la semántica de mensajes con propiedades indexables.

Desde una perspectiva de seguridad, el registro de intentos de acceso fallido y accesos no autorizados responde a los requisitos de **auditoría** recogidos en el estándar OWASP ASVS (Application Security Verification Standard), sección 7 (*Error Handling and Logging*), que establece que los sistemas deben registrar eventos de seguridad relevantes sin exponer información sensible en los mensajes de log.
