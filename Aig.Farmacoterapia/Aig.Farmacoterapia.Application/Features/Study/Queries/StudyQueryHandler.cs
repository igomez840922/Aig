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
using Aig.Farmacoterapia.Domain.Models;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using AutoMapper;
using Aig.Farmacoterapia.Domain.Entities.Enums;

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
    public class GetEvaluatorQuery : IRequest<Result<List<UserModelOutput>>>
    {
        public long StudyId { get; set; }
        public GetEvaluatorQuery(long studyId) => StudyId = studyId;
    }
    internal class StudyQueryHandler : 
        IRequestHandler<GetAllStudyQuery, PaginatedResult<AigEstudio>>,
        IRequestHandler<GetStudyQuery, Result<AigEstudio>>,
        IRequestHandler<GetEvaluatorQuery, Result<List<UserModelOutput>>>
    {
        private readonly IAigEstudioRepository _repository;
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISystemLogger _logger;

        public StudyQueryHandler(IAigEstudioRepository repository, IUnitOfWork unitOfWork, IUserService userService, IMapper mapper, ISystemLogger logger)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _mapper = mapper;
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
        public async Task<Result<List<UserModelOutput>>> Handle(GetEvaluatorQuery request, CancellationToken cancellationToken)
        {
            Result<List<UserModelOutput>> answer = new();
            try
            {
                var users = _mapper.Map<List<UserModelOutput>>((await _userService.GetAllEvaluatorAsync()).Data);
                var evaluators = _repository.ListEvaluatorAsync(request.StudyId);
                answer = Result<List<UserModelOutput>>.Success(users.Select(x => { 
                    x.EvaluatorStatus = evaluators.Any(p => p == x.Id) ? 
                    EvaluatorStatus.Assigned : 
                    EvaluatorStatus.UnAssigned; 
                    return x; }).ToList());
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<List<UserModelOutput>>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }
    }
}