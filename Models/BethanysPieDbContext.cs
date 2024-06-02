using Microsoft.EntityFrameworkCore;

namespace Pluralsight.AspNetCore.BethanysPie.Models
{
    public class BethanysPieDbContext : DbContext
    {
        public BethanysPieDbContext(DbContextOptions<BethanysPieDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .Property(o => o.Price)
                .HasColumnType("decimal(20, 2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderTotal)
                .HasColumnType("decimal(20, 2)");

            modelBuilder.Entity<Pie>()
                .Property(o => o.Price)
                .HasColumnType("decimal(20, 2)");
        }
    }
}
