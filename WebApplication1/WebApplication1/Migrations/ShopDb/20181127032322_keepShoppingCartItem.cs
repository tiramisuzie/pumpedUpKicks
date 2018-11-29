using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PumpedUpKicks.Migrations.ShopDb
{
    public partial class keepShoppingCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "ShoppingCartItem");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "ShoppingCartItem",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShoppingCartItem",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "ShoppingCartItem",
                keyColumn: "ShoppingCartItemId",
                keyValue: 1,
                column: "UserId",
                value: "2077f23d-3421-4a3d-baa8-f4b67046d0df");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ShoppingCartItem",
                newName: "userId");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "ShoppingCartItem",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "ShoppingCartItem",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "UserId" },
                values: new object[] { 1, "2077f23d-3421-4a3d-baa8-f4b67046d0df" });

            migrationBuilder.UpdateData(
                table: "ShoppingCartItem",
                keyColumn: "ShoppingCartItemId",
                keyValue: 1,
                columns: new[] { "ShoppingCartId", "userId" },
                values: new object[] { 1, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItem_ShoppingCarts_ShoppingCartId",
                table: "ShoppingCartItem",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "ShoppingCartId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
