using Microsoft.EntityFrameworkCore;
using CopyStackOverFlow_Version2.Model;

namespace CopyStackOverFlow_Version2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        
    }
}
