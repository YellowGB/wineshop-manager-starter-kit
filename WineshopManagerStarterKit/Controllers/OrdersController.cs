using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineshopManagerStarterKit.Data;
using WineshopManagerStarterKit.Models;

namespace WineshopManagerStarterKit.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/orders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetAll()
    {
        return await _context.Orders
            .Include(o => o.Supplier)
            .Include(o => o.OrderWines)
                .ThenInclude(ow => ow.Wine)
            .ToListAsync();
    }

    // GET: api/orders/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetById(int id)
    {
        var order = await _context.Orders
            .Include(o => o.Supplier)
            .Include(o => o.OrderWines)
                .ThenInclude(ow => ow.Wine)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    // POST: api/orders
    [HttpPost]
    public async Task<ActionResult<Order>> Create(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
    }

    // PUT: api/orders/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Order order)
    {
        if (id != order.Id)
        {
            return BadRequest();
        }

        var existing = await _context.Orders.FindAsync(id);

        if (existing == null)
        {
            return NotFound();
        }

        existing.SupplierId = order.SupplierId;
        existing.OrderDate = order.OrderDate;
        existing.DeliveryDate = order.DeliveryDate;
        existing.Street = order.Street;
        existing.PostCode = order.PostCode;
        existing.City = order.City;
        existing.Validated = order.Validated;
        existing.Delivered = order.Delivered;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/orders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
