using CourseService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseService.Api.Data;

public class CourseDbContext : DbContext
{
    public CourseDbContext(DbContextOptions<CourseDbContext> options)
        : base(options)
    {
    }

    // Tabellen Courses i databasen
    public DbSet<Course> Courses => Set<Course>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data för kurser
        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id = 1,
                Title = "Machine Learning Basics",
                Instructor = "Jennifer Anderson",
                Category = "Graphic Design",
                Duration = "6 weeks",
                Level = "Beginner",
                Image = "/images/course1.jpg",
                Rating = 5,
                Description = "Learn machine learning basics",
                Students = 120
            },

            new Course
            {
                Id = 2,
                Title = "Business Analytics & Strategy",
                Instructor = "Robert Chen",
                Category = "UI/UX Design",
                Duration = "8 weeks",
                Level = "Intermediate",
                Image = "/images/course2.jpg",
                Rating = 5,
                Description = "Business analytics course",
                Students = 95
            },

            new Course
            {
                Id = 3,
                Title = "Content Marketing",
                Instructor = "Emily Davis",
                Category = "Brand Identity",
                Duration = "5 weeks",
                Level = "Beginner",
                Image = "/images/course3.jpg",
                Rating = 5,
                Description = "Marketing fundamentals",
                Students = 70
            },

            new Course
            {
                Id = 4,
                Title = "Product Design for Beginner",
                Instructor = "Michael Torres",
                Category = "Web Design",
                Duration = "7 weeks",
                Level = "Beginner",
                Image = "/images/course4.jpg",
                Rating = 5,
                Description = "Product design basics",
                Students = 110
            },

            new Course
            {
                Id = 5,
                Title = "Backend Developer",
                Instructor = "Sarah Williams",
                Category = "Development",
                Duration = "10 weeks",
                Level = "Intermediate",
                Image = "/images/course5.jpg",
                Rating = 4,
                Description = "Backend development course",
                Students = 150
            },

            new Course
            {
                Id = 6,
                Title = "Adobe XD for Designer",
                Instructor = "David Martinez",
                Category = "Design",
                Duration = "4 weeks",
                Level = "Beginner",
                Image = "/images/course6.jpg",
                Rating = 5,
                Description = "Adobe XD design course",
                Students = 60
            }
        );
    }
}