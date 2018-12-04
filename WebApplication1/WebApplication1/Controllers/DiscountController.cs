using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PumpedUpKicks.Interfaces;
using PumpedUpKicks.Models.ViewModels;

namespace PumpedUpKicks.Controllers
{
    [Authorize(Policy = "DiscountPolicy")]
    public class DiscountController : Controller
    {
        private readonly IProduct _shops;
        private readonly double discount = 0.20;

        public DiscountController(IProduct context)
        {
            _shops = context;

        }

        // GET: Shop
        public async Task<IActionResult> Index()
        {
            var products = await _shops.GetProducts();
            var discountProduct = products.Select(x => new DiscountProductViewModel(x, discount)).ToList();
            return View(discountProduct);
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
            return View(new DiscountProductViewModel(product, discount));
        }
    }
}