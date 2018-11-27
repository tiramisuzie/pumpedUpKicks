using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpedUpKicks.Interfaces;
using PumpedUpKicks.Models.Interfaces;
using PumpedUpKicks.Data;
using Microsoft.EntityFrameworkCore;

namespace PumpedUpKicks.Models.Services
{
    public class CartItemsService : IShoppingCartItem
    {
        ShopDbContext _shopdbcontex; 

        public CartItemsService(ShopDbContext context)
        {
            _shopdbcontex = context;
        }

        public async Task CreateCartItem(ShoppingCartItem item)
        {
            _shopdbcontex.ShoppingCartItem.Add(item);
            await _shopdbcontex.SaveChangesAsync();
        }

        public Task DeleteCartItem(ShoppingCartItem item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ShoppingCartItem>> GetItemsFromCart(int id, string userId)
        {
            List<ShoppingCartItem> cartItems = await _shopdbcontex.ShoppingCartItem.Where(x => x.ShoppingCartId == id && x.userId == userId).ToListAsync();
            return cartItems;
        }

        public Task UpdateCartItem(ShoppingCartItem item)
        {
            throw new NotImplementedException();
        }
    }
}
