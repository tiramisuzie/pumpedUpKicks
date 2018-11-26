using Microsoft.EntityFrameworkCore.Migrations;

namespace PumpedUpKicks.Migrations
{
    public partial class linkCollectiontemp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoppingCartItemId",
                table: "ShoppingCarts");

            migrationBuilder.UpdateData(
                table: "ShoppingCartItem",
                keyColumn: "ShoppingCartItemId",
                keyValue: 1,
                column: "ProductId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartItemId",
                table: "ShoppingCarts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ShoppingCartItem",
                keyColumn: "ShoppingCartItemId",
                keyValue: 1,
                column: "ProductId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "ShoppingCartId",
                keyValue: 1,
                column: "ShoppingCartItemId",
                value: 1);
        }
    }
}
