using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class deleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artisans_Users_ArtisanId",
                table: "Artisans");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Customers_CustomerId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInquiries_Customers_CustomerId",
                table: "CustomerInquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInquiries_Products_ProductId",
                table: "CustomerInquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_CustomerId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryPartners_Users_DeliveryPartnerId",
                table: "DeliveryPartners");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryStatusUpdates_DeliveryPartners_DeliveryPartnerId",
                table: "DeliveryStatusUpdates");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryStatusUpdates_Orders_OrderId",
                table: "DeliveryStatusUpdates");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryPartners_DeliveryPartnerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Artisans_ArtisanId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_Artisans_Users_ArtisanId",
                table: "Artisans",
                column: "ArtisanId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Customers_CustomerId",
                table: "Cart",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInquiries_Customers_CustomerId",
                table: "CustomerInquiries",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInquiries_Products_ProductId",
                table: "CustomerInquiries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_CustomerId",
                table: "Customers",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryPartners_Users_DeliveryPartnerId",
                table: "DeliveryPartners",
                column: "DeliveryPartnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryStatusUpdates_DeliveryPartners_DeliveryPartnerId",
                table: "DeliveryStatusUpdates",
                column: "DeliveryPartnerId",
                principalTable: "DeliveryPartners",
                principalColumn: "DeliveryPartnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryStatusUpdates_Orders_OrderId",
                table: "DeliveryStatusUpdates",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryPartners_DeliveryPartnerId",
                table: "Orders",
                column: "DeliveryPartnerId",
                principalTable: "DeliveryPartners",
                principalColumn: "DeliveryPartnerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Artisans_ArtisanId",
                table: "Products",
                column: "ArtisanId",
                principalTable: "Artisans",
                principalColumn: "ArtisanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artisans_Users_ArtisanId",
                table: "Artisans");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Customers_CustomerId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInquiries_Customers_CustomerId",
                table: "CustomerInquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerInquiries_Products_ProductId",
                table: "CustomerInquiries");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_CustomerId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryPartners_Users_DeliveryPartnerId",
                table: "DeliveryPartners");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryStatusUpdates_DeliveryPartners_DeliveryPartnerId",
                table: "DeliveryStatusUpdates");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryStatusUpdates_Orders_OrderId",
                table: "DeliveryStatusUpdates");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryPartners_DeliveryPartnerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Artisans_ArtisanId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_Artisans_Users_ArtisanId",
                table: "Artisans",
                column: "ArtisanId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Customers_CustomerId",
                table: "Cart",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Products_ProductId",
                table: "Cart",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInquiries_Customers_CustomerId",
                table: "CustomerInquiries",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerInquiries_Products_ProductId",
                table: "CustomerInquiries",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_CustomerId",
                table: "Customers",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryPartners_Users_DeliveryPartnerId",
                table: "DeliveryPartners",
                column: "DeliveryPartnerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryStatusUpdates_DeliveryPartners_DeliveryPartnerId",
                table: "DeliveryStatusUpdates",
                column: "DeliveryPartnerId",
                principalTable: "DeliveryPartners",
                principalColumn: "DeliveryPartnerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryStatusUpdates_Orders_OrderId",
                table: "DeliveryStatusUpdates",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryPartners_DeliveryPartnerId",
                table: "Orders",
                column: "DeliveryPartnerId",
                principalTable: "DeliveryPartners",
                principalColumn: "DeliveryPartnerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Artisans_ArtisanId",
                table: "Products",
                column: "ArtisanId",
                principalTable: "Artisans",
                principalColumn: "ArtisanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Customers_CustomerId",
                table: "Reviews",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Products_ProductId",
                table: "Reviews",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
