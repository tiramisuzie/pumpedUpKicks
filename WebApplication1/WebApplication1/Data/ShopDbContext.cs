using Microsoft.EntityFrameworkCore;
using PumpedUpKicks.Models;
using System.Collections.Generic;

namespace PumpedUpKicks.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        // For composite keys and shadow properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Name = "Nike Air Max 97",
                    Price = 100,
                    Image = "https://i.ebayimg.com/images/g/qaIAAOSwc49Y7oRt/s-l300.jpg",
                    Description = "NIKE AIR MAX 97. ... With design heavily inspired by nature and materials, the Air Max 97 was the first of its kind to feature a hidden lacing system as well as a full-length, one-piece Air Max bubble that ran along the entire shoe, providing comfort and undeniable style."
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Nike Air Max 95",
                    Price = 200,
                    Image = "http://52.13.144.230/wp-content/uploads/2008/01/am95c1.jpg",
                    Description = "Nike Air Max 95 Style. after sneaker. ... The Nike Air Max 95, with a heel and forefoot that feature the well-known Air-Sole cushioning, also ensures to provide lightweight and all-day comfort. With this said, the shoe is considered by many as a reliable everyday footwear."
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Nike Air Max 270",
                    Price = 150,
                    Image = "https://sneakernews.com/wp-content/uploads/2018/08/nike-air-max-270-sf-giants-BV2517_800-1.jpg",
                    Description = "The Nike Air Max 270 Men's Shoe is inspired by two icons of big Air: the Air Max 180 and Air Max 93. It features Nike's biggest heel Air unit yet for a super-soft ride that feels as impossible as it looks. The Nike Air Max 270 Men's Shoe is inspired by two icons of big Air: the Air Max 180 and Air Max 93."
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Nike Kyrie 3",
                    Price = 150,
                    Image = "http://www.freerun2you.com/pic/NBA-Kyrie-Irving-3-White-Golden-Basketball-Shoes---1-416.jpg",
                    Description = "The Nike Kyrie 3 is Kyrie Irving's third signature basketball shoe. It features a mix of Flywire, traction pods, Zoom Air, and more."
                },
                new Product
                {
                    ProductId = 5,
                    Name = "Nike Air Force 1",
                    Price = 175,
                    Image = "https://www.sneakerfiles.com/wp-content/uploads/2018/03/nike-air-force-1-low-suede-pack-1.jpg",
                    Description = "Introduced to the world in 1982, the Nike Air Force 1 was the first basketball shoe to feature Nike Air technology, revolutionizing the game forever. From the hardwood to the blacktop to the core of hip-hop culture, today the AF1 stays true to its roots with soft, springy cushioning and a large midsole."
                },
                new Product
                {
                    ProductId = 6,
                    Name = "Nike Zoom Vaporfly",
                    Price = 205,
                    Image = "https://pmcfootwearnews.files.wordpress.com/2018/08/zoom_vaporfly_4_percent_tilt_original.jpg?w=700&h=437&crop=1",
                    Description = "Introducing the Nike Zoom Vaporfly Elite Flyprint. Weighing 11g lighter than the Nike Zoom Vaporfly 4%, this 3-D printed shoe is fast - tracking the future of running with a more breathable upper that boasts almost zero water retention."
                },
                new Product
                {
                    ProductId = 7,
                    Name = "Nike LeBron 15",
                    Price = 215,
                    Image = "https://www.flightclub.com/media/catalog/product/cache/1/image/1600x1140/9df78eab33525d08d6e5fb8d27136e95/8/0/802369_01.jpg",
                    Description = "The upper of the LeBron 15 is made of an innovated high-grade Flyknit material that Nike calls BattleKnit. It is designed by Jason Petrie specifically for the need of LeBron for a durable, comfortable, and highly stretchable upper. The inside of the shoe is lined with thick foam to provide the much needed comfort."
                },
                new Product
                {
                    ProductId = 8,
                    Name = "Jordan 1's",
                    Price = 150,
                    Image = "https://images.solecollector.com/complex/images/c_fill,dpr_2.0,f_auto,fl_lossy,q_auto,w_680/red-velvet-jordan-1-heirness_tmgdsx/red-velvet-jordan-1-heiress",
                    Description = "The sneaker is heavily influenced by the Air Jordan 1's having a leather upper and both a Nike swoosh and a Jumpman plus a Jordan Wings logo. Its first retail debut was on September 3, 2016 in the banned colorway for $185 alongside its air Jordan 1 counterpart."
                },
                new Product
                {
                    ProductId = 9,
                    Name = "Jordan 3's",
                    Price = 300,
                    Image = "https://sneakernews.com/wp-content/uploads/2018/05/where-to-buy-air-jordan-3-katrina.jpg",
                    Description = "The Air Jordan III (3) is Michael Jordan's third signature basketball shoe. It released in 1988 in four colorways of white, black, red, and blue. It was the first Air Jordan to feature visible Air, elephant print, and the Jumpman logo."
                },
                new Product
                {
                    ProductId = 10,
                    Name = "Jordan 4's",
                    Price = 350,
                    Image = "https://sneakernews.com/wp-content/uploads/2018/08/jordan-4-raptors-AQ3816_065-store-list-1.jpg",
                    Description = "AIR JORDAN IV The Air Jordan IV debuted in 1989 and was designed by Tinker Hatfield. It features lightweight netting and plastic wings on the upper as well as visible Max Air. The original colorways of the Air Jordan IV are 'White/Cement,' 'Bred,' 'Military,' and 'Fire Red.'"
                }
            );  
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
    }

}
