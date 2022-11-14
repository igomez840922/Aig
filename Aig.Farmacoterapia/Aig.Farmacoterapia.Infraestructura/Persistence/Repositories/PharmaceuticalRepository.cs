using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Specifications.Medicament;
using Aig.Farmacoterapia.Infrastructure.Extensions;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Repositories
{
    public class PharmaceuticalRepository : IPharmaceuticalRepository
    {
        private readonly IRepositoryAsync<AigFormaFarmaceutica> _repository;
        private readonly ISystemLogger _logger;

        public PharmaceuticalRepository(IRepositoryAsync<AigFormaFarmaceutica> repository, ISystemLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<PaginatedResult<AigFormaFarmaceutica>> ListAsync(PageSearchArgs args)
        {
            if (args == null) throw new Exception();
            var result = new PaginatedResult<AigFormaFarmaceutica>(new List<AigFormaFarmaceutica>());
            try
            {
                var orderByList = new List<Tuple<SortingOption, Expression<Func<AigFormaFarmaceutica, object>>>>();
                var filterList = new List<Expression<Func<AigFormaFarmaceutica, bool>>>();

                if (args.SortingOptions != null)
                {
                    foreach (var sortingOption in args.SortingOptions)
                    {
                        switch (sortingOption.Field)
                        {
                            case "created":
                                orderByList.Add(new(sortingOption, c => c.Created));
                             break;
                            case "modified":
#pragma warning disable CS8603 // Possible null reference return.
                                orderByList.Add(new(sortingOption, c => c.LastModified));
#pragma warning restore CS8603 // Possible null reference return.
                                break;
                            case "name":
                                orderByList.Add(new(sortingOption, c => c.Nombre));
                                break;
                            case "status":
                                orderByList.Add(new(sortingOption, c => c.Estado));
                                break;
                        }
                    }
                }
                if (args?.FilteringOptions != null)
                {
                    foreach (var filteringOption in args.FilteringOptions)
                    {
                        switch (filteringOption.Field)
                        {
                            case "term":
                                {
                                    Expression<Func<AigFormaFarmaceutica, bool>> expression = f => f.Nombre.Contains((string)filteringOption.Value);
                                    filterList.Add(expression);
                                }
                                break;
                          
                        }
                    }
                }
                if (orderByList.Count == 0)
                    orderByList.Add(new(new() { Direction = SortingDirection.ASC }, c => c.Created));

                var filterSpec = new PharmaceuticalSpecification(filterList);
                result = await _repository.Entities
                                          .OrderBy(orderByList)
                                          .WhereBy(filterSpec)
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                                          .PaginatedByAsync(args.PageIndex, args.PageSize);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            catch (Exception exc)
            {
                _logger.Error(exc.Message, exc);
            }
            return result;
        }
    }
}
