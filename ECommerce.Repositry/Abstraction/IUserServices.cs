using ECommerce.Core.Helpers.Enums;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Abstraction
{
    public interface IUserServices
    {
        Task<UserResponse> GetConsumerById(string consumerId);
        Task<UserResponse> GetAdminById(string adminId);
        Task<UserResponse> GetDeliveryById(string deliveryId);

        Task<TokenModel> Login(LoginInputModel model);
        Task<bool> SignUp(SignUpInputModel model, UserRoles role);

        Task<TokenModel> RefreshTheToken(string refreshToken, string token);
        Task<bool> Logout(string userId);

        Task<UserResponse> EditPersonalData(UserDetailsToEditModel model);
    }
}
