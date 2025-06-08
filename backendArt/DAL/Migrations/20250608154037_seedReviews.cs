using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Reviews",
               columns: new[] { "ReviewId", "ProductId", "CustomerId", "Rating", "Comment", "CreatedDate" },
               values: new object[]
               {
                    3001,   // à ajuster si nécessaire
                    4,
                    7,      // CustomerId existant
                    5,
                    "Excellent qualité, je recommande !",
                    new DateTime(2025, 6, 8, 14, 30, 0)
               });

            // INSERT Reviews for product 5
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "ProductId", "CustomerId", "Rating", "Comment", "CreatedDate" },
                values: new object[]
                {
                    3002,
                    5,
                    7,
                    4,
                    "Bon produit, conforme à la description.",
                    new DateTime(2025, 6, 7, 11, 15, 0)
                });

            // INSERT Reviews for product 20
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "ProductId", "CustomerId", "Rating", "Comment", "CreatedDate" },
                values: new object[]
                {
                    3003,
                    20,
                    6,
                    3,
                    "Montre sympa, mais achetée trop grande pour mon poignet.",
                    new DateTime(2025, 6, 6, 9, 0, 0)
                });

            // INSERT Reviews for product 21
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "ProductId", "CustomerId", "Rating", "Comment", "CreatedDate" },
                values: new object[]
                {
                    3004,
                    21,
                    10,
                    4,
                    "Bracelet de très bonne facture, très confortable.",
                    new DateTime(2025, 6, 5, 16, 45, 0)
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValues: new object[] { 3001, 3002, 3003, 3004 });
        }
    }
}
