# Course Service

Course Service är en microservice för kursdelen i vårt LMS-projekt.

Servicen ansvarar för att hantera kurser i systemet.

## Funktioner

I denna service kan användaren:

- hämta alla kurser
- söka kurser
- filtrera kurser
- sortera kurser
- visa kursdetaljer
- skapa kurs
- uppdatera kurs
- ta bort kurs

## Admin funktioner

Admin kan:

- skapa nya kurser
- uppdatera befintliga kurser
- ta bort kurser

Endpoints för admin:


POST /api/courses
PUT /api/courses/{id}
DELETE /api/courses/{id}

## Tekniker

Projektet använder:

- ASP.NET Core Web API
- REST API
- JWT Bearer Authentication
- Role-based Authorization
- EF Core
- SQL Server
- Swagger
- Scalar/OpenAPI
- Docker
- Git branches

## API Endpoints

### Hämta alla kurser

GET /api/courses
Hämta kursdetaljer
GET /api/courses/{id}
Söka och filtrera kurser
GET /api/courses?search=backend&category=Development
Sortera kurser
GET /api/courses?sortBy=rating&sortOrder=desc
Pagination
GET /api/courses?page=1&pageSize=3
Skapa kurs
POST /api/courses
Uppdatera kurs
PUT /api/courses/{id}
Ta bort kurs
DELETE /api/courses/{id}
Authorization

Admin endpoints skyddas med:

[Authorize(Roles = "Admin")]

Om användaren inte har token returnerar API:

401 Unauthorized
Validation

Validation finns i CourseRequestDto.

Exempel:

Title krävs
Description krävs
Category krävs
Duration krävs
Level krävs
Rating måste vara mellan 0 och 5
Pagination

API returnerar:

items
page
pageSize
totalCount
totalPages
Sorting

API stödjer sortering med:

title
category
rating
students
duration
level

Exempel:

GET /api/courses?sortBy=title&sortOrder=asc
Swagger och Scalar

Swagger används på:

/swagger

Scalar används på:

/scalar
Docker

Projektet innehåller en Dockerfile för containerisering.

Branches
feature/course-service-setup

Grundstruktur för Course Service.

feature/search-filter-courses

Sökning och filtrering av kurser.

feature/course-details-endpoint

Endpoint för kursdetaljer.

feature/admin-course-management

Admin CRUD endpoints.

feature/protect-admin-endpoints

JWT authorization för admin endpoints.

feature/course-validation

Validation för kursdata.

feature/course-sorting

Sortering av kurser.
