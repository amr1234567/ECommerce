using ECommerce.Core.Entities.Application.Contained;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities.Application
{
    public class Product
    {
        [Required]
        [BsonId]
        //[Key]
        [BsonElement("id")]
        public string Id { get; set; }

        [BsonElement("name")]
        [Required]
        public string Name { get; set; }

        [BsonElement("description")]
        [AllowNull]
        public string Description { get; set; }

        [BsonElement("categor_id")]
        [Required]
        public string CategoryId { get; set; }

        [BsonElement("seller_id")]
        [Required]
        public string SellerId { get; set; }

        [BsonElement("sub_category_id")]
        [AllowNull]
        public string SubCategoryId { get; set; }

        [AllowNull]
        public PeriodDiscount Discount { get; set; }

        [BsonElement("real_price")]
        [Required]
        public double RealPrice { get; set; }

        [BsonElement("quantity")]
        [Range(0, int.MaxValue)]
        [Required]
        public int Quantity { get; set; }



        [NotMapped]
        public bool HasDiscount => Discount is not null;

        [NotMapped]
        public bool HasItems => Quantity != 0;

        [NotMapped]
        public double CurrentPrice => HasDiscount ?
            RealPrice - Discount.DiscountAmount / 100 * RealPrice :
            RealPrice;

    }
}
