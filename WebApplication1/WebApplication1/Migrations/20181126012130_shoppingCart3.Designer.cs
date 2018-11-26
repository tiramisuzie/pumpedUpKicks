﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PumpedUpKicks.Data;

namespace PumpedUpKicks.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20181126012130_shoppingCart3")]
    partial class shoppingCart3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PumpedUpKicks.Models.Shop", b =>
                {
                    b.Property<int>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ShopId");

                    b.ToTable("Shops");

                    b.HasData(
                        new { ShopId = 1, Description = "Classic fresh and multiple colorways", Name = "Nike Air Max 97" },
                        new { ShopId = 2, Description = "Classic fresh and multiple colorways", Name = "Nike Air Max 95" },
                        new { ShopId = 3, Description = "Classic fresh and multiple colorways", Name = "Nike Air Max" },
                        new { ShopId = 4, Description = "Classic fresh and multiple colorways", Name = "Nike Kyrie 3" },
                        new { ShopId = 5, Description = "Classic fresh and multiple colorways", Name = "Nike Air Force 1" },
                        new { ShopId = 6, Description = "Classic fresh and multiple colorways", Name = "Nike Zoom Vaporfly" },
                        new { ShopId = 7, Description = "Classic fresh and multiple colorways", Name = "Nike LeBron 15" },
                        new { ShopId = 8, Description = "Classic fresh and multiple colorways", Name = "Jordan 1's" },
                        new { ShopId = 9, Description = "Classic fresh and multiple colorways", Name = "Jordan 3's" },
                        new { ShopId = 10, Description = "Classic fresh and multiple colorways", Name = "Jordan 4's" }
                    );
                });

            modelBuilder.Entity("PumpedUpKicks.Models.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId");

                    b.HasKey("ShoppingCartId");

                    b.ToTable("ShoppingCart");

                    b.HasData(
                        new { ShoppingCartId = 1, UserId = "29f37bce - a6ec - 4291 - bee5 - 49d2ca421093" }
                    );
                });

            modelBuilder.Entity("PumpedUpKicks.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("ShopId");

                    b.Property<int>("ShoppingCartId");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("ShopId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartItem");

                    b.HasData(
                        new { ShoppingCartItemId = 1, Amount = 0, ShopId = 10, ShoppingCartId = 1 }
                    );
                });

            modelBuilder.Entity("PumpedUpKicks.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("PumpedUpKicks.Models.Shop", "Shop")
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PumpedUpKicks.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
