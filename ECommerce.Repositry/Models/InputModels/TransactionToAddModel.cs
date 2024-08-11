using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Application.Contained;
using ECommerce.Core.Repositories.Manager;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Models.InputModels
{
    public class TransactionToAddModel
    {
        [AllowNull]
        [BsonElement("discount_id")]
        public string DiscountCode { get; set; }

        [BsonElement("items")]
        [Required]
        public string ShopCartId { get; set; }

        [Required]
        [BsonElement("delivery_id")]
        public string DelivaryId { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]
        [BsonElement("consumer_id")]
        public string ConsumerId { get; set; }

        public async Task<Transaction> ToModel(IManagerRepository managerRepository)
        {
            Discount? discount = string.IsNullOrEmpty(DiscountCode) ?
                null :
                await managerRepository.DiscountRepository.GetDiscountByCode(DiscountCode);

            ShopCart shopCart = await managerRepository.ShopCartRepository.GetShopCartById(ShopCartId);

            return new Transaction()
            {
                DiscountId = string.IsNullOrEmpty(DiscountCode) ? null : discount!.Id,
                Items = shopCart.Items,
                ConsumerId = ConsumerId,
                Location = Location,
                TotalPrice = shopCart.TotalPrice,
                PriceAfterDiscount = string.IsNullOrEmpty(DiscountCode) ?
                shopCart.TotalPrice :
                shopCart.TotalPrice - discount!.Percentage / 100 * shopCart.TotalPrice,
                CreatedAt = DateTime.UtcNow,
            };
        }

    }
}
