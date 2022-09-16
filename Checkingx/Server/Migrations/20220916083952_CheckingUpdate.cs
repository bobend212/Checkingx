using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkingx.Server.Migrations
{
    public partial class CheckingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ignored",
                table: "Checking",
                newName: "IsError");

            migrationBuilder.RenameColumn(
                name: "FoundError",
                table: "Checking",
                newName: "IsCorrected");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsError",
                table: "Checking",
                newName: "Ignored");

            migrationBuilder.RenameColumn(
                name: "IsCorrected",
                table: "Checking",
                newName: "FoundError");
        }
    }
}
