using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkingx.Server.Migrations
{
    public partial class DatesAddedToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Create",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Update",
                table: "Projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Create",
                table: "CheckItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Update",
                table: "CheckItems",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Create",
                table: "Checking",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Update",
                table: "Checking",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 1,
                column: "Create",
                value: new DateTime(2022, 9, 21, 13, 3, 42, 955, DateTimeKind.Local).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 2,
                column: "Create",
                value: new DateTime(2022, 9, 21, 13, 3, 42, 955, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 3,
                column: "Create",
                value: new DateTime(2022, 9, 21, 13, 3, 42, 955, DateTimeKind.Local).AddTicks(9909));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 4,
                column: "Create",
                value: new DateTime(2022, 9, 21, 13, 3, 42, 955, DateTimeKind.Local).AddTicks(9911));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 5,
                column: "Create",
                value: new DateTime(2022, 9, 21, 13, 3, 42, 955, DateTimeKind.Local).AddTicks(9913));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 6,
                column: "Create",
                value: new DateTime(2022, 9, 21, 13, 3, 42, 955, DateTimeKind.Local).AddTicks(9914));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 7,
                column: "Create",
                value: new DateTime(2022, 9, 21, 13, 3, 42, 955, DateTimeKind.Local).AddTicks(9916));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 8,
                column: "Create",
                value: new DateTime(2022, 9, 21, 13, 3, 42, 955, DateTimeKind.Local).AddTicks(9918));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 9,
                column: "Create",
                value: new DateTime(2022, 9, 21, 13, 3, 42, 955, DateTimeKind.Local).AddTicks(9919));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 10,
                column: "Create",
                value: new DateTime(2022, 9, 21, 13, 3, 42, 955, DateTimeKind.Local).AddTicks(9921));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Create",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Update",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Create",
                table: "CheckItems");

            migrationBuilder.DropColumn(
                name: "Update",
                table: "CheckItems");

            migrationBuilder.DropColumn(
                name: "Create",
                table: "Checking");

            migrationBuilder.DropColumn(
                name: "Update",
                table: "Checking");
        }
    }
}
