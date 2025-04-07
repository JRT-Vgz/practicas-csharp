
using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;

namespace RepositoryComponent
{
    public class ItemsDBContext : DbContext
    {
        public DbSet<ItemModel> ItemsModel { get; set; }

        public ItemsDBContext(DbContextOptions<ItemsDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemModel>().ToTable("Item");
        }
    }
}
