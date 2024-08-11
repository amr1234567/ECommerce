using ECommerce.Core.Entities.Application;
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
    public class SubCategoryResponse
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public List<SellersForSubCategory> Sellers { get; set; }
        public SubCategoryResponse(SubCategory subCategory, IManagerRepository managerRepository)
        {
            Id = subCategory.Id;
            Name = subCategory.Name;
            Description = subCategory.Description;
            CategoryId = subCategory.CategoryId;
            Sellers = subCategory.SellersIds.Select(s => new SellersForSubCategory
            {
                Id = s,
                Name = managerRepository.SellerRepository.GetSellerById(s).Result.Name,
            }).ToList();
        }
        public SubCategoryResponse()
        {

        }
    }

    public class SellersForSubCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
