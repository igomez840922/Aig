using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Specifications.Contry;
using Aig.Farmacoterapia.Infrastructure.Extensions;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Repositories
{
    public class ContryRepository : IContryRepository
    {
        private readonly IRepositoryAsync<AigPais> _repository;
        private readonly ISystemLogger _logger;
        public ContryRepository(IRepositoryAsync<AigPais> repository, ISystemLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<PaginatedResult<AigPais>> ListAsync(PageSearchArgs args)
        {
            if (args == null) throw new Exception();
            var result = new PaginatedResult<AigPais>(new List<AigPais>());
            try
            {
                var orderByList = new List<Tuple<SortingOption, Expression<Func<AigPais, object>>>>();
                var filterList = new List<Expression<Func<AigPais, bool>>>();

                if (args.SortingOptions != null)
                {
                    foreach (var sortingOption in args.SortingOptions)
                    {
                        switch (sortingOption.Field)
                        {
                            case "iso":
                                orderByList.Add(new(sortingOption, c => c.Iso));
                                break;
                            case "name":
                                orderByList.Add(new(sortingOption, c => c.Nombre));
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
                                    Expression<Func<AigPais, bool>> expression = f => f.Nombre.ToLower().Contains(((string)filteringOption.Value).ToLower());
                                    filterList.Add(expression);
                                }
                                break;

                        }
                    }
                }
                if (orderByList.Count == 0)
                    orderByList.Add(new(new() { Direction = SortingDirection.ASC }, c => c.Created));

                var filterSpec = new ContrySpecification(filterList);
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
