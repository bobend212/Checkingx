using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkingx.Server.Migrations
{
    public partial class StatusAddedToCheckingInsteadBooleans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsError",
                table: "Checking");

            migrationBuilder.DropColumn(
                name: "IsFixed",
                table: "Checking");

            migrationBuilder.DropColumn(
                name: "IsNA",
                table: "Checking");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Checking",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Checking");

            migrationBuilder.AddColumn<bool>(
                name: "IsError",
                table: "Checking",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFixed",
                table: "Checking",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNA",
                table: "Checking",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
