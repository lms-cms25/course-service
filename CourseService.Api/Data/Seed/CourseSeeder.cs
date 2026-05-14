using CourseService.Api.Models;

namespace CourseService.Api.Data.Seed;

public static class CourseSeeder
{
    public static void SeedCourses(CourseDbContext db)
    {
        // Om det redan finns kurser ska vi inte lägga till samma kurser igen
        if (db.Courses.Any())
            return;

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
                Students = 150,
                CreatedAt = new DateTime(2026, 5, 12, 0, 0, 0, DateTimeKind.Utc)
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
                Students = 120,
                CreatedAt = new DateTime(2026, 5, 12, 0, 0, 0, DateTimeKind.Utc)
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
                Students = 90,
                CreatedAt = new DateTime(2026, 5, 12, 0, 0, 0, DateTimeKind.Utc)
            },
            new Course
            {
                Title = "UI/UX Design",
                Instructor = "Robert Chen",
                Category = "UI/UX Design",
                Duration = "7 weeks",
                Level = "Beginner",
                Image = "/images/course4.jpg",
                Rating = 4.7,
                Description = "Learn modern UI and UX design",
                Students = 80,
                CreatedAt = new DateTime(2026, 5, 12, 0, 0, 0, DateTimeKind.Utc)
            },
            new Course
            {
                Title = "Graphic Design Basics",
                Instructor = "David Martinez",
                Category = "Graphic Design",
                Duration = "5 weeks",
                Level = "Beginner",
                Image = "/images/course5.jpg",
                Rating = 4.3,
                Description = "Basic graphic design course",
                Students = 65,
                CreatedAt = new DateTime(2026, 5, 12, 0, 0, 0, DateTimeKind.Utc)
            },
            new Course
            {
                Title = "Advanced Web Development",
                Instructor = "Michael Torres",
                Category = "Development",
                Duration = "12 weeks",
                Level = "Advanced",
                Image = "/images/course6.jpg",
                Rating = 4.8,
                Description = "Advanced fullstack web development",
                Students = 110,
                CreatedAt = new DateTime(2026, 5, 12, 0, 0, 0, DateTimeKind.Utc)
            }
        );

        db.SaveChanges();
    }
}