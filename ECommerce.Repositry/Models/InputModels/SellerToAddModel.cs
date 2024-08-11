using ECommerce.Core.Entities.Application;
using ECommerce.Core.Helpers.Enums;
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
    public class SellerToAddModel
    {
        [Required]
        public string Name { get; set; }

        [AllowNull]
        public string Description { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [AllowNull]
        public string? GeneralLocation { get; set; }

        [AllowNull]
        [DataType(DataType.Url)]
        public string? LocationUrl { get; set; }

        [Required]
        public SellerTypes SellerType { get; set; }

        public Seller ToModel()
        {
            return new Seller()
            {
                Name = Name,
                Description = Description,
                CategoryId = CategoryId,
                GeneralLocation = GeneralLocation,
                LocationUrl = LocationUrl,
                SellerType = SellerType
            };
        }
    }
}
