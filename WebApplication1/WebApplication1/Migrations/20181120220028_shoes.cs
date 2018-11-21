using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PumpedUpKicks.Migrations
{
    public partial class shoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ID", "Description", "Name" },
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
