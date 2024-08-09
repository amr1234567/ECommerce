using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities.Users.Contained
{
    [Owned]
    public class Location
    {
        [Required]
        [BsonElement("street_name")]
        public string StreetName { get; set; }
        [Required]
        [BsonElement("city_name")]
        public string CityName { get; set; }
        [Required]
        [BsonElement("country_name")]
        public string CountryName { get; set; }
        [BsonElement("zip_code")]
        public string? ZipCode { get; set; }
    }
}
