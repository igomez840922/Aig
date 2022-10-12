using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspRetiroRetencionTB:SystemId
    {        
        public virtual List<AUD_ProdRetiroRetencionTB> LProductos { get; set; }
    }
}
