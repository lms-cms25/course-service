namespace CourseService.Api.Dtos;

public class CreateCourseDto
{
    // Titel som användaren skickar in
    public string Title { get; set; } = string.Empty;

    // Beskrivning av kursen
    public string Description { get; set; } = string.Empty;

    // Kategori för kursen
    public string Category { get; set; } = string.Empty;

    // Lärare för kursen
    public string Instructor { get; set; } = string.Empty;
}