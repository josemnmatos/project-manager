using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerApp.Migrations
{
    public partial class AddedTokenToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2023, 9, 8, 14, 42, 36, 557, DateTimeKind.Utc).AddTicks(4343));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2023, 9, 8, 14, 42, 36, 557, DateTimeKind.Utc).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2023, 9, 12, 14, 42, 36, 557, DateTimeKind.Utc).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deadline",
                value: new DateTime(2023, 10, 7, 14, 42, 36, 557, DateTimeKind.Utc).AddTicks(4350));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deadline",
                value: new DateTime(2023, 10, 7, 14, 42, 36, 557, DateTimeKind.Utc).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Deadline",
                value: new DateTime(2023, 11, 6, 14, 42, 36, 557, DateTimeKind.Utc).AddTicks(4351));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2023, 9, 8, 11, 21, 22, 733, DateTimeKind.Utc).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2023, 9, 8, 11, 21, 22, 733, DateTimeKind.Utc).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2023, 9, 12, 11, 21, 22, 733, DateTimeKind.Utc).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deadline",
                value: new DateTime(2023, 10, 7, 11, 21, 22, 733, DateTimeKind.Utc).AddTicks(50));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deadline",
                value: new DateTime(2023, 10, 7, 11, 21, 22, 733, DateTimeKind.Utc).AddTicks(50));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Deadline",
                value: new DateTime(2023, 11, 6, 11, 21, 22, 733, DateTimeKind.Utc).AddTicks(51));
        }
    }
}
