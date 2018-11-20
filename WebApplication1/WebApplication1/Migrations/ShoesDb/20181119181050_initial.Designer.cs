﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PumpedUpKicks.Data;

namespace PumpedUpKicks.Migrations.ShoesDb
{
    [DbContext(typeof(ShoesDbContext))]
    [Migration("20181119181050_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PumpedUpKicks.Models.Shoe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Shoes");

                    b.HasData(
                        new { ID = 1, Description = "Classic fresh and multiple colorways", Name = "Nike Air Max 97" },
                        new { ID = 2, Description = "Classic fresh and multiple colorways", Name = "Nike Air Max 95" },
                        new { ID = 3, Description = "Classic fresh and multiple colorways", Name = "Nike Air Max" },
                        new { ID = 4, Description = "Classic fresh and multiple colorways", Name = "Nike Kyrie 3" },
                        new { ID = 5, Description = "Classic fresh and multiple colorways", Name = "Nike Air Force 1" },
                        new { ID = 6, Description = "Classic fresh and multiple colorways", Name = "Nike Zoom Vaporfly" },
                        new { ID = 7, Description = "Classic fresh and multiple colorways", Name = "Nike LeBron 15" },
                        new { ID = 8, Description = "Classic fresh and multiple colorways", Name = "Jordan 1's" },
                        new { ID = 9, Description = "Classic fresh and multiple colorways", Name = "Jordan 3's" },
                        new { ID = 10, Description = "Classic fresh and multiple colorways", Name = "Jordan 4's" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
