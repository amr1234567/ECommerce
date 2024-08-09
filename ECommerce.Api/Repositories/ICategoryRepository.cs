using ECommerce.Core.Entities.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<bool> AddNewCategory(Category model);
        Task<Category> EditCategoryDetails(Category model);
        Task<IQueryable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(string categoryId);
    }
}
