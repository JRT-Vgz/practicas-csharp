using Microsoft.EntityFrameworkCore;
using ProjectFinalDemo.Domain.Entities;

namespace ProjectFinalDemo.Infrastructure.Data.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }

        public override int SaveChanges()
        {
            try
            {
                AddAuditoryAttributes();
                //List<AuditEntry> auditEntries = GetAuditEntries();
                int response = base.SaveChanges();
                //SaveAuditOtherDB(auditEntries);
                return response;
            }
            catch (Exception ex)
            {
                this.ChangeTracker.Clear();
                throw ex;
            }
        }

        private void AddAuditoryAttributes()
        {
            this.ChangeTracker.DetectChanges();
            var added = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Added)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in added)
            {
                if (entity is BaseEntity)
                {
                    var track = entity as BaseEntity;
                    track.CreatedDate = DateTime.Now;
                    track.CreatedBy = 1;
                    track.Status = true;
                }
            }

            var modified = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Modified)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in modified)
            {
                if (entity is BaseEntity)
                {
                    var track = entity as BaseEntity;
                    track.UpdatedDate = DateTime.Now;
                    track.UpdatedBy = 1;
                }
            }
        }
    }
}
