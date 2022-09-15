using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkingx.Server.Migrations
{
    public partial class SchemaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checkings_Projects_ProjectId",
                table: "Checkings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checkings",
                table: "Checkings");

            migrationBuilder.RenameTable(
                name: "Checkings",
                newName: "Checking");

            migrationBuilder.RenameIndex(
                name: "IX_Checkings_ProjectId",
                table: "Checking",
                newName: "IX_Checking_ProjectId");

            migrationBuilder.AddColumn<bool>(
                name: "FoundError",
                table: "Checking",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ignored",
                table: "Checking",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checking",
                table: "Checking",
                column: "CheckingId");

            migrationBuilder.CreateTable(
                name: "CheckItems",
                columns: table => new
                {
                    CheckItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckItems", x => x.CheckItemId);
                });

            migrationBuilder.InsertData(
                table: "CheckItems",
                columns: new[] { "CheckItemId", "Category", "Priority", "Title" },
                values: new object[] { 1, "SLAB", 3, "Ensure slab follows outline of ground floor." });

            migrationBuilder.InsertData(
                table: "CheckItems",
                columns: new[] { "CheckItemId", "Category", "Priority", "Title" },
                values: new object[] { 2, "SLAB", 2, "Batten line is not shown on slab." });

            migrationBuilder.InsertData(
                table: "CheckItems",
                columns: new[] { "CheckItemId", "Category", "Priority", "Title" },
                values: new object[] { 3, "SLAB", 3, "All load bearing walls are indicated." });

            migrationBuilder.InsertData(
                table: "CheckItems",
                columns: new[] { "CheckItemId", "Category", "Priority", "Title" },
                values: new object[] { 4, "ROOF", 1, "All internal and external walls dimensioned and dimensions are accurate." });

            migrationBuilder.InsertData(
                table: "CheckItems",
                columns: new[] { "CheckItemId", "Category", "Priority", "Title" },
                values: new object[] { 5, "PANELS", 1, "Cross dimensions are shown." });

            migrationBuilder.InsertData(
                table: "CheckItems",
                columns: new[] { "CheckItemId", "Category", "Priority", "Title" },
                values: new object[] { 6, "PANELS", 2, "Point load symbols shown and dimensioned. Point loads are split for joinery" });

            migrationBuilder.InsertData(
                table: "CheckItems",
                columns: new[] { "CheckItemId", "Category", "Priority", "Title" },
                values: new object[] { 7, "PANELS", 3, "All point loads end up on a sufficient beam or a load bearing wall." });

            migrationBuilder.InsertData(
                table: "CheckItems",
                columns: new[] { "CheckItemId", "Category", "Priority", "Title" },
                values: new object[] { 8, "FLOOR", 1, "Portal panel shoes shown and dimensioned. Note added to ensure coursing blocks are left out where the shoe is positioned." });

            migrationBuilder.InsertData(
                table: "CheckItems",
                columns: new[] { "CheckItemId", "Category", "Priority", "Title" },
                values: new object[] { 9, "FLOOR", 1, "Slab edge distance and spacing between bolts connecting portal frames/steel posts are correct." });

            migrationBuilder.InsertData(
                table: "CheckItems",
                columns: new[] { "CheckItemId", "Category", "Priority", "Title" },
                values: new object[] { 10, "PANELS", 2, "If step in slab level appears, it is clearly indicated and detail is added." });

            migrationBuilder.CreateIndex(
                name: "IX_Checking_CheckItemId",
                table: "Checking",
                column: "CheckItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checking_CheckItems_CheckItemId",
                table: "Checking",
                column: "CheckItemId",
                principalTable: "CheckItems",
                principalColumn: "CheckItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checking_Projects_ProjectId",
                table: "Checking",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checking_CheckItems_CheckItemId",
                table: "Checking");

            migrationBuilder.DropForeignKey(
                name: "FK_Checking_Projects_ProjectId",
                table: "Checking");

            migrationBuilder.DropTable(
                name: "CheckItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checking",
                table: "Checking");

            migrationBuilder.DropIndex(
                name: "IX_Checking_CheckItemId",
                table: "Checking");

            migrationBuilder.DropColumn(
                name: "FoundError",
                table: "Checking");

            migrationBuilder.DropColumn(
                name: "Ignored",
                table: "Checking");

            migrationBuilder.RenameTable(
                name: "Checking",
                newName: "Checkings");

            migrationBuilder.RenameIndex(
                name: "IX_Checking_ProjectId",
                table: "Checkings",
                newName: "IX_Checkings_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checkings",
                table: "Checkings",
                column: "CheckingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checkings_Projects_ProjectId",
                table: "Checkings",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
