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
    public class PatientRecordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PatientRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PatientRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientRecords>>> GetPatientRecord()
        {
            return await _context.PatientRecords.ToListAsync();
        }

        // GET: api/PatientRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientRecords>> GetPatientRecord(int id)
        {
            var patientRecord = await _context.PatientRecords.FindAsync(id);

            if (patientRecord == null)
            {
                return NotFound();
            }

            return patientRecord;
        }

        // PUT: api/PatientRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientRecord(int id, PatientRecords patientRecord)
        {
            if (id != patientRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(patientRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientRecordExists(id))
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

        // POST: api/PatientRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientRecords>> PostPatientRecord(PatientRecords patientRecord)
        {
            _context.PatientRecords.Add(patientRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientRecord", new { id = patientRecord.Id }, patientRecord);
        }

        // DELETE: api/PatientRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientRecord(int id)
        {
            var patientRecord = await _context.PatientRecords.FindAsync(id);
            if (patientRecord == null)
            {
                return NotFound();
            }

            _context.PatientRecords.Remove(patientRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientRecordExists(int id)
        {
            return _context.PatientRecords.Any(e => e.Id == id);
        }
    }
}
