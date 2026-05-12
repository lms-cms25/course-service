namespace CourseService.Api.Dtos;

public class CourseResponseDto
{
    // Id från databasen
    public int Id { get; set; }

    // Kursens titel
    public string Title { get; set; } = string.Empty;

    // Kursens beskrivning
    public string Description { get; set; } = string.Empty;

    // Kursens kategori
    public string Category { get; set; } = string.Empty;

    // Kursens lärare
    public string Instructor { get; set; } = string.Empty;
}