using Microsoft.EntityFrameworkCore.Migrations;

namespace PumpedUpKicks.Migrations
{
    public partial class flattenIt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_Products_ProductId",
                table: "ShoppingCartItem");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItem_ProductId",
                table: "ShoppingCartItem");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "ShoppingCartItem",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ShoppingCartItem",
                keyColumn: "ShoppingCartItemId",
                keyValue: 1,
                column: "ProductName",
                value: "Nike Air Max 97");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "ShoppingCartItem");

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
        }
    }
}
