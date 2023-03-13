using Aig.Farmacoterapia.Application.Features.Medicament.Queries;
using Aig.Farmacoterapia.Application.Features.Study.Commands;
using Aig.Farmacoterapia.Application.Features.Study.Queries;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/studies")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    [SwaggerOrder(2)]
    public class StudyController : Controller
    {
        private readonly IMediator _mediator;
        public StudyController(IMediator mediator) => _mediator = mediator;
       
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] PageSearchArgs Args) => Ok(await _mediator.Send(new GetAllStudyQuery(Args)));

        [HttpGet("study/{id}")]
        public async Task<IActionResult> GetStudy(long id) => Ok(await _mediator.Send(new GetStudyQuery(id)));

        [HttpGet("notification")]
        public async Task<IActionResult> GetNotification() => Ok(await _mediator.Send(new GetStudyNotifyQuery()));

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] AigEstudio model) => Ok(await _mediator.Send(new AddEditStudyCommand(model)));

        [HttpPost("clone")]
        public async Task<IActionResult> Update([FromBody] CloneStudyCommand model) => Ok(await _mediator.Send(model));

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteStudyCommand model) => Ok(await _mediator.Send(model));

        [HttpGet("evaluators/{studyId}")]
        public async Task<IActionResult> GetEvaluatorQuery(long studyId) => Ok(await _mediator.Send(new GetEvaluatorQuery(studyId)));

        [HttpPost]
        [Route("evaluators")]
        public async Task<IActionResult> SetEvaluators([FromBody] SetEvaluatorCommand model) => Ok(await _mediator.Send(model));

        [HttpGet("{type}/{file}")]
        [AllowAnonymous]
        public async Task<FileStreamResult> GetFile(string type, string file) => await _mediator.Send(new GetFileQuery(type, file));

    }
}
