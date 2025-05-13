
using Microsoft.EntityFrameworkCore;
using RepositoryComponent.Models;

namespace RepositoryComponent
{
    public class ItemsDBContext : DbContext
    {
        public DbSet<ItemModel> ItemsModel { get; set; }
        public DbSet<NoteModel> NotesModel { get; set; }

        public ItemsDBContext(DbContextOptions<ItemsDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemModel>().ToTable("Item");

            modelBuilder.Entity<NoteModel>().ToTable("Note")
                .HasOne(n => n.Item)
                .WithMany(i => i.Notes)
                .HasForeignKey(n => n.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
