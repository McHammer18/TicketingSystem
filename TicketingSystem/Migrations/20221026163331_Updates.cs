using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketingSystem.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: "inProgress");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: "qa");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: "toDo");

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[] { "checkin", "Checking In" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[] { "IR", "In Race" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[] { "waiting", "Wating to Start" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: "checkin");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: "IR");

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "StatusId",
                keyValue: "waiting");

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[] { "inProgress", "In Progress" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[] { "qa", "Quality Assurance" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[] { "toDo", "To Do" });
        }
    }
}
