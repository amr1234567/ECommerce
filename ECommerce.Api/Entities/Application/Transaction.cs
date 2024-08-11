using ECommerce.Core.Entities.Application.Contained;
using ECommerce.Core.Entities.Users;
using ECommerce.Core.Helpers.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ECommerce.Core.Entities.Application
{
    public class Transaction
    {
        //[Key]
        [BsonId]
        [BsonElement("id")]
        public string Id { get; set; }

        [AllowNull]
        public DateTime ExpectedReceiveDate { get; set; }

        [AllowNull]
        [BsonElement("receive_date")]
        public DateTime ReceiveDate { get; set; }

        [Required]
        [BsonElement("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [AllowNull]
        [BsonElement("discount_id")]
        public string DiscountId { get; set; }

        [Required]
        [BsonElement("total_price")]
        public double TotalPrice { get; set; }

        [BsonElement("price_after_discount")]
        public double PriceAfterDiscount { get; set; }

        [BsonElement("items")]
        [Required]
        public List<ShopCartItem> Items { get; set; }

        [AllowNull]
        [BsonElement("delivery_id")]
        public string DelivaryId { get; set; }

        [Required]
        [BsonElement("status")]
        public TransactionStatus Status { get; set; } = TransactionStatus.Created;

        [Required]
        public Location Location { get; set; }

        [Required]
        [BsonElement("consumer_id")]
        public string ConsumerId { get; set; }
    }
}
