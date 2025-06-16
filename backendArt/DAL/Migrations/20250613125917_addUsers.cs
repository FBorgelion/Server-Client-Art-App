using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class addUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Username","Email", "PasswordHash", "Role", "Salt" },
                values: new object[,]
                {
                    { 100, "admin123", "admin123@mail.com"  , "6C654A11CCFB9ED9417B", "Admin", "Friday" },
                    { 200, "art123",   "art123@mail.com"  , "6C654A11CCFB9ED9417B", "Artisan", "Friday" },
                    { 300, "partner123", "partner123@mail.com" , "6C654A11CCFB9ED9417B", "DeliveryPartner", "Friday" },
                    { 400, "cust123",  "cust123@mail.com"  , "6C654A11CCFB9ED9417B", "Customer", "Friday" }
                }
            );

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "ShippingAddress", "PaymentInfo" },
                values: new object[,]
                {
                    { 400, "47 rue Saint-Jean Bruxelles" , "VISA 11325489974"}
                }
            );

            migrationBuilder.InsertData(
                table: "Artisans",
                columns: new[] { "ArtisanId", "ProfileDescription" },
                values: new object[] { 200, "Profil artisan pour art123" }
            );

            migrationBuilder.InsertData(
                table: "DeliveryPartners",
                columns: new[] { "DeliveryPartnerId" },
                values: new object[] { 300 }
            );

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId" },
                values: new object[] { 300 }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Customers", "CustomerId", 100);
            migrationBuilder.DeleteData("Customers", "CustomerId", 400);
            migrationBuilder.DeleteData("Artisans", "ArtisanId", 200);
            migrationBuilder.DeleteData("DeliveryPartners", "DeliveryPartnerId", 300);

            migrationBuilder.DeleteData("Users", "UserId", 100);
            migrationBuilder.DeleteData("Users", "UserId", 200);
            migrationBuilder.DeleteData("Users", "UserId", 300);
            migrationBuilder.DeleteData("Users", "UserId", 400);
        }
    }
}
    

