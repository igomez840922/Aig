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
        public AUD_InspCierreOperacionTB()
        {
            GeneralesEmpresa = new AUD_GeneralesEmpresa();
            DatosResponsable = new DatosPersona();

            DatosConclusiones = new AUD_DatosConclusiones();

        }

        private AUD_InspeccionTB inspeccion;
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }


        //Generales Empresa
        private AUD_GeneralesEmpresa generalesEmpresa;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_GeneralesEmpresa GeneralesEmpresa { get => generalesEmpresa; set => SetProperty(ref generalesEmpresa, value); }

        //DATOS RESPONSABLE DEL ESTABLECIMIENTO
        private DatosPersona datosResponsable;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona DatosResponsable { get => datosResponsable; set => SetProperty(ref datosResponsable, value); }

        //SOLICITUD DE CIERRE
        private string solicitudCierre;
        public string SolicitudCierre { get => solicitudCierre; set => SetProperty(ref solicitudCierre, value); }

        //Observacion Ubicacion
        private string observacionUbicacion;
        public string ObservacionUbicacion { get => observacionUbicacion; set => SetProperty(ref observacionUbicacion, value); }

        //Destino de productos
        private string destinoProductos;
        public string DestinoProductos { get => destinoProductos; set => SetProperty(ref destinoProductos, value); }


        //Datos Conclusión de Inspección
        private AUD_DatosConclusiones datosConclusiones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosConclusiones DatosConclusiones { get => datosConclusiones; set => SetProperty(ref datosConclusiones, value); }


    }

}
