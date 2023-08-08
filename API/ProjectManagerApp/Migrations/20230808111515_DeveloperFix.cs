using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerApp.Migrations
{
    public partial class DeveloperFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Developers_DeveloperId",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2023, 9, 8, 11, 15, 14, 751, DateTimeKind.Utc).AddTicks(4954));

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
                column: "Deadline",
                value: new DateTime(2023, 9, 12, 11, 15, 14, 751, DateTimeKind.Utc).AddTicks(4961));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deadline",
                value: new DateTime(2023, 10, 7, 11, 15, 14, 751, DateTimeKind.Utc).AddTicks(4962));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deadline",
                value: new DateTime(2023, 10, 7, 11, 15, 14, 751, DateTimeKind.Utc).AddTicks(4963));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Deadline",
                value: new DateTime(2023, 11, 6, 11, 15, 14, 751, DateTimeKind.Utc).AddTicks(4964));

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Developers_DeveloperId",
                table: "Tasks",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Developers_DeveloperId",
                table: "Tasks");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Developers_DeveloperId",
                table: "Tasks",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
