using Aig.Farmacoterapia.Application.Features.Study.Commands;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Entities.Studies.Enums;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Mail;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Application.Features.Service.Commands
{
    public partial class EditAigServiceCommand : IRequest<IResult>
    {
        public AigService Model { get; set; }
        public EditAigServiceCommand(AigService model) => Model = model;
    }
    internal class AigServiceHandler :IRequestHandler<EditAigServiceCommand, IResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemLogger _logger;
        public AigServiceHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ISystemLogger logger) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
       
        public async Task<IResult> Handle(EditAigServiceCommand request, CancellationToken cancellationToken)
        {
            IResult answer;
            try
            {
                if(request.Model?.Id > 0) {
                   var entity = await _unitOfWork.Repository<AigService>().UpdateAsync(request.Model);
                   answer = entity != null && _unitOfWork.Commit() ?
                   Result<AigService>.Success(entity, "Elementpo guardado correctamente !") :
                   Result<AigService>.Fail(new List<string>() { "Error durante la operación" });
                }
                else
                  answer=Result<AigService>.Fail(new List<string>() { "Error durante la operación" });
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }
    }
}
