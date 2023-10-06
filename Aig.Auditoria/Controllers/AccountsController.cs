using Aig.Auditoria.Services;
using DataModel;
using DataModel.DTO;
using DataModel.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aig.Auditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[AllowAnonymous]
	public class AccountsController : ControllerBase
	{
		private readonly IAuthService authService;
		private readonly IConfiguration _configuration;
		private readonly IConfigurationSection _jwtSettings;

		public AccountsController(IAuthService authService, IConfiguration configuration)
		{
			this.authService = authService;
			_configuration = configuration;
			_jwtSettings = _configuration.GetSection("JwtSettings");
		}


		//      [HttpPost("Registration")]
		//      [AllowAnonymous]
		//      public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO userForRegistration)
		//{
		//	if (userForRegistration == null || !ModelState.IsValid)
		//		return BadRequest();

		//	var user = new IdentityUser { UserName = userForRegistration.UserName, Email = userForRegistration.UserName };

		//	var result = await authService.Register(user, userForRegistration.Password);
		//	if (!result.Succeeded)
		//	{
		//		var errors = result.Errors.Select(e => e.Description);

		//		return BadRequest(new RegistrationResponseDto { Errors = errors });
		//	}

		//	return StatusCode(201);
		//}


		[HttpPost("Login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromBody] LoginModel appUser)
		{
			var response = await authService.Login(appUser);
			if (response?.Result??false)
			{
				var user = await authService.CurrentUserInfo(appUser.UserName);

                var signingCredentials = GetSigningCredentials();
				var claims = GetClaims(user);
				var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
				var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

				return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token, UserId = user.Id });
			}
			return Unauthorized(new AuthResponseDto { ErrorMessage = "nombre de usuario o contraseña no válidos" });
		}

        private SigningCredentials GetSigningCredentials()
		{
			var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
			var secret = new SymmetricSecurityKey(key);

			return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
		}

		private List<Claim> GetClaims(ApplicationUser user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

			return claims;
		}

		private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
		{
			var tokenOptions = new JwtSecurityToken(
				issuer: _jwtSettings.GetSection("validIssuer").Value,
				audience: _jwtSettings.GetSection("validAudience").Value,
				claims: claims,
				expires: DateTime.UtcNow.AddYears(5),//DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
                signingCredentials: signingCredentials);

			return tokenOptions;
		}
	}

}
