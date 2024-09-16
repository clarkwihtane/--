using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication9.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeDbContext _employeeContext;
        public EmployeeController(EmployeeDbContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            if (_employeeContext.Employees == null)
            {
                return NotFound();
            }
            return await _employeeContext.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            if (_employeeContext.Employees is null)
            {
                return NotFound();
            }
            var employee = await _employeeContext.Employees.FindAsync(id);
            if (employee is null)
            {
                return NotFound();
            }
            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee data is null.");
            }

            _employeeContext.Employees.Add(employee);
            await _employeeContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.employee_id }, employee);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _employeeContext.Employees.Remove(employee);
            await _employeeContext.SaveChangesAsync();

            return NoContent();
        }


    }
}
