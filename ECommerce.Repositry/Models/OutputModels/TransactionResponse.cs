using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Application.Contained;
using ECommerce.Repository.Abstraction;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Models.OutputModels
{
    public class TransactionResponse
    {
        public string Id { get; set; }

        public DateTime ExpectedReceiveDate { get; set; }

        public DateTime ReceiveDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public string DiscountId { get; set; }

        public double TotalPrice { get; set; }

        public double PriceAfterDiscount { get; set; }

        public List<ShopCartItem> Items { get; set; }

        public string DelivaryId { get; set; }
        public string DelivaryName { get; set; }

        public string Status { get; set; }

        public string StreetName { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string? ZipCode { get; set; }

        public string ConsumerId { get; set; }
        public string ConsumerName { get; set; }

        public TransactionResponse(Transaction transaction, IUserServices userServices)
        {
            DelivaryId = transaction.DelivaryId;
            ConsumerId = transaction.ConsumerId;
            Status = transaction.Status.ToString();
            StreetName = transaction.Location.StreetName;
            CityName = transaction.Location.CityName;
            CountryName = transaction.Location.CountryName;
            ZipCode = transaction.Location.ZipCode;
            PriceAfterDiscount = transaction.PriceAfterDiscount;
            DiscountId = transaction.DiscountId;
            ConsumerName = userServices.GetConsumerById(ConsumerId).Result.Name;
            DelivaryName = string.IsNullOrEmpty(DelivaryId) ?
                string.Empty :
                userServices.GetDeliveryById(DelivaryId).Result.Name;
            Id = transaction.Id;
            ExpectedReceiveDate = transaction.ExpectedReceiveDate;
            TotalPrice = transaction.TotalPrice;
            Items = transaction.Items;
        }
        public TransactionResponse()
        {

        }
    }
}
