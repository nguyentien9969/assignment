using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    public partial class SecondMigartion_ResetData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrowRequest_Persons_AprovedBy",
                table: "BookBorrowRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrowRequest_Persons_RequestedBy",
                table: "BookBorrowRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrowRequest_Person_AprovedBy",
                table: "BookBorrowRequest",
                column: "AprovedBy",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrowRequest_Person_RequestedBy",
                table: "BookBorrowRequest",
                column: "RequestedBy",
                principalTable: "Person",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrowRequest_Person_AprovedBy",
                table: "BookBorrowRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrowRequest_Person_RequestedBy",
                table: "BookBorrowRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrowRequest_Persons_AprovedBy",
                table: "BookBorrowRequest",
                column: "AprovedBy",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrowRequest_Persons_RequestedBy",
                table: "BookBorrowRequest",
                column: "RequestedBy",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
