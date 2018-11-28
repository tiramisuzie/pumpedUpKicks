using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpedUpKicks.Models.ViewModels;

namespace PumpedUpKicks.Models.Interfaces
{
    public interface IShoppingCartItem
    {
        Task CreateCartItem(ShoppingCartItem item);
        Task DeleteCartItem(ShoppingCartItem item);
        Task UpdateCartItem(ShoppingCartItem item);
        Task<List<ShoppingCartItem>> GetItemsFromCart(int id, string userId);
    }
}
