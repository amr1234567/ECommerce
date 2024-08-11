using System.ComponentModel.DataAnnotations;

namespace ECommerce.Presentation.Models
{
    public class ChangeCategoryForProductInputModel
    {
        [Required]
        public string productId { get; set; }
        [Required]
        public string newCategoryId { get; set; }
    }
}
