using MeU_EventManagementSystem_API.Data;
using MeU_EventManagementSystem_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class EventSponsorsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EventSponsorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/EventSponsors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventSponsor>>> GetEventSponsors()
    {
        return await _context.EventSponsors.Include(es => es.Event).Include(es => es.Sponsor).ToListAsync();
    }

    // GET: api/EventSponsors/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<EventSponsor>> GetEventSponsor(int id)
    {
        var eventSponsor = await _context.EventSponsors.Include(es => es.Event).Include(es => es.Sponsor).FirstOrDefaultAsync(es => es.EventSponsorID == id);
        if (eventSponsor == null) return NotFound();
        return eventSponsor;
    }

    // POST: api/EventSponsors
    [HttpPost]
    public async Task<ActionResult<EventSponsor>> PostEventSponsor(EventSponsor eventSponsor)
    {
        _context.EventSponsors.Add(eventSponsor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEventSponsor), new { id = eventSponsor.EventSponsorID }, eventSponsor);
    }

    // PUT: api/EventSponsors/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEventSponsor(int id, EventSponsor eventSponsor)
    {
        if (id != eventSponsor.EventSponsorID) return BadRequest();
        _context.Entry(eventSponsor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EventSponsorExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/EventSponsors/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEventSponsor(int id)
    {
        var eventSponsor = await _context.EventSponsors.FindAsync(id);
        if (eventSponsor == null) return NotFound();

        _context.EventSponsors.Remove(eventSponsor);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool EventSponsorExists(int id)
    {
        return _context.EventSponsors.Any(es => es.EventSponsorID == id);
    }
}