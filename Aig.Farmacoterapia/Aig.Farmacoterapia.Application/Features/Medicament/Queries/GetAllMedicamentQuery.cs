using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Interfaces;
using AutoMapper;

namespace Aig.Farmacoterapia.Application.Features.Medicament.Queries
{
    public class GetAllMedicamentQuery : IRequest<PaginatedResult<AigMedicamento>>
    {
        public PageSearchArgs Args { get; set; }
        public GetAllMedicamentQuery(PageSearchArgs args) => Args = args;
       
    }

    internal class GetAllMedicamentHandler : IRequestHandler<GetAllMedicamentQuery, PaginatedResult<AigMedicamento>>
    {
        private readonly IMedicamentRepository _repository;
        private readonly ISystemLogger _logger;

        public GetAllMedicamentHandler(IMedicamentRepository repository, ISystemLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<PaginatedResult<AigMedicamento>> Handle(GetAllMedicamentQuery request, CancellationToken cancellationToken)
        {
            PaginatedResult<AigMedicamento> answer = new();
            try
            {
                answer = await _repository.ListAsync(request.Args);
            }
            catch (Exception exc) 
            {
                 _logger.Error("Requested operation failed", exc);
                 return PaginatedResult<AigMedicamento>.Failure(new List<string>() { exc.Message });
            }
            return answer;
        }
    }
}