using Microsoft.EntityFrameworkCore;
using PumpedUpKicks.Data;
using PumpedUpKicks.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PumpedUpKicks.Models.Services
{
    public class ProductService : IProduct
    {

        private ShopDbContext _context;

        public ProductService(ShopDbContext context)
        {
            _context = context;
        }

        //Get list of all products
        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
        
        public async Task<Product> GetProduct(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
