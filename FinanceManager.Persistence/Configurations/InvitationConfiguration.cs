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
				UserFromId = 4,
				UserToId = 1,
				CreatedAt = now,
				ModifiedAt = now
			},
			new Invitation
			{
				UserFromId = 4,
				UserToId = 2,
				CreatedAt = now,
				ModifiedAt = now
			},
			new Invitation
			{
				UserFromId = 1,
				UserToId = 4,
				CreatedAt = now,
				ModifiedAt = now
			}
		);

		builder.Ignore(i => i.Id);

		builder.HasKey(i => new { i.UserFromId, i.UserToId });

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

		builder.ToTable(table => table.HasCheckConstraint("CK_Invitation_NotEqual", "[UserFromId] <> [UserToId]"));
	}
}
