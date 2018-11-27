using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PumpedUpKicks.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PumpedUpKicks.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProduct _shops;

        public ShopController(IProduct context)
        {
            _shops = context;
        }

        // GET: Shop
        public async Task<IActionResult> Index()
        {
            return View(await _shops.GetProducts());
        }

        // GET: Shop/3
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var product = await _shops.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
