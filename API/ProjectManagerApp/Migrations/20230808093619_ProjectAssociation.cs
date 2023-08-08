using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerApp.Migrations
{
    public partial class ProjectAssociation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2023, 9, 8, 9, 36, 19, 132, DateTimeKind.Utc).AddTicks(4260));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2023, 9, 8, 9, 36, 19, 132, DateTimeKind.Utc).AddTicks(4266));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2023, 9, 12, 9, 36, 19, 132, DateTimeKind.Utc).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deadline",
                value: new DateTime(2023, 10, 7, 9, 36, 19, 132, DateTimeKind.Utc).AddTicks(4267));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deadline",
                value: new DateTime(2023, 10, 7, 9, 36, 19, 132, DateTimeKind.Utc).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Deadline",
                value: new DateTime(2023, 11, 6, 9, 36, 19, 132, DateTimeKind.Utc).AddTicks(4269));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
