# CRIApp - Documento Tecnico de Requisitos

Fecha: 30 de marzo de 2026
Version: 1.2 (base de registro para memoria final)

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

## 3. Requisitos funcionales (RF)

Escala de prioridad:

- Alta: imprescindible para demo/defensa.
- Media: aporta valor directo al producto.
- Baja: mejora evolutiva.

Estado:

- Implementado
- Parcial
- Pendiente

| Identificador | Requisito funcional | Prioridad | Estado | Descripción | 
|---|---|---|---|---|
| RF-001 | El sistema debe permitir el registro de nuevos usuarios mediante el ingreso de datos personales | Alta | Implementado | Para registrarse un usuário debe informar los siguientes datos: nombre (obligatorio), nombre de usuário (obligatorio, móvil o correo), fecha de nacimiento (obligatorio), sexo (obligatorio, hombre, mujer u otro), nível educativo (opcional, sin estudios, primaria/ESO, bachillerato, formación profesional o estudios universitarios), tipo de familia (opcional, monoparental feminina, monoparental masculina, pareja de hombre y mujer, pareja de hombre y hombre o pareja de mujer y mujer) y numero de hijos (opcional, mayor o igual a 0). Una vez creado el usuario debe recibir un correo/SMS de bienvenida y ser redireccionado al inicio de sesión. |
| RF-002 | El sistema debe permitir a los usuarios iniciar sesión con sus credenciales | Alta | Parcial, falta implementar vaidación para mostrar las pantallas de bienvenida solamente en el primer login | Para acceder al sistema el usuario debe informar sus credenciales. El sistema debe validar que el usuario existe y que la contraseña informada está correcta. Si el usuario está accedendo a la por la primera vez, se debe mostrar algunas pantallas de bienvenida a la app. |
| RF-003 | El sistema debe permitir la recuperación de contraseña mediante el envío de un código | Alta | Implementado | Para recuperar su contraseña, el usuario debe informar su nombre de usuario (correo o móvil), entonces el sistema le enviará un codigo de seguridad (SMS/Correo). |
| RF-004 | El sistema debe permitir restablecer la contraseña mediante validación de código | Alta | Implementado | Una vez que el usuario haya recibido su codigo de seguridad, una vez que ello sea informado y convalidado, entonces la contraseña podra ser alterada. |
| RF-005 | El sistema debe permitir a los usuarios autenticados consultar su perfil | Alta | Implementado | Todos los datos personales del usuarios informados en la creacion de su cuenta deben ser exibidos, excepto por su nombre de usuario. |
| RF-006 | El sistema debe permitir a los usuarios autenticados actualizar su perfil | Alta | Implementado | Todos los datos personales del usuarios informados en la creacion de su cuenta deben poder ser editados, excepto por su nombre de usuario, siguiendo las mismas reglas aplicadas para la creacion de usuarios. |
| RF-007 | El sistema debe permitir la desactivación de cuentas de usuario | Media | Parcial, endpoint disponible; validar comportamiento del sistema con usuarios desactivados; implementar request en el front end | Usuário puede desactivar su cuenta. |
| RF-008 | El sistema debe permitir registrar hijos/as asociados a una cuenta de usuario | Alta | Implementado | Para crear un hijo deben ser informados los siguientes datos: nombre (obligatiro), fecha de nacimiento (obligatorio), sexo (obligatorio, hombre, mujer u otro), prematuro (obligatorio, sí o no), numero de meses de lactancia (obligatorio, mayor o igual a 0)  |
| RF-009 | El sistema debe permitir listar los hijos/as asociados a un usuario | Alta | Implementado | El sistema debe permitir al usuario consultar todos los hijos/as asociados a su cuenta y consultar todos los datos de cada hijo, conforme fueron informados en la creación de ellos. |
| RF-010 | El sistema debe permitir editar la información de los hijos/as | Alta | Implementado | El sistema debe permitir al usuario editar todos los datos de cada hijo/a asociado a su cuenta, conforme reglas aplicadas en la creación de hijos. |
| RF-011 | El sistema debe guardar automaticamente las preguntas en la base de datos | Alta | Implementado | El sistema debe añadir automaticamente la siguiente lista de preguntas para que sean hechas al usuario. |
| RF-012 | El sistema debe listar preguntas disponibles para ser respondidas por cada hijo/a | Alta | Implementado | El sistema debe listar 10 preguntas para cada hijo del usuário por dia, de acuerdo con la lista predefinida de preguntas registradas |
| RF-013 | El sistema debe permitir registrar las respuestas proporcionadas por los usuario | Alta | Implementado | El sistema de guardar las respuestas de los usuarios a las preguntas cuando ellos pulsen el buton de siguiente. Las respuestas siguen la escala de likert y deben ser guardadas con su valor numerico asociadas a cada usuario |
| RF-014 | El sistema debe permitir la creación de foros por parte de los usuarios | Media | Implementado | Para crear un foro, los siguientes datos son necesarios: nombre y descripcion. |
| RF-015 | El sistema debe permitir consultar foros y su detalle | Media | Implementado | El sistema debe mostrar el nombre y la descipcion del foro, así como todos los comentario ya añadidos al foro y sus creadores.  |
| RF-016 | El sistema debe permitir editar foros por usuarios autorizados | Media | Implementado | El sistema debe permitir solamente al dueno del foro editar su nombre y descripcion. |
| RF-017 | El sistema debe permitir comentar en los foros | Media | Implementado | El sistema debe permitir a todos los usuarios ya registrados comentar sobre los foros existentes, sean suyos o de otros usuarios.  |
| RF-018 | El sistema debe guardar automaticamente las preguntas frecuentes en la base de datos | Alta | Implementado | El sistema debe añadir automaticamente la siguiente lista de preguntas frecuentes para que sean consultadas por los usuarios. |
| RF-019 | El sistema debe permitir consultar preguntas frecuentes (FAQ) | Media | Implementado | El sistema debe permitir al usuario consultas las preguntas frecuentes, mostrando todos los datos en una lista despligable. |
| RF-020 | El sistema debe guardar automaticamente los recursos audivisuales en la base de datos | Alta | Implementado | El sistema debe añadir automaticamente la siguiente lista de recursos audiovisuales para que sean consultadas por los usuarios.  |
| RF-021 | El sistema debe permitir consultar recursos audiovisuales | Media | Implementado | Debe ser posible ver los recursos audiovisuales desde la aplicacion sin la necesidad. de salir de la app. |
| RF-022 | El sistema debe generar y asignar premios en función de la puntuación de los usuarios | Media | Pendiente | El calculo que debe ser ejecutado diariamente es el siguiente. Se debe añadir la puntuacion generada al score del usuario. El usuario debe poder ver su score y los premios que puede ganar. Si el usuario llegar a las siguientes punctuaciones, se debe asignar lo siguiente. Broze para usuarios con 100 puntos, plata para usuarios con 500 puntos, Oro para los usuarios con 1000 y Diamante para los usuarios con mas de 10 mil puntos  |
| RF-023 | El sistema debe permitir consultar los premios de un usuario | Alta | Pendiente | El sistema debe mostrar el score del usuario y los premios existentes que puede ganas. Los premios que haya ganado deben ser enseñados en color y los premios que aun no ganada deben ser enseñados en todos de grises. |
| RF-024 | El sistema debe generar notificaciones diarias para avisar los usuários que deben responder las preguntas para sus hijos | Media | Pendiente | El sistema debe analisar de hora en hora todos los usuarios y verificar los que aun no hayan contestado preguntas en el dia curriente. Si no han contestado las preguntas para algun hijo, le enviaremos una notificacion que tiene prguntas pendientes. Las notificaciones se deben guardar en la base de datos. No se debe mandar más de una notificacion por dia para los usuarios. |
| RF-025 | El sistema debe permitir consultar notificaciones enviadas al usuario. | Media | Pendiente | El sistema debe permitir consultar todas las notificaciones recibidas. Deben ser enseñados todos los datos de la notificacion. |


## 5. Requisitos no funcionales (RNF)

| ID | Requisito no funcional | Prioridad | Estado | Criterio verificable |
|---|---|---|---|---|
| RNF-001 | Seguridad de secretos por variables de entorno | Alta | Pendiente | No exponer claves en repositorio ni appsettings versionados. |
| RNF-002 | Cifrado de trafico (HTTPS) en despliegue | Alta | Parcial | API publica accesible por HTTPS y redireccion activa. |
| RNF-003 | Rendimiento en consultas listadas | Media | Parcial | Paginacion en colecciones principales (foros, preguntas, comentarios). |
| RNF-004 | Observabilidad y logging estructurado | Media | Pendiente | Logs con contexto para errores y trazas clave de negocio. |
| RNF-005 | Pruebas automatizadas backend | Alta | Pendiente | Suite unitaria/integracion para servicios y endpoints criticos. |
| RNF-006 | Despliegue reproducible en nube | Alta | Pendiente | Pipeline y guia de despliegue en proveedor gratuito seleccionado. |

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