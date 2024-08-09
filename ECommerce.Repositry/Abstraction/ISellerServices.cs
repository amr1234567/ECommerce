using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Views;
using ECommerce.Core.Helpers.Enums;
using ECommerce.Repositry.Models.InputModels;
using ECommerce.Repositry.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Abstraction
{
    public interface ISellerServices
    {
        Task<bool> GenerateNewSeller(SellerToAddModel model);
        Task<SellerResponse> DeleteSeller(string sellerId);
        Task<List<SellerResponse>> GetAllSellers();
        Task<SellerResponse> GetSellerById(string SellerId);
        Task<SellerResponse> UpdateSellerDetails(SellerToEditModel model);
        Task<SellerResponse> ChangeCategoryOfSeller(string sellerId, string categoryId);
        Task<SellerResponse> ChangeTypeOfSeller(string sellerId, SellerTypes newType);
        Task<SellerResponse> AddNewSubCategoriesToSeller(string SellerId, params string[] SubCategoriesId);
        Task<SellerResponse> RemoveSubCategoriesFromSeller(string SellerId, params string[] SubCategoriesId);
        Task<List<ProductResponse>> GetAllProductsForSeller(string sellerId);
    }
}
