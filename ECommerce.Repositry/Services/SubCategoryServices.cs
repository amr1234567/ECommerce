
using ECommerce.Core.Repositories.Manager;
using ECommerce.Repositry.Abstraction;
using ECommerce.Repositry.Models.InputModels;
using ECommerce.Repositry.Models.OutputModels;

namespace ECommerce.Repositry.Services
{
    internal class SubCategoryServices(IManagerRepository managerRepository) : ISubCategoryServices
    {
        public Task<bool> AddSubCategory(SubCategoryToAddModel model)
        {
            throw new NotImplementedException();
        }

        public Task<SubCategoryResponse> ChangeCategoryOfSubCategory(string subCategoryId, string newCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<SubCategoryResponse> DeleteSubCategory(string SubCategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<SubCategoryResponse> EditSubCategory(SubCategoryToEditModel model)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubCategoryResponse>> GetAllSubCategories()
        {
            throw new NotImplementedException();
        }

        public Task<List<SubCategoryResponse>> GetAllSubCategoriesForSeller(string sellerId)
        {
            throw new NotImplementedException();
        }
    }
}
