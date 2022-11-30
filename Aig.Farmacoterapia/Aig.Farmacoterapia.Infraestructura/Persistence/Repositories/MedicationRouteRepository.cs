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
    public class MedicationRouteRepository : IMedicationRouteRepository
    {
        private readonly IRepositoryAsync<AigViaAdministracion> _repository;
        private readonly ISystemLogger _logger;

        public MedicationRouteRepository(IRepositoryAsync<AigViaAdministracion> repository, ISystemLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<PaginatedResult<AigViaAdministracion>> ListAsync(PageSearchArgs args)
        {
            if (args == null) throw new Exception();
            var result = new PaginatedResult<AigViaAdministracion>(new List<AigViaAdministracion>());
            try
            {
                var orderByList = new List<Tuple<SortingOption, Expression<Func<AigViaAdministracion, object>>>>();
                var filterList = new List<Expression<Func<AigViaAdministracion, bool>>>();

                if (args.SortingOptions != null)
                {
                    foreach (var sortingOption in args.SortingOptions)
                    {
                        switch (sortingOption.Field)
                        {
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
                                    Expression<Func<AigViaAdministracion, bool>> expression = f => f.Nombre.ToLower().Contains(((string)filteringOption.Value).ToLower());
                                    filterList.Add(expression);
                                }
                                break;
                          
                        }
                    }
                }
                if (orderByList.Count == 0)
                    orderByList.Add(new(new() { Direction = SortingDirection.ASC }, c => c.Created));

                var filterSpec = new MedicationRouteSpecification(filterList);
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
