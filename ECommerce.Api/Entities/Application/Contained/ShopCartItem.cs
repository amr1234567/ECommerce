using Microsoft.EntityFrameworkCore;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities.Application.Contained
{
    [Owned]
    public class ShopCartItem
    {
        [BsonElement("product_id")]
        public string ProductID { get; set; }
        [BsonElement("product_price")]
        public double ProductPrice { get; set; }
        [BsonElement("total_item_price")]
        public double TotalItemPrice { get; set; }
        [BsonElement("product_quantity")]
        public int ProductQuantity { get; set; }

    }
}
