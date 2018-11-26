using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PumpedUpKicks.Models;
using PumpedUpKicks.Models.Interfaces;

namespace PumpedUpKicks.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private UserManager<ApplicationUser> _userManager;

        public ShoppingCartController(UserManager<ApplicationUser> userManager, IShoppingCart context)
        {
            _shoppingCart = context;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.Cart = await _shoppingCart.GetShoppingCart(user.Id);
            return View();
        }
    }
}