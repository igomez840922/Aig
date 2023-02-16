using Aig.Farmacoterapia.Application.Features.Medicament.Commands;
using Aig.Farmacoterapia.Application.Features.Medicament.Queries;
using Aig.Farmacoterapia.Application.Medicament.Model;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/medicament")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    [SwaggerOrder(6)]
    public class MedicamentController : Controller
    {
        private readonly IMediator _mediator;
        public MedicamentController(IMediator mediator) => _mediator = mediator;

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard() => Ok(await _mediator.Send(new GetDashboardMedicamentQuery()));

        [HttpPost("adminsearch")]
        public async Task<IActionResult> AdminSearch([FromBody] PageSearchArgs Args) => Ok(await _mediator.Send(new AdminGetAllMedicamentQuery(Args)));
        
        [AllowAnonymous]
        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] PageSearchArgs Args) => Ok(await _mediator.Send(new GetAllMedicamentQuery(Args)));

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicament(long id) => Ok(await _mediator.Send(new GetMedicamentQuery(id)));

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] AigMedicamento model) => Ok(await _mediator.Send(new AddEditMedicamentCommand(model)));

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteMedicamentCommand model) => Ok(await _mediator.Send(model));

        [HttpPost("pharmaceutica")]
        public async Task<IActionResult> GetPharmaceutical(GetPharmaceuticalQuery model) => Ok(await _mediator.Send(model));
      
        [HttpPost("medicationroute")]
        public async Task<IActionResult> MedicationRoutel(GetMedicationRoutelQuery model) => Ok(await _mediator.Send(model));

        [HttpPost("marker")]
        public async Task<IActionResult> GetMarker(GetMarkerQuery model) => Ok(await _mediator.Send(model));

        [HttpGet("{type}/{file}")]
        [AllowAnonymous]
        public async Task<FileStreamResult> GetFile(string type, string file) => await _mediator.Send(new GetFileQuery(type, file));

        [HttpPost]
        [HttpPost("list")]
        public async Task<IActionResult> List([FromBody] MedicamentPageSearch model) => Ok(await _mediator.Send(new ListMedicamentQuery(model)));

    }
}
