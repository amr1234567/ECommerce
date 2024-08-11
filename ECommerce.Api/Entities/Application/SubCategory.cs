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
    public class SubCategory
    {
        [Required]
        //[Key]
        [BsonElement("id")]
        [BsonId]
        public string Id { get; set; }
        [Required]
        [BsonElement("name")]
        public string Name { get; set; }
        [AllowNull]
        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("category_id")]
        [Required]
        public string CategoryId { get; set; }

        [AllowNull]
        [BsonElement("sellers")]
        public List<string> SellersIds { get; set; }
    }
}
