# Diario de Desarrollo — 8 al 11 de Mayo de 2026

---

## Viernes 8 de Mayo

### API
- `a9c6bb6` — Añadidas traducciones (ES/EN/PT) en `AppMessages.resx` y `EmailMessages.resx` (#63)
- `aac1d81` — Mejoradas plantillas de email con HTML y logo inline (#67)
- `63ed6ec` — Corregidos tests unitarios afectados por cambios anteriores (#55)
- `f53e0a4` — Permitido el valor 6 en respuestas de cuestionario (escala Likert completa 1–6) (#55)

### Android
- `8226080` — Corregido el parser de fechas (`DateHelper`) (#55)
- `d9f88b1` — Corregido el cierre de actividad al no quedar más preguntas disponibles en el día (#55)
- `26bc8c0` — Adaptada la UI para aceptar respuestas entre 1 y 6 (#55)
- `feb72b9` — Pequeñas correcciones generales (#55)
- `76e8b2c` / `4268683` — Añadidas y corregidas strings de traducción (ES/EN/PT) (#63)
- `55d5315` — Implementada pantalla de premios (`AwardActivity` + `AwardViewModel` + `AwardAdapter`) (#64)
- `04cc2d2` — Implementada pantalla de recomendaciones (`RecommendationActivity`) (#65)
- `4c611a8` — Añadidas imágenes de recomendaciones (`rec_01.png` a `rec_45.png`) (#65)
- `986c321` — Corregidos textos en pantallas de premios y recomendaciones (#64, #65)
- `1739602` — Corregidas imágenes de recomendaciones (#65)

---

## Sábado 9 de Mayo

### Android
- `860602a` — Sincronización de `dev` con el estado completo después de mergear todas las issues
- `01ef1fb` — Eliminado archivo duplicado y apuntado Gradle a la URL real de la API (#60)
- `9906144` / `901ba14` — Añadido adaptador vacío al ViewPager mientras la API carga datos (#65, #55)
- `0895f99` — Añadido lint de commits y ramas al repositorio Android (#60)
- `29ce17d` — Implementada solicitud para desactivar cuenta de usuario (#57)
- `322398c` — Eliminadas imágenes sin uso (#57)
- `dc53aa6` — Corregida la visualización de mensajes de error al usuario (#57)
- `c1e4042` — Añadido pipeline de CI/CD para publicar APK al hacer merge en `main` (#60)
- `a8263fa` — Redirigir a YouTube al hacer clic en recurso audiovisual (#58)
- `e9c2ef5` — Mejorada la responsividad del menú principal (#58)
- `476eb2e` — Corregido el tamaño de los campos de entrada en las pantallas de login (#55)

---

## Domingo 10 de Mayo

### API
- `1d646ec` / `751a7af` — Renombrada entidad `Advice` → `Recommendation`; reiniciadas migraciones (#73)
- `cdc9bb5` / `5ccb2e8` — Implementada entidad `RecommendationCheckpoint` con campo `Completed` y constraint único por día (#74)
- `7e96671` — Cambiada lógica de cálculo de score: 70% respuestas + 30% checkpoints (#75)
- `6de0b61` — Añadido `QuestionGroup` y endpoint para obtener preguntas por grupo (#72)
- `96e3771` — Reimplementados premios alineados con los requisitos:
  - `HabitBuilder` — 3 días consecutivos con checkpoints completados
  - `ConsistentParent` — checkpoints en 7 días distintos
  - Medallas de plata por grupo HEFAS (cognitivo, emocional, rutinas, social)
  - Medalla de oro — todas las medallas de plata obtenidas
- `d4c02a8` — Corregida lógica de envío de recomendaciones (#76)
- `ed7d467` — Añadidas nuevas imágenes de medallas (#76)
- `91ca349` — Corregidos tests unitarios (#76)
- `f11b79d` — Implementada infraestructura de notificaciones y jobs por cadencia HEFAS:
  - `SendMotivationalNotificationJob` — si han pasado exactamente 2 días sin checkpoint
  - `SendPointsRiskNotificationJob` — si han pasado exactamente 3 días sin checkpoint
  - `SendReEvaluationNotificationJob` — si hay 7+ días de inactividad
- `931b197` — Reiniciadas migraciones (#78)
- `b6dfb82` — Añadidas traducciones al response de notificaciones (#78)
- `04ccf95` — Notificaciones creadas automáticamente al generar premios y recomendaciones (#56)
- `9088662` — Añadido historial de notificaciones (#59)
- `bd998bb` — Corregido: no devolver notificaciones para usuarios nuevos sin actividad (#59)

### Android
- `90daa90` — Renombrada `Advice` → `Recommendation` en el cliente (#70)
- `65e47fb` — Eliminado `adminId` de tablas que no lo necesitaban (#71)
- `31ecab2` — Implementada UI del ChildBook (#68)
- `72d1c1b` — Cargadas imágenes de premios y recomendaciones desde la API (#68)
- `492aa87` — Renombrada `Advice` → `Recommendation` en el cliente Android (#73)
- `87b3d7b` — Implementado flujo de RecommendationCheckpoint (botones YES/NO por recomendación) (#77)
- `b3defef` — Corregido comportamiento de tabs al confirmar checkpoint (#76)
- `f52e338` — Textos de premios obtenidos desde la API en lugar de hardcodeados (#76)
- `faad76c` — Añadido WorkManager para notificaciones locales (#78)
- `efb9b8c` — Corregido texto de saludo en el menú (#78)
- `186aa44` — Corregidos márgenes en pantallas de FAQ y recursos audiovisuales (#78)
- `2c8cc95` — Añadido historial de notificaciones (#59)
- `4597cd5` — Pequeñas correcciones de UI (#59)

---

## Lunes 11 de Mayo

### API
- `646cc94` — Añadida paginación al endpoint de notificaciones (`GET /notifications?page=&pageSize=`)
- `e735149` — Implementado **feature flag** `PhoneNumberUsernameEnabled`:
  - Nueva clase `FeatureSettings` con static `Current` + `Initialize()`
  - `GET /feature-flags` — endpoint público sin autenticación
  - Los 4 validators (`CreateUser`, `Login`, `ForgotPassword`, `ResetPassword`) usan el flag para decidir si aceptan teléfono como username
  - `IsValidUsernameEmail()` añadido a `ValidationExtensions`
- `d24d991` — Flag `PhoneNumberUsernameEnabled` desactivado por defecto en `appsettings.json`
- `412b399` — Corregidos tests unitarios:
  - 8 tests fallaban por senhas frágiles (`"password123"` → `"Password1!"`) y por flag desactivado en test
  - Construtores inicializan `FeatureSettings` con el flag activado en los tests de teléfono
- `d86c02b` — Corregidas frecuencias de los jobs Hangfire:
  - `UpdateAndAwardChildBookJob`: `Minutely` → `Daily`
  - `SaveUsersRecommendations`: `Hourly` → `Daily`

### Android
- `00d19b6` — Añadida paginación en pantalla de notificaciones
- `1c04ef2` / `138f12a` — Mejoras generales de UI
- `b099da4` — Corregido build roto
- `0e72e7e` — Corregidas animaciones entre actividades
- `effa10a` — Implementado **feature flag** en Android:
  - `FeatureFlagsResponse.kt`, `FeatureFlagsManager.kt`
  - `getFeatureFlags()` en `IAuthRepository` + `AuthRepositoryImpl`
  - `SignInViewModel.loadFeatureFlags()` llamado en el inicio
  - Labels de username dinámicos en `SignInActivity`, `SignUpActivity`, `ForgotPasswordActivity`
  - `AbstractValidator.isValidUsername()` condicional al flag
  - Strings `username_with_phone` y `username_email_only` en ES/EN/PT
- `4885fe3` / `571f29e` — Pipeline de CI actualizado para publicar APK firmado
- `07dbe0f` — **Corrección de scroll con teclado**:
  - `activity_forgot_password.xml`: `LinearLayout` y `ScrollView` con `match_parent` + `fillViewport="true"`
  - `activity_create_forum.xml`: contenido del card envuelto en `ScrollView` con `fillViewport="true"`

---

## Resumen de issues completadas (8–11 mayo)

| Issue | Descripción | Estado |
|---|---|---|
| #55 | Escala Likert 1–6 en respuestas | ✅ |
| #56 | Notificaciones al crear premios/recomendaciones | ✅ |
| #57 | Desactivación de cuenta | ✅ |
| #58 | Recursos audiovisuales + menú responsivo | ✅ |
| #59 | Historial de notificaciones | ✅ |
| #60 | CI/CD, pipelines, lint | ✅ |
| #63 | Traducciones ES/EN/PT | ✅ |
| #64 | Pantalla de premios Android | ✅ |
| #65 | Pantalla de recomendaciones Android | ✅ |
| #67 | Mejora de plantillas de email | ✅ |
| #68 | ChildBook — entidad + UI | ✅ |
| #70/71 | Rename Advice → Recommendation (limpieza) | ✅ |
| #72 | QuestionGroup — agrupación de preguntas | ✅ |
| #73 | Rename Advice → Recommendation (definitivo) | ✅ |
| #74 | RecommendationCheckpoint backend | ✅ |
| #75 | Score 70/30 (respuestas + checkpoints) | ✅ |
| #76 | Nuevos premios HabitBuilder/ConsistentParent/HEFAS | ✅ |
| #77 | Checkpoint YES/NO en Android | ✅ |
| #78 | Jobs de notificación por cadencia HEFAS | ✅ |
| —  | Feature flag PhoneNumberUsernameEnabled | ✅ |
| —  | Corrección frecuencia jobs Hangfire | ✅ |
| —  | Corrección scroll con teclado (forgot/forum) | ✅ |
