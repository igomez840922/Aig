using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Aig.Farmacoterapia.Domain.Extensions;
using Aig.Farmacoterapia.Domain.Entities.Enums;

namespace Aig.Farmacoterapia.Infrastructure.Services
{
    //public class IdentityService : ITokenService
    //{
    //    private readonly UserManager<ApplicationUser> _userManager;
    //    private readonly IOptions<AppConfiguration> _appConfig;
    //    public IdentityService(UserManager<ApplicationUser> userManager, IOptions<AppConfiguration> appConfig)
    //    {
    //        _userManager = userManager;
    //        _appConfig = appConfig;
    //    }


    //    private async Task<Claim> GetRoleClaim(ApplicationUser user)
    //    {
    //        var claim = new Claim(ClaimTypes.Role, string.Empty);
    //        var roles = await _userManager.GetRolesAsync(user);
    //        if (roles.Any())
    //            claim = new Claim("roles", string.Join(",", roles.ToArray()));
    //        return claim;
    //    }
    //    public async Task<Result<TokenResponse>> LoginAsync(TokenRequest model)
    //    {
    //        var user = await _userManager.FindByEmailAsync(model.Email);
    //        if (user == null)
    //            return await Result<TokenResponse>.FailAsync("User Not Found.");

    //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfig.Value.Secret));
    //        var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
    //        var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(_appConfig.Value.ExpiryInMinutes));
    //        var claims = new[]{
    //            await GetRoleClaim(user),
    //            new("identifier", user.Id),
    //            new Claim("username", user.UserName),
    //            new Claim("name", user.FullName),
    //            new Claim("email", user.Email),
    //            new Claim("avatar", user.ProfilePicture ?? string.Empty)
    //         };
    //        var token = new JwtSecurityToken(audience: _appConfig.Value.Audience,
    //                                         issuer: _appConfig.Value.Issuer,
    //                                         claims: claims,
    //                                         expires: expiration,
    //                                         signingCredentials: credenciais);
    //        var response = new TokenResponse { Token = new JwtSecurityTokenHandler().WriteToken(token), TokenExpiryTime = expiration };
    //        return await Result<TokenResponse>.SuccessAsync(response);
    //    }

    //}


    public class IdentityService : ITokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IOptions<AppConfiguration> _appConfig;
        private readonly ApplicationDbContext _dbContext;
        public IdentityService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext dbContext,
            IOptions<AppConfiguration> appConfig)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _appConfig = appConfig;
            _appConfig = appConfig;
            _dbContext = dbContext;
        }

        public async Task<Result<TokenResponse>> LoginAsync(TokenRequest model)
        {
            //var user = await _userManager.FindByEmailAsync(model.Email);
            var dbset = _dbContext.Set<ApplicationUser>();
            var user = dbset.Where(p => p.Email == model.Email).FirstOrDefault();

            if (user == null)
            {
                return await Result<TokenResponse>.FailAsync("Usuario no encontrado.");
            }
            if (!user.IsActive)
            {
                return await Result<TokenResponse>.FailAsync("Usuario no activo. Póngase en contacto con el administrador.");
            }
            if (!user.EmailConfirmed)
            {
                return await Result<TokenResponse>.FailAsync("Correo electrónico no confirmado.");
            }
            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                return await Result<TokenResponse>.FailAsync("Credenciales no válidas.");
            }

            user.RefreshToken = GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
           
            //await _userManager.UpdateAsync(user);
            Update(user);

            var token = await GenerateJwtAsync(user);
            var response = new TokenResponse { Token = token, RefreshToken = user.RefreshToken, TokenExpiryTime = user.RefreshTokenExpiryTime, Avatar = user.ProfilePicture! };

            return await Result<TokenResponse>.SuccessAsync(response);
        }

        public void Update(ApplicationUser item) 
        {
            _dbContext.Entry(item).CurrentValues.SetValues(item);
            _dbContext.SaveChanges();
        }
        public async Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model)
        {
            if (model is null)
            {
                return await Result<TokenResponse>.FailAsync("Invalid Client Token.");
            }
            var userPrincipal = GetPrincipalFromExpiredToken(model.Token);
            var userEmail = userPrincipal.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
                return await Result<TokenResponse>.FailAsync("User Not Found.");
            if (user.RefreshToken != model.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return await Result<TokenResponse>.FailAsync("Invalid Client Token.");
            var token = GenerateEncryptedToken(GetSigningCredentials(), await GetClaimsAsync(user));
            user.RefreshToken = GenerateRefreshToken();
            await _userManager.UpdateAsync(user);

            var response = new TokenResponse { Token = token, RefreshToken = user.RefreshToken, TokenExpiryTime = user.RefreshTokenExpiryTime };
            return await Result<TokenResponse>.SuccessAsync(response);
        }

        private async Task<string> GenerateJwtAsync(ApplicationUser user)
        {
            var token = GenerateEncryptedToken(GetSigningCredentials(), await GetClaimsAsync(user));
            return token;
        }

        private async Task<IEnumerable<Claim>> GetClaimsAsync(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            var permissionClaims = new List<Claim>();
            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role.ParseEnum<RoleType>().ToString()));
                var thisRole = await _roleManager.FindByNameAsync(role);
                var allPermissionsForThisRoles = await _roleManager.GetClaimsAsync(thisRole);
                permissionClaims.AddRange(allPermissionsForThisRoles);
            }
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id),
                new("username", user.UserName),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Name, user.FirstName),
                new(ClaimTypes.Surname, user.LastName),
                new(ClaimTypes.MobilePhone, user.PhoneNumber ?? string.Empty),
                new(ClaimTypes.UserData, user.ProfilePicture ?? string.Empty)
            }
            .Union(userClaims)
            .Union(roleClaims)
            .Union(permissionClaims);

            return claims;
        }
      
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private string GenerateEncryptedToken(SigningCredentials signingCredentials, IEnumerable<Claim> claims)
        {
            var token = new JwtSecurityToken(
               claims: claims,
               expires: DateTime.UtcNow.AddDays(7),
               signingCredentials: signingCredentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var encryptedToken = tokenHandler.WriteToken(token);
            return encryptedToken;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appConfig.Value.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RoleClaimType = ClaimTypes.Role,
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var secret = Encoding.UTF8.GetBytes(_appConfig.Value.Secret);
            return new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256);
        }
    }
}
