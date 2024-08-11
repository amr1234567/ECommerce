using ECommerce.Core.Entities.Application;
using ECommerce.Core.Exceptions;
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
    internal class SubCategoryRepository(ECommerceContext context) : ISubCategoryRepository
    {
        public async Task<bool> AddSubCategory(SubCategory model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var id = new ObjectId();
            model.Id = id.ToString();
            await context.SubCategories.AddAsync(model);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<SubCategory> DeleteSubCategory(string SubCategoryId)
        {
            SubCategory subCategory = await GetSubCategoryById(SubCategoryId);
            context.SubCategories.Remove(subCategory);
            await context.SaveChangesAsync();
            return subCategory;
        }

        private async Task<SubCategory> GetSubCategoryById(string subCategoryId)
        {
            return await context.SubCategories.FirstOrDefaultAsync(c => c.Id.Equals(subCategoryId))
                ?? throw new NotFoundException($"Sub category with id {subCategoryId}");
        }

        public async Task<SubCategory> EditSubCategory(SubCategory model)
        {
            var subCategory = await GetSubCategoryById(model.Id);
            subCategory.Name = string.IsNullOrEmpty(model.Name) ? subCategory.Name : model.Name;
            subCategory.Description = string.IsNullOrEmpty(model.Description) ? subCategory.Description : model.Description;
            context.SubCategories.Update(subCategory);
            await context.SaveChangesAsync();
            return subCategory;
        }

        public Task<IQueryable<SubCategory>> GetAllSubCategories()
        {
            return Task.FromResult(context.SubCategories.AsNoTracking());
        }

        public async Task<List<SubCategory>> GetAllSubCategoriesForSeller(string sellerId)
        {
            var seller = await context.Sellers.FirstOrDefaultAsync(s => s.Id.Equals(sellerId))
                ?? throw new NotFoundException($"seller with id {sellerId}");
            var subCategories = new List<SubCategory>();
            foreach (var subCategoryId in seller.SubCategoriesIds)
            {
                var subCategory = await context.SubCategories.FirstOrDefaultAsync(s => s.Id.Equals(subCategoryId))
                     ?? throw new NotFoundException($"sub category with id {subCategoryId}"); ;
                subCategories.Add(subCategory);
            }
            return subCategories;
        }

        public async Task<SubCategory> ChangeCategoryOfSubCategory(string subCategoryId, string newCategoryId)
        {
            if (string.IsNullOrEmpty(subCategoryId))
                throw new ParameterIsNullOrEmptyException(nameof(subCategoryId));
            if (string.IsNullOrEmpty(newCategoryId))
                throw new ParameterIsNullOrEmptyException(nameof(newCategoryId));
            var subCategory = await GetSubCategoryById(subCategoryId);
            var category = await context.Categories.FirstOrDefaultAsync(c => c.Id.Equals(newCategoryId))
                ?? throw new NotFoundException($"Category with id {newCategoryId}");
            subCategory.CategoryId = newCategoryId;
            context.SubCategories.Update(subCategory);
            await context.SaveChangesAsync();
            return subCategory;
        }

        public async Task<SubCategory> GetSubCategoryBuyId(string subCategoryId)
        {
            if (string.IsNullOrEmpty(subCategoryId))
                throw new ParameterIsNullOrEmptyException(nameof(subCategoryId));
            var subCategory = await context.SubCategories.FirstOrDefaultAsync(c => c.Id.Equals(subCategoryId))
                ?? throw new NotFoundException($"sub category with id {subCategoryId}");
            return subCategory;
        }
    }
}
