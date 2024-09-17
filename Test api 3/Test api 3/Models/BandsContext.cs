using Microsoft.EntityFrameworkCore;

namespace Test_api_3.Models
{
    public class BandsContext : DbContext
    {
        public BandsContext(DbContextOptions options) : base(options) { }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Style> Styles { get; set; }
    }
}
