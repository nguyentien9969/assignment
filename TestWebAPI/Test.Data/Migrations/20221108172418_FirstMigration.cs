using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => new { x.BooksId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_BookCategories_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategories_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestStatus = table.Column<int>(type: "int", nullable: false),
                    AprovedBy = table.Column<int>(type: "int", nullable: true),
                    RequestedBy = table.Column<int>(type: "int", nullable: true),
                    RequestAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApproveAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookBorrowRequest_Persons_AprovedBy",
                        column: x => x.AprovedBy,
                        principalTable: "Persons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookBorrowRequest_Persons_RequestedBy",
                        column: x => x.RequestedBy,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookBorrowRequestDetails",
                columns: table => new
                {
                    BookBorrowRequestsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowRequestDetails", x => new { x.BookBorrowRequestsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_BookBorrowRequestDetails_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBorrowRequestDetails_BookBorrowRequest_BookBorrowRequestsId",
                        column: x => x.BookBorrowRequestsId,
                        principalTable: "BookBorrowRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Conan" },
                    { 2, null, "Doraemon" },
                    { 3, null, "GT1" },
                    { 4, null, "Phan tich thiet ke" },
                    { 5, null, "C#" },
                    { 6, null, "Java" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Comic" },
                    { 2, null, "Science" },
                    { 3, null, "Math" },
                    { 4, null, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Nguyen Tien", "pass1", 0, "user1" },
                    { 2, "Bui Ngoc", "pass2", 0, "user2" },
                    { 3, "Ngoc Anh", "pass3", 1, "user3" },
                    { 4, "Anh Tuan", "pass4", 1, "user4" }
                });

            migrationBuilder.InsertData(
                table: "BookBorrowRequest",
                columns: new[] { "Id", "ApproveAt", "AprovedBy", "RequestAt", "RequestStatus", "RequestedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2022, 11, 9, 0, 24, 17, 864, DateTimeKind.Local).AddTicks(1171), 0, 1 },
                    { 2, new DateTime(2022, 11, 9, 0, 24, 17, 864, DateTimeKind.Local).AddTicks(1183), 3, new DateTime(2022, 11, 9, 0, 24, 17, 864, DateTimeKind.Local).AddTicks(1182), 1, 1 },
                    { 3, new DateTime(2022, 11, 9, 0, 24, 17, 864, DateTimeKind.Local).AddTicks(1184), 4, new DateTime(2022, 11, 9, 0, 24, 17, 864, DateTimeKind.Local).AddTicks(1184), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "BookCategories",
                columns: new[] { "BooksId", "CategoriesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 4, 3 },
                    { 5, 3 },
                    { 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "BookBorrowRequestDetails",
                columns: new[] { "BookBorrowRequestsId", "BooksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowRequest_AprovedBy",
                table: "BookBorrowRequest",
                column: "AprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowRequest_RequestedBy",
                table: "BookBorrowRequest",
                column: "RequestedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowRequestDetails_BooksId",
                table: "BookBorrowRequestDetails",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategories_CategoriesId",
                table: "BookCategories",
                column: "CategoriesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrowRequestDetails");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "BookBorrowRequest");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
