using InBoxOutBoxExample.Domain.Write.Entities;
using Microsoft.EntityFrameworkCore;
using cloudscribe.EFCore.PostgreSql.Conventions;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using InBoxOutBoxExample.Domain;
using InBoxOutBoxExample.Domain.Write.Entities.Outbox;

namespace InBoxOutBoxExample.Persistence.Contexts
{
    public class InBoxOutBoxExampleWriteDbContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductOutbox>? ProductOutboxes { get; set; }
        public InBoxOutBoxExampleWriteDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplySnakeCaseConventions();         
            base.OnModelCreating(modelBuilder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            
            IEnumerable<EntityEntry<BaseEntity>> entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }


    }
}
