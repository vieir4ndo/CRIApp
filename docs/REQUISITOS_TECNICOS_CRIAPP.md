# CRIApp - Documento Tecnico de Requisitos

Fecha: 17 de marzo de 2026
Version: 1.0 (base de registro para memoria final)

## 1. Proposito

Este documento define los requisitos tecnicos de CRIApp para:

- registrar formalmente el alcance funcional y no funcional,
- evaluar estado actual (implementado/parcial/pendiente),
- establecer criterio de cierre para el TFM,
- reutilizar contenido en la memoria final.

## 2. Alcance del sistema

CRIApp es una solucion cliente-servidor para apoyo a la crianza:

- Backend: API REST en .NET 8.
- Frontend: app Android en Kotlin.
- Persistencia: PostgreSQL.

## 3. Fuentes revisadas

### 3.1 Documentacion de producto y teoria

- [README.md](../README.md)
- [.github/copilot-context.md](../.github/copilot-context.md)
- [docs/papers/Memoria App Crianza GTe R1.docx.pdf](papers/Memoria%20App%20Crianza%20GTe%20R1.docx.pdf)
- [docs/papers/Anexo 1. Protocolo recogida datos HEFAS (10-17).pdf](papers/Anexo%201.%20Protocolo%20recogida%20datos%20HEFAS%20(10-17).pdf)
- [docs/papers/Protocolo reducido HEFAS (10-17).pdf](papers/Protocolo%20reducido%20HEFAS%20(10-17).pdf)
- [docs/theory/product/Semana2_InceptionVFINAL.pdf](theory/product/Semana2_InceptionVFINAL.pdf)
- [docs/theory/product/Semana2_HistoriasUsuarioVFINAL.pdf](theory/product/Semana2_HistoriasUsuarioVFINAL.pdf)
- [docs/theory/product/Semana2_RoadmappingVFINAL.pdf](theory/product/Semana2_RoadmappingVFINAL.pdf)
- [docs/theory/product/Semana3Sesion1BDD.pdf](theory/product/Semana3Sesion1BDD.pdf)
- [docs/theory/product/Semana3Sesion2TDD.pdf](theory/product/Semana3Sesion2TDD.pdf)
- [docs/theory/product/Semana3Sesion2Junit.pdf](theory/product/Semana3Sesion2Junit.pdf)

### 3.2 Evidencia tecnica de implementacion

- [api/src/CRIApp.Api/Controllers](../api/src/CRIApp.Api/Controllers)
- [api/src/CRIApp.Application/Services](../api/src/CRIApp.Application/Services)
- [android/app/src/main/java/com/example/criapp](../android/app/src/main/java/com/example/criapp)
- [docs/trello_history/n5BYIhyS - criapp-board.json](trello_history/n5BYIhyS%20-%20criapp-board.json)

Nota: la extraccion automatica de texto de PDFs no estuvo disponible en el entorno actual. Se usan titulos/documentos como fuente de alcance y se recomienda una validacion final manual contra contenido textual de esos archivos antes del cierre definitivo.

## 4. Requisitos funcionales (RF)

Escala de prioridad:

- Alta: imprescindible para demo/defensa.
- Media: aporta valor directo al producto.
- Baja: mejora evolutiva.

Estado:

- Implementado
- Parcial
- Pendiente

| ID | Requisito funcional | Prioridad | Evidencia tecnica | Estado | Criterio de aceptacion resumido |
|---|---|---|---|---|---|
| RF-001 | Registro de usuario | Alta | UserController + UserService | Implementado | El usuario puede crear cuenta y recibir respuesta valida de alta. |
| RF-002 | Inicio de sesion con token | Alta | UserController (login) + UserService | Implementado | Usuario autenticado recibe token y puede acceder a endpoints protegidos. |
| RF-003 | Recuperacion de contrasena | Alta | UserController (forgot-password) + UserService | Implementado | Se genera y envia codigo/token de recuperacion por canal definido. |
| RF-004 | Reseteo de contrasena | Alta | UserController (reset-password) + UserService | Implementado | Usuario puede actualizar contrasena con validacion de codigo. |
| RF-005 | Consulta y actualizacion de perfil | Alta | UserController (GET/PATCH) | Implementado | Usuario autenticado consulta y edita sus datos de perfil. |
| RF-006 | Baja de usuario | Media | UserController (DELETE) | Parcial | Endpoint disponible; validar reglas de borrado y consistencia de datos. |
| RF-007 | Alta de hijos/as | Alta | ChildController (POST) + ChildService | Implementado | Usuario puede registrar datos de hijo/a asociados a su cuenta. |
| RF-008 | Listado y detalle de hijos/as | Alta | ChildController (GET, GET by id) | Implementado | Usuario visualiza lista y detalle de hijos asociados. |
| RF-009 | Edicion de hijos/as | Alta | ChildController (PATCH) | Implementado | Usuario modifica datos de hijo/a con validaciones de negocio. |
| RF-010 | Obtencion de preguntas para responder | Alta | QuestionController (GET) + QuestionService | Implementado | App obtiene preguntas disponibles segun reglas de negocio. |
| RF-011 | Registro de respuestas | Alta | AnswerController (POST) + AnswerService | Implementado | Usuario envia respuestas y estas quedan persistidas. |
| RF-012 | Creacion de foros | Media | ForumController (POST) + ForumService | Implementado | Usuario crea hilo/foro visible para la comunidad. |
| RF-013 | Consulta de foros (lista y detalle) | Media | ForumController (GET, GET by id) | Implementado | Usuario consulta foros y detalle de uno concreto. |
| RF-014 | Edicion de foros | Media | ForumController (PATCH) | Implementado | Autor/usuario permitido actualiza contenido del foro. |
| RF-015 | Comentarios en foros | Media | CommentController (POST/DELETE) + ForumController comments | Implementado | Usuario puede publicar comentario y eliminar bajo reglas definidas. |
| RF-016 | Consulta de FAQ | Media | FaqController (GET) + FaqService | Implementado | Usuario obtiene listado de preguntas frecuentes. |
| RF-017 | Consulta de recursos audiovisuales | Media | AudiovisualResourceController (GET) | Implementado | Usuario visualiza recursos multimedia de apoyo. |
| RF-018 | Mensajeria de soporte (email/SMS) | Media | MessageService + settings externos | Implementado | Sistema puede enviar mensajes para flujos definidos. |
| RF-019 | Flujo Android de autenticacion completo | Alta | SignInActivity, SignUpActivity, ForgotPasswordActivity, ResetPasswordActivity | Implementado | Usuario completa registro/login/recuperacion desde app. |
| RF-020 | Flujo Android de gestion de hijos | Alta | ChildActivity, CreateChildActivity, UpdateChildActivity | Implementado | App permite alta/listado/edicion de hijos sin errores criticos. |
| RF-021 | Flujo Android de preguntas y respuestas | Alta | QuestionsActivity, AnswerActivity | Implementado | App permite seleccionar preguntas y enviar respuestas. |
| RF-022 | Flujo Android social (foros/comentarios) | Media | ForumsActivity, ForumActivity, CreateForumActivity, UpdateForumActivity | Implementado | App permite consultar/crear/editar foros y comentar. |
| RF-023 | Flujo Android de perfil | Alta | ProfileActivity | Implementado | Usuario consulta/actualiza perfil desde app. |
| RF-024 | Flujo Android de FAQ y recursos | Media | FaqActivity, AudioVisualResourcesActivity | Implementado | App muestra FAQ y recursos audiovisuales. |
| RF-025 | Sistema de premios/logros (gamificacion) | Media | Entidad Award en dominio | Pendiente | Se asignan/consultan logros por hitos definidos. |
| RF-026 | Publicacion en Play Store | Baja | Decision de producto vigente | Pendiente (intencional) | No aplica para esta etapa; se valida entrega por APK/AAB. |

## 5. Requisitos no funcionales (RNF)

| ID | Requisito no funcional | Prioridad | Estado | Criterio verificable |
|---|---|---|---|---|
| RNF-001 | Arquitectura por capas en backend | Alta | Implementado | Separacion Domain/Application/Api/Repository mantenida. |
| RNF-002 | Seguridad de secretos por variables de entorno | Alta | Pendiente | No exponer claves en repositorio ni appsettings versionados. |
| RNF-003 | Cifrado de trafico (HTTPS) en despliegue | Alta | Parcial | API publica accesible por HTTPS y redireccion activa. |
| RNF-004 | Autenticacion y autorizacion consistente | Alta | Parcial | Endpoints protegidos y politicas por rol/propiedad cuando corresponda. |
| RNF-005 | Validacion de entrada robusta | Alta | Parcial | Validaciones backend + validaciones UX en Android para campos criticos. |
| RNF-006 | Rendimiento en consultas listadas | Media | Parcial | Paginacion en colecciones principales (foros, preguntas, comentarios). |
| RNF-007 | Observabilidad y logging estructurado | Media | Pendiente | Logs con contexto para errores y trazas clave de negocio. |
| RNF-008 | Pruebas automatizadas backend | Alta | Pendiente | Suite unitaria/integracion para servicios y endpoints criticos. |
| RNF-009 | Pruebas automatizadas Android | Alta | Parcial | JUnit/Espresso para flujos nucleares (autenticacion, hijos, preguntas). |
| RNF-010 | Despliegue reproducible en nube | Alta | Pendiente | Pipeline y guia de despliegue en proveedor gratuito seleccionado. |
| RNF-011 | Usabilidad y accesibilidad basica Android | Media | Parcial | Mensajes de error claros, estados de carga y navegacion consistente. |
| RNF-012 | Trazabilidad para memoria final | Alta | Parcial | Matriz requisito -> evidencia tecnica -> prueba -> resultado documentada. |

## 6. Requisitos tecnicos especificos del refactor Android (RFA)

Estos requisitos incorporan el objetivo academico de aplicar ensenanzas del master.

| ID | Requisito de refactor Android | Prioridad | Estado objetivo |
|---|---|---|---|
| RFA-001 | Separar presentacion, dominio y datos (arquitectura limpia) | Alta | Requerido para cierre |
| RFA-002 | Introducir patron MVVM (o equivalente justificado) | Alta | Requerido para cierre |
| RFA-003 | Centralizar networking y manejo de errores de API | Alta | Requerido para cierre |
| RFA-004 | Definir estados de UI (loading/success/error) de forma explicita | Alta | Requerido para cierre |
| RFA-005 | Reducir logica de negocio en Activities | Alta | Requerido para cierre |
| RFA-006 | Incorporar DI (Hilt/Koin o alternativa justificada) | Media | Deseable alto |
| RFA-007 | Cobertura de tests unitarios para modulos refactorizados | Alta | Requerido para cierre |
| RFA-008 | Documentar decisiones de arquitectura (ADR breve) | Media | Requerido para memoria |

## 7. Requisitos tecnicos de despliegue API en nube gratuita (RDEP)

| ID | Requisito de despliegue | Prioridad | Estado objetivo |
|---|---|---|---|
| RDEP-001 | Seleccionar proveedor con plan gratuito viable | Alta | Requerido para cierre |
| RDEP-002 | Configurar variables de entorno para secretos | Alta | Requerido para cierre |
| RDEP-003 | Publicar API accesible por HTTPS | Alta | Requerido para cierre |
| RDEP-004 | Configurar base de datos compatible y migraciones | Alta | Requerido para cierre |
| RDEP-005 | Definir proceso CI/CD basico (build + deploy) | Media | Deseable alto |
| RDEP-006 | Documentar URL publica y procedimiento de despliegue | Alta | Requerido para memoria |

## 8. Matriz de trazabilidad inicial

| Requisito | Artefacto tecnico principal | Evidencia de app/uso | Evidencia documental |
|---|---|---|---|
| RF-001 a RF-006 | UserController/UserService | SignIn/SignUp/Profile/Reset Password | README + papers |
| RF-007 a RF-009 | ChildController/ChildService | ChildActivity/CreateChild/UpdateChild | Trello historial |
| RF-010 y RF-011 | QuestionController + AnswerController | QuestionsActivity + AnswerActivity | Trello historial |
| RF-012 a RF-015 | ForumController + CommentController | ForumsActivity/ForumActivity | Trello historial |
| RF-016 y RF-017 | FaqController + AudiovisualResourceController | FaqActivity + AudioVisualResourcesActivity | README |
| RFA-001 a RFA-008 | Android refactor planificado | Evidencia antes/despues en APK demo | Memoria final |
| RDEP-001 a RDEP-006 | Infra cloud y pipeline | API publica consumida por app | Memoria final |

## 9. Criterio de uso en memoria final

Para cada requisito de prioridad Alta y Media se recomienda documentar en la memoria:

1. Objetivo del requisito.
2. Implementacion tecnica (archivo/modulo).
3. Evidencia de validacion (test o prueba manual estructurada).
4. Resultado y limitaciones.

## 10. Proximos pasos de gobierno de requisitos

1. Confirmar con tutoria/cliente si RF-025 (gamificacion) entra en alcance obligatorio de defensa.
2. Convertir los requisitos de Alta prioridad en historias de sprint (1 semana).
3. Completar una tabla de verificacion final por requisito antes de la entrega.
4. Congelar version final de este documento como anexo tecnico de memoria.

---

Documento vivo: actualizar al cierre de cada sprint con cambios de estado y evidencias.
