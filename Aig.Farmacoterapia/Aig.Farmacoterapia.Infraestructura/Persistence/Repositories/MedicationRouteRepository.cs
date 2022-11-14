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
#pragma warning disable CS8603 // Possible null reference return.
                                orderByList.Add(new(sortingOption, c => c.Nombre));
#pragma warning restore CS8603 // Possible null reference return.
                                break;
                            case "status":
#pragma warning disable CS8603 // Possible null reference return.
                                orderByList.Add(new(sortingOption, c => c.Estado));
#pragma warning restore CS8603 // Possible null reference return.
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
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                                    Expression<Func<AigViaAdministracion, bool>> expression = f => f.Nombre.Contains((string)filteringOption.Value);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
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
