using DataModel.Helper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspCierreOperacionTB : SystemId
    {
        private AUD_InspeccionTB inspeccion;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //Datos del Representante Legal
        private AUD_DatosRepresentLegal datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRepresentLegal DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }

        //Datos de la Inspeccion
        private AUD_DatosInspeccion datosInspeccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosInspeccion DatosInspeccion { get => datosInspeccion; set => SetProperty(ref datosInspeccion, value); }


    }

    public class AUD_DatosInspeccion : SystemId
    {
        //SOLICITUD DE CIERRE
        private string solicitudCierre;
        public string SolicitudCierre { get => solicitudCierre; set => SetProperty(ref solicitudCierre, value); }

        //Observacion Ubicacion
        private string observacionUbicacion;
        public string ObservacionUbicacion { get => observacionUbicacion; set => SetProperty(ref observacionUbicacion, value); }

        //Destino de productos
        private string destinoProductos;
        public string DestinoProductos { get => destinoProductos; set => SetProperty(ref destinoProductos, value); }

    }

}
