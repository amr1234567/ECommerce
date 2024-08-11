using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Application.Contained;
using ECommerce.Core.Helpers.Enums;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities.Users
{
    public class User : IdentityUser
    {
        [Required]
        [BsonElement("name")]
        public string Name { get; set; }

        public Location? Location { get; set; }

        [BsonElement("shop_cart_id")]
        public string? ShopCartId { get; set; }

        [Required]
        [BsonElement("role")]
        [BsonRepresentation(BsonType.String)]
        public UserRoles Role { get; set; }

        [AllowNull]
        public string? RefreshToken { get; set; }
    }
}
