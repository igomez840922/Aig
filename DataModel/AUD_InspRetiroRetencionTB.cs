using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspRetiroRetencionTB:SystemId
    {
       
        private string seccionOficinaRegional;
        [StringLength(250)]
        public string SeccionOficinaRegional { get => seccionOficinaRegional; set => SetProperty(ref seccionOficinaRegional, value); }

        
        //tipo de retención
        private enum_InspRetiroRetencionType retiroRetencionType;
        public enum_InspRetiroRetencionType RetiroRetencionType { get => retiroRetencionType; set => SetProperty(ref retiroRetencionType, value); }


        private List<AUD_ProdRetiroRetencionTB> lProductos;
        public virtual List<AUD_ProdRetiroRetencionTB> LProductos { get => lProductos; set => SetProperty(ref lProductos, value); }

        private AUD_InspeccionTB inspeccion;
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

    }
}
