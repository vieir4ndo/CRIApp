# Despliegue de CRIApp API en Azure

## Visión general

Este documento describe el proceso completo de despliegue de la API REST de CRIApp en la nube, utilizando una arquitectura sin coste económico apta para entornos de demostración y TFM.

---

## Arquitectura final

```
GitHub (código fuente)
    │
    └── GitHub Actions (CI/CD)
            ├── Build & Test (.NET 8) ← todas las ramas
            │       └── Validación de cobertura (≥ 80%)
            ├── Migrations (dotnet ef → Neon PostgreSQL) ← solo main
            └── Deploy (Azure App Service F1) ← solo main
                        │
                        ├── Neon.tech (PostgreSQL serverless)
                        └── Application Insights (telemetría)
```

---

## Recursos Azure aprovisionados

El grupo de recursos `criapp` contiene los siguientes recursos:

| Recurso | Tipo | Región | Obligatorio | Descripción |
|---|---|---|---|---|
| `criapp-api` | App Service | Spain Central | ✅ Sí | La aplicación API en ejecución |
| `plan-criapp-api` | App Service Plan (F1) | Spain Central | ✅ Sí | El App Service no puede existir sin un plan de alojamiento |
| `identity-criapp-api` | Managed Identity | Spain Central | ✅ Sí | Identidad federada para autenticación OIDC desde GitHub Actions; sin ella el deploy falla |
| `appinsights-criapp-api` | Application Insights | Spain Central | ✅ Sí | Telemetría de la aplicación (requests, excepciones, dependencias) |
| `ws-8c9bbc00-spaincentr` | Log Analytics Workspace | Spain Central | ✅ Sí | Application Insights moderno (workspace-based) lo requiere obligatoriamente |
| `Application Insights Smart Detection` | Action Group | Global | ❌ Opcional | Creado automáticamente por Application Insights para alertas de anomalías; se puede eliminar si no se usan alertas |
| `criapp` | Action Group | Global | ❌ Opcional | Idem — creado automáticamente; prescindible |

> **Conclusión:** El mínimo funcional son los 5 primeros recursos. Los 2 Action Groups son ruido generado automáticamente por el portal y pueden eliminarse sin impacto.

---

## Tecnologías y justificación de decisiones

### 1. Azure App Service (Plan F1 — gratuito)

**Qué es:** Plataforma como servicio (PaaS) de Microsoft Azure para alojar aplicaciones web.

**Por qué se eligió:**
- Tier F1 completamente gratuito (sin límite de tiempo).
- Soporte nativo para .NET 8 en Linux.
- Integración directa con GitHub Actions mediante OIDC (sin necesidad de gestionar credenciales manuales).
- Escalabilidad futura: migrar a B1/S1 sin cambios en el código ni en la pipeline.

**Limitaciones del tier F1:**
- Sin dominio personalizado con SSL.
- Sin slots de staging.
- CPU y memoria compartidas (suficiente para demo/TFM).

---

### 2. Neon.tech (PostgreSQL serverless — gratuito)

**Qué es:** Servicio de PostgreSQL serverless con tier permanentemente gratuito.

**Por qué se eligió:**
- Azure Database for PostgreSQL no dispone de tier gratuito (~12€/mes el más económico).
- Neon ofrece 0,5 GB de almacenamiento y conexiones ilimitadas sin coste.
- Compatible con Npgsql y Entity Framework Core sin cambios en el código.
- Soporte nativo de SSL (`sslmode=require`), lo que cumple requisitos de seguridad básicos.

**Configuración de conexión:**
La connection string debe estar en formato key-value para Npgsql:
```
Host=<host>;Port=5432;Database=<db>;Username=<user>;Password=<password>;SSL Mode=Require;Trust Server Certificate=true
```

> **Nota:** El formato URI de PostgreSQL (`postgresql://user:pass@host/db`) no es compatible con Npgsql en migraciones EF Core.

---

### 3. GitHub Actions (CI/CD — gratuito)

**Qué es:** Plataforma de integración y entrega continua integrada en GitHub.

**Por qué se eligió sobre Azure Pipelines:**
- Azure Pipelines requiere aprobación manual de Microsoft para ejecutar pipelines en proyectos privados (el paralelismo gratuito fue eliminado en 2021).
- GitHub Actions ofrece 2.000 minutos/mes gratuitos para repositorios privados.
- Integración nativa con el repositorio GitHub existente.

**Autenticación con Azure:**
Se utiliza autenticación OIDC (OpenID Connect) mediante un Service Principal federado, evitando el almacenamiento de credenciales estáticas. Los secrets utilizados son:
- `AZUREAPPSERVICE_CLIENTID_*`
- `AZUREAPPSERVICE_TENANTID_*`
- `AZUREAPPSERVICE_SUBSCRIPTIONID_*`

---

### 4. Entity Framework Core 8 (migraciones automáticas)

Las migraciones de base de datos se ejecutan como paso explícito en la pipeline **antes** del despliegue, garantizando que el esquema esté actualizado antes de que la nueva versión de la app arranque.

```
Build → Test → Coverage → Migrate → Deploy
```

Esto evita errores de startup por incompatibilidad entre el esquema y el código desplegado.

---

### 5. Application Insights (telemetría — gratuito en tier básico)

**Qué es:** Servicio de monitorización y diagnóstico de aplicaciones de Azure, con recolección automática de telemetría.

**Por qué se configuró:**
- El recurso `appinsights-criapp-api` ya había sido creado automáticamente por el portal Azure al crear el App Service.
- Proporciona sin configuración adicional: trazas de requests HTTP, excepciones, dependencias (llamadas a PostgreSQL, HTTP externas), métricas de rendimiento y logs.
- La integración con .NET se hace con una sola línea: `builder.Services.AddApplicationInsightsTelemetry()`.

**Qué monitoriza automáticamente:**
- Requests entrantes (URL, método, código de respuesta, duración)
- Excepciones no controladas y stack traces
- Dependencias: queries SQL, llamadas HTTP a Twilio y Mailjet
- Métricas del proceso: CPU, memoria, número de requests/s

**Dónde ver los datos:**
- Portal Azure → grupo de recursos `criapp` → `appinsights-criapp-api` → **Live Metrics**, **Transaction Search**, **Failures**, **Performance**

---

### 6. Health Checks

Se implementaron dos endpoints de monitorización:

| Endpoint | Descripción |
|---|---|
| `GET /health` | Estado completo: base de datos, email (SMTP) y SMS (Twilio) |
| `GET /health/self` | Estado de la aplicación sin dependencias externas |

**Respuesta de `/health`:**
```json
{
  "status": "Healthy",
  "duration": "00:00:01.234",
  "checks": {
    "database": { "status": "Healthy", "duration": "00:00:00.123" },
    "email":    { "status": "Healthy", "duration": "00:00:00.456" },
    "sms":      { "status": "Healthy", "duration": "00:00:00.789" }
  }
}
```

---

### 7. Refactor de Program.cs — extensiones por responsabilidad

Para mejorar la mantenibilidad y legibilidad, toda la configuración de `Program.cs` fue extraída a clases de extensión en `src/CRIApp.Api/Extensions/`, siguiendo el principio de responsabilidad única (SRP):

| Fichero | Método(s) | Responsabilidad |
|---|---|---|
| `SettingsExtensions.cs` | `AddSettingsConfiguration` | Vincula `TwilioSettings` y `MailjetSettings` desde la configuración |
| `AuthenticationExtensions.cs` | `AddJwtAuthentication` | Configura autenticación JWT Bearer con validación de parámetros |
| `HangfireExtensions.cs` | `AddHangfireServices` | Registra Hangfire con almacenamiento PostgreSQL |
| `FluentValidationExtensions.cs` | `AddFluentValidationLocalization` | Establece el idioma `es-ES` para los mensajes de validación |
| `HealthChecksExtensions.cs` | `AddAppHealthChecks`, `UseHealthCheckEndpoints` | Registra los health checks y mapea los endpoints `/health` y `/health/self` |
| `JobsExtensions.cs` | `AddJobServices`, `UseRecurringJobs` | Registra el job en DI y configura la ejecución recurrente con Hangfire |

El `Program.cs` resultante queda reducido a una secuencia declarativa de llamadas, sin lógica de configuración inline.

---

## Pipeline CI/CD — Descripción detallada

Fichero: `.github/workflows/deploy.yml`

### Estrategia de ramas

La pipeline se activa en **todas las ramas** (`on.push.branches: '**'`), pero los jobs de migración y despliegue están condicionados a `main`:

| Job | Ramas feature | `main` |
|---|---|---|
| Build & Test + Coverage | ✅ | ✅ |
| Migrate | ❌ | ✅ |
| Deploy | ❌ | ✅ |

Esto permite validar la calidad del código en cada rama sin riesgo de afectar a la base de datos ni al entorno de producción.

### Job 1: `build-and-test`
1. Checkout del código
2. Setup .NET 8 SDK
3. `dotnet restore`
4. `dotnet build --configuration Release`
5. `dotnet test` con recolección de cobertura usando `coverlet.runsettings`
6. Instalación de `dotnet-reportgenerator-globaltool`
7. Generación del informe Cobertura consolidado
8. **Validación del umbral de cobertura:** el job falla si la cobertura de líneas es inferior al 80% (`COVERAGE_THRESHOLD`)
9. `dotnet publish` → genera artefacto ZIP *(solo en `main`)*
10. Sube artefacto a GitHub Actions *(solo en `main`)*

### Job 2: `migrate` (depende de `build-and-test`, solo en `main`)
1. Checkout del código
2. Setup .NET 8 SDK
3. Instala `dotnet-ef` globalmente
4. `dotnet restore`
5. Ejecuta `dotnet ef database update` contra Neon PostgreSQL usando el secret `NEON_CONNECTION_STRING_KV`

### Job 3: `deploy` (depende de `migrate`, solo en `main`)
1. Descarga artefacto del Job 1
2. Login en Azure mediante OIDC
3. Despliega en Azure App Service (`criapp-api`)

### Exclusiones de cobertura

Configuradas en `coverlet.runsettings`:
- Proyecto `CRIApp.Repository` (mappings, migraciones, seeders)
- Ficheros: `Program.cs`, `**/Migrations/**`, `**/Seeders/**`, `**/Mappings/**`
- Atributos: `[ExcludeFromCodeCoverage]`, `[GeneratedCode]`, `[CompilerGenerated]`

---

## Variables de entorno en Azure App Service

Todas las configuraciones sensibles se almacenan como Application Settings en Azure (equivalentes a variables de entorno), nunca en el código fuente:

| Variable | Descripción |
|---|---|
| `APPLICATIONINSIGHTS_CONNECTION_STRING` | Connection string del recurso Application Insights |
| `ASPNETCORE_ENVIRONMENT` | `Production` |
| `ConnectionStrings__Postgres` | Connection string key-value de Neon |
| `JwtTokenSettings__Key` | Clave secreta para firma de tokens JWT |
| `JwtTokenSettings__Issuer` | Issuer del token JWT |
| `JwtTokenSettings__ExpiresInMinutes` | Expiración del token |
| `UserSettings__PasswordPepper` | Pepper para hashing de contraseñas |
| `UserSettings__PasswordHashIterations` | Iteraciones del algoritmo de hashing |
| `TwilioSettings__ClientId` | Account SID de Twilio |
| `TwilioSettings__ClientSecret` | Auth Token de Twilio |
| `TwilioSettings__SenderPhoneNumber` | Número remitente de SMS |
| `MailjetSettings__*` | Configuración SMTP para envío de emails |

---

## URLs de producción

| Recurso | URL |
|---|---|
| API base | `https://criapp-api-a0fef0esc6h6dxe5.spaincentral-01.azurewebsites.net` |
| Swagger UI | `.../swagger` |
| Health completo | `.../health` |
| Health app | `.../health/self` |

---

## Problemas encontrados y soluciones

### 1. `.github` en `.gitignore`
**Problema:** Los ficheros de workflow nunca se subían al repositorio.  
**Solución:** Eliminar la entrada `.github` del `.gitignore`.

### 2. Azure Pipelines requiere pago
**Problema:** El paralelismo gratuito fue eliminado por Microsoft para proyectos privados.  
**Solución:** Migrar a GitHub Actions.

### 3. `DOTNET_VERSION` reservada por el runner
**Problema:** La variable de entorno `DOTNET_VERSION` en el YAML conflictúa con una variable interna del runner de GitHub Actions, causando formato inválido.  
**Solución:** Renombrar a `DOTNET_SDK_VERSION`.

### 4. `AddDbContext` sin constructor compatible
**Problema:** `AppContext` solo tenía constructor sin parámetros; `AddDbContext` con opciones externas requiere constructor que acepte `DbContextOptions<T>`.  
**Solución:** Añadir constructor `public AppContext(DbContextOptions<AppContext> options) : base(options) {}`.

### 5. Incompatibilidad de versiones EF Core 6 vs 8
**Problema:** `CRIApp.Repository` usaba EF Core 6.0 mientras la API usaba EF Core 8.0, causando conflictos de dependencias (`NU1605`).  
**Solución:** Actualizar todos los paquetes EF Core a la versión 8.0.4 en todos los proyectos, alineando también `Microsoft.AspNetCore.Authentication.JwtBearer` y `System.IdentityModel.Tokens.Jwt`.

### 6. Formato URI incompatible con Npgsql en migraciones
**Problema:** Neon proporciona la connection string en formato URI (`postgresql://...`), que Npgsql no acepta en tiempo de diseño (migraciones EF).  
**Solución:** Crear un segundo secret `NEON_CONNECTION_STRING_KV` con formato key-value para las migraciones, y actualizar el mismo formato en Azure App Service.

### 7. `OnConfiguring` no leía variables de entorno
**Problema:** El método `OnConfiguring` del `AppContext` solo leía `appsettings.json`, ignorando las variables de entorno de la pipeline.  
**Solución:** Añadir `.AddEnvironmentVariables()` al `ConfigurationBuilder` y el paquete `Microsoft.Extensions.Configuration.EnvironmentVariables`.

### 8. Hangfire LiteDB crasheaba en startup
**Problema:** Hangfire intentaba crear `hf.db` en el directorio de trabajo, que puede no ser escribible en Azure App Service F1.  
**Solución:** Migrado a `Hangfire.PostgreSql` usando Neon como storage, eliminando la dependencia de sistema de ficheros.

### 9. Secrets expuestos en `appsettings.json`
**Problema:** Credenciales de Twilio, Mailjet y JWT estaban hardcodeadas en `appsettings.json` y versionadas en el repositorio.  
**Solución:** Credenciales movidas a `appsetting.development.json` (excluido del control de versiones) para desarrollo local, y a Application Settings de Azure para producción. El `appsettings.json` del repositorio solo contiene valores de configuración no sensibles.

### 10. `Program.cs` monolítico difícil de mantener
**Problema:** Toda la configuración de servicios (JWT, Hangfire, Health Checks, FluentValidation, etc.) estaba inline en `Program.cs`, violando el principio de responsabilidad única.  
**Solución:** Extraída a 6 clases de extensión en `src/CRIApp.Api/Extensions/` (ver sección [Refactor de Program.cs](#7-refactor-de-programcs--extensiones-por-responsabilidad)).

---

## Pendiente / Trabajo futuro

- [x] Reactivar el job recurrente de Hangfire — migrado a `Hangfire.PostgreSql`.
- [x] Añadir cobertura de código al informe de la pipeline — validación automática con umbral del 80%.
- [x] Eliminar secrets del repositorio — movidos a `appsetting.development.json` y Azure App Settings.
- [x] Refactorizar `Program.cs` — extraído a extensiones por responsabilidad.
- [ ] Configurar dominio personalizado con SSL (requiere plan B1 o superior).
- [ ] Considerar mover a `appsettings.Production.json` generado en la pipeline mediante secrets.
- [ ] Rotar las credenciales de Twilio y Mailjet como medida de seguridad preventiva.
