using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Interfaces.Studies;
using Aig.Farmacoterapia.Domain.Specifications.Studies;
using Aig.Farmacoterapia.Infrastructure.Extensions;
using LinqKit;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Repositories.Studies
{
    public class AigCodigoEstudioRepository : IAigCodigoEstudioRepository
    {
        private readonly IRepositoryAsync<AigCodigoEstudio> _repository;
        private readonly ISystemLogger _logger;
        public AigCodigoEstudioRepository(IRepositoryAsync<AigCodigoEstudio> repository,ISystemLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<PaginatedResult<AigCodigoEstudio>> ListAsync(PageSearchArgs args)
        {
            if (args == null) throw new Exception();
            var result = new PaginatedResult<AigCodigoEstudio>(new List<AigCodigoEstudio>());
            try
            {
                var orderByList = new List<Tuple<SortingOption, Expression<Func<AigCodigoEstudio, object>>>>();
                var filterList = new List<Expression<Func<AigCodigoEstudio, bool>>>();
               
                if (args.SortingOptions != null){
                    foreach (var sortingOption in args.SortingOptions){
                        switch (sortingOption.Field){
                            case "created":
                                  orderByList.Add(new(sortingOption, c => c.Created));
                                  break;
                            case "modified":
                                orderByList.Add(new(sortingOption, c => c.LastModified!));
                                break;
                            case "code":
                                orderByList.Add(new(sortingOption, c => c.Codigo));
                                break;
                        }
                    }
                }
                if (args?.FilteringOptions != null) {
                    foreach (var filteringOption in args.FilteringOptions){
                        switch (filteringOption.Field){
                            case "term":
                                {
                                    string value = ((string)filteringOption.Value).ToLower();
                                    Expression<Func<AigCodigoEstudio, bool>> expression = f => f.Codigo.Contains(value);                                  
                                    filterList.Add(expression);
                                }
                                break;
                        }
                    }
                }
                if (orderByList.Count == 0)
                    orderByList.Add(new(new() { Direction = SortingDirection.ASC }, c => c.Created));

                var filterSpec = new CodeSpecification(filterList);
                result = await _repository.Entities
                                          .OrderBy(orderByList)
                                          .WhereBy(filterSpec)
                                          .PaginatedByAsync(args.PageIndex, args.PageSize);
            }
            catch (Exception exc)
            {
                 _logger.Error(exc.Message, exc);
            }
            return result;
        }

    }
}
