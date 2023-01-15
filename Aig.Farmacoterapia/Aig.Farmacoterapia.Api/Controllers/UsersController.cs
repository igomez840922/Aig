using Aig.Farmacoterapia.Application.Features.Medicament.Queries;
using Aig.Farmacoterapia.Domain.Common;
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

        [HttpGet("phone/{phone}")]
        public async Task<IActionResult> ExistPhone(string phone) => Ok(await _mediator.Send(new GetPhoneQuery(phone)));
    }
}

