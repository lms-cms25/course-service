using CourseService.Api.Data;
using CourseService.Api.Dtos;
using CourseService.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseService.Api.Controllers;

[ApiController]
[Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly CourseDbContext _context;

    public CourseController(CourseDbContext context)
    {
        _context = context;
    }

    // Hämtar alla kurser
    [HttpGet]
    public async Task<IActionResult> GetAllCourses(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 3,
        [FromQuery] string? search = null,
        [FromQuery] string? category = null,
        [FromQuery] string? sortBy = null,
        [FromQuery] string? sortOrder = "asc")
    {
        if (page < 1)
            page = 1;

        if (pageSize < 1)
            pageSize = 3;

        // Börjar med alla kurser från databasen och tar med programmet
        var query = _context.Courses
            .Include(c => c.StudyProgram)
            .AsQueryable();

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(c => new CourseDto(
                c.Id,
                c.Title,
                c.Instructor,
                c.Category,
                c.Duration,
                c.Level,
                c.Image,
                c.Rating,
                c.Description,
                c.Students,
                c.StudyProgramId,
                c.StudyProgram != null ? c.StudyProgram.Name : ""
            ))
            .ToListAsync();

        return Ok(new
        {
            items,
            page,
            pageSize,
            totalCount,
            totalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
        });
    }

    // Hämtar en kurs med id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById(int id)
    {
        var course = await _context.Courses
            .Include(c => c.StudyProgram)
            .Where(c => c.Id == id)
            .Select(c => new CourseDto(
                c.Id,
                c.Title,
                c.Instructor,
                c.Category,
                c.Duration,
                c.Level,
                c.Image,
                c.Rating,
                c.Description,
                c.Students,
                c.StudyProgramId,
                c.StudyProgram != null ? c.StudyProgram.Name : ""
            ))
            .FirstOrDefaultAsync();

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
    public async Task<IActionResult> CreateCourse([FromBody] CourseRequestDto request)
    {
        var course = new Course
        {
            Title = request.Title,
            Instructor = request.Instructor,
            Category = request.Category,
            Duration = request.Duration,
            Level = request.Level,
            Image = request.Image,
            Rating = request.Rating,
            Description = request.Description,
            Students = request.Students,

            // Kopplar kursen till ett program
            StudyProgramId = request.StudyProgramId,

            CreatedAt = DateTime.UtcNow
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        // Hämtar programnamnet efter att kursen har sparats
        var program = await _context.StudyPrograms
            .FirstOrDefaultAsync(p => p.Id == course.StudyProgramId);

        var response = new CourseDto(
            course.Id,
            course.Title,
            course.Instructor,
            course.Category,
            course.Duration,
            course.Level,
            course.Image,
            course.Rating,
            course.Description,
            course.Students,
            course.StudyProgramId,
            program?.Name ?? ""
        );

        return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, response);
    }

    // Uppdaterar en kurs
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseRequestDto request)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);

        if (course is null)
        {
            return NotFound(new
            {
                message = $"Course with id {id} was not found"
            });
        }

        course.Title = request.Title;
        course.Instructor = request.Instructor;
        course.Category = request.Category;
        course.Duration = request.Duration;
        course.Level = request.Level;
        course.Image = request.Image;
        course.Rating = request.Rating;
        course.Description = request.Description;
        course.Students = request.Students;

        // Uppdaterar vilket program kursen tillhör
        course.StudyProgramId = request.StudyProgramId;

        await _context.SaveChangesAsync();

        // Hämtar programnamnet efter uppdatering
        var program = await _context.StudyPrograms
            .FirstOrDefaultAsync(p => p.Id == course.StudyProgramId);

        var response = new CourseDto(
            course.Id,
            course.Title,
            course.Instructor,
            course.Category,
            course.Duration,
            course.Level,
            course.Image,
            course.Rating,
            course.Description,
            course.Students,
            course.StudyProgramId,
            program?.Name ?? ""
        );

        return Ok(response);
    }

    // Tar bort en kurs
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);

        if (course is null)
        {
            return NotFound(new
            {
                message = $"Course with id {id} was not found"
            });
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

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
    int Students,
    int StudyProgramId,
    string StudyProgramName
);