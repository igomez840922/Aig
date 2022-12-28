﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Domain.Specifications.Studies;
using Aig.Farmacoterapia.Infrastructure.Extensions;

namespace Aig.Farmacoterapia.Infrastructure.Persistence.Repositories
{
    public class StudiesRepository : IStudiesRepository
    {
        private readonly IRepositoryAsync<AigEstudios> _repository;
        private readonly ISystemLogger _logger;
        public StudiesRepository(IRepositoryAsync<AigEstudios> repository, ISystemLogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<PaginatedResult<AigEstudios>> ListAsync(PageSearchArgs args)
        {
         
            if (args == null) throw new Exception();
            var result = new PaginatedResult<AigEstudios>(new List<AigEstudios>());
            try
            {
                var orderByList = new List<Tuple<SortingOption, Expression<Func<AigEstudios, object>>>>();
                var filterList = new List<Expression<Func<AigEstudios, bool>>>();

                if (args.SortingOptions != null)
                {
                    foreach (var sortingOption in args.SortingOptions)
                    {
                        switch (sortingOption.Field)
                        {
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
                                   Expression<Func<AigEstudios, bool>> expression = f => f.Codigo.Contains((string)filteringOption.Value) ||
                                   f.Nombre.ToLower().Contains(((string)filteringOption.Value).ToLower()) ||
                                   f.InvestigadorPrincipal.ToLower().Contains(((string)filteringOption.Value).ToLower()) ||
                                   f.ComiteBioetica.ToLower().Contains(((string)filteringOption.Value).ToLower()) ||
                                   f.CentroInvestigacion.ToLower().Contains(((string)filteringOption.Value).ToLower());
                                   filterList.Add(expression);
                                }
                                break;
                            case "startEvaluationDate":
                                {
                                    var value = filteringOption.Value.ToString();
                                    var date = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    Expression<Func<AigEstudios, bool>> expression = f => f.FechaEvaluacion >= date;
                                    filterList.Add(expression);

                                }
                                break;
                            case "sendEvaluationDate":
                                {
                                    var value = filteringOption.Value.ToString();
                                    var date = DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.None);
                                    Expression<Func<AigEstudios, bool>> expression = f => f.FechaEvaluacion <= date;
                                    filterList.Add(expression);
                                }
                                break;

                        }
                    }
                }
                if (orderByList.Count == 0)
                    orderByList.Add(new(new() { Direction = SortingDirection.ASC }, c => c.Created));

                var filterSpec = new StudiesSpecification(filterList);
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