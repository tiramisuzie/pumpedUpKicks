using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PumpedUpKicks.Interfaces;
using PumpedUpKicks.Models;
using PumpedUpKicks.Models.Interfaces;

namespace PumpedUpKicks.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IProduct _product;
        private readonly IShoppingCartItem _shoppingCartItem;

        private UserManager<ApplicationUser> _userManager;

        public ShoppingCartController(UserManager<ApplicationUser> userManager, IShoppingCart context, IProduct product, IShoppingCartItem shoppingCartItem)
        {
            _shoppingCart = context;
            _userManager = userManager;
            _product = product;
            _shoppingCartItem = shoppingCartItem;
        }
        

        public async Task<IActionResult> Index()
        {
            dynamic system = new ExpandoObject();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var cart = await _shoppingCart.GetShoppingCart(user.Id);
            var listofitems = await _shoppingCartItem.GetItemsFromCart(cart.ShoppingCartId, user.Id);
            List<Product> productList = new List<Product>();
            foreach(var item in listofitems)
            {
                var product = await _product.GetProduct(item.ProductId);
                productList.Add(product);
            }
            system.list = listofitems;
            system.product = productList;
            return View(system);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItemToCart(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var cart = await _shoppingCart.GetShoppingCart(user.Id);

            var product = cart.ShoppingCartItems.FirstOrDefault(x => x.ProductId == id);
            ShoppingCartItem products = new ShoppingCartItem()
            {
                ShoppingCartId = cart.ShoppingCartId,
                userId = user.Id,
                Quantity = product!=null? product.Quantity+1:1,
                ProductId = id,
            };
            await _shoppingCartItem.CreateCartItem(products);
            return RedirectToAction("Index", "ShoppingCart");       
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var cart = await _shoppingCart.GetShoppingCart(user.Id);
            var product = cart.ShoppingCartItems.FirstOrDefault(x => x.ProductId == id);
            await _shoppingCartItem.DeleteCartItem(product);
            return View("Delete", "ShoppingCart");
        }
    }
}