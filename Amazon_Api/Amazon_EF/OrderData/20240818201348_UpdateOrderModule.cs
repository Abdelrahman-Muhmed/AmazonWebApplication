using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amazon_EF.OrderData
{
    /// <inheritdoc />
    public partial class UpdateOrderModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliveryMethod_deliveryMethodId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_orderItem_Order_Orderid",
                table: "orderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_orderItem_Order_productItemOreder_orderid",
                table: "orderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryMethod",
                table: "DeliveryMethod");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "DeliveryMethod",
                newName: "deliveryMethods");

            migrationBuilder.RenameIndex(
                name: "IX_Order_deliveryMethodId",
                table: "orders",
                newName: "IX_orders_deliveryMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deliveryMethods",
                table: "deliveryMethods",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItem_orders_Orderid",
                table: "orderItem",
                column: "Orderid",
                principalTable: "orders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItem_orders_productItemOreder_orderid",
                table: "orderItem",
                column: "productItemOreder_orderid",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_deliveryMethods_deliveryMethodId",
                table: "orders",
                column: "deliveryMethodId",
                principalTable: "deliveryMethods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItem_orders_Orderid",
                table: "orderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_orderItem_orders_productItemOreder_orderid",
                table: "orderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_deliveryMethods_deliveryMethodId",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_deliveryMethods",
                table: "deliveryMethods");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "deliveryMethods",
                newName: "DeliveryMethod");

            migrationBuilder.RenameIndex(
                name: "IX_orders_deliveryMethodId",
                table: "Order",
                newName: "IX_Order_deliveryMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryMethod",
                table: "DeliveryMethod",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliveryMethod_deliveryMethodId",
                table: "Order",
                column: "deliveryMethodId",
                principalTable: "DeliveryMethod",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderItem_Order_Orderid",
                table: "orderItem",
                column: "Orderid",
                principalTable: "Order",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItem_Order_productItemOreder_orderid",
                table: "orderItem",
                column: "productItemOreder_orderid",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
