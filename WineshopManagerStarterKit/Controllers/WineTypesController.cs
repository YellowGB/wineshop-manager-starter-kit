using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineshopManagerStarterKit.Data;
using WineshopManagerStarterKit.Models;

namespace WineshopManagerStarterKit.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WineTypesController : ControllerBase
{
    private readonly AppDbContext _context;

    public WineTypesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/winetypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WineType>>> GetAll()
    {
        return await _context.WineTypes.ToListAsync();
    }

    // GET: api/winetypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<WineType>> GetById(int id)
    {
        var wineType = await _context.WineTypes.FindAsync(id);

        if (wineType == null)
        {
            return NotFound();
        }

        return wineType;
    }

    // POST: api/winetypes
    [HttpPost]
    public async Task<ActionResult<WineType>> Create(WineType wineType)
    {
        if (await _context.WineTypes.AnyAsync(wt => wt.Name == wineType.Name))
        {
            return Conflict($"A wine type with the name '{wineType.Name}' already exists.");
        }

        _context.WineTypes.Add(wineType);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = wineType.Id }, wineType);
    }

    // PUT: api/winetypes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, WineType wineType)
    {
        if (id != wineType.Id)
        {
            return BadRequest();
        }

        var existing = await _context.WineTypes.FindAsync(id);

        if (existing == null)
        {
            return NotFound();
        }

        existing.Name = wineType.Name;

        if (await _context.WineTypes.AnyAsync(wt => wt.Name == wineType.Name && wt.Id != id))
        {
            return Conflict($"A wine type with the name '{wineType.Name}' already exists.");
        }

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/winetypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var wineType = await _context.WineTypes.FindAsync(id);

        if (wineType == null)
        {
            return NotFound();
        }

        _context.WineTypes.Remove(wineType);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
