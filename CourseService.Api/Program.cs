using CourseService.Api.Data;
using CourseService.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

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

app.Run();