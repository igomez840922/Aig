using Aig.Farmacoterapia.Application.Features.StudyDNFD.Commands;
using Aig.Farmacoterapia.Application.Features.StudyDNFD.Queries;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/studiesdnfd")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    public class StudyDNFDController : Controller
    {
        private readonly IMediator _mediator;
        public StudyDNFDController(IMediator mediator) => _mediator = mediator;

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] PageSearchArgs Args) => Ok(await _mediator.Send(new GetAllStudyDNFDQuery(Args)));

        [HttpGet("study/{id}")]
        public async Task<IActionResult> GetStudy(long id) => Ok(await _mediator.Send(new GetStudyDNFDQuery(id)));

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] AigEstudioDNFD model) => Ok(await _mediator.Send(new AddEditStudyDNFDCommand(model)));

        [HttpPost("evaluate")]
        public async Task<IActionResult> Evaluate([FromBody] EvaluateRequestCommand model) => Ok(await _mediator.Send(model));

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteStudyDNFDCommand model) => Ok(await _mediator.Send(model));
    }
}
