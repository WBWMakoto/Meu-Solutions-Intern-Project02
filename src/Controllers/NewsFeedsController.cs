using MeU_EventManagementSystem_API.Data;
using MeU_EventManagementSystem_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class NewsFeedsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public NewsFeedsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/NewsFeeds
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NewsFeed>>> GetNewsFeeds()
    {
        return await _context.NewsFeeds.Include(nf => nf.Event).ToListAsync();
    }

    // GET: api/NewsFeeds/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<NewsFeed>> GetNewsFeed(int id)
    {
        var newsFeed = await _context.NewsFeeds.Include(nf => nf.Event).FirstOrDefaultAsync(nf => nf.NewsID == id);
        if (newsFeed == null) return NotFound();
        return newsFeed;
    }

    // POST: api/NewsFeeds
    [HttpPost]
    public async Task<ActionResult<NewsFeed>> PostNewsFeed(NewsFeed newsFeed)
    {
        _context.NewsFeeds.Add(newsFeed);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetNewsFeed), new { id = newsFeed.NewsID }, newsFeed);
    }

    // PUT: api/NewsFeeds/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutNewsFeed(int id, NewsFeed newsFeed)
    {
        if (id != newsFeed.NewsID) return BadRequest();
        _context.Entry(newsFeed).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!NewsFeedExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/NewsFeeds/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNewsFeed(int id)
    {
        var newsFeed = await _context.NewsFeeds.FindAsync(id);
        if (newsFeed == null) return NotFound();

        _context.NewsFeeds.Remove(newsFeed);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool NewsFeedExists(int id)
    {
        return _context.NewsFeeds.Any(nf => nf.NewsID == id);
    }
}

