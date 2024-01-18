using FinanceManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
				UserName = "Konstantin1",
				FirstName = "Константин",
				LastName = "Усиков",
				Balance = 10000,
				Gender = "M",
				Email = "usikov_konstantin@mail.ru",
				Password = "46BDA4F3691DF3493E8931985FB2073986231F597BD8D1841FFE919CA670EB06:D7A6746090E449C64C85B60FADAE5D2F:50000:SHA256",
				IsRegistered = true,
				CreatedAt = now,
				ModifiedAt = now
			},
			new User
			{
				Id = 2,
				TeamId = 1,
				UserName = "Dmitry1",
				FirstName = "Дмитрий",
				LastName = "Орлов",
				Balance = 20000,
				Gender = "M",
				Email = "orlov_dmitry@yandex.ru",
				Password = "F77753025D17913EE058E04AC3A62373A4F8564FCEE7C5DC4AD3F1A419238B4E:6641B1A3A8BADF1A30F307179A9A5C0A:50000:SHA256",
				IsRegistered = true,
				CreatedAt = now,
				ModifiedAt = now
			},
			new User
			{
				Id = 3,
				TeamId = 1,
				UserName = "Artyom1",
				FirstName = "Артем",
				LastName = "Иванов",
				Balance = 30000,
				Gender = "M",
				Email = "ivanov_artyom@gmail.com",
				Password = "39E7BE9C0432F76FF7E239D3C8C9313270BF2CDC1D5EBDA0474C241F52387CC8:368AEC1394165D87754905CECD02A369:50000:SHA256",
				IsRegistered = true,
				CreatedAt = now,
				ModifiedAt = now
			},
			new User
			{
				Id = 4,
				TeamId = 2,
				UserName = "Maria1",
				FirstName = "Мария",
				LastName = "Смирнова",
				Balance = 40000,
				Gender = "F",
				Email = "smirnova_maria@mail.ru",
				Password = "593652F3B10EE726A804C7B74C8C5A5A9E0C7F1E4E135BF1414E92CA5EE6EEFC:FE38DEBEE0E9CC245B5BE4BBC4A0918C:50000:SHA256",
				IsRegistered = true,
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
			.IsRequired()
			.HasColumnType("decimal(10,2)");
		builder.ToTable(table => table.HasCheckConstraint("CK_User_Balance", "[Balance] >= 0 AND [Balance] < 100000000"));

		builder.Property(u => u.Gender)
			.IsRequired()
			.HasMaxLength(1);
		builder.ToTable(table => table.HasCheckConstraint("CK_User_Gender", "[Gender] IN ('M', 'F')"));

		builder.Property(u => u.Email)
			.IsRequired()
			.HasMaxLength(50);
		builder.HasIndex(u => u.Email)
			.IsUnique();
		builder.ToTable(table => table.HasCheckConstraint("CK_User_EmailFormat", "PATINDEX('%_@_%', [Email]) > 0"));

		builder.Property(u => u.Password)
			.IsRequired();

		builder.Property(u => u.IsRegistered)
			.IsRequired();

		builder.Property(u => u.RegistrationToken)
			.HasMaxLength(100);

		builder.Property(u => u.ResetPasswordToken)
			.HasMaxLength(100);

		builder.Property(u => u.ChangeEmailToken)
			.HasMaxLength(100);

		builder.Property(u => u.RefreshToken)
			.HasMaxLength(100);

		builder.Property(u => u.NewEmail)
			.HasMaxLength(50);
		builder.ToTable(table => table.HasCheckConstraint("CK_User_NewEmailFormat", "PATINDEX('%_@_%', [NewEmail]) > 0"));
	}
}
