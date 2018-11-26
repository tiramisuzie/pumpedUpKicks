﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PumpedUpKicks.Data;

namespace PumpedUpKicks.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PumpedUpKicks.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new { ProductId = 1, Description = "Classic fresh and multiple colorways", Name = "Nike Air Max 97" },
                        new { ProductId = 2, Description = "Classic fresh and multiple colorways", Name = "Nike Air Max 95" },
                        new { ProductId = 3, Description = "Classic fresh and multiple colorways", Name = "Nike Air Max" },
                        new { ProductId = 4, Description = "Classic fresh and multiple colorways", Name = "Nike Kyrie 3" },
                        new { ProductId = 5, Description = "Classic fresh and multiple colorways", Name = "Nike Air Force 1" },
                        new { ProductId = 6, Description = "Classic fresh and multiple colorways", Name = "Nike Zoom Vaporfly" },
                        new { ProductId = 7, Description = "Classic fresh and multiple colorways", Name = "Nike LeBron 15" },
                        new { ProductId = 8, Description = "Classic fresh and multiple colorways", Name = "Jordan 1's" },
                        new { ProductId = 9, Description = "Classic fresh and multiple colorways", Name = "Jordan 3's" },
                        new { ProductId = 10, Description = "Classic fresh and multiple colorways", Name = "Jordan 4's" }
                    );
                });

            modelBuilder.Entity("PumpedUpKicks.Models.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId");

                    b.HasKey("ShoppingCartId");

                    b.ToTable("ShoppingCarts");

                    b.HasData(
                        new { ShoppingCartId = 1, UserId = "2077f23d-3421-4a3d-baa8-f4b67046d0df" }
                    );
                });

            modelBuilder.Entity("PumpedUpKicks.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId");

                    b.Property<string>("ProductName");

                    b.Property<int>("Quantity");

                    b.Property<int>("ShoppingCartId");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartItem");

                    b.HasData(
                        new { ShoppingCartItemId = 1, ProductId = 1, ProductName = "Nike Air Max 97", Quantity = 2, ShoppingCartId = 1 }
                    );
                });

            modelBuilder.Entity("PumpedUpKicks.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("PumpedUpKicks.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
