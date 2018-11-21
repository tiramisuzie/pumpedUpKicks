using Microsoft.EntityFrameworkCore;
using PumpedUpKicks.Models;

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
            modelBuilder.Entity<Shop>().HasData(
                new Shop
                {
                    ID = 1,
                    Name = "Nike Air Max 97",
                    Description = "Classic fresh and multiple colorways"
                },
                 new Shop
                 {
                     ID = 2,
                     Name = "Nike Air Max 95",
                     Description = "Classic fresh and multiple colorways"
                 },
                  new Shop
                  {
                      ID = 3,
                      Name = "Nike Air Max",
                      Description = "Classic fresh and multiple colorways"
                  },
                   new Shop
                   {
                       ID = 4,
                       Name = "Nike Kyrie 3",
                       Description = "Classic fresh and multiple colorways"
                   },
                    new Shop
                    {
                        ID = 5,
                        Name = "Nike Air Force 1",
                        Description = "Classic fresh and multiple colorways"
                    },
                     new Shop
                     {
                         ID = 6,
                         Name = "Nike Zoom Vaporfly",
                         Description = "Classic fresh and multiple colorways"
                     },
                      new Shop
                      {
                          ID = 7,
                          Name = "Nike LeBron 15",
                          Description = "Classic fresh and multiple colorways"
                      },
                       new Shop
                       {
                           ID = 8,
                           Name = "Jordan 1's",
                           Description = "Classic fresh and multiple colorways"
                       },
                        new Shop
                        {
                            ID = 9,
                            Name = "Jordan 3's",
                            Description = "Classic fresh and multiple colorways"
                        },
                         new Shop
                         {
                             ID = 10,
                             Name = "Jordan 4's",
                             Description = "Classic fresh and multiple colorways"
                         }

                );
        }
        public DbSet<Shop> Shops { get; set; }
    }

}
