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
        public AUD_InspRetiroRetencionTB()
        {
            DatosRegente = new AUD_DatosRegente();
            DatosRepresentLegal = new AUD_DatosRepresentLegal();
            DatosAtendidosPor = new AUD_DatosAtendidosPor();

            DatosConclusiones = new AUD_DatosConclusiones();
            LProductos = new List<AUD_ProdRetiroRetencionTB>();

        }

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

        //Datos Conclusión de Inspección
        private AUD_DatosConclusiones datosConclusiones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosConclusiones DatosConclusiones { get => datosConclusiones; set => SetProperty(ref datosConclusiones, value); }


        //Datos Regente
        private AUD_DatosRegente datosRegente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRegente DatosRegente { get => datosRegente; set => SetProperty(ref datosRegente, value); }

        //Datos Represent Legal
        private AUD_DatosRepresentLegal datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRepresentLegal DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }

        //Datos Atendidos Por
        private AUD_DatosAtendidosPor datosAtendidosPor;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAtendidosPor DatosAtendidosPor { get => datosAtendidosPor; set => SetProperty(ref datosAtendidosPor, value); }

        
    }
}
