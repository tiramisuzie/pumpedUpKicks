using Microsoft.EntityFrameworkCore;
using PumpedUpKicks.Models;
using System.Collections.Generic;

namespace PumpedUpKicks.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        // For composite keys and shadow properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Nike Air Max 97",
                    Price = 100,
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Nike Air Max 95",
                    Price = 200,
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Nike Air Max",
                    Price = 150,
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Nike Kyrie 3",
                    Price = 150,
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Nike Air Force 1",
                    Price = 175,
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Nike Zoom Vaporfly",
                    Price = 205,
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 7,
                    Name = "Nike LeBron 15",
                    Price = 215,
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 8,
                    Name = "Jordan 1's",
                    Price = 150,
                    Image = "~/images/airmax97.jpg",
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 9,
                    Name = "Jordan 3's",
                    Price = 300,
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 10,
                    Name = "Jordan 4's",
                    Price = 350,
                    Description = "Classic fresh and multiple colorways"
                }

            );


            modelBuilder.Entity<ShoppingCartItem>(entity =>
            {
                entity.HasOne(d => d.ShoppingCart)
                    .WithMany(p => p.ShoppingCartItems)
                    .HasForeignKey("ShoppingCartId");
            });
    
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts {get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
    }

}
