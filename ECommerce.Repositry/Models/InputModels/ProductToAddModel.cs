using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Application.Contained;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Models.InputModels
{
    public class ProductToAddModel
    {
        [Required]
        public string Name { get; set; }

        [AllowNull]
        public string Description { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public string SellerId { get; set; }

        [AllowNull]
        public string SubCategoryId { get; set; }


        [Required]
        public double RealPrice { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int Quantity { get; set; }

        public Product ToModel()
        {
            return new Product
            {
                CategoryId = CategoryId,
                Name = Name,
                Description = Description,
                RealPrice = RealPrice,
                Quantity = Quantity,
                SellerId = SellerId,
                SubCategoryId = SubCategoryId,
            };
        }
    }
}
