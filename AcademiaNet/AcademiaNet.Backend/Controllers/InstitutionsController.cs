using AcademiaNet.Backend.Data;
using AcademiaNet.Shared.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fantasy.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstitutionsController : ControllerBase
{
    private readonly DataContext _context;

    public InstitutionsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _context.Institutions.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var institution = await _context.Institutions.FirstOrDefaultAsync(c => c.InstitutionID == id);
        if (institution == null)
        {
            return NotFound();
        }
        return Ok(institution);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Institution institution)
    {
        _context.Add(institution);
        await _context.SaveChangesAsync();
        return Ok(institution);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var institution = await _context.Institutions.FirstOrDefaultAsync(c => c.InstitutionID == id);
        if (institution == null)
        {
            return NotFound();
        }

        _context.Remove(institution);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Institution institution)
    {
        _context.Update(institution);
        await _context.SaveChangesAsync();
        return Ok(institution);
    }
}