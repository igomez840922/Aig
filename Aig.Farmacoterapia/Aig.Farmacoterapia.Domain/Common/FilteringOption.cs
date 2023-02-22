﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Common
{
    public enum FilteringOperator
    {
        Contains,
        NotContains,
        LessThan,
        LessThanEqual,
        GreaterThan,
        GreaterThanEqual,
        NotEqual,
        Equal,
        StartsWith,
        EndsWith
    }
    public enum LogicalOperator {Or, And}
    public class FilteringOption
    {
        public string Field { get; set; }
        public FilteringOperator Operator { get; set; }
        public string Value { get; set; }
    }
}
