using demo_models.Table;
using Microsoft.EntityFrameworkCore;

namespace demo_web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}