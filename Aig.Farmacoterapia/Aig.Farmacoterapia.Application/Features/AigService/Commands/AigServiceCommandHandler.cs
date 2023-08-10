using AutoMapper;
using MediatR;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Entities.Products;

namespace Aig.Farmacoterapia.Application.Features.Service.Commands
{
    public partial class AddEditAigRecordCommand : IRequest<IResult>
    {
        public AigRecord Model { get; set; }
        public AddEditAigRecordCommand(AigRecord model) => Model = model;

    }
    internal class AigServiceCommandHandler :  IRequestHandler<AddEditAigRecordCommand, IResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadService _uploadService;
        private readonly ISystemLogger _logger;

        public AigServiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUploadService uploadService, ISystemLogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uploadService = uploadService;
            _logger = logger;
        }

        public async Task<IResult> Handle(AddEditAigRecordCommand request, CancellationToken cancellationToken)
        {
            IResult answer;
            try
            {
               
                if (request.Model.Id > 0)
                    await _unitOfWork.Repository<AigRecord>().UpdateAsync(request.Model);
                else
                    await _unitOfWork.Repository<AigRecord>().AddAsync(request.Model);
                answer = Result<bool>.Success(_unitOfWork.Commit());
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