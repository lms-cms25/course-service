using System.ComponentModel.DataAnnotations;

namespace CourseService.Api.Dtos;

public class CourseRequestDto
{
    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Instructor is required")]
    public string Instructor { get; set; } = string.Empty;

    [Required(ErrorMessage = "Category is required")]
    public string Category { get; set; } = string.Empty;

    [Required(ErrorMessage = "Duration is required")]
    public string Duration { get; set; } = string.Empty;

    [Required(ErrorMessage = "Level is required")]
    public string Level { get; set; } = string.Empty;

    public string Image { get; set; } = string.Empty;

    public int StudyProgramId { get; set; }


    [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
    public double Rating { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
    public string Description { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "Students cannot be negative")]
    public int Students { get; set; }
}