# CRIApp - Plan de Trabajo TFM (Sprints + Kanban)

Fecha de inicio del plan: 6 de abril de 2026
Última revisión: 9 de mayo de 2026
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
- Total de puntos en backlog original: 81 puntos.
- Puntos ya entregados (semanas 1-5): ~50 puntos.
- Puntos restantes estimados: ~31 puntos.
- Duración restante: 7-8 semanas (12 may — 30 jun).

Nota: HU-014 (memoria final) se trabaja en paralelo desde la semana 9, no se deja para el final.

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

- Hito A: HU-001 (anteproyecto 1 página PDF) — ✅ ENTREGADO (7 de abril de 2026).
- Hito B: HU-014 (memoria final) completada antes de fin de junio.
- Hito C: HU-015 (defensa) preparada con diapositivas + demo + ensayo.

## 5. Registro de semanas completadas

### Semana 1 (6 abr - 12 abr) ✅

- HU-001 Anteproyecto TFM — DONE
- HU-002 Refactor arquitectura Android — inicio

### Semana 2 (13 abr - 19 abr) ✅

- HU-002 Refactor arquitectura Android — DONE
- HU-003 Cliente API Android robusto — inicio
- HU-005 Hardening de seguridad de API — DONE (secretos externalizados, Swagger/Hangfire restringidos a non-prod, referencias nullable resueltas)
- HU-006 Pruebas backend de servicios críticos — DONE (suite de tests + CI pipeline con threshold de cobertura)
- HU-007 Observabilidad y logging estructurado — DONE (Application Insights integrado, logs en clases clave)
- HU-013 Despliegue cloud gratuito de API — DONE (Azure App Service + GitHub Actions CI/CD + health checks JSON + Hangfire/PostgreSQL)

### Semana 3 (20 abr - 26 abr) ✅

- HU-003 Cliente API Android robusto — DONE
- HU-004 Cierre de primer login y onboarding — DONE

### Semana 4 (27 abr - 3 may) ✅

- HU-008 Sistema de gamificación (premios + score) — inicio anticipado
- HU-009 Notificaciones útiles — inicio (skeleton + SMTP)
- HU-016 Soporte multilingüe (i18n) — DONE (adelantada)

### Semana 5 (4 may - 10 may) ✅

- HU-008 Sistema de gamificación — DONE (cierre completo: premios, score, flujo de preguntas, UI Likert 1-6, filtrado por familia, rotación 7 días)
- HU-017 Rotación inteligente de preguntas y mejoras de UI — DONE (adelantada)
- HU-018 Sistema de Recomendaciones personalizadas — DONE (adelantada)
- HU-019 Limpieza automática de códigos de reset — DONE (adelantada)
- HU-020 Mejoras en templates de email — DONE (adelantada)
- HU-010 Desactivación de cuenta — backend DONE, Android pendiente

Nota retrospectiva: Las semanas 4-5 fueron altamente productivas. Se adelantaron HU-016/017/018/019/020 y se cerró HU-008 con un alcance ampliado. La semana 2 (17 de abril) resultó ser también extraordinariamente productiva: se completaron HU-005, HU-006, HU-007 y HU-013 en un único día de trabajo intenso vinculado al despliegue en Azure. Las HU-013 y HU-006 previstas originalmente para semanas posteriores quedaron cerradas semanas antes.

---

## 6. Distribución recomendada — semanas restantes (a partir del 11 de mayo)

### Semana 6 (11 may - 17 may) — ⏸ Pausa

Sin trabajo en el TFM esta semana.

---

### Semana 7 (18 may - 24 may)

Objetivo: cerrar las notificaciones push y la desactivación de cuenta.

- HU-009 Notificaciones útiles — integración FCM/push notifications Android (5 pts)
- HU-010 Desactivación de cuenta — cierre Android: botón en ProfileActivity, confirmación, cierre de sesión automático (3 pts)

Carga objetivo: ~8 pts
Resultado esperado: notificaciones push operativas y flujo de desactivación de cuenta completo end-to-end.

---

### Semana 8 (25 may - 31 may)

Objetivo: cerrar las funcionalidades complementarias de la app.

- HU-011 Visualización robusta de recursos audiovisuales (3 pts)
- HU-012 Consulta de historial de notificaciones (3 pts)

Carga objetivo: ~6 pts
Resultado esperado: visualización de recursos validada con manejo de errores e historial de notificaciones visible en la app.

---

### Semana 9 (1 jun - 7 jun)

Objetivo: arrancar la memoria final.

- HU-014 Memoria final del TFM — bloque 1: introducción, marco teórico, requisitos, metodología

Carga objetivo: ~5 pts
Resultado esperado: primeros capítulos en borrador avanzado, listos para revisión.

---

### Semana 10 (8 jun - 14 jun)

Objetivo: núcleo técnico de la memoria.

- HU-014 Memoria final del TFM — bloque 2: arquitectura, implementación, pruebas, resultados

Carga objetivo: ~5 pts
Resultado esperado: capítulos de implementación y pruebas documentados con evidencias del repositorio.

---

### Semana 11 (15 jun - 21 jun)

Objetivo: cierre de memoria e inicio de la defensa.

- HU-014 Memoria final del TFM — bloque 3: conclusiones, trabajo futuro, edición global
- HU-015 Preparación de defensa en tribunal — inicio: estructura de diapositivas y guión v1

Carga objetivo: ~7 pts
Resultado esperado: borrador de memoria completo y primera versión de la presentación disponible.

---

### Semana 12 (22 jun - 30 jun)

Objetivo: cierre académico total.

- HU-014 Memoria final del TFM — revisión final y entrega
- HU-015 Preparación de defensa en tribunal — cierre: demo en vivo, ensayo cronometrado y plan de contingencia

Carga objetivo: ~7 pts
Resultado esperado: memoria entregada antes de fin de junio y defensa lista para el tribunal.

## 7. Resumen por fases

- Fase 1 — Semanas 1-3 ✅: Anteproyecto + fundamentos técnicos Android + seguridad + tests + logging + despliegue cloud.
- Fase 2 — Semanas 4-5 ✅: Gamificación, recomendaciones, i18n, emails.
- Fase 3 — Semana 6: Pausa.
- Fase 4 — Semanas 7-8: Cierre de funcionalidades de la app (notificaciones push, desactivación, audiovisual, historial).
- Fase 5 — Semanas 9-12: Memoria final + preparación de defensa.

## 8. Estado actual de HU (9 mayo 2026)

| HU | Título | Estado |
|----|--------|--------|
| HU-001 | Anteproyecto TFM | ✅ DONE |
| HU-002 | Refactor arquitectura Android | ✅ DONE |
| HU-003 | Cliente API Android robusto | ✅ DONE |
| HU-004 | Cierre de primer login y onboarding | ✅ DONE |
| HU-005 | Hardening de seguridad de API | ✅ DONE |
| HU-006 | Pruebas backend de servicios críticos | ✅ DONE |
| HU-007 | Observabilidad y logging estructurado | ✅ DONE |
| HU-008 | Sistema de gamificación (premios, score, preguntas, UI) | ✅ DONE |
| HU-009 | Notificaciones útiles | 🔄 EN PROGRESO — Semana 7 |
| HU-010 | Desactivación de cuenta end-to-end | 🔄 EN PROGRESO — Semana 7 (backend ✅) |
| HU-011 | Visualización robusta de recursos audiovisuales | ⬜ Semana 8 |
| HU-012 | Consulta de historial de notificaciones | ⬜ Semana 8 |
| HU-013 | Despliegue cloud gratuito de API | ✅ DONE |
| HU-014 | Memoria final del TFM | ⬜ Semanas 9-12 |
| HU-015 | Preparación de defensa en tribunal | ⬜ Semanas 11-12 |
| HU-016 | Soporte multilingüe (i18n) | ✅ DONE |
| HU-017 | Rotación inteligente de preguntas y mejoras de UI | ✅ DONE |
| HU-018 | Sistema de Recomendaciones personalizadas | ✅ DONE |
| HU-019 | Limpieza automática de códigos de reset | ✅ DONE |
| HU-020 | Mejoras en templates de email | ✅ DONE |

## 9. Regla práctica para mover tarjetas en Git Projects

Mover una historia a Done solo si cumple simultáneamente:

- Criterios BDD verificados.
- DoD completo.
- Evidencia registrada en docs (captura, prueba o resultado medible).
- Impacto reflejado en memoria (si aplica).

## 10. Contingencia (si una semana se complica)

Orden de protección de hitos:

1. No mover HU-014 ni HU-015 de sus ventanas objetivo.
2. Si hay que recortar, reducir primero el alcance de HU-012 (historial de notificaciones), de menor impacto en la defensa.
3. HU-009 puede simplificarse a notificación por email si la integración FCM resulta costosa.

