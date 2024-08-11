using ECommerce.Core.Entities.Application;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Models.InputModels
{
    public class SubCategoryToEditModel
    {
        [AllowNull]
        public string Name { get; set; }
        [AllowNull]
        public string Description { get; set; }

        public SubCategory ToModel()
        {
            return new SubCategory
            {
                Name = Name,
                Description = Description
            };
        }
    }
}
