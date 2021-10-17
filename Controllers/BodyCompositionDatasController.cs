using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Diadiabetes_App;
using Diadiabetes_App.model;

namespace Diadiabetes_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyCompositionDatasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BodyCompositionDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BodyCompositionDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BodyCompositionData>>> GetBodyCompositionDatum()
        {
            return await _context.BodyCompositionData.ToListAsync();
        }

        // GET: api/BodyCompositionDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyCompositionData>> GetBodyCompositionData(int id)
        {
            var bodyCompositionData = await _context.BodyCompositionData.FindAsync(id);

            if (bodyCompositionData == null)
            {
                return NotFound();
            }

            return bodyCompositionData;
        }

        // PUT: api/BodyCompositionDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyCompositionData(int id, BodyCompositionData bodyCompositionData)
        {
            if (id != bodyCompositionData.Id)
            {
                return BadRequest();
            }

            _context.Entry(bodyCompositionData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodyCompositionDataExists(id))
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

        // POST: api/BodyCompositionDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BodyCompositionData>> PostBodyCompositionData(BodyCompositionData bodyCompositionData)
        {
            _context.BodyCompositionData.Add(bodyCompositionData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBodyCompositionData", new { id = bodyCompositionData.Id }, bodyCompositionData);
        }

        // DELETE: api/BodyCompositionDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodyCompositionData(int id)
        {
            var bodyCompositionData = await _context.BodyCompositionData.FindAsync(id);
            if (bodyCompositionData == null)
            {
                return NotFound();
            }

            _context.BodyCompositionData.Remove(bodyCompositionData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BodyCompositionDataExists(int id)
        {
            return _context.BodyCompositionData.Any(e => e.Id == id);
        }
    }
}
