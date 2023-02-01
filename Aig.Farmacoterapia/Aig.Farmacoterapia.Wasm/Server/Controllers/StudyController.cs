using Aig.Farmacoterapia.Application.Features.Study.Commands;
using Aig.Farmacoterapia.Application.Features.Study.Queries;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/studies")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    public class StudyController : Controller
    {
        private readonly IMediator _mediator;
        public StudyController(IMediator mediator) => _mediator = mediator;
       
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] PageSearchArgs Args) => Ok(await _mediator.Send(new GetAllStudyQuery(Args)));

        [HttpGet("study/{id}")]
        public async Task<IActionResult> GetStudy(long id) => Ok(await _mediator.Send(new GetStudyQuery(id)));

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] AigEstudio model) => Ok(await _mediator.Send(new AddEditStudyCommand(model)));

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteStudyCommand model) => Ok(await _mediator.Send(model));

        [HttpGet("evaluators/{studyId}")]
        public async Task<IActionResult> GetEvaluatorQuery(long studyId) => Ok(await _mediator.Send(new GetEvaluatorQuery(studyId)));

        [HttpPost]
        [Route("evaluators")]
        public async Task<IActionResult> SetEvaluators([FromBody] SetEvaluatorCommand model) => Ok(await _mediator.Send(model));
       
    }
}
