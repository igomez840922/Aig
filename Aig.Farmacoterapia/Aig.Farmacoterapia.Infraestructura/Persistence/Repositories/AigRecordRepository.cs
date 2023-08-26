using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Entities.Enums;
using Aig.Farmacoterapia.Domain.Entities.Products;
using Aig.Farmacoterapia.Domain.Extensions;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Specifications.Record;
using Aig.Farmacoterapia.Infrastructure.Extensions;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Repositories
{
    public class AigRecordRepository : IAigRecordRepository
    {
        private readonly IRepositoryAsync<AigRecord> _repository;
        private readonly ISystemLogger _logger;

        public AigRecordRepository(IRepositoryAsync<AigRecord> repository, ISystemLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<PaginatedResult<AigRecord>> AdminListAsync(PageSearchArgs args)
        {
            if (args == null) throw new Exception();
            var result = new PaginatedResult<AigRecord>(new List<AigRecord>());
            try
            {
                var orderByList = new List<Tuple<SortingOption, Expression<Func<AigRecord, object>>>>();
                var filterList = new List<Expression<Func<AigRecord, bool>>>();
               
                if (args.SortingOptions != null){
                    foreach (var sortingOption in args.SortingOptions)
                    {
                        switch (sortingOption.Field)
                        {
                            case "created":
                                orderByList.Add(new(sortingOption, c => c.Created));
                                break;
                            case "updated":
                                orderByList.Add(new(sortingOption, c => c.FechaUltimaActualizacion));
                                break;
                            case "numReg":
                                orderByList.Add(new(sortingOption, c => c.Numero));
                                break;
                            case "name":
                                orderByList.Add(new(sortingOption, c => c.Producto.Nombre));
                                break;
                            case "dateOfIssue":
                                orderByList.Add(new(sortingOption, c => c.FechaExpedicion));
                                break;
                            case "expirationDate":
                                orderByList.Add(new(sortingOption, c => c.FechaVencimiento));
                                break;
                        }
                    }
                }
                if (args?.FilteringOptions != null) {
                    foreach (var filteringOption in args.FilteringOptions)
                    {
                        switch (filteringOption.Field)
                        {
                            case "term":
                                {
                                    Expression<Func<AigRecord, bool>> expression = f => f.Numero.Contains((string)filteringOption.Value) ||
                                    f.Producto.Nombre.ToLower().Contains(((string)filteringOption.Value).ToLower()) ||
                                    f.Producto.PrincipioActivo.ToLower().Contains(((string)filteringOption.Value).ToLower()) ||
                                    f.Fabricante.Nombre.ToLower().Contains(((string)filteringOption.Value).ToLower());
                                    filterList.Add(expression);
                                }
                                break;
                            case "service":
                                {
                                    var service = filteringOption.Value.ParseEnum<ServiceType>();
                                    if (service != ServiceType.All)
                                    {
                                        Expression<Func<AigRecord, bool>> expression = f => f.Servicio == service;
                                        filterList.Add(expression);
                                    }
                                }
                                break;
                            case "startDateOfIssue":
                                {
                                    var value = filteringOption.Value;
                                    var date = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    Expression<Func<AigRecord, bool>> expression = f => f.FechaExpedicion >= date;
                                    filterList.Add(expression);

                                }
                                break;
                            case "endDateOfIssue":
                                {
                                    var value = filteringOption.Value;
                                    var date = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    Expression<Func<AigRecord, bool>> expression = f => f.FechaExpedicion <= date;
                                    filterList.Add(expression);
                                }
                                break;
                            case "startExpirationDate":
                                {
                                    var value = filteringOption.Value;
                                    var date = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    Expression<Func<AigRecord, bool>> expression = f => f.FechaVencimiento >= date;
                                    filterList.Add(expression);

                                }
                                break;
                            case "endDateExpirationDate":
                                {
                                    var value = filteringOption.Value;
                                    var date = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    Expression<Func<AigRecord, bool>> expression = f => f.FechaVencimiento <= date;
                                    filterList.Add(expression);
                                }
                                break;
                            case "expiration":
                                {
                                    var value = int.Parse(filteringOption.Value);
                                    Expression<Func<AigRecord, bool>> expression = value switch {
                                        0 => f => true,
                                        1 => f => DateTime.Now < f.FechaVencimiento,
                                        2 => f => DateTime.Now > f.FechaVencimiento,
                                    };
                                    filterList.Add(expression);
                                }
                                break;

                        }
                    }
                }
                if (orderByList.Count == 0)
                    orderByList.Add(new(new() { Direction = SortingDirection.ASC }, c => c.Created));

                var filterSpec = new AdminAigRecordSpecification(filterList);
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
        private string GetSaleCondition(string value)
        {
            return value switch
            {
                "SP" => "Sin Prescripción Médica", //Sin Prescripción Médica 
                "CP" => "Bajo Prescripción Médica", //Prescripción Médica,Con Prescripción Médica Controlada
                "UH" => "Uso Hospitalario Exclusivo",//
                "VP" => "Venta popular",//Venta Libre o Venta Popular
                _ => string.Empty
            };
        }
        public async Task<PaginatedResult<AigRecord>> ListAsync(PageSearchArgs args)
        {
            if (args == null) throw new Exception();
            var result = new PaginatedResult<AigRecord>(new List<AigRecord>());
            try
            {
                var orderByList = new List<Tuple<SortingOption, Expression<Func<AigRecord, object>>>>();
                var filterList = new List<Expression<Func<AigRecord, bool>>>()
                {
                    f => DateTime.Now < f.FechaVencimiento
                };

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
                                orderByList.Add(new(sortingOption, c => c.Numero));
                                break;
                            case "name":
                                orderByList.Add(new(sortingOption, c => c.Producto.Nombre));
                                break;
                            case "dateOfIssue":
                                orderByList.Add(new(sortingOption, c => c.FechaExpedicion));
                                break;
                            case "expirationDate":
                                orderByList.Add(new(sortingOption, c => c.FechaVencimiento));
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
                                    Expression<Func<AigRecord, bool>> expression = f => f.Numero.Contains((string)filteringOption.Value) ||
                                    f.Producto.Nombre.ToLower().Contains(value) ||
                                    f.Producto.PrincipioActivo.ToLower().Contains(value) ||
                                    f.Fabricante.Nombre.ToLower().Contains(value);
                                    filterList.Add(expression);
                                }
                                break;
                            case "SaleCondition":
                                {
                                    var value = filteringOption.Value.ToString();
                                    Expression<Func<AigRecord, bool>> expression = f => f.Producto.CondicionVenta == GetSaleCondition(value);
                                    filterList.Add(expression);
                                }
                                break;
                            //case "Classification":
                            //    {
                            //        var value = filteringOption.Value.ToString().Trim().ToLower(); ;
                            //        Expression<Func<AigRecord, bool>> expression = f => f.TipoMedicamento.ToLower() == value;
                            //        filterList.Add(expression);
                            //    }
                            //    break;
                            //case "Valid":
                            //    {
                            //        var value = Convert.ToBoolean(filteringOption.Value);
                            //        Expression<Func<AigMedicamento, bool>> expression = f => f.Vigente == value;
                            //        filterList.Add(expression);
                            //    }
                            //    break;

                        }
                    }
                }
                if (orderByList.Count == 0)
                    orderByList.Add(new(new() { Direction = SortingDirection.ASC }, c => c.Created));

                var filterSpec = new AigRecordSpecification(filterList, args.LogicalOperator);
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
