using Microsoft.AspNetCore.Mvc;
using CourseService.Api.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace CourseService.Api.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    // Mock data för kurser
    private static readonly List<CourseDto> Courses =
    [
        new(1, "Machine Learning Basics", "Jennifer Anderson", "Graphic Design", "6 weeks", "Beginner", "/images/course1.jpg", 5, "Learn machine learning basics", 120),
        new(2, "Business Analytics & Strategy", "Robert Chen", "UI/UX Design", "8 weeks", "Intermediate", "/images/course2.jpg", 5, "Business analytics course", 95),
        new(3, "Content Marketing", "Emily Davis", "Brand Identity", "5 weeks", "Beginner", "/images/course3.jpg", 5, "Marketing fundamentals", 70),
        new(4, "Product Design for Beginner", "Michael Torres", "Web Design", "7 weeks", "Beginner", "/images/course4.jpg", 5, "Product design basics", 110),
        new(5, "Backend Developer", "Sarah Williams", "Development", "10 weeks", "Intermediate", "/images/course5.jpg", 4, "Backend development course", 150),
        new(6, "Adobe XD for Designer", "David Martinez", "Design", "4 weeks", "Beginner", "/images/course6.jpg", 5, "Adobe XD design course", 60)
    ];

    // Hämtar alla kurser med sökning, filtrering och pagination
    
    [HttpGet]
    public IActionResult GetAllCourses(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 3,
        [FromQuery] string? search = null,
        [FromQuery] string? category = null)
    {
        if (page < 1)
            page = 1;

        if (pageSize < 1)
            pageSize = 3;

        var query = Courses.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(c =>
                c.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                c.Instructor.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                c.Category.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(c =>
                c.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
        }

        var filteredCourses = query.ToList();

        var totalCount = filteredCourses.Count;

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

    // Hämtar en specifik kurs via id
   
    [HttpGet("{id}")]
    public IActionResult GetCourseById(int id)
    {
        var course = Courses.FirstOrDefault(c => c.Id == id);

        if (course is null)
        {
            return NotFound(new
            {
                message = $"Course with id {id} was not found"
            });
        }

        return Ok(course);
    }

    // Skapar en ny kurs
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public IActionResult CreateCourse([FromBody] CourseRequestDto request)
    {
        if (string.IsNullOrWhiteSpace(request.Title) ||
            string.IsNullOrWhiteSpace(request.Description) ||
            string.IsNullOrWhiteSpace(request.Category))
        {
            return BadRequest(new
            {
                message = "Title, description and category are required"
            });
        }

        var newId = Courses.Max(c => c.Id) + 1;

        var course = new CourseDto(
            newId,
            request.Title,
            request.Instructor,
            request.Category,
            request.Duration,
            request.Level,
            request.Image,
            request.Rating,
            request.Description,
            request.Students
        );

        Courses.Add(course);

        return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
    }

    // Uppdaterar en kurs
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public IActionResult UpdateCourse(int id, [FromBody] CourseRequestDto request)
    {
        var existingCourse = Courses.FirstOrDefault(c => c.Id == id);

        if (existingCourse is null)
        {
            return NotFound(new
            {
                message = $"Course with id {id} was not found"
            });
        }

        var updatedCourse = new CourseDto(
            id,
            request.Title,
            request.Instructor,
            request.Category,
            request.Duration,
            request.Level,
            request.Image,
            request.Rating,
            request.Description,
            request.Students
        );

        var index = Courses.FindIndex(c => c.Id == id);
        Courses[index] = updatedCourse;

        return Ok(updatedCourse);
    }

    // Tar bort en kurs
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public IActionResult DeleteCourse(int id)
    {
        var course = Courses.FirstOrDefault(c => c.Id == id);

        if (course is null)
        {
            return NotFound(new
            {
                message = $"Course with id {id} was not found"
            });
        }

        Courses.Remove(course);

        return NoContent();
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
    double Rating,
    string Description,
    int Students
);