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
    internal class ProductServices(IManagerRepository managerRepository) : IProductServices
    {
        public Task<bool> AddNewProduct(ProductToAddModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> ChangeCategoryForProduct(string productId, string newCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> ChangeSubCategoryForProduct(string productId, string newSubCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> DeleteProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductResponse>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductResponse>> GetAllProductsForSeller(string sellerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductResponse>> GetAllProductsInCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductResponse>> GetAllProductsInSubCategory(string subCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> GetProductById(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> UpdateProductDetails(ProductToEditModel model)
        {
            throw new NotImplementedException();
        }
    }
}
