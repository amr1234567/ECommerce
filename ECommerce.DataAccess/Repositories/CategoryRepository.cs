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
    internal class CategoryRepository(ECommerceContext context) : ICategoryRepository
    {
        public async Task<bool> AddNewCategory(Category model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var id = new ObjectId();
            model.Id = id.ToString();
            await context.Categories.AddAsync(model);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Category> EditCategoryDetails(Category model)
        {
            var category = await GetCategoryById(model.Id);
            category.Description = string.IsNullOrEmpty(model.Description) ? category.Description : model.Description;
            category.Name = string.IsNullOrEmpty(model.Name) ? category.Name : model.Name;
            context.Categories.Update(category);
            await context.SaveChangesAsync();
            return category;
        }

        public Task<IQueryable<Category>> GetAllCategories()
        {
            return Task.FromResult(context.Categories.AsQueryable());
        }

        public async Task<Category> GetCategoryById(string categoryId) =>
            await context.Categories.FirstOrDefaultAsync(c => c.Id.Equals(categoryId)) ??
            throw new NotFoundException($"Category with id {categoryId}");

        private async Task<SubCategory> GetSubCategoryById(string subCategoryId) =>
            await context.SubCategories.FirstOrDefaultAsync(c => c.Id.Equals(subCategoryId)) ??
            throw new NotFoundException($"Category with id {subCategoryId}");
    }
}
