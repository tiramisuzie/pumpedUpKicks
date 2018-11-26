using Microsoft.EntityFrameworkCore.Migrations;

namespace PumpedUpKicks.Migrations
{
    public partial class shoppingCart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_Shops_ShopItemID",
                table: "ShoppingCartItem");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItem_ShopItemID",
                table: "ShoppingCartItem");

            migrationBuilder.DeleteData(
                table: "ShoppingCartItem",
                keyColumn: "ShoppingCartItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingCart",
                keyColumn: "ShoppingCartId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ShopItemID",
                table: "ShoppingCartItem");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Shops",
                newName: "ShopId");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "ShoppingCart",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "ShoppingCartItem",
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_Shops_ShopId",
                table: "ShoppingCartItem");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItem_ShopId",
                table: "ShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "ShoppingCartItem");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "Shops",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ShoppingCart",
                newName: "userId");

            migrationBuilder.AddColumn<int>(
                name: "ShopItemID",
                table: "ShoppingCartItem",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ShoppingCart",
                columns: new[] { "ShoppingCartId", "userId" },
                values: new object[] { 1, "29f37bce - a6ec - 4291 - bee5 - 49d2ca421093" });

            migrationBuilder.InsertData(
                table: "ShoppingCartItem",
                columns: new[] { "ShoppingCartItemId", "Amount", "ShopItemID", "ShoppingCartId" },
                values: new object[] { 1, 0, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShopItemID",
                table: "ShoppingCartItem",
                column: "ShopItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_Shops_ShopItemID",
                table: "ShoppingCartItem",
                column: "ShopItemID",
                principalTable: "Shops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
