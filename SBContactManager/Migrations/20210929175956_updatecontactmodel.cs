using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBContactManager.Migrations
{
    public partial class updatecontactmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2021, 9, 29, 11, 59, 55, 47, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2021, 9, 29, 11, 59, 55, 52, DateTimeKind.Local).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2021, 9, 29, 11, 59, 55, 52, DateTimeKind.Local).AddTicks(6386));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2021, 9, 28, 13, 7, 39, 321, DateTimeKind.Local).AddTicks(3242));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2021, 9, 28, 13, 7, 39, 326, DateTimeKind.Local).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2021, 9, 28, 13, 7, 39, 326, DateTimeKind.Local).AddTicks(5192));
        }
    }
}
