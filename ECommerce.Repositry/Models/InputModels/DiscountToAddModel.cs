using ECommerce.Core.Entities.Application;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Models.InputModels
{
    public class DiscountToAddModel
    {
        [Range(0, 100)]
        [Required]
        public double Percentage { get; set; }

        public Discount ToModel()
        {
            return new Discount { Percentage = Percentage };
        }


    }
}
