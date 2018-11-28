using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PumpedUpKicks.Data;
using PumpedUpKicks.Interfaces;
using PumpedUpKicks.Models;
using PumpedUpKicks.Models.Interfaces;
using PumpedUpKicks.Models.ViewModels;

namespace PumpedUpKicks.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart _shoppingCart;
        private readonly IProduct _product;
        private readonly IShoppingCartItem _shoppingCartItem;
        private readonly ShopDbContext _shopcontext;


        private UserManager<ApplicationUser> _userManager;

        public ShoppingCartController(UserManager<ApplicationUser> userManager, IShoppingCart context, IProduct product, IShoppingCartItem shoppingCartItem, ShopDbContext shopcontext)
        {
            _shoppingCart = context;
            _userManager = userManager;
            _product = product;
            _shoppingCartItem = shoppingCartItem;
            _shopcontext = shopcontext;
        }
        

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var cart = await _shoppingCart.GetShoppingCart(user.Id);
            
            var listofitems = await _shoppingCartItem.GetItemsFromCart(cart.ShoppingCartId, user.Id);
            List<CartItemViewModel> cvmList = new List<CartItemViewModel>(); 
            
            foreach(var i in listofitems)
            {
                var cvm = new CartItemViewModel();
                cvm.Price = i.Price;
                cvm.ProductId = i.ProductId;
                cvm.ShoppingCartId = i.ShoppingCartId;
                cvm.Quantity = i.Quantity;
                cvm.Name = _shopcontext.Products.Where(x => x.ProductId == cvm.ProductId).Select(p => p.Name).FirstOrDefault().ToString();
                cvmList.Add(cvm);
            }
            return View(cvmList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItemToCart(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var cart = await _shoppingCart.GetShoppingCart(user.Id);
            var prod = await _product.GetProduct(id);

            var product = cart.ShoppingCartItems.FirstOrDefault(x => x.ProductId == id);

            if (product == null)
            {
                ShoppingCartItem products = new ShoppingCartItem()
                {
                    ShoppingCartId = cart.ShoppingCartId,
                    userId = user.Id,
                    Quantity = 1,
                    ProductId = id,
                    Price = prod.Price
                };
                    await _shoppingCartItem.CreateCartItem(products);
            }
            else
            {
                product.Quantity += 1;
                await _shoppingCartItem.UpdateCartItem(product);
            }

            return RedirectToAction("Index", "ShoppingCart");       
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var cart = await _shoppingCart.GetShoppingCart(user.Id);
            var product = cart.ShoppingCartItems.FirstOrDefault(x => x.ProductId == id);
            await _shoppingCartItem.DeleteCartItem(product);
            return View("Delete", "ShoppingCart");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var cart = await _shoppingCart.GetShoppingCart(user.Id);
            var product = cart.ShoppingCartItems.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }

    }
}