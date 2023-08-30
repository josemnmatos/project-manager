using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerApp.Migrations
{
    public partial class DeveloperFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Deadline", "DeveloperId" },
                values: new object[] { new DateTime(2023, 9, 8, 11, 21, 22, 733, DateTimeKind.Utc).AddTicks(41), 1 });

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
                columns: new[] { "Deadline", "DeveloperId" },
                values: new object[] { new DateTime(2023, 9, 12, 11, 21, 22, 733, DateTimeKind.Utc).AddTicks(48), 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Deadline", "DeveloperId" },
                values: new object[] { new DateTime(2023, 10, 7, 11, 21, 22, 733, DateTimeKind.Utc).AddTicks(50), 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Deadline", "DeveloperId" },
                values: new object[] { new DateTime(2023, 10, 7, 11, 21, 22, 733, DateTimeKind.Utc).AddTicks(50), 1 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Deadline", "DeveloperId" },
                values: new object[] { new DateTime(2023, 11, 6, 11, 21, 22, 733, DateTimeKind.Utc).AddTicks(51), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Deadline", "DeveloperId" },
                values: new object[] { new DateTime(2023, 9, 8, 11, 15, 14, 751, DateTimeKind.Utc).AddTicks(4954), 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2023, 9, 8, 11, 15, 14, 751, DateTimeKind.Utc).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Deadline", "DeveloperId" },
                values: new object[] { new DateTime(2023, 9, 12, 11, 15, 14, 751, DateTimeKind.Utc).AddTicks(4961), 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Deadline", "DeveloperId" },
                values: new object[] { new DateTime(2023, 10, 7, 11, 15, 14, 751, DateTimeKind.Utc).AddTicks(4962), 3 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Deadline", "DeveloperId" },
                values: new object[] { new DateTime(2023, 10, 7, 11, 15, 14, 751, DateTimeKind.Utc).AddTicks(4963), 2 });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Deadline", "DeveloperId" },
                values: new object[] { new DateTime(2023, 11, 6, 11, 15, 14, 751, DateTimeKind.Utc).AddTicks(4964), 3 });
        }
    }
}
