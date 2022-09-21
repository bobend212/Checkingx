using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Checkingx.Server.Migrations
{
    public partial class OrderAddedToCheckItemEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Update",
                table: "Checking",
                newName: "ReviewDate");

            migrationBuilder.RenameColumn(
                name: "Create",
                table: "Checking",
                newName: "CheckDate");

            migrationBuilder.AddColumn<int>(
                name: "OrderNo",
                table: "CheckItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 1,
                column: "Create",
                value: new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 2,
                column: "Create",
                value: new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 3,
                column: "Create",
                value: new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7712));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 4,
                column: "Create",
                value: new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 5,
                column: "Create",
                value: new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7716));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 6,
                column: "Create",
                value: new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7718));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 7,
                column: "Create",
                value: new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7719));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 8,
                column: "Create",
                value: new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 9,
                column: "Create",
                value: new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "CheckItems",
                keyColumn: "CheckItemId",
                keyValue: 10,
                column: "Create",
                value: new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7724));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNo",
                table: "CheckItems");

            migrationBuilder.RenameColumn(
                name: "ReviewDate",
                table: "Checking",
                newName: "Update");

            migrationBuilder.RenameColumn(
                name: "CheckDate",
                table: "Checking",
                newName: "Create");

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
    }
}
