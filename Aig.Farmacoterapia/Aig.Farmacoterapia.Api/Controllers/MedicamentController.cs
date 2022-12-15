using Aig.Farmacoterapia.Application.Features.Medicament.Queries;
using Aig.Farmacoterapia.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/medicament")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    public class MedicamentController : Controller
    {
        private readonly IMediator _mediator;
        public MedicamentController(IMediator mediator) => _mediator = mediator;

        [HttpPost("search")]
        public async Task<IActionResult> GetAll([FromBody] PageSearchArgs Args) => Ok(await _mediator.Send(new GetAllMedicamentQuery(Args)));
    }
}
