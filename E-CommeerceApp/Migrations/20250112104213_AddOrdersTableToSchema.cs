using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_CommeerceApp.Migrations
{
    /// <inheritdoc />
    public partial class AddOrdersTableToSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "OrderID",
                schema: "Product");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Product",
                columns: table => new
                {
                    OrdereID = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR Product.OrderID"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductID = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<int>(type: "int", nullable: false),
                    OrderData = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrdereID);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductsProductID",
                        column: x => x.ProductsProductID,
                        principalSchema: "Product",
                        principalTable: "Products",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductsProductID",
                schema: "Product",
                table: "Orders",
                column: "ProductsProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Product");

            migrationBuilder.DropSequence(
                name: "OrderID",
                schema: "Product");
        }
    }
}
