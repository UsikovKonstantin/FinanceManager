﻿using FinanceManager.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
	public void Configure(EntityTypeBuilder<Category> builder)
	{
		DateTime now = DateTime.UtcNow;
		builder.HasData(
			new Category
			{
				Id = 1,
				Name = "Заработная плата",
				Type = 'I',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 2,
				Name = "Премия",
				Type = 'I',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 3,
				Name = "Пенсия",
				Type = 'I',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 4,
				Name = "Подарки",
				Type = 'I',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 5,
				Name = "Продуктовый магазин",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 6,
				Name = "Хозтовары",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 7,
				Name = "Подписка на музыкальный сервис",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 8,
				Name = "Магазин электроники",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 9,
				Name = "Магазин сантехники",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 10,
				Name = "Кафе/Ресторан",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 11,
				Name = "Услуги ЖКХ",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 12,
				Name = "Бензин",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 13,
				Name = "Общественный транспорт",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 14,
				Name = "Такси",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 15,
				Name = "Посещение врача",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 16,
				Name = "Лекарства",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 17,
				Name = "Одежда",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 18,
				Name = "Учебное заведение",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 19,
				Name = "Образование(книги/курсы/т.п.)",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 20,
				Name = "Развлечение(кино/концерты/т.п.)",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 21,
				Name = "Личные расходы",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 22,
				Name = "Подарки",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 23,
				Name = "Хобби",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 24,
				Name = "Красота и уход за собой",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 25,
				Name = "Проценты по кредитам",
				Type = 'E',
				CreatedAt = now,
				ModifiedAt = now
			},
			new Category
			{
				Id = 26,
				Name = "Другое",
				Type = 'B',
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

		builder.Property(c => c.Type)
			.IsRequired()
			.IsFixedLength()      
			.HasMaxLength(1)      
			.HasConversion<char>();
		builder.ToTable(table => table.HasCheckConstraint("CK_Category_Type", "[Type] IN ('I', 'E', 'B')"));
	}
}
