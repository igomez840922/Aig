using Aig.Farmacoterapia.Application.Features.Account.Queries;
using Aig.Farmacoterapia.Application.Features.Medicament.Commands;
using Aig.Farmacoterapia.Application.Features.Medicament.Queries;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator) => _mediator = mediator;

        [HttpPost("search")]
        public async Task<IActionResult> GetAll([FromBody] PageSearchArgs Args) => Ok(await _mediator.Send(new GetAllUserQuery(Args)));
        
        [HttpGet("username/{userName}")]
        public async Task<IActionResult> ExistUsername(string userName) => Ok(await _mediator.Send(new GetUsernameQuery(userName)));

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetUser(string userName) => Ok(await _mediator.Send(new GetUserQuery(userName)));

        [HttpGet("phone/{phone}")]
        public async Task<IActionResult> ExistPhone(string phone) => Ok(await _mediator.Send(new GetPhoneQuery(phone)));

        [HttpPost("updateprofile")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileRequest model) => Ok(await _mediator.Send(new UpdateProfileCommand(model)));

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model) => Ok(await _mediator.Send(new RegisterUserCommand(model)));

        [HttpPost("updateroles")]
        public async Task<IActionResult> UpdateRoles([FromBody] UpdateUserRolesRequest model) => Ok(await _mediator.Send(new UpdateUserRolesCommand(model)));

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest model) => Ok(await _mediator.Send(new ChangePasswordCommand(model)));

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(string id) => Ok(await _mediator.Send(new DeleteUserCommand() { Id= id }));
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand model) => Ok(await _mediator.Send(model));

        [HttpGet("avatar/{image}")]
        [AllowAnonymous]
        public async Task<FileStreamResult> GetAvatar(string image) => await _mediator.Send(new GetAvatarQuery(image));
    }
}
