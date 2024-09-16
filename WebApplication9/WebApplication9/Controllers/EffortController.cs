using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApplication9.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EffortController : ControllerBase
    {


        private readonly EffortDbContext _effortContext;
        public EffortController(EffortDbContext effortContext)
        {
            _effortContext = effortContext;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Effort>>> GetEffort()
        {
            if (_effortContext.Efforts == null)
            {
                return NotFound();
            }
            return await _effortContext.Efforts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Effort>> GetEffort(int id)
        {
            if (_effortContext.Efforts is null)
            {
                return NotFound();
            }
            var effort = await _effortContext.Efforts.FindAsync(id);
            if (effort is null)
            {
                return NotFound();
            }
            return effort;
        }

        [HttpPost]
        public async Task<ActionResult<Effort>> PostEffort(Effort effort)
        {
            if (effort == null)
            {
                return BadRequest("Effort data is null.");
            }

            _effortContext.Efforts.Add(effort);
            await _effortContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEffort), new { id = effort.effort_id }, effort);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEffort(int id)
        {
            var effort = await _effortContext.Efforts.FindAsync(id);

            if (effort == null)
            {
                return NotFound();
            }

            _effortContext.Efforts.Remove(effort);
            await _effortContext.SaveChangesAsync();

            return NoContent();
        }


    }
}
