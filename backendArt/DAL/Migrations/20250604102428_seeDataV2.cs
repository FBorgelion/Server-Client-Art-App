using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class seeDataV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Username", "Email", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 3,        "livreur1",   "livreur1@example.com",  "AQAAAAEAACcQAAAAEO7kUY...", "DeliveryPartner" },
                    { 4,        "admin1",     "admin@example.com",     "AQAAAAEAACcQAAAAEMnpLO...", "Admin" },
                    { 5,        "client2",    "client2@example.com",   "AQAAAAEAACcQAAAAELk9AX...", "Customer" }
                }
            );

            // 2) Insert DeliveryPartner (ID 3)
            migrationBuilder.InsertData(
                table: "DeliveryPartners",
                columns: new[] { "DeliveryPartnerId" },
                values: new object[] { 3 }
            );

            // 3) Insert Admin (ID 4)
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId" },
                values: new object[] { 4 }
            );

            // 4) Insert additional Customers (ID 5)
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "ShippingAddress", "PaymentInfo" },
                values: new object[] { 5, "456 Avenue Louise, 1050 Ixelles", "Mastercard **** 5678" }
            );

            // 5) Insert additional Products (IDs 2, 3)
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ArtisanId", "Title", "Description", "Price", "Stock", "Images" },
                values: new object[,]
                {
                    { 2,           1,           "Collier en argent",     "Collier fin en argent 925, fabriqué à la main", 79.50m, 15,             "https://cdn.example.com/images/collier1.jpg" },
                    { 3,           1,           "Tasse en céramique verte", "Tasse artisanale, émaillée en vert émeraude", 24.00m, 20,            "https://cdn.example.com/images/tasse1.jpg" }
                }
            );

            // 6) Insert additional Reviews (IDs 2, 3)
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "ProductId", "CustomerId", "Rating", "Comment", "CreatedDate" },
                values: new object[,]
                {
                    { 2,          2,           2,           4,        "Très joli collier, expédition rapide.",          new DateTime(2025, 1, 25, 14, 0, 0) },
                    { 3,          3,           2,           5,        "La tasse est vraiment solide et bien finie.",   new DateTime(2025, 1, 26, 9, 15, 0) }
                }
            );

            // 7) Insert additional Cart items (IDs 2, 3)
            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartItemId", "CustomerId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 2,             5,            2,           1 },
                    { 3,             5,            3,           3 }
                }
            );

            // 8) Insert additional Order (ID 2) and OrderItems (IDs 2, 3)
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate", "Status", "TotalAmount", "DeliveryPartnerId", "ShippingAddress" },
                values: new object[] { 2, 5, new DateTime(2025, 1, 25, 19, 0, 0), "Processing", 152.50m, 3, "456 Avenue Louise, 1050 Ixelles" }
            );

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "OrderId", "ProductId", "Quantity", "PriceAtPurchase" },
                values: new object[,]
                {
                    { 2,              2,         2,           1,          79.50m },
                    { 3,              2,         3,           3,          24.00m }
                }
            );

            // 9) Insert DeliveryStatusUpdates (IDs 1, 2)
            migrationBuilder.InsertData(
                table: "DeliveryStatusUpdates",
                columns: new[] { "UpdateId", "OrderId", "DeliveryPartnerId", "Status", "TimeStamp" },
                values: new object[,]
                {
                    { 1,          1,         3,                   "Shipped",   new DateTime(2025, 1, 20, 12, 0, 0) },
                    { 2,          2,         3,                   "PickedUp",  new DateTime(2025, 1, 25, 20, 0, 0) }
                }
            );

            // 10) Insert additional Inquiries (IDs 2, 3)
            migrationBuilder.InsertData(
                table: "CustomerInquiries",
                columns: new[] { "InquiryId", "ProductId", "CustomerId", "Message", "Response", "CreatedAt" },
                values: new object[,]
                {
                    { 2,           2,           5,           "Le collier est-il réglable en longueur ?",        "Oui, il possède une chaîne ajustable jusqu’à 45 cm.",      new DateTime(2025, 1, 26, 10, 0, 0) },
                    { 3,           3,           2,           "La tasse passe au lave-vaisselle ?",               "Oui, elle est certifiée lave-vaisselle.",                   new DateTime(2025, 1, 26, 11, 0, 0) }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerInquiries",
                keyColumn: "InquiryId",
                keyValue: 3
            );
            migrationBuilder.DeleteData(
                table: "CustomerInquiries",
                keyColumn: "InquiryId",
                keyValue: 2
            );

            // 9) Delete DeliveryStatusUpdates
            migrationBuilder.DeleteData(
                table: "DeliveryStatusUpdates",
                keyColumn: "UpdateId",
                keyValue: 2
            );
            migrationBuilder.DeleteData(
                table: "DeliveryStatusUpdates",
                keyColumn: "UpdateId",
                keyValue: 1
            );

            // 8) Delete OrderItems (IDs 3, 2)
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3
            );
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2
            );

            // 8) Delete Order (ID 2)
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2
            );

            // 7) Delete Cart items (IDs 3, 2)
            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "CartItemId",
                keyValue: 3
            );
            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "CartItemId",
                keyValue: 2
            );

            // 6) Delete Reviews (IDs 3, 2)
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3
            );
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2
            );

            // 5) Delete Products (IDs 3, 2)
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3
            );
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2
            );

            // 4) Delete Customer (ID 5)
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5
            );

            // 3) Delete Admin (ID 4)
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 4
            );

            // 2) Delete DeliveryPartner (ID 3)
            migrationBuilder.DeleteData(
                table: "DeliveryPartners",
                keyColumn: "DeliveryPartnerId",
                keyValue: 3
            );

            // 1) Delete Users (IDs 5, 4, 3)
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5
            );
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4
            );
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3
            );
        }
    }
}
