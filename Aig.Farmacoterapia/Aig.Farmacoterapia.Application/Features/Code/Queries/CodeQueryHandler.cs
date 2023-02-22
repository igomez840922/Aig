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
using Aig.Farmacoterapia.Infrastructure.Extensions;
using Aig.Farmacoterapia.Domain.Specifications.Studies;

namespace Aig.Farmacoterapia.Application.Features.Code.Queries
{
    public class GetAllCodeQuery : IRequest<PaginatedResult<AigCodigoEstudio>>
    {
        public PageSearchArgs Args { get; set; }
        public GetAllCodeQuery(PageSearchArgs args) => Args = args;
    }
    public class GetCodeQuery : IRequest<Result<AigCodigoEstudio>>
    {
        public long Id { get; set; }
        public GetCodeQuery(long id) => Id = id;
    }
    public class GetCodesQuery : IRequest<Result<List<AigCodigoEstudio>>>
    {
        public string Value { get; set; }
    }
    internal class CodeQueryHandler :
        IRequestHandler<GetAllCodeQuery, PaginatedResult<AigCodigoEstudio>>,
        IRequestHandler<GetCodeQuery, Result<AigCodigoEstudio>>,
        IRequestHandler<GetCodesQuery, Result<List<AigCodigoEstudio>>>
    {
        private readonly IAigCodigoEstudioRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISystemLogger _logger;

        public CodeQueryHandler(IAigCodigoEstudioRepository repository, IUnitOfWork unitOfWork,IMapper mapper, ISystemLogger logger)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PaginatedResult<AigCodigoEstudio>> Handle(GetAllCodeQuery request, CancellationToken cancellationToken)
        {
            PaginatedResult<AigCodigoEstudio> answer;
            try
            {
                answer = await _repository.ListAsync(request.Args);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return PaginatedResult<AigCodigoEstudio>.Failure(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<Result<AigCodigoEstudio>> Handle(GetCodeQuery request, CancellationToken cancellationToken)
        {
            var answer = new Result<AigCodigoEstudio>();
            try
            {
                var result = await _unitOfWork.Repository<AigCodigoEstudio>().GetByIdAsync(request.Id);
                answer = result == null ? Result<AigCodigoEstudio>.Fail() : Result<AigCodigoEstudio>.Success(result);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<AigCodigoEstudio>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<Result<List<AigCodigoEstudio>>> Handle(GetCodesQuery request, CancellationToken cancellationToken)
        {
            Result<List<AigCodigoEstudio>> answer = new();
            try
            {
                var result = new List<AigCodigoEstudio>();
                var query = _unitOfWork.Repository<AigCodigoEstudio>().GetAll();
                if (!string.IsNullOrEmpty(request.Value))
                    result = await query.WhereByAsync(p => p.Codigo, new CodeSpecification(request.Value));
                else
                    result = await query.WhereByAsync(p => p.Codigo);
                answer = Result<List<AigCodigoEstudio>>.Success(result);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<List<AigCodigoEstudio>>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }

    }
}