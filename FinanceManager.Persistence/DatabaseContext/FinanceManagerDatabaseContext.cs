using FinanceManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Persistence.DatabaseContext;

public class FinanceManagerDatabaseContext : DbContext
{
	public FinanceManagerDatabaseContext(DbContextOptions<FinanceManagerDatabaseContext> options) : base(options)
	{

	}

	public DbSet<Team> Teams { get; set; }
	public DbSet<Role> Roles { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<UserRole> UserRoles { get; set; }
	public DbSet<CategoryTransfer> CategoryTransfers { get; set; }
	public DbSet<UserTransfer> UserTransfers { get; set; }
	public DbSet<Invitation> Invitations { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinanceManagerDatabaseContext).Assembly);

		base.OnModelCreating(modelBuilder);
	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		DateTime now = DateTime.UtcNow;
		foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
			.Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
		{
			entry.Entity.ModifiedAt = now;

			if (entry.State == EntityState.Added)
			{
				entry.Entity.CreatedAt = now;
			}
		}

		return base.SaveChangesAsync(cancellationToken);
	}
}
