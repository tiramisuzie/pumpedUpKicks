using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpedUpKicks.Models.ViewModels
{
    public class CartItemViewModel
    {
        public int ShoppingCartId { get; set; }
        public string userId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
    }
}
