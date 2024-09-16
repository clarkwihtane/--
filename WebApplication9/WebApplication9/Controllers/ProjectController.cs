using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;

using Microsoft.EntityFrameworkCore;
namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {


        private readonly ProjectDbContext _projectContext;
        public ProjectController(ProjectDbContext projectContext)
        {
            _projectContext = projectContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProject()
        {
            if (_projectContext.Projects == null)
            {
                return NotFound();
            }
            return await _projectContext.Projects.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            if (_projectContext.Projects is null)
            {
                return NotFound();
            }
            var project = await _projectContext.Projects.FindAsync(id);
            if (project is null)
            {
                return NotFound();
            }
            return project;
        }

        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
            if (project == null)
            {
                return BadRequest("Project data is null.");
            }

            _projectContext.Projects.Add(project);
            await _projectContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = project.project_id }, project);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _projectContext.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            _projectContext.Projects.Remove(project);
            await _projectContext.SaveChangesAsync();

            return NoContent();
        }




    }
}
