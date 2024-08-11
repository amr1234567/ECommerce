using ECommerce.Core.Entities.Application;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Abstraction
{
    public interface ICategoryServices
    {
        Task<bool> AddNewCategory(CategoryToAddModel model);
        Task<CategoryResponse> EditCategoryDetails(CategoryToEditModel model);
        Task<IQueryable<CategoryResponse>> GetAllCategories();
        Task<CategoryResponse> GetCategoryById(string categoryId);
    }
}
