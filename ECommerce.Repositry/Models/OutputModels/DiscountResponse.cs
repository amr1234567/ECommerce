using ECommerce.Core.Entities.Application;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Models.OutputModels
{
    public class DiscountResponse
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public double Percentage { get; set; }
        public bool IsUsed { get; set; }
        public DiscountResponse(Discount discount)
        {
            Id = discount.Id;
            Code = discount.Code;
            Percentage = discount.Percentage;
            IsUsed = discount.IsUsed;
        }
    }
}
