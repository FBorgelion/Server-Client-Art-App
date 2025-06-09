using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedOrdersv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate", "Status", "TotalAmount", "DeliveryPartnerId", "ShippingAddress" },
                values: new object[,]
                {
                    { 10001, 7, new DateTime(2025, 6, 1, 10, 0, 0, DateTimeKind.Utc), "PickedUp", 49.99m, 13, "123 Main St" },
                    { 10002, 7, new DateTime(2025, 6, 2, 14, 30, 0, DateTimeKind.Utc), "InTransit", 75.50m, 13, "456 Secondary St" }
                });

            migrationBuilder.InsertData(
                table: "DeliveryStatusUpdates",
                columns: new[] { "UpdateId", "OrderId", "DeliveryPartnerId", "Status", "TimeStamp" },
                values: new object[,]
                {
                    { 2001, 10001, 13, "PickedUp", new DateTime(2025, 6, 1, 10, 5, 0, DateTimeKind.Utc) },
                    { 2002, 10002, 13, "InTransit", new DateTime(2025, 6, 2, 14, 45, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DeliveryStatusUpdates",
                keyColumn: "UpdateId",
                keyValues: new object[] { 2001, 2002 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValues: new object[] { 1001, 1002 });
        }
    }
}
