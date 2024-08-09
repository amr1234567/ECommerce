using ECommerce.Core.Repositories.Manager;
using ECommerce.Repositry.Abstraction;
using ECommerce.Repositry.Models.InputModels;
using ECommerce.Repositry.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Services
{
    internal class DiscountServices(IManagerRepository managerRepository) : IDiscountServices
    {
        public Task<DiscountResponse> DeleteDiscountFromDb(string discountId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GenerateNewDiscount(DiscountToAddModel model)
        {
            throw new NotImplementedException();
        }

        public Task<DiscountResponse> GetDiscountById(string discountId)
        {
            throw new NotImplementedException();
        }

        public Task<DiscountResponse> MarkDiscountAsUsed(string discountId)
        {
            throw new NotImplementedException();
        }
    }
}
