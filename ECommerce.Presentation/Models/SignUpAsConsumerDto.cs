using ECommerce.Repositry.Models.InputModels;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Presentation.Models
{
    public class SignUpAsConsumerDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string CountryName { get; set; }

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
                CityName = CityName,
                StreetName = StreetName,
                CountryName = CountryName,
                Email = Email,
                Password = Password,
                ConfirmPassword = ConfirmPassword,
                Name = Name,
            };
        }
    }
}
