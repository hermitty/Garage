using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage.Infrastructure.Migrations
{
    public partial class scheduled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Task");

            migrationBuilder.AddColumn<DateTime>(
                name: "Scheduled",
                table: "Task",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Scheduled",
                table: "Task");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Task",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
