using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PumpedUpKicks.Migrations.ShopDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.ShoppingCartItemId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Image", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "NIKE AIR MAX 97. ... With design heavily inspired by nature and materials, the Air Max 97 was the first of its kind to feature a hidden lacing system as well as a full-length, one-piece Air Max bubble that ran along the entire shoe, providing comfort and undeniable style.", "https://i.ebayimg.com/images/g/qaIAAOSwc49Y7oRt/s-l300.jpg", "Nike Air Max 97", 100 },
                    { 2, "Nike Air Max 95 Style. after sneaker. ... The Nike Air Max 95, with a heel and forefoot that feature the well-known Air-Sole cushioning, also ensures to provide lightweight and all-day comfort. With this said, the shoe is considered by many as a reliable everyday footwear.", "http://52.13.144.230/wp-content/uploads/2008/01/am95c1.jpg", "Nike Air Max 95", 200 },
                    { 3, "The Nike Air Max 270 Men's Shoe is inspired by two icons of big Air: the Air Max 180 and Air Max 93. It features Nike's biggest heel Air unit yet for a super-soft ride that feels as impossible as it looks. The Nike Air Max 270 Men's Shoe is inspired by two icons of big Air: the Air Max 180 and Air Max 93.", "https://sneakernews.com/wp-content/uploads/2018/08/nike-air-max-270-sf-giants-BV2517_800-1.jpg", "Nike Air Max 270", 150 },
                    { 4, "The Nike Kyrie 3 is Kyrie Irving's third signature basketball shoe. It features a mix of Flywire, traction pods, Zoom Air, and more.", "http://www.freerun2you.com/pic/NBA-Kyrie-Irving-3-White-Golden-Basketball-Shoes---1-416.jpg", "Nike Kyrie 3", 150 },
                    { 5, "Introduced to the world in 1982, the Nike Air Force 1 was the first basketball shoe to feature Nike Air technology, revolutionizing the game forever. From the hardwood to the blacktop to the core of hip-hop culture, today the AF1 stays true to its roots with soft, springy cushioning and a large midsole.", "https://www.sneakerfiles.com/wp-content/uploads/2018/03/nike-air-force-1-low-suede-pack-1.jpg", "Nike Air Force 1", 175 },
                    { 6, "Introducing the Nike Zoom Vaporfly Elite Flyprint. Weighing 11g lighter than the Nike Zoom Vaporfly 4%, this 3-D printed shoe is fast - tracking the future of running with a more breathable upper that boasts almost zero water retention.", "https://pmcfootwearnews.files.wordpress.com/2018/08/zoom_vaporfly_4_percent_tilt_original.jpg?w=700&h=437&crop=1", "Nike Zoom Vaporfly", 205 },
                    { 7, "The upper of the LeBron 15 is made of an innovated high-grade Flyknit material that Nike calls BattleKnit. It is designed by Jason Petrie specifically for the need of LeBron for a durable, comfortable, and highly stretchable upper. The inside of the shoe is lined with thick foam to provide the much needed comfort.", "https://www.flightclub.com/media/catalog/product/cache/1/image/1600x1140/9df78eab33525d08d6e5fb8d27136e95/8/0/802369_01.jpg", "Nike LeBron 15", 215 },
                    { 8, "The sneaker is heavily influenced by the Air Jordan 1's having a leather upper and both a Nike swoosh and a Jumpman plus a Jordan Wings logo. Its first retail debut was on September 3, 2016 in the banned colorway for $185 alongside its air Jordan 1 counterpart.", "https://images.solecollector.com/complex/images/c_fill,dpr_2.0,f_auto,fl_lossy,q_auto,w_680/red-velvet-jordan-1-heirness_tmgdsx/red-velvet-jordan-1-heiress", "Jordan 1's", 150 },
                    { 9, "The Air Jordan III (3) is Michael Jordan's third signature basketball shoe. It released in 1988 in four colorways of white, black, red, and blue. It was the first Air Jordan to feature visible Air, elephant print, and the Jumpman logo.", "https://sneakernews.com/wp-content/uploads/2018/05/where-to-buy-air-jordan-3-katrina.jpg", "Jordan 3's", 300 },
                    { 10, "AIR JORDAN IV The Air Jordan IV debuted in 1989 and was designed by Tinker Hatfield. It features lightweight netting and plastic wings on the upper as well as visible Max Air. The original colorways of the Air Jordan IV are 'White/Cement,' 'Bred,' 'Military,' and 'Fire Red.'", "https://sneakernews.com/wp-content/uploads/2018/08/jordan-4-raptors-AQ3816_065-store-list-1.jpg", "Jordan 4's", 350 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem");
        }
    }
}
