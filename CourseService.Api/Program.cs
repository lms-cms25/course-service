using CourseService.Api.Data;
using CourseService.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using CourseService.Api.Data.Seed;

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

Console.WriteLine("APP STARTING...");

var app = builder.Build();

// Kör migrations automatiskt när appen startar
try
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<CourseDbContext>();
  
  db.Database.Migrate();
  CourseSeeder.SeedCourses(db);
}
 
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
    throw;
}

   
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


app.Run();

public partial class Program
{
} 