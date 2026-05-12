using CourseService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseService.Api.Data;

public class CourseDbContext : DbContext
{
    public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
    {
    }

    // Tabellen Courses i databasen
    public DbSet<Course> Courses => Set<Course>();
}