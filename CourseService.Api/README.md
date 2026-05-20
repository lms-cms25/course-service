# Course Service API

Course Service is a microservice for the Shiko LMS platform built with ASP.NET Core Web API.

The service manages:
- Courses
- Study Programs
- Course administration
- Authentication-protected endpoints

The project follows a microservice-oriented architecture and uses Entity Framework Core with SQL Server and Azure deployment.

---

# Technologies

## Backend
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Scalar API Documentation
- JWT Authentication
- REST API
- Azure App Service

## Frontend
- Next.js
- TypeScript
- CSS Modules

## Other Tools
- GitHub
- Azure SQL Database
- Entity Framework Migrations

---

# Features

## Courses
- Get all courses
- Get course by id
- Create course
- Update course
- Delete course

## Study Programs
- Get all study programs
- Get study program by id
- Create study program
- Update study program
- Delete study program

## Security
- JWT Authentication
- Authorization support
- Protected admin endpoints

## Documentation
- Swagger UI
- Scalar API Documentation

---

# LMS Architecture

The service follows a school/LMS architecture inspired by educational platforms like Nackademin LMS.

Example structure:

Study Program
└── Courses

Example:

.NET Webbutvecklare
├── ASP.NET Core
├── ASP.NET Advanced
├── Databases
└── Affärsmannaskap

The architecture supports organizing courses into educational programs instead of standalone marketplace courses.

---

# Project Structure

## Backend

CourseService.Api

### Folders
- Controllers
- Data
- Dtos
- Models
- Services
- Migrations
- docs

---

# API Endpoints

## Courses

### Get all courses
GET /api/courses

### Get course by id
GET /api/courses/{id}

### Create course
POST /api/courses

### Update course
PUT /api/courses/{id}

### Delete course
DELETE /api/courses/{id}

---

## Study Programs

### Get all programs
GET /api/programs

### Get program by id
GET /api/programs/{id}

### Create program
POST /api/programs

### Update program
PUT /api/programs/{id}

### Delete program
DELETE /api/programs/{id}

---

# Swagger Documentation

## Local Swagger
https://localhost:7102/swagger

## Azure Swagger
https://course-service-api-vita-fzagd0b4g7a8geap.swedencentral-01.azurewebsites.net/swagger

---

# Local Setup

## Install dependencies

```bash
dotnet restore