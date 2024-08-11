using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Application.Contained;
using ECommerce.Core.Entities.Views;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Abstraction
{
    public interface IProductServices
    {
        Task<bool> AddNewProduct(ProductToAddModel model);
        Task<ProductResponse> IncreaseQuantityOfProductBy(string productId, int quantity);
        Task<ProductResponse> ChangePrice(string productId, double newPrice);
        Task<ProductResponse> AddNewDiscount(string productId, PeriodDiscount discount);
        Task<ProductResponse> RemoveDiscountIfExist(string productId);
        Task<ProductResponse> ChangeDetails(string productId, ProductToEditModel model);
        Task<ProductResponse> TransferProductToNewSeller(string productId, string sellerId);
        Task<ProductResponse> ChangeCategoryForProduct(string productId, string newCategoryId);
        Task<ProductResponse> ChangeSubCategoryForProduct(string productId, string newSubCategoryId);
        Task<ProductResponse> DeleteProduct(string productId);
        Task<ProductResponse> GetProductById(string productId);
        Task<IQueryable<ProductResponse>> GetAllProducts();
        Task<IQueryable<ProductResponse>> GetAllProductsInSubCategory(string subCategoryId);
        Task<IQueryable<ProductResponse>> GetAllProductsInCategory(string categoryId);
        Task<IQueryable<ProductResponse>> GetAllProductsForSeller(string sellerId);
    }
}
