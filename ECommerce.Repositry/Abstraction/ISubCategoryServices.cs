﻿using ECommerce.Core.Entities.Application;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Abstraction
{
    public interface ISubCategoryServices
    {
        Task<bool> AddSubCategory(SubCategoryToAddModel model);
        Task<SubCategoryResponse> EditSubCategory(SubCategoryToEditModel model);
        Task<SubCategoryResponse> DeleteSubCategory(string SubCategoryId);
        Task<SubCategoryResponse> ChangeCategoryOfSubCategory(string subCategoryId, string newCategoryId);
        Task<IQueryable<SubCategoryResponse>> GetAllSubCategories();
        Task<List<SubCategoryResponse>> GetAllSubCategoriesForSeller(string sellerId);
    }
}
