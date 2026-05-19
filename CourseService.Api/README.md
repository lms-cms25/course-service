# Course Service API

Course Service is a part of the Shiko LMS platform built with ASP.NET Core Web API and Next.js.

The service handles course and study program management functionality in the LMS platform.

Courses are connected to Study Programs to simulate a real educational platform structure similar to Nackademin LMS architecture.

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

Study Programs:
- Create study programs
- Connect courses to study programs
- Organize courses inside educational programs

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
- Manage study program connections

Documentation:
- Swagger documentation
- Scalar API documentation

# LMS Architecture

The system follows a school/LMS structure:

Study Program
└── Courses
    └── Reviews

Example:
.NET Webbutvecklare
├── ASP.NET Core
├── ASP.NET Advanced
├── Databases
└── Affärsmannaskap

This architecture is inspired by Nackademin LMS structure instead of Udemy-style standalone courses.

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

Courses:

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

The database contains:
- Courses
- StudyPrograms

Courses are connected to StudyPrograms using foreign keys.

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
- Study program relationships

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

 