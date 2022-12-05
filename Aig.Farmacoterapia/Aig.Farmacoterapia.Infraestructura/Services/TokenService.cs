using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TokenResponse = Aig.Farmacoterapia.Infrastructure.Identity.TokenResponse;
using TokenRequest = Aig.Farmacoterapia.Infrastructure.Identity.TokenRequest;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Configuration;
using Microsoft.Extensions.Options;

namespace Aig.Farmacoterapia.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<AppConfiguration>  _appConfig;
        public TokenService(UserManager<ApplicationUser> userManager, IOptions<AppConfiguration> appConfig)
        {
            _userManager = userManager;
            _appConfig = appConfig;
        }
       
        public async Task<Result<TokenResponse>> LoginAsync(TokenRequest model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return await Result<TokenResponse>.FailAsync("User Not Found.");
            }

            string secret = _appConfig.Value.Secret;
            string audience = "AudienceClientJwt";
            string issuer = "IssuerClientJwt";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var expiration = DateTime.UtcNow.AddHours(7);
            var claims = new[]{
                                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
             };

            JwtSecurityToken token = new JwtSecurityToken(
                                                           audience: audience
                                                          , issuer: issuer
                                                          , claims: claims
                                                          , expires: expiration
                                                          , signingCredentials: credenciais);

            var response = new TokenResponse { Token = new JwtSecurityTokenHandler().WriteToken(token), TokenExpiryTime = expiration };
            return await Result<TokenResponse>.SuccessAsync(response);
        }

    }
}
