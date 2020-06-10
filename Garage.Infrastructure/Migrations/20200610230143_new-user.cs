using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage.Infrastructure.Migrations
{
    public partial class newuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Active", "AddressEmail", "Login", "Name", "Password", "Role", "Surname" },
                values: new object[] { 1, false, null, "admin", null, "12345", 2, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
