using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF2.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProductManufacture = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "Category",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CatId", "CategoryName" },
                values: new object[] { 1, "Computer" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CatId", "CategoryName" },
                values: new object[] { 2, "Mouse" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CatId", "CategoryName" },
                values: new object[] { 3, "Screen" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "ProductCategoryId", "ProductManufacture", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, "VietNam", "A1" },
                    { 2, 1, "China", "A2" },
                    { 3, 2, "China", "A3" },
                    { 4, 2, "China", "B4" },
                    { 5, 3, "China", "B4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
