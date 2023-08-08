using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagerApp.Migrations
{
    public partial class role_separation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Managers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Managers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Developers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Developers",
                newName: "FirstName");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Managers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Developers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName", "UserId" },
                values: new object[] { "annadev@email.com", "Anna", "Peters", 3 });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "UserId" },
                values: new object[] { 1, "jmarkdev@email.com", "Mark", "Anthony", 2 });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastName", "UserId" },
                values: new object[] { "Marks", 1 });

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "John", "Marks", "johnmanager@email.com", "password", "manager" },
                    { 2, "Mark", "Anthony", "markdev@email.com", "passwordmark", "developer" },
                    { 3, "Anna", "Peters", "annadev@email.com", "passwordanna", "developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Developers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Managers",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Managers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Developers",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Developers",
                newName: "Name");

            migrationBuilder.UpdateData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name", "Password" },
                values: new object[] { "markdev@email.com", "Mark", "passwordmark" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 3, "annadev@email.com", "Anna", "passwordanna" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "password");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2023, 8, 17, 15, 11, 26, 793, DateTimeKind.Utc).AddTicks(8267));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2023, 8, 17, 15, 11, 26, 793, DateTimeKind.Utc).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2023, 8, 21, 15, 11, 26, 793, DateTimeKind.Utc).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deadline",
                value: new DateTime(2023, 9, 15, 15, 11, 26, 793, DateTimeKind.Utc).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Deadline",
                value: new DateTime(2023, 9, 15, 15, 11, 26, 793, DateTimeKind.Utc).AddTicks(8276));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Deadline",
                value: new DateTime(2023, 10, 15, 15, 11, 26, 793, DateTimeKind.Utc).AddTicks(8276));
        }
    }
}
