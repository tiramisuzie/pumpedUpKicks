using System.Collections.Generic;
using System.Threading.Tasks;

namespace PumpedUpKicks.Models.Interfaces
{
    public interface IShoppingCartItem
    {
        Task CreateCartItem(ShoppingCartItem item);

        Task DeleteCartItem(ShoppingCartItem item);

        Task UpdateCartItem(ShoppingCartItem item);

        Task<List<ShoppingCartItem>> GetItemsFromCart(string userId);
    }
}
