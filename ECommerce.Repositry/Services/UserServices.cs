using ECommerce.Core.Entities.Application;
using ECommerce.Core.Entities.Application.Contained;
using ECommerce.Core.Entities.Users;
using ECommerce.Core.Exceptions;
using ECommerce.Core.Helpers.Enums;
using ECommerce.Core.Repositories.Manager;
using ECommerce.Repository.Abstraction;
using ECommerce.Repository.Models.InputModels;
using ECommerce.Repository.Models.OutputModels;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Services
{
    public class UserServices(UserManager<User> userManager,
        IManagerRepository managerRepository,
        ITokenServices tokenServices,
        RoleManager<IdentityRole> roleManager) : IUserServices
    {
        public Task<UserResponse> EditPersonalData(UserDetailsToEditModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<UserResponse> GetAdminById(string adminId)
        {
            var user = await userManager.FindByIdAsync(adminId)
                ?? throw new NotFoundException($"Admin with id {adminId}");
            if (!user.Role.Equals(UserRoles.Admin))
                throw new UserInIncorrectRoleException("admin");
            return new UserResponse(user);
        }

        public async Task<UserResponse> GetConsumerById(string consumerId)
        {
            var user = await userManager.FindByIdAsync(consumerId)
                ?? throw new NotFoundException($"Consumer with id {consumerId}");
            if (!user.Role.Equals(UserRoles.Consumer))
                throw new UserInIncorrectRoleException("consumer");
            return new UserResponse(user);
        }

        public async Task<UserResponse> GetDeliveryById(string deliveryId)
        {
            var user = await userManager.FindByIdAsync(deliveryId)
                 ?? throw new NotFoundException($"Delivery with id {deliveryId}");
            if (!user.Role.Equals(UserRoles.Delivery))
                throw new UserInIncorrectRoleException("delivery");
            return new UserResponse(user);
        }

        public async Task<TokenModel> Login(LoginInputModel model)
        {
            ArgumentNullException.ThrowIfNull(model);
            var user = await userManager.FindByEmailAsync(model.Email)
                ?? throw new NotFoundException($"User with email {model.Email}");
            var check = await userManager.CheckPasswordAsync(user, model.Password);
            if (!check)
            {
                throw new LoginFailedException();
            }
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, user.Role.ToString())
            };


            if (user.Role.Equals(UserRoles.Consumer))
                claims.AddRange([
                    new Claim(CustomClaimTypes.CountryName, user.Location.CountryName),
                    new Claim(CustomClaimTypes.CityName, user.Location.CityName),
                    new Claim(CustomClaimTypes.StreetName, user.Location.StreetName),
                    new Claim(CustomClaimTypes.ShopCartId,user.ShopCartId)
                    ]);

            else if (user.Role == UserRoles.Delivery)
                claims.AddRange([
                    new Claim(CustomClaimTypes.CountryName, user.Location.CountryName),
                    new Claim(CustomClaimTypes.CityName, user.Location.CityName)
                    ]);

            var tokenModel = await tokenServices.GenerateNewTokenModel(user.Id, claims);
            return tokenModel;
        }

        public async Task<bool> Logout(string userId)
        {
            return await tokenServices.RevokeTokenWithUserId(userId);
        }

        public async Task<TokenModel> RefreshTheToken(string refreshToken, string token)
        {
            return await tokenServices.RefreshTheToken(refreshToken, token);
        }

        public async Task<bool> SignUp(SignUpInputModel model, UserRoles role)
        {
            ArgumentNullException.ThrowIfNull(model);
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user != null)
                throw new EmailExistException(user.Email);
            var newUser = new User
            {
                Id = new ObjectId().ToString(),
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email,
                Role = role,
            };
            if (role == UserRoles.Consumer)
            {
                newUser.Location = role.Equals(UserRoles.Consumer) ? new Location
                {
                    CityName = model.CityName,
                    StreetName = model.StreetName,
                    CountryName = model.CountryName,
                } : null;
            }
            var res = await userManager.CreateAsync(newUser, model.Password);
            if (!res.Succeeded)
            {
                throw new CreationException(role.ToString());
            }
            var userFromDb = await userManager.FindByEmailAsync(model.Email)
                ?? throw new NotFoundException($"User with email {model.Email}");
            userFromDb.ShopCartId = await managerRepository.ShopCartRepository.AddShopCart(userFromDb.Id);
            await userManager.UpdateAsync(userFromDb);
            if (!await roleManager.RoleExistsAsync(role.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(role.ToString()));
            }
            var resForAssignRole = await userManager.AddToRoleAsync(userFromDb, role.ToString());
            if (!resForAssignRole.Succeeded)
            {
                throw new CreationException(role.ToString());
            }
            return res.Succeeded;
        }
    }
}
