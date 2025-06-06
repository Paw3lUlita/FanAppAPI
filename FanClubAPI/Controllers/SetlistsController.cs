using FanClubAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class SetlistsController : ControllerBase
{
    private readonly FanClubContext _context;
    public SetlistsController(FanClubContext context) => _context = context;

    // -------------------- 1) GET z filtrem ---------------------
    // /api/Setlists            -> cała tabela              (stare zachowanie)
    // /api/Setlists?concertId=3 -> tylko dany koncert, sort = SongOrder
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Setlists>>> GetSetlists(
        [FromQuery] int? concertId)
    {
        IQueryable<Setlists> q = _context.Setlists.AsNoTracking();

        if (concertId.HasValue)
            q = q.Where(s => s.ConcertId == concertId.Value)
                 .OrderBy(s => s.SongOrder);

        return await q.ToListAsync();
    }

    // -------------------- 2) GET /{id}  ------------------------
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Setlists>> GetSetlistsById(int id)
    {
        var item = await _context.Setlists.FindAsync(id);
        return item is null ? NotFound() : item;
    }

    // -------------------- 3) PUT -------------------------------
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutSetlists(int id, Setlists dto)
    {
        if (id != dto.Id) return BadRequest();

        _context.Entry(dto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // -------------------- 4) POST ------------------------------
    [HttpPost]
    public async Task<ActionResult<Setlists>> PostSetlists(Setlists dto)
    {
        // jeśli SongOrder nieprzesłany lub 0 → nadaj kolejny numer
        if (dto.SongOrder <= 0)
        {
            var max = await _context.Setlists
                         .Where(s => s.ConcertId == dto.ConcertId)
                         .MaxAsync(s => (int?)s.SongOrder) ?? 0;
            dto.SongOrder = max + 1;
        }

        _context.Setlists.Add(dto);
        await _context.SaveChangesAsync();

        // zwracamy obiekt Z NOWYM Id
        return CreatedAtAction(nameof(GetSetlistsById),
                               new { id = dto.Id }, dto);
    }

    // -------------------- 5) DELETE ----------------------------
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteSetlists(int id)
    {
        var item = await _context.Setlists.FindAsync(id);
        if (item is null) return NotFound();

        _context.Setlists.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
