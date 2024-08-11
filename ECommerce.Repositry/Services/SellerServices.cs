using ECommerce.Core.Entities.Application;
using ECommerce.Core.Helpers.Enums;
using ECommerce.Core.Repositories.Manager;
using ECommerce.Repository.Abstraction;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using MongoDB.Driver.Core.Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Services
{
    internal class SellerServices(IManagerRepository managerRepository) : ISellerServices
    {
        public async Task<SellerResponse> AddNewSubCategoriesToSeller(string SellerId, params string[] SubCategoriesId)
        {
            var seller = await managerRepository.SellerRepository.AddNewSubCategoriesToSeller(SellerId, SubCategoriesId);
            return new SellerResponse
            {
                Id = seller.Id,
                Name = seller.Name,
                Description = seller.Description,
                CategoryId = seller.CategoryId,
                GeneralLocation = seller.GeneralLocation,
                LocationUrl = seller.LocationUrl,
                SellerType = seller.SellerType.ToString(),
                CategoryName = managerRepository.CategoryRepository.GetCategoryById(seller.CategoryId).Result.Name,
                SubCategories = seller.SubCategoriesIds.Select(c => new SubCategoryForSellerResponse
                {
                    Id = c,
                    Name = managerRepository.SubCategoryRepository.GetSubCategoryBuyId(c).Result.Name,
                }).ToList()
            };
        }

        public async Task<SellerResponse> ChangeCategoryOfSeller(string sellerId, string categoryId)
        {
            var seller = await managerRepository.SellerRepository.ChangeCategoryOfSeller(sellerId, categoryId);
            return new SellerResponse
            {
                Id = seller.Id,
                Name = seller.Name,
                Description = seller.Description,
                CategoryId = seller.CategoryId,
                GeneralLocation = seller.GeneralLocation,
                LocationUrl = seller.LocationUrl,
                SellerType = seller.SellerType.ToString(),
                CategoryName = managerRepository.CategoryRepository.GetCategoryById(seller.CategoryId).Result.Name,
                SubCategories = seller.SubCategoriesIds.Select(c => new SubCategoryForSellerResponse
                {
                    Id = c,
                    Name = managerRepository.SubCategoryRepository.GetSubCategoryBuyId(c).Result.Name,
                }).ToList()
            };
        }

        public async Task<SellerResponse> ChangeTypeOfSeller(string sellerId, SellerTypes newType)
        {
            var seller = await managerRepository.SellerRepository.ChangeTypeOfSeller(sellerId, newType);
            return new SellerResponse
            {
                Id = seller.Id,
                Name = seller.Name,
                Description = seller.Description,
                CategoryId = seller.CategoryId,
                GeneralLocation = seller.GeneralLocation,
                LocationUrl = seller.LocationUrl,
                SellerType = seller.SellerType.ToString(),
                CategoryName = managerRepository.CategoryRepository.GetCategoryById(seller.CategoryId).Result.Name,
                SubCategories = seller.SubCategoriesIds.Select(c => new SubCategoryForSellerResponse
                {
                    Id = c,
                    Name = managerRepository.SubCategoryRepository.GetSubCategoryBuyId(c).Result.Name,
                }).ToList()
            };
        }

        public async Task<SellerResponse> DeleteSeller(string sellerId)
        {
            var seller = await managerRepository.SellerRepository.DeleteSeller(sellerId);
            return new SellerResponse
            {
                Id = seller.Id,
                Name = seller.Name,
                Description = seller.Description,
                CategoryId = seller.CategoryId,
                GeneralLocation = seller.GeneralLocation,
                LocationUrl = seller.LocationUrl,
                SellerType = seller.SellerType.ToString(),
                CategoryName = managerRepository.CategoryRepository.GetCategoryById(seller.CategoryId).Result.Name,
                SubCategories = seller.SubCategoriesIds.Select(c => new SubCategoryForSellerResponse
                {
                    Id = c,
                    Name = managerRepository.SubCategoryRepository.GetSubCategoryBuyId(c).Result.Name,
                }).ToList()
            };
        }

        public async Task<bool> GenerateNewSeller(SellerToAddModel model)
        {
            var res = await managerRepository.SellerRepository.GenerateNewSeller(model.ToModel());
            return res;
        }

        public async Task<IQueryable<ProductResponse>> GetAllProductsForSeller(string sellerId)
        {
            var products = await managerRepository.ProductRepository.GetAllProductsForSeller(sellerId);
            return products.Select(product => new ProductResponse
            {
                ProductDescription = product.ProductDescription,
                DiscountPrecentage = product.DiscountPrecentage,
                FinalDateForDiscount = product.FinalDateForDiscount,
                FirstDateForDiscount = product.FirstDateForDiscount,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SubCategoryId = product.SubCategoryId,
                SubCategoryName = product.SubCategoryName,
                SellerId = product.SellerId,
                SellerName = product.SellerName,
            });
        }

        public async Task<IQueryable<SellerResponse>> GetAllSellers()
        {
            var sellers = await managerRepository.SellerRepository.GetAllSellers();
            return sellers.Select(seller => new SellerResponse
            {
                Id = seller.Id,
                Name = seller.Name,
                Description = seller.Description,
                CategoryId = seller.CategoryId,
                GeneralLocation = seller.GeneralLocation,
                LocationUrl = seller.LocationUrl,
                SellerType = seller.SellerType.ToString(),
                CategoryName = managerRepository.CategoryRepository.GetCategoryById(seller.CategoryId).Result.Name,
                SubCategories = seller.SubCategoriesIds.Select(c => new SubCategoryForSellerResponse
                {
                    Id = c,
                    Name = managerRepository.SubCategoryRepository.GetSubCategoryBuyId(c).Result.Name,
                }).ToList()
            });
        }

        public async Task<SellerResponse> GetSellerById(string SellerId)
        {
            var seller = await managerRepository.SellerRepository.GetSellerById(SellerId);
            return new SellerResponse
            {
                Id = seller.Id,
                Name = seller.Name,
                Description = seller.Description,
                CategoryId = seller.CategoryId,
                GeneralLocation = seller.GeneralLocation,
                LocationUrl = seller.LocationUrl,
                SellerType = seller.SellerType.ToString(),
                CategoryName = managerRepository.CategoryRepository.GetCategoryById(seller.CategoryId).Result.Name,
                SubCategories = seller.SubCategoriesIds.Select(c => new SubCategoryForSellerResponse
                {
                    Id = c,
                    Name = managerRepository.SubCategoryRepository.GetSubCategoryBuyId(c).Result.Name,
                }).ToList()
            };
        }

        public async Task<SellerResponse> RemoveSubCategoriesFromSeller(string SellerId, params string[] SubCategoriesId)
        {
            var seller = await managerRepository.SellerRepository.RemoveSubCategoriesFromSeller(SellerId, SubCategoriesId);
            return new SellerResponse
            {
                Id = seller.Id,
                Name = seller.Name,
                Description = seller.Description,
                CategoryId = seller.CategoryId,
                GeneralLocation = seller.GeneralLocation,
                LocationUrl = seller.LocationUrl,
                SellerType = seller.SellerType.ToString(),
                CategoryName = managerRepository.CategoryRepository.GetCategoryById(seller.CategoryId).Result.Name,
                SubCategories = seller.SubCategoriesIds.Select(c => new SubCategoryForSellerResponse
                {
                    Id = c,
                    Name = managerRepository.SubCategoryRepository.GetSubCategoryBuyId(c).Result.Name,
                }).ToList()
            };
        }

        public async Task<SellerResponse> UpdateSellerDetails(SellerToEditModel model)
        {
            var seller = await managerRepository.SellerRepository.UpdateSellerDetails(model.ToModel());
            return new SellerResponse
            {
                Id = seller.Id,
                Name = seller.Name,
                Description = seller.Description,
                CategoryId = seller.CategoryId,
                GeneralLocation = seller.GeneralLocation,
                LocationUrl = seller.LocationUrl,
                SellerType = seller.SellerType.ToString(),
                CategoryName = managerRepository.CategoryRepository.GetCategoryById(seller.CategoryId).Result.Name,
                SubCategories = seller.SubCategoriesIds.Select(c => new SubCategoryForSellerResponse
                {
                    Id = c,
                    Name = managerRepository.SubCategoryRepository.GetSubCategoryBuyId(c).Result.Name,
                }).ToList()
            };
        }
    }
}
