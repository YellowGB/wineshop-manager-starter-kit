using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineshopManagerStarterKit.Data;
using WineshopManagerStarterKit.Models;

namespace WineshopManagerStarterKit.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class WinesController : ControllerBase
{
    private readonly AppDbContext _context;

    public WinesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/wines
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Wine>>> GetAll()
    {
        return await _context.Wines
            .Include(w => w.WineType)
            .ToListAsync();
    }

    // GET: api/wines/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Wine>> GetById(int id)
    {
        var wine = await _context.Wines
            .Include(w => w.WineType)
            .FirstOrDefaultAsync(w => w.Id == id);

        if (wine == null)
        {
            return NotFound();
        }

        return wine;
    }

    // GET: api/wines/5/tickets
    [HttpGet("{id}/tickets")]
    public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets(int id)
    {
        var wine = await _context.Wines.FindAsync(id);

        if (wine == null)
        {
            return NotFound();
        }

        var tickets = await _context.TicketWines
            .Where(tw => tw.WineId == id)
            .Include(tw => tw.Ticket)
                .ThenInclude(t => t!.Client)
            .Select(tw => tw.Ticket!)
            .Distinct()
            .ToListAsync();

        return tickets;
    }

    // GET: api/wines/5/orders
    [HttpGet("{id}/orders")]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int id)
    {
        var wine = await _context.Wines.FindAsync(id);

        if (wine == null)
        {
            return NotFound();
        }

        var orders = await _context.OrderWines
            .Where(ow => ow.WineId == id)
            .Include(ow => ow.Order)
                .ThenInclude(o => o!.Supplier)
            .Select(ow => ow.Order!)
            .Distinct()
            .ToListAsync();

        return orders;
    }

    // POST: api/wines
    [HttpPost]
    public async Task<ActionResult<Wine>> Create(Wine wine)
    {
        _context.Wines.Add(wine);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = wine.Id }, wine);
    }

    // PUT: api/wines/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Wine wine)
    {
        if (id != wine.Id)
        {
            return BadRequest();
        }

        var existing = await _context.Wines.FindAsync(id);

        if (existing == null)
        {
            return NotFound();
        }

        existing.Name = wine.Name;
        existing.WineTypeId = wine.WineTypeId;
        existing.Quantity = wine.Quantity;
        existing.AmountBeforeTax = wine.AmountBeforeTax;
        existing.TaxRate = wine.TaxRate;
        existing.Threshold = wine.Threshold;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/wines/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var wine = await _context.Wines.FindAsync(id);

        if (wine == null)
        {
            return NotFound();
        }

        _context.Wines.Remove(wine);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
