using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI5.Models;

namespace WebAPI5.Controllers
{
    [Route("api/Beers")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly BeerContext _context;

        public BeersController(BeerContext context)
        {
            _context = context;
        }

        // GET: api/Beers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beers>>> GetBeerItems()
        {
            return await _context.BeerItems.ToListAsync();
        }

        // GET: api/Beers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Beers>> GetBeers(long id)
        {
            var beers = await _context.BeerItems.FindAsync(id);

            if (beers == null)
            {
                return NotFound();
            }

            return beers;
        }

        // PUT: api/Beers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeers(long id, Beers beers)
        {
            if (id != beers.Id)
            {
                return BadRequest();
            }

            _context.Entry(beers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeersExists(id))
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

        // POST: api/Beers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Beers>> PostBeers(Beers beers)
        {
            _context.BeerItems.Add(beers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeers", new { id = beers.Id }, beers);
        }

        // DELETE: api/Beers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBeers(long id)
        {
            var beers = await _context.BeerItems.FindAsync(id);
            if (beers == null)
            {
                return NotFound();
            }

            _context.BeerItems.Remove(beers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BeersExists(long id)
        {
            return _context.BeerItems.Any(e => e.Id == id);
        }
    }
}
