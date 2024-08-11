using ECommerce.Core.Entities.Application;
using ECommerce.Core.Helpers.Enums;
using ECommerce.Core.Repositories.Manager;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Models.OutputModels
{
    public class SellerResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string GeneralLocation { get; set; }
        public string LocationUrl { get; set; }
        public string SellerType { get; set; }
        public List<SubCategoryForSellerResponse> SubCategories { get; set; }
        public SellerResponse(Seller seller, IManagerRepository managerRepository)
        {
            Id = seller.Id;
            Name = seller.Name;
            Description = seller.Description;
            CategoryId = seller.CategoryId;
            GeneralLocation = seller.GeneralLocation;
            LocationUrl = seller.LocationUrl;
            SellerType = seller.SellerType.ToString();
            CategoryName = managerRepository.CategoryRepository.GetCategoryById(seller.CategoryId).Result.Name;
            SubCategories = seller.SubCategoriesIds.Select(c => new SubCategoryForSellerResponse
            {
                Id = c,
                Name = managerRepository.SubCategoryRepository.GetSubCategoryBuyId(c).Result.Name,
            }).ToList();
        }
        public SellerResponse()
        {


        }
    }
    public class SubCategoryForSellerResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
