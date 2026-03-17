# TFM CRIApp - Metodologia y Plan de Cierre

Fecha: 17 de marzo de 2026

## 1. Decision metodologica para el cierre del TFM

Se adopta una metodologia agil hibrida basada en:

- Scrum (sprints cortos de 1 semana)
- Kanban (control de flujo y limite de trabajo en curso)
- Inception (alineacion de alcance y objetivos de cierre)
- Historias de usuario (trazabilidad funcional)
- BDD (criterios de aceptacion)
- TDD/JUnit (calidad tecnica, sobre todo en logica critica)

### Justificacion

Esta metodologia se ajusta al estado actual del proyecto (mucho desarrollo funcional ya implementado) y prioriza terminar con calidad, evidencia academica y reduccion de riesgo en el tiempo restante.

## 2. Estado sintetico del proyecto (base para memoria)

### Ya implementado

- API en .NET con arquitectura por capas (Domain, Application, Api, Repository).
- Multiples controladores y servicios funcionales (usuarios, hijos, preguntas, respuestas, foros, comentarios, FAQ, recursos audiovisuales).
- Aplicacion Android con flujo funcional amplio (autenticacion, perfil, hijos, preguntas, foros, FAQ, recursos).
- Base de datos PostgreSQL con migraciones y seeders.

### Pendiente critico para cierre de calidad

- Tests backend (actualmente sin suite de pruebas automatizadas de negocio).
- Fortalecimiento de seguridad/configuracion para despliegue.
- Consolidacion de estructura para reducir duplicidades y deuda tecnica.
- Evidencia final para memoria (trazabilidad requisito -> implementacion -> prueba -> resultado).

## 3. Linea estrategica nueva acordada

### 3.1 Refactor importante en Android

Objetivo: realizar un buen refactor de la app Android aplicando ensenanzas de la asignatura del master.

Enfoque recomendado:

- Evolucion hacia arquitectura limpia y mantenible (capas, separacion de responsabilidades).
- Estandarizacion de gestion de estado y navegacion.
- Reduccion de acoplamiento entre UI y acceso a datos.
- Mejora de manejo de errores, validaciones y experiencia de usuario.
- Introduccion de tests unitarios y, si es viable, instrumentados para flujos criticos.

Resultado esperado para la memoria:

- Demostrar madurez tecnica: antes/despues del refactor.
- Justificar decisiones de arquitectura con criterios de mantenibilidad, testabilidad y escalabilidad.

### 3.2 Despliegue de la API en nube gratuita

Objetivo: desplegar la API en un proveedor cloud sin coste inicial.

Criterios de seleccion:

- Tier gratuito realista para API REST.
- Facilidad de despliegue continuo.
- Compatibilidad con PostgreSQL (gestionado o alternativa equivalente).
- Simplicidad de configuracion de variables de entorno y secretos.

Proveedores a evaluar (segun disponibilidad de fecha):

- Render
- Railway
- Fly.io
- Koyeb
- Azure for Students (si aplica por perfil academico)

Entregable para memoria:

- URL publica de API (o entorno de demo estable).
- Capturas de pipeline/deploy.
- Descripcion de arquitectura de despliegue y costes.

### 3.3 Publicacion Android en Play Store

Decision actual:

- No se publicara en Play Store por ahora.

Enfoque alternativo valido para TFM:

- Entrega por APK/AAB de demostracion.
- Evidencia de instalacion y ejecucion en dispositivo/emulador.
- Demostracion funcional guiada con escenarios de uso.

## 4. Plan de ejecucion sugerido (4 semanas)

## Semana 1

- Congelar alcance funcional de cierre.
- Definir backlog tecnico del refactor Android.
- Definir Definition of Done academica por historia.
- Preparar estrategia de despliegue cloud y entorno de configuracion segura.

## Semana 2

- Ejecutar refactor Android (iteracion 1: base arquitectonica).
- Introducir bateria inicial de tests Android.
- Ajustes backend minimos necesarios para estabilidad de integracion.

## Semana 3

- Ejecutar refactor Android (iteracion 2: flujos criticos y UX).
- Despliegue de API en nube gratuita.
- Verificacion end-to-end app -> API desplegada.

## Semana 4

- Hardening final (errores, seguridad, trazabilidad).
- Preparacion de evidencias para memoria y defensa.
- Consolidacion de anexos tecnicos (capturas, metricas, decisiones).

## 5. Criterios de cierre (Definition of Done TFM)

Una historia se considera cerrada solo si cumple:

- Implementacion funcional completa.
- Criterios BDD verificados.
- Prueba automatizada o evidencia de prueba manual estructurada.
- Evidencia documental para memoria.
- Sin regresiones visibles en flujos principales.

## 6. Riesgos y mitigacion

- Riesgo: refactor demasiado grande y sin control.
  - Mitigacion: refactor incremental por modulos y checkpoints semanales.

- Riesgo: limitaciones de tiers gratuitos cloud.
  - Mitigacion: evaluar 2 proveedores en paralelo y mantener plan B.

- Riesgo: falta de tiempo para documentacion final.
  - Mitigacion: documentar evidencia en cada sprint, no al final.

## 7. Decision ejecutiva final

Para finalizar el TFM con calidad academica y tecnica:

1. Mantener metodologia agil hibrida (Scrum + Kanban + BDD/TDD).
2. Priorizar refactor Android como eje de aprendizaje del master.
3. Completar despliegue de API en nube gratuita para validacion real.
4. Posponer publicacion en Play Store sin impactar negativamente la defensa.

---

Documento vivo: actualizar al cierre de cada sprint con avances, bloqueos y evidencias.
