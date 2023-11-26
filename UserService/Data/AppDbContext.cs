using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
            => Database.EnsureCreated();

        public DbSet<Item> Items { get; set; } = null!;
    }
}
