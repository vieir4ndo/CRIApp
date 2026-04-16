# ADR-001 — Arquitectura Android: Migración a MVVM por capas

**Estado:** Aceptada  
**Historia de usuario asociada:** HU-002  
**Issue de referencia:** #28  
**Fecha de decisión:** Abril 2026  
**Autores:** Equipo CRIApp

---

## 1. Contexto

La aplicación Android de CRIApp fue desarrollada inicialmente con toda la lógica concentrada en las Activities. Este patrón, denominado habitualmente *God Activity*, presenta los siguientes problemas documentados en la bibliografía de ingeniería de software móvil:

- **Imposibilidad de testear la lógica de negocio** de forma aislada, ya que depende del ciclo de vida de Android.
- **Alto acoplamiento** entre UI, acceso a datos y lógica de dominio.
- **Pérdida de estado en rotaciones de pantalla** o cambios de configuración, al no sobrevivir las Activities a dichos eventos.
- **Duplicación de código** en el acceso a `SharedPreferences` y en las llamadas HTTP.

La documentación oficial de Android (Android Architecture Guidelines, Google 2023) y la bibliografía académica recomiendan el patrón **MVVM (Model–View–ViewModel)** para separar responsabilidades y alinear el desarrollo con el ciclo de vida gestionado de Android.

---

## 2. Decisión

Se adopta una **arquitectura en tres capas** para toda la aplicación Android:

```
presentation/   ← Activities + ViewModels + UiState
domain/         ← Interfaces de repositorio (contratos)
data/           ← Implementaciones de repositorio + cliente HTTP + preferencias
```

### Componentes introducidos

| Componente | Responsabilidad |
|---|---|
| `UiState<T>` (sealed class) | Representa los estados posibles de una operación asíncrona: `Idle`, `Loading`, `Success<T>`, `Error` |
| `ViewModel` (Jetpack) | Mantiene el estado de UI, sobrevive a cambios de configuración, expone `LiveData` |
| `LiveData<UiState<T>>` | Canal reactivo observable desde la Activity; garantiza actualizaciones en el hilo principal |
| `IXxxRepository` (interfaces) | Contratos del dominio, desacoplan ViewModel de la implementación concreta |
| `XxxRepositoryImpl` | Implementaciones con `withContext(Dispatchers.IO)`, ejecutan llamadas de red fuera del hilo principal |
| `PreferencesManager` | Centraliza el acceso a `SharedPreferences`, elimina duplicación |
| `CriAppHttpClient` | Cliente OkHttp único con `BuildConfig.BASE_URL`, reemplaza el cliente disperso anterior |
| `ViewModelProvider.Factory` | Inyección manual de dependencias sin framework externo |

---

## 3. Alternativas consideradas

| Alternativa | Motivo de descarte |
|---|---|
| Mantener arquitectura *God Activity* | No testeable, no mantenible, no escala |
| Migrar a Jetpack Compose | Requiere reescritura completa de layouts; fuera del alcance del TFM |
| Usar Hilt para inyección de dependencias | Añade complejidad de configuración; se pospone a iteración posterior |
| Migrar a Retrofit | Se pospone; OkHttp existente es suficiente para el alcance actual |
| MVP (Model–View–Presenter) | MVVM está más integrado con el ecosistema Jetpack y es la recomendación oficial de Google |

---

## 4. Consecuencias

### Positivas
- La lógica de negocio puede probarse con tests unitarios sin necesidad de emulador.
- El estado de UI sobrevive a rotaciones de pantalla gracias al `ViewModel`.
- El código es más legible, modular y alineado con los patrones del máster.
- La separación `domain/repository` permite cambiar la capa de datos (por ejemplo, migrar a Retrofit) sin modificar ViewModels.

### Negativas / Compromisos
- Se incrementa el número de ficheros por funcionalidad (ViewModel + Factory + Repository).
- Sin DI automático (Hilt/Koin), las factories se instancian manualmente en cada Activity.
- El cliente HTTP (OkHttp manual) deberá migrarse a Retrofit en una iteración futura para reducir código boilerplate.

---

## 5. Correcciones de ciclo de vida aplicadas

Durante la implementación se detectaron y corrigieron errores relacionados con el ciclo de vida de Android que se documentan aquí como parte de la decisión arquitectónica.

### 5.1 Listas sin actualización al volver al back stack

**Problema:** `loadX()` solo se llamaba en `onCreate()`. Al volver desde una Activity hija (p.ej. `UpdateForumActivity → ForumsActivity`), Android retoma la instancia existente mediante `onResume()`, sin invocar `onCreate()`. Los datos no se recargaban.

**Patrón establecido:**
```kotlin
override fun onResume() {
    super.onResume()
    viewModel.loadX()
}
```

**Complemento obligatorio:** `view.removeAllViews()` antes de repoblar el `LinearLayout` en el observer, para evitar duplicación de vistas si el observer se dispara más de una vez sobre la misma instancia.

**Activities corregidas:** `ForumsActivity`, `ChildActivity`, `QuestionsActivity`.

---

### 5.2 Back stack inflado por navegación manual

**Problema:** Las Activities de creación/edición (`CreateChildActivity`, `UpdateChildActivity`, `CreateForumActivity`, `UpdateForumActivity`) hacían `startActivity(Intent(this, ParentActivity::class.java))` en el estado `Success`. Esto creaba una nueva instancia del padre en lugar de regresar a la existente, inflando el back stack.

**Solución:** Sustituir `startActivity(...)` por `finish()`. Android gestiona automáticamente el retorno a la Activity anterior del stack.

```kotlin
// Antes (incorrecto)
startActivity(Intent(this, ChildActivity::class.java))

// Después (correcto)
finish()
```

---

### 5.3 Flujo de autenticación sin limpieza del back stack

**Problema:** Al completar el login, registro o logout, las Activities de autenticación permanecían en el back stack. El usuario podía volver a ellas pulsando *atrás* desde el menú principal.

**Solución aplicada por transición:**

| Transición | Solución |
|---|---|
| Login → `WelcomeMessagesActivity` | `finish()` tras `startActivity` |
| `WelcomeMessages` → `MenuActivity` | `finish()` tras `startActivity` |
| `ForgotPassword` → `ResetPassword` | `finish()` tras `startActivity` |
| `ResetPassword` / `SignUpSuccess` → `SignInActivity` | `FLAG_ACTIVITY_NEW_TASK or FLAG_ACTIVITY_CLEAR_TASK` |
| Logout (ProfileActivity) → `SignInActivity` | `FLAG_ACTIVITY_NEW_TASK or FLAG_ACTIVITY_CLEAR_TASK` |

`FLAG_ACTIVITY_CLEAR_TASK` destruye todas las Activities del stack antes de iniciar la nueva, garantizando que el usuario no pueda volver a sesiones anteriores.

---

### 5.4 `onBackPressed()` deprecated (API 33+)

**Problema:** El override de `onBackPressed()` fue declarado deprecated en Android API 33. Además, varias Activities lo usaban para navegar manualmente a la Activity padre, siendo innecesario porque el comportamiento por defecto de Android ya hace `finish()`.

**Solución:**
- Activities donde el back debe *bloquearse* (`SignInActivity`, `MenuActivity`): sustituir por `OnBackPressedCallback`.
- Activities donde el back debe simplemente volver al padre (`ChildActivity`, `QuestionsActivity`, `ForumsActivity`, `AnswerActivity`): eliminar el override, el comportamiento por defecto es correcto.

```kotlin
// Bloquear back (SignInActivity, MenuActivity)
onBackPressedDispatcher.addCallback(this, object : OnBackPressedCallback(true) {
    override fun handleOnBackPressed() { }
})

// Navegación natural — no override necesario
// Android llama finish() por defecto
```

---

### 5.5 `DialogBuilder` sin finalizar Activity origen

**Problema:** `DialogBuilder.withSubmitButtonRedirectingToActivity()` iniciaba la Activity destino pero no finalizaba la Activity origen, dejando instancias huérfanas en el back stack.

**Solución:**
```kotlin
submitButton.setOnClickListener {
    context.startActivity(Intent(context, redirectTo))
    (context as? Activity)?.finish()
}
```

---

## 6. Relación con la bibliografía del máster

- **Patrón MVVM:** Gamma et al. (1994), *Design Patterns* — Observer pattern como base conceptual de LiveData/Observer.
- **Separación de capas:** Martin (2017), *Clean Architecture* — Regla de dependencia: las capas internas no conocen las externas.
- **Ciclo de vida Android:** Android Developers Documentation — *Activity Lifecycle*, *ViewModel Overview*, *LiveData Overview*.
- **Back stack:** Android Developers Documentation — *Tasks and Back Stack*.
- **Callbacks modernos:** `OnBackPressedDispatcher` — introducido en AndroidX Activity 1.0.0 como reemplazo del deprecated `onBackPressed()`.

---

## 7. Estado de implementación

| Módulo | ViewModel | Repository | Ciclo de vida corregido |
|---|---|---|---|
| Autenticación (Sign In/Up, Forgot/Reset) | ✅ | ✅ | ✅ |
| Perfil | ✅ | ✅ | ✅ |
| Hijos (Child, Create, Update) | ✅ | ✅ | ✅ |
| Preguntas / Respuestas | ✅ | ✅ | ✅ |
| FAQ | ✅ | ✅ | — (solo lectura) |
| Recursos audiovisuales | ✅ | ✅ | — (solo lectura) |
| Foros (Forums, Forum, Create, Update) | ✅ | ✅ | ✅ |
| Menú / Welcome | — | — | ✅ |

**Pendiente para próxima iteración:** migración a Retrofit, introducción de Hilt para DI, tests unitarios de ViewModels.
