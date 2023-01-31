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

namespace Aig.Farmacoterapia.Application.Features.StudyDNFD.Queries
{
    public class GetAllStudyDNFDQuery : IRequest<PaginatedResult<AigEstudioDNFD>>
    {
        public PageSearchArgs Args { get; set; }
        public GetAllStudyDNFDQuery(PageSearchArgs args) => Args = args; 
    }
    public class GetStudyDNFDQuery : IRequest<Result<AigEstudioDNFD>>
    {
        public long Id { get; set; }
        public GetStudyDNFDQuery(long id) => Id = id;
    }
    internal class StudyDNFDQueryHandler : 
        IRequestHandler<GetAllStudyDNFDQuery, PaginatedResult<AigEstudioDNFD>>,
        IRequestHandler<GetStudyDNFDQuery, Result<AigEstudioDNFD>>
    {
        private readonly IAigEstudioDNFDRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISystemLogger _logger;

        public StudyDNFDQueryHandler(IAigEstudioDNFDRepository repository, IUnitOfWork unitOfWork, ISystemLogger logger)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<PaginatedResult<AigEstudioDNFD>> Handle(GetAllStudyDNFDQuery request, CancellationToken cancellationToken)
        {
            PaginatedResult<AigEstudioDNFD> answer;
            try
            {
                answer = await _repository.ListAsync(request.Args);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return PaginatedResult<AigEstudioDNFD>.Failure(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<Result<AigEstudioDNFD>> Handle(GetStudyDNFDQuery request, CancellationToken cancellationToken)
        {
            var answer = new Result<AigEstudioDNFD>();
            try
            {
                var result = await _unitOfWork.Repository<AigEstudioDNFD>().GetByIdAsync(request.Id);
                answer = result == null ? Result<AigEstudioDNFD>.Fail() : Result<AigEstudioDNFD>.Success(result);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<AigEstudioDNFD>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

    }
}