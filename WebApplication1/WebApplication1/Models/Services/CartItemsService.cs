﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PumpedUpKicks.Interfaces;
using PumpedUpKicks.Models.Interfaces;
using PumpedUpKicks.Data;
using Microsoft.EntityFrameworkCore;

namespace PumpedUpKicks.Models.Services
{
    public class CartItemsService : IShoppingCartItem
    {
        ShopDbContext _shopdbcontex; 

        public CartItemsService(ShopDbContext context)
        {
            _shopdbcontex = context;
        }

        public async Task CreateCartItem(ShoppingCartItem item)
        {
            _shopdbcontex.ShoppingCartItem.Add(item);
            await _shopdbcontex.SaveChangesAsync();
        }

        public async Task DeleteCartItem(ShoppingCartItem item)
        {
            _shopdbcontex.ShoppingCartItem.Remove(item);
            await _shopdbcontex.SaveChangesAsync();
        }

        public async Task<List<ShoppingCartItem>> GetItemsFromCart(int id, string userId)
        {
            List<ShoppingCartItem> cartItems = await _shopdbcontex.ShoppingCartItem.Where(x => x.ShoppingCartId == id && x.userId == userId).ToListAsync();
            return cartItems;
        }

        public async Task UpdateCartItem(ShoppingCartItem item)
        {
            _shopdbcontex.ShoppingCartItem.Update(item);
            await _shopdbcontex.SaveChangesAsync();
        }
    }
}
