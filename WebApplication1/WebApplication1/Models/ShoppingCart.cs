using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PumpedUpKicks.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
