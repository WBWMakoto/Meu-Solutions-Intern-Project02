using MeU_EventManagementSystem_API.Data;
using MeU_EventManagementSystem_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ParticipantsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ParticipantsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Participants
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Participant>>> GetParticipants()
    {
        return await _context.Participants.ToListAsync();
    }

    // GET: api/Participants/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Participant>> GetParticipant(int id)
    {
        var participant = await _context.Participants.FindAsync(id);
        if (participant == null) return NotFound();
        return participant;
    }

    // POST: api/Participants
    [HttpPost]
    public async Task<ActionResult<Participant>> PostParticipant(Participant participant)
    {
        _context.Participants.Add(participant);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetParticipant), new { id = participant.ParticipantID }, participant);
    }

    // PUT: api/Participants/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutParticipant(int id, Participant participant)
    {
        if (id != participant.ParticipantID) return BadRequest();
        _context.Entry(participant).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ParticipantExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Participants/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteParticipant(int id)
    {
        var participant = await _context.Participants.FindAsync(id);
        if (participant == null) return NotFound();

        _context.Participants.Remove(participant);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool ParticipantExists(int id)
    {
        return _context.Participants.Any(p => p.ParticipantID == id);
    }
}
