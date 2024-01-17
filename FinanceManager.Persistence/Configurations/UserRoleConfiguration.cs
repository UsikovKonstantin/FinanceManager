using FinanceManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Persistence.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
	public void Configure(EntityTypeBuilder<UserRole> builder)
	{
		DateTime now = DateTime.UtcNow;
		builder.HasData(
			new UserRole
			{
				UserId = 1,
				RoleId = 2,
				CreatedAt = now,
				ModifiedAt = now
			},
			new UserRole
			{
				UserId = 2,
				RoleId = 1,
				CreatedAt = now,
				ModifiedAt = now
			},
			new UserRole
			{
				UserId = 3,
				RoleId = 1,
				CreatedAt = now,
				ModifiedAt = now
			},
			new UserRole
			{
				UserId = 4,
				RoleId = 2,
				CreatedAt = now,
				ModifiedAt = now
			}
		);

		builder.Ignore(ur => ur.Id);

		builder.HasKey(ur => new { ur.UserId, ur.RoleId });

		builder.Property(ur => ur.CreatedAt)
			.IsRequired();

		builder.Property(ur => ur.ModifiedAt)
			.IsRequired();

		builder.HasOne(ur => ur.User)
			.WithMany(u => u.UserRoles)
			.HasForeignKey(ur => ur.UserId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(ur => ur.Role)
			.WithMany(r => r.UserRoles)
			.HasForeignKey(ur => ur.RoleId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}
