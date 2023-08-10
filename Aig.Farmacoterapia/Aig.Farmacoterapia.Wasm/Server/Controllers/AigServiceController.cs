using Aig.Farmacoterapia.Application.Features.Service.Commands;
using Aig.Farmacoterapia.Application.Features.Service.Queries;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/services")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    [SwaggerOrder(9)]

    public class AigServiceController : Controller
    {
        private readonly IMediator _mediator;
        public AigServiceController(IMediator mediator) => _mediator = mediator;

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] PageArgs model) => Ok(await _mediator.Send(new GetAllAigServiceQuery(model)));

        [HttpGet("service/{id}")]
        public async Task<IActionResult> GetService(long id) => Ok(await _mediator.Send(new GetAigServiceQuery(id)));
        
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] AigService model) => Ok(await _mediator.Send(new EditAigServiceCommand(model)));
    }
}
   
