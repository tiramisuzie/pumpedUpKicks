using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpedUpKicks.Models.Interfaces
{
    public interface IShoppingCart
    {
        Task<ShoppingCart> GetShoppingCart(string userId);
    }
}
