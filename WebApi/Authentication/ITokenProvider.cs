using Entities;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Authentication
{
    public interface ITokenProvider
    {
        string createToken(Users user, DateTime expire);
        TokenValidationParameters GetTokenValidationParameters();
    }
}
