using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            // Products...
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ArtisanId", "Title", "Description", "Price", "Stock", "Images" },
                values: new object[,]
                {
            { 20, 17, "Montre artisanale", "Montre en bois fait main", 75.0m, 15, null },
            { 21,17, "Bracelet cuir",     "Bracelet en cuir véritable", 25.0m, 50, null }
                });

            // Orders...
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate", "Status", "TotalAmount", "DeliveryPartnerId", "ShippingAddress" },
                values: new object[] { 1001, 18, new DateTime(2025, 6, 8, 10, 0, 0), "Pending", 125.0m, null, "123 Artisan St." });

            // OrderItems...
            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "OrderId", "ProductId", "Quantity", "PriceAtPurchase" },
                values: new object[,]
                {
            { 2001, 1001, 20, 1, 75.0m },
            { 2002, 1001, 21, 2, 25.0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("OrderItems", "OrderItemId", 2001);
            migrationBuilder.DeleteData("OrderItems", "OrderItemId", 2002);
            migrationBuilder.DeleteData("Orders", "OrderId", 1001);
            migrationBuilder.DeleteData("Products", "ProductId", 20);
            migrationBuilder.DeleteData("Products", "ProductId", 21);
            migrationBuilder.DeleteData("Artisans", "ArtisanId", 8);
        }
    }
}
