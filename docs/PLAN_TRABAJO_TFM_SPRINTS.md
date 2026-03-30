# CRIApp - Plan de Trabajo TFM (Sprints + Kanban)

Fecha de inicio del plan: 6 de abril de 2026
Marco de trabajo: Scrum ligero (semanal) + Kanban (flujo diario)
Fuente de backlog: [docs/HISTORIAS_USUARIO_NUEVO_CICLO.md](HISTORIAS_USUARIO_NUEVO_CICLO.md)

## 1. Objetivo del plan

Convertir las historias de usuario existentes en una hoja de ruta semanal realista hasta fin de junio, respetando hitos academicos y la estrategia del proyecto:

- finalización de flujos pendientes,
- refactor Android con patrones del máster,
- mejora de calidad (tests, seguridad, despliegue),
- cierre académico (anteproyecto, memoria final, defensa).

## 2. Supuestos de capacidad

- Capacidad media: 6-8 puntos por semana.
- Velocidad objetivo para planificar: 7 puntos/semana.
- Total de puntos en backlog: 81 puntos.
- Duración estimada: 12 semanas (6 abr — 30 jun).

Nota: HU-014 (memoria final) se trabaja en paralelo desde la semana 10, no se deja para el final.

## 3. Política de metodología (cómo ejecutar cada semana)

### Scrum semanal (cadencia)

- Lunes/martes: planificación semanal (selección de HU y subtareas).
- Diario: seguimiento Kanban breve (10-15 min).
- Fin de semana: review + retrospectiva corta + actualización de evidencia para memoria.

### Kanban (flujo recomendado)

Columnas sugeridas para Git Projects:

- Backlog
- Sprint Backlog
- In Progress
- Done

Políticas:

- WIP máximo: 2 tarjetas en In Progress.
- No mover a Done sin DoD y evidencia mínima.
- Cada HU cerrada debe dejar evidencia en docs para HU-014.

## 4. Hitos académicos obligatorios

- Hito A: HU-001 (anteproyecto 1 página PDF) antes del 7 de abril de 2026.
- Hito B: HU-014 (memoria final) completada antes de fin de junio.
- Hito C: HU-015 (defensa) preparada con diapositivas + demo + ensayo.

## 5. Distribución recomendada por semanas

### Semana 1 (6 abr - 12 abr) ⚠️ Hito A

Objetivo: entregar el anteproyecto antes del martes 7 de abril y arrancar el refactor Android.

- HU-001 Anteproyecto TFM — cerrar antes del martes 7 (2 pts)
- HU-002 Refactor de arquitectura Android — inicio (8 pts, parcial)

Carga objetivo: ~7 pts
Resultado esperado: anteproyecto entregado + primer módulo Android reestructurado arrancado.

---

### Semana 2 (13 abr - 19 abr)

Objetivo: completar la base arquitectónica Android.

- HU-002 Refactor de arquitectura Android — cierre
- HU-003 Cliente API Android robusto — inicio (5 pts, parcial)

Carga objetivo: ~7 pts
Resultado esperado: arquitectura por capas consolidada y cliente HTTP configurado.

---

### Semana 3 (20 abr - 26 abr)

Objetivo: cerrar la capa de red y validar el flujo base de usuario.

- HU-003 Cliente API Android robusto — cierre
- HU-004 Cierre de primer login y onboarding (3 pts)

Carga objetivo: ~6 pts
Resultado esperado: networking robusto y flujo de primer login/onboarding validado.

---

### Semana 4 (27 abr - 3 may)

Objetivo: asegurar la base de seguridad de la API y arrancar pruebas backend.

- HU-005 Hardening de seguridad de API (5 pts)
- HU-006 Pruebas backend de servicios críticos — inicio (8 pts, parcial)

Carga objetivo: ~7 pts
Resultado esperado: secretos externalizados, HTTPS aplicado y primeros tests backend arrancados.

---

### Semana 5 (4 may - 10 may)

Objetivo: completar la suite de pruebas backend.

- HU-006 Pruebas backend de servicios críticos — cierre

Carga objetivo: ~8 pts (semana intensiva)
Resultado esperado: suite de tests backend ejecutable en CI con reporte básico de cobertura.

---

### Semana 6 (11 may - 17 may)

Objetivo: añadir trazabilidad operativa y arrancar funcionalidades de negocio.

- HU-007 Observabilidad y logging estructurado (5 pts)
- HU-008 Sistema de premios por progreso — inicio (5 pts, parcial)

Carga objetivo: ~7 pts
Resultado esperado: logging estructurado activo y primeros premios implementados.

---

### Semana 7 (18 may - 24 may)

Objetivo: completar la gamificación y arrancar las notificaciones.

- HU-008 Sistema de premios por progreso — cierre
- HU-009 Notificaciones útiles — inicio (5 pts, parcial)

Carga objetivo: ~7 pts
Resultado esperado: premios funcionales de extremo a extremo y job de notificaciones en marcha.

---

### Semana 8 (25 may - 31 may)

Objetivo: completar notificaciones y cerrar funcionalidades de cuenta.

- HU-009 Notificaciones útiles — cierre
- HU-010 Desactivación de cuenta end-to-end (3 pts)

Carga objetivo: ~7 pts
Resultado esperado: notificaciones operativas con logging y flujo de desactivación de cuenta completo.

---

### Semana 9 (1 jun - 7 jun)

Objetivo: cerrar funcionalidades complementarias y arrancar el despliegue.

- HU-011 Visualización robusta de recursos audiovisuales (3 pts)
- HU-012 Consulta de historial de notificaciones (3 pts)
- HU-013 Despliegue cloud gratuito de API — inicio (5 pts, parcial)

Carga objetivo: ~7 pts
Resultado esperado: visualización e historial validados, entorno cloud en configuración.

---

### Semana 10 (8 jun - 14 jun)

Objetivo: completar el despliegue y arrancar la redacción de la memoria.

- HU-013 Despliegue cloud gratuito de API — cierre
- HU-014 Memoria final del TFM — bloque 1 (marco teórico, requisitos, metodología) (parcial)

Carga objetivo: ~7 pts
Resultado esperado: API pública accesible mediante HTTPS y primer bloque de memoria redactado.

---

### Semana 11 (15 jun - 21 jun)

Objetivo: avanzar en la memoria y arrancar la preparación de la defensa.

- HU-014 Memoria final del TFM — bloque 2 (implementación, pruebas, resultados) (parcial)
- HU-015 Preparación de defensa en tribunal — inicio (parcial)

Carga objetivo: ~7 pts
Resultado esperado: cuerpo técnico de la memoria cerrado y primera versión de diapositivas disponible.

---

### Semana 12 (22 jun - 30 jun)

Objetivo: cierre académico total.

- HU-014 Memoria final del TFM — bloque 3 y entrega (conclusiones, trabajo futuro, edición final)
- HU-015 Preparación de defensa en tribunal — cierre (demo en vivo + ensayo cronometrado + plan de contingencia)

Carga objetivo: ~7 pts
Resultado esperado: memoria entregada antes de fin de junio y defensa lista para el tribunal.

## 6. Resumen por fases

- Fase 1 — Semanas 1-3: Hito anteproyecto + fundamentos técnicos Android.
- Fase 2 — Semanas 4-5: Seguridad y calidad backend.
- Fase 3 — Semanas 6-8: Funcionalidades principales (premios, notificaciones, cuenta).
- Fase 4 — Semana 9: Funcionalidades complementarias + inicio despliegue.
- Fase 5 — Semanas 10-12: Despliegue + memoria final + defensa.

## 7. Regla práctica para mover tarjetas en Git Projects

Mover una historia a Done solo si cumple simultáneamente:

- Criterios BDD verificados.
- DoD completo.
- Evidencia registrada en docs (captura, prueba o resultado medible).
- Impacto reflejado en memoria (si aplica).

## 8. Contingencia (si una semana se complica)

Orden de protección de hitos:

1. No mover HU-001 ni HU-014 de sus ventanas objetivo.
2. Mantener HU-002/HU-003/HU-005/HU-006 como núcleo de calidad técnica.
3. Si hace falta recortar, reducir primero el alcance de HU-011 o HU-012 (funcionalidades de menor impacto en la defensa).