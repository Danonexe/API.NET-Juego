using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TodoApi.Models;
using MongoDB.Bson;

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
            var estadisticas = await _context.Estadisticas.Find(_ => true).ToListAsync();
            return estadisticas;
        }

        // GET: api/Estadisticas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estadisticas>> GetEstadisticas(string id)
        {
            var filter = Builders<Estadisticas>.Filter.Eq("_id", ObjectId.Parse(id));
            var estadisticas = await _context.Estadisticas.Find(filter).FirstOrDefaultAsync();

            if (estadisticas == null)
            {
                return NotFound();
            }

            return estadisticas;
        }

        // PUT: api/Estadisticas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadisticas(string id, Estadisticas estadisticas)
        {
            if (id != estadisticas.Id)
            {
                return BadRequest();
            }

            try
            {
                var filter = Builders<Estadisticas>.Filter.Eq("_id", ObjectId.Parse(id));
                var update = Builders<Estadisticas>.Update
                    .Set(e => e.Nick, estadisticas.Nick)
                    .Set(e => e.Score, estadisticas.Score)
                    .Set(e => e.Time, estadisticas.Time);

                var result = await _context.Estadisticas.UpdateOneAsync(filter, update);

                if (result.ModifiedCount == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                if (!await EstadisticasExistsAsync(id))
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
        [HttpPost]
        public async Task<ActionResult<Estadisticas>> PostEstadisticas(Estadisticas estadisticas)
        {
            // Asegúrate de que el id sea nulo para que MongoDB genere uno
            estadisticas.Id = null;
            
            await _context.Estadisticas.InsertOneAsync(estadisticas);

            return CreatedAtAction(nameof(GetEstadisticas), new { id = estadisticas.Id }, estadisticas);
        }

        // DELETE: api/Estadisticas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadisticas(string id)
        {
            var filter = Builders<Estadisticas>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = await _context.Estadisticas.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                return NotFound();
            }

            return NoContent();
        }

        private async Task<bool> EstadisticasExistsAsync(string id)
        {
            var filter = Builders<Estadisticas>.Filter.Eq("_id", ObjectId.Parse(id));
            var count = await _context.Estadisticas.CountDocumentsAsync(filter);
            return count > 0;
        }
    }
}