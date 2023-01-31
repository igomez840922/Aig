using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Interfaces.Studies;

namespace Aig.Farmacoterapia.Application.Features.Study.Queries
{
    public class GetAllStudyQuery : IRequest<PaginatedResult<AigEstudio>>
    {
        public PageSearchArgs Args { get; set; }
        public GetAllStudyQuery(PageSearchArgs args) => Args = args; 
    }
    public class GetStudyQuery : IRequest<Result<AigEstudio>>
    {
        public long Id { get; set; }
        public GetStudyQuery(long id) => Id = id;
    }
    internal class StudyQueryHandler : 
        IRequestHandler<GetAllStudyQuery, PaginatedResult<AigEstudio>>,
        IRequestHandler<GetStudyQuery, Result<AigEstudio>>
    {
        private readonly IAigEstudioRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemLogger _logger;

        public StudyQueryHandler(IAigEstudioRepository repository, IUnitOfWork unitOfWork, ISystemLogger logger)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PaginatedResult<AigEstudio>> Handle(GetAllStudyQuery request, CancellationToken cancellationToken)
        {
            PaginatedResult<AigEstudio> answer;
            try
            {
                answer = await _repository.ListAsync(request.Args);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return PaginatedResult<AigEstudio>.Failure(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<Result<AigEstudio>> Handle(GetStudyQuery request, CancellationToken cancellationToken)
        {
            var answer = new Result<AigEstudio>();
            try
            {
                var result = await _unitOfWork.Repository<AigEstudio>().GetByIdAsync(request.Id);
                answer = result == null ? Result<AigEstudio>.Fail() : Result<AigEstudio>.Success(result);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<AigEstudio>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

    }
}