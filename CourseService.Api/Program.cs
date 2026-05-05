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

builder.Services.AddControllers();

// (Swagger UI)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Använder CORS-regeln för frontend
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();