using FinanceManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Persistence.Configurations;

public class UserTransferConfiguration : IEntityTypeConfiguration<UserTransfer>
{
	public void Configure(EntityTypeBuilder<UserTransfer> builder)
	{
		DateTime now = DateTime.UtcNow;
		builder.HasData(
			new UserTransfer
			{
				Id = 1,
				UserFromId = 1,
				UserToId = 2,
				Amount = 250,
				DoneAt = now.AddDays(-5),
				Description = "Описание 1",
				CreatedAt = now,
				ModifiedAt = now
			},
			new UserTransfer
			{
				Id = 2,
				UserFromId = 4,
				UserToId = 3,
				Amount = 500,
				DoneAt = now.AddDays(-10),
				Description = "Описание 2",
				CreatedAt = now,
				ModifiedAt = now
			},
			new UserTransfer
			{
				Id = 3,
				UserFromId = 4,
				UserToId = 1,
				Amount = 700,
				DoneAt = now.AddDays(-15),
				Description = "Описание 3",
				CreatedAt = now,
				ModifiedAt = now
			}
		);

		builder.HasKey(ut => ut.Id);
		builder.Property(ut => ut.Id).ValueGeneratedOnAdd();

		builder.Property(ut => ut.CreatedAt)
			.IsRequired();

		builder.Property(ut => ut.ModifiedAt)
			.IsRequired();

		builder.HasOne(ut => ut.UserFrom)
			.WithMany(u => u.UserTransfersFrom)
			.HasForeignKey(ut => ut.UserFromId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(ut => ut.UserTo)
			.WithMany(u => u.UserTransfersTo)
			.HasForeignKey(ut => ut.UserToId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(ut => ut.Amount)
			.HasColumnType("decimal(7,2)")
			.IsRequired();
		builder.ToTable(table => table.HasCheckConstraint("CK_UserTransfer_Amount", "[Amount] > 0 AND [Amount] < 100000"));

		builder.Property(ut => ut.DoneAt)
			.IsRequired();

		builder.Property(ut => ut.Description)
			.HasMaxLength(100);
	}
}
