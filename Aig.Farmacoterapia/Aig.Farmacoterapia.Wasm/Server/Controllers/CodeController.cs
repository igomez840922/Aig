using Aig.Farmacoterapia.Application.Features.Code.Queries;
using Aig.Farmacoterapia.Application.Features.Study.Commands;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/codes")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    [SwaggerOrder(8)]
    public class CodeController : Controller
    {
        private readonly IMediator _mediator;
        public CodeController(IMediator mediator) => _mediator = mediator;
       
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] PageSearchArgs Args) => Ok(await _mediator.Send(new GetAllCodeQuery(Args)));

        [HttpGet("code/{id}")]
        public async Task<IActionResult> GetStudy(long id) => Ok(await _mediator.Send(new GetCodeQuery(id)));

        [HttpPost("list")]
        public async Task<IActionResult> GetPharmaceutical(GetCodesQuery model) => Ok(await _mediator.Send(model));


        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] AigCodigoEstudio model) => Ok(await _mediator.Send(new AddEditCodeCommand(model)));

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCodeCommand model) => Ok(await _mediator.Send(model));

    }
}
