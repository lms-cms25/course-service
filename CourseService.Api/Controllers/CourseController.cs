using Microsoft.AspNetCore.Mvc;

namespace CourseService.Api.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    // Mock data för kurser
    private static readonly List<CourseDto> Courses =
    [
        new(1, "Machine Learning Basics", "Jennifer Anderson", "Graphic Design", "6 weeks", "Beginner"),
        new(2, "Business Analytics & Strategy", "Robert Chen", "UI/UX Design", "8 weeks", "Intermediate"),
        new(3, "Content Marketing", "Emily Davis", "Brand Identity", "5 weeks", "Beginner"),
        new(4, "Product Design for Beginner", "Michael Torres", "Web Design", "7 weeks", "Beginner"),
        new(5, "Backend Developer", "Sarah Williams", "Development", "10 weeks", "Intermediate"),
        new(6, "Adobe XD for Designer", "David Martinez", "Design", "4 weeks", "Beginner")
    ];

    // Hämtar alla kurser med pagination
    [HttpGet]
    public IActionResult GetAllCourses([FromQuery] int page = 1, [FromQuery] int pageSize = 3)
    {
        // Säkerställer att page och pageSize inte blir fel
        if (page < 1)
        {
            page = 1;
        }

        if (pageSize < 1)
        {
            pageSize = 3;
        }

        var totalCount = Courses.Count;

        var items = Courses
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var result = new
        {
            items,
            page,
            pageSize,
            totalCount,
            totalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
        };

        return Ok(result);
    }
}

// DTO för kursdata som skickas till frontend
public record CourseDto(
    int Id,
    string Title,
    string Instructor,
    string Category,
    string Duration,
    string Level
);