using Microsoft.EntityFrameworkCore.Migrations;

namespace PumpedUpKicks.Migrations
{
    public partial class changeUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "ShoppingCartId",
                keyValue: 1,
                column: "UserId",
                value: "2077f23d-3421-4a3d-baa8-f4b67046d0df");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "ShoppingCartId",
                keyValue: 1,
                column: "UserId",
                value: "29f37bce - a6ec - 4291 - bee5 - 49d2ca421093");
        }
    }
}
