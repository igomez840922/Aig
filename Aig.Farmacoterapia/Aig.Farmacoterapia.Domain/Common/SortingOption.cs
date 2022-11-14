using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Common
{
    public enum SortingDirection
    {
        ASC,
        DESC
    }

    public class SortingOption
    {
#pragma warning disable CS8618 // Non-nullable property 'Field' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Field { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Field' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        public SortingDirection Direction { get; set; }

        public int Priority { get; set; }
    }
}
