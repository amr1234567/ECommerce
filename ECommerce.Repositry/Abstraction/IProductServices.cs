using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Views;
using ECommerce.Repositry.Models.InputModels;
using ECommerce.Repositry.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Abstraction
{
    public interface IProductServices
    {
        Task<bool> AddNewProduct(ProductToAddModel model);
        Task<ProductResponse> UpdateProductDetails(ProductToEditModel model);
        Task<ProductResponse> ChangeCategoryForProduct(string productId, string newCategoryId);
        Task<ProductResponse> ChangeSubCategoryForProduct(string productId, string newSubCategoryId);
        Task<ProductResponse> DeleteProduct(string productId);
        Task<ProductResponse> GetProductById(string productId);
        Task<List<ProductResponse>> GetAllProducts();
        Task<List<ProductResponse>> GetAllProductsInSubCategory(string subCategoryId);
        Task<List<ProductResponse>> GetAllProductsInCategory(string categoryId);
        Task<List<ProductResponse>> GetAllProductsForSeller(string sellerId);
    }
}
