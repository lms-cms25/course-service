using CourseService.Api.Data;
using CourseService.Api.Models;
using CourseService.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CourseDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Tillåter frontend att anropa backend lokalt
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Lägger till controllers för REST API
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Lägger till CourseService i DI-container
builder.Services.AddScoped<ICourseService, CourseService.Api.Services.CourseService>();

// Kopplar EF Core till SQL Server
builder.Services.AddDbContext<CourseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Lägger till JWT Bearer authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Här kommer IdentityService URL senare
        options.Authority = builder.Configuration["Jwt:Authority"];

        // Tillåter lokal utveckling utan HTTPS metadata
        options.RequireHttpsMetadata = false;

        // Kontrollerar token audience
        options.Audience = builder.Configuration["Jwt:Audience"];
    });

builder.Services.AddAuthorization();

// Lägger till OpenAPI/Scalar dokumentation
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    // Scalar
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options.Title = "Course Service API";
    });

    // Start page
    app.MapGet("/", () => Results.Redirect("/scalar"));
}

app.UseHttpsRedirection();

// Använder CORS-regeln för frontend
app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CourseDbContext>();

    db.Database.EnsureCreated();

    if (!db.Courses.Any())
    {
        db.Courses.AddRange(
            new Course
            {
                Title = "Backend Developer",
                Instructor = "Sarah Williams",
                Category = "Development",
                Duration = "10 weeks",
                Level = "Intermediate",
                Image = "/images/course1.jpg",
                Rating = 5,
                Description = "Backend development course",
                Students = 150
            },

            new Course
            {
                Title = "Machine Learning Basics",
                Instructor = "Jennifer Anderson",
                Category = "AI",
                Duration = "6 weeks",
                Level = "Beginner",
                Image = "/images/course2.jpg",
                Rating = 4.5,
                Description = "Learn machine learning basics",
                Students = 120
            },

            new Course
            {
                Title = "Frontend Development",
                Instructor = "Emily Davis",
                Category = "Frontend",
                Duration = "8 weeks",
                Level = "Beginner",
                Image = "/images/course3.jpg",
                Rating = 4,
                Description = "Frontend fundamentals",
                Students = 90
            }
        );

        db.SaveChanges();
    }
}

app.Run();