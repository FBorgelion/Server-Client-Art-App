using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Username", "Email", "PasswordHash", "Role"},
                values: new object[,]
                {
                    { 1, "artisantest", "artiste@example.com", "AQAAAAEAACcQAAAAEN0uX...", "Artisan" },
                    { 2, "clienttest",   "client@example.com",  "AQAAAAEAACcQAAAAEL9x...", "Customer" }
                }
            );

            // 2) Insert Artisan
            migrationBuilder.InsertData(
                table: "Artisans",
                columns: new[] { "ArtisanId", "ProfileDescription"},
                values: new object[] { 1, "Artisan test spécialisé en poterie" }
            );

            // 3) Insert Customer
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "ShippingAddress", "PaymentInfo" },
                values: new object[] { 2, "123 Rue de la République, 1000 Bruxelles", "VISA **** 1234" }
            );

            // 4) Insert Product
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ArtisanId", "Title", "Description", "Price", "Stock", "Images" },
                values: new object[] { 1, 1, "Vase en céramique bleu", "Vase artisanal fait main, émaillé bleu azur", 49.99, 10, "https://cdn.example.com/images/vase1.jpg" }
            );

            // 5) Insert Cart item
            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartItemId", "CustomerId", "ProductId", "Quantity" },
                values: new object[] { 1, 2, 1, 2 }
            );

            // 6) Insert Order
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate", "Status", "TotalAmount", "DeliveryPartnerId", "ShippingAddress" },
                values: new object[] { 1, 2, new DateTime(2025, 1, 20, 11, 10, 0), "Delivered", 99.98m, null, "123 Rue de la République, 1000 Bruxelles" }
            );

            // 7) Insert OrderItem
            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "OrderId", "ProductId", "Quantity", "PriceAtPurchase" },
                values: new object[] { 1, 1, 1, 2, 49.99 }
            );

            // 8) Insert Review
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "ProductId", "CustomerId", "Rating", "Comment", "CreatedDate" },
                values: new object[] { 1, 1, 2, 5, "Super qualité, très satisfait !", new DateTime(2025, 1, 21, 9, 0, 0) }
            );

            // 9) Insert Inquiry
            migrationBuilder.InsertData(
                table: "CustomerInquiries",
                columns: new[] { "InquiryId", "ProductId", "CustomerId", "Message", "Response", "CreatedAt" },
                values: new object[] { 1, 1, 2, "Le vase convient-il pour un extérieur ?", "Oui, il est émaillé et résiste aux intempéries", new DateTime(2025, 1, 22, 8, 30, 0) }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.DeleteData(
                table: "CustomerInquiries",
                keyColumn: "InquiryId",
                keyValue: 1
            );

            // 8) Delete Review
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1
            );

            // 7) Delete OrderItem
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1
            );

            // 6) Delete Order
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1
            );

            // 5) Delete Cart item
            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "CartItemId",
                keyValue: 1
            );

            // 4) Delete Product
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1
            );

            // 3) Delete Customer
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2
            );

            // 2) Delete Artisan
            migrationBuilder.DeleteData(
                table: "Artisans",
                keyColumn: "ArtisanId",
                keyValue: 1
            );

            // 1) Delete Users
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1
            );
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2
            );
        }
    }
}
