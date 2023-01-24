using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Response
{
    public class DashboardMedicamentResponse
    {
        public int MedicamentCount { set; get; } = 0;

        public int InterchangeableCount { set; get; }
        public string InterchangeablePercent { set; get; }

        public string GenericPercent { set; get; }
        public int GenericCount { set; get; }
  
        public int ReferenceCount { set; get; }
        public string ReferencePercent { set; get; }

        public int PrescriptionCount { set; get; }
        public string PrescriptionPercent { set; get; }

        public int NotPrescriptionCount { set; get; }
        public string NotPrescriptionPercent { set; get; }

        public int HospitalUseCount { set; get; }
        public string HospitalUsePercent { set; get; }

        public int PopularSaleCount { set; get; }
        public string PopularSalePercent { set; get; }

        public int ActiveCount { set; get; }
        public string ActivePercent { set; get; }

        public int NotActiveCount { set; get; }
        public string NotActivePercent { set; get; }
    }
}
