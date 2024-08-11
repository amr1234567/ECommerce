using ECommerce.Core.Entities.Application;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ECommerce.Repository.Models.InputModels
{
    public class SellerToEditModel
    {
        [AllowNull]
        public string Name { get; set; }

        [AllowNull]
        public string Description { get; set; }

        [AllowNull]
        public string GeneralLocation { get; set; }

        [AllowNull]
        [DataType(DataType.Url)]
        public string LocationUrl { get; set; }

        public Seller ToModel()
        {
            return new Seller
            {
                Name = Name,
                Description = Description,
                GeneralLocation = GeneralLocation,
                LocationUrl = LocationUrl
            };
        }

    }
}
