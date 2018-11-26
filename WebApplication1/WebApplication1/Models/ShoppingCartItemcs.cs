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
        [Key]
        public int ShoppingCartItemId { get; set; }
        
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
