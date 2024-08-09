using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Application.Contained;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Models.OutputModels
{
    public class ShopCartResponse
    {
        
        public string Id { get; set; }

        public List<ShopCartItem> Items { get; set; }

        public double TotalPrice {  get; set; }

        public ShopCartResponse(ShopCart shopCart)
        {
            Id = shopCart.Id;
            Items = shopCart.Items;
            TotalPrice = shopCart.TotalPrice;
        }
    }
}
