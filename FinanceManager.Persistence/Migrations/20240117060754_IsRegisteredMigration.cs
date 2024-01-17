using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IsRegisteredMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(2148) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(5886), new DateTime(2024, 1, 12, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(5886), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(5886), new DateTime(2024, 1, 7, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(5886), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(5886), new DateTime(2024, 1, 2, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(5886), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(5886), new DateTime(2023, 12, 28, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(5886), new DateTime(2024, 1, 17, 6, 7, 53, 52, DateTimeKind.Utc).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 53, DateTimeKind.Utc).AddTicks(1469), new DateTime(2024, 1, 17, 6, 7, 53, 53, DateTimeKind.Utc).AddTicks(1469) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 53, DateTimeKind.Utc).AddTicks(1469), new DateTime(2024, 1, 17, 6, 7, 53, 53, DateTimeKind.Utc).AddTicks(1469) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 53, DateTimeKind.Utc).AddTicks(1469), new DateTime(2024, 1, 17, 6, 7, 53, 53, DateTimeKind.Utc).AddTicks(1469) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 56, DateTimeKind.Utc).AddTicks(7584), new DateTime(2024, 1, 17, 6, 7, 53, 56, DateTimeKind.Utc).AddTicks(7584) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 56, DateTimeKind.Utc).AddTicks(7584), new DateTime(2024, 1, 17, 6, 7, 53, 56, DateTimeKind.Utc).AddTicks(7584) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 56, DateTimeKind.Utc).AddTicks(7584), new DateTime(2024, 1, 17, 6, 7, 53, 56, DateTimeKind.Utc).AddTicks(7584) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(310), new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(310) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(310), new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(310) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(8988), new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(8988) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(8988), new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(8988) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(8988), new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(8988) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(8988), new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(8988) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 58, DateTimeKind.Utc).AddTicks(8101), new DateTime(2024, 1, 12, 6, 7, 53, 58, DateTimeKind.Utc).AddTicks(8101), new DateTime(2024, 1, 17, 6, 7, 53, 58, DateTimeKind.Utc).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 58, DateTimeKind.Utc).AddTicks(8101), new DateTime(2024, 1, 7, 6, 7, 53, 58, DateTimeKind.Utc).AddTicks(8101), new DateTime(2024, 1, 17, 6, 7, 53, 58, DateTimeKind.Utc).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 58, DateTimeKind.Utc).AddTicks(8101), new DateTime(2024, 1, 2, 6, 7, 53, 58, DateTimeKind.Utc).AddTicks(8101), new DateTime(2024, 1, 17, 6, 7, 53, 58, DateTimeKind.Utc).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsRegistered", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(2388), true, new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(2388) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsRegistered", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(2388), true, new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(2388) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsRegistered", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(2388), true, new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(2388) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "IsRegistered", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(2388), true, new DateTime(2024, 1, 17, 6, 7, 53, 57, DateTimeKind.Utc).AddTicks(2388) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038), new DateTime(2024, 1, 15, 6, 45, 29, 489, DateTimeKind.Utc).AddTicks(8038) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), new DateTime(2024, 1, 10, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), new DateTime(2024, 1, 5, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), new DateTime(2023, 12, 31, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), new DateTime(2023, 12, 26, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(1675) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(7581), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(7581) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(7581), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(7581) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(7581), new DateTime(2024, 1, 15, 6, 45, 29, 490, DateTimeKind.Utc).AddTicks(7581) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(2567), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(2567) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(2567), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(2567) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(2567), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(2567) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(5281), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(5281) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(5281), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(5281) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944), new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944), new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944), new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944), new DateTime(2024, 1, 15, 6, 45, 29, 495, DateTimeKind.Utc).AddTicks(3944) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), new DateTime(2024, 1, 10, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), new DateTime(2024, 1, 15, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), new DateTime(2024, 1, 5, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), new DateTime(2024, 1, 15, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), new DateTime(2023, 12, 31, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627), new DateTime(2024, 1, 15, 6, 45, 29, 496, DateTimeKind.Utc).AddTicks(3627) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320), new DateTime(2024, 1, 15, 6, 45, 29, 494, DateTimeKind.Utc).AddTicks(7320) });
        }
    }
}
