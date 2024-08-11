using ECommerce.Core.Entities.Application;
using ECommerce.Core.Repositories.Manager;
using ECommerce.Repository.Abstraction;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;

namespace ECommerce.Repository.Services
{
    internal class SubCategoryServices(IManagerRepository managerRepository) : ISubCategoryServices
    {
        public async Task<bool> AddSubCategory(SubCategoryToAddModel model)
        {
            var res = await managerRepository.SubCategoryRepository.AddSubCategory(model.ToModel());
            return res;
        }

        public async Task<SubCategoryResponse> ChangeCategoryOfSubCategory(string subCategoryId, string newCategoryId)
        {
            var subCategory = await managerRepository.SubCategoryRepository.ChangeCategoryOfSubCategory(subCategoryId, newCategoryId);
            return new SubCategoryResponse
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                Description = subCategory.Description,
                CategoryId = subCategory.CategoryId,
                Sellers = subCategory.SellersIds.Select(s => new SellersForSubCategory
                {
                    Id = s,
                    Name = managerRepository.SellerRepository.GetSellerById(s).Result.Name,
                }).ToList(),
            };
        }

        public async Task<SubCategoryResponse> DeleteSubCategory(string SubCategoryId)
        {
            var subCategory = await managerRepository.SubCategoryRepository.DeleteSubCategory(SubCategoryId);
            return new SubCategoryResponse
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                Description = subCategory.Description,
                CategoryId = subCategory.CategoryId,
                Sellers = subCategory.SellersIds.Select(s => new SellersForSubCategory
                {
                    Id = s,
                    Name = managerRepository.SellerRepository.GetSellerById(s).Result.Name,
                }).ToList(),
            };
        }

        public async Task<SubCategoryResponse> EditSubCategory(SubCategoryToEditModel model)
        {
            var subCategory = await managerRepository.SubCategoryRepository.EditSubCategory(model.ToModel());
            return new SubCategoryResponse
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                Description = subCategory.Description,
                CategoryId = subCategory.CategoryId,
                Sellers = subCategory.SellersIds.Select(s => new SellersForSubCategory
                {
                    Id = s,
                    Name = managerRepository.SellerRepository.GetSellerById(s).Result.Name,
                }).ToList(),
            };
        }

        public async Task<IQueryable<SubCategoryResponse>> GetAllSubCategories()
        {
            var subCategories = await managerRepository.SubCategoryRepository.GetAllSubCategories();
            return subCategories.Select(subCategory => new SubCategoryResponse
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                Description = subCategory.Description,
                CategoryId = subCategory.CategoryId,
                Sellers = subCategory.SellersIds.Select(s => new SellersForSubCategory
                {
                    Id = s,
                    Name = managerRepository.SellerRepository.GetSellerById(s).Result.Name,
                }).ToList(),
            });
        }

        public async Task<List<SubCategoryResponse>> GetAllSubCategoriesForSeller(string sellerId)
        {
            var subCategories = await managerRepository.SubCategoryRepository.GetAllSubCategoriesForSeller(sellerId);
            return subCategories.Select(subCategory => new SubCategoryResponse
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                Description = subCategory.Description,
                CategoryId = subCategory.CategoryId,
                Sellers = subCategory.SellersIds.Select(s => new SellersForSubCategory
                {
                    Id = s,
                    Name = managerRepository.SellerRepository.GetSellerById(s).Result.Name,
                }).ToList(),
            }).ToList();
        }

    }
}
