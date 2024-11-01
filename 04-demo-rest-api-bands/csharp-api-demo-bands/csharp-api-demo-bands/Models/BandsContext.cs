using Microsoft.EntityFrameworkCore;

namespace csharp_api_demo_bands.Models
{
    public class BandsContext : DbContext
    {
        public BandsContext(DbContextOptions<BandsContext> options) : base(options) { }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Style> Styles { get; set; }
    }
}
