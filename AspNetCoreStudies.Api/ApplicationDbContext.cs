using AspNetCoreStudies.Api.Features.Articles;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreStudies.Api
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
