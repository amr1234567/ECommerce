using ECommerce.Core.Entities.Application;
using ECommerce.Core.Repositories.Manager;
using ECommerce.Repository.Abstraction;
using ECommerce.Repository.Helpers;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Services
{
    internal class CategoryServices(IManagerRepository managerRepository) : ICategoryServices
    {
        public async Task<bool> AddNewCategory(CategoryToAddModel model)
        {
            var res = await managerRepository.CategoryRepository.AddNewCategory(model.ToModel());
            if (res)
                return true;
            return false;
        }

        public async Task<CategoryResponse> EditCategoryDetails(CategoryToEditModel model)
        {
            var category = await managerRepository.CategoryRepository.EditCategoryDetails(model.ToModel());
            return new CategoryResponse
            {
                Description = category.Description,
                Name = category.Name,
                Id = category.Id,
            };
        }

        public async Task<IQueryable<CategoryResponse>> GetAllCategories()
        {
            var categories = await managerRepository.CategoryRepository.GetAllCategories();
            return categories.Select(c => new CategoryResponse
            {
                Description = c.Description,
                Name = c.Name,
                Id = c.Id,
            }).OrderBy(c => c.Name);
        }

        public async Task<CategoryResponse> GetCategoryById(string categoryId)
        {
            var category = await managerRepository.CategoryRepository.GetCategoryById(categoryId);
            return new CategoryResponse
            {
                Description = category.Description,
                Name = category.Name,
                Id = category.Id,
            };
        }
    }
}
