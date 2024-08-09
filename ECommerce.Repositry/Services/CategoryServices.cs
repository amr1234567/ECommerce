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
    internal class CategoryServices(IManagerRepository managerRepository) : ICategoryServices
    {
        public Task<bool> AddNewCategory(CategoryToAddModel model)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponse> DeleteCategory(string categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponse> EditCategoryDetails(CategoryToEditModel model)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryResponse>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryResponse> GetCategoryById(string categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
