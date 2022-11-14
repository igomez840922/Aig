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
    public class MedicamentRepository : IMedicamentRepository
    {
        private readonly IRepositoryAsync<AigMedicamento> _repository;
        private readonly ISystemLogger _logger;

        public MedicamentRepository(IRepositoryAsync<AigMedicamento> repository, ISystemLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<PaginatedResult<AigMedicamento>> ListAsync(PageSearchArgs args)
        {
            if (args == null) throw new Exception();
            var result = new PaginatedResult<AigMedicamento>(new List<AigMedicamento>());
            try
            {
                var orderByList = new List<Tuple<SortingOption, Expression<Func<AigMedicamento, object>>>>();
                var filterList = new List<Expression<Func<AigMedicamento, bool>>>();
               
                if (args.SortingOptions != null){
                    foreach (var sortingOption in args.SortingOptions){
                        switch (sortingOption.Field){
                            case "created":
                                  orderByList.Add(new(sortingOption, c => c.Created));
                                  break;
                            case "modified":
#pragma warning disable CS8603 // Possible null reference return.
                                orderByList.Add(new(sortingOption, c => c.LastModified));
#pragma warning restore CS8603 // Possible null reference return.
                                break;
                            case "numReg":
                                orderByList.Add(new(sortingOption, c => c.NumReg));
                                break;
                            case "name":
                                orderByList.Add(new(sortingOption, c => c.Nombre));
                                break;
                            case "dateOfIssue":
#pragma warning disable CS8603 // Possible null reference return.
                                orderByList.Add(new(sortingOption, c => c.FechaEmision));
#pragma warning restore CS8603 // Possible null reference return.
                                break;
                            case "expirationDate":
#pragma warning disable CS8603 // Possible null reference return.
                                orderByList.Add(new(sortingOption, c => c.FechaExpiracion));
#pragma warning restore CS8603 // Possible null reference return.
                                break;
                        }
                    }
                }
                if (args?.FilteringOptions != null) {
                    foreach (var filteringOption in args.FilteringOptions){
                        switch (filteringOption.Field){
                            case "term":
                                {
                                    Expression<Func<AigMedicamento, bool>> expression = f => f.NumReg.Contains((string)filteringOption.Value) ||
                                    f.Nombre.Contains((string)filteringOption.Value) ||
                                    f.Principio.Contains((string)filteringOption.Value);
                                    filterList.Add(expression);
                                }
                                break;
                            case "startDateOfIssue":
                                {
                                    var value = filteringOption.Value.ToString();
#pragma warning disable CS8604 // Possible null reference argument for parameter 's' in 'DateTime DateTime.Parse(string s, IFormatProvider? provider, DateTimeStyles styles)'.
                                    var date = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.None);
#pragma warning restore CS8604 // Possible null reference argument for parameter 's' in 'DateTime DateTime.Parse(string s, IFormatProvider? provider, DateTimeStyles styles)'.
                                    Expression<Func<AigMedicamento, bool>> expression = f => f.FechaEmision >= date;
                                    filterList.Add(expression);

                                }
                                break;
                            case "endDateOfIssue":
                                {
                                    var value = filteringOption.Value.ToString();
#pragma warning disable CS8604 // Possible null reference argument for parameter 's' in 'DateTime DateTime.Parse(string s, IFormatProvider? provider, DateTimeStyles styles)'.
                                    var date = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.None);
#pragma warning restore CS8604 // Possible null reference argument for parameter 's' in 'DateTime DateTime.Parse(string s, IFormatProvider? provider, DateTimeStyles styles)'.
                                    Expression<Func<AigMedicamento, bool>> expression = f => f.FechaEmision <= date;
                                    filterList.Add(expression);
                                }
                                break;
                            case "startExpirationDate":
                                {
                                    var value = filteringOption.Value.ToString();
#pragma warning disable CS8604 // Possible null reference argument for parameter 's' in 'DateTime DateTime.Parse(string s, IFormatProvider? provider, DateTimeStyles styles)'.
                                    var date = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.None);
#pragma warning restore CS8604 // Possible null reference argument for parameter 's' in 'DateTime DateTime.Parse(string s, IFormatProvider? provider, DateTimeStyles styles)'.
                                    Expression<Func<AigMedicamento, bool>> expression = f => f.FechaEmision >= date;
                                    filterList.Add(expression);

                                }
                                break;
                            case "endDateExpirationDate":
                                {
                                    var value = filteringOption.Value.ToString();
#pragma warning disable CS8604 // Possible null reference argument for parameter 's' in 'DateTime DateTime.Parse(string s, IFormatProvider? provider, DateTimeStyles styles)'.
                                    var date = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.None);
#pragma warning restore CS8604 // Possible null reference argument for parameter 's' in 'DateTime DateTime.Parse(string s, IFormatProvider? provider, DateTimeStyles styles)'.
                                    Expression<Func<AigMedicamento, bool>> expression = f => f.FechaEmision <= date;
                                    filterList.Add(expression);
                                }
                                break;
                        }
                    }
                }
                if (orderByList.Count == 0)
                    orderByList.Add(new(new() { Direction = SortingDirection.ASC }, c => c.Created));

                var filterSpec = new MedicamentSpecification(filterList);
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
