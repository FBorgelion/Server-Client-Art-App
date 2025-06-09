using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedInquiries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "CustomerInquiries",
            columns: new[] { "InquiryId", "ProductId", "CustomerId", "Message", "Response", "CreatedAt" },
            values: new object[,]
            {
                { 10,  4, 10, "Bonjour, est-ce que ce modèle existe en plusieurs tailles ?", null, new DateTime(2025,6,9,8,30,0,DateTimeKind.Utc) },
                { 20,  5, 7, "Pouvez-vous me confirmer les dimensions exactes ?",         null, new DateTime(2025,6,9,9,15,0,DateTimeKind.Utc) },
                { 30, 20, 6, "Y a-t-il une option de gravure disponible ?",               null, new DateTime(2025,6,10,14,0,0,DateTimeKind.Utc) },
                { 40, 21, 10, "Le bracelet résiste-t-il à l'eau ?",                       null, new DateTime(2025,6,10,16,45,0,DateTimeKind.Utc) }
            });
        }
        

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
            table: "CustomerInquiries",
            keyColumn: "InquiryId",
            keyValues: new object[] { 1, 2, 3, 4 });
        }
    }
}
