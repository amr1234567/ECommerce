using ECommerce.Core.Entities.Users;
using ECommerce.Core.Exceptions;
using ECommerce.Core.Helpers.Classes;
using ECommerce.Repository.Abstraction;
using ECommerce.Repository.Models.OutputModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ECommerce.Repository.Services
{
    public class TokenServices(UserManager<User> userManager, IOptions<JwtHelper> jwtOptions) : ITokenServices
    {
        private readonly JwtHelper _jwtHelper = jwtOptions.Value;

        public async Task<TokenModel> GenerateNewTokenModel(string userId, IEnumerable<Claim>? claims = null)
        {
            //if (await CheckUserHasRefreshToken(userId))
            //    throw new UserHasTokenException();
            var refreshToken = await GenerateNewRefreshToken();
            var token = await GenerateNewToken(claims);
            var user = await GetUserById(userId);
            user.RefreshToken = refreshToken;
            await userManager.UpdateAsync(user);
            return new TokenModel
            {
                Token = token,
                RefreshToken = refreshToken,
                ExpireDate = DateTime.Now.AddMinutes(_jwtHelper.ExpireTimeInMinutes),
            };
        }


        public async Task<bool> RevokeAllTokens()
        {
            foreach (var user in userManager.Users)
            {
                user.RefreshToken = null;
                await userManager.UpdateAsync(user);
            }
            return true;
        }

        public async Task<bool> RevokeToken(string refreshToken)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken)
                ?? throw new NotFoundException($"User with token {refreshToken}");
            user.RefreshToken = refreshToken;
            await userManager.UpdateAsync(user);
            return true;
        }

        public async Task<TokenModel> RefreshTheToken(string refreshToken, string token)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken)
                ?? throw new UserHasNoRefreshTokenException();
            var princ = GetPrincipalFromExpiredToken(token);
            var idClaim = princ.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.NameIdentifier));
            if (idClaim is null || idClaim.Value != user.Id)
                throw new TokenNotValidException();
            var newRefreshToken = await GenerateNewRefreshToken();
            user.RefreshToken = newRefreshToken;
            await userManager.UpdateAsync(user);
            return new TokenModel
            {
                ExpireDate = DateTime.Now.AddMinutes(_jwtHelper.ExpireTimeInMinutes),
                RefreshToken = newRefreshToken,
                Token = await GenerateNewToken(princ.Claims),
            };
        }

        public async Task<User> GetUserById(string id) =>
            await userManager.FindByIdAsync(id)
            ?? throw new NotFoundException($"User with id {id}");

        public async Task<bool> RevokeTokenWithUserId(string userId)
        {
            var user = await GetUserById(userId);
            user.RefreshToken = null;
            await userManager.UpdateAsync(user);
            return true;
        }
        private async Task<bool> CheckUserHasRefreshToken(string userId, string refreshToken)
        {
            var user = await GetUserById(userId);
            return user.RefreshToken == refreshToken;
        }
        private async Task<bool> CheckUserHasRefreshToken(string userId)
        {
            var user = await userManager.FindByIdAsync(userId)
                ?? throw new NotFoundException($"User with id {userId}");
            return !string.IsNullOrEmpty(user.RefreshToken);
        }

        private Task<string> GenerateNewRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Task.FromResult(Convert.ToBase64String(randomNumber));
        }

        private Task<string> GenerateNewToken(IEnumerable<Claim> claims = null)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtHelper.Key));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            var tokeOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtHelper.ExpireTimeInMinutes),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Task.FromResult(tokenString);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            if (!tokenHandler.CanReadToken(token))
            {
                throw new NotValidTokenSignatureException();
            }
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtHelper.Key)),
                ValidateLifetime = false
            };
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

    }
}
