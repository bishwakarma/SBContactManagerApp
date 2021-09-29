using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SBContactManager.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 4, "Other" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2021, 9, 29, 13, 12, 45, 542, DateTimeKind.Local).AddTicks(7048));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2021, 9, 29, 13, 12, 45, 547, DateTimeKind.Local).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2021, 9, 29, 13, 12, 45, 547, DateTimeKind.Local).AddTicks(8539));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

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
    }
}
