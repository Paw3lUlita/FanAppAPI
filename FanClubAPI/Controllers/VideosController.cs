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
    public class VideosController : ControllerBase
    {
        private readonly FanClubContext _context;

        public VideosController(FanClubContext context)
        {
            _context = context;
        }

        // GET: api/Videos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videos>>> GetVideos()
        {
            return await _context.Videos.ToListAsync();
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Videos>> GetVideos(int id)
        {
            var videos = await _context.Videos.FindAsync(id);

            if (videos == null)
            {
                return NotFound();
            }

            return videos;
        }

        // PUT: api/Videos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideos(int id, Videos videos)
        {
            if (id != videos.Id)
            {
                return BadRequest();
            }

            _context.Entry(videos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideosExists(id))
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

        // POST: api/Videos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Videos>> PostVideos(Videos videos)
        {
            _context.Videos.Add(videos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideos", new { id = videos.Id }, videos);
        }

        // DELETE: api/Videos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideos(int id)
        {
            var videos = await _context.Videos.FindAsync(id);
            if (videos == null)
            {
                return NotFound();
            }

            _context.Videos.Remove(videos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VideosExists(int id)
        {
            return _context.Videos.Any(e => e.Id == id);
        }
    }
}
