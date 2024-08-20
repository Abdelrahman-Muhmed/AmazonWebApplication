using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Amazon_EF.Data
{
    /// <inheritdoc />
    public partial class EditeDBSetName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PK_orderItem",
                table: "orderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_deliveryMethods",
                table: "deliveryMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "orderItem",
                newName: "OrderItem");

            migrationBuilder.RenameTable(
                name: "deliveryMethods",
                newName: "DeliveryMethods");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_orderItem_productItemOreder_orderid",
                table: "OrderItem",
                newName: "IX_OrderItem_productItemOreder_orderid");

            migrationBuilder.RenameIndex(
                name: "IX_orderItem_Orderid",
                table: "OrderItem",
                newName: "IX_OrderItem_Orderid");

            migrationBuilder.RenameIndex(
                name: "IX_orders_deliveryMethodId",
                table: "Order",
                newName: "IX_Order_deliveryMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeliveryMethods",
                table: "DeliveryMethods",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_DeliveryMethods_deliveryMethodId",
                table: "Order",
                column: "deliveryMethodId",
                principalTable: "DeliveryMethods",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_Orderid",
                table: "OrderItem",
                column: "Orderid",
                principalTable: "Order",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_productItemOreder_orderid",
                table: "OrderItem",
                column: "productItemOreder_orderid",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_DeliveryMethods_deliveryMethodId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_Orderid",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_productItemOreder_orderid",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeliveryMethods",
                table: "DeliveryMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "orderItem");

            migrationBuilder.RenameTable(
                name: "DeliveryMethods",
                newName: "deliveryMethods");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_productItemOreder_orderid",
                table: "orderItem",
                newName: "IX_orderItem_productItemOreder_orderid");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_Orderid",
                table: "orderItem",
                newName: "IX_orderItem_Orderid");

            migrationBuilder.RenameIndex(
                name: "IX_Order_deliveryMethodId",
                table: "orders",
                newName: "IX_orders_deliveryMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderItem",
                table: "orderItem",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deliveryMethods",
                table: "deliveryMethods",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
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
    }
}
