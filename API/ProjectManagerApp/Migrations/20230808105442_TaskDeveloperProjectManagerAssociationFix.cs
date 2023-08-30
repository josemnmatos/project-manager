using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerApp.Migrations
{
    public partial class TaskDeveloperProjectManagerAssociationFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2023, 9, 8, 10, 54, 41, 865, DateTimeKind.Utc).AddTicks(9043));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2023, 9, 8, 10, 54, 41, 865, DateTimeKind.Utc).AddTicks(9048));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2023, 9, 12, 10, 54, 41, 865, DateTimeKind.Utc).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deadline",
                value: new DateTime(2023, 10, 7, 10, 54, 41, 865, DateTimeKind.Utc).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deadline",
                value: new DateTime(2023, 10, 7, 10, 54, 41, 865, DateTimeKind.Utc).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Deadline",
                value: new DateTime(2023, 11, 6, 10, 54, 41, 865, DateTimeKind.Utc).AddTicks(9104));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2023, 9, 8, 10, 52, 1, 150, DateTimeKind.Utc).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2023, 9, 8, 10, 52, 1, 150, DateTimeKind.Utc).AddTicks(3740));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2023, 9, 12, 10, 52, 1, 150, DateTimeKind.Utc).AddTicks(3741));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deadline",
                value: new DateTime(2023, 10, 7, 10, 52, 1, 150, DateTimeKind.Utc).AddTicks(3741));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deadline",
                value: new DateTime(2023, 10, 7, 10, 52, 1, 150, DateTimeKind.Utc).AddTicks(3742));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Deadline",
                value: new DateTime(2023, 11, 6, 10, 52, 1, 150, DateTimeKind.Utc).AddTicks(3743));
        }
    }
}
