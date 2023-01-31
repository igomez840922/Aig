using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies;
using Aig.Farmacoterapia.Domain.Entities.Studies.Enums;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Interfaces.Studies;
using Aig.Farmacoterapia.Domain.Specifications.Studies;
using Aig.Farmacoterapia.Infrastructure.Extensions;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Repositories.Studies
{
    public class AigEstudioRepository : IAigEstudioRepository
    {
        private readonly IRepositoryAsync<AigEstudio> _repository;
        private readonly ISystemLogger _logger;
        public AigEstudioRepository(IRepositoryAsync<AigEstudio> repository, ISystemLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<PaginatedResult<AigEstudio>> ListAsync(PageSearchArgs args)
        {
            if (args == null) throw new Exception();
            var result = new PaginatedResult<AigEstudio>(new List<AigEstudio>());
            try
            {
                var orderByList = new List<Tuple<SortingOption, Expression<Func<AigEstudio, object>>>>();
                var filterList = new List<Expression<Func<AigEstudio, bool>>>();
               
                if (args.SortingOptions != null){
                    foreach (var sortingOption in args.SortingOptions){
                        switch (sortingOption.Field){
                            case "created":
                                  orderByList.Add(new(sortingOption, c => c.Created));
                                  break;
                            case "modified":
                                orderByList.Add(new(sortingOption, c => c.LastModified!));
                                break;
                            case "title":
                                orderByList.Add(new(sortingOption, c => c.Titulo));
                                break;
                            case "evaluationDate":
                                orderByList.Add(new(sortingOption, c => c.Nota.FechaEvaluacion!));
                                break;
                            case "admissionDate":
                                orderByList.Add(new(sortingOption, c => c.FechaIngreso!));
                                break;
                        }
                    }
                }
                if (args?.FilteringOptions != null) {
                    foreach (var filteringOption in args.FilteringOptions){
                        switch (filteringOption.Field){
                            case "term":
                                {
                                    Expression<Func<AigEstudio, bool>> expression = f => f.Codigo.Contains((string)filteringOption.Value) ||
                                    f.Titulo.ToLower().Contains(((string)filteringOption.Value).ToLower()) ||
                                    f.CentroInvestigacion.ToLower().Contains(((string)filteringOption.Value).ToLower()) ||
                                    f.InvestigadorPrincipal.ToLower().Contains(((string)filteringOption.Value).ToLower());
                                    filterList.Add(expression);
                                 }
                                break;
                            case "state":
                                {
                                    var state = (EstadoEstudio)Enum.Parse(typeof(EstadoEstudio),filteringOption.Value, true);
                                    Expression<Func<AigEstudio, bool>> expression = f => f.Estado == state;
                                    filterList.Add(expression);
                                }
                                break;
                            case "startEvaluationDate":
                                {
                                    var value = filteringOption.Value;
                                    var date = DateTime.ParseExact(value,"dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    Expression<Func<AigEstudio, bool>> expression = f => f.Nota.FechaEvaluacion >= date;
                                    filterList.Add(expression);

                                }
                                break;
                            case "endEvaluationDate":
                                {
                                    var value = filteringOption.Value;
                                    var date = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    Expression<Func<AigEstudio, bool>> expression = f => f.Nota.FechaEvaluacion <= date;
                                    filterList.Add(expression);
                                }
                                break;
                            case "startAdmissionDate":
                                {
                                    var value = filteringOption.Value;
                                    var date = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    Expression<Func<AigEstudio, bool>> expression = f => f.FechaIngreso >= date;
                                    filterList.Add(expression);

                                }
                                break;
                            case "endAdmissionDate":
                                {
                                    var value = filteringOption.Value;
                                    var date = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    Expression<Func<AigEstudio, bool>> expression = f => f.FechaIngreso <= date;
                                    filterList.Add(expression);
                                }
                                break;
                         
                        }
                    }
                }
                if (orderByList.Count == 0)
                    orderByList.Add(new(new() { Direction = SortingDirection.ASC }, c => c.Created));

                var filterSpec = new StudieSpecification(filterList);
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
