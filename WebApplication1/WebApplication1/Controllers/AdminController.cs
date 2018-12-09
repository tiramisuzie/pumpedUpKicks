using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PumpedUpKicks.Interfaces;
using PumpedUpKicks.Models;

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
        public async Task<IActionResult> FormAction(int id, int qty, string update, string delete)
        {
            if (!string.IsNullOrEmpty(update))
            {
                await UpdateQty(id, qty);
            }

            if (!string.IsNullOrEmpty(delete))
            {
                await DeleteProduct(id);
            }

            return RedirectToAction("Index");
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product p)
        {
            await _shops.CreateProduct(p);
            return RedirectToAction("Index");
        }

        private async Task<bool> UpdateQty(int id, int qty)
        {
            var p = await _shops.GetProduct(id);
            p.InventoryQty = qty;
            await _shops.UpdateProduct(p);
            return true;
        }

        private async Task<bool> DeleteProduct(int id)
        {
            var p = await _shops.GetProduct(id);
            await _shops.DeleteProduct(p);
            return true;
        }
    }
}
