using MeU_EventManagementSystem_API.Data;
using MeU_EventManagementSystem_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AdminsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AdminsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Admins
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
    {
        return await _context.Admins.ToListAsync();
    }

    // GET: api/Admins/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Admin>> GetAdmin(int id)
    {
        var admin = await _context.Admins.FindAsync(id);
        if (admin == null) return NotFound();
        return admin;
    }

    // POST: api/Admins
    [HttpPost]
    public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
    {
        _context.Admins.Add(admin);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAdmin), new { id = admin.AdminID }, admin);
    }

    // PUT: api/Admins/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAdmin(int id, Admin admin)
    {
        if (id != admin.AdminID) return BadRequest();
        _context.Entry(admin).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AdminExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/Admins/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdmin(int id)
    {
        var admin = await _context.Admins.FindAsync(id);
        if (admin == null) return NotFound();

        _context.Admins.Remove(admin);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool AdminExists(int id)
    {
        return _context.Admins.Any(e => e.AdminID == id);
    }
}
