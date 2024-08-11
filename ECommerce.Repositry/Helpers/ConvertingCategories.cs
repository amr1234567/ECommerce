using ECommerce.Core.Entities.Application;
using ECommerce.Repository.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Helpers
{
    public static class ConvertingCategories
    {
        public static CategoryResponse FromModelToDto(this Category response)
        {
            return new CategoryResponse
            {
                Id = response.Id,
                Name = response.Name,
                Description = response.Description,
            };
        }
    }
}
