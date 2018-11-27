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
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Nike Air Max 95",
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Nike Air Max",
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Nike Kyrie 3",
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Nike Air Force 1",
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Nike Zoom Vaporfly",
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 7,
                    Name = "Nike LeBron 15",
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 8,
                    Name = "Jordan 1's",
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 9,
                    Name = "Jordan 3's",
                    Description = "Classic fresh and multiple colorways"
                },
                new Product
                {
                    ProductId = 10,
                    Name = "Jordan 4's",
                    Description = "Classic fresh and multiple colorways"
                }

            );

            //modelBuilder.Entity<ShoppingCart>().HasData(new ShoppingCart
            //{
            //    ShoppingCartId = 1,
            //    UserId = "2077f23d-3421-4a3d-baa8-f4b67046d0df"
            //}
            //);

            modelBuilder.Entity<ShoppingCartItem>(entity =>
            {
                entity.HasOne(d => d.ShoppingCart)
                    .WithMany(p => p.ShoppingCartItems)
                    .HasForeignKey("ShoppingCartId");
            });
            

            //modelBuilder.Entity<ShoppingCartItem>().HasData(new ShoppingCartItem
            //{
            //    ShoppingCartItemId = 1,
            //    ShoppingCartId = 1,
            //    ProductId = 1,
            //    Quantity = 2
            //});
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts {get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
    }

}
