using Aig.Farmacoterapia.Application.Features.Medicament.Commands;
using Aig.Farmacoterapia.Application.Features.Medicament.Queries;
using Aig.Farmacoterapia.Application.Features.Report.Queries;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aig.Farmacoterapia.Api.Controllers
{
    [ApiController]
    [Route("api/report")]
    [Authorize(AuthenticationSchemes = "JwtClient")]
    public class ReportController : Controller
    {
        private readonly IMediator _mediator;
        public ReportController(IMediator mediator) => _mediator = mediator;

        [HttpGet("{studyId}")]
        [AllowAnonymous]
        public async Task<FileStreamResult> GetFile(long studyId) => await _mediator.Send(new GetNoteFileQuery(studyId));
    }
}
