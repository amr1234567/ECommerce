using ECommerce.Core.Entities.Application;
using ECommerce.Repositry.Models.InputModels;
using ECommerce.Repositry.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Abstraction
{
    public interface ICategoryServices
    {
        Task<bool> AddNewCategory(CategoryToAddModel model);
        Task<CategoryResponse> EditCategoryDetails(CategoryToEditModel model);
        Task<CategoryResponse> DeleteCategory(string categoryId);
        Task<List<CategoryResponse>> GetAllCategories();
        Task<CategoryResponse> GetCategoryById(string categoryId);
    }
}
