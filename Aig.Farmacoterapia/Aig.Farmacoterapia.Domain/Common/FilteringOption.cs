using System;
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
    public enum LogicalOperator { And, Or }
    public class FilteringOption
    {
#pragma warning disable CS8618 // Non-nullable property 'Field' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Field { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Field' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        public FilteringOperator Operator { get; set; }

#pragma warning disable CS8618 // Non-nullable property 'Value' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public object Value { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Value' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
