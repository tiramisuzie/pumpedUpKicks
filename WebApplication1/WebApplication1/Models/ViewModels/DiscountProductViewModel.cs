using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpedUpKicks.Models.ViewModels
{
    public class DiscountProductViewModel : Product
    {
        public DiscountProductViewModel(Product p, double d)
        {
            ProductId = p.ProductId;

            Image = p.Image;

            Name = p.Name;

            Price = Convert.ToInt32(p.Price * d);

            Description = p.Description;
        }
    }
}
