using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PumpedUpKicks.Interfaces;

namespace PumpedUpKicks.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    public class AdminController : Controller
    {
        private readonly IProduct _shops;
        
        public AdminController(IProduct context)
        {
            _shops = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _shops.GetProducts());
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQty(int id, int qty)
        {
            var p = await _shops.GetProduct(id);
            p.InventoryQty = qty;
            await _shops.UpdateProduct(p);
            return RedirectToAction("Index");
        }
    }
}
