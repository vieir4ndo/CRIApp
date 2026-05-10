# CRIApp - Plan de Trabajo TFM (Sprints + Kanban)

Fecha de inicio del plan: 6 de abril de 2026
Última revisión: 10 de mayo de 2026
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
- Puntos ya entregados (semanas 1-5): ~68 puntos (incluyendo HU-010, HU-011, HU-021, HU-022, HU-023, HU-024 adelantadas).
- Puntos nuevos incorporados (HU-026 a HU-031): 21 puntos.
- Puntos restantes estimados: ~49 puntos (HU-025 + HU-026 a HU-031 + HU-009 + HU-012 + HU-014 + HU-015).
- Duración restante: 7 semanas productivas (18 may — 30 jun) + pausa semana 6.

Nota: HU-014 (memoria final) se trabaja en paralelo desde la semana 11, no se deja para el final.

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
- HU-010 Desactivación de cuenta — DONE completo end-to-end (backend + Android)
- HU-011 Visualización robusta de recursos audiovisuales — DONE (adelantada)
- HU-021 Entidad ChildBook: libro de progreso del hijo — DONE (adelantada)
- HU-022 Premios del hijo con traducciones en BD — DONE (adelantada)
- HU-023 Renombrar Recomendación a Consejo — DONE (adelantada)
- HU-024 Desacoplamiento de admin en FAQ, Question y Consejo — DONE (adelantada)

Nota retrospectiva: Las semanas 4-5 fueron extraordinariamente productivas. Se adelantaron HU-016/017/018/019/020 y se cerró HU-008 con alcance ampliado. Además, se completaron anticipadamente HU-010, HU-011, HU-021, HU-022, HU-023 y HU-024 — historias originalmente planificadas para las semanas 7–10. El análisis del protocolo HEFAS (10 mayo) identificó el bucle conductual de verificación de rutinas como funcionalidad nuclear no implementada, originando las HU-026 a HU-031.

---

## 6. Distribución recomendada — semanas restantes (a partir del 11 de mayo)

### Semana 6 (11 may - 17 may) — ⏸ Pausa

Sin trabajo en el TFM esta semana.

---

### Semana 7 (18 may - 24 may)

Objetivo: iniciar el bucle conductual HEFAS — rename semántico y checkpoint backend.

- HU-026 Renombrar Advice a Recommendation (alineación HEFAS) (2 pts)
- HU-027 RecommendationCheckpoint — entidad, endpoints y lógica backend (5 pts)

Orden dentro de la semana: HU-026 primero (prerequisito semántico, bajo riesgo). HU-027 a continuación sobre la base renombrada.
Carga objetivo: ~7 pts
Resultado esperado: entidad `Recommendation` con nombre correcto; entidad `RecommendationCheckpoint` persistida; endpoint `POST .../checkpoint` operativo; `GET /child/{id}/book` devuelve `TodayCompleted` por recomendación.

Nota: HU-023 y HU-024 (originalmente previstas para esta semana) ya están cerradas como parte del sprint anticipado de la semana 5.

---

### Semana 8 (25 may - 31 may)

Objetivo: agrupación de preguntas + score basado en checkpoints.

- HU-025 Agrupación de preguntas y rotación por grupo (3 pts)
- HU-028 Actualización del score basada en checkpoints de rutinas (3 pts)

Orden dentro de la semana: HU-025 primero (independiente, bajo riesgo). HU-028 al final (depende de HU-027 de la semana anterior).
Carga objetivo: ~6 pts
Resultado esperado: selección diaria de preguntas equilibrada por grupo temático; score `ChildBook` combina cuestionario (70%) y checkpoints de rutinas (30%).

Nota: HU-010 (desactivación) ya está cerrada; HU-025 se mantiene en esta semana sin cambio.

---

### Semana 9 (1 jun - 7 jun)

Objetivo: Android — verificación de rutinas y nuevos premios conductuales.

- HU-030 Android — verificación diaria de rutinas en pantalla de recomendaciones (5 pts)
- HU-029 Nuevos premios por racha de checkpoints (`HabitBuilder`, `ConsistentParent`) (3 pts)

Orden dentro de la semana: HU-030 primero (UX visible, depende de HU-027). HU-029 al final (backend, menor impacto visible).
Carga objetivo: ~8 pts
Resultado esperado: el PCR puede marcar YES/NO por rutina desde la app; dos nuevos tipos de premio por constancia operativos.

---

### Semana 10 (8 jun - 14 jun)

Objetivo: notificaciones HEFAS por cadencia + notificaciones de eventos (premios y orientaciones) + WorkManager Android.

- HU-031 Notificaciones basadas en checkpoints de rutinas (cadencia 2/3/7 días) ✅ DONE (10 may)
- HU-009 Notificaciones útiles — sistema completo BD + WorkManager Android ✅ DONE (10 may)

Resultado real: sistema completo de notificaciones sin FCM. La API crea notificaciones en la BD (entidad `Notification`, 5 tipos). El WorkManager Android realiza polling cada 15 minutos via `GET /notifications/pending`, muestra las notificaciones del sistema y las marca como entregadas. Textos localizados (ES/EN/PT) con el nombre del niño interpolado en la API. Notificaciones de nuevo premio y nuevas orientaciones creadas por los jobs `UpdateAndAwardChildBookJob` y `SaveUsersRecommendations`. Toda la creación de notificaciones canalizada por `INotificationService.CreateIfNotExists` (capa de servicio; los jobs no acceden directamente al repositorio).

---

### Semana 11 (15 jun - 21 jun)

Objetivo: historial de notificaciones + arranque de la memoria.

- HU-012 Consulta de historial de notificaciones (3 pts)
- HU-014 Memoria final del TFM — bloque 1: introducción, marco teórico, requisitos, metodología (4 pts)

Carga objetivo: ~7 pts
Resultado esperado: historial de notificaciones visible en la app; primeros capítulos de la memoria en borrador avanzado.

---

### Semana 12 (22 jun - 28 jun)

Objetivo: núcleo técnico de la memoria + inicio de la defensa.

- HU-014 Memoria final del TFM — bloque 2: arquitectura, implementación, pruebas, resultados (5 pts)
- HU-015 Preparación de defensa en tribunal — inicio: estructura de diapositivas y guión v1 (2 pts)

Carga objetivo: ~7 pts
Resultado esperado: capítulos de implementación y pruebas documentados con evidencias del repositorio; primera versión de la presentación disponible.

---

### Semana 13 (29 jun - 30 jun) — Cierre

Objetivo: cierre académico total.

- HU-014 Memoria final del TFM — bloque 3: conclusiones, trabajo futuro, edición global y entrega (4 pts)
- HU-015 Preparación de defensa en tribunal — cierre: demo en vivo, ensayo cronometrado y plan de contingencia (3 pts)

Carga objetivo: ~7 pts (semana corta, 2 días)
Resultado esperado: memoria entregada y defensa lista para el tribunal.

## 7. Resumen por fases

- Fase 1 — Semanas 1-3 ✅: Anteproyecto + fundamentos técnicos Android + seguridad + tests + logging + despliegue cloud.
- Fase 2 — Semanas 4-5 ✅: Gamificación, recomendaciones, i18n, emails, ChildBook, premios localizados, rename dominio, desacoplamiento admin, desactivación, audiovisual.
- Fase 3 — Semana 6: Pausa.
- Fase 4 — Semana 7: Bucle conductual HEFAS — rename Advice→Recommendation + RecommendationCheckpoint backend.
- Fase 5 — Semana 8: Agrupación de preguntas + score basado en checkpoints.
- Fase 6 — Semana 9: Android — verificación de rutinas YES/NO + nuevos premios de racha.
- Fase 7 — Semana 10: Notificaciones HEFAS por cadencia + eventos (premios/orientaciones) + WorkManager Android (HU-031 + HU-009) ✅ DONE.
- Fase 8 — Semana 11: Historial de notificaciones + arranque de memoria.
- Fase 9 — Semanas 12-13: Memoria final + preparación de defensa.
- Fase 7 — Semana 10: Traducciones de premios + notificaciones push (sobre dominio limpo).
- Fase 8 — Semana 11: Historial de notificaciones + arranque de memoria.
- Fase 9 — Semanas 12-13: Memoria final + preparación de defensa.

## 8. Estado actual de HU (10 mayo 2026)

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
| HU-009 | Notificaciones útiles | ✅ DONE (10 may) |
| HU-010 | Desactivación de cuenta end-to-end | ✅ DONE (10 may) |
| HU-011 | Visualización robusta de recursos audiovisuales | ✅ DONE (9 may) |
| HU-012 | Consulta de historial de notificaciones | ⬜ Semana 11 |
| HU-013 | Despliegue cloud gratuito de API | ✅ DONE |
| HU-014 | Memoria final del TFM | ⬜ Semanas 11-13 |
| HU-015 | Preparación de defensa en tribunal | ⬜ Semanas 12-13 |
| HU-016 | Soporte multilingüe (i18n) | ✅ DONE |
| HU-017 | Rotación inteligente de preguntas y mejoras de UI | ✅ DONE |
| HU-018 | Sistema de Recomendaciones personalizadas | ✅ DONE |
| HU-019 | Limpieza automática de códigos de reset | ✅ DONE |
| HU-020 | Mejoras en templates de email | ✅ DONE |
| HU-021 | Entidad ChildBook: libro de progreso del hijo | ✅ DONE (10 may) |
| HU-022 | Premios del hijo con traducciones en BD | ✅ DONE (10 may) |
| HU-023 | Renombrar Recomendación a Consejo | ✅ DONE (10 may) |
| HU-024 | Desacoplamiento de admin en FAQ, Question y Consejo | ✅ DONE (10 may) |
| HU-025 | Agrupación de preguntas y rotación por grupo | ⬜ Semana 8 |
| HU-026 | Renombrar Advice a Recommendation (HEFAS) | ⬜ Semana 7 |
| HU-027 | RecommendationCheckpoint — backend | ⬜ Semana 7 |
| HU-028 | Score basado en checkpoints de rutinas | ⬜ Semana 8 |
| HU-029 | Nuevos premios por racha de checkpoints | ⬜ Semana 9 |
| HU-030 | Android — verificación diaria de rutinas | ⬜ Semana 9 |
| HU-031 | Notificaciones basadas en checkpoints | ✅ DONE (10 may) |

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
3. HU-009 ✅ completada sin FCM — sistema de notificaciones por polling con WorkManager (respaldado en BD).
4. HU-021 (ChildBook) es el refactoring de mayor riesgo; si se bloquea, la semana 9 puede reconfigurarse para avanzar HU-011 y HU-012 y dejar ChildBook como trabajo futuro documentado en la memoria.

