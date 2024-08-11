using ECommerce.Core.Entities.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repositories
{
    public interface IDiscountRepository
    {
        Task<bool> GenerateNewDiscount(Discount model);
        Task<Discount> GetDiscountById(string discountId);
        Task<Discount> DeleteDiscountFromDb(string discountId);
        Task<Discount> MarkDiscountAsUsed(string discountId);
        Task<Discount> GetDiscountByCode(string code);
    }
}
