# TooliRent API

REST-API för ett verktygsuthyrningssystem i en makerspace-miljö. Medlemmar kan boka, hämta och återlämna verktyg. Administratörer hanterar verktyg, kategorier, användare och ser statistik.

## Teknikstack

- ASP.NET Core 8
- Entity Framework Core 8 (Code-First)
- SQL Server (Docker)
- JWT Bearer Authentication
- AutoMapper
- FluentValidation
- Swagger / OpenAPI

---

## Arkitektur

Projektet följer en **N-tier-arkitektur** med fyra lager:

```
SUT24_TooliRent_V2_API            → Controllers, Program.cs, AuthDtos
SUT24_TooliRent_V2_Application    → Services, Interfaces, DTOs, MappingProfile, Validering
SUT24_TooliRent_V2_Domain         → Entities, Enums, Repository-interfaces
SUT24_TooliRent_V2_Infrastructure → AppDbContext, AuthDbContext, Repositories, UnitOfWork, Migrations
```

### Designmönster

- **Repository pattern** — ett repository per entitet (Tool, Booking, BookingTool, ToolCategory, Member)
- **Unit of Work** — samlar alla repositories och ett gemensamt `SaveChangesAsync`
- **Service pattern** — all affärslogik i separata services som injiceras i controllers
- **DTO-separation** — entiteter exponeras aldrig direkt; AutoMapper mappar mellan entity och DTO

### Autentisering

Två separata DbContexts:
- `AppDbContext` — domändata (verktyg, bokningar, members m.m.)
- `AuthDbContext` — ASP.NET Identity + refresh tokens

JWT utfärdas vid inloggning. Roller: **Admin** och **Member**.

---

## Köra projektet lokalt

### Förutsättningar

- .NET 8 SDK
- Docker Desktop

### 1. Starta SQL Server i Docker

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyStrongPass123" \
  -p 1433:1433 --name toolirent-sql \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

### 2. Kör migrationer

Från mappen `SUT24_TooliRent_V2_API`:

```bash
dotnet ef database update --context AppDbContext --project ../SUT24_TooliRent_V2_Infrastructure
dotnet ef database update --context AuthDbContext --project ../SUT24_TooliRent_V2_Infrastructure
```

### 3. Starta API:et

```bash
dotnet run --project SUT24_TooliRent_V2_API
```

Swagger finns på: `http://localhost:{port}/swagger`

### Testanvändare (seed)

| Roll   | E-post                  | Lösenord   |
|--------|-------------------------|------------|
| Admin  | admin@example.com       | Admin123!  |
| Member | member1@example.com     | Member123! |
| Member | member2@example.com     | Member123! |

---

## API-endpoints

Endpoints markerade med **[Admin]** kräver Admin-rollen. Endpoints markerade med **[Auth]** kräver inloggning.

### Auth — `/api/auth`

| Metod | Endpoint         | Beskrivning                              | Åtkomst  |
|-------|------------------|------------------------------------------|----------|
| POST  | `/register`      | Registrera nytt konto (tilldelas Member) | Public   |
| POST  | `/login`         | Logga in, returnerar access- och refresh token | Public |
| POST  | `/refresh`       | Hämta nytt access token via refresh token | Public  |
| POST  | `/logout`        | Revokar refresh token                    | Public   |

**Login-svar:**
```json
{
  "accessToken": "eyJ...",
  "refreshToken": "a3f9c2d1..."
}
```

**Refresh/Logout-body:**
```json
{ "refreshToken": "a3f9c2d1..." }
```

---

### Verktyg — `/api/tools`

| Metod  | Endpoint                    | Beskrivning                        | Åtkomst |
|--------|-----------------------------|------------------------------------|---------|
| GET    | `/`                         | Lista alla verktyg                 | Public  |
| GET    | `/{id}`                     | Hämta verktyg per ID               | Public  |
| GET    | `/category/{categoryId}`    | Filtrera på kategori               | Public  |
| GET    | `/condition/{condition}`    | Filtrera på skick                  | Public  |
| GET    | `/available`                | Lista tillgängliga verktyg         | Public  |
| POST   | `/`                         | Skapa verktyg                      | [Admin] |
| PUT    | `/{id}`                     | Uppdatera verktyg                  | [Admin] |
| DELETE | `/{id}`                     | Ta bort verktyg                    | [Admin] |

---

### Verktygskategorier — `/api/toolcategory`

| Metod  | Endpoint  | Beskrivning             | Åtkomst |
|--------|-----------|-------------------------|---------|
| GET    | `/`       | Lista alla kategorier   | Public  |
| GET    | `/{id}`   | Hämta kategori per ID   | Public  |
| POST   | `/`       | Skapa kategori          | [Admin] |
| DELETE | `/{id}`   | Ta bort kategori        | [Admin] |

---

### Bokningar — `/api/booking`

| Metod  | Endpoint          | Beskrivning                          | Åtkomst |
|--------|-------------------|--------------------------------------|---------|
| GET    | `/`               | Lista alla bokningar                 | [Admin] |
| GET    | `/{id}`           | Hämta bokning per ID                 | [Admin] |
| GET    | `/user/{userId}`  | Lista bokningar för en användare     | [Auth]  |
| POST   | `/`               | Skapa bokning (ett eller flera verktyg) | [Auth] |
| PUT    | `/{id}`           | Uppdatera bokning                    | [Admin] |
| DELETE | `/{id}`           | Avboka                               | [Auth]  |

**Skapa bokning:**
```json
{
  "memberId": 1,
  "startDate": "2025-01-15T08:00:00",
  "endDate": "2025-01-20T17:00:00",
  "toolIds": [1, 2]
}
```

---

### Hämtning och återlämning — `/api/bookingtool`

| Metod | Endpoint                          | Beskrivning                        | Åtkomst |
|-------|-----------------------------------|------------------------------------|---------|
| POST  | `/{bookingId}/{toolId}/pickup`    | Markera verktyg som hämtat         | [Auth]  |
| PUT   | `/{bookingId}/{toolId}/return`    | Markera verktyg som återlämnat     | [Auth]  |

**Återlämning-body:**
```json
{ "returnStatus": "ReturnedOk" }
```
Möjliga värden: `ReturnedOk`, `ReturnedDamaged`

---

### Medlemshantering — `/api/member`

| Metod | Endpoint          | Beskrivning                         | Åtkomst |
|-------|-------------------|-------------------------------------|---------|
| GET   | `/`               | Lista alla members                  | [Admin] |
| PATCH | `/{id}/status`    | Aktivera eller inaktivera member    | [Admin] |

**Status-body:**
```json
{ "isActive": false }
```

---

### Statistik — `/api/stats`

| Metod | Endpoint | Beskrivning                              | Åtkomst |
|-------|----------|------------------------------------------|---------|
| GET   | `/`      | Statistik över bokningar, verktyg och members | [Admin] |

**Svar:**
```json
{
  "totalBookings": 10,
  "pendingBookings": 2,
  "reservedBookings": 3,
  "activeBookings": 2,
  "returnedBookings": 2,
  "cancelledBookings": 1,
  "overdueBookings": 0,
  "totalTools": 8,
  "availableTools": 5,
  "unavailableTools": 3,
  "totalMembers": 4,
  "activeMembers": 3,
  "inactiveMembers": 1
}
```

---

## Datamodeller

### Member
| Fält                  | Typ      |
|-----------------------|----------|
| Id                    | int      |
| PersonalNumber        | string   |
| Name                  | string   |
| Email                 | string   |
| PhoneNumber           | string   |
| Address               | string   |
| MembershipDate        | DateTime |
| MembershipValidUntil  | DateTime |
| IsActive              | bool     |

### Tool
| Fält                 | Typ           |
|----------------------|---------------|
| Id                   | int           |
| Name                 | string        |
| Description          | string        |
| IsAvailable          | bool          |
| DemandsCertification | bool          |
| Condition            | ToolCondition |
| ToolCategoryId       | int (FK)      |
| WorkshopId           | int (FK)      |

### Booking
| Fält        | Typ           |
|-------------|---------------|
| Id          | int           |
| MemberId    | int (FK)      |
| StartDate   | DateTime      |
| EndDate     | DateTime      |
| Status      | BookingStatus |
| IsOverdue   | bool (beräknad) |

### BookingStatus
`Pending` → `Reserved` → `Active` → `Returned` / `Cancelled`

### ReturnStatus
`NotFetched` → `Fetched` → `ReturnedOk` / `ReturnedDamaged`
