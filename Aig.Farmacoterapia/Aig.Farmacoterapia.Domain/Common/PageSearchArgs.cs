using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Common
{
    public class PageArgs
    {
        [DefaultValue(1)]
        public int PageIndex { get; set; }
        [DefaultValue(10)]
        public int PageSize { get; set; }
        public PageArgs()
        {
            PageIndex = 1;
            PageSize = 10;
        }
    }
    public class PageSearchArgs: PageArgs
    {
        public PageSearchArgs():base() {
            SortingOptions= new List<SortingOption>();
            FilteringOptions=new List<FilteringOption>();
            LogicalOperator = LogicalOperator.Or;
        }
        public List<SortingOption> SortingOptions { get; set; }
        public List<FilteringOption> FilteringOptions { get; set; }
        [DefaultValue(LogicalOperator.Or)]
        public LogicalOperator LogicalOperator { get; set; }
    }
}
