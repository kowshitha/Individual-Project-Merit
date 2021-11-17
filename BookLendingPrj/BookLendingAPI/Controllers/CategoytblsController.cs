using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLendingAPI.Models;

namespace BookLendingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoytblsController : ControllerBase
    {
        private readonly BooklprjtContext _context;

        public CategoytblsController(BooklprjtContext context)
        {
            _context = context;
        }

        // GET: api/Categoytbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoytbl>>> GetCategoytbls()
        {
            return await _context.Categoytbls.Include(e=>e.Booktbls).ToListAsync();
        }

        // GET: api/Categoytbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoytbl>> GetCategoytbl(int id)
        {
            var categoytbl = await _context.Categoytbls.FindAsync(id);

            if (categoytbl == null)
            {
                return NotFound();
            }

            return categoytbl;
        }

        // PUT: api/Categoytbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoytbl(int id, Categoytbl categoytbl)
        {
            if (id != categoytbl.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoytbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoytblExists(id))
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

        // POST: api/Categoytbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categoytbl>> PostCategoytbl(Categoytbl categoytbl)
        {
            _context.Categoytbls.Add(categoytbl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoytblExists(categoytbl.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategoytbl", new { id = categoytbl.Id }, categoytbl);
        }

        // DELETE: api/Categoytbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoytbl(int id)
        {
            var categoytbl = await _context.Categoytbls.FindAsync(id);
            if (categoytbl == null)
            {
                return NotFound();
            }

            _context.Categoytbls.Remove(categoytbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoytblExists(int id)
        {
            return _context.Categoytbls.Any(e => e.Id == id);
        }
    }
}
