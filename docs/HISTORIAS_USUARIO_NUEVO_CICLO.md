# CRIApp - Revision de Trello y Nuevas Historias de Usuario

Fecha: 17 de marzo de 2026
Objetivo: validar estados del board historico y definir historias del nuevo ciclo (refactor + pendientes funcionales + despliegue).

## 1. Criterio de revision aplicado

Se comparo el board historico de Trello con evidencia de implementacion en:

- API: controladores y servicios.
- Android: Activities y componentes de soporte.
- Infra: pipeline y configuracion de arranque.

Estados de auditoria usados:

- Correcto: Trello coincide con evidencia de codigo.
- Parcial: existe implementacion, pero incompleta o sin calidad suficiente para cierre.
- Pendiente: no hay implementacion funcional suficiente.
- Hecho con refactor pendiente: funciona, pero debe revisarse por nuevos patrones y calidad.

## 2. Resultado de auditoria (board antiguo vs codigo)

### 2.1 Historias de Backlog (5)

| Historia Trello | Estado en Trello | Evidencia tecnica | Veredicto |
|---|---|---|---|
| Flujo de gestion de preguntas | Backlog | En API solo hay GET para preguntas a responder; no gestion completa (alta/edicion/baja) | Correcto (Pendiente real) |
| Flujo de gestion de preguntas frecuentes | Backlog | FAQ expone consulta (GET), sin gestion completa de contenido | Correcto (Pendiente real) |
| Flujo de gestion de recursos audiovisual | Backlog | Recursos audiovisuales en consulta (GET), sin gestion completa de contenido | Correcto (Pendiente real) |
| Recibimiento de notificaciones | Backlog | Job programado existe, pero implementacion actual es placeholder | Correcto (Pendiente real) |
| Recibimiento de premios | Backlog | Entidad/modelado existe, sin flujo funcional de asignacion/consulta | Correcto (Pendiente real) |

### 2.2 Historias en Done (35)

Resumen ejecutivo:

- Mayoritariamente correctas en termino de funcionalidad base (autenticacion, hijos, foros, FAQ/recursos de consulta, respuestas, utilidades UI).
- Varias deben migrar semanticamente a estado "Hecho con refactor pendiente" por objetivo nuevo del proyecto (patrones del master + calidad de codigo).
- Algunas deben marcarse "Parcial" por evidencia operativa insuficiente para cierre (deploy productivo real, notificaciones automáticas completas).

Reclasificacion recomendada para nuevo ciclo:

- Mantener como Correcto funcional: sign up/sign in, perfil, hijos (crear/editar), foros (base), contestar respuestas, FAQ/recursos de consulta, dialogos/datepickers.
- Cambiar a Hecho con refactor pendiente: mostrar errores, loaders, validaciones, gestion de foro frontend/backend, actividades de autenticacion/perfil/hijos/preguntas.
- Cambiar a Parcial: deploy API (hay pipeline docker local, falta evidencia de despliegue cloud gratuito estable), envio de correo/SMS (implementado en flujo puntual, pendiente robustez y verificacion end-to-end).

## 3. Backlog nuevo de historias de usuario (siguiendo formato de teoria)

Formato aplicado por historia:

- Enunciado: Como [rol], quiero [necesidad], para [beneficio].
- Criterios de aceptacion en estilo BDD (Dado/Cuando/Entonces).
- Definicion de Hecho (DoD).

Prioridad:

- Alta: imprescindible para defensa y calidad final.
- Media: alto valor pero secuenciable.
- Baja: mejora evolutiva.

---

## HU-001 - Refactor de arquitectura Android

Prioridad: Alta
Tipo: Tecnica
Estimacion: 8 puntos

Como equipo de desarrollo,
quiero reorganizar la app Android con arquitectura por capas y patron MVVM,
para mejorar mantenibilidad, testabilidad y escalabilidad del producto.

Criterios de aceptacion (BDD):

- Dado un modulo funcional de Android,
  cuando se revise su estructura,
  entonces la logica de UI, dominio y acceso a datos estara separada.
- Dado un flujo critico (autenticacion o hijos),
  cuando se ejecute en app,
  entonces no dependera de logica de negocio embebida directamente en Activity.

DoD:

- Se define estructura objetivo (presentacion/dominio/datos).
- Se migra al menos un vertical completo (ejemplo: autenticacion).
- Se documenta decision de arquitectura para memoria.

---

## HU-002 - Cliente API Android robusto

Prioridad: Alta
Tipo: Tecnica
Estimacion: 5 puntos

Como desarrollador Android,
quiero centralizar el cliente HTTP y el manejo de errores,
para reducir duplicacion y mejorar la calidad del codigo.

Criterios de aceptacion (BDD):

- Dado un error HTTP de la API,
  cuando ocurra en cualquier pantalla,
  entonces la app mostrara un error consistente y trazable.
- Dado un cambio de endpoint base,
  cuando se actualice configuracion,
  entonces no sera necesario editar multiples Activities.

DoD:

- Configuracion de base URL externalizada por entorno.
- Manejo unificado de errores de red/serializacion.
- Eliminacion de duplicaciones relevantes en llamadas de red.

---

## HU-003 - Validaciones de formulario mejoradas

Prioridad: Alta
Tipo: Funcional/Calidad
Estimacion: 3 puntos

Como usuario de CRIApp,
quiero validaciones claras y consistentes en los formularios,
para evitar errores y completar tareas con menos friccion.

Criterios de aceptacion (BDD):

- Dado un formulario con datos invalidos,
  cuando pulse enviar,
  entonces se mostraran mensajes claros, especificos y accionables.
- Dado un formulario valido,
  cuando pulse enviar,
  entonces la operacion continuara sin errores de validacion.

DoD:

- Reglas estandarizadas en modulo comun de validacion.
- Mensajes de error consistentes entre pantallas.
- Cobertura de validaciones criticas con tests unitarios.

---

## HU-004 - Gestion completa de preguntas (backend)

Prioridad: Alta
Tipo: Funcional
Estimacion: 5 puntos

Como administrador de contenido,
quiero crear, editar y desactivar preguntas,
para gestionar el itinerario de aprendizaje sin depender de cambios manuales en base de datos.

Criterios de aceptacion (BDD):

- Dado un usuario administrador,
  cuando cree una pregunta valida,
  entonces esta quedara disponible para su uso segun reglas definidas.
- Dado una pregunta existente,
  cuando se actualice,
  entonces los cambios seran persistidos y auditables.

DoD:

- Endpoints de gestion (alta/edicion/baja logica).
- Validaciones de negocio aplicadas.
- Tests de servicio/controlador para casos positivos y negativos.

---

## HU-005 - Gestion completa de FAQ (backend)

Prioridad: Media
Tipo: Funcional
Estimacion: 3 puntos

Como administrador de contenido,
quiero gestionar preguntas frecuentes,
para mantener la informacion de ayuda actualizada.

Criterios de aceptacion (BDD):

- Dado un admin,
  cuando cree o edite una FAQ,
  entonces los usuarios veran el contenido actualizado en la app.
- Dado una FAQ obsoleta,
  cuando se desactive,
  entonces dejara de aparecer en el listado publico.

DoD:

- Operaciones de gestion de FAQ implementadas.
- Control de acceso por rol/perfil.
- Pruebas de API y evidencia en app.

---

## HU-006 - Gestion completa de recursos audiovisuales

Prioridad: Media
Tipo: Funcional
Estimacion: 3 puntos

Como administrador de contenido,
quiero gestionar recursos audiovisuales,
para ofrecer material actualizado y relevante a las familias.

Criterios de aceptacion (BDD):

- Dado un recurso nuevo valido,
  cuando se publique,
  entonces aparecera en el listado de la app.
- Dado un recurso inactivo,
  cuando un usuario consulte,
  entonces no sera mostrado.

DoD:

- CRUD logico para recursos audiovisuales.
- Validacion de formato/URL/metadata.
- Evidencia de consumo en app Android.

---

## HU-007 - Sistema de premios por progreso

Prioridad: Alta
Tipo: Funcional
Estimacion: 5 puntos

Como usuario de CRIApp,
quiero recibir premios por hitos de progreso,
para aumentar motivacion y adherencia al uso de la app.

Criterios de aceptacion (BDD):

- Dado un hito de progreso cumplido,
  cuando el sistema lo detecte,
  entonces se asignara un premio al usuario.
- Dado un usuario con premios,
  cuando consulte su perfil o seccion de logros,
  entonces vera su historial de premios.

DoD:

- Reglas de asignacion de premios implementadas.
- Persistencia y consulta de premios disponible.
- Evidencia funcional en API y app.

---

## HU-008 - Notificaciones utiles y no placeholder

Prioridad: Alta
Tipo: Funcional/Calidad
Estimacion: 5 puntos

Como usuario de CRIApp,
quiero recibir notificaciones utiles (recordatorios/progreso),
para mantener continuidad en el aprendizaje.

Criterios de aceptacion (BDD):

- Dado un usuario con actividad baja,
  cuando se cumpla regla de recordatorio,
  entonces el sistema enviara notificacion por canal configurado.
- Dado un envio de notificacion,
  cuando se procese,
  entonces quedara registro de exito/error para seguimiento.

DoD:

- Job de notificaciones con logica real de negocio.
- Integracion estable con canal de mensajeria configurado.
- Logging y control de errores implementados.

---

## HU-009 - Despliegue cloud gratuito de API

Prioridad: Alta
Tipo: DevOps
Estimacion: 5 puntos

Como responsable tecnico del TFM,
quiero desplegar la API en una nube gratuita,
para demostrar viabilidad real y disponer de entorno publico de validacion.

Criterios de aceptacion (BDD):

- Dado un proveedor cloud gratuito seleccionado,
  cuando se realice el despliegue,
  entonces la API estara accesible mediante HTTPS.
- Dado un cambio en rama principal,
  cuando se ejecute pipeline,
  entonces se podra desplegar sin pasos manuales criticos.

DoD:

- URL publica operativa.
- Variables de entorno y secretos externalizados.
- Guia de despliegue documentada para memoria.

---

## HU-010 - Hardening de seguridad de API

Prioridad: Alta
Tipo: Calidad/Seguridad
Estimacion: 5 puntos

Como autor del TFM,
quiero endurecer configuracion y seguridad de la API,
para reducir riesgo tecnico y cumplir buenas practicas academicas/profesionales.

Criterios de aceptacion (BDD):

- Dado el entorno de produccion,
  cuando arranque la API,
  entonces los secretos no estaran en repositorio y se aplicara HTTPS.
- Dado un endpoint protegido,
  cuando reciba token invalido,
  entonces respondera con error de autorizacion controlado.

DoD:

- Secretos fuera de codigo versionado.
- Configuracion por entorno completada.
- Checklist de seguridad minima validado.

---

## HU-011 - Pruebas backend de servicios criticos

Prioridad: Alta
Tipo: Calidad
Estimacion: 8 puntos

Como equipo tecnico,
quiero pruebas automatizadas en servicios backend criticos,
para detectar regresiones y elevar la calidad del sistema.

Criterios de aceptacion (BDD):

- Dado un cambio en servicios de usuario/preguntas/hijos,
  cuando se ejecute la suite,
  entonces se validaran casos positivos y negativos clave.
- Dado una regresion funcional,
  cuando se ejecute CI,
  entonces la falla sera detectada antes de integrar.

DoD:

- Proyecto de tests backend incorporado.
- Casos criticos implementados y ejecutables en CI.
- Reporte basico de resultados/cobertura.

---

## HU-012 - Pruebas Android (unitarias e instrumentadas)

Prioridad: Alta
Tipo: Calidad
Estimacion: 8 puntos

Como equipo tecnico,
quiero pruebas Android sobre validaciones y flujos criticos,
para asegurar estabilidad tras el refactor.

Criterios de aceptacion (BDD):

- Dado un flujo critico de autenticacion o hijos,
  cuando se ejecute test instrumentado,
  entonces el flujo completara sin error.
- Dado reglas de validacion comunes,
  cuando se ejecuten tests unitarios,
  entonces devolvera resultados esperados en casos limite.

DoD:

- Suite minima de tests unitarios Android.
- Suite minima de tests instrumentados para 2-3 flujos.
- Ejecucion documentada para memoria.

---

## HU-013 - Evidencias para memoria final por historia

Prioridad: Alta
Tipo: Academica/Proceso
Estimacion: 3 puntos

Como autor del TFM,
quiero registrar evidencia de cada historia (implementacion, prueba y resultado),
para facilitar redaccion de memoria y defensa.

Criterios de aceptacion (BDD):

- Dado una historia cerrada,
  cuando se revise el registro,
  entonces existira evidencia tecnica y funcional trazable.
- Dado la redaccion de memoria,
  cuando se consulte la matriz,
  entonces se podra mapear requisito -> cambio -> validacion -> resultado.

DoD:

- Plantilla de evidencia definida y usada por historia.
- Matriz de trazabilidad actualizada en docs.
- Material listo para anexos de memoria.

---

## HU-014 - Anteproyecto TFM (1 pagina PDF)

Prioridad: Alta
Tipo: Academica/Entrega
Estimacion: 2 puntos
Fecha objetivo: 7 de abril de 2026

Como estudiante del TFM,
quiero preparar y entregar un anteproyecto de una pagina en PDF,
para formalizar el alcance, el enfoque tecnico y el plan inicial ante la universidad.

Criterios de aceptacion (BDD):

- Dado el estado actual del proyecto,
  cuando redacte el anteproyecto,
  entonces el documento resumira problema, objetivos, metodologia y plan de trabajo.
- Dado el plazo academico,
  cuando llegue el 7 de abril de 2026,
  entonces el PDF estara finalizado y listo para entrega.

DoD:

- PDF de 1 pagina generado.
- Contenido alineado con metodologia y backlog vigente.
- Version registrada en docs para trazabilidad.

---

## HU-015 - Memoria final del TFM

Prioridad: Alta
Tipo: Academica/Entrega
Estimacion: 13 puntos
Fecha objetivo: fin de junio de 2026

Como autor del TFM,
quiero construir la memoria final a partir de toda la documentacion tecnica y evidencias del proyecto,
para presentar un trabajo coherente, defendible y alineado con los resultados obtenidos.

Criterios de aceptacion (BDD):

- Dado el conjunto de documentos existentes,
  cuando avance la redaccion,
  entonces cada capitulo estara trazado con requisitos, implementacion, pruebas y resultados.
- Dado el cierre del desarrollo,
  cuando consolide la memoria,
  entonces incluira analisis tecnico, decisiones de arquitectura, validacion y conclusiones.

DoD:

- Indice y estructura academica cerrados.
- Conversion de docs tecnicos a secciones de memoria completada.
- Version final preparada para entrega a finales de junio.

---

## HU-016 - Preparacion de defensa en tribunal

Prioridad: Alta
Tipo: Academica/Defensa
Estimacion: 8 puntos
Fecha objetivo: previo a la fecha oficial de defensa

Como estudiante del TFM,
quiero preparar la defensa (diapositivas, guion y demo en vivo),
para comunicar con claridad el valor academico y tecnico de CRIApp ante el tribunal.

Criterios de aceptacion (BDD):

- Dado el contenido de memoria,
  cuando prepare las diapositivas,
  entonces quedaran cubiertos problema, metodologia, implementacion, resultados y trabajo futuro.
- Dado un entorno de demo,
  cuando ejecute la presentacion completa,
  entonces la demo en vivo funcionara de extremo a extremo sin bloqueos criticos.

DoD:

- Presentacion final de defensa completada.
- Script de demo y plan de contingencia preparados.
- Ensayo cronometrado realizado al menos una vez.

## 4. Orden recomendado de ejecucion

1. HU-014 (anteproyecto PDF 1 pagina) con fecha fija 7 de abril de 2026.
2. HU-001, HU-002, HU-003 (base de refactor Android).
3. HU-011, HU-012 (red de seguridad de calidad).
4. HU-004, HU-005, HU-006 (pendientes de gestion de contenido).
5. HU-007, HU-008 (gamificacion y notificaciones).
6. HU-010, HU-009 (hardening + despliegue cloud).
7. HU-013 (consolidacion y cierre documental).
8. HU-015 en paralelo progresivo (memoria final hasta fin de junio) y HU-016 al cierre (defensa).

## 5. Nota de alineacion con teoria

Estas historias siguen la estructura recomendada de producto agil tratada en teoria:

- narrativa de valor (Como/Quiero/Para),
- criterios de aceptacion verificables (BDD),
- criterio operativo de cierre (Definition of Done).

---

Documento vivo: actualizar estado de cada HU por sprint (To Do / Doing / Review / Done).
