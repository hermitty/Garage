using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage.Infrastructure.Migrations
{
    public partial class workrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Active", "AddressEmail", "Login", "Name", "Password", "Role", "Surname" },
                values: new object[] { 2, false, null, null, "Worker1", null, 0, null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Active", "AddressEmail", "Login", "Name", "Password", "Role", "Surname" },
                values: new object[] { 3, false, null, null, "Worker2", null, 0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
