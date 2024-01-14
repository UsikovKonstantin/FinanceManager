using Microsoft.EntityFrameworkCore;
using FinanceManager.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Persistence.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
	public void Configure(EntityTypeBuilder<Team> builder)
	{
		DateTime now = DateTime.UtcNow;
		builder.HasData(
			new Team
			{
				Id = 1,
				Name = "Группа 1",
				CreatedAt = now,
				ModifiedAt = now
			},
			new Team
			{
				Id = 2,
				Name = "Группа 2",
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
	}
}
