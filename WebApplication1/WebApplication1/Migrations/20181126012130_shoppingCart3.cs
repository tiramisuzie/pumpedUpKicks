using Microsoft.EntityFrameworkCore.Migrations;

namespace PumpedUpKicks.Migrations
{
    public partial class shoppingCart3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShoppingCart",
                columns: new[] { "ShoppingCartId", "UserId" },
                values: new object[] { 1, "29f37bce - a6ec - 4291 - bee5 - 49d2ca421093" });

            migrationBuilder.InsertData(
                table: "ShoppingCartItem",
                columns: new[] { "ShoppingCartItemId", "Amount", "ShopId", "ShoppingCartId" },
                values: new object[] { 1, 0, 10, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ShoppingCartItem",
                keyColumn: "ShoppingCartItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingCart",
                keyColumn: "ShoppingCartId",
                keyValue: 1);
        }
    }
}
