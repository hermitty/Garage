using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage.Infrastructure.Migrations
{
    public partial class d : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Customer_OwnerId1",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_OwnerId1",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ReporterId",
                table: "Task");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_OwnerId",
                table: "Vehicle",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Customer_OwnerId",
                table: "Vehicle",
                column: "OwnerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Customer_OwnerId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_OwnerId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "OwnerId1",
                table: "Vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReporterId",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "Role",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_OwnerId1",
                table: "Vehicle",
                column: "OwnerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Customer_OwnerId1",
                table: "Vehicle",
                column: "OwnerId1",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
