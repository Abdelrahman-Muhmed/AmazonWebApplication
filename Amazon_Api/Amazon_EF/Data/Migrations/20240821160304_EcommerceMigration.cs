using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amazon_EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class EcommerceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryMethod",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cost = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    DeliveryTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethod", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductBrand",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrand", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ByerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    orderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shippingAdress_firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shippingAdress_lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shippingAdress_street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shippingAdress_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shippingAdress_country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deliveryMethodId = table.Column<int>(type: "int", nullable: false),
                    subTotal = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    paymentIntedId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_DeliveryMethod_deliveryMethodId",
                        column: x => x.deliveryMethodId,
                        principalTable: "DeliveryMethod",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_ProductBrand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "ProductBrand",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    productItemOreder_productId = table.Column<int>(type: "int", nullable: false),
                    productItemOreder_productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productItemOreder_picturelUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productItemOreder_orderid = table.Column<int>(type: "int", nullable: true),
                    Orderid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_Orderid",
                        column: x => x.Orderid,
                        principalTable: "Order",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_productItemOreder_orderid",
                        column: x => x.productItemOreder_orderid,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_deliveryMethodId",
                table: "Order",
                column: "deliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_Orderid",
                table: "OrderItem",
                column: "Orderid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_productItemOreder_orderid",
                table: "OrderItem",
                column: "productItemOreder_orderid");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ProductBrand");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "DeliveryMethod");
        }
    }
}
