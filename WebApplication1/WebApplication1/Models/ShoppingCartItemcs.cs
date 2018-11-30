using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PumpedUpKicks.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public string UserId { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }

        public int Price { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }
    }
}
