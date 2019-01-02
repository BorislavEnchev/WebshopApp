using Microsoft.EntityFrameworkCore.Migrations;

namespace WebshopApp.Data.Migrations
{
    public partial class dbSetsInitialized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientReceipt_AspNetUsers_ClientId",
                table: "ClientReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientReceipt_Receipt_ReceiptId",
                table: "ClientReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_ClientId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_ShipmentData_ShipmentDataId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Order_OrderId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Order_OrderId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_AspNetUsers_CashierId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_AspNetUsers_ClientId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Payment_PaymentId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptOrder_Order_OrderId",
                table: "ReceiptOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptOrder_Receipt_ReceiptId",
                table: "ReceiptOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShipmentData",
                table: "ShipmentData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptOrder",
                table: "ReceiptOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientReceipt",
                table: "ClientReceipt");

            migrationBuilder.RenameTable(
                name: "ShipmentData",
                newName: "ShipmentsDatas");

            migrationBuilder.RenameTable(
                name: "ReceiptOrder",
                newName: "ReceiptsOrders");

            migrationBuilder.RenameTable(
                name: "Receipt",
                newName: "Receipts");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "ClientReceipt",
                newName: "ClientsReceipts");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptOrder_ReceiptId",
                table: "ReceiptsOrders",
                newName: "IX_ReceiptsOrders_ReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptOrder_OrderId",
                table: "ReceiptsOrders",
                newName: "IX_ReceiptsOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_PaymentId",
                table: "Receipts",
                newName: "IX_Receipts_PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_ClientId",
                table: "Receipts",
                newName: "IX_Receipts_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_CashierId",
                table: "Receipts",
                newName: "IX_Receipts_CashierId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_OrderId",
                table: "Payments",
                newName: "IX_Payments_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ShipmentDataId",
                table: "Orders",
                newName: "IX_Orders_ShipmentDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ClientId",
                table: "Orders",
                newName: "IX_Orders_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientReceipt_ReceiptId",
                table: "ClientsReceipts",
                newName: "IX_ClientsReceipts_ReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientReceipt_ClientId",
                table: "ClientsReceipts",
                newName: "IX_ClientsReceipts_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShipmentsDatas",
                table: "ShipmentsDatas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptsOrders",
                table: "ReceiptsOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientsReceipts",
                table: "ClientsReceipts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsReceipts_AspNetUsers_ClientId",
                table: "ClientsReceipts",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientsReceipts_Receipts_ReceiptId",
                table: "ClientsReceipts",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShipmentsDatas_ShipmentDataId",
                table: "Orders",
                column: "ShipmentDataId",
                principalTable: "ShipmentsDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_CashierId",
                table: "Receipts",
                column: "CashierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_AspNetUsers_ClientId",
                table: "Receipts",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Payments_PaymentId",
                table: "Receipts",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptsOrders_Orders_OrderId",
                table: "ReceiptsOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptsOrders_Receipts_ReceiptId",
                table: "ReceiptsOrders",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientsReceipts_AspNetUsers_ClientId",
                table: "ClientsReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientsReceipts_Receipts_ReceiptId",
                table: "ClientsReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShipmentsDatas_ShipmentDataId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_CashierId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_AspNetUsers_ClientId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Payments_PaymentId",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptsOrders_Orders_OrderId",
                table: "ReceiptsOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptsOrders_Receipts_ReceiptId",
                table: "ReceiptsOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShipmentsDatas",
                table: "ShipmentsDatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiptsOrders",
                table: "ReceiptsOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Receipts",
                table: "Receipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payments",
                table: "Payments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientsReceipts",
                table: "ClientsReceipts");

            migrationBuilder.RenameTable(
                name: "ShipmentsDatas",
                newName: "ShipmentData");

            migrationBuilder.RenameTable(
                name: "ReceiptsOrders",
                newName: "ReceiptOrder");

            migrationBuilder.RenameTable(
                name: "Receipts",
                newName: "Receipt");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "Payment");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "ClientsReceipts",
                newName: "ClientReceipt");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptsOrders_ReceiptId",
                table: "ReceiptOrder",
                newName: "IX_ReceiptOrder_ReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceiptsOrders_OrderId",
                table: "ReceiptOrder",
                newName: "IX_ReceiptOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_PaymentId",
                table: "Receipt",
                newName: "IX_Receipt_PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_ClientId",
                table: "Receipt",
                newName: "IX_Receipt_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_CashierId",
                table: "Receipt",
                newName: "IX_Receipt_CashierId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_OrderId",
                table: "Payment",
                newName: "IX_Payment_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ShipmentDataId",
                table: "Order",
                newName: "IX_Order_ShipmentDataId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ClientId",
                table: "Order",
                newName: "IX_Order_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientsReceipts_ReceiptId",
                table: "ClientReceipt",
                newName: "IX_ClientReceipt_ReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientsReceipts_ClientId",
                table: "ClientReceipt",
                newName: "IX_ClientReceipt_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShipmentData",
                table: "ShipmentData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiptOrder",
                table: "ReceiptOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Receipt",
                table: "Receipt",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientReceipt",
                table: "ClientReceipt",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientReceipt_AspNetUsers_ClientId",
                table: "ClientReceipt",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientReceipt_Receipt_ReceiptId",
                table: "ClientReceipt",
                column: "ReceiptId",
                principalTable: "Receipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_ClientId",
                table: "Order",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_ShipmentData_ShipmentDataId",
                table: "Order",
                column: "ShipmentDataId",
                principalTable: "ShipmentData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Order_OrderId",
                table: "Payment",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Order_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_AspNetUsers_CashierId",
                table: "Receipt",
                column: "CashierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_AspNetUsers_ClientId",
                table: "Receipt",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Payment_PaymentId",
                table: "Receipt",
                column: "PaymentId",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptOrder_Order_OrderId",
                table: "ReceiptOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptOrder_Receipt_ReceiptId",
                table: "ReceiptOrder",
                column: "ReceiptId",
                principalTable: "Receipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
