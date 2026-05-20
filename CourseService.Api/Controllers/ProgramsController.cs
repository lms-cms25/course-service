using CourseService.Api.Data;
using CourseService.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CourseService.Api.Controllers;

#region DTOs

// DTO för att skapa program
public class CreateProgramDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;
}

// DTO för att uppdatera program
public class UpdateProgramDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;
}

// DTO för response
public class ProgramResponseDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}

#endregion

[ApiController]
[Route("api/[controller]")]
public class ProgramsController : ControllerBase
{
    private readonly CourseDbContext _context;

    public ProgramsController(CourseDbContext context)
    {
        _context = context;
    }

    // Hämtar alla program
    [HttpGet]
    {

        return Ok(programs);
    }

    [HttpGet("{id}")]
    {
        var program = await _context.StudyPrograms
            .FirstOrDefaultAsync(p => p.Id == id);

        {
            return NotFound(new
            {
                message = $"Program with id {id} was not found"
            });
        }

    }

    // Skapar nytt program
    [Authorize(Roles = "Admin")]
    [HttpPost]
    {
            Name = dto.Name,
            Description = dto.Description
        };

        _context.StudyPrograms.Add(program);

        await _context.SaveChangesAsync();

    }

    // Uppdaterar program
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    {
        var program = await _context.StudyPrograms
            .FirstOrDefaultAsync(p => p.Id == id);

        {
            return NotFound(new
            {
                message = $"Program with id {id} was not found"
            });
        }


        await _context.SaveChangesAsync();

    }

    // Tar bort program
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProgram(int id)
    {
        var program = await _context.StudyPrograms
            .FirstOrDefaultAsync(p => p.Id == id);

        {
            return NotFound(new
            {
                message = $"Program with id {id} was not found"
            });
        }

        _context.StudyPrograms.Remove(program);

        await _context.SaveChangesAsync();

    }
}