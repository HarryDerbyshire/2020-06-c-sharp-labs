using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_safari_entity_core.Models;

namespace api_safari_entity_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalTypesController : ControllerBase
    {
        private readonly SafariContext _context;

        public AnimalTypesController(SafariContext context)
        {
            _context = context;
        }

        // GET: api/AnimalTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalType>>> GetAnimalTypes()
        {
            return await _context.AnimalTypes.ToListAsync();
        }

        // GET: api/AnimalTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalType>> GetAnimalType(long id)
        {
            var animalType = await _context.AnimalTypes.FindAsync(id);

            if (animalType == null)
            {
                return NotFound();
            }

            return animalType;
        }

        // PUT: api/AnimalTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalType(long id, AnimalType animalType)
        {
            if (id != animalType.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(animalType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalTypeExists(id))
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

        // POST: api/AnimalTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AnimalType>> PostAnimalType(AnimalType animalType)
        {
            _context.AnimalTypes.Add(animalType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AnimalTypeExists(animalType.TypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAnimalType", new { id = animalType.TypeId }, animalType);
        }

        // DELETE: api/AnimalTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnimalType>> DeleteAnimalType(long id)
        {
            var animalType = await _context.AnimalTypes.FindAsync(id);
            if (animalType == null)
            {
                return NotFound();
            }

            _context.AnimalTypes.Remove(animalType);
            await _context.SaveChangesAsync();

            return animalType;
        }

        private bool AnimalTypeExists(long id)
        {
            return _context.AnimalTypes.Any(e => e.TypeId == id);
        }
    }
}
