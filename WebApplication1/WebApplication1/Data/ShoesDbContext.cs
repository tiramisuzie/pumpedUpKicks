using Microsoft.EntityFrameworkCore;

namespace PumpedUpKicks.Data
{
    public class ShoesDbContext : DbContext
    {
        public ShoesDbContext(DbContextOptions<ShoesDbContext> options) : base(options)
        {
        }

        // For composite keys and shadow properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }

}
