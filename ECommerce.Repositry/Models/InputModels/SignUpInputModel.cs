using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Models.InputModels
{
    public class SignUpInputModel
    {
        public string Name { get; set; }

        public string? CityName { get; set; }

        public string? StreetName { get; set; }

        public string? CountryName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

    }
}
