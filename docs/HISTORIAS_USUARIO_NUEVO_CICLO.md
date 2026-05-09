# CRIApp - Revisión de Trello, Requisitos v1.4 y Nuevas Historias de Usuario

Fecha: 30 de marzo de 2026 | Última actualización: 9 de mayo de 2026
Objetivo: alinear el backlog del nuevo ciclo con la auditoría del board histórico y con el documento de requisitos técnicos v1.4 (estado real de implementación).
Versión: 1.4

## Estado global del backlog (8 mayo 2026)

| HU | Título | Estado |
|----|--------|--------|
| HU-001 | Anteproyecto TFM | ✅ DONE |
| HU-002 | Refactor arquitectura Android | ✅ DONE |
| HU-003 | Cliente API Android robusto | ✅ DONE |
| HU-004 | Cierre de primer login y onboarding | ✅ DONE |
| HU-005 | Hardening de seguridad de API | ⬜ No iniciado |
| HU-006 | Pruebas backend de servicios críticos | ⬜ No iniciado |
| HU-007 | Observabilidad y logging estructurado | ⬜ No iniciado |
| HU-008 | Sistema de premios por progreso | ✅ DONE |
| HU-009 | Notificaciones útiles | 🔄 EN PROGRESO |
| HU-010 | Desactivación de cuenta end-to-end | 🔄 EN PROGRESO (backend ✅) |
| HU-011 | Visualización robusta de recursos audiovisuales | ✅ DONE |
| HU-012 | Consulta de historial de notificaciones | ⬜ No iniciado |
| HU-013 | Despliegue cloud gratuito de API | ⬜ No iniciado |
| HU-014 | Memoria final del TFM | ⬜ No iniciado |
| HU-015 | Preparación de defensa en tribunal | ⬜ No iniciado |
| HU-016 | Soporte multilingüe (i18n) | ✅ DONE |
| HU-017 | Mejoras en sistema de gamificación (premios conductuales) | ✅ DONE |
| HU-018 | Sistema de Recomendaciones personalizadas | ✅ DONE |
| HU-019 | Limpieza automática de códigos de reset de contraseña | ✅ DONE |
| HU-020 | Mejoras en templates de email (diseño y localización) | ✅ DONE |

## 1. Backlog nuevo de historias de usuario (siguiendo formato de teoría)

Formato aplicado por historia:

- Enunciado: Como [rol], quiero [necesidad], para [beneficio].
- Criterios de aceptación en estilo BDD (Dado/Cuando/Entonces).
- Definición de Hecho (DoD).

Prioridad:

- Alta: imprescindible para defensa y calidad final.
- Media: alto valor pero secuenciable.
- Baja: mejora evolutiva.

Orden de ejecución: las historias están ordenadas respetando dependencias técnicas y hitos académicos. Se trabaja primero el compromiso de fecha fija (anteproyecto), luego la base técnica Android, luego calidad y seguridad, luego funcionalidades y, por último, el cierre académico.

---

## Grupo A — Compromiso académico urgente

---

## HU-001 - Anteproyecto TFM (1 página PDF)

Prioridad: Alta
Tipo: Académica/Entrega
Estimación: 2 puntos
Fecha objetivo: 7 de abril de 2026

Como estudiante del TFM,
quiero preparar y entregar un anteproyecto de una página en PDF,
para formalizar el alcance, el enfoque técnico y el plan inicial ante la universidad.

Criterios de aceptación (BDD):

- Dado el estado actual del proyecto,
  cuando redacte el anteproyecto,
  entonces el documento resumirá problema, objetivos, metodología y plan de trabajo.
- Dado el plazo académico,
  cuando llegue el 7 de abril de 2026,
  entonces el PDF estará finalizado y listo para entrega.

DoD:

- PDF de 1 página generado.
- Contenido alineado con metodología y backlog vigente.
- Versión registrada en docs para trazabilidad.

---

## Grupo B — Fundamentos técnicos Android

---

## HU-002 - Refactor de arquitectura Android

Prioridad: Alta
Tipo: Técnica
Estimación: 8 puntos

Como equipo de desarrollo,
quiero reorganizar la app Android con arquitectura por capas y patrón MVVM,
para mejorar mantenibilidad, testabilidad y escalabilidad del producto.

Criterios de aceptación (BDD):

- Dado un módulo funcional de Android,
  cuando se revise su estructura,
  entonces la lógica de UI, dominio y acceso a datos estará separada.
- Dado un flujo crítico (autenticación o hijos),
  cuando se ejecute en app,
  entonces no dependerá de lógica de negocio embebida directamente en Activity.

DoD:

- Se define estructura objetivo (presentación/dominio/datos).
- Se migra al menos un vertical completo (ejemplo: autenticación).
- Se documenta decisión de arquitectura para memoria.

---

## HU-003 - Cliente API Android robusto

Prioridad: Alta
Tipo: Técnica
Estimación: 5 puntos

Como desarrollador Android,
quiero utilizar un cliente HTTP robusto
para reducir duplicación y mejorar la calidad del código.

Criterios de aceptación (BDD):

- Dado un cambio de entorno (desarrollo o producción),
  cuando se actualice la configuración de base URL,
  entonces no será necesario modificar ninguna llamada de red individual.
- Dado un response JSON de la API,
  cuando el cliente HTTP lo reciba,
  entonces se deserializará automáticamente al modelo de datos correspondiente sin conversión manual intermedia.

DoD:

- Configuración de base URL externalizada por entorno.
- Eliminación de duplicaciones relevantes.
- Eliminación de conversiones de modelo en JSON innecesarias.

---

## HU-004 - Cierre de primer login y onboarding

Prioridad: Alta
Tipo: Funcional/Calidad
Estimación: 3 puntos

Como usuario nuevo de CRIApp,
quiero que el flujo de primer login y bienvenida quede controlado una única vez,
para entrar a la app sin fricción ni pantallas repetidas en accesos posteriores.

Criterios de aceptación (BDD):

- Dado un usuario en su primer acceso,
  cuando inicie sesión correctamente,
  entonces se mostrarán pantallas de bienvenida según el flujo definido.
- Dado un usuario que ya completó el primer acceso,
  cuando vuelva a autenticarse,
  entonces no se repetirá el onboarding y accederá al flujo principal.

DoD:

- Persistencia de estado de primer login implementada y validada.
- Manejo de casos borde (reinstalación/sesión expirada) documentado.
- Evidencia funcional en app Android.

---

## Grupo C — Calidad y seguridad

---

## HU-005 - Hardening de seguridad de API

Prioridad: Alta
Tipo: Calidad/Seguridad
Estimación: 5 puntos

Como autor del TFM,
quiero endurecer configuración y seguridad de la API,
para reducir riesgo técnico y cumplir buenas prácticas académicas/profesionales.

Criterios de aceptación (BDD):

- Dado el entorno de producción,
  cuando arranque la API,
  entonces los secretos no estarán en repositorio y se aplicará HTTPS.
- Dado un endpoint protegido,
  cuando reciba token inválido,
  entonces responderá con error de autorización controlado.

DoD:

- Secretos fuera de código versionado.
- Configuración por entorno completada.
- Checklist de seguridad mínima validado.

---

## HU-006 - Pruebas backend de servicios críticos

Prioridad: Alta
Tipo: Calidad
Estimación: 8 puntos

Como equipo técnico,
quiero pruebas automatizadas en servicios backend críticos,
para detectar regresiones y elevar la calidad del sistema.

Criterios de aceptación (BDD):

- Dado un cambio en servicios de usuario/preguntas/hijos,
  cuando se ejecute la suite,
  entonces se validarán casos positivos y negativos clave.
- Dada una regresión funcional,
  cuando se ejecute CI,
  entonces la falla será detectada antes de integrar.

DoD:

- Proyecto de tests backend incorporado.
- Casos críticos implementados y ejecutables en CI.
- Reporte básico de resultados/cobertura.

---

## HU-007 - Observabilidad y logging estructurado

Prioridad: Media
Tipo: Calidad/Operación
Estimación: 5 puntos

Como responsable técnico del TFM,
quiero disponer de logging estructurado con contexto técnico y de negocio,
para diagnosticar errores y demostrar trazabilidad operativa del sistema.

Criterios de aceptación (BDD):

- Dado un evento crítico de negocio o error técnico,
  cuando ocurra en API,
  entonces quedará registrado con campos estructurados y contexto mínimo útil.
- Dada una incidencia funcional,
  cuando se revise el log,
  entonces será posible rastrear causa probable sin inspección manual extensa de código.

DoD:

- Estándar de logs definido e implementado en endpoints/servicios clave.
- Registro de errores con contexto de correlación disponible.
- Evidencia de consulta de logs documentada para memoria.

---

## Grupo D — Funcionalidades

---

## HU-008 - Sistema de gamificación: premios, puntuación y flujo de preguntas

Estado: ✅ DONE (cerrado: 9 de mayo de 2026)
Prioridad: Alta
Tipo: Funcional/Mejora
Estimación: 8 puntos

Como usuario de CRIApp,
quiero recibir premios basados en mi comportamiento de uso y responder a un conjunto de preguntas diarias relevante para mi situación familiar,
para mantenerme motivado, obtener retroalimentación significativa y adherirme al proceso de evaluación.

Criterios de aceptación (BDD):

- Dado un hito de progreso conductual cumplido,
  cuando el job diario se ejecute,
  entonces se asignará el premio correspondiente al usuario.
- Dado un usuario con premios asignados,
  cuando consulte la sección de logros,
  entonces verá los premios con imágenes diferenciadas según si están alcanzados o no.
- Dado un usuario que responde preguntas para un hijo,
  cuando solicite la lista diaria,
  entonces recibirá hasta 5 preguntas filtradas por tipo de familia, sin repetir preguntas respondidas en los últimos 7 días, en orden aleatorio.
- Dado un usuario en la pantalla de preguntas,
  cuando seleccione una respuesta en la escala Likert (1–6),
  entonces la interfaz mostrará el color correspondiente al valor y tipo de puntuación (normal o invertida), con animación de transición entre preguntas.
- Dado que la respuesta se está enviando,
  cuando el sistema procese la petición,
  entonces los botones de respuesta y avance estarán desactivados hasta confirmar éxito o error.

DoD:

**Backend — Score y premios:**
- ✅ Job `UpdateUsersScoreJob`: recalcula score diariamente (respuestas correctas × 100 / total, escala 0–100%). Tipos `Default` (1–4 positivos) y `Reversed` (5–6 positivos).
- ✅ Job `CalculateAndSaveAwards`: evalúa y persiste 5 tipos de premio conductual:
  - `FirstSteps`: ≥5 preguntas distintas respondidas.
  - `EngagedFamily`: respuestas en 3 días consecutivos.
  - `Overcoming`: puntuación mejorada ≥20% respecto al día anterior.
  - `PositiveEnvironment`: puntuación > 80.
  - `SmallProgress`: puntuación mejorada respecto al día anterior.
- ✅ Endpoint GET `/users/{id}/awards` con `AwardDto`.

**Backend — Consulta de preguntas:**
- ✅ Filtrado por `FamilyType` del usuario: las preguntas excluyen tipos de familia no aplicables (`Question.ExcludedFamilyTypes`).
- ✅ Exclusión de preguntas respondidas en los últimos 7 días (ventana UTC): `GetRecentlyAnsweredQuestionIds` usa `DateTime.UtcNow.Date`.
- ✅ Límite de 5 preguntas respondidas por día por hijo: `GetRemainingQuestions` con ventana UTC.
- ✅ Selección aleatoria del conjunto disponible.
- ✅ Campo `ScoringType` por pregunta: `Default` o `Reversed`.

**Android — Pantalla de preguntas:**
- ✅ Escala Likert extendida a 6 opciones (botones `likert_btn_1` a `likert_btn_6`).
- ✅ Colores de los botones Likert reflejan el tipo de puntuación: orden normal para `Default`, invertido para `Reversed` (`updateLikertButtons`).
- ✅ Barra de degradado alineada con el tipo de scoring.
- ✅ Animación de transición al avanzar de pregunta (fade + slide horizontal).
- ✅ Barra de progreso sin animación en carga inicial (`animate = false` → `setProgressCompat(progress, false)`).
- ✅ Desactivación de flecha y botones Likert durante `UiState.Loading`; reactivación en `Success`/`Error`.
- ✅ Guard en `QuestionViewModel.answerQuestion()`: retorno anticipado si ya hay una petición en vuelo.

**Android — Premios:**
- ✅ `AwardActivity` + `AwardViewModel` + `AwardViewModelFactory` + `AwardAdapter` con MVVM.
- ✅ `IAwardRepository` + `AwardRepositoryImpl`.
- ✅ Imágenes diferenciadas por tipo de premio (`AwardResources.kt`).
- ✅ Navegación desde `MenuActivity`.

Nota técnica: Se optó por premios de carácter conductual/cualitativo en lugar de umbrales numéricos fijos, alineado con teorías de motivación intrínseca (autodeterminación). Decisión registrada en ADR.

---

## HU-009 - Notificaciones útiles

Estado: 🔄 EN PROGRESO (iniciado: 8 de mayo de 2026)
Prioridad: Alta
Tipo: Funcional/Calidad
Estimación: 5 puntos

Como usuario de CRIApp,
quiero recibir notificaciones útiles (recordatorios/progreso),
para mantener continuidad en el aprendizaje.

Criterios de aceptación (BDD):

- Dado un usuario con actividad baja,
  cuando se cumpla regla de recordatorio,
  entonces el sistema enviará notificación por canal configurado.
- Dado un envío de notificación,
  cuando se procese,
  entonces quedará registro de éxito/error para seguimiento.

DoD:

- Job de notificaciones con lógica real de negocio (evaluar usuarios con preguntas pendientes y enviar máximo una notificación diaria por usuario).
- Integración estable con canal de mensajería configurado (correo o SMS según configuración del entorno).
- Logging y control de errores implementados.

Progreso actual:

- ✅ Job `NotifyUsersWithLessThanTenAnswersJob` creado y registrado en el scheduler (skeleton con TODO: integrar push notifications Android).
- ✅ Sistema de email (SMTP) mejorado: plantillas HTML con logo embebido como adjunto, traducciones ES/EN/PT en `EmailMessages.{resx}`.
- ✅ Job `CleanUserResetPasswordCodesJob` implementado: limpia códigos de recuperación de contraseña con antigüedad > 10 minutos.
- ⏳ Pendiente: integración de push notifications nativas Android (FCM o similar) en el job de recordatorio.

---

## HU-010 - Desactivación de cuenta end-to-end

Estado: 🔄 EN PROGRESO — Backend ✅ / Android ⏳
Prioridad: Media
Tipo: Funcional
Estimación: 3 puntos

Como usuario autenticado,
quiero desactivar mi cuenta desde la app,
para tener control sobre mi permanencia en el sistema.

Criterios de aceptación (BDD):

- Dado un usuario autenticado,
  cuando solicite desactivar su cuenta,
  entonces el backend registrará el estado inactivo y la app lo reflejará.
- Dado un usuario con cuenta desactivada,
  cuando intente iniciar sesión,
  entonces recibirá respuesta de acceso denegado controlada.

DoD:

- Flujo completo backend + Android implementado.
- Mensajería de estado consistente para usuario.
- Prueba de regresión mínima del flujo de autenticación.

Progreso actual:

- ✅ Backend: endpoint POST /users/{id}/deactivate implementado en `UserController`, servicio `UserService.Deactivate()`, lógica de dominio `user.Deactivate()` en entidad `User`.
- ⏳ Pendiente: flujo Android (botón en ProfileActivity o similar, confirmación de usuario, cierre de sesión automático tras desactivación).

---

## HU-011 - Visualización robusta de recursos audiovisuales

Prioridad: Media
Tipo: Funcional/Calidad
Estimación: 3 puntos

Como usuario de CRIApp,
quiero visualizar recursos audiovisuales sin errores de carga,
para consumir contenido educativo dentro del flujo de la app.

Criterios de aceptación (BDD):

- Dado un recurso audiovisual válido,
  cuando lo abra desde la app,
  entonces el contenido se reproducirá correctamente.
- Dado un recurso con fallo de carga,
  cuando falle la visualización,
  entonces la app mostrará error controlado y opción de reintento.

DoD:

- Visualización de enlaces/embebidos validada en Android.
- Manejo de errores y estados de carga implementado.
- Evidencia funcional registrada para memoria.

---

## HU-012 - Consulta de historial de notificaciones

Prioridad: Media
Tipo: Funcional
Estimación: 3 puntos

Como usuario de CRIApp,
quiero consultar el historial de notificaciones enviadas,
para revisar recordatorios y eventos relevantes de mi actividad.

Criterios de aceptación (BDD):

- Dado un usuario con notificaciones enviadas,
  cuando abra la sección de historial,
  entonces verá listado con tipo, contenido, fecha y estado.
- Dado un usuario sin notificaciones,
  cuando consulte el historial,
  entonces verá estado vacío informativo sin error.

DoD:

- Endpoint y vista de historial de notificaciones disponibles.
- Campos mínimos (tipo, contenido, fecha, estado) validados.
- Evidencia funcional en API y app.

---

## Grupo E — DevOps

---

## HU-013 - Despliegue cloud gratuito de API

Prioridad: Alta
Tipo: DevOps
Estimación: 5 puntos

Como responsable técnico de la CRIApp,
quiero desplegar la API en una nube gratuita,
para demostrar viabilidad real y disponer de entorno público de validación.

Criterios de aceptación (BDD):

- Dado un proveedor cloud gratuito seleccionado,
  cuando se realice el despliegue,
  entonces la API estará accesible mediante HTTPS.
- Dado un cambio en rama principal,
  cuando se ejecute pipeline,
  entonces se podrá desplegar sin pasos manuales críticos.

DoD:

- URL pública operativa.
- Variables de entorno y secretos externalizados.
- Guía de despliegue documentada para memoria.

---

## HU-016 - Soporte multilingüe (i18n)

Estado: ✅ DONE (cerrado: 8 de mayo de 2026)
Prioridad: Media
Tipo: Calidad/Funcional
Estimación: 3 puntos

Como usuario de CRIApp,
quiero que la aplicación y sus comunicaciones estén disponibles en mi idioma (español, inglés o portugués),
para reducir la barrera de uso y mejorar la experiencia global.

Criterios de aceptación (BDD):

- Dado un usuario con idioma configurado en el dispositivo,
  cuando reciba un correo o mensaje de la app,
  entonces el contenido estará en su idioma (ES/EN/PT).
- Dado un usuario que usa la app Android en inglés o portugués,
  cuando navegue por las pantallas,
  entonces los textos se mostrarán en el idioma del sistema operativo.

DoD:

- ✅ API: recursos de mensajes `AppMessages` y `EmailMessages` implementados en ES/EN/PT mediante archivos `.resx` con localización dinámica vía `IStringLocalizer`.
- ✅ API: traducciones aplicadas a mensajes de validación, excepciones de negocio y contenido de emails.
- ✅ Android: archivos `strings.xml` en `values/`, `values-en/` y `values-pt/` con textos de interfaz completos.
- ✅ Entidades con campos de traducción: `Recommendation.TextEn`, `Recommendation.TextPt`; Question y otros recursos con campos equivalentes.
- ✅ Migración de base de datos `AddTranslationColumns` aplicada.

---

## HU-017 - Mejoras en sistema de gamificación (premios conductuales)

Estado: ✅ DONE (cerrado: 9 de mayo de 2026)
Prioridad: Media
Tipo: Funcional/Mejora
Estimación: 3 puntos

---

## HU-018 - Sistema de Recomendaciones personalizadas

Estado: ✅ DONE (cerrado: 9 de mayo de 2026)
Prioridad: Alta
Tipo: Funcional
Estimación: 5 puntos

Como usuario de CRIApp,
quiero recibir recomendaciones personalizadas basadas en mis respuestas,
para mejorar el bienestar de mi familia con contenido relevante a mi situación.

Criterios de aceptación (BDD):

- Dado un usuario con respuestas registradas,
  cuando el admin asocie recomendaciones,
  entonces el usuario podrá consultarlas desde la app en su idioma.
- Dado un usuario con idioma configurado,
  cuando acceda a recomendaciones,
  entonces se mostrarán en ES, EN o PT según `Accept-Language`.

DoD:

- ✅ Entidad `Recommendation` con `Text`, `TextEn`, `TextPt`, asociada a `Question` y `User`.
- ✅ Endpoint GET `/users/{id}/recommendations` con internacionalización.
- ✅ Migrations: `AddRecommendationsToUsersTable`, `AddRecommendationTable`, `AddTranslationColumns`.
- ✅ Android: `RecommendationActivity` + `RecommendationViewModel` + `RecommendationAdapter` + 45 imágenes (`rec_01.png` a `rec_45.png`) mapeadas en `RecommendationResources.kt`.

---

## HU-019 - Limpieza automática de códigos de reset de contraseña

Estado: ✅ DONE (cerrado: 9 de mayo de 2026)
Prioridad: Media
Tipo: Técnica/Seguridad
Estimación: 1 punto

Como administrador del sistema,
quiero que los códigos de reset de contraseña expirados sean eliminados automáticamente,
para mantener la base de datos limpia y cumplir con buenas prácticas de seguridad.

Criterios de aceptación (BDD):

- Dado que un usuario solicitó un reset de contraseña hace más de 10 minutos,
  cuando se ejecute el job de limpieza,
  entonces el código será eliminado de la base de datos.
- Dado un código de reset activo (< 10 min),
  cuando se ejecute el job,
  entonces no será eliminado.

DoD:

- ✅ Job `CleanUserResetPasswordCodesJob` implementado y registrado en Hangfire.
- ✅ Criterio de expiración: antigüedad > 10 minutos.
- ✅ Sin impacto en códigos activos validado.

---

## HU-020 - Mejoras en templates de email (diseño y localización)

Estado: ✅ DONE (cerrado: 9 de mayo de 2026)
Prioridad: Media
Tipo: Funcional/Calidad
Estimación: 2 puntos

Como usuario de CRIApp,
quiero recibir emails de bienvenida y recuperación de contraseña con un diseño profesional y localizado,
para tener una experiencia de usuario coherente y de confianza.

Criterios de aceptación (BDD):

- Dado un usuario que se registra o solicita reset de contraseña,
  cuando reciba el email,
  entonces el contenido estará en su idioma (ES/EN/PT) con logo y diseño HTML completo.
- Dado el logo de la aplicación,
  cuando se envíe el email,
  entonces el logo estará embebido como adjunto inline (CID), no como enlace externo.

DoD:

- ✅ Logo embebido como adjunto inline en el email.
- ✅ `EmailMessages.resx` en ES/EN/PT con cobertura completa de ambos flujos (creación de cuenta y recuperación de contraseña).
- ✅ Templates HTML con variables localizadas: asunto, título, preheader, heading, cuerpo, pie de página.
- ✅ SMS de creación de cuenta y recuperación de contraseña localizados.

---

## Grupo F — Cierre académico

---

## HU-014 - Memoria final del TFM

Prioridad: Alta
Tipo: Académica/Entrega
Estimación: 13 puntos
Fecha objetivo: fin de junio de 2026

Como autor del TFM,
quiero construir la memoria final a partir de toda la documentación técnica y evidencias del proyecto,
para presentar un trabajo coherente, defendible y alineado con los resultados obtenidos.

Criterios de aceptación (BDD):

- Dado el conjunto de documentos existentes,
  cuando avance la redacción,
  entonces cada capítulo estará trazado con requisitos, implementación, pruebas y resultados.
- Dado el cierre del desarrollo,
  cuando consolide la memoria,
  entonces incluirá análisis técnico, decisiones de arquitectura, validación y conclusiones.

DoD:

- Índice y estructura académica cerrados.
- Conversión de docs técnicos a secciones de memoria completada.
- Versión final preparada para entrega a finales de junio.

---

## HU-015 - Preparación de defensa en tribunal

Prioridad: Alta
Tipo: Académica/Defensa
Estimación: 8 puntos
Fecha objetivo: previo a la fecha oficial de defensa

Como estudiante del TFM,
quiero preparar la defensa (diapositivas, guion y demo en vivo),
para comunicar con claridad el valor académico y técnico de CRIApp ante el tribunal.

Criterios de aceptación (BDD):

- Dado el contenido de memoria,
  cuando prepare las diapositivas,
  entonces quedarán cubiertos problema, metodología, implementación, resultados y trabajo futuro.
- Dado un entorno de demo,
  cuando ejecute la presentación completa,
  entonces la demo en vivo funcionará de extremo a extremo sin bloqueos críticos.

DoD:

- Presentación final de defensa completada.
- Script de demo y plan de contingencia preparados.
- Ensayo cronometrado realizado al menos una vez.
