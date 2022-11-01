using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Common
{
    public class PageArgs
    {
      
        public int PageIndex { get; set; }
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
        }

        public List<SortingOption> SortingOptions { get; set; }
        public List<FilteringOption> FilteringOptions { get; set; }
    }
}
