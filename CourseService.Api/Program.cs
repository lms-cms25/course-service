using CourseService.Api.Data;
using CourseService.Api.Data.Seed;
using CourseService.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Kopplar EF Core till SQL Server
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

// Lägger till JWT Bearer authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Jwt:Authority"];
        options.RequireHttpsMetadata = false;
        options.Audience = builder.Configuration["Jwt:Audience"];
    });

builder.Services.AddAuthorization();

// Lägger till OpenAPI/Scalar dokumentation
builder.Services.AddOpenApi();

var app = builder.Build();


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


app.UseHttpsRedirection();

// Använder CORS-regeln för frontend
app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Skapar databasen och lägger till testkurser om tabellen är tom

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (!string.IsNullOrEmpty(connectionString))
{


    using (var scope = app.Services.CreateScope())

    {
        var db = scope.ServiceProvider.GetRequiredService<CourseDbContext>();

        //db.Database.Migrate();

        CourseSeeder.SeedCourses(db);
    }
}

app.Run();

public partial class Program
{
} 