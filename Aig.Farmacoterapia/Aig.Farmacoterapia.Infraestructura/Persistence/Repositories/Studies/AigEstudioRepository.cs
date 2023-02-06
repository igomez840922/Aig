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
using LinqKit;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Repositories.Studies
{
    public class AigEstudioRepository : IAigEstudioRepository
    {
        private readonly IRepositoryAsync<AigEstudio> _repository;
        private readonly IRepositoryAsync<AigEstudioEvaluador> _evaluatorRepository;
        private readonly ISystemLogger _logger;
        public AigEstudioRepository(IRepositoryAsync<AigEstudio> repository, IRepositoryAsync<AigEstudioEvaluador> evaluatorRepository, ISystemLogger logger)
        {
            _repository = repository;
            _evaluatorRepository = evaluatorRepository;
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
                           case "assignmentDate":
                                orderByList.Add(new(sortingOption, c => c.FechaAsignacion!));
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
                                    string value = ((string)filteringOption.Value).ToLower();
                                    Expression<Func<AigEstudio, bool>> expression = f => f.Codigo.Contains(value) ||
                                    f.Titulo.ToLower().Contains(value) ||
                                    f.CentroInvestigacion.ToLower().Contains(value) ||
                                    f.ProductsMetadata.ToLower().Contains(value) ||
                                    f.InvestigadorPrincipal.ToLower().Contains(value);
                                    filterList.Add(expression);
                                }
                                break;
                            case "product":
                                {
                                    string value = ((string)filteringOption.Value).ToLower();
                                    Expression<Func<AigEstudio, bool>> expression = f => f.ProductsMetadata.ToLower().Contains(value);
                                    filterList.Add(expression);
                                }
                                break;
                            case "status":
                                {

                                    var state = (EstadoEstudio)Enum.Parse(typeof(EstadoEstudio), filteringOption.Value, true);
                                    if (state != EstadoEstudio.All)
                                    {
                                        Expression<Func<AigEstudio, bool>> expression = f => f.Estado == state;
                                        filterList.Add(expression);
                                    }
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
                            case "startAssignmentDate":
                                {
                                    var value = filteringOption.Value;
                                    var date = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    Expression<Func<AigEstudio, bool>> expression = f => f.FechaAsignacion >= date;
                                    filterList.Add(expression);

                                }
                                break;
                            case "endAssignmentDate":
                                {
                                    var value = filteringOption.Value;
                                    var date = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                    Expression<Func<AigEstudio, bool>> expression = f => f.FechaAsignacion <= date;
                                    filterList.Add(expression);
                                }
                                break;
                            case "evaluator":
                                {
                                    var value = filteringOption.Value;
                                    string[] users = new string[] { value };
                                    Expression<Func<AigEstudioEvaluador, bool>> lExp = p => users.Contains(p.UserId);
                                    var lQuery = _evaluatorRepository.Entities.AsExpandable().Where(lExp).Select(g => g.EstudioId).Distinct();
                                    Expression<Func<AigEstudio, bool>> expression = f => lQuery.Contains(f.Id);
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
            result.Data = result.Data.Select(w => { w.Evaluators = w.EstudioEvaluador.Select(s => s.UserId).ToList(); return w; }).ToList();
            return result;
        }

        public List<string> ListEvaluatorAsync(long studyId)
        {
            var result = new List<string>();
            try
            {
                var filterSpec = new StudyEvaluadorSpecification(studyId);
                result = _evaluatorRepository.Entities
                    .WhereBy(filterSpec)
                    .Select(p => p.UserId)
                    .ToList();
            }
            catch (Exception exc)
            {
                _logger.Error(exc.Message, exc);
            }
            return result;
        }
       
      
    }
}
