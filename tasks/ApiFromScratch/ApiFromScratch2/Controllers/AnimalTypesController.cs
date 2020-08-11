using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiFromScratch2.Models;

namespace ApiFromScratch2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalTypesController : ControllerBase
    {
        private readonly Animal2DBContext _context;

        public AnimalTypesController(Animal2DBContext context)
        {
            _context = context;
        }

        // GET: api/AnimalTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalTypes>>> GetAnimalTypes()
        {
            return await _context.AnimalTypes.ToListAsync();
        }

        // GET: api/AnimalTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalTypes>> GetAnimalTypes(int id)
        {
            var animalTypes = await _context.AnimalTypes.FindAsync(id);

            if (animalTypes == null)
            {
                return NotFound();
            }

            return animalTypes;
        }

        // PUT: api/AnimalTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalTypes(int id, AnimalTypes animalTypes)
        {
            if (id != animalTypes.AnimalTypeId)
            {
                return BadRequest();
            }

            _context.Entry(animalTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalTypesExists(id))
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
        public async Task<ActionResult<AnimalTypes>> PostAnimalTypes(AnimalTypes animalTypes)
        {
            _context.AnimalTypes.Add(animalTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalTypes", new { id = animalTypes.AnimalTypeId }, animalTypes);
        }

        // DELETE: api/AnimalTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AnimalTypes>> DeleteAnimalTypes(int id)
        {
            var animalTypes = await _context.AnimalTypes.FindAsync(id);
            if (animalTypes == null)
            {
                return NotFound();
            }

            _context.AnimalTypes.Remove(animalTypes);
            await _context.SaveChangesAsync();

            return animalTypes;
        }

        private bool AnimalTypesExists(int id)
        {
            return _context.AnimalTypes.Any(e => e.AnimalTypeId == id);
        }
    }
}
