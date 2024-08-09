using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities.Application
{
    public class Discount
    {
        [Required]
        //[Key]
        [BsonId]
        [BsonElement("id")]
        public string Id { get; set; }
        [Required]
        [BsonElement("code")]
        public string Code { get; set; }
        [Range(0, 100)]
        [Required]
        [BsonElement("percentage")]
        public double Percentage { get; set; }

        [BsonElement("is_used")]
        public bool IsUsed { get; set; }
    }
}
