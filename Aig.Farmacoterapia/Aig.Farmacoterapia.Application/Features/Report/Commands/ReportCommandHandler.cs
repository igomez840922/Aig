using AutoMapper;
using MediatR;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Models;
using Aig.Farmacoterapia.Domain.Interfaces.Integration;

namespace Aig.Farmacoterapia.Application.Features.Study.Commands
{
    public partial class SendNoteCommand : IRequest<IResult>
    {
        public string Code { get; set; }
        public UploadFileDTO File { get; set; }
        public SendNoteCommand(string code, UploadFileDTO file) {
            Code = code;
            File = file;
        }

    }
   
    internal class ReportCommandHandler : IRequestHandler<SendNoteCommand, IResult>
    {
        private readonly ITramitesServices _service;
        private readonly ISystemLogger _logger;
        
        public ReportCommandHandler(ITramitesServices service, IMapper mapper, ISystemLogger logger)
        {
            _service = service;
            _logger = logger;
        }
      
        public async Task<IResult> Handle(SendNoteCommand request, CancellationToken cancellationToken)
        {
            IResult answer;
            try
            {
                //answer =await _service.SendNote(request.Code,request.File, cancellationToken);

                var prod = "https://faddi-minsa.panamadigital.gob.pa";
                var qa = "https://uat2-minsa.panamadigital.gob.pa/faddi";
                answer = await _service.SendNote(prod, request.Code, request.File, cancellationToken);
                answer = await _service.SendNote(qa, request.Code, request.File, cancellationToken);
            }
            catch (Exception exc)
            {
                _logger.Error("Error en la operación solicitada", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

    }
}