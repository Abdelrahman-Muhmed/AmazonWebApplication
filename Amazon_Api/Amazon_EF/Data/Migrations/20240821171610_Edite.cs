using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amazon_EF.Data.Migrations
{
    /// <inheritdoc />
    public partial class Edite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_productItemOreder_orderid",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_productItemOreder_orderid",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "productItemOreder_orderid",
                table: "OrderItem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productItemOreder_orderid",
                table: "OrderItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_productItemOreder_orderid",
                table: "OrderItem",
                column: "productItemOreder_orderid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_productItemOreder_orderid",
                table: "OrderItem",
                column: "productItemOreder_orderid",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
