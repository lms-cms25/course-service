using CourseService.Api.Data;
using CourseService.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CourseService.Api.Services;

public class CourseService : ICourseService
{
    private readonly CourseDbContext _context;

    public CourseService(CourseDbContext context)
    {
        _context = context;
    }

    public async Task<List<CourseResponseDto>> GetCoursesAsync(string? search, string? category)
    {
        // Börjar med alla kurser
        var query = _context.Courses.AsQueryable();

        // Filtrerar på söktext om den finns
        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(c =>
                c.Title.Contains(search) ||
                c.Description.Contains(search));
        }

        // Filtrerar på kategori om den finns
        if (!string.IsNullOrWhiteSpace(category))
        {
            query = query.Where(c => c.Category == category);
        }

        // Returnerar kurser som DTO
        return await query
            .Select(c => new CourseResponseDto
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
                Category = c.Category,
                Instructor = c.Instructor
            })
            .ToListAsync();
    }
}