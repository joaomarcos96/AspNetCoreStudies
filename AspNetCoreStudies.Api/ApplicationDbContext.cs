using AspNetCoreStudies.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreStudies.Api
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
