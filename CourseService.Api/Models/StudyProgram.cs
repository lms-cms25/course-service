namespace CourseService.Api.Models;

public class StudyProgram
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    // Lista med kurser

    public List<Course> Courses { get; set; } = new();
}