# CRIApp - Plan de Trabajo TFM (Sprints + Kanban)

Fecha de inicio del plan: 17 de marzo de 2026
Marco de trabajo: Scrum ligero (semanal) + Kanban (flujo diario)
Fuente de backlog: [docs/HISTORIAS_USUARIO_NUEVO_CICLO.md](HISTORIAS_USUARIO_NUEVO_CICLO.md)

## 1. Objetivo del plan

Convertir las historias de usuario existentes en una hoja de ruta semanal realista hasta fin de junio, respetando hitos academicos y la estrategia del proyecto:

- refactor Android con patrones del master,
- mejora de calidad (tests, seguridad, despliegue),
- cierre academico (anteproyecto, memoria final, defensa).

## 2. Suposiciones de capacidad

- Capacidad media: 6-8 puntos por semana.
- Velocidad objetivo para planificar: 7 puntos/semana.
- Punto total backlog actual: 92 puntos.
- Duracion estimada para completar backlog principal: 13-14 semanas.

Nota: HU-016 (memoria final) se trabaja en paralelo, no se deja para el final.

## 3. Politica de metodologia (como ejecutar cada semana)

### Scrum semanal (cadencia)

- Lunes/martes: planificacion semanal (seleccion de HU y subtareas).
- Diario: seguimiento Kanban breve (10-15 min).
- Fin de semana: review + retrospectiva corta + actualizacion de evidencia para memoria.

### Kanban (flujo recomendado)

Columnas sugeridas para Git Projects:

- Backlog
- Ready
- In Progress
- Review
- Done

Politicas:

- WIP maximo: 2 tarjetas en In Progress.
- No mover a Done sin DoD y evidencia minima.
- Cada HU cerrada debe dejar evidencia en docs para HU-014/HU-016.

## 4. Hitos academicos obligatorios

- Hito A: HU-015 (anteproyecto 1 pagina PDF) antes del 7 de abril de 2026.
- Hito B: HU-016 (memoria final) completada antes de fin de junio.
- Hito C: HU-017 (defensa) preparada con diapositivas + demo + ensayo.

## 5. Distribucion recomendada por semanas

## Semana 1 (17 mar - 22 mar)

Objetivo: arrancar formalmente y asegurar hito academico inmediato.

- HU-015 Anteproyecto TFM (2 pts)
- HU-014 Evidencias para memoria por historia (arranque de plantilla) (3 pts)
- HU-003 Validaciones mejoradas (inicio) (parcial)

Carga objetivo: 7 pts
Resultado esperado: anteproyecto casi final + plantilla de evidencia operativa.

## Semana 2 (23 mar - 29 mar)

Objetivo: cerrar anteproyecto y preparar base de refactor.

- HU-015 cierre y version final PDF (resto)
- HU-001 Refactor arquitectura Android (inicio) (8 pts, parcial)

Carga objetivo: 7 pts
Resultado esperado: anteproyecto cerrado y primer modulo Android reestructurado.

## Semana 3 (30 mar - 5 abr)

Objetivo: consolidar arquitectura y cumplir fecha de entrega.

- HU-001 Refactor arquitectura Android (cierre)
- HU-002 Cliente API Android robusto (inicio) (5 pts, parcial)

Carga objetivo: 7 pts
Resultado esperado: arquitectura base asentada + entrega lista para 7 abril.

## Semana 4 (6 abr - 12 abr)

Objetivo: cerrar base tecnica Android y abrir bloque de calidad.

- HU-002 Cliente API Android robusto (cierre)
- HU-003 Validaciones mejoradas (cierre)

Carga objetivo: 6-7 pts
Resultado esperado: networking y validaciones consistentes.

## Semana 5 (13 abr - 19 abr)

Objetivo: red de seguridad en backend.

- HU-011 Pruebas backend servicios criticos (inicio) (8 pts, parcial)

Carga objetivo: 7 pts
Resultado esperado: proyecto de tests backend y primeros casos criticos ejecutando.

## Semana 6 (20 abr - 26 abr)

Objetivo: completar calidad backend y arrancar Android tests.

- HU-011 Pruebas backend (cierre)
- HU-012 Pruebas Android (inicio) (8 pts, parcial)

Carga objetivo: 7-8 pts
Resultado esperado: base de calidad automatizada en ambos frentes.

## Semana 7 (27 abr - 3 may)

Objetivo: completar pruebas Android y pasar a pendientes funcionales.

- HU-012 Pruebas Android (cierre)
- HU-004 Gestion completa de preguntas (inicio/cierre segun alcance) (5 pts)

Carga objetivo: 7-8 pts
Resultado esperado: suite minima de pruebas + preguntas con gestion ampliada.

## Semana 8 (4 may - 10 may)

Objetivo: completar gestion de contenido.

- HU-005 Gestion FAQ (3 pts)
- HU-006 Gestion recursos audiovisuales (3 pts)

Carga objetivo: 6 pts
Resultado esperado: FAQ y recursos con gestion completa (no solo consulta).

## Semana 9 (11 may - 17 may)

Objetivo: gamificacion y engagement.

- HU-007 Sistema de premios (5 pts)
- HU-008 Notificaciones utiles (inicio) (5 pts, parcial)

Carga objetivo: 7-8 pts
Resultado esperado: premios funcionales y notificaciones en avance real.

## Semana 10 (18 may - 24 may)

Objetivo: hardening tecnico de entorno real.

- HU-008 Notificaciones utiles (cierre)
- HU-010 Hardening de seguridad API (5 pts)

Carga objetivo: 7-8 pts
Resultado esperado: seguridad minima y notificaciones operativas con logs.

## Semana 11 (25 may - 31 may)

Objetivo: despliegue y consolidacion repositorio.

- HU-009 Despliegue cloud gratuito API (5 pts)
- HU-013 Consolidacion estructura duplicada (3 pts)

Carga objetivo: 8 pts
Resultado esperado: API publica en cloud + estructura mas limpia.

## Semana 12 (1 jun - 7 jun)

Objetivo: iniciar cierre academico fuerte.

- HU-016 Memoria final (bloque 1: marco, requisitos, metodologia) (parcial)
- HU-014 actualizacion final de evidencias por HU

Carga objetivo: 6-7 pts efectivos de redaccion/documentacion
Resultado esperado: primer bloque de memoria completo y trazabilidad al dia.

## Semana 13 (8 jun - 14 jun)

Objetivo: construir resultados y discusion de memoria.

- HU-016 Memoria final (bloque 2: implementacion, pruebas, resultados) (parcial)

Carga objetivo: 6-7 pts
Resultado esperado: cuerpo tecnico principal de memoria cerrado.

## Semana 14 (15 jun - 21 jun)

Objetivo: preparar defensa mientras se cierra memoria.

- HU-016 Memoria final (bloque 3: conclusiones, trabajo futuro, edicion final)
- HU-017 Defensa (inicio: diapositivas + guion) (parcial)

Carga objetivo: 7 pts
Resultado esperado: memoria casi final + deck inicial de defensa.

## Semana 15 (22 jun - 30 jun)

Objetivo: cierre final academico.

- HU-016 entrega final memoria
- HU-017 defensa (demo en vivo + ensayo cronometrado + plan contingencia)

Carga objetivo: 7 pts
Resultado esperado: memoria entregada y defensa lista para tribunal.

## 6. Plan resumen por fases

- Fase 1 (Semanas 1-4): Hito 7 abril + base refactor Android.
- Fase 2 (Semanas 5-8): Calidad automatizada + gestion de contenido.
- Fase 3 (Semanas 9-11): Gamificacion + seguridad + despliegue.
- Fase 4 (Semanas 12-15): Memoria final + defensa.

## 7. Regla practica para mover tarjetas en Git Projects

Mover una historia a Done solo si cumple simultaneamente:

- Criterios BDD verificados.
- DoD completo.
- Evidencia registrada en docs (captura, prueba o resultado medible).
- Impacto reflejado en memoria (si aplica).

## 8. Contingencia (si una semana se complica)

Orden de proteccion de hitos:

1. No mover HU-015 ni HU-016 de sus ventanas objetivo.
2. Mantener HU-001/HU-002/HU-011/HU-012 como nucleo de calidad.
3. Si hace falta recortar, recortar primero alcance de HU-006 y HU-013.

---

Documento operativo: puedes copiar esta secuencia a Git Projects y usarla como baseline de planificacion semanal.
