using Microsoft.EntityFrameworkCore;



namespace WebApplication9.Models
{
    public class Employee_ProjectDbContext : DbContext
    {

        public Employee_ProjectDbContext(DbContextOptions<Employee_ProjectDbContext> options) : base(options)
        {

        }
        public DbSet<Employee_Project> Employee_Projects { get; set; } = null!;


    }
}
