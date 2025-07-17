using CoreData.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CoreData.Interfaces;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
	{
		public StoreContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Student> Students { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var entities = ChangeTracker.Entries()
				.Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

			foreach (var entityEntry in entities)
			{
				var baseEntity = (BaseEntity)entityEntry.Entity;

				if (entityEntry.State == EntityState.Added)
				{
					baseEntity.CreatedDate = DateTime.UtcNow;
				}

				baseEntity.ModifiedDate = DateTime.UtcNow;
			}

			var deletedEntities = ChangeTracker.Entries()
				.Where(e => e.Entity is ISoftDeletable && e.State == EntityState.Deleted);

			foreach (var entityEntry in deletedEntities)
			{
				entityEntry.State = EntityState.Modified;
				((ISoftDeletable)entityEntry.Entity).IsDeleted = true;
			}

			return await base.SaveChangesAsync(cancellationToken);
		}
	}
}
