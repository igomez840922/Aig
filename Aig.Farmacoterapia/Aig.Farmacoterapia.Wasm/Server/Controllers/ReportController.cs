using Aig.Farmacoterapia.Application.Features.Code.Queries;
using Aig.Farmacoterapia.Application.Features.Medicament.Commands;
using Aig.Farmacoterapia.Application.Features.Medicament.Queries;
using Aig.Farmacoterapia.Application.Features.Report.Queries;
using Aig.Farmacoterapia.Application.Features.Study.Commands;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Models;
using Aig.Farmacoterapia.Infrastructure.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/report")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    [SwaggerOrder(5)]
    public class ReportController : Controller
    {
        private readonly IMediator _mediator;
        public ReportController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{studyId}/{code}")]
        [AllowAnonymous]
        public async Task<FileStreamResult> GetFile(long studyId,string code) => await _mediator.Send(new GetNoteFileQuery(studyId));
      
        [HttpPost("note")]
        public async Task<IActionResult> Note(SendNoteCommand model) => Ok(await _mediator.Send(model));

    }
}
