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

        private AUD_InspeccionTB inspeccion;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //tipo de retención
        private enum_InspRetiroRetencionType retiroRetencionType;
        public enum_InspRetiroRetencionType RetiroRetencionType { get => retiroRetencionType; set => SetProperty(ref retiroRetencionType, value); }

        //Datos del Representante Legal
        private AUD_DatosRepresentLegal datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRepresentLegal DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }
        
        //Datos Atendidos Por
        private AUD_DatosAtendidosPor datosAtendidosPor;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAtendidosPor DatosAtendidosPor { get => datosAtendidosPor; set => SetProperty(ref datosAtendidosPor, value); }


        private List<AUD_ProdRetiroRetencionTB> lProductos;
        public virtual List<AUD_ProdRetiroRetencionTB> LProductos { get => lProductos; set => SetProperty(ref lProductos, value); }

                

    }
}
