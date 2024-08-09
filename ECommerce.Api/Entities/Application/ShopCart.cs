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
    public class ShopCart
    {
        //[Key]
        [BsonId]
        [BsonElement("id")]
        public string Id { get; set; }

        [BsonElement("items")]
        [AllowNull]
        public List<ShopCartItem> Items { get; set; }

        [NotMapped]
        public double TotalPrice => Items is not null ? Items.Sum(p => p.ProductPrice) : 0;

        [Required]
        public string UserId { get; set; }
    }
}
