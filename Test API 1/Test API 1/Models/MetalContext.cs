using Microsoft.EntityFrameworkCore;

namespace Test_API_1.Models
{
    public class MetalContext : DbContext
    {
        public MetalContext(DbContextOptions options) : base(options) { }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Style> Style { get; set; }
    }
}
