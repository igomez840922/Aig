using AutoMapper;
using MediatR;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Studies;

namespace Aig.Farmacoterapia.Application.Features.Study.Commands
{
    public partial class AddEditStudyCommand : IRequest<IResult>
    {
        public AigEstudio Model { get; set; }
        public AddEditStudyCommand(AigEstudio model) => Model = model;

    }
    public partial class DeleteStudyCommand : IRequest<IResult>
    {
        public long Id { get; set; }
    }
    internal class StudyCommandHandler : 
        IRequestHandler<AddEditStudyCommand, IResult>,
        IRequestHandler<DeleteStudyCommand, IResult>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemLogger _logger;

        public StudyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISystemLogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IResult> Handle(AddEditStudyCommand request, CancellationToken cancellationToken)
        {
            IResult answer;
            try
            {
                if (request.Model.Id > 0)
                    await _unitOfWork.Repository<AigEstudio>().UpdateAsync(request.Model);
                else
                    await _unitOfWork.Repository<AigEstudio>().AddAsync(request.Model);
                answer = Result<bool>.Success(_unitOfWork.Commit());
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<IResult> Handle(DeleteStudyCommand request, CancellationToken cancellationToken)
        {
            IResult answer = new Result();
            try
            {
                var item=await _unitOfWork.Repository<AigEstudio>().GetByIdAsync(request.Id);
                if (item != null){
                    await _unitOfWork.Repository<AigEstudio>().DeleteAsync(item);
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