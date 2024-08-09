using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Application.Contained;
using ECommerce.Core.Exceptions;
using ECommerce.Core.Repositories;
using ECommerce.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repositories
{
    internal class ShopCartRepository(ECommerceContext context) : IShopCartRepository
    {
        public async Task<ShopCart> AddProductsToShopCart(string shopCartId, params string[] productsId)
        {
            ShopCart? shopCart = null;
            foreach (var productId in productsId)
            {
                shopCart = await AddProductToShopCart(shopCartId, productId);
            }
            await context.SaveChangesAsync();
            return shopCart is null ? await GetShopCartById(shopCartId) : shopCart;
        }

        public async Task<ShopCart> AddProductToShopCart(string shopCartId, string productId)
        {

            var shopCart = await GetShopCartById(shopCartId);
            var item = shopCart.Items.FirstOrDefault(item => item.ProductID == productId);
            if (item is not null)
            {
                item.ProductQuantity++;
                item.TotalItemPrice = item.ProductPrice * item.ProductQuantity;
                return shopCart;
            }
            var product = await context.Products.FirstOrDefaultAsync(p => p.Id.Equals(productId))
                    ?? throw new NotFoundException($"Product with id {productId}");
            shopCart.Items.Add(new ShopCartItem
            {
                ProductID = productId,
                ProductPrice = product.CurrentPrice,
                ProductQuantity = 1,
                TotalItemPrice = product.CurrentPrice
            });

            await context.SaveChangesAsync();
            return shopCart;
        }

        public async Task<string> AddShopCart(string userId)
        {
            var id = new ObjectId();
            var shopCart = new ShopCart
            {
                Id = id.ToString(),
                UserId = userId
            };
            await context.ShopCarts.AddAsync(shopCart);
            await context.SaveChangesAsync();
            var shopCartFromDb = await GetShopCartByUserId(userId);
            return shopCartFromDb.Id;
        }

        public async Task<ShopCart> DeleteShopCart(string shopCartId)
        {
            var shopCart = await GetShopCartById(shopCartId);
            context.ShopCarts.Remove(shopCart);
            await context.SaveChangesAsync();
            return shopCart;
        }

        public async Task<ShopCart> EmptyShopCart(string shopCartId)
        {
            var shopCart = await GetShopCartById(shopCartId);
            shopCart.Items = [];
            context.ShopCarts.Update(shopCart);
            await context.SaveChangesAsync();
            return shopCart;
        }

        public async Task<ShopCart> GetShopCartById(string shopCartId)
        {
            return await context.ShopCarts.FirstOrDefaultAsync(s => s.Id.Equals(shopCartId))
                ?? throw new NotFoundException($"Shop Cart with id {shopCartId}");
        }

        public async Task<ShopCart> RemoveProductFromShopCart(string shopCartId, string productId)
        {
            var shopCart = await GetShopCartById(shopCartId);
            var item = shopCart.Items.FirstOrDefault(x => x.ProductID.Equals(productId))
                ?? throw new NotFoundException($"product with {productId}");
            if (item.ProductQuantity > 1)
                item.ProductQuantity--;
            else if (item.ProductQuantity == 1)
                shopCart.Items.Remove(item);

            await context.SaveChangesAsync();
            return shopCart;
        }

        public async Task<ShopCart> RemoveProductsFromShopCart(string shopCartId, params string[] productsId)
        {
            ShopCart? shopCart = null;
            foreach (var productId in productsId)
            {
                shopCart = await RemoveProductFromShopCart(shopCartId, productId);
            }
            await context.SaveChangesAsync();
            return shopCart is null ? await GetShopCartById(shopCartId) : shopCart;
        }

        private async Task<ShopCart> GetShopCartByUserId(string userId)
        {
            return await context.ShopCarts.FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
