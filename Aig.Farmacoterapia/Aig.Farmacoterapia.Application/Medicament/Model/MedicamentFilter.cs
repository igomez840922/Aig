using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Application.Medicament.Model
{
    public class BaseFilter
    {
        public BaseFilter()
        {
            Term = string.Empty;
        }
        [DefaultValue("")]
        public string Term { get; set; }
    }
    public class MedicamentFilter: BaseFilter
    {
        public MedicamentFilter():base() {
            StartDate = null;
            EndDate =null;
        }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
    public class MedicamentPageSearch : BaseFilter
    {
        public MedicamentPageSearch() : base()
        {
            PageIndex = 1;
            PageSize = 10;
        }
        [DefaultValue(1)]
        public int PageIndex { get; set; }
        [DefaultValue(10)]
        public int PageSize { get; set; }
    }
}
