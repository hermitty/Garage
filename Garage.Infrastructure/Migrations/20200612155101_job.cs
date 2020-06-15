using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage.Infrastructure.Migrations
{
    public partial class job : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_User_AssigneeId",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Vehicle_VehicleId",
                table: "Task");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Task",
                table: "Task");

            migrationBuilder.RenameTable(
                name: "Task",
                newName: "Job");

            migrationBuilder.RenameIndex(
                name: "IX_Task_VehicleId",
                table: "Job",
                newName: "IX_Job_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_AssigneeId",
                table: "Job",
                newName: "IX_Job_AssigneeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Job",
                table: "Job",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_User_AssigneeId",
                table: "Job",
                column: "AssigneeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Vehicle_VehicleId",
                table: "Job",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_User_AssigneeId",
                table: "Job");

            migrationBuilder.DropForeignKey(
                name: "FK_Job_Vehicle_VehicleId",
                table: "Job");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Job",
                table: "Job");

            migrationBuilder.RenameTable(
                name: "Job",
                newName: "Task");

            migrationBuilder.RenameIndex(
                name: "IX_Job_VehicleId",
                table: "Task",
                newName: "IX_Task_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Job_AssigneeId",
                table: "Task",
                newName: "IX_Task_AssigneeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Task",
                table: "Task",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_User_AssigneeId",
                table: "Task",
                column: "AssigneeId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Vehicle_VehicleId",
                table: "Task",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
