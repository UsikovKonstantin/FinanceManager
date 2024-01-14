using FinanceManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Persistence.Configurations;

public class CategoryTransferConfiguration : IEntityTypeConfiguration<CategoryTransfer>
{
	public void Configure(EntityTypeBuilder<CategoryTransfer> builder)
	{
		DateTime now = DateTime.UtcNow;
		builder.HasData(
			new CategoryTransfer
			{
				Id = 1,
				UserId = 1,
				CategoryId = 1,
				Amount = 10000,
				DoneAt = now.AddDays(-5),
				Description = "Описание 1",
				CreatedAt = now,
				ModifiedAt = now
			},
			new CategoryTransfer
			{
				Id = 2,
				UserId = 1,
				CategoryId = 2,
				Amount = 5000,
				DoneAt = now.AddDays(-10),
				Description = "Описание 2",
				CreatedAt = now,
				ModifiedAt = now
			},
			new CategoryTransfer
			{
				Id = 3,
				UserId = 2,
				CategoryId = 12,
				Amount = -1000,
				DoneAt = now.AddDays(-15),
				Description = "Описание 3",
				CreatedAt = now,
				ModifiedAt = now
			},
			new CategoryTransfer
			{
				Id = 4,
				UserId = 4,
				CategoryId = 13,
				Amount = -800,
				DoneAt = now.AddDays(-20),
				Description = "Описание 4",
				CreatedAt = now,
				ModifiedAt = now
			}
		);

		builder.HasKey(ct => ct.Id);
		builder.Property(ct => ct.Id).ValueGeneratedOnAdd();

		builder.Property(ct => ct.CreatedAt)
			.IsRequired();

		builder.Property(ct => ct.ModifiedAt)
			.IsRequired();

		builder.HasOne(ct => ct.User)
			.WithMany(u => u.CategoryTransfers)
			.HasForeignKey(ct => ct.UserId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(ct => ct.Category)
			.WithMany(c => c.CategoryTransfers)
			.HasForeignKey(ct => ct.CategoryId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(ct => ct.Amount)
			.HasColumnType("decimal(7,2)")
			.IsRequired();
		builder.ToTable(table => table.HasCheckConstraint("CK_CategoryTransfer_Amount", "[Amount] > -100000 AND [Amount] < 100000 AND [Amount] <> 0"));

		builder.Property(ct => ct.DoneAt)
			.IsRequired();

		builder.Property(ct => ct.Description)
			.HasMaxLength(100);
	}
}
