# Course Service API

Course Service is a part of the Shiko LMS platform built with ASP.NET Core Web API and Next.js.

The service handles course management functionality including getting all courses, getting courses by id, creating courses, updating courses and deleting courses.

The project uses Entity Framework Core with SQL Server and follows a microservice-based architecture.

# Technologies

Backend:
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Scalar
- JWT Authentication

Frontend:
- Next.js
- TypeScript
- CSS Modules

Other:
- GitHub
- Azure App Service
- Azure SQL Database

# Features

Course API:
- GET all courses
- GET course by id
- POST create course
- PUT update course
- DELETE course

Admin Panel:
- Create courses
- Edit courses
- Delete courses

Documentation:
- Swagger documentation
- Scalar API documentation

# Project Structure

Backend:
CourseService.Api

Folders:
- Controllers
- Data
- Dtos
- Models
- Services
- Migrations

Frontend:
- src/app/courses
- src/app/courses/admin

# Frontend Routes

Courses:
http://localhost:3000/courses

Admin Courses:
http://localhost:3000/courses/admin


# API Endpoints

Get all courses:
GET /api/courses

Get course by id:
GET /api/courses/{id}

Create course:
POST /api/courses

Update course:
PUT /api/courses/{id}

Delete course:
DELETE /api/courses/{id}

# Swagger

Swagger documentation:
https://localhost:7102/swagger

# Local Setup

Backend:

Install packages:

dotnet restore

Run migrations:

dotnet ef database update

Run API:

dotnet run

Frontend:

Install packages:

npm install

Run frontend:

npm run dev

# Database

The project uses SQL Server with Entity Framework Core migrations.

Seed data is automatically added when the application starts.

# Security

The API supports:
- JWT Authentication
- Authorization
- Protected admin functionality

# Testing

The project includes testing for:
- API functionality
- CRUD operations
- Course service logic

# Deployment

Frontend:
Deployed with Vercel.

Backend:
Deployed with Azure App Service.

Database:
Azure SQL Database.

# Authors

CMS25 .NET2 – Nackademin  
Shiko LMS Project

## System Architecture Diagram

![Course Service System Architecture](docs/course-service-system-architecture.png)

## Sequence Diagrams

### Get Courses Flow

```mermaid
sequenceDiagram
    participant User
    participant Frontend as Next.js Frontend
    participant API as Course Service API
    participant DB as SQL Server

    User->>Frontend: Opens Courses page
    Frontend->>API: GET /api/courses?page=1&pageSize=3
    API->>DB: Reads courses with EF Core
    DB-->>API: Returns courses
    API-->>Frontend: Returns JSON response
    Frontend-->>User: Shows course cards
```

### Admin Create Course Flow

```mermaid
sequenceDiagram
    participant Admin
    participant Frontend as Admin Frontend
    participant API as Course Service API
    participant Auth as JWT Authorization
    participant DB as SQL Server

    Admin->>Frontend: Fills in course form
    Frontend->>API: POST /api/courses with JWT token
    API->>Auth: Validates Admin role
    Auth-->>API: Authorized
    API->>DB: Saves new course with EF Core
    DB-->>API: Course saved
    API-->>Frontend: Returns created course
    Frontend-->>Admin: Shows updated course list
```

### Delete Course Flow

```mermaid
sequenceDiagram
    participant Admin
    participant Frontend as Admin Frontend
    participant API as Course Service API
    participant Auth as JWT Authorization
    participant DB as SQL Server

    Admin->>Frontend: Clicks Delete
    Frontend->>API: DELETE /api/courses/{id} with JWT token
    API->>Auth: Validates Admin role
    Auth-->>API: Authorized
    API->>DB: Deletes course
    DB-->>API: Course deleted
    API-->>Frontend: Returns 204 No Content
    Frontend-->>Admin: Removes course from list
```