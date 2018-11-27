﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PumpedUpKicks.Migrations.ShopDb
{
    public partial class initialshop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCartId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    userId = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "ShoppingCartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Classic fresh and multiple colorways", "Nike Air Max 97" },
                    { 2, "Classic fresh and multiple colorways", "Nike Air Max 95" },
                    { 3, "Classic fresh and multiple colorways", "Nike Air Max" },
                    { 4, "Classic fresh and multiple colorways", "Nike Kyrie 3" },
                    { 5, "Classic fresh and multiple colorways", "Nike Air Force 1" },
                    { 6, "Classic fresh and multiple colorways", "Nike Zoom Vaporfly" },
                    { 7, "Classic fresh and multiple colorways", "Nike LeBron 15" },
                    { 8, "Classic fresh and multiple colorways", "Jordan 1's" },
                    { 9, "Classic fresh and multiple colorways", "Jordan 3's" },
                    { 10, "Classic fresh and multiple colorways", "Jordan 4's" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "UserId" },
                values: new object[] { 1, "2077f23d-3421-4a3d-baa8-f4b67046d0df" });

            migrationBuilder.InsertData(
                table: "ShoppingCartItem",
                columns: new[] { "ShoppingCartItemId", "ProductId", "ProductName", "Quantity", "ShoppingCartId", "userId" },
                values: new object[] { 1, 1, "Nike Air Max 97", 2, 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");
        }
    }
}