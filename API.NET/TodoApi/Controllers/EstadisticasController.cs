using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadisticasController : ControllerBase
    {
        private readonly TodoContext _context;

        public EstadisticasController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Estadisticas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estadisticas>>> GetEstadisticas()
        {
            return await _context.Estadisticas.ToListAsync();
        }

        // GET: api/Estadisticas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estadisticas>> GetEstadisticas(long id)
        {
            var Estadisticas = await _context.Estadisticas.FindAsync(id);

            if (Estadisticas == null)
            {
                return NotFound();
            }

            return Estadisticas;
        }

        // PUT: api/Estadisticas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadisticas(long id, Estadisticas Estadisticas)
        {
            if (id != Estadisticas.Id)
            {
                return BadRequest();
            }

            _context.Entry(Estadisticas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadisticasExists(id))
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

        // POST: api/Estadisticas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estadisticas>> PostEstadisticas(Estadisticas Estadisticas)
        {
            _context.Estadisticas.Add(Estadisticas);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetEstadisticas", new { id = Estadisticas.Id }, Estadisticas);
            return CreatedAtAction(nameof(GetEstadisticas), new { id = Estadisticas.Id }, Estadisticas);
        }

        // DELETE: api/Estadisticas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadisticas(long id)
        {
            var Estadisticas = await _context.Estadisticas.FindAsync(id);
            if (Estadisticas == null)
            {
                return NotFound();
            }

            _context.Estadisticas.Remove(Estadisticas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadisticasExists(long id)
        {
            return _context.Estadisticas.Any(e => e.Id == id);
        }
    }
}
