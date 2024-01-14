using FinanceManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.Contracts;
using System.Reflection.Emit;

namespace FinanceManager.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		DateTime now = DateTime.UtcNow;
		builder.HasData(
			new User
			{
				Id = 1,
				TeamId = 1,
				UserName = "Konstantin",
				FirstName = "Константин",
				LastName = "Усиков",
				Balance = 10000,
				Gender = 'M',
				Email = "usikov_konstantin@mail.ru",
				EmailConfirmed = true,
				Password = "03D1F6545E6426DDEC4797280867E2F14593E0FB38DD6BF190773139DCE58D92:E1C74E1AEB5D8308D160474C6E2C274E:50000:SHA256",
				CreatedAt = now,
				ModifiedAt = now
			},
			new User
			{
				Id = 2,
				TeamId = 1,
				UserName = "Dmitry",
				FirstName = "Дмитрий",
				LastName = "Орлов",
				Balance = 20000,
				Gender = 'M',
				Email = "orlov_dmitry@yandex.ru",
				EmailConfirmed = true,
				Password = "41998DC78F605A001090203007F3F7341D46BE392229F82263C753B712BB57D5:2365F9A998AE23EBC65EAB8BAD005458:50000:SHA256",
				CreatedAt = now,
				ModifiedAt = now
			},
			new User
			{
				Id = 3,
				TeamId = 1,
				UserName = "Artyom",
				FirstName = "Артем",
				LastName = "Иванов",
				Balance = 30000,
				Gender = 'M',
				Email = "ivanov_artyom@gmail.com",
				EmailConfirmed = true,
				Password = "AC74B05E1B544764C0E33E0D4574A5E29C629AF5D22394B7308789DE59F054F3:9FD58EBE4CB968212D9F0117466A77CC:50000:SHA256",
				CreatedAt = now,
				ModifiedAt = now
			},
			new User
			{
				Id = 4,
				TeamId = 2,
				UserName = "Maria",
				FirstName = "Мария",
				LastName = "Смирнова",
				Balance = 40000,
				Gender = 'F',
				Email = "smirnova_maria@mail.ru",
				EmailConfirmed = true,
				Password = "D9507B7FD5AF9880B37D6926354AB29CA7B313891BE5A3E9B851A4BF6E32BDCD:0E08FF50E2205404163CE192B957FA60:50000:SHA256",
				CreatedAt = now,
				ModifiedAt = now
			}
		);

		builder.HasKey(u => u.Id);
		builder.Property(u => u.Id).ValueGeneratedOnAdd();

		builder.Property(u => u.CreatedAt)
			.IsRequired();

		builder.Property(u => u.ModifiedAt)
			.IsRequired();

		builder.HasOne(u => u.Team)
			.WithMany(t => t.Users)
			.HasForeignKey(u => u.TeamId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(u => u.UserName)
			.IsRequired()
			.HasMaxLength(50);
		builder.HasIndex(u => u.UserName)
			.IsUnique();

		builder.Property(u => u.FirstName)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(u => u.LastName)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(u => u.Balance)
			.HasColumnType("decimal(10,2)")
			.IsRequired();
		builder.ToTable(table => table.HasCheckConstraint("CK_User_Balance", "[Balance] >= 0 AND [Balance] < 100000000"));

		builder.Property(u => u.Gender)
			.IsRequired()
			.IsFixedLength()
			.HasMaxLength(1)
			.HasConversion<char>();
		builder.ToTable(table => table.HasCheckConstraint("CK_User_Gender", "[Gender] IN ('M', 'F')"));

		builder.Property(u => u.Email)
			.IsRequired()
			.HasMaxLength(50);
		builder.HasIndex(u => u.Email)
			.IsUnique();
		builder.ToTable(table => table.HasCheckConstraint("CK_User_Email", "CHARINDEX('@', [Email]) > 0"));
		builder.ToTable(table => table.HasCheckConstraint("CK_User_EmailFormat", "PATINDEX('%_@__%.__%', [Email]) > 0"));

		builder.Property(u => u.EmailConfirmed)
			.IsRequired();

		builder.Property(u => u.Password)
			.IsRequired()
			.HasMaxLength(150);

		builder.Property(u => u.AccessToken)
			.HasMaxLength(200);

		builder.Property(u => u.RefreshToken)
			.HasMaxLength(200);
	}
}
