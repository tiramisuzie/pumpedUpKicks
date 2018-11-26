using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PumpedUpKicks.Migrations
{
    public partial class shoppingCart4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_Shops_ShopId",
                table: "ShoppingCartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItem_ShopId",
                table: "ShoppingCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart");

            migrationBuilder.RenameTable(
                name: "ShoppingCart",
                newName: "ShoppingCarts");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "ShoppingCartItem",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ShoppingCartItem",
                newName: "ProductId");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartItemId",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts",
                column: "ShoppingCartId");

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

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "ShoppingCartId",
                keyValue: 1,
                column: "ShoppingCartItemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ShoppingCartItem",
                keyColumn: "ShoppingCartItemId",
                keyValue: 1,
                columns: new[] { "ProductId", "Quantity" },
                values: new object[] { 10, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ProductId",
                table: "ShoppingCartItem",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_Products_ProductId",
                table: "ShoppingCartItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "ShoppingCartId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_Products_ProductId",
                table: "ShoppingCartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItem_ProductId",
                table: "ShoppingCartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCarts",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "ShoppingCartItemId",
                table: "ShoppingCarts");

            migrationBuilder.RenameTable(
                name: "ShoppingCarts",
                newName: "ShoppingCart");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ShoppingCartItem",
                newName: "ShopId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ShoppingCartItem",
                newName: "Amount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCart",
                table: "ShoppingCart",
                column: "ShoppingCartId");

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ShopId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ShopId);
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "Description", "Name" },
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

            migrationBuilder.UpdateData(
                table: "ShoppingCartItem",
                keyColumn: "ShoppingCartItemId",
                keyValue: 1,
                columns: new[] { "Amount", "ShopId" },
                values: new object[] { 0, 10 });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShopId",
                table: "ShoppingCartItem",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_Shops_ShopId",
                table: "ShoppingCartItem",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "ShopId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCart_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId",
                principalTable: "ShoppingCart",
                principalColumn: "ShoppingCartId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
