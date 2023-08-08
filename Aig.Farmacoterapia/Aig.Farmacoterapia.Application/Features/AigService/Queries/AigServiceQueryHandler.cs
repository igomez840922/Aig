using Aig.Farmacoterapia.Application.Features.Study.Queries;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Interfaces.Studies;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Models;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Aig.Farmacoterapia.Application.Features.Service.Queries
{
    public class GetAllAigServiceQuery : IRequest<PaginatedResult<AigService>>
    {
        public PageArgs Model { get; set; }
        public GetAllAigServiceQuery(PageArgs model) => Model = model;
    }
    public class GetAigServiceQuery : IRequest<Result<AigService>>
    {
        public long Id { get; set; }
        public GetAigServiceQuery(long id) => Id = id;
    }

    internal class AigServiceQueryHandler :
       IRequestHandler<GetAllAigServiceQuery, PaginatedResult<AigService>>,
       IRequestHandler<GetAigServiceQuery, Result<AigService>> {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISystemLogger _logger;

        public AigServiceQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ISystemLogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PaginatedResult<AigService>> Handle(GetAllAigServiceQuery request, CancellationToken cancellationToken)
        {
            PaginatedResult<AigService> answer;
            try
            {
               var sorting = new Tuple<SortingOption, Expression<Func<AigService, object>>>(new SortingOption() { Direction = SortingDirection.DESC }, c => c.Created);
               answer = await _unitOfWork.Repository<AigService>().GetPagedResponseAsync(request.Model, sorting);
                
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return PaginatedResult<AigService>.Failure(new List<string>() { exc.Message });
            }
            return answer;
        }

        public async Task<Result<AigService>> Handle(GetAigServiceQuery request, CancellationToken cancellationToken)
        {
            var answer = new Result<AigService>();
            try
            {
                var result = await _unitOfWork.Repository<AigService>().GetByIdAsync(request.Id);
                answer = result == null ? Result<AigService>.Fail() : Result<AigService>.Success(result);
            }
            catch (Exception exc)
            {
                _logger.Error("Requested operation failed", exc);
                return Result<AigService>.Fail(new List<string>() { exc.Message });
            }
            return answer;
        }
    }
}
