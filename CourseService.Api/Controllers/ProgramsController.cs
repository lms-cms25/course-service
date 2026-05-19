using CourseService.Api.Data;
using CourseService.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseService.Api.Controllers;

[ApiController]
[Route("api/programs")]
public class ProgramsController : ControllerBase
{
    private readonly CourseDbContext _context;

    public ProgramsController(CourseDbContext context)
    {
        _context = context;
    }

    // Hämtar alla program
    [HttpGet]
    public async Task<IActionResult> GetPrograms()
    {
        var programs = await _context.StudyPrograms.ToListAsync();

        return Ok(programs);
    }

    // Hämtar program via id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProgramById(int id)
    {
        var program = await _context.StudyPrograms
            .FirstOrDefaultAsync(p => p.Id == id);

        if (program is null)
        {
            return NotFound(new
            {
                message = $"Program with id {id} was not found"
            });
        }

        return Ok(program);
    }

    // Skapar nytt program
    [HttpPost]
    public async Task<IActionResult> CreateProgram([FromBody] StudyProgram program)
    {
        _context.StudyPrograms.Add(program);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProgramById),
            new { id = program.Id }, program);
    }

    // Uppdaterar program
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProgram(
        int id,
        [FromBody] StudyProgram updatedProgram)
    {
        var program = await _context.StudyPrograms
            .FirstOrDefaultAsync(p => p.Id == id);

        if (program is null)
        {
            return NotFound(new
            {
                message = $"Program with id {id} was not found"
            });
        }

        // Uppdaterar programmets data
        program.Name = updatedProgram.Name;
        program.Description = updatedProgram.Description;

        await _context.SaveChangesAsync();

        return Ok(program);
    }

    // Tar bort program
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProgram(int id)
    {
        var program = await _context.StudyPrograms
            .FirstOrDefaultAsync(p => p.Id == id);

        if (program is null)
        {
            return NotFound(new
            {
                message = $"Program with id {id} was not found"
            });
        }

        _context.StudyPrograms.Remove(program);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}