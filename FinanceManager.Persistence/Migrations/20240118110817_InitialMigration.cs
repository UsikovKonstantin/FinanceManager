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
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: false),
                    RegistrationToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegistrationTokenExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResetPasswordToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ResetPasswordTokenExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChangeEmailToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ChangeEmailTokenExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RefreshTokenExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.CheckConstraint("CK_User_Balance", "[Balance] >= 0 AND [Balance] < 100000000");
                    table.CheckConstraint("CK_User_EmailFormat", "PATINDEX('%_@_%', [Email]) > 0");
                    table.CheckConstraint("CK_User_Gender", "[Gender] IN ('M', 'F')");
                    table.CheckConstraint("CK_User_NewEmailFormat", "PATINDEX('%_@_%', [NewEmail]) > 0");
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
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Заработная плата", "I" },
                    { 2, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Премия", "I" },
                    { 3, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Пенсия", "I" },
                    { 4, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Продуктовый магазин", "E" },
                    { 5, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Хозтовары", "E" },
                    { 6, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Подписка на музыкальный сервис", "E" },
                    { 7, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Магазин электроники", "E" },
                    { 8, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Магазин сантехники", "E" },
                    { 9, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Кафе/Ресторан", "E" },
                    { 10, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Услуги ЖКХ", "E" },
                    { 11, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Бензин", "E" },
                    { 12, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Общественный транспорт", "E" },
                    { 13, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Такси", "E" },
                    { 14, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Посещение врача", "E" },
                    { 15, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Лекарства", "E" },
                    { 16, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Одежда", "E" },
                    { 17, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Учебное заведение", "E" },
                    { 18, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Образование(книги/курсы/т.п.)", "E" },
                    { 19, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Развлечение(кино/концерты/т.п.)", "E" },
                    { 20, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Личные расходы", "E" },
                    { 21, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Хобби", "E" },
                    { 22, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Красота и уход за собой", "E" },
                    { 23, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Проценты по кредитам", "E" },
                    { 24, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Подарки", "B" },
                    { 25, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), "Другое", "B" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(5410), new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(5410), "TeamMember" },
                    { 2, new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(5410), new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(5410), "TeamLeader" },
                    { 3, new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(5410), new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(5410), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(8389), new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(8389), "Группа 1" },
                    { 2, new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(8389), new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(8389), "Группа 2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Balance", "ChangeEmailToken", "ChangeEmailTokenExpirationDate", "CreatedAt", "Email", "FirstName", "Gender", "IsRegistered", "LastName", "ModifiedAt", "NewEmail", "Password", "RefreshToken", "RefreshTokenExpirationDate", "RegistrationToken", "RegistrationTokenExpirationDate", "ResetPasswordToken", "ResetPasswordTokenExpirationDate", "TeamId", "UserName" },
                values: new object[,]
                {
                    { 1, 10000m, null, null, new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552), "usikov_konstantin@mail.ru", "Константин", "M", true, "Усиков", new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552), null, "46BDA4F3691DF3493E8931985FB2073986231F597BD8D1841FFE919CA670EB06:D7A6746090E449C64C85B60FADAE5D2F:50000:SHA256", null, null, null, null, null, null, 1, "Konstantin1" },
                    { 2, 20000m, null, null, new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552), "orlov_dmitry@yandex.ru", "Дмитрий", "M", true, "Орлов", new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552), null, "F77753025D17913EE058E04AC3A62373A4F8564FCEE7C5DC4AD3F1A419238B4E:6641B1A3A8BADF1A30F307179A9A5C0A:50000:SHA256", null, null, null, null, null, null, 1, "Dmitry1" },
                    { 3, 30000m, null, null, new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552), "ivanov_artyom@gmail.com", "Артем", "M", true, "Иванов", new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552), null, "39E7BE9C0432F76FF7E239D3C8C9313270BF2CDC1D5EBDA0474C241F52387CC8:368AEC1394165D87754905CECD02A369:50000:SHA256", null, null, null, null, null, null, 1, "Artyom1" },
                    { 4, 40000m, null, null, new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552), "smirnova_maria@mail.ru", "Мария", "F", true, "Смирнова", new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552), null, "593652F3B10EE726A804C7B74C8C5A5A9E0C7F1E4E135BF1414E92CA5EE6EEFC:FE38DEBEE0E9CC245B5BE4BBC4A0918C:50000:SHA256", null, null, null, null, null, null, 2, "Maria1" }
                });

            migrationBuilder.InsertData(
                table: "CategoryTransfers",
                columns: new[] { "Id", "Amount", "CategoryId", "CreatedAt", "Description", "DoneAt", "ModifiedAt", "UserId" },
                values: new object[,]
                {
                    { 1, 10000m, 1, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), "Описание 1", new DateTime(2024, 1, 13, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), 1 },
                    { 2, 5000m, 2, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), "Описание 2", new DateTime(2024, 1, 8, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), 1 },
                    { 3, -1000m, 12, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), "Описание 3", new DateTime(2024, 1, 3, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), 2 },
                    { 4, -800m, 13, new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), "Описание 4", new DateTime(2023, 12, 29, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), 4 }
                });

            migrationBuilder.InsertData(
                table: "Invitations",
                columns: new[] { "Id", "CreatedAt", "ModifiedAt", "UserFromId", "UserToId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 18, 11, 8, 17, 132, DateTimeKind.Utc).AddTicks(4952), new DateTime(2024, 1, 18, 11, 8, 17, 132, DateTimeKind.Utc).AddTicks(4952), 4, 1 },
                    { 2, new DateTime(2024, 1, 18, 11, 8, 17, 132, DateTimeKind.Utc).AddTicks(4952), new DateTime(2024, 1, 18, 11, 8, 17, 132, DateTimeKind.Utc).AddTicks(4952), 4, 2 },
                    { 3, new DateTime(2024, 1, 18, 11, 8, 17, 132, DateTimeKind.Utc).AddTicks(4952), new DateTime(2024, 1, 18, 11, 8, 17, 132, DateTimeKind.Utc).AddTicks(4952), 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId", "CreatedAt", "ModifiedAt" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439), new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439) },
                    { 1, 2, new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439), new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439) },
                    { 1, 3, new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439), new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439) },
                    { 2, 4, new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439), new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439) }
                });

            migrationBuilder.InsertData(
                table: "UserTransfers",
                columns: new[] { "Id", "Amount", "CreatedAt", "Description", "DoneAt", "ModifiedAt", "UserFromId", "UserToId" },
                values: new object[,]
                {
                    { 1, 250m, new DateTime(2024, 1, 18, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), "Описание 1", new DateTime(2024, 1, 13, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), new DateTime(2024, 1, 18, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), 1, 2 },
                    { 2, 500m, new DateTime(2024, 1, 18, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), "Описание 2", new DateTime(2024, 1, 8, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), new DateTime(2024, 1, 18, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), 4, 3 },
                    { 3, 700m, new DateTime(2024, 1, 18, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), "Описание 3", new DateTime(2024, 1, 3, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), new DateTime(2024, 1, 18, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), 4, 1 }
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
