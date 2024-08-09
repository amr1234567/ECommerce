using ECommerce.Core.Entities.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface ISubCategoryRepository
    {
        Task<bool> AddSubCategory(SubCategory model);
        Task<SubCategory> EditSubCategory(SubCategory model);
        Task<SubCategory> DeleteSubCategory(string SubCategoryId);
        Task<SubCategory> ChangeCategoryOfSubCategory(string subCategoryId, string newCategoryId);
        Task<IQueryable<SubCategory>> GetAllSubCategories();
        Task<List<SubCategory>> GetAllSubCategoriesForSeller(string sellerId);
    }
}
