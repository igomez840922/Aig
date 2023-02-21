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
        private AUD_InspeccionTB inspeccion;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //Datos Atendidos Por
        private AUD_DatosAtendidosPor datosAtendidosPor;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAtendidosPor DatosAtendidosPor { get => datosAtendidosPor; set => SetProperty(ref datosAtendidosPor, value); }

        //Datos Atendidos Por
        private AUD_DetallesInvestigacion detallesInvestigacion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DetallesInvestigacion DetallesInvestigacion { get => detallesInvestigacion; set => SetProperty(ref detallesInvestigacion, value); }

        
    }

    public class AUD_DetallesInvestigacion : SystemId
    {
        private string detalleVerificacion;
        public string DetalleVerificacion { get => detalleVerificacion; set => SetProperty(ref detalleVerificacion, value); }


        private string detalleInspeccion;
        public string DetalleInspeccion { get => detalleInspeccion; set => SetProperty(ref detalleInspeccion, value); }


        private enumOpcionSiNo adjuntaActaRetencion;
        public enumOpcionSiNo AdjuntaActaRetencion { get => adjuntaActaRetencion; set => SetProperty(ref adjuntaActaRetencion, value); }

        private enumOpcionSiNo movilizarProductos;
        public enumOpcionSiNo MovilizarProductos { get => movilizarProductos; set => SetProperty(ref movilizarProductos, value); }

    }
}
