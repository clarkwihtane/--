

using Microsoft.EntityFrameworkCore;


namespace WebApplication9.Models
{
    public class EffortDbContext : DbContext
    {
        public EffortDbContext(DbContextOptions<EffortDbContext> options) : base(options)
        {

        }
        public DbSet<Effort> Efforts { get; set; } = null!;

    }
}