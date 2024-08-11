using ECommerce.Core.Entities.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Models.InputModels
{
    public class CategoryToEditModel
    {
        [Required]
        public string CategoryId { get; set; }
        [AllowNull]
        public string CategoryName { get; set; }
        [AllowNull]
        public string Description { get; set; }
        public Category ToModel()
        {
            return new Category
            {
                Id = CategoryId,
                Description = Description,
                Name = CategoryName
            };
        }
    }
}
