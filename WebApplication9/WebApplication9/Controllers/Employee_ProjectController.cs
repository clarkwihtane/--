using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee_ProjectController : ControllerBase
    {

        private readonly Employee_ProjectDbContext _employee_projectContext;
        public Employee_ProjectController(Employee_ProjectDbContext employee_projectContext)
        {
            _employee_projectContext = employee_projectContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee_Project>>> GetEmployee_Project()
        {
            if (_employee_projectContext.Employee_Projects == null)
            {
                return NotFound();
            }
            return await _employee_projectContext.Employee_Projects.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee_Project>> GetEmployee_Project(int id)
        {
            if (_employee_projectContext.Employee_Projects is null)
            {
                return NotFound();
            }
            var employee_project = await _employee_projectContext.Employee_Projects.FindAsync(id);
            if (employee_project is null)
            {
                return NotFound();
            }
            return employee_project;
        }

        [HttpPost]
        public async Task<ActionResult<Employee_Project>> PostEmployee_Project(Employee_Project employee_project)
        {
            if (employee_project == null)
            {
                return BadRequest("Employee_project data is null.");
            }

            _employee_projectContext.Employee_Projects.Add(employee_project);
            await _employee_projectContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee_Project), new { id = employee_project.e_p_id }, employee_project);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee_Project(int id)
        {
            var employee_project = await _employee_projectContext.Employee_Projects.FindAsync(id);

            if (employee_project == null)
            {
                return NotFound();
            }

            _employee_projectContext.Employee_Projects.Remove(employee_project);
            await _employee_projectContext.SaveChangesAsync();

            return NoContent();
        }



    }
}
