using e_commerce.Models;
using Microsoft.EntityFrameworkCore;


namespace e_commerce.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ProductTypes> ProductTypes { get; set; } = null!;

        public DbSet<Products> Products { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderDetails> OrderDetails { get; set; } = null!;

        public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();   // удаляем бд со старой схемой
            Database.EnsureCreated();     // создаем бд с новой схемой
        }
    }
}