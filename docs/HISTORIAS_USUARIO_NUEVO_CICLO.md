# CRIApp - Revisión de Trello, Requisitos v1.4 y Nuevas Historias de Usuario

Fecha: 30 de marzo de 2026 | Última actualización: 10 de mayo de 2026
Objetivo: alinear el backlog del nuevo ciclo con la auditoría del board histórico y con el documento de requisitos técnicos v1.5 (estado real de implementación).
Versión: 1.5

## Estado global del backlog (10 mayo 2026)

| HU | Título | Estado |
|----|--------|--------|
| HU-001 | Anteproyecto TFM | ✅ DONE |
| HU-002 | Refactor arquitectura Android | ✅ DONE |
| HU-003 | Cliente API Android robusto | ✅ DONE |
| HU-004 | Cierre de primer login y onboarding | ✅ DONE |
| HU-005 | Hardening de seguridad de API | ✅ DONE (17 abr) |
| HU-006 | Pruebas backend de servicios críticos | ✅ DONE (17 abr) |
| HU-007 | Observabilidad y logging estructurado | ✅ DONE (17 abr) |
| HU-008 | Sistema de premios por progreso | ✅ DONE |
| HU-009 | Notificaciones útiles | 🔄 EN PROGRESO (depende de HU-027) |
| HU-010 | Desactivación de cuenta end-to-end | ✅ DONE (10 may) |
| HU-011 | Visualización robusta de recursos audiovisuales | ✅ DONE (9 may) |
| HU-012 | Consulta de historial de notificaciones | ⬜ No iniciado |
| HU-013 | Despliegue cloud gratuito de API | ✅ DONE (17 abr — Azure) |
| HU-014 | Memoria final del TFM | ⬜ No iniciado |
| HU-015 | Preparación de defensa en tribunal | ⬜ No iniciado |
| HU-016 | Soporte multilingüe (i18n) | ✅ DONE |
| HU-017 | Rotación inteligente de preguntas diarias y mejoras de UI | ✅ DONE |
| HU-018 | Sistema de Recomendaciones personalizadas | ✅ DONE |
| HU-019 | Limpieza automática de códigos de reset de contraseña | ✅ DONE |
| HU-020 | Mejoras en templates de email (diseño y localización) | ✅ DONE |
| HU-021 | Entidad ChildBook: libro de progreso del hijo | ✅ DONE (10 may) |
| HU-022 | Premios del hijo con traducciones en BD | ✅ DONE (10 may) |
| HU-023 | Renombrar Recomendación a Consejo | ✅ DONE (10 may) |
| HU-024 | Desacoplamiento de admin en FAQ, Question y Consejo | ✅ DONE (10 may) |
| HU-025 | Agrupación de preguntas y rotación por grupo | ⬜ No iniciado |
| HU-026 | Renombrar Advice a Recommendation (alineación HEFAS) | ⬜ No iniciado |
| HU-027 | RecommendationCheckpoint — verificación de rutinas backend | ⬜ No iniciado |
| HU-028 | Actualización del score basada en checkpoints de rutinas | ⬜ No iniciado |
| HU-029 | Nuevos premios por racha de checkpoints | ⬜ No iniciado |
| HU-030 | Android — verificación diaria de rutinas en pantalla de recomendaciones | ⬜ No iniciado |
| HU-031 | Notificaciones basadas en checkpoints de rutinas | ⬜ No iniciado |

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

## HU-017 - Rotación inteligente de preguntas diarias y mejoras de UI

Estado: ✅ DONE (cerrado: 9 de mayo de 2026)
Prioridad: Media
Tipo: Funcional/Mejora
Estimación: 2 puntos

Como usuario de CRIApp,
quiero recibir preguntas de evaluación de forma rotatoria cada día aunque ya las haya respondido antes,
para mantener la continuidad del proceso de evaluación y permitir medir mi progreso a lo largo del tiempo.

Criterios de aceptación (BDD):

- Dado un usuario que ha respondido todas las preguntas disponibles para su perfil familiar,
  cuando solicite la lista diaria de preguntas,
  entonces recibirá preguntas rotatorias (incluyendo previamente respondidas) con lógica anti-repetición inmediata.
- Dado un usuario que responde preguntas con frecuencia,
  cuando el sistema seleccione la lista diaria,
  entonces priorizará preguntas no respondidas recientemente para minimizar repetición a corto plazo.
- Dado un usuario con historial de respuestas acumulado a lo largo del tiempo,
  cuando el sistema sirva preguntas repetidas,
  entonces quedará el registro necesario para comparar cómo responde la misma pregunta en distintos momentos (mejora/deterioro).
- Dado que el usuario entra en la pantalla de preguntas,
  cuando se cargue la interfaz,
  entonces la experiencia visual será mejorada respecto a la versión anterior.

DoD:

- ✅ Lógica de servicio de preguntas actualizada: eliminado el bloqueo de "agotamiento" de preguntas; las preguntas siempre están disponibles.
- ✅ Anti-repetición: el algoritmo de selección prioriza preguntas no respondidas recientemente para evitar repetición inmediata consecutiva.
- ✅ Rotación continua garantizada: el usuario siempre dispone de preguntas para responder, independientemente de su historial.
- ✅ Habilitación futura de análisis longitudinal: el mismo cuestionario repetido en el tiempo registra variaciones de respuesta que permiten medir tendencias de mejora o deterioro.
- ✅ Android: UI de la pantalla de preguntas mejorada (layout, colores, tipografía o interacción visual).

Nota técnica: El cambio de modelo (de "agotamiento hasta fin" a "rotación continua con anti-repetición") es coherente con la teoría de medición repetida (*test-retest reliability*) aplicada a instrumentos de evaluación del bienestar familiar. Permite futuros análisis de tendencia sin necesidad de cambios en el modelo de datos ni en la API.

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

## Grupo G — Refactoring de dominio

---

## HU-021 - Entidad ChildBook: libro de progreso del hijo

Prioridad: Alta
Tipo: Técnica/Refactoring
Estimación: 5 puntos

Como desarrollador,
quiero crear una entidad `ChildBook` que centralice el progreso de cada hijo,
para eliminar el acoplamiento actual donde `Score`, `ScoreLastUpdatedAt` y `Awards` viven en `User` en lugar de en el hijo al que pertenecen.

Contexto técnico:

Actualmente la entidad `User` acumula datos de progreso (`Score`, `ScoreLastUpdatedAt`, `List<Award>`) que semánticamente pertenecen al proceso de evaluación de un hijo concreto. Esto genera acoplamiento y dificulta escalar el modelo cuando un PCR tiene varios hijos. La entidad `ChildBook` actúa como agregado que contiene todo lo relativo al progreso de un hijo específico.

Criterios de aceptación (BDD):

- Dado un hijo registrado en el sistema,
  cuando el sistema procese sus respuestas y calcule su progreso,
  entonces los datos (`Score`, `ScoreLastUpdatedAt`) quedarán persistidos en `ChildBook`, no en `User`.
- Dado un PCR con múltiples hijos,
  cuando consulte el progreso de cada uno,
  entonces cada hijo dispondrá de su propio `ChildBook` independiente.
- Dado el refactoring de `User`,
  cuando se complete la migración,
  entonces los campos `Score`, `ScoreLastUpdatedAt` y la relación `Awards` serán eliminados de `User`.
- Dado el repositorio y servicio existentes de puntuación y premios,
  cuando se adapten a la nueva estructura,
  entonces los jobs `UpdateUsersScoreJob` y `CalculateAndSaveAwards` operarán sobre `ChildBook` en lugar de `User`.

DoD:

- Entidad `ChildBook` creada en `CRIApp.Domain/Entities/ChildBook.cs` con: `ChildId` (FK), `Score`, `ScoreLastUpdatedAt`, `List<Award>`.
- Relación `Child 1–1 ChildBook` configurada en EF Core (mapping y migration).
- `Score` y `ScoreLastUpdatedAt` eliminados de `User`.
- Relación `User.Awards` migrada a `ChildBook.Awards`.
- Jobs `UpdateUsersScoreJob` y `CalculateAndSaveAwards` adaptados.
- Endpoint GET `/children/{childId}/book` o integrado en la respuesta de `/children/{childId}`.
- Pruebas unitarias actualizadas para reflejar el nuevo modelo.
- Migration de base de datos aplicada sin pérdida de datos.

---

## HU-022 - Premios del hijo con traducciones en BD

Prioridad: Media
Tipo: Funcional/Dominio
Estimación: 3 puntos

Como PCR (persona con responsabilidad parental) que usa la app en inglés o portugués,
quiero que los nombres y descripciones de los premios de mi hijo aparezcan en mi idioma,
para entender el significado de cada logro sin barreras lingüísticas.

Contexto técnico:

Actualmente `Award` almacena sólo `AwardType` (enum entero). Los textos del premio se resuelven en el cliente Android mediante recursos de cadenas o hardcode. Esto impide que la API devuelva el texto localizado y complica la internacionalización. La solución es almacenar en BD los campos de nombre y descripción en los tres idiomas (ES/EN/PT), alineando el modelo con el patrón ya establecido en `Question`, `Recommendation` y `Faq`.

Criterios de aceptación (BDD):

- Dado un premio asignado a un hijo,
  cuando la app Android solicite los premios con `Accept-Language: en`,
  entonces la API devolverá `name` y `description` en inglés.
- Dado un premio cuya traducción no existe en la BD para el idioma solicitado,
  cuando la API resuelva el texto,
  entonces hará fallback al español como idioma predeterminado.
- Dado el modelo de dominio actualizado,
  cuando se añadan los campos de traducción a `Award`,
  entonces seguirán el patrón existente: `Name` (ES), `NameEn`, `NamePt`, `Description` (ES), `DescriptionEn`, `DescriptionPt`.
- Dado un premio ya asignado (sin traducciones migradas),
  cuando la API lo devuelva,
  entonces no fallará: los campos opcionales retornarán el texto base.

DoD:

- Campos `Name`, `NameEn`, `NamePt`, `Description`, `DescriptionEn`, `DescriptionPt` añadidos a la entidad `Award`.
- `Award` migrada dentro de `ChildBook` (dependencia de HU-021).
- Endpoint de premios actualizado para devolver texto localizado según `Accept-Language`.
- `AwardDto` extendido con `Name` y `Description` localizados.
- Contenido inicial (seed o migration) con textos de los 5 tipos de premio en ES/EN/PT.
- Android: eliminadas las cadenas hardcodeadas de nombres de premios; se usa el texto devuelto por la API.
- Pruebas unitarias de resolución de locale para `Award`.
- Migration de base de datos aplicada.

---

## HU-023 - Renombrar Recomendación a Consejo en toda la plataforma

Prioridad: Media
Tipo: Técnica/UX
Estimación: 2 puntos

Como equipo de desarrollo y responsable académico,
quiero renombrar el concepto `Recommendation` a `Consejo` (consejo parental) en toda la plataforma,
para alinear la terminología con el lenguaje de la investigación en competencias parentales y mejorar la comprensión del usuario final.

Contexto técnico:

El término "Recomendación" es genérico. El ámbito académico del CRI (Cuestionario de Relaciones con los Iguales / herramienta de evaluación parental) usa "consejo" para referirse a las orientaciones concretas que se dan al PCR tras evaluar sus respuestas. Este cambio es semántico, no estructural: el modelo de datos, la lógica de negocio y las relaciones no cambian.

Criterios de aceptación (BDD):

- Dado un endpoint que hoy se llama `/users/{id}/recommendations`,
  cuando se complete el renombrado,
  entonces el endpoint pasará a llamarse `/users/{id}/consejos`.
- Dada la entidad `Recommendation` en el dominio,
  cuando se renombre a `Consejo`,
  entonces toda la cadena (entidad, repositorio, servicio, DTO, controlador, tests) usará el nuevo nombre.
- Dado el texto visible en la app Android,
  cuando el usuario acceda a la sección de consejos,
  entonces verá el término "Consejo" (ES), "Advice" (EN), "Conselho" (PT) en lugar de "Recomendación".
- Dado el renombrado,
  cuando se ejecute la suite de tests,
  entonces todos los tests pasarán sin modificación de lógica.

DoD:

- Entidad `Recommendation` renombrada a `Consejo` en `CRIApp.Domain`.
- Tabla en BD renombrada mediante migration (`RenameRecommendationsTable`).
- Repositorio `IRecommendationRepository` → `IConsejoRepository`.
- Servicio `IRecommendationService` → `IConsejoService`.
- DTO `RecommendationDto` → `ConsejoDto`.
- Endpoint `/users/{id}/recommendations` → `/users/{id}/consejos`.
- `UserRecommendation` → `UserConsejo` (tabla de relación).
- Android: `RecommendationActivity`, `RecommendationViewModel`, `RecommendationAdapter` renombrados; cadenas de UI actualizadas en ES/EN/PT.
- Todos los tests actualizados y pasando.

---

## HU-024 - Desacoplamiento de admin en FAQ, Question y Consejo

Prioridad: Alta
Tipo: Técnica/Dominio
Estimación: 5 puntos

Como equipo de desarrollo,
quiero eliminar la dependencia explícita de un usuario administrador en las entidades `Faq`, `Question` y `Consejo`,
para simplificar el modelo de dominio, homogeneizar la nomenclatura con el resto de entidades (que ya usan `PrcId`) y reducir la rigidez del sistema de permisos.

Contexto técnico:

Actualmente, `Faq`, `Question` y `Consejo` (ex-`Recommendation`) tienen un campo `AdminId: Guid` con FK obligatoria a `User` y una validación en dominio que exige que el creador sea administrador. Esto acopla el modelo de negocio al rol de usuario, hace que las entidades no sean creables sin un admin existente y genera asimetría respecto a otras entidades (`Child`, `Award`) que ya usan `PrcId`. El objetivo es:
1. Renombrar `AdminId`/`Admin` a `PrcId`/`Prc` en las tres entidades.
2. Eliminar la validación de dominio que requiere `IsAdmin = true`.
3. Actualizar las navigation properties en `User` (sección `#region admin fields`) para usar la nueva nomenclatura.

Criterios de aceptación (BDD):

- Dada la entidad `Faq`,
  cuando se revise su constructor y sus propiedades,
  entonces no habrá referencia a `AdminId` ni a `Admin`; en su lugar existirá `PrcId` y `Prc`.
- Dada la entidad `Question`,
  cuando se revise su validación de dominio,
  entonces no existirá comprobación de `IsAdmin`; cualquier PCR autenticado podrá ser el creador.
- Dada la entidad `Consejo`,
  cuando se revise su constructor,
  entonces `AdminId` habrá sido reemplazado por `PrcId`.
- Dado el modelo `User`,
  cuando se revise la región `#region admin fields`,
  entonces las propiedades de navegación (`Questions`, `AdminRecommendations`, `Faqs`, `AudiovisualResources`) habrán sido renombradas a nombres neutrales o eliminadas si no son necesarias para la carga de datos.
- Dado el sistema en producción,
  cuando se aplique la migration de BD,
  entonces las columnas `admin_id` en las tablas afectadas serán renombradas a `prc_id` sin pérdida de datos.
- Dados los tests unitarios existentes,
  cuando se ejecute la suite tras el cambio,
  entonces todos pasarán con la nueva nomenclatura.

DoD:

- `Faq.AdminId` → `Faq.PrcId`; `Faq.Admin` → `Faq.Prc`.
- `Question.AdminId` → `Question.PrcId`; `Question.Admin` → `Question.Prc`; eliminada validación `IsAdmin`.
- `Consejo.AdminId` → `Consejo.PrcId`; `Consejo.Admin` → `Consejo.Prc`.
- `User.Questions`, `User.AdminRecommendations`, `User.Faqs`, `User.AudiovisualResources` renombradas a `User.CreatedQuestions`, `User.CreatedConsejos`, `User.CreatedFaqs`, `User.CreatedAudiovisualResources` (o eliminadas si no se usan en queries).
- Mappings EF Core (`FaqMapping`, `QuestionMapping`, `ConsejoMapping`) actualizados.
- Migration `RenameAdminToPrcInContentEntities` aplicada.
- Todos los servicios, repositorios, DTOs y tests actualizados.
- Lógica de autorización en endpoints no cambia (la API sigue requiriendo JWT válido); sólo cambia la semántica del campo creador en dominio.

---

## HU-025 - Agrupación de preguntas y rotación por grupo

Prioridad: Alta
Tipo: Funcional/Dominio
Estimación: 3 puntos

Como PCR (persona con responsabilidad parental),
quiero que las preguntas diarias que recibo cubran siempre distintas áreas del desarrollo parental,
para recibir una evaluación equilibrada y no sesgada hacia un único tema en una misma sesión.

Contexto técnico:

Actualmente la selección de preguntas es aleatoria dentro del pool disponible para el perfil familiar del PCR. Si todas las preguntas disponibles pertenecen a una misma dimensión temática (por ejemplo, "estimulación cognitiva"), el usuario puede recibir una batería desequilibrada. Añadir un campo `Group` (o `QuestionGroup`) a la entidad `Question` permite que el algoritmo de selección garantice al menos una pregunta por grupo activo, distribuyendo la evaluación de forma homogénea.

Criterios de aceptación (BDD):

- Dado un conjunto de preguntas con distintos grupos definidos,
  cuando el sistema seleccione la lista diaria de 5 preguntas,
  entonces incluirá al menos una pregunta de cada grupo con preguntas disponibles, hasta completar el límite de 5.
- Dado un grupo sin preguntas disponibles para el perfil familiar del PCR (por exclusión de FamilyType),
  cuando el sistema construya la lista,
  entonces omitirá ese grupo sin error y cubrirá los restantes.
- Dado un grupo con todas sus preguntas respondidas recientemente (dentro de la ventana anti-repetición de 7 días),
  cuando el sistema seleccione preguntas,
  entonces usará preguntas de ese grupo aunque ya hayan sido respondidas, manteniendo la cobertura por grupo.
- Dado el campo `Group` añadido a `Question`,
  cuando un administrador cree o edite una pregunta,
  entonces podrá asignarle un grupo de los valores definidos en el enum `QuestionGroup`.
- Dado el endpoint existente de preguntas,
  cuando devuelva la lista diaria,
  entonces incluirá el campo `group` en cada pregunta del response.

DoD:

- Enum `QuestionGroup` creado en `CRIApp.Domain/Enums/QuestionGroup.cs` con los grupos temáticos iniciales (mínimo 4: `CognitiveDevelopment`, `EmotionalBonding`, `DailyRoutines`, `SocialInteraction`).
- Campo `Group` (`QuestionGroup`) añadido a la entidad `Question` como campo obligatorio.
- Migration `AddGroupToQuestion` aplicada sin pérdida de datos (columna nullable en migración, luego constraint tras seed).
- Algoritmo de selección en `QuestionService.GetRemainingQuestions()` actualizado: selección de 1 pregunta por grupo disponible, luego relleno aleatorio hasta 5.
- `QuestionDto` actualizado con campo `Group`.
- Endpoint de creación/edición de preguntas (admin) actualizado para aceptar `Group`.
- Android: campo `group` recibido en el modelo de datos; UI puede mostrar etiqueta o icono de grupo (opcional para MVP).
- Pruebas unitarias de `QuestionService` actualizadas para verificar la lógica de selección por grupo.
- Migration y seed de grupos iniciales aplicados.

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

---

## Grupo H — Bucle conductual HEFAS (loop de verificación de rutinas)

Contexto: tras el análisis del protocolo HEFAS, se identificó que el sistema de orientaciones/recomendaciones no es solo un listado estático. El protocolo exige que la app pregunte periódicamente al PCR si ha realizado las rutinas asignadas, recompense la constancia y reprograme la evaluación a los 7 días. Las HU-026 a HU-031 implementan este bucle completo.

---

## HU-026 - Renombrar Advice a Recommendation (alineación protocolo HEFAS)

Prioridad: Alta
Tipo: Técnica/Semántica
Estimación: 2 puntos

Como equipo de desarrollo,
quiero renombrar la entidad `Advice` (Consejo) a `Recommendation` en toda la plataforma,
para alinear la terminología del código con el protocolo HEFAS, que denomina "orientación/recomendación" a las guías parentales generadas tras la evaluación.

Contexto técnico:

La entidad fue renombrada de `Recommendation` a `Consejo`/`Advice` en HU-023. Tras el análisis del protocolo HEFAS, el término correcto del dominio científico es "recomendación u orientación". El término `Consejo` introduce ambigüedad semántica en el contexto académico. Este cambio es el prerequisito para HU-027, que introduce `RecommendationCheckpoint`.

Criterios de aceptación (BDD):

- Dada la entidad `Advice` en el dominio,
  cuando se complete el renombrado,
  entonces toda la cadena (entidad, repositorio, DTO, controlador, tests) usará `Recommendation`.
- Dado el endpoint `/child/{id}/book` que expone las orientaciones como `advices`,
  cuando se renombre,
  entonces el campo JSON pasará a llamarse `recommendations`.
- Dado el trabajo ya realizado en HU-023,
  cuando se aplique esta HU,
  entonces no se modificará lógica de negocio; solo nombres de clases, tablas y variables.

DoD:

- Entidad `Advice` → `Recommendation` en `CRIApp.Domain`.
- Tabla `advices` renombrada → `recommendations` (migration).
- Tabla de relación `child_book_advices` → `child_book_recommendations` (migration).
- `IAdviceRepository` → `IRecommendationRepository`.
- `AdviceDto` → `RecommendationDto` con campo JSON `recommendations`.
- Job `SaveUsersAdvices` → `SaveUsersRecommendations`.
- `ChildBook.Advices` → `ChildBook.Recommendations`.
- Android: `AdviceActivity`, `AdviceAdapter`, modelos e interfaces renombrados; cadenas de UI actualizadas.
- Todos los tests actualizados y pasando.
- Migration de BD aplicada sin pérdida de datos.

---

## HU-027 - RecommendationCheckpoint — sistema de verificación de rutinas (backend)

Prioridad: Alta
Tipo: Funcional/Dominio
Estimación: 5 puntos

Como PCR (persona con responsabilidad parental),
quiero que la app me pregunte diariamente si he realizado las rutinas de las recomendaciones asignadas,
para que el sistema registre mi constancia y me proporcione retroalimentación sobre mi progreso conductual.

Contexto técnico (protocolo HEFAS):

El protocolo HEFAS establece que el criterio de orientación binario (0 = necesita orientación, 1 = no necesaria) genera una recomendación activa. La app debe verificar periódicamente si el PCR aplica la rutina recomendada. Esta verificación es el núcleo del bucle conductual:
`cuestionario → recomendación activa → verificación diaria → puntos → premios → reevaluación`.

Criterios de aceptación (BDD):

- Dada una recomendación activa asignada a un ChildBook,
  cuando el PCR confirme haber realizado la rutina (YES),
  entonces el sistema registrará un `RecommendationCheckpoint` con `completed = true` para la fecha.
- Dada una recomendación activa asignada a un ChildBook,
  cuando el PCR indique no haber realizado la rutina (NO),
  entonces el sistema registrará un `RecommendationCheckpoint` con `completed = false`.
- Dado un checkpoint ya registrado para hoy,
  cuando se intente registrar otro para la misma recomendación y fecha,
  entonces la API devolverá error de validación (no se permite duplicado por día).
- Dado el endpoint `GET /child/{childId}/book`,
  cuando devuelva las recomendaciones,
  entonces incluirá el estado del checkpoint de hoy (`todayCompleted: bool?`) para cada recomendación.

DoD:

- Entidad `RecommendationCheckpoint` creada: `RecommendationId` (FK), `ChildBookId` (FK), `Date` (UTC), `Completed` (bool).
- Clave única compuesta `(RecommendationId, ChildBookId, Date)` para evitar duplicados diarios.
- Endpoint `POST /child/{childId}/book/recommendations/{recommendationId}/checkpoint` con body `{ completed: bool }`.
- `ChildBookDto` extendido: cada `RecommendationDto` incluye `TodayCompleted: bool?` (null si no hay checkpoint hoy).
- Migration `AddRecommendationCheckpointTable` aplicada.
- Tests unitarios para el servicio de checkpoint (caso happy path, caso duplicado).

---

## HU-028 - Actualización del score basada en checkpoints de rutinas

Prioridad: Alta
Tipo: Funcional/Dominio
Estimación: 3 puntos

Como PCR,
quiero que mi puntuación de progreso refleje tanto mis respuestas al cuestionario como el seguimiento de las rutinas recomendadas,
para que el score mida mi comportamiento parental real y no solo mis respuestas a preguntas.

Contexto técnico:

El score actual (`ChildBook.UpdateScore`) se basa únicamente en las respuestas al cuestionario HEFAS. El protocolo establece que la mejora se mide por la aplicación de las orientaciones. La fórmula propuesta es:

```
score = (respuestas_correctas / total_preguntas) × 70
      + (checkpoints_completados / total_recomendaciones_activas) × 30
```

Este cambio hace que el score refleje tanto el diagnóstico (cuestionario) como el comportamiento de seguimiento (checkpoints).

Criterios de aceptación (BDD):

- Dado un ChildBook con respuestas y checkpoints de hoy,
  cuando se ejecute el job de score,
  entonces el score combinará ambas métricas según la fórmula definida.
- Dado un ChildBook sin recomendaciones activas,
  cuando se calcule el score,
  entonces se aplicará la fórmula solo sobre respuestas (peso 100%, sin dividir por 0).
- Dado un ChildBook con recomendaciones pero sin checkpoints de hoy,
  cuando se calcule el score,
  entonces los checkpoints contribuirán con 0 al componente de rutinas.

DoD:

- `ChildBook.UpdateScore()` actualizado para recibir también la lista de `RecommendationCheckpoint` del día.
- Fórmula `70/30` implementada en dominio.
- `UpdateChildBookScoreJob` adaptado para pasar checkpoints al método de score.
- Tests unitarios para la nueva fórmula (sin checkpoints, con checkpoints parciales, con todos completados).
- Documentada la decisión de diseño (fórmula 70/30) en ADR o en el DoD de la HU.

---

## HU-029 - Nuevos premios por racha de checkpoints de rutinas

Prioridad: Media
Tipo: Funcional/Gamificación
Estimación: 3 puntos

Como PCR,
quiero recibir premios especiales cuando mantengo una racha de días cumpliendo las rutinas recomendadas,
para sentirme reconocido por mi constancia y mantener la motivación.

Contexto técnico:

Los premios actuales (`CalculateAndSaveAwards`) se basan en respuestas al cuestionario. El protocolo HEFAS introduce una capa de gamificación sobre el seguimiento de rutinas. Los nuevos tipos de premio son conductuales sobre checkpoints.

Criterios de aceptación (BDD):

- Dado un ChildBook con checkpoints completados 3 días consecutivos,
  cuando el job de premios se ejecute,
  entonces se asignará el premio `HabitBuilder`.
- Dado un ChildBook con al menos un checkpoint completado en 7 días distintos,
  cuando el job se ejecute,
  entonces se asignará el premio `ConsistentParent`.
- Dado que un premio ya fue asignado,
  cuando el job vuelva a ejecutarse,
  entonces no se duplicará (comportamiento idempotente existente).

DoD:

- `AwardType` extendido con `HabitBuilder = 6` y `ConsistentParent = 7`.
- `EvaluateHabitBuilder()` y `EvaluateConsistentParent()` añadidos a `CalculateAndSaveAwards`.
- Seed de datos en BD para los dos nuevos tipos de premio (texto ES/EN/PT + imagen).
- Android: nuevas imágenes y cadenas de texto para los dos nuevos tipos en `AwardResources`.
- Tests unitarios para las dos nuevas condiciones de evaluación.

---

## HU-030 - Android — verificación diaria de rutinas en pantalla de recomendaciones

Prioridad: Alta
Tipo: Funcional/UX
Estimación: 5 puntos

Como PCR,
quiero poder indicar en la app si he realizado hoy la rutina recomendada,
para que el sistema registre mi progreso y me recompense por la constancia.

Contexto técnico:

La pantalla actual (`AdviceActivity` / `RecommendationActivity` tras HU-026) muestra las recomendaciones asignadas en un ViewPager de solo lectura. Esta HU añade la interacción de verificación diaria:

```
[imagen + texto de recomendación]
¿Has realizado esta rutina hoy?
[ ✅ Sí, lo hice ]   [ ❌ Todavía no ]
```

Criterios de aceptación (BDD):

- Dado que el PCR ve una recomendación en el carrusel,
  cuando pulse "Sí, lo hice",
  entonces la app llamará al endpoint de checkpoint con `completed = true` y mostrará confirmación visual.
- Dado que el PCR pulsa "Todavía no",
  cuando se procese,
  entonces se llamará al endpoint con `completed = false` y se mostrará mensaje motivacional.
- Dado que ya se registró un checkpoint hoy para esa recomendación,
  cuando el PCR abra la pantalla,
  entonces los botones estarán desactivados y se mostrará el estado del checkpoint registrado.
- Dado un error de red al registrar el checkpoint,
  cuando falle la llamada,
  entonces se mostrará mensaje de error controlado sin dejar la UI en estado inconsistente.

DoD:

- `RecommendationActivity` (o `AdviceActivity`) actualizada con botones YES/NO por card.
- `RecommendationViewModel` con método `registerCheckpoint(recommendationId, childId, completed)`.
- `IRecommendationRepository` extendido con `registerCheckpoint(...)`.
- `RecommendationRepositoryImpl` implementa la llamada al endpoint `POST .../checkpoint`.
- Estado `TodayCompleted` recibido del backend en `RecommendationDto` usado para pre-set de UI.
- Desactivación de botones durante la llamada en vuelo (`UiState.Loading`).
- Strings `"¿Has realizado esta rutina hoy?"`, `"Sí, lo hice"`, `"Todavía no"` en ES/EN/PT.
- Tests unitarios del ViewModel para checkpoint (happy path + error de red).

---

## HU-031 - Notificaciones basadas en checkpoints de rutinas

Prioridad: Media
Tipo: Funcional
Estimación: 3 puntos

Como PCR,
quiero recibir notificaciones recordándome realizar las rutinas recomendadas cuando llevo días sin verificarlas,
para mantener la constancia en el seguimiento de las orientaciones parentales.

Contexto técnico (protocolo HEFAS):

El protocolo establece una cadencia específica de notificaciones post-recomendación:
- Tras 2 días sin checkpoint completado → notificación motivacional.
- Tras 3 días sin checkpoint → aviso de riesgo de pérdida de puntos.
- Tras 7 días sin actividad → invitación a reevaluar el cuestionario HEFAS.

Esta HU actualiza el job `NotifyUsersWithLessThanTenAnswersJob` (que actualmente es un skeleton) para incluir esta lógica de checkpoint.

Criterios de aceptación (BDD):

- Dado un ChildBook con recomendaciones activas y sin checkpoints en los últimos 2 días,
  cuando el job se ejecute,
  entonces se enviará notificación motivacional al PCR.
- Dado un ChildBook sin checkpoints en los últimos 3 días,
  cuando el job se ejecute,
  entonces se enviará notificación de aviso de puntos.
- Dado un ChildBook sin ningún checkpoint ni respuesta en 7 días,
  cuando el job se ejecute,
  entonces se enviará notificación invitando a reevaluar el cuestionario.
- Dado un PCR que ya recibió una notificación de tipo X hoy,
  cuando el job vuelva a ejecutarse,
  entonces no se duplicará el envío.

DoD:

- Job `NotifyUsersWithCheckpointRemindersJob` creado (o `NotifyUsersWithLessThanTenAnswersJob` actualizado).
- Lógica de evaluación de 2/3/7 días implementada sobre `RecommendationCheckpoint`.
- Integración con canal de mensajería existente (email/SMS según configuración).
- Plantillas de notificación en ES/EN/PT en `EmailMessages.resx`.
- Control anti-duplicado: máximo una notificación de cada tipo por ChildBook por día.
- Tests unitarios para la lógica de cadencia (2/3/7 días).
