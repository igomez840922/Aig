using Aig.Farmacoterapia.Application.Features.Account.Commands;
using Aig.Farmacoterapia.Domain.Identity;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Aig.Farmacoterapia.Infrastructure.Helpers;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/identity")]
    [SwaggerOrder(1)]
    public class IdentityController : Controller
    {
        private readonly IMediator _mediator;
        public IdentityController(IMediator mediator) => _mediator = mediator;

        [HttpPost("login")]
        public async Task<IActionResult> Login(TokenRequest model) => Ok(await _mediator.Send(new LoginCommand(model)));

        [HttpPost("token/refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenRequest model) => Ok(await _mediator.Send(new RefreshTokenCommand(model)));
    }
}
