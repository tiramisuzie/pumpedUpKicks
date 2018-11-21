using Microsoft.EntityFrameworkCore;
using PumpedUpKicks.Data;
using PumpedUpKicks.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PumpedUpKicks.Models.Services
{
    public class ShopService : IShop
    {

        private ShopDbContext _context;

        public ShopService(ShopDbContext context)
        {
            _context = context;
        }

        //Get list of all products
        public async Task<List<Shop>> GetProducts()
        {
            return await _context.Shops.ToListAsync();
        }
        
        public async Task<Shop> GetShop(int id)
        {
            return await _context.Shops.FirstOrDefaultAsync(x => x.ID == id);
        }
    }
}
