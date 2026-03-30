# CRIApp - Revisión de Trello, Requisitos v1.4 y Nuevas Historias de Usuario

Fecha: 30 de marzo de 2026
Objetivo: alinear el backlog del nuevo ciclo con la auditoría del board histórico y con el documento de requisitos técnicos v1.4 (estado real de implementación).
Versión: 1.3

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

## HU-008 - Sistema de premios por progreso

Prioridad: Alta
Tipo: Funcional
Estimación: 5 puntos

Como usuario de CRIApp,
quiero recibir premios por hitos de progreso,
para aumentar motivación y adherencia al uso de la app.

Criterios de aceptación (BDD):

- Dado un hito de progreso cumplido,
  cuando el sistema lo detecte,
  entonces se asignará un premio al usuario.
- Dado un usuario con premios,
  cuando consulte su perfil o sección de logros,
  entonces verá su historial de premios.

DoD:

- Reglas de asignación de premios implementadas según umbrales definidos en RF-022: Bronce (>= 100 pts), Plata (>= 500 pts), Oro (>= 1000 pts), Diamante (>= 10000 pts).
- Persistencia y consulta de premios disponible.
- Premios alcanzados distinguibles visualmente de los no alcanzados (RF-023).
- Evidencia funcional en API y app.

---

## HU-009 - Notificaciones útiles

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

---

## HU-010 - Desactivación de cuenta end-to-end

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
