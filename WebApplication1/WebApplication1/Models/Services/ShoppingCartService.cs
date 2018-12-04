using Microsoft.EntityFrameworkCore;
using PumpedUpKicks.Data;
using PumpedUpKicks.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpedUpKicks.Models.Services
{
    public class ShoppingCartService : IShoppingCartItem
    {
        private ShopDbContext _context;

        public ShoppingCartService(ShopDbContext context)
        {
            _context = context;
        }

        public async Task CreateCartItem(ShoppingCartItem item)
        {
            _context.ShoppingCartItem.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCartItem(ShoppingCartItem item)
        {
            _context.ShoppingCartItem.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ShoppingCartItem>> GetItemsFromCart(string userId)
        {
            return await _context.ShoppingCartItem.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task UpdateCartItem(ShoppingCartItem item)
        {
            _context.ShoppingCartItem.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
