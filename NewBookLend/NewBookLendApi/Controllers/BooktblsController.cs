using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewBookLendApi.Models;

namespace NewBookLendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooktblsController : ControllerBase
    {
        private readonly BooklprjtContext _context;

        public BooktblsController(BooklprjtContext context)
        {
            _context = context;
        }

        // GET: api/Booktbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booktbl>>> GetBooktbls()
        {
            return await _context.Booktbls.ToListAsync();
        }

        // GET: api/Booktbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booktbl>> GetBooktbl(int id)
        {
            var booktbl = await _context.Booktbls.FindAsync(id);

            if (booktbl == null)
            {
                return NotFound();
            }

            return booktbl;
        }

        // PUT: api/Booktbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooktbl(int id, Booktbl booktbl)
        {
            if (id != booktbl.BId)
            {
                return BadRequest();
            }

            _context.Entry(booktbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooktblExists(id))
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

        // POST: api/Booktbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booktbl>> PostBooktbl(Booktbl booktbl)
        {
            _context.Booktbls.Add(booktbl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BooktblExists(booktbl.BId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBooktbl", new { id = booktbl.BId }, booktbl);
        }

        // DELETE: api/Booktbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooktbl(int id)
        {
            var booktbl = await _context.Booktbls.FindAsync(id);
            if (booktbl == null)
            {
                return NotFound();
            }

            _context.Booktbls.Remove(booktbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BooktblExists(int id)
        {
            return _context.Booktbls.Any(e => e.BId == id);
        }
    }
}
