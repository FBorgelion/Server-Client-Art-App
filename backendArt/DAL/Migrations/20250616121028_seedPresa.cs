using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedPresa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Products",
               columns: new[] { "ProductId", "ArtisanId", "Title", "Description", "Price", "Stock", "Images" },
               values: new object[,]
               {
                    { 100, 200, "Terrasse du café le soir", "Reproduction Terrasse du café le soir", 10.5m, 100, "/images/terrasse.png" },
                    { 101, 200, "La Nuit étoilée ", "Reproduction de La Nuit étoilée (1889)", 20.0m,  50, "/images/nuit.png" },
                    { 102, 200, "Portrait d'Adele Bloch-Bauer I", "Commandé par Ferdinand Bloch-Bauer, banquier et producteur de sucre, le mari d’Adele Bloch-Bauer, ce portrait est l'œuvre la plus représentative du cycle d'or de Klimt. C'est le premier des deux portraits d'Adele par Klimt — le second date de 1912 et tous deux font partie des nombreuses œuvres de l'artiste appartenant à la famille Bloch-Bauer.", 15.75m, 25, "/images/portrait.png" },
                    { 103, 200, "Le Radeau de la Méduse", "Son titre initial, donné par Géricault lors de sa première présentation, est Scène d'un naufrage. Ce tableau, de très grande dimension (environ 5 m de haut pour 7 m de large), représente un épisode tragique de l'histoire de la marine coloniale française : le naufrage de la frégate Méduse.", 30.0m,  10, "/images/radeau.png" },
                    { 104, 200, "La Persistance de la mémoire", "La Persistance de la mémoire est un tableau surréaliste peint en 1931 par Salvador Dalí. C'est une huile sur toile connue dans le grand public sous le titre Les Montres molles et l'un des plus célèbres tableaux du peintre.", 5.0m,   200,"/images/memoire.png" }
               }
           );

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate", "Status", "TotalAmount", "DeliveryPartnerId", "ShippingAddress" },
                values: new object[,]
                {
                    { 2001, 400, DateTime.UtcNow.AddDays(-10), "InProduction",  31.0m,  300,               "12 rue A, Paris" },
                    { 2002, 400, DateTime.UtcNow.AddDays(-8),  "PickedUp",      47.25m, 300,                  "34 avenue B, Lyon" },
                    { 2003,400, DateTime.UtcNow.AddDays(-5),  "InTransit",     15.75m, 300,                 "56 boulevard C, Lille" },
                    { 2004,400, DateTime.UtcNow.AddDays(-3),  "Delivered",     30.0m,  300,                 "78 impasse D, Nice" },
                    { 2005,400, DateTime.UtcNow.AddDays(-1),  "Shipped",       5.0m,   300,                 "90 chemin E, Bordeaux" }
                }
            );

            // ─── OrderItems ────────────────────────────────────────────────────────
            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "OrderId", "ProductId", "Quantity", "PriceAtPurchase" },
                values: new object[,]
                {
                    { 3000, 2001, 100, 2, 10.5m },
                    { 3001, 2001, 101, 1, 20.0m },
                    { 3002, 2002, 102, 3, 15.75m },
                    { 3003, 2003, 103, 1, 30.0m },
                    { 3004, 2004, 104, 5, 5.0m  }
                }
            );

            // ─── Reviews ──────────────────────────────────────────────────────────
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "ProductId", "CustomerId", "Rating", "Comment", "CreatedDate" },
                values: new object[,]
                {
                    { 4000, 100, 400, 5, "Excellent", DateTime.UtcNow.AddDays(-9) },
                    { 4001, 101, 400, 4, "Très bien", DateTime.UtcNow.AddDays(-7) },
                    { 4002, 102,400, 3, "Correct",  DateTime.UtcNow.AddDays(-4) },
                    { 4003, 103,400, 2, "Moyen",    DateTime.UtcNow.AddDays(-2) },
                    { 4004, 104,400, 1, "Décevant", DateTime.UtcNow.AddDays(-1) }
                }
            );

            // ─── DeliveryStatusUpdates ────────────────────────────────────────────
            migrationBuilder.InsertData(
                table: "DeliveryStatusUpdates",
                columns: new[] { "UpdateId", "OrderId", "DeliveryPartnerId", "Status", "TimeStamp" },
                values: new object[,]
                {
                    { 5000, 2001, 300, "PickedUp",  DateTime.UtcNow.AddDays(-8).AddHours(1) },
                    { 5001, 2002,300, "InTransit", DateTime.UtcNow.AddDays(-5).AddHours(2) },
                    { 5002, 2003,300, "Delivered", DateTime.UtcNow.AddDays(-3).AddHours(3) },
                    { 5003, 2004,300, "Shipped",   DateTime.UtcNow.AddDays(-1).AddHours(4) },
                    { 5004, 2005,300, "InProduction", DateTime.UtcNow.AddDays(-10).AddHours(5) }
                }
            );

            // ─── Inquiries ─────────────────────────────────────────────────────────
            migrationBuilder.InsertData(
                table: "CustomerInquiries",
                columns: new[] { "InquiryId", "ProductId", "CustomerId", "Message", "Response", "CreatedAt" },
                values: new object[,]
                {
                    { 6000, 100, 400, "C'est fait main ?", "Réponse A",  DateTime.UtcNow.AddDays(-9) },
                    { 6001, 101, 400, "Possible d'avoir un emballage cadeau ?", "Réponse B",  DateTime.UtcNow.AddDays(-7) },
                    { 6002, 102,400, "Vous faites d'autres modèles ?", null,        DateTime.UtcNow.AddDays(-4) },
                    { 6003, 103,400, "Vous avez un magasin ?", null,        DateTime.UtcNow.AddDays(-2) },
                    { 6004, 104,400, "On se connait, non ?", "Réponse E",  DateTime.UtcNow.AddDays(-1) }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("CustomerInquiries", "InquiryId", 6000);
            migrationBuilder.DeleteData("CustomerInquiries", "InquiryId", 6001);
            migrationBuilder.DeleteData("CustomerInquiries", "InquiryId", 6002);
            migrationBuilder.DeleteData("CustomerInquiries", "InquiryId", 6003);
            migrationBuilder.DeleteData("CustomerInquiries", "InquiryId", 6004);

            migrationBuilder.DeleteData("DeliveryStatusUpdates", "UpdateId", 5000);
            migrationBuilder.DeleteData("DeliveryStatusUpdates", "UpdateId", 5001);
            migrationBuilder.DeleteData("DeliveryStatusUpdates", "UpdateId", 5002);
            migrationBuilder.DeleteData("DeliveryStatusUpdates", "UpdateId", 5003);
            migrationBuilder.DeleteData("DeliveryStatusUpdates", "UpdateId", 5004);

            migrationBuilder.DeleteData("Reviews", "ReviewId", 4000);
            migrationBuilder.DeleteData("Reviews", "ReviewId", 4001);
            migrationBuilder.DeleteData("Reviews", "ReviewId", 4002);
            migrationBuilder.DeleteData("Reviews", "ReviewId", 4003);
            migrationBuilder.DeleteData("Reviews", "ReviewId", 4004);

            migrationBuilder.DeleteData("OrderItems", "OrderItemId", 3000);
            migrationBuilder.DeleteData("OrderItems", "OrderItemId", 3001);
            migrationBuilder.DeleteData("OrderItems", "OrderItemId", 3002);
            migrationBuilder.DeleteData("OrderItems", "OrderItemId", 3003);
            migrationBuilder.DeleteData("OrderItems", "OrderItemId", 3004);

            migrationBuilder.DeleteData("Orders", "OrderId", 2000);
            migrationBuilder.DeleteData("Orders", "OrderId", 2001);
            migrationBuilder.DeleteData("Orders", "OrderId", 2002);
            migrationBuilder.DeleteData("Orders", "OrderId", 2003);
            migrationBuilder.DeleteData("Orders", "OrderId", 2004);

            migrationBuilder.DeleteData("Cart", "CartItemId", 1000);
            migrationBuilder.DeleteData("Cart", "CartItemId", 1001);
            migrationBuilder.DeleteData("Cart", "CartItemId", 1002);
            migrationBuilder.DeleteData("Cart", "CartItemId", 1003);
            migrationBuilder.DeleteData("Cart", "CartItemId", 1004);

            migrationBuilder.DeleteData("Products", "ProductId", 100);
            migrationBuilder.DeleteData("Products", "ProductId", 101);
            migrationBuilder.DeleteData("Products", "ProductId", 102);
            migrationBuilder.DeleteData("Products", "ProductId", 103);
            migrationBuilder.DeleteData("Products", "ProductId", 104);

            migrationBuilder.DeleteData("DeliveryPartners", "DeliveryPartnerId", 3);
            migrationBuilder.DeleteData("DeliveryPartners", "DeliveryPartnerId", 13);
            migrationBuilder.DeleteData("DeliveryPartners", "DeliveryPartnerId", 14);
            migrationBuilder.DeleteData("DeliveryPartners", "DeliveryPartnerId", 15);
            migrationBuilder.DeleteData("DeliveryPartners", "DeliveryPartnerId", 16);

            migrationBuilder.DeleteData("Customers", "CustomerId", 1);
            migrationBuilder.DeleteData("Customers", "CustomerId", 5);
            migrationBuilder.DeleteData("Customers", "CustomerId", 10);
            migrationBuilder.DeleteData("Customers", "CustomerId", 11);
            migrationBuilder.DeleteData("Customers", "CustomerId", 12);

            migrationBuilder.DeleteData("Artisans", "ArtisanId", 2);
            migrationBuilder.DeleteData("Artisans", "ArtisanId", 6);
            migrationBuilder.DeleteData("Artisans", "ArtisanId", 7);
            migrationBuilder.DeleteData("Artisans", "ArtisanId", 8);
            migrationBuilder.DeleteData("Artisans", "ArtisanId", 9);

            migrationBuilder.DeleteData("Admins", "AdminId", 4);

            migrationBuilder.DeleteData("Users", "UserId", 1);
            migrationBuilder.DeleteData("Users", "UserId", 2);
            migrationBuilder.DeleteData("Users", "UserId", 3);
            migrationBuilder.DeleteData("Users", "UserId", 4);
            migrationBuilder.DeleteData("Users", "UserId", 5);
        }
    }
}
