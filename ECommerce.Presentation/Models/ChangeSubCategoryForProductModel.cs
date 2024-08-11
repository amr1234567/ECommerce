using System.ComponentModel.DataAnnotations;

namespace ECommerce.Presentation.Models
{
    public class ChangeSubCategoryForProductModel
    {
        [Required]
        public string productId { get; set; }
        [Required]
        public string newSubCategoryId { get; set; }
    }
}
