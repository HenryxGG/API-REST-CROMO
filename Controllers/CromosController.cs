using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CromosApi.Data;
using CromosApi.Models;

namespace CromosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CromosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CromosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /api/cromos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cromo>>> GetCromos()
        {
            return await _context.Cromos.ToListAsync();
        }

        // POST: /api/cromos
        [HttpPost]
        public async Task<ActionResult<Cromo>> PostCromo(Cromo cromo)
        {
            _context.Cromos.Add(cromo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCromos), new { id = cromo.Id }, cromo);
        }

        // PUT: /api/cromos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCromo(int id, Cromo cromo)
        {
            if (id != cromo.Id) return BadRequest();

            _context.Entry(cromo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: /api/cromos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCromo(int id)
        {
            var cromo = await _context.Cromos.FindAsync(id);
            if (cromo == null) return NotFound();

            _context.Cromos.Remove(cromo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}