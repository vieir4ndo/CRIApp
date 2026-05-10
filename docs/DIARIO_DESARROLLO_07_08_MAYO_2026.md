# CRIApp — Diário de Desenvolvimento (7–8 Maio 2026)

Sprint atual: Semana 5 (4–10 maio) — issue#35

---

## Backend API — O que foi desenvolvido

### Gamificação (HU-008 — DONE)

- **Job `CalculateAndSaveAwards`** (diário): 5 tipos de prêmio comportamentais:
  - `FirstSteps` — respondeu ≥5 perguntas distintas
  - `EngagedFamily` — respondeu em 3 dias consecutivos
  - `Overcoming` — pontuação melhorou ≥20% vs dia anterior
  - `PositiveEnvironment` — pontuação > 80
  - `SmallProgress` — pontuação melhorou vs dia anterior
- **Cálculo de score**: `UpdateUsersScoreJob` + `UserService.UpdateScore` — score = respostas corretas × 100 / total (0–100%). Tipo de scoring por pergunta: `Default` (1–4 positivos) ou `Reversed` (5–6 positivos).
- **Endpoint** GET `/users/{id}/awards` — retorna lista de `AwardDto`
- **Entidade `Award`** com enum `AwardType` (5 valores)

### Sistema de Recomendações (novo)

- **Entidade `Recommendation`** com campos `Text`, `TextEn`, `TextPt`, associada a `Question` e `User`
- Salvas por admin, associadas a usuários com base nas respostas
- **Endpoint** GET `/users/{id}/recommendations`
- **Migrations**: `AddRecommendationsToUsersTable`, `AddRecommendationTable`, `AddTranslationColumns`

### Desativação de conta (HU-010 — backend DONE)

- `POST /users/{id}/deactivate` → `UserService.Deactivate()` → `user.Deactivate()`
- Android pendente

### Jobs implementados

| Job | Descrição |
|-----|-----------|
| `CalculateAndSaveAwards` | Gamificação — avalia e persiste prêmios diariamente |
| `UpdateUsersScoreJob` | Recalcula score de todos os usuários |
| `NotifyUsersWithLessThanTenAnswersJob` | Skeleton criado — TODO: push notifications |
| `CleanUserResetPasswordCodesJob` | Limpa códigos de reset expirados (> 10 min) |

### Email (SMTP) melhorado

- Logo embebido como attachment inline no email
- Templates HTML com variáveis localizadas
- `EmailMessages.resx` em ES/EN/PT

### i18n — Suporte multilingüe (HU-016 — DONE)

#### API — Mensagens de negócio (`AppMessages`)

- Arquivo `AppMessages.cs` (marcador de recurso) + 3 arquivos `.resx`: `AppMessages.es.resx`, `AppMessages.en.resx`, `AppMessages.pt.resx`
- 12 chaves de mensagem cobrindo todos os erros de negócio: `UserAlreadyExists`, `InvalidCredentials`, `UserNotFound`, `InvalidResetCode`, `ChildNotFound`, `ChildNotBelongsToUser`, `ChildNotFoundForUser`, `QuestionNotFound`, `ForumNotFound`, `ForumNotBelongsToUser`, `CommentNotFound`, `GenericError`
- `IStringLocalizer<AppMessages>` injetado e usado em todos os serviços: `UserService`, `AnswerService`, `ChildService` (e demais)
- Idioma resolvido automaticamente pelo header `Accept-Language` da requisição HTTP

#### API — Mensagens de email e SMS (`EmailMessages`)

- `EmailMessages.cs` + `EmailMessages.es.resx`, `EmailMessages.en.resx`, `EmailMessages.pt.resx`
- Cobre 2 fluxos de email completos com todas as partes da template HTML:
  - **Criação de conta**: assunto, título, preheader, heading, corpo, campo "registrado com"
  - **Recuperação de senha**: assunto, título, preheader, heading, corpo, tempo de expiração, nota de expiração
- Rodapé compartilhado: mensagem automática, aviso de no-reply, copyright
- Mensagens SMS para criação de conta e recuperação de senha

#### API — Configuração de localização (`Program.cs`)

```csharp
builder.Services.AddLocalization();

app.UseRequestLocalization(options =>
{
    options.SetDefaultCulture("es");
    options.AddSupportedCultures("es", "en", "pt");
    options.AddSupportedUICultures("es", "en", "pt");
});
```

- Cultura padrão: espanhol (`es`)
- Culturas suportadas: `es`, `en`, `pt`
- Resolução automática via header `Accept-Language`

#### API — Traduções em entidades do domínio

- `Recommendation`: campos `TextEn`, `TextPt` adicionados à entidade e mapeados no EF Core
- Migration `AddTranslationColumns` (08/05/2026) aplicada para colunas de tradução
- `RecommendationDto` retorna texto no idioma correto com base na cultura da requisição

#### Android — Strings multilingüe

- 3 arquivos `strings.xml` com **89 strings cada**: `values/` (ES base), `values-en/`, `values-pt/`
- Cobertura de todas as activities principais: SignIn, SignUp, Menu, Profile, Answer, Award, Recommendation, Child, Forum, FAQ, etc.
- Resolução automática pelo sistema Android com base no idioma do dispositivo

### Outros

- Validação de respostas: aceita valores 1–6 (escala Likert completa)
- Split Query EF Core para consultas de awards/recommendations (performance)
- Swagger com suporte a autenticação JWT
- `family_type` tratado como campo opcional em pergunta

---

## Android — O que foi desenvolvido

### Tela de Prêmios (HU-008 — DONE)

- `AwardActivity` + `AwardViewModel` (MVVM) + `AwardAdapter` (RecyclerView)
- `AwardViewModelFactory` para injeção de dependência manual
- `IAwardRepository` (domínio) + `AwardRepositoryImpl` (dados)
- `AwardResources.kt` com mapeamento de imagens por tipo de prêmio
- Imagens: `small_progress_award.png` e ícones diferenciados por tipo
- Navegação: `MenuActivity.onButtonAwardClick`

### Tela de Recomendações (novo)

- `RecommendationActivity` + `RecommendationViewModel` + `RecommendationAdapter`
- `IRecommendationRepository` (domínio) + `RecommendationRepositoryImpl` (dados)
- `RecommendationResources.kt` com mapeamento das 45 imagens
- 45 imagens de recomendações (`rec_01.png` a `rec_45.png`)
- Navegação: `MenuActivity.onButtonChildBookClick`

### i18n Android (HU-016 — DONE)

- `values/strings.xml` (base ES), `values-en/strings.xml`, `values-pt/strings.xml`
- Cobertura de strings em todas as activities principais

### UI/UX melhorias

- Resposta a perguntas atualizada para escala 1–6 (Likert completo)
- `WelcomeMessagesActivity` com mensagens de boas-vindas melhoradas
- Novos estilos: `card_holo_purple.xml`, `card_purple.xml`, `tab_background_selector.xml`
- `CriAppDropdown` + `CriAppSpinnerAdapter` para dropdowns customizados
- `DialogBuilder` + `DialogFactory` para diálogos padronizados e reutilizáveis
- `TextViewExtensions` + `ViewFactory` helpers
- Correção de parsing de datas em `DateHelper`
- Correção de fechamento de activity após verificar que não há mais perguntas no dia

---

## Estado do backlog após estes 2 dias

| HU | Título | Status |
|----|--------|--------|
| HU-008 | Sistema de premios por progreso | ✅ DONE |
| HU-009 | Notificaciones útiles | ✅ DONE (10 may) |
| HU-010 | Desativação de conta end-to-end | 🔄 Em progresso (Android pendente) |
| HU-016 | Soporte multilingüe (i18n) | ✅ DONE (HU nova criada) |

## Observação sobre o plano

- A Semana 5 previa HU-013 (deploy cloud) + HU-006 (testes backend).
- Foram adiantadas HU-008, HU-009 (parcial), HU-010 (backend) e HU-016.
- HU-013 e HU-006 ficam para re-priorizar na semana 6.
