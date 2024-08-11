using ECommerce.Repository.Models.InputModels;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Presentation.Models
{
    public class SignUpAsAdminDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public SignUpInputModel ToInputModel()
        {
            return new SignUpInputModel
            {
                Email = Email,
                Password = Password,
                ConfirmPassword = ConfirmPassword,
                Name = Name,
            };
        }
    }
}
