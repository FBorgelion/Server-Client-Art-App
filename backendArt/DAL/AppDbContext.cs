using Microsoft.EntityFrameworkCore;
using Domain;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Artisan> Artisans { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryPartner> DeliveryPartners { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<DeliveryStatusUpdate> DeliveryStatusUpdates { get; set; }
        public DbSet<Inquiry> CustomerInquiries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ----------------------------
            // 1-1 User → Artisan
            modelBuilder.Entity<Artisan>()
                .HasKey(a => a.ArtisanId);
            modelBuilder.Entity<Artisan>()
                .HasOne(a => a.User)
                .WithOne(u => u.Artisan)
                .HasForeignKey<Artisan>(a => a.ArtisanId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1-1 User → Customer
            modelBuilder.Entity<Customer>()
                .HasKey(cu => cu.CustomerId);
            modelBuilder.Entity<Customer>()
                .HasOne(cu => cu.User)
                .WithOne(u => u.Customer)
                .HasForeignKey<Customer>(cu => cu.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1-1 User → DeliveryPartner
            modelBuilder.Entity<DeliveryPartner>()
                .HasKey(dp => dp.DeliveryPartnerId);
            modelBuilder.Entity<DeliveryPartner>()
                .HasOne(dp => dp.User)
                .WithOne(u => u.DeliveryPartner)
                .HasForeignKey<DeliveryPartner>(dp => dp.DeliveryPartnerId)
                .OnDelete(DeleteBehavior.Cascade);

            // 1-1 User → Admin
            modelBuilder.Entity<Admin>()
                .HasKey(ad => ad.AdminId);
            modelBuilder.Entity<Admin>()
                .HasOne(ad => ad.User)
                .WithOne(u => u.Admin)
                .HasForeignKey<Admin>(ad => ad.AdminId);

            // ----------------------------
            // Artisan (1) → (N) Products
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Artisan)
                .WithMany(a => a.Products)
                .HasForeignKey(p => p.ArtisanId)
                .OnDelete(DeleteBehavior.Cascade);

            // ----------------------------
            // Customer (1) → (N) Cart
            modelBuilder.Entity<Cart>()
                .HasKey(c => c.CartItemId);
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Customer)
                .WithMany(cu => cu.CartItems)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Product (1) → (N) Cart
            modelBuilder.Entity<Cart>()
            .HasOne(c => c.Product)
            .WithMany(p => p.CartItems)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Cascade);  


            // ----------------------------
            // Customer (1) → (N) Orders
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(cu => cu.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // DeliveryPartner (1) → (N) Orders
            //           ⇓
            // OnDelete Restrict pour éviter un chemin en cascade multiple
            modelBuilder.Entity<Order>()
                .HasOne(o => o.DeliveryPartner)
                .WithMany(dp => dp.Orders)
                .HasForeignKey(o => o.DeliveryPartnerId)
                .OnDelete(DeleteBehavior.Cascade);

            // ----------------------------
            // Order (1) → (N) OrderItems
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Product (1) → (N) OrderItems
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // ----------------------------
            // Product (1) → (N) Reviews
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Customer (1) → (N) Reviews
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany(cu => cu.Reviews)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // ----------------------------
            // Order (1) → (N) DeliveryStatusUpdates
            modelBuilder.Entity<DeliveryStatusUpdate>()
                .HasKey(dsu => dsu.UpdateId);
            modelBuilder.Entity<DeliveryStatusUpdate>()
                .HasOne(dsu => dsu.Order)
                .WithMany(o => o.DeliveryStatusUpdates)
                .HasForeignKey(dsu => dsu.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // DeliveryPartner (1) → (N) DeliveryStatusUpdates
            modelBuilder.Entity<DeliveryStatusUpdate>()
                .HasOne(dsu => dsu.DeliveryPartner)
                .WithMany(dp => dp.DeliveryStatusUpdates)
                .HasForeignKey(dsu => dsu.DeliveryPartnerId)
                .OnDelete(DeleteBehavior.Cascade);

            // ----------------------------
            // Product (1) → (N) CustomerInquiries
            // Inquiry (1) → (N) Product
            modelBuilder.Entity<Inquiry>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.Inquiries)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Cascade);  

            // Customer (1) → (N) CustomerInquiries
            modelBuilder.Entity<Inquiry>()
                .HasOne(ci => ci.Customer)
                .WithMany(cu => cu.CustomerInquiries)
                .HasForeignKey(ci => ci.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
