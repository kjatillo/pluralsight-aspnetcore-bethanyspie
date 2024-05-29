using Microsoft.EntityFrameworkCore;

namespace Pluralsight.AspNetCore.BethanysPie.Models
{
    public class BethanysPieDbContext : DbContext
    {
        public BethanysPieDbContext(DbContextOptions<BethanysPieDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
