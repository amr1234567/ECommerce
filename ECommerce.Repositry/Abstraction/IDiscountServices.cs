using ECommerce.Core.Entities.Application;
using ECommerce.Repositry.Models.InputModels;
using ECommerce.Repositry.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Abstraction
{
    public interface IDiscountServices
    {
        Task<bool> GenerateNewDiscount(DiscountToAddModel model);
        Task<DiscountResponse> GetDiscountById(string discountId);
        Task<DiscountResponse> DeleteDiscountFromDb(string discountId);
        Task<DiscountResponse> MarkDiscountAsUsed(string discountId);
    }
}
