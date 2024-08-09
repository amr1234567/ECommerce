using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Views;
using ECommerce.Core.Exceptions;
using ECommerce.Core.Helpers.Enums;
using ECommerce.Core.Repositories;
using ECommerce.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repositories
{
    internal class SellerRepository(ECommerceContext context) : ISellerRepository
    {
        public async Task<Seller> AddNewSubCategoriesToSeller(string sellerId, params string[] SubCategoriesId)
        {
            var seller = await GetSellerById(sellerId);
            foreach (var subCategoryId in SubCategoriesId)
            {
                var subCategory = await context.SubCategories.FirstOrDefaultAsync(c => c.Id == subCategoryId)
                    ?? throw new NotFoundException($"Sub Category with id {subCategoryId}");
            }
            seller.SubCategoriesIds.AddRange(SubCategoriesId);
            context.Sellers.Update(seller);
            await context.SaveChangesAsync();
            return seller;
        }

        public async Task<Seller> DeleteSeller(string sellerId)
        {
            var seller = await GetSellerById(sellerId);
            context.Sellers.Remove(seller);
            await context.SaveChangesAsync();
            return seller;
        }


        public async Task<bool> GenerateNewSeller(Seller model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var id = new ObjectId();
            model.Id = id.ToString();
            await context.Sellers.AddAsync(model);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<IQueryable<Seller>> GetAllSellers()
        {
            return Task.FromResult(context.Sellers.AsNoTracking());
        }

        public async Task<Seller> GetSellerById(string sellerId)
        {
            return await context.Sellers.FirstOrDefaultAsync(s => s.Id.Equals(sellerId))
                ?? throw new NotFoundException($"Seller with id {sellerId}");
        }

        public async Task<Seller> UpdateSellerDetails(Seller model)
        {
            var seller = await GetSellerById(model.Id);
            seller.GeneralLocation = string.IsNullOrEmpty(model.GeneralLocation) ? seller.GeneralLocation : model.GeneralLocation;
            seller.Name = string.IsNullOrEmpty(model.Name) ? seller.Name : model.Name;
            seller.Description = string.IsNullOrEmpty(model.Description) ? seller.Description : model.Description;
            seller.LocationUrl = string.IsNullOrEmpty(model.LocationUrl) ? seller.LocationUrl : model.LocationUrl;
            context.Sellers.Update(seller);
            await context.SaveChangesAsync();
            return seller;
        }

        public async Task<Seller> ChangeCategoryOfSeller(string sellerId, string categoryId)
        {
            var seller = await GetSellerById(sellerId);
            seller.CategoryId = categoryId;
            seller.SubCategoriesIds = [];
            await context.SaveChangesAsync();
            return seller;
        }

        public async Task<Seller> ChangeTypeOfSeller(string sellerId, SellerTypes newType)
        {
            var seller = await GetSellerById(sellerId);
            seller.SellerType = newType;
            await context.SaveChangesAsync();
            return seller;
        }

        public async Task<Seller> RemoveSubCategoriesFromSeller(string sellerId, params string[] subCategoriesId)
        {
            var seller = await GetSellerById(sellerId);
            foreach (var subCategoryId in subCategoriesId)
            {
                var subCategory = await context.SubCategories.FirstOrDefaultAsync(c => c.Id == subCategoryId)
                    ?? throw new NotFoundException($"Sub Category with id {subCategoryId}");
                seller.SubCategoriesIds.Remove(subCategoryId);
            }
            context.Sellers.Update(seller);
            await context.SaveChangesAsync();
            return seller;
        }
    }
}
