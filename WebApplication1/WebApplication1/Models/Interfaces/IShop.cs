using PumpedUpKicks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PumpedUpKicks.Interfaces
{
    public interface IShop
    {
        Task<List<Shop>> GetProducts();
        
        Task<Shop> GetShop(int id);
    }
}
