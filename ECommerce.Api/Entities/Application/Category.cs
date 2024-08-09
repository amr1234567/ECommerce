using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities.Application
{
    public class Category
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

        [BsonElement("sellers")]
        [AllowNull]
        public List<string>? Sellers { get; set; }


    }
}
