using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerApp.Migrations
{
    public partial class roleSeparationFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2023, 9, 7, 14, 6, 7, 740, DateTimeKind.Utc).AddTicks(2269));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2023, 9, 7, 14, 6, 7, 740, DateTimeKind.Utc).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2023, 9, 11, 14, 6, 7, 740, DateTimeKind.Utc).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deadline",
                value: new DateTime(2023, 10, 6, 14, 6, 7, 740, DateTimeKind.Utc).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deadline",
                value: new DateTime(2023, 10, 6, 14, 6, 7, 740, DateTimeKind.Utc).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Deadline",
                value: new DateTime(2023, 11, 5, 14, 6, 7, 740, DateTimeKind.Utc).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "johnmanager@email.com", "John", "Marks" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "markdev@email.com", "Mark", "Anthony" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "annadev@email.com", "Anna", "Peters" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2023, 9, 7, 13, 38, 38, 205, DateTimeKind.Utc).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2023, 9, 7, 13, 38, 38, 205, DateTimeKind.Utc).AddTicks(7406));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2023, 9, 11, 13, 38, 38, 205, DateTimeKind.Utc).AddTicks(7406));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deadline",
                value: new DateTime(2023, 10, 6, 13, 38, 38, 205, DateTimeKind.Utc).AddTicks(7407));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deadline",
                value: new DateTime(2023, 10, 6, 13, 38, 38, 205, DateTimeKind.Utc).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Deadline",
                value: new DateTime(2023, 11, 5, 13, 38, 38, 205, DateTimeKind.Utc).AddTicks(7409));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "John", "Marks", "johnmanager@email.com" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "Mark", "Anthony", "markdev@email.com" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "Anna", "Peters", "annadev@email.com" });
        }
    }
}
