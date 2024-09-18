using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace api_test_2.Models
{
    public class BandsContext : DbContext
    {
        public BandsContext(DbContextOptions options) : base(options) { }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Style> Styles { get; set; }
    }
}
