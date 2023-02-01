using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aig.Farmacoterapia.Application.Features.Media.Commands;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/media")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    public class MediaController : Controller
    {
        private readonly IMediator _mediator;
        public MediaController(IMediator mediator) =>_mediator = mediator;

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormCollection formData) => Ok(await _mediator.Send(new UploadMediaCommand(formData)));

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteFile([FromBody] DeleteMediaCommand model) => Ok(await _mediator.Send(model));
    }
}
