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
    public async Task<ActionResult<IEnumerable<ProgramResponseDto>>> GetPrograms()
    {
        var programs = await _context.StudyPrograms
            .Select(p => new ProgramResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            })
            .ToListAsync();

        return Ok(programs);
    }

    // Hämtar program med id
    [HttpGet("{id}")]
    public async Task<ActionResult<ProgramResponseDto>> GetProgram(int id)
    {
        var program = await _context.StudyPrograms
            .FirstOrDefaultAsync(p => p.Id == id);

        if (program == null)
        {
            return NotFound(new
            {
                message = $"Program with id {id} was not found"
            });
        }

        var response = new ProgramResponseDto
        {
            Id = program.Id,
            Name = program.Name,
            Description = program.Description
        };

        return Ok(response);
    }

    // Skapar nytt program
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<ProgramResponseDto>> CreateProgram(CreateProgramDto dto)
    {
        var program = new StudyProgram
        {
            Name = dto.Name,
            Description = dto.Description
        };

        _context.StudyPrograms.Add(program);

        await _context.SaveChangesAsync();

        var response = new ProgramResponseDto
        {
            Id = program.Id,
            Name = program.Name,
            Description = program.Description
        };

        return CreatedAtAction(nameof(GetProgram), new { id = program.Id }, response);
    }

    // Uppdaterar program
    [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProgram(int id, UpdateProgramDto dto)
    {
        var program = await _context.StudyPrograms
            .FirstOrDefaultAsync(p => p.Id == id);

        if (program == null)
        {
            return NotFound(new
            {
                message = $"Program with id {id} was not found"
            });
        }

        program.Name = dto.Name;
        program.Description = dto.Description;

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Program updated successfully"
        });
    }

    // Tar bort program
    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProgram(int id)
    {
        var program = await _context.StudyPrograms
            .FirstOrDefaultAsync(p => p.Id == id);

        if (program == null)
        {
            return NotFound(new
            {
                message = $"Program with id {id} was not found"
            });
        }

        _context.StudyPrograms.Remove(program);

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Program deleted successfully"
        });
    }
}