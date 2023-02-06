using Aig.Farmacoterapia.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Application.Features.Report.Queries
{
    public partial class GetNoteFileQuery : IRequest<FileStreamResult>
    {
        public long StudyId { get; set; }
        public GetNoteFileQuery(long studyId) => StudyId = studyId;

    }
    internal class ReportQueryHandler : IRequestHandler<GetNoteFileQuery, FileStreamResult>
    {
        private readonly IReportService _reportService;
        private readonly ISystemLogger _logger;

        public ReportQueryHandler(IReportService reportService, ISystemLogger logger)
        {
            _reportService = reportService;
            _logger = logger;
        }

        public async Task<FileStreamResult> Handle(GetNoteFileQuery request, CancellationToken cancellationToken)
        {
            FileStreamResult result = new(new MemoryStream(Array.Empty<byte>()), "application/pdf");
            try
            {
                var data = await _reportService.GetNotePdfAsync(request.StudyId);
                result = new(new MemoryStream(data), "application/pdf");
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
            }
            return result;
        }

    }
}
