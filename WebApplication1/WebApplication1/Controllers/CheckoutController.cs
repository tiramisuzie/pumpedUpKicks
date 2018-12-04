using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PumpedUpKicks.Models;
using PumpedUpKicks.Interfaces;
using PumpedUpKicks.Models.Interfaces;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PumpedUpKicks.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IShoppingCartItem _shoppingCartItem;
        public CheckoutController(UserManager<ApplicationUser> userManager, IShoppingCartItem shoppingCartItem)
        {
            _userManager = userManager;
            _shoppingCartItem = shoppingCartItem;
        }
        

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userID = _userManager.GetUserId(Request.HttpContext.User);

            var listOfCartItems = await _shoppingCartItem.GetItemsFromCart(userID);

            return View(listOfCartItems);
        }
    }
}
