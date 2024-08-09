using ECommerce.Core.Entities.Application;
using ECommerce.Repositry.Models.InputModels;
using ECommerce.Repositry.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Abstraction
{
    public interface IShopCartServices
    {
        Task<string> AddShopCart(string userId);
        Task<ShopCartResponse> AddProductToShopCart(string shopCartId, string productId);
        Task<ShopCartResponse> AddProductsToShopCart(string shopCartId, params string[] productsId);
        Task<ShopCartResponse> RemoveProductFromShopCart(string shopCartId, string productId);
        Task<ShopCartResponse> RemoveProductsFromShopCart(string shopCartId, params string[] productsId);
        Task<ShopCartResponse> DeleteShopCart(string shopCartId);
        Task<ShopCartResponse> GetShopCartById(string shopCartId);
    }
}
