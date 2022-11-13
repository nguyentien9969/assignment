using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    public partial class FirstMigrations_fix8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookBorrowRequest",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequestAt",
                value: new DateTime(2022, 11, 9, 1, 36, 17, 882, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "BookBorrowRequest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApproveAt", "RequestAt" },
                values: new object[] { new DateTime(2022, 11, 9, 1, 36, 17, 882, DateTimeKind.Local).AddTicks(7854), new DateTime(2022, 11, 9, 1, 36, 17, 882, DateTimeKind.Local).AddTicks(7853) });

            migrationBuilder.UpdateData(
                table: "BookBorrowRequest",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApproveAt", "RequestAt" },
                values: new object[] { new DateTime(2022, 11, 9, 1, 36, 17, 882, DateTimeKind.Local).AddTicks(7856), new DateTime(2022, 11, 9, 1, 36, 17, 882, DateTimeKind.Local).AddTicks(7855) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookBorrowRequest",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequestAt",
                value: new DateTime(2022, 11, 9, 1, 34, 54, 27, DateTimeKind.Local).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "BookBorrowRequest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApproveAt", "RequestAt" },
                values: new object[] { new DateTime(2022, 11, 9, 1, 34, 54, 27, DateTimeKind.Local).AddTicks(8326), new DateTime(2022, 11, 9, 1, 34, 54, 27, DateTimeKind.Local).AddTicks(8325) });

            migrationBuilder.UpdateData(
                table: "BookBorrowRequest",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApproveAt", "RequestAt" },
                values: new object[] { new DateTime(2022, 11, 9, 1, 34, 54, 27, DateTimeKind.Local).AddTicks(8327), new DateTime(2022, 11, 9, 1, 34, 54, 27, DateTimeKind.Local).AddTicks(8327) });
        }
    }
}
