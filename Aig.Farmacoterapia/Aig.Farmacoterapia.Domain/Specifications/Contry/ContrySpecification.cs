﻿using Aig.Farmacoterapia.Domain.Entities;
using Aig.Farmacoterapia.Domain.Specifications.Base;
using System.Linq.Expressions;

namespace Aig.Farmacoterapia.Domain.Specifications.Contry
{
    public class ContrySpecification : BaseSpecification<AigPais>
    {
        public ContrySpecification(string value)
        {
            if (!string.IsNullOrEmpty(value))
                Criteria = p => p.Nombre.ToLower().StartsWith(value.ToLower());
        }
        public ContrySpecification(List<Expression<Func<AigPais, bool>>> filters)
        {
            Criteria = p => true;
            foreach (var filter in filters)
                And(filter);
            }
      }
}