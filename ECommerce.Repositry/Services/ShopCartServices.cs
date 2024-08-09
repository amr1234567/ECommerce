using ECommerce.Core.Repositories.Manager;
using ECommerce.Repositry.Abstraction;
using ECommerce.Repositry.Models.InputModels;
using ECommerce.Repositry.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Services
{
    internal class ShopCartServices(IManagerRepository managerRepository) : IShopCartServices
    {
        public async Task<ShopCartResponse> AddProductsToShopCart(string shopCartId, params string[] productsId)
        {
            var shopCart = await managerRepository.ShopCartRepository.AddProductsToShopCart(shopCartId, productsId);
            return new ShopCartResponse(shopCart);
        }

        public async Task<ShopCartResponse> AddProductToShopCart(string shopCartId, string productId)
        {
            var shopCart = await managerRepository.ShopCartRepository.AddProductToShopCart(shopCartId, productId);
            return new ShopCartResponse(shopCart);
        }

        public async Task<string> AddShopCart(string userId)
        {
            return await managerRepository.ShopCartRepository.AddShopCart(userId);
        }


        public Task<ShopCartResponse> DeleteShopCart(string shopCartId)
        {
            throw new NotImplementedException();
        }

        public async Task<ShopCartResponse> GetShopCartById(string shopCartId)
        {
            var shopCart = await managerRepository.ShopCartRepository.GetShopCartById(shopCartId);
            return new ShopCartResponse(shopCart);
        }

        public Task<ShopCartResponse> RemoveProductFromShopCart(string shopCartId, string productId)
        {
            throw new NotImplementedException();
        }

        public Task<ShopCartResponse> RemoveProductsFromShopCart(string shopCartId, params string[] productsId)
        {
            throw new NotImplementedException();
        }
    }
}
