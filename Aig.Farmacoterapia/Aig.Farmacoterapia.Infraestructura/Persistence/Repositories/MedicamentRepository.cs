using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
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

        public async Task<PaginatedResult<AigMedicamento>> AdminListAsync(PageSearchArgs args)
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
                                orderByList.Add(new(sortingOption, c => c.LastModified));
                                break;
                            case "numReg":
                                orderByList.Add(new(sortingOption, c => c.NumReg));
                                break;
                            case "name":
                                orderByList.Add(new(sortingOption, c => c.Nombre));
                                break;
                            case "dateOfIssue":
                                orderByList.Add(new(sortingOption, c => c.FechaEmision));
                                break;
                            case "expirationDate":
                                orderByList.Add(new(sortingOption, c => c.FechaExpiracion));
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
                                    f.Nombre.ToLower().Contains(((string)filteringOption.Value).ToLower()) ||
                                    f.Principio.ToLower().Contains(((string)filteringOption.Value).ToLower()) ||
                                    f.Fabricante.Nombre.ToLower().Contains(((string)filteringOption.Value).ToLower());
                                    filterList.Add(expression);
                                }
                                break;
                            case "maker":
                                {
                                   
                                    Expression<Func<AigMedicamento, bool>> expression = f => f.Fabricante.Nombre.Contains(((string)filteringOption.Value));
                                    filterList.Add(expression);
                                }
                                break;
                            case "startDateOfIssue":
                                {
                                    var value = filteringOption.Value.ToString();
                                    var date = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    Expression<Func<AigMedicamento, bool>> expression = f => f.FechaEmision >= date;
                                    filterList.Add(expression);

                                }
                                break;
                            case "endDateOfIssue":
                                {
                                    var value = filteringOption.Value.ToString();
                                    var date = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    Expression<Func<AigMedicamento, bool>> expression = f => f.FechaEmision <= date;
                                    filterList.Add(expression);
                                }
                                break;
                            case "startExpirationDate":
                                {
                                    var value = filteringOption.Value.ToString();
                                    var date = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    Expression<Func<AigMedicamento, bool>> expression = f => f.FechaExpiracion >= date;
                                    filterList.Add(expression);

                                }
                                break;
                            case "endDateExpirationDate":
                                {
                                    var value = filteringOption.Value.ToString();
                                    var date = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    Expression<Func<AigMedicamento, bool>> expression = f => f.FechaExpiracion <= date;
                                    filterList.Add(expression);
                                }
                                break;
                            case "MedicalPrescription":
                                {
                                    var value = filteringOption.Value.ToString();
                                    Expression<Func<AigMedicamento, bool>> expression = f => f.CondicionVenta == value;
                                    filterList.Add(expression);
                                }
                                break;
                            case "HospitalUse":
                            case "PopularSale":
                                {
                                    var value = filteringOption.Value.ToString();
                                    Expression<Func<AigMedicamento, bool>> expression = filteringOption.Operator == FilteringOperator.Equal ?
                                        f => f.CondicionVenta == value :
                                        f => f.CondicionVenta != value;
                                    filterList.Add(expression);
                                }
                                break;
                            case "ChemicalSynthesis":
                            case "Radiopharmaceuticals":
                            case "Orphans":
                            case "Homeopathic":
                            case "Phytopharmaceuticals":
                            case "Biotechnological":
                            case "Biological":
                                {
                                    var value = filteringOption.Value.ToString();
                                    Expression<Func<AigMedicamento, bool>> expression = filteringOption.Operator == FilteringOperator.Equal ?
                                        f => f.TipoMedicamento == value :
                                        f => f.TipoMedicamento != value;
                                    filterList.Add(expression);
                                }
                                break;
                            case "Interchangeable":
                            case "Referencia":
                            case "Generic":
                            case "Mark":
                                {
                                    var value = filteringOption.Value.ToString();
                                    Expression<Func<AigMedicamento, bool>> expression = filteringOption.Operator == FilteringOperator.Equal ?
                                        f => f.TipoEquivalencia == value :
                                        f => f.TipoEquivalencia != value;
                                    filterList.Add(expression);
                                }
                                break;


                        }
                    }
                }
                if (orderByList.Count == 0)
                    orderByList.Add(new(new() { Direction = SortingDirection.ASC }, c => c.Created));

                var filterSpec = new AdminMedicamentSpecification(filterList);
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
        public async Task<PaginatedResult<AigMedicamento>> ListAsync(PageSearchArgs args, LogicalOperator logicalOperator = LogicalOperator.Or)
        {
            if (args == null) throw new Exception();
            var result = new PaginatedResult<AigMedicamento>(new List<AigMedicamento>());
            try
            {
                var orderByList = new List<Tuple<SortingOption, Expression<Func<AigMedicamento, object>>>>();
                var filterList = new List<Expression<Func<AigMedicamento, bool>>>();

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
                                orderByList.Add(new(sortingOption, c => c.LastModified));
                                break;
                            case "numReg":
                                orderByList.Add(new(sortingOption, c => c.NumReg));
                                break;
                            case "name":
                                orderByList.Add(new(sortingOption, c => c.Nombre));
                                break;
                            case "dateOfIssue":
                                orderByList.Add(new(sortingOption, c => c.FechaEmision));
                                break;
                            case "expirationDate":
                                orderByList.Add(new(sortingOption, c => c.FechaExpiracion));
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
                                    var value = filteringOption.Value.ToString().Trim().ToLower();
                                    Expression<Func<AigMedicamento, bool>> expression = f => f.NumReg.Contains((string)filteringOption.Value) ||
                                    f.Nombre.ToLower().Contains(value) ||
                                    f.Principio.ToLower().Contains(value) ||
                                    f.Fabricante.Nombre.ToLower().Contains(value);
                                    filterList.Add(expression);
                                }
                                break;
                            case "MedicalPrescription":
                                {
                                    var value = filteringOption.Value.ToString();
                                    Expression<Func<AigMedicamento, bool>> expression = f => f.CondicionVenta == value;
                                    filterList.Add(expression);
                                }
                                break;
                            case "HospitalUse":
                            case "PopularSale":
                                {
                                    var value = filteringOption.Value.ToString();
                                    Expression<Func<AigMedicamento, bool>> expression = filteringOption.Operator == FilteringOperator.Equal ?
                                        f => f.CondicionVenta == value :
                                        f => f.CondicionVenta != value;
                                    filterList.Add(expression);
                                }
                                break;
                            case "ChemicalSynthesis":
                            case "Radiopharmaceuticals":
                            case "Orphans":
                            case "Homeopathic":
                            case "Phytopharmaceuticals":
                            case "Biotechnological":
                            case "Biological":
                                {
                                    var value = filteringOption.Value.ToString();
                                    Expression<Func<AigMedicamento, bool>> expression = filteringOption.Operator == FilteringOperator.Equal ?
                                        f => f.TipoMedicamento == value :
                                        f => f.TipoMedicamento != value;
                                    filterList.Add(expression);
                                }
                                break;
                            case "Interchangeable":
                            case "Referencia":
                            case "Generic":
                            case "Mark":
                                {
                                    var value = filteringOption.Value.ToString();
                                    Expression<Func<AigMedicamento, bool>> expression = filteringOption.Operator == FilteringOperator.Equal ?
                                        f => f.TipoEquivalencia == value :
                                        f => f.TipoEquivalencia != value;
                                    filterList.Add(expression);
                                }
                                break;


                        }
                    }
                }
                if (orderByList.Count == 0)
                    orderByList.Add(new(new() { Direction = SortingDirection.ASC }, c => c.Created));

                var filterSpec = new MedicamentSpecification(filterList, logicalOperator);
                result = await _repository.Entities
                                          .OrderBy(orderByList)
                                          .WhereBy2(filterSpec)
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
