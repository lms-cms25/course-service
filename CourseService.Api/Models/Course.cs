namespace CourseService.Api.Models;

public class Course
{
    public int Id { get; set; }

    // Kursens titel
    public string Title { get; set; } = string.Empty;

    // Kort beskrivning av kursen
    public string Description { get; set; } = string.Empty;

    // Kurskategori, till exempel Frontend eller Backend
    public string Category { get; set; } = string.Empty;

    // Namn på läraren
    public string Instructor { get; set; } = string.Empty;

    // Datum när kursen skapades
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}