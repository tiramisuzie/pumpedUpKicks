using PumpedUpKicks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PumpedUpKicks.Interfaces
{
    public interface IProduct
    {
        Task<List<Product>> GetProducts();
        
        Task<Product> GetProduct(int id);

        Task UpdateProduct(Product p);
    }
}
