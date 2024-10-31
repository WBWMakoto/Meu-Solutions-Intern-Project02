using MeU_EventManagementSystem_API.Data;
using MeU_EventManagementSystem_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class SponsorsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SponsorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Sponsors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sponsor>>> GetSponsors()
    {
        return await _context.Sponsors.ToListAsync();
    }

    // GET: api/Sponsors/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Sponsor>> GetSponsor(int id)
    {
        var sponsor = await _context.Sponsors.FindAsync(id);
        if (sponsor == null) return NotFound();
        return sponsor;
    }

    // POST: api/Sponsors
    [HttpPost]
    public async Task<ActionResult<Sponsor>> PostSponsor(Sponsor sponsor)
    {
        _context.Sponsors.Add(sponsor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetSponsor), new { id = sponsor.SponsorID }, sponsor);
    }

    // PUT: api/Sponsors/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutSponsor(int id, Sponsor sponsor)
    {
        if (id != sponsor.SponsorID) return BadRequest();
        _context.Entry(sponsor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SponsorExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Sponsors/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSponsor(int id)
    {
        var sponsor = await _context.Sponsors.FindAsync(id);
        if (sponsor == null) return NotFound();

        _context.Sponsors.Remove(sponsor);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool SponsorExists(int id)
    {
        return _context.Sponsors.Any(s => s.SponsorID == id);
    }
}
