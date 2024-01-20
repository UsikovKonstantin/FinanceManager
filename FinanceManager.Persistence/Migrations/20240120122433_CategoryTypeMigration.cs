using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CategoryTypeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Category_Type",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Categories",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127), new DateTime(2024, 1, 20, 12, 24, 32, 711, DateTimeKind.Utc).AddTicks(7127) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(406), new DateTime(2024, 1, 15, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(406), new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(406) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(406), new DateTime(2024, 1, 10, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(406), new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(406) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(406), new DateTime(2024, 1, 5, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(406), new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(406) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(406), new DateTime(2023, 12, 31, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(406), new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(406) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(6318), new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(6318) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(6318), new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(6318) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(6318), new DateTime(2024, 1, 20, 12, 24, 32, 712, DateTimeKind.Utc).AddTicks(6318) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(3576), new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(3576) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(3576), new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(3576) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(3576), new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(3576) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(6271), new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(6271) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(6271), new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(6271) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 717, DateTimeKind.Utc).AddTicks(5054), new DateTime(2024, 1, 20, 12, 24, 32, 717, DateTimeKind.Utc).AddTicks(5054) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 717, DateTimeKind.Utc).AddTicks(5054), new DateTime(2024, 1, 20, 12, 24, 32, 717, DateTimeKind.Utc).AddTicks(5054) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 717, DateTimeKind.Utc).AddTicks(5054), new DateTime(2024, 1, 20, 12, 24, 32, 717, DateTimeKind.Utc).AddTicks(5054) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 717, DateTimeKind.Utc).AddTicks(5054), new DateTime(2024, 1, 20, 12, 24, 32, 717, DateTimeKind.Utc).AddTicks(5054) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 718, DateTimeKind.Utc).AddTicks(4302), new DateTime(2024, 1, 15, 12, 24, 32, 718, DateTimeKind.Utc).AddTicks(4302), new DateTime(2024, 1, 20, 12, 24, 32, 718, DateTimeKind.Utc).AddTicks(4302) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 718, DateTimeKind.Utc).AddTicks(4302), new DateTime(2024, 1, 10, 12, 24, 32, 718, DateTimeKind.Utc).AddTicks(4302), new DateTime(2024, 1, 20, 12, 24, 32, 718, DateTimeKind.Utc).AddTicks(4302) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 718, DateTimeKind.Utc).AddTicks(4302), new DateTime(2024, 1, 5, 12, 24, 32, 718, DateTimeKind.Utc).AddTicks(4302), new DateTime(2024, 1, 20, 12, 24, 32, 718, DateTimeKind.Utc).AddTicks(4302) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(8566), new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(8566) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(8566), new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(8566) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(8566), new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(8566) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(8566), new DateTime(2024, 1, 20, 12, 24, 32, 716, DateTimeKind.Utc).AddTicks(8566) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Categories",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(4980) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), new DateTime(2024, 1, 13, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), new DateTime(2024, 1, 8, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), new DateTime(2024, 1, 3, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), new DateTime(2023, 12, 29, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909), new DateTime(2024, 1, 18, 11, 8, 17, 131, DateTimeKind.Utc).AddTicks(8909) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 132, DateTimeKind.Utc).AddTicks(4952), new DateTime(2024, 1, 18, 11, 8, 17, 132, DateTimeKind.Utc).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 132, DateTimeKind.Utc).AddTicks(4952), new DateTime(2024, 1, 18, 11, 8, 17, 132, DateTimeKind.Utc).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 132, DateTimeKind.Utc).AddTicks(4952), new DateTime(2024, 1, 18, 11, 8, 17, 132, DateTimeKind.Utc).AddTicks(4952) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(5410), new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(5410), new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(5410), new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(5410) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(8389), new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(8389) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(8389), new DateTime(2024, 1, 18, 11, 8, 17, 136, DateTimeKind.Utc).AddTicks(8389) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439), new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439), new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439), new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439), new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(7439) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), new DateTime(2024, 1, 13, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), new DateTime(2024, 1, 18, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), new DateTime(2024, 1, 8, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), new DateTime(2024, 1, 18, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), new DateTime(2024, 1, 3, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757), new DateTime(2024, 1, 18, 11, 8, 17, 138, DateTimeKind.Utc).AddTicks(7757) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552), new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552), new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552), new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552), new DateTime(2024, 1, 18, 11, 8, 17, 137, DateTimeKind.Utc).AddTicks(552) });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Category_Type",
                table: "Categories",
                sql: "[Type] IN ('I', 'E', 'B')");
        }
    }
}
