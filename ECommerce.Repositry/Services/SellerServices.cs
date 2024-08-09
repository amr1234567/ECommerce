using ECommerce.Core.Helpers.Enums;
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
    internal class SellerServices(IManagerRepository managerRepository) : ISellerServices
    {
        public Task<SellerResponse> AddNewSubCategoriesToSeller(string SellerId, params string[] SubCategoriesId)
        {
            throw new NotImplementedException();
        }

        public Task<SellerResponse> ChangeCategoryOfSeller(string sellerId, string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<SellerResponse> ChangeTypeOfSeller(string sellerId, SellerTypes newType)
        {
            throw new NotImplementedException();
        }

        public Task<SellerResponse> DeleteSeller(string sellerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GenerateNewSeller(SellerToAddModel model)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductResponse>> GetAllProductsForSeller(string sellerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<SellerResponse>> GetAllSellers()
        {
            throw new NotImplementedException();
        }

        public Task<SellerResponse> GetSellerById(string SellerId)
        {
            throw new NotImplementedException();
        }

        public Task<SellerResponse> RemoveSubCategoriesFromSeller(string SellerId, params string[] SubCategoriesId)
        {
            throw new NotImplementedException();
        }

        public Task<SellerResponse> UpdateSellerDetails(SellerToEditModel model)
        {
            throw new NotImplementedException();
        }
    }
}
