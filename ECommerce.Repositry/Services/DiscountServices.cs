using ECommerce.Core.Repositories.Manager;
using ECommerce.Repository.Abstraction;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Services
{
    internal class DiscountServices(IManagerRepository managerRepository) : IDiscountServices
    {
        public async Task<DiscountResponse> DeleteDiscountFromDb(string discountId)
        {
            var dicount = await managerRepository.DiscountRepository.DeleteDiscountFromDb(discountId);
            return new DiscountResponse(dicount);
        }

        public async Task<bool> GenerateNewDiscount(DiscountToAddModel model)
        {
            var res = await managerRepository.DiscountRepository.GenerateNewDiscount(model.ToModel());
            return res;
        }

        public async Task<DiscountResponse> GetDiscountById(string discountId)
        {
            var discount = await managerRepository.DiscountRepository.GetDiscountById(discountId);
            return new DiscountResponse(discount);
        }

        public async Task<DiscountResponse> MarkDiscountAsUsed(string discountId)
        {
            var discount = await managerRepository.DiscountRepository.MarkDiscountAsUsed(discountId);
            return new DiscountResponse(discount);
        }
    }
}
