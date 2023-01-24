using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Aig.Farmacoterapia.Application.Features.Medicament.Commands;

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

        [HttpDelete("{type}/{image}")]
        public async Task<IActionResult> DeleteFile(string type, string image) => Ok(await _mediator.Send(new DeleteMediaCommand(type, image)));
    }
}
