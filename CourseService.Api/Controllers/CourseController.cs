using Microsoft.AspNetCore.Mvc;

namespace CourseService.Api.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    // Mock data för kurser
    private static readonly List<CourseDto> Courses =
    [
        new(1, "Machine Learning Basics", "Jennifer Anderson", "Graphic Design", "6 weeks", "Beginner", "/images/course1.jpg", 5),
        new(2, "Business Analytics & Strategy", "Robert Chen", "UI/UX Design", "8 weeks", "Intermediate", "/images/course2.jpg", 5),
        new(3, "Content Marketing", "Emily Davis", "Brand Identity", "5 weeks", "Beginner", "/images/course3.jpg", 5),
        new(4, "Product Design for Beginner", "Michael Torres", "Web Design", "7 weeks", "Beginner", "/images/course4.jpg", 5),
        new(5, "Backend Developer", "Sarah Williams", "Development", "10 weeks", "Intermediate", "/images/course5.jpg", 4),
        new(6, "Adobe XD for Designer", "David Martinez", "Design", "4 weeks", "Beginner", "/images/course6.jpg", 5)
    ];

    // Hämtar alla kurser med sökning, filtrering och pagination
    [HttpGet]
    public IActionResult GetAllCourses(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 3,
        [FromQuery] string? search = null,
        [FromQuery] string? category = null)
    {
        // Säkerställer att värden inte blir fel
        if (page < 1)
            page = 1;

        if (pageSize < 1)
            pageSize = 3;

        // Börjar med alla kurser
        var query = Courses.AsQueryable();

        // Filtrerar på söktext
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(c =>
                c.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                c.Instructor.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                c.Category.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        // Filtrerar på kategori
        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(c =>
                c.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        var filteredCourses = query.ToList();

        var totalCount = filteredCourses.Count;

        // Pagination logik
        var items = filteredCourses
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return Ok(new
        {
            items,
            page,
            pageSize,
            totalCount,
            totalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
        });
    }
}

// DTO för kursdata som skickas till frontend
public record CourseDto(
    int Id,
    string Title,
    string Instructor,
    string Category,
    string Duration,
    string Level,
    string Image,
    double Rating
);