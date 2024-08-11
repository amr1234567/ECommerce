using ECommerce.Core.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Models.OutputModels
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string? CountryName { get; set; }
        public string? CityName { get; set; }
        public string? StreetName { get; set; }
        public string? ZipCode { get; set; }
        public string? ShopCartId { get; set; }

        public UserResponse(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Role = user.Role.ToString();
            CountryName = user.Location is null ? null : user.Location.CountryName;
            CityName = user.Location is null ? null : user.Location.CityName;
            StreetName = user.Location is null ? null : user.Location.StreetName;
            ZipCode = user.Location is null ? null : user.Location.ZipCode;
            ShopCartId = user.ShopCartId;
        }
    }
}
