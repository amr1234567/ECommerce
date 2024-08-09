using ECommerce.Repositry.Models.OutputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Abstraction
{
    public interface ITokenServices
    {
        Task<TokenModel> GenerateNewTokenModel(string userId, IEnumerable<Claim> claims = null);
        Task<TokenModel> RefreshTheToken(string refreshToken, string token);
        Task<bool> RevokeToken(string refreshToken);
        Task<bool> RevokeTokenWithUserId(string userId);
        Task<bool> RevokeAllTokens();
    }
}
