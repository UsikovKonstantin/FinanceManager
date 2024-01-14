using FinanceManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Persistence.Configurations;

public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
{
	public void Configure(EntityTypeBuilder<Invitation> builder)
	{
		DateTime now = DateTime.UtcNow;
		builder.HasData(
			new Invitation
			{
				Id = 1,
				UserFromId = 4,
				UserToId = 1,
				CreatedAt = now,
				ModifiedAt = now
			},
			new Invitation
			{
				Id = 2,
				UserFromId = 4,
				UserToId = 2,
				CreatedAt = now,
				ModifiedAt = now
			},
			new Invitation
			{
				Id = 3,
				UserFromId = 1,
				UserToId = 4,
				CreatedAt = now,
				ModifiedAt = now
			}
		);

		builder.HasKey(i => i.Id);
		builder.Property(i => i.Id).ValueGeneratedOnAdd();

		builder.Property(i => i.CreatedAt)
			.IsRequired();

		builder.Property(i => i.ModifiedAt)
			.IsRequired();

		builder.HasOne(i => i.UserFrom)
			.WithMany(u => u.InvitationsFrom)
			.HasForeignKey(i => i.UserFromId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(i => i.UserTo)
			.WithMany(u => u.InvitationsTo)
			.HasForeignKey(i => i.UserToId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(i => new { i.UserFromId, i.UserToId })
			.IsUnique();

		builder.ToTable(table => table.HasCheckConstraint("CK_Invitation_NotEqual", "[UserFromId] <> [UserToId]"));
	}
}
