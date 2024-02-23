using Microsoft.EntityFrameworkCore;
using WebApplication1.models;
namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
    }
}
