using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FanClubAPI.Models;

namespace FanClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConcertsController : ControllerBase
    {
        private readonly FanClubContext _context;

        public ConcertsController(FanClubContext context)
        {
            _context = context;
        }

        // GET: api/Concerts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concerts>>> GetConcerts()
        {
            return await _context.Concerts.ToListAsync();
        }

        // GET: api/Concerts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concerts>> GetConcerts(int id)
        {
            var concerts = await _context.Concerts.FindAsync(id);

            if (concerts == null)
            {
                return NotFound();
            }

            return concerts;
        }

        // PUT: api/Concerts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcerts(int id, Concerts concerts)
        {
            if (id != concerts.Id)
            {
                return BadRequest();
            }

            _context.Entry(concerts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcertsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Concerts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Concerts>> PostConcerts(Concerts concerts)
        {
            _context.Concerts.Add(concerts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConcerts", new { id = concerts.Id }, concerts);
        }

        // DELETE: api/Concerts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcerts(int id)
        {
            var concerts = await _context.Concerts.FindAsync(id);
            if (concerts == null)
            {
                return NotFound();
            }

            _context.Concerts.Remove(concerts);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConcertsExists(int id)
        {
            return _context.Concerts.Any(e => e.Id == id);
        }
    }
}
