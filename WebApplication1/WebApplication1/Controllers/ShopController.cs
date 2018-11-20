using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PumpedUpKicks.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PumpedUpKicks.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShop _shops;

        public ShopController(IShop context)
        {
            _shops = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _shops.GetProducts());
        }
    }
}
