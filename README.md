# CRIApp

## Descripción del Proyecto

CRIApp es una aplicación educativa desarrollada como Trabajo de Fin de Grado (TFM), inspirada en plataformas como Duolingo. Su objetivo principal es asistir a los padres en el proceso de crianza de sus hijos mediante lecciones interactivas, consejos y herramientas pedagógicas. La aplicación combina una API web robusta con una interfaz móvil intuitiva, promoviendo un enfoque gamificado para el aprendizaje parental.

Este proyecto se alinea con principios de la psicología educativa y la tecnología educativa, donde el aprendizaje activo y la retroalimentación inmediata facilitan la adquisición de conocimientos. Según teorías como el constructivismo de Piaget, el diseño interactivo de CRIApp permite a los usuarios construir conocimientos a través de experiencias prácticas, fomentando la autonomía y la reflexión en la crianza.

## Objetivos

- Desarrollar una API web en C# y .NET que proporcione funcionalidades backend escalables y seguras.
- Implementar un frontend móvil en Android y Kotlin, optimizado para una experiencia de usuario (UX) fluida y accesible.
- Integrar una base de datos PostgreSQL para la gestión eficiente de datos, asegurando persistencia y consultas rápidas.

## Tecnologías Utilizadas

- **Backend**: C# con .NET 8, aprovechando el framework ASP.NET Core para el desarrollo de APIs RESTful. Esto permite una arquitectura modular y orientada a microservicios, facilitando la separación de responsabilidades y la escalabilidad horizontal.
- **Base de Datos**: PostgreSQL, una base de datos relacional de código abierto que soporta transacciones ACID y consultas complejas, ideal para aplicaciones educativas que requieren integridad de datos.
- **Frontend**: Android con Kotlin, utilizando Jetpack Compose para una UI declarativa y moderna. Kotlin ofrece seguridad de tipos y interoperabilidad con Java, mientras que Android Studio proporciona herramientas para desarrollo móvil eficiente.
- **Otras Herramientas**: Git para control de versiones, con submodules para gestionar dependencias modulares.

## Instalación

### Prerrequisitos

- .NET 8 SDK instalado.
- PostgreSQL configurado y ejecutándose.
- Android Studio para el desarrollo del frontend.
- Git para clonar el repositorio.

### Pasos de Instalación

1. Clona el repositorio principal:
   ```
   git clone https://github.com/tu-usuario/CRIApp.git
   cd CRIApp
   ```

2. Inicializa y actualiza los submodules (si aplican):
   ```
   git submodule update --init --recursive
   ```

3. Para el backend:
   - Navega al directorio del API (ej. `cd CRIApp.API`).
   - Restaura las dependencias: `dotnet restore`.
   - Configura la cadena de conexión a PostgreSQL en `appsettings.json`.
   - Ejecuta las migraciones: `dotnet ef database update`.
   - Inicia el servidor: `dotnet run`.

4. Para el frontend:
   - Abre el proyecto en Android Studio (directorio `CRIApp.Android`).
   - Sincroniza Gradle y ejecuta en un emulador o dispositivo.

5. Actualización de submodules (como se indica en el repositorio):
   ```
   git submodule foreach 'git checkout main && git pull'
   git add .
   git commit -m "update submodules"
   git push
   ```

## Uso

- **API**: Accede a endpoints como `/api/lecciones` para obtener contenido educativo. La API sigue principios REST, permitiendo operaciones CRUD sobre recursos como usuarios, lecciones y progresos.
- **Aplicación Móvil**: Inicia sesión, selecciona lecciones temáticas sobre crianza (ej. disciplina, nutrición) y completa actividades interactivas. La gamificación incluye puntos y logros para motivar el aprendizaje continuo.

Relacionado con la teoría de la motivación intrínseca de Deci y Ryan (Self-Determination Theory), CRIApp diseña experiencias que satisfacen necesidades de autonomía, competencia y relación, potenciando el engagement del usuario.

## Contribución

Este proyecto es académico y abierto a contribuciones. Para contribuir:
1. Forkea el repositorio.
2. Crea una rama para tu feature: `git checkout -b feature/nueva-funcionalidad`.
3. Realiza commits descriptivos y solicita un pull request.
4. Sigue las guías de estilo de C# y Kotlin.

Como revisor académico, se recomienda citar fuentes como "Educación y Tecnología: Una Alianza para el Siglo XXI" de UNESCO para contextualizar el impacto educativo.

## Licencia

Este proyecto se distribuye bajo la Licencia MIT. Consulta el archivo `LICENSE` para más detalles.

## Contacto

Para preguntas o colaboraciones, contacta al autor del TFM: [matheus.eu.mv@gmail.com]. 

---

*Nota: Este README se basa en la estructura y objetivos del proyecto CRIApp. Asegúrate de actualizarlo conforme evolucione el desarrollo.*