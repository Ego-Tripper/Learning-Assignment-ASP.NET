using CarMagazineISP_41.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarMagazineISP_411.Data.Context
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShopCartItem> ShopCarItem { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Ёдлектромобили" }, new Category { CategoryId = 2, CategoryName = "BurgenTruck" });
        }
    }
}