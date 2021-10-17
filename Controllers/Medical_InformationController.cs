using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Diadiabetes_App;
using Diadiabetes_App.Models;

namespace Diadiabetes_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Medical_InformationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Medical_InformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Medical_Informations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medical_Informations>>> GetMedical_Informations()
        {
            return await _context.Medical_Informations.ToListAsync();
        }

        // GET: api/Medical_Informations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medical_Informations>> GetMedical_Informations(long id)
        {
            var Medical_Informations = await _context.Medical_Informations.FindAsync(id);

            if (Medical_Informations == null)
            {
                return NotFound();
            }

            return Medical_Informations;
        }

        // PUT: api/Medical_Informations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedical_Informations(long id, Medical_Informations Medical_Informations)
        {
            if (id != Medical_Informations.Id)
            {
                return BadRequest();
            }

            _context.Entry(Medical_Informations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Medical_InformationsExists(id))
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

        // POST: api/Medical_Informations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medical_Informations>> PostMedical_Informations(Medical_Informations Medical_Informations)
        {
            _context.Medical_Informations.Add(Medical_Informations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedical_Informations", new { id = Medical_Informations.Id }, Medical_Informations);
        }

        // DELETE: api/Medical_Information/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedical_Informations(long id)
        {
            var Medical_Informations = await _context.Medical_Informations.FindAsync(id);
            if (Medical_Informations == null)
            {
                return NotFound();
            }

            _context.Medical_Informations.Remove(Medical_Informations);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Medical_InformationsExists(long id)
        {
            return _context.Medical_Informations.Any(e => e.Id == id);
        }
    }
}
