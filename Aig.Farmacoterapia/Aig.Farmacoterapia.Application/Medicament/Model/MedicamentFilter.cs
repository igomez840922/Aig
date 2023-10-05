using Aig.Farmacoterapia.Domain.Entities;
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
            All = true;
        }
        [DefaultValue("")]
        public string Term { get; set; }
        [DefaultValue(true)]
        public bool All { get; set; }
    }
    public class MedicamentFilter: BaseFilter
    {
        public MedicamentFilter():base() {
            StartDate = null;
            EndDate =null;
            StartExpirationDate = null;
            EndExpirationDate = null;
        }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartExpirationDate { get; set; }
        public DateTime? EndExpirationDate { get; set; }
        public AigFabricante? Fabricante { get; set; }

    }
    public class RequestPageSearch : BaseFilter
    {
        public RequestPageSearch() : base()
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
