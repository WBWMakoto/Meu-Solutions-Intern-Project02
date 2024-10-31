using MeU_EventManagementSystem_API.Data;
using MeU_EventManagementSystem_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EventsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Events
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
        return await _context.Events.Include(e => e.EventSponsors).ToListAsync();
    }

    // GET: api/Events/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        var eventItem = await _context.Events
            .Include(e => e.EventSponsors)
            .FirstOrDefaultAsync(e => e.EventID == id);

        if (eventItem == null) return NotFound();
        return eventItem;
    }

    // POST: api/Events
    [HttpPost]
    public async Task<ActionResult<Event>> PostEvent(Event eventItem)
    {
        _context.Events.Add(eventItem);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEvent), new { id = eventItem.EventID }, eventItem);
    }

    // PUT: api/Events/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEvent(int id, Event eventItem)
    {
        if (id != eventItem.EventID) return BadRequest();
        _context.Entry(eventItem).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EventExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Events/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var eventItem = await _context.Events.FindAsync(id);
        if (eventItem == null) return NotFound();

        _context.Events.Remove(eventItem);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool EventExists(int id)
    {
        return _context.Events.Any(e => e.EventID == id);
    }
}