using FinanceManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
	public void Configure(EntityTypeBuilder<Role> builder)
	{
		DateTime now = DateTime.UtcNow;
		builder.HasData(
			new Role
			{
				Id = 1,
				Name = "TeamMember",
				CreatedAt = now,
				ModifiedAt = now
			},
			new Role
			{
				Id = 2,
				Name = "TeamLeader",
				CreatedAt = now,
				ModifiedAt = now
			},
			new Role
			{
				Id = 3,
				Name = "Admin",
				CreatedAt = now,
				ModifiedAt = now
			}
		);

		builder.HasKey(c => c.Id);
		builder.Property(c => c.Id).ValueGeneratedOnAdd();

		builder.Property(c => c.CreatedAt)
			.IsRequired();

		builder.Property(c => c.ModifiedAt)
			.IsRequired();

		builder.Property(c => c.Name)
			.IsRequired()
			.HasMaxLength(50);
		builder.HasIndex(c => c.Name)
			.IsUnique();
	}
}
