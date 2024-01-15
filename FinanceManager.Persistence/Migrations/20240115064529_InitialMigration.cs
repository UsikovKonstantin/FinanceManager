using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinanceManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "char(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.CheckConstraint("CK_Category_Type", "[Type] IN ('I', 'E', 'B')");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Gender = table.Column<string>(type: "char(1)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AccessTokenExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RefreshTokenExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.CheckConstraint("CK_User_Balance", "[Balance] >= 0 AND [Balance] < 100000000");
                    table.CheckConstraint("CK_User_Email", "CHARINDEX('@', [Email]) > 0");
                    table.CheckConstraint("CK_User_EmailFormat", "PATINDEX('%_@__%.__%', [Email]) > 0");
                    table.CheckConstraint("CK_User_Gender", "[Gender] IN ('M', 'F')");
                    table.ForeignKey(
                        name: "FK_Users_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    DoneAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTransfers", x => x.Id);
                    table.CheckConstraint("CK_CategoryTransfer_Amount", "[Amount] > -100000 AND [Amount] < 100000 AND [Amount] <> 0");
                    table.ForeignKey(
                        name: "FK_CategoryTransfers_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryTransfers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invitations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFromId = table.Column<int>(type: "int", nullable: false),
                    UserToId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitations", x => x.Id);
                    table.CheckConstraint("CK_Invitation_NotEqual", "[UserFromId] <> [UserToId]");
                    table.ForeignKey(
                        name: "FK_Invitations_Users_UserFromId",
                        column: x => x.UserFromId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invitations_Users_UserToId",
                        column: x => x.UserToId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFromId = table.Column<int>(type: "int", nullable: false),
                    UserToId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    DoneAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTransfers", x => x.Id);
                    table.CheckConstraint("CK_UserTransfer_Amount", "[Amount] > 0 AND [Amount] < 100000");
                    table.ForeignKey(
                        name: "FK_UserTransfers_Users_UserFromId",
                        column: x => x.UserFromId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTransfers_Users_UserToId",
                        column: x => x.UserToId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Заработная плата", "I" },
                    { 2, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Премия", "I" },
                    { 3, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Пенсия", "I" },
                    { 4, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Продуктовый магазин", "E" },
                    { 5, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Хозтовары", "E" },
                    { 6, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Подписка на музыкальный сервис", "E" },
                    { 7, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Магазин электроники", "E" },
                    { 8, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Магазин сантехники", "E" },
                    { 9, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Кафе/Ресторан", "E" },
                    { 10, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Услуги ЖКХ", "E" },
                    { 11, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Бензин", "E" },
                    { 12, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Общественный транспорт", "E" },
                    { 13, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Такси", "E" },
                    { 14, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Посещение врача", "E" },
                    { 15, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Лекарства", "E" },
                    { 16, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Одежда", "E" },
                    { 17, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Учебное заведение", "E" },
                    { 18, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Образование(книги/курсы/т.п.)", "E" },
                    { 19, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Развлечение(кино/концерты/т.п.)", "E" },
                    { 20, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Личные расходы", "E" },
                    { 21, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Хобби", "E" },
                    { 22, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Красота и уход за собой", "E" },
                    { 23, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Проценты по кредитам", "E" },
                    { 24, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Подарки", "B" },
                    { 25, new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), "Другое", "B" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(2567), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(2567), "TeamMember" },
                    { 2, new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(2567), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(2567), "TeamLeader" },
                    { 3, new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(2567), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(2567), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(5281), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(5281), "Группа 1" },
                    { 2, new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(5281), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(5281), "Группа 2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessToken", "AccessTokenExpirationDate", "Balance", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "ModifiedAt", "Password", "RefreshToken", "RefreshTokenExpirationDate", "TeamId", "UserName" },
                values: new object[,]
                {
                    { 1, null, null, 10000m, new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320), "usikov_konstantin@mail.ru", true, "Константин", "M", "Усиков", new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320), "03D1F6545E6426DDEC4797280867E2F14593E0FB38DD6BF190773139DCE58D92:E1C74E1AEB5D8308D160474C6E2C274E:50000:SHA256", null, null, 1, "Konstantin" },
                    { 2, null, null, 20000m, new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320), "orlov_dmitry@yandex.ru", true, "Дмитрий", "M", "Орлов", new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320), "41998DC78F605A001090203007F3F7341D46BE392229F82263C753B712BB57D5:2365F9A998AE23EBC65EAB8BAD005458:50000:SHA256", null, null, 1, "Dmitry" },
                    { 3, null, null, 30000m, new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320), "ivanov_artyom@gmail.com", true, "Артем", "M", "Иванов", new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320), "AC74B05E1B544764C0E33E0D4574A5E29C629AF5D22394B7308789DE59F054F3:9FD58EBE4CB968212D9F0117466A77CC:50000:SHA256", null, null, 1, "Artyom" },
                    { 4, null, null, 40000m, new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320), "smirnova_maria@mail.ru", true, "Мария", "F", "Смирнова", new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320), "D9507B7FD5AF9880B37D6926354AB29CA7B313891BE5A3E9B851A4BF6E32BDCD:0E08FF50E2205404163CE192B957FA60:50000:SHA256", null, null, 2, "Maria" }
                });

            migrationBuilder.InsertData(
                table: "CategoryTransfers",
                columns: new[] { "Id", "Amount", "CategoryId", "CreatedAt", "Description", "DoneAt", "ModifiedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 10000m, 1, new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), "Описание 1", new DateTime(2024, 1, 10, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), 1 },
                    { 2, 5000m, 2, new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), "Описание 2", new DateTime(2024, 1, 5, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), 1 },
                    { 3, -1000m, 12, new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), "Описание 3", new DateTime(2023, 12, 31, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), 2 },
                    { 4, -800m, 13, new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), "Описание 4", new DateTime(2023, 12, 26, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), 4 }
                });

            migrationBuilder.InsertData(
                table: "Invitations",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserFromId", "UserToId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(7581), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(7581), 4, 1 },
                    { 2, new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(7581), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(7581), 4, 2 },
                    { 3, new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(7581), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(7581), 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedAt", "ModifiedAt" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944), new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944) },
                    { 1, 2, new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944), new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944) },
                    { 1, 3, new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944), new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944) },
                    { 2, 4, new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944), new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944) }
                });

            migrationBuilder.InsertData(
                table: "UserTransfers",
                columns: new[] { "Id", "Amount", "CreatedAt", "Description", "DoneAt", "ModifiedAt", "UserFromId", "UserToId" },
                values: new object[,]
                {
                    { 1, 250m, new DateTime(2024, 1, 15, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), "Описание 1", new DateTime(2024, 1, 10, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), new DateTime(2024, 1, 15, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), 1, 2 },
                    { 2, 500m, new DateTime(2024, 1, 15, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), "Описание 2", new DateTime(2024, 1, 5, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), new DateTime(2024, 1, 15, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), 4, 3 },
                    { 3, 700m, new DateTime(2024, 1, 15, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), "Описание 3", new DateTime(2023, 12, 31, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), new DateTime(2024, 1, 15, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTransfers_CategoryId",
                table: "CategoryTransfers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTransfers_UserId",
                table: "CategoryTransfers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_UserFromId_UserToId",
                table: "Invitations",
                columns: new[] { "UserFromId", "UserToId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invitations_UserToId",
                table: "Invitations",
                column: "UserToId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TeamId",
                table: "Users",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTransfers_UserFromId",
                table: "UserTransfers",
                column: "UserFromId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTransfers_UserToId",
                table: "UserTransfers",
                column: "UserToId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTransfers");

            migrationBuilder.DropTable(
                name: "Invitations");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTransfers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
