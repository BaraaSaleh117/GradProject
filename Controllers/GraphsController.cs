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
    public class GraphsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GraphsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Graphs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Graphs>>> GetGraph()
        {
            return await _context.Graphs.ToListAsync();
        }

        // GET: api/Graphs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Graphs>> GetGraph(int id)
        {
            var graph = await _context.Graphs.FindAsync(id);

            if (graph == null)
            {
                return NotFound();
            }

            return graph;
        }

        // PUT: api/Graphs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGraph(int id, Graphs graph)
        {
            if (id != graph.Id)
            {
                return BadRequest();
            }

            _context.Entry(graph).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraphExists(id))
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

        // POST: api/Graphs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Graphs>> PostGraph(Graphs graph)
        {
            _context.Graphs.Add(graph);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGraph", new { id = graph.Id }, graph);
        }

        // DELETE: api/Graphs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGraph(int id)
        {
            var graph = await _context.Graphs.FindAsync(id);
            if (graph == null)
            {
                return NotFound();
            }

            _context.Graphs.Remove(graph);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GraphExists(int id)
        {
            return _context.Graphs.Any(e => e.Id == id);
        }
    }
}
