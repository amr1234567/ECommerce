using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using ECommerce.Core.Helpers.Enums;

namespace ECommerce.Core.Entities.Application
{
    public class Seller
    {
        [Required]
        //[Key]
        [BsonId]
        [BsonElement("id")]
        public string Id { get; set; }

        [BsonElement("name")]
        [Required]
        public string Name { get; set; }

        [BsonElement("description")]
        [AllowNull]
        public string Description { get; set; }


        [BsonElement("category_id")]
        [Required]
        public string CategoryId { get; set; }

        [BsonElement("general_location")]
        [AllowNull]
        public string GeneralLocation { get; set; }

        [AllowNull]
        [BsonElement("location_url")]
        [DataType(DataType.Url)]
        public string LocationUrl { get; set; }

        [BsonElement("seller_type")]
        [Required]
        public SellerTypes SellerType { get; set; }

        [BsonElement("sub_categories_ids")]
        [AllowNull]
        public List<string> SubCategoriesIds { get; set; }
    }
}
