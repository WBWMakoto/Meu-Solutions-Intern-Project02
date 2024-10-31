using MeU_EventManagementSystem_API.Data;
using MeU_EventManagementSystem_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class QRCheckInsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public QRCheckInsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/QRCheckIns
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QRCheckIn>>> GetQRCheckIns()
    {
        return await _context.QRCheckIns.Include(q => q.Event).Include(q => q.Participant).ToListAsync();
    }

    // GET: api/QRCheckIns/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<QRCheckIn>> GetQRCheckIn(int id)
    {
        var qrCheckIn = await _context.QRCheckIns.Include(q => q.Event).Include(q => q.Participant).FirstOrDefaultAsync(q => q.CheckInID == id);
        if (qrCheckIn == null) return NotFound();
        return qrCheckIn;
    }

    // POST: api/QRCheckIns
    [HttpPost]
    public async Task<ActionResult<QRCheckIn>> PostQRCheckIn(QRCheckIn qrCheckIn)
    {
        _context.QRCheckIns.Add(qrCheckIn);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetQRCheckIn), new { id = qrCheckIn.CheckInID }, qrCheckIn);
    }

    // PUT: api/QRCheckIns/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutQRCheckIn(int id, QRCheckIn qrCheckIn)
    {
        if (id != qrCheckIn.CheckInID) return BadRequest();
        _context.Entry(qrCheckIn).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!QRCheckInExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/QRCheckIns/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQRCheckIn(int id)
    {
        var qrCheckIn = await _context.QRCheckIns.FindAsync(id);
        if (qrCheckIn == null) return NotFound();

        _context.QRCheckIns.Remove(qrCheckIn);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool QRCheckInExists(int id)
    {
        return _context.QRCheckIns.Any(q => q.CheckInID == id);
    }
}
