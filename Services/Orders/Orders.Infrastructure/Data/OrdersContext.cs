using Microsoft.EntityFrameworkCore;
using Orders.Core.Entities;

namespace Orders.Infrastructure.Data
{
    public class OrdersContext : DbContext
    {

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);
            
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<OrderItem>()
                .Property(e => e.CreatedTime)
                .HasDefaultValueSql("GETUTCDATE()");
            
            modelBuilder.Entity<Order>()
                .Property(e => e.CreatedTime)
                .HasDefaultValueSql("GETUTCDATE()");
            
            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedTime)
                .HasDefaultValueSql("GETUTCDATE()");

            if (!this.Database.GetPendingMigrations().Any())
            {
                SeedData(modelBuilder);
            }
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "İphone 15 Pro 128GB", Price = 60000 },
                new Product { Id = 2, Name = "Asus Rog RTX4090", Price = 120000 },
                new Product { Id = 3, Name = "Samsung Curved 4k Monitör", Price = 15000 },
                new Product { Id = 4, Name = "Philips Amblight 60inch 4K TV", Price = 35000 },
                new Product { Id = 5, Name = "Segway Elektrikli Scooter", Price = 45999 }
            );
        }
    }
}
