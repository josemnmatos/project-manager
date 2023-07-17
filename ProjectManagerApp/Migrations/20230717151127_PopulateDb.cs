using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerApp.Migrations
{
    public partial class PopulateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 2, "markdev@email.com", "Mark", "passwordmark" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 3, "annadev@email.com", "Anna", "passwordanna" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "johnmanager@email.com", "John", "password" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Budget", "ManagerId", "Name" },
                values: new object[] { 1, 100.0, 1, "Calculator" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Budget", "ManagerId", "Name" },
                values: new object[] { 2, 5000.0, 1, "Weather App" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Deadline", "Description", "DeveloperId", "Name", "ProjectId", "State" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 17, 15, 11, 26, 793, DateTimeKind.Utc).AddTicks(8267), "Build buttons and outer interface", 2, "Build Interface", 1, 2 },
                    { 2, new DateTime(2023, 8, 17, 15, 11, 26, 793, DateTimeKind.Utc).AddTicks(8273), "Build logic for the sum operation", 2, "Make sum logic", 1, 2 },
                    { 3, new DateTime(2023, 8, 21, 15, 11, 26, 793, DateTimeKind.Utc).AddTicks(8274), "Build logic for the multiplication operation", 3, "Make multiplication logic", 1, 2 },
                    { 4, new DateTime(2023, 9, 15, 15, 11, 26, 793, DateTimeKind.Utc).AddTicks(8275), "Integrate App with an Weather API", 3, "Integrate Weather API", 2, 3 },
                    { 5, new DateTime(2023, 9, 15, 15, 11, 26, 793, DateTimeKind.Utc).AddTicks(8276), "Build a search bar for user search", 2, "Make a search bar", 2, 2 },
                    { 6, new DateTime(2023, 10, 15, 15, 11, 26, 793, DateTimeKind.Utc).AddTicks(8276), "Deploy app online", 3, "Deploy app", 2, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
