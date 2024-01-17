using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManager.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CascadeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822), new DateTime(2024, 1, 17, 9, 49, 40, 327, DateTimeKind.Utc).AddTicks(9822) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(3439), new DateTime(2024, 1, 12, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(3439), new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(3439) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(3439), new DateTime(2024, 1, 7, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(3439), new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(3439) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(3439), new DateTime(2024, 1, 2, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(3439), new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(3439) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(3439), new DateTime(2023, 12, 28, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(3439), new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(3439) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(8852), new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(8852) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(8852), new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(8852) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(8852), new DateTime(2024, 1, 17, 9, 49, 40, 328, DateTimeKind.Utc).AddTicks(8852) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(3823), new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(3823) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(3823), new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(3823) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(3823), new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(3823) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(6517), new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(6517) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(6517), new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(6517) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 333, DateTimeKind.Utc).AddTicks(4634), new DateTime(2024, 1, 17, 9, 49, 40, 333, DateTimeKind.Utc).AddTicks(4634) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 333, DateTimeKind.Utc).AddTicks(4634), new DateTime(2024, 1, 17, 9, 49, 40, 333, DateTimeKind.Utc).AddTicks(4634) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 333, DateTimeKind.Utc).AddTicks(4634), new DateTime(2024, 1, 17, 9, 49, 40, 333, DateTimeKind.Utc).AddTicks(4634) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 333, DateTimeKind.Utc).AddTicks(4634), new DateTime(2024, 1, 17, 9, 49, 40, 333, DateTimeKind.Utc).AddTicks(4634) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 334, DateTimeKind.Utc).AddTicks(4176), new DateTime(2024, 1, 12, 9, 49, 40, 334, DateTimeKind.Utc).AddTicks(4176), new DateTime(2024, 1, 17, 9, 49, 40, 334, DateTimeKind.Utc).AddTicks(4176) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 334, DateTimeKind.Utc).AddTicks(4176), new DateTime(2024, 1, 7, 9, 49, 40, 334, DateTimeKind.Utc).AddTicks(4176), new DateTime(2024, 1, 17, 9, 49, 40, 334, DateTimeKind.Utc).AddTicks(4176) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 334, DateTimeKind.Utc).AddTicks(4176), new DateTime(2024, 1, 2, 9, 49, 40, 334, DateTimeKind.Utc).AddTicks(4176), new DateTime(2024, 1, 17, 9, 49, 40, 334, DateTimeKind.Utc).AddTicks(4176) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(8567), new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(8567) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(8567), new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(8567) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(8567), new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(8567) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(8567), new DateTime(2024, 1, 17, 9, 49, 40, 332, DateTimeKind.Utc).AddTicks(8567) });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(5192) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(9043), new DateTime(2024, 1, 12, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(9043), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(9043) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(9043), new DateTime(2024, 1, 7, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(9043), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(9043) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(9043), new DateTime(2024, 1, 2, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(9043), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(9043) });

            migrationBuilder.UpdateData(
                table: "CategoryTransfers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(9043), new DateTime(2023, 12, 28, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(9043), new DateTime(2024, 1, 17, 8, 19, 34, 68, DateTimeKind.Utc).AddTicks(9043) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 69, DateTimeKind.Utc).AddTicks(4915), new DateTime(2024, 1, 17, 8, 19, 34, 69, DateTimeKind.Utc).AddTicks(4915) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 69, DateTimeKind.Utc).AddTicks(4915), new DateTime(2024, 1, 17, 8, 19, 34, 69, DateTimeKind.Utc).AddTicks(4915) });

            migrationBuilder.UpdateData(
                table: "Invitations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 69, DateTimeKind.Utc).AddTicks(4915), new DateTime(2024, 1, 17, 8, 19, 34, 69, DateTimeKind.Utc).AddTicks(4915) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(109), new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(109) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(109), new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(109) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(109), new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(109) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(2679), new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(2679) });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(2679), new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(2679) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 1 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(955), new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(955), new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 3 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(955), new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(955), new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(9730), new DateTime(2024, 1, 12, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(9730), new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(9730) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(9730), new DateTime(2024, 1, 7, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(9730), new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(9730) });

            migrationBuilder.UpdateData(
                table: "UserTransfers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "DoneAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(9730), new DateTime(2024, 1, 2, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(9730), new DateTime(2024, 1, 17, 8, 19, 34, 74, DateTimeKind.Utc).AddTicks(9730) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(4688), new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(4688) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(4688), new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(4688) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(4688), new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(4688) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(4688), new DateTime(2024, 1, 17, 8, 19, 34, 73, DateTimeKind.Utc).AddTicks(4688) });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
