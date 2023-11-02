using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{    
    public class AUD_DatosRetiroRetencion : SystemId
    {
        public AUD_DatosRetiroRetencion()
        {
            LProductos = new List<AUD_ProdRetiroRetencionTB>();
        }

        //tipo de retención
        private enum_InspRetiroRetencionType retiroRetencionType;
        public enum_InspRetiroRetencionType RetiroRetencionType { get => retiroRetencionType; set => SetProperty(ref retiroRetencionType, value); }

        private List<AUD_ProdRetiroRetencionTB> lProductos;
        public virtual List<AUD_ProdRetiroRetencionTB> LProductos { get => lProductos; set => SetProperty(ref lProductos, value); }

    }

}
