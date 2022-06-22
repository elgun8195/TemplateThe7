using Microsoft.EntityFrameworkCore;
using The_7.Models;

namespace The_7.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext( DbContextOptions options) : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
