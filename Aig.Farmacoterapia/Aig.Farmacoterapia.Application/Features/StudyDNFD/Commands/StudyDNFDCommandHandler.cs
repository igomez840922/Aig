using AutoMapper;
using MediatR;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Studies;

namespace Aig.Farmacoterapia.Application.Features.StudyDNFD.Commands
{
    public partial class AddEditStudyDNFDCommand : IRequest<IResult>
    {
        public AigEstudioDNFD Model { get; set; }
        public AddEditStudyDNFDCommand(AigEstudioDNFD model) => Model = model;

    }
    public partial class DeleteStudyDNFDCommand : IRequest<IResult>
    {
        public long Id { get; set; }
    }
    internal class StudyDNFDCommandHandler : 
        IRequestHandler<AddEditStudyDNFDCommand, IResult>,
        IRequestHandler<DeleteStudyDNFDCommand, IResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadService _uploadService;
        private readonly ISystemLogger _logger;

        public StudyDNFDCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUploadService uploadService, ISystemLogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uploadService = uploadService;
            _logger = logger;
        }

        public async Task<IResult> Handle(AddEditStudyDNFDCommand request, CancellationToken cancellationToken)
        {
            IResult answer;
            try
            {
                if (request.Model.Id > 0)
                    await _unitOfWork.Repository<AigEstudioDNFD>().UpdateAsync(request.Model);
                else
                    await _unitOfWork.Repository<AigEstudioDNFD>().AddAsync(request.Model);
                answer = Result<bool>.Success(_unitOfWork.Commit());
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<IResult> Handle(DeleteStudyDNFDCommand request, CancellationToken cancellationToken)
        {
            IResult answer = new Result();
            try
            {
                var item=await _unitOfWork.Repository<AigEstudioDNFD>().GetByIdAsync(request.Id);
                if (item != null){
                    await _unitOfWork.Repository<AigEstudioDNFD>().DeleteAsync(item);
                    answer = Result<bool>.Success(_unitOfWork.Commit());
                }
                else answer = Result<bool>.Fail();
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