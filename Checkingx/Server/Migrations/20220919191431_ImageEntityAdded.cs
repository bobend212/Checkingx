using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkingx.Server.Migrations
{
    public partial class ImageEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    CheckingId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Checking_CheckingId",
                        column: x => x.CheckingId,
                        principalTable: "Checking",
                        principalColumn: "CheckingId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_CheckingId",
                table: "Images",
                column: "CheckingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
