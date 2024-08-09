using ECommerce.Core.Entities.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface IShopCartRepository
    {
        Task<string> AddShopCart(string userId);
        Task<ShopCart> AddProductToShopCart(string shopCartId, string productId);
        Task<ShopCart> AddProductsToShopCart(string shopCartId, params string[] productsId);
        Task<ShopCart> RemoveProductFromShopCart(string shopCartId, string productId);
        Task<ShopCart> RemoveProductsFromShopCart(string shopCartId, params string[] productsId);
        Task<ShopCart> DeleteShopCart(string shopCartId);
        Task<ShopCart> GetShopCartById(string shopCartId);
        Task<ShopCart> EmptyShopCart(string shopCartId);
    }
}
