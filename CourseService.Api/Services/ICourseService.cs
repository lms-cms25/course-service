using CourseService.Api.Dtos;

namespace CourseService.Api.Services;

public interface ICourseService
{
    //Hämtar kurser med sökning och filtering
    Task<List<CourseResponseDto>> GetCoursesAsync(string? search, string? category);
}