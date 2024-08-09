using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Views;
using ECommerce.Core.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface ISellerRepository
    {
        Task<bool> GenerateNewSeller(Seller model);
        Task<Seller> DeleteSeller(string sellerId);
        Task<IQueryable<Seller>> GetAllSellers();
        Task<Seller> GetSellerById(string SellerId);
        Task<Seller> UpdateSellerDetails(Seller model);
        Task<Seller> ChangeCategoryOfSeller(string sellerId, string categoryId);
        Task<Seller> ChangeTypeOfSeller(string sellerId, SellerTypes newType);
        Task<Seller> AddNewSubCategoriesToSeller(string SellerId, params string[] SubCategoriesId);
        Task<Seller> RemoveSubCategoriesFromSeller(string SellerId, params string[] SubCategoriesId);
    }
}
