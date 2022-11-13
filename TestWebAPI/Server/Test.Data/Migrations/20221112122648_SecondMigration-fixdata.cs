using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    public partial class SecondMigrationfixdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookBorrowRequest",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequestAt",
                value: new DateTime(2022, 11, 12, 19, 26, 47, 812, DateTimeKind.Local).AddTicks(3092));

            migrationBuilder.UpdateData(
                table: "BookBorrowRequest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApproveAt", "RequestAt" },
                values: new object[] { new DateTime(2022, 11, 12, 19, 26, 47, 812, DateTimeKind.Local).AddTicks(3104), new DateTime(2022, 11, 12, 19, 26, 47, 812, DateTimeKind.Local).AddTicks(3104) });

            migrationBuilder.UpdateData(
                table: "BookBorrowRequest",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApproveAt", "RequestAt" },
                values: new object[] { new DateTime(2022, 11, 12, 19, 26, 47, 812, DateTimeKind.Local).AddTicks(3106), new DateTime(2022, 11, 12, 19, 26, 47, 812, DateTimeKind.Local).AddTicks(3105) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookBorrowRequest",
                keyColumn: "Id",
                keyValue: 1,
                column: "RequestAt",
                value: new DateTime(2022, 11, 10, 20, 20, 40, 211, DateTimeKind.Local).AddTicks(175));

            migrationBuilder.UpdateData(
                table: "BookBorrowRequest",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApproveAt", "RequestAt" },
                values: new object[] { new DateTime(2022, 11, 10, 20, 20, 40, 211, DateTimeKind.Local).AddTicks(185), new DateTime(2022, 11, 10, 20, 20, 40, 211, DateTimeKind.Local).AddTicks(185) });

            migrationBuilder.UpdateData(
                table: "BookBorrowRequest",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApproveAt", "RequestAt" },
                values: new object[] { new DateTime(2022, 11, 10, 20, 20, 40, 211, DateTimeKind.Local).AddTicks(187), new DateTime(2022, 11, 10, 20, 20, 40, 211, DateTimeKind.Local).AddTicks(186) });
        }
    }
}
