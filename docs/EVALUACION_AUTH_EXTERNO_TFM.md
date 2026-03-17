# CRIApp - Evaluacion de usar servidor de autenticacion externo

Fecha: 17 de marzo de 2026
Contexto: decision para discutir con tutor/profesor en fase de cierre del TFM.

## 1. Situacion actual del proyecto

Autenticacion ya implementada internamente en la API:

- Registro, login, forgot password, reset password y perfil.
- JWT emitido por la propia API.
- Integracion de mensajeria para recuperacion (email/SMS).

Evidencia tecnica:

- [api/src/CRIApp.Api/Controllers/UserController.cs](../api/src/CRIApp.Api/Controllers/UserController.cs)
- [api/src/CRIApp.Application/Services/UserService.cs](../api/src/CRIApp.Application/Services/UserService.cs)
- [api/src/CRIApp.Api/Program.cs](../api/src/CRIApp.Api/Program.cs)
- [android/app/src/main/java/com/example/criapp/services/CriAppClient.kt](../android/app/src/main/java/com/example/criapp/services/CriAppClient.kt)

## 2. Pregunta de decision

Conviene migrar ahora a un proveedor externo de identidad (Auth0, Keycloak, Firebase Auth, Supabase Auth, Cognito, etc.)?

## 3. Analisis objetivo (para este TFM)

### Ventajas de un auth externo

- Seguridad y hardening mas robustos por defecto (MFA, rotacion de claves, controles de riesgo).
- Menor responsabilidad en gestion criptografica/credenciales a largo plazo.
- Buen argumento de arquitectura para producto real escalable.

### Desventajas de migrar ahora

- Coste de integracion alto en backend y Android en una fase final.
- Riesgo de regresion en flujos que ya funcionan (sign in, reset, perfil).
- Implica redisenar contratos de login/claims/permisos y adaptacion de app.
- Puede consumir semanas que ahora deben invertirse en refactor, calidad, despliegue y memoria.

## 4. Impacto estimado en calendario

### Migracion completa ahora (recomendada: NO)

Impacto probable: 2 a 4 semanas reales, incluyendo:

- Integracion proveedor + configuracion tenant.
- Cambios en endpoints y validacion de tokens.
- Refactor cliente Android para nuevo flujo.
- Repruebas end-to-end y ajustes de seguridad.

Riesgo: comprometer hitos academicos (anteproyecto, memoria, defensa) y calidad final.

### Mantener auth interno + hardening (recomendada: SI)

Impacto probable: 4 a 8 dias efectivos, incluyendo:

- Secretos por variables de entorno.
- HTTPS y configuracion por entorno.
- Mejorar expiracion/renovacion de token.
- Mejoras de validacion y logging de seguridad.

Beneficio: menor riesgo y mejor relacion esfuerzo/resultado para cierre de TFM.

## 5. Recomendacion para este TFM

Decision recomendada:

- No migrar a auth externo en esta fase de entrega.
- Mantener autenticacion interna y endurecerla tecnicamente.
- Incluir auth externo como trabajo futuro justificado, con opcion de PoC pequena si hay tiempo.

Razon principal:

- Ya existe un flujo de identidad funcional y operativo.
- El mayor valor academico ahora esta en calidad, refactor Android, despliegue y evidencia experimental para memoria.

## 6. Estrategia propuesta para hablar con el profesor

Mensaje sugerido:

"Evaluamos migrar a proveedor externo de identidad. Tecnologicamente aporta robustez, pero en fase final del TFM el coste y riesgo de regresion son altos. Optamos por mantener el auth interno y aplicar hardening de seguridad (secrets, HTTPS, validacion token, logging). Dejamos la migracion a auth externo como linea de trabajo futuro o PoC acotada si queda margen." 

## 7. Plan minimo de hardening (accionable)

1. Externalizar secretos y credenciales de auth/mensajeria.
2. Activar HTTPS y revisar configuracion por entorno.
3. Revisar expiracion de token y manejo de renovacion en Android.
4. Definir politicas basicas de autorizacion por recurso.
5. Registrar eventos de autenticacion y errores de seguridad.

## 8. Opcional: PoC pequena de auth externo (sin migrar todo)

Si el profesor quiere evidencia comparativa, hacer una PoC limitada:

- Solo endpoint de login social o validacion de token externo en una ruta piloto.
- Sin reemplazar todo el sistema actual.
- Resultado documentado en memoria como experimento de arquitectura.

## 9. Conclusion

Para el estado actual de CRIApp y el horizonte temporal hasta junio, la opcion mas realista y defendible es:

- mantener auth interno,
- mejorar seguridad y calidad,
- documentar auth externo como evolucion futura.

Esta decision maximiza probabilidad de entrega solida y buena defensa del TFM.
