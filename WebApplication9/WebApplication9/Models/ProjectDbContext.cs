
using Microsoft.EntityFrameworkCore;


namespace WebApplication9.Models
{
    public class ProjectDbContext : DbContext
    {

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; } = null!;

    }
}
