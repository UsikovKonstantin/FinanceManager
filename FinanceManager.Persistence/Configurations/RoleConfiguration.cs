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

		builder.HasKey(r => r.Id);
		builder.Property(r => r.Id).ValueGeneratedOnAdd();

		builder.Property(r => r.CreatedAt)
			.IsRequired();

		builder.Property(r => r.ModifiedAt)
			.IsRequired();

		builder.Property(r => r.Name)
			.IsRequired()
			.HasMaxLength(50);
		builder.HasIndex(r => r.Name)
			.IsUnique();
	}
}
