using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkingx.Server.Migrations
{
    public partial class ProjectEntityUpdatedCheckingPriority : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CheckingPriority",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckingPriority",
                table: "Projects");
        }
    }
}
