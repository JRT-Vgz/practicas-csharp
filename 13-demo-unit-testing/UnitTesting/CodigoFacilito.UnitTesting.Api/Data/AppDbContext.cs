using CodigoFacilito.UnitTesting.Api.Entities;

using Microsoft.EntityFrameworkCore;

namespace CodigoFacilito.UnitTesting.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
