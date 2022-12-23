using Aig.Farmacoterapia.Application.Features.Account.Commands;
using Aig.Farmacoterapia.Domain.Identity;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Application.Features.Account.Queries;
using Aig.Farmacoterapia.Infrastructure.Interfaces;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUploadService _uploadService;
        private readonly IUserService _userService;

        //public AccountsController(IMediator mediator) => _mediator = mediator;
        public AccountsController(IMediator mediator, IUploadService uploadService, IUserService userService) {
            _mediator = mediator;
            _uploadService = uploadService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(TokenRequest model) => Ok(await _mediator.Send(new LoginCommand(model)));

        [HttpPost("token/refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenRequest model) => Ok(await _mediator.Send(new RefreshTokenCommand(model)));

        [HttpGet("avatar/{image}")]
        public async Task<FileStreamResult> GetAvatar(string image) => await _mediator.Send(new GetAvatarQuery(image));

        [HttpPost("updateprofile")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileRequest model) => Ok(await _mediator.Send(new UpdateProfileCommand(model)));

        [HttpPut("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest model)
        {
            var response = await _userService.ChangePasswordAsync(model);
            return Ok(response);
        }
        
    }
}
