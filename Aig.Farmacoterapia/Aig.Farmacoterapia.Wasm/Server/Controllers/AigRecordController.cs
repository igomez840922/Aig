using Aig.Farmacoterapia.Application.Features.Medicament.Queries;
using Aig.Farmacoterapia.Application.Features.Service.Commands;
using Aig.Farmacoterapia.Application.Medicament.Model;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/record")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    [SwaggerOrder(6)]
    public class AigRecordController : Controller
    {
        private readonly IMediator _mediator;
        public AigRecordController(IMediator mediator) => _mediator = mediator;

        [HttpPost("adminsearch")]
        public async Task<IActionResult> AdminSearch([FromBody] PageSearchArgs Args) => Ok(await _mediator.Send(new AdminGetAllAigRecordQuery(Args)));
        
        [AllowAnonymous]
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] PageSearchArgs Args) => Ok(await _mediator.Send(new GetAllAigRecordQuery(Args)));

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecord(long id) => Ok(await _mediator.Send(new GetAigRecordQuery(id)));

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] AigRecord model) => Ok(await _mediator.Send(new AddEditAigRecordCommand(model)));
       
        [HttpGet("{type}/{file}")]
        [AllowAnonymous]
        public async Task<FileStreamResult> GetFile(string type, string file) => await _mediator.Send(new GetAigRecordFileQuery(type, file));

        [HttpPost("list")]
        public async Task<IActionResult> List([FromBody] MedicamentPageSearch model) => Ok(await _mediator.Send(new ListAigRecordQuery(model)));

    }
}
