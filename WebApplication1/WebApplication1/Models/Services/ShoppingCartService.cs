using Microsoft.EntityFrameworkCore;
using PumpedUpKicks.Data;
using PumpedUpKicks.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpedUpKicks.Models.Services
{
    public class ShoppingCartService : IShoppingCart
    {
        private ShopDbContext _context;

        public ShoppingCartService(ShopDbContext context)
        {
            _context = context;
        }
        
        public async Task<ShoppingCart> GetShoppingCart(string userId)
        {
            return await _context.ShoppingCarts.Include(x => x.ShoppingCartItems).FirstOrDefaultAsync(x => x.UserId==userId);
        }
    }
}
