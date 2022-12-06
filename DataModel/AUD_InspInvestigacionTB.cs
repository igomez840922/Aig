using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspInvestigacionTB: SystemId
    {
        public AUD_InspInvestigacionTB()
        {
            DatosEstablecimiento = new AUD_DatosEstablecimiento();
            DatosAtendidosPor = new AUD_DatosAtendidosPor();
            DatosRepresentLegal = new AUD_DatosRepresentLegal();
            DatosConclusiones = new AUD_DatosConclusiones();    
        }

        private AUD_InspeccionTB inspeccion;
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }


        private string detalleVerificacion;
        public string DetalleVerificacion { get => detalleVerificacion; set => SetProperty(ref detalleVerificacion, value); }


        private string detalleInspeccion;
        public string DetalleInspeccion { get => detalleInspeccion; set => SetProperty(ref detalleInspeccion, value); }


        private enumOpcionSiNo adjuntaActaRetencion;
        public enumOpcionSiNo AdjuntaActaRetencion { get => adjuntaActaRetencion; set => SetProperty(ref adjuntaActaRetencion, value); }


        //Datos del Establecimiento
        private AUD_DatosEstablecimiento datosEstablecimiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosEstablecimiento DatosEstablecimiento { get => datosEstablecimiento; set => SetProperty(ref datosEstablecimiento, value); }

        //Datos Atendidos Por
        private AUD_DatosAtendidosPor datosAtendidosPor;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAtendidosPor DatosAtendidosPor { get => datosAtendidosPor; set => SetProperty(ref datosAtendidosPor, value); }

        //Datos del Regente
        private AUD_DatosRepresentLegal datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRepresentLegal DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }
               

        //Datos Conclusión de Inspección
        private AUD_DatosConclusiones datosConclusiones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosConclusiones DatosConclusiones { get => datosConclusiones; set => SetProperty(ref datosConclusiones, value); }

        

    }
}
