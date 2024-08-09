using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface IProductRepository
    {
        Task<bool> AddNewProduct(Product model);
        Task<ProductSellerCategorySubCategory> UpdateProductDetails(Product model);
        Task<ProductSellerCategorySubCategory> ChangeCategoryForProduct(string productId, string newCategoryId);
        Task<ProductSellerCategorySubCategory> ChangeSubCategoryForProduct(string productId, string newSubCategoryId);
        Task<ProductSellerCategorySubCategory> DeleteProduct(string productId);
        Task<ProductSellerCategorySubCategory> GetProductById(string productId);
        Task<IQueryable<ProductSellerCategorySubCategory>> GetAllProducts();
        Task<IQueryable<ProductSellerCategorySubCategory>> GetAllProductsInSubCategory(string subCategoryId);
        Task<IQueryable<ProductSellerCategorySubCategory>> GetAllProductsInCategory(string categoryId);
        Task<IQueryable<ProductSellerCategorySubCategory>> GetAllProductsForSeller(string sellerId);

    }
}
