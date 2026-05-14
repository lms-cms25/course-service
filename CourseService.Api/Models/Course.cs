namespace CourseService.Api.Models;

public class Course
{
    public int Id { get; set; }

    // Kursens titel
    public string Title { get; set; } = string.Empty;

    // Namn på läraren
    public string Instructor { get; set; } = string.Empty;

    // Kurskategori
    public string Category { get; set; } = string.Empty;

    // Kursens längd
    public string Duration { get; set; } = string.Empty;

    // Kursens nivå
    public string Level { get; set; } = string.Empty;

    // Bild till kursen
    public string Image { get; set; } = string.Empty;

    // Kursens betyg
    public double Rating { get; set; }

    // Kort beskrivning av kursen
    public string Description { get; set; } = string.Empty;

    // Antal studenter
    public int Students { get; set; }

    // Datum när kursen skapades
    public DateTime CreatedAt { get; set; }
}