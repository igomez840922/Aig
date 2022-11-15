using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspAperCambUbicAgenTB : SystemId
    {
        public AUD_InspAperCambUbicAgenTB()
        {
            DatosEstablecimiento = new AUD_DatosEstablecimiento();
            DatosSolicitante = new AUD_DatosSolicitante();
            DatosRegente = new AUD_DatosRegente();
            DatosRepresentLegal = new AUD_DatosRepresentLegal();
            DatosCondicionesLocal = new AUD_DatosCondicionesLocal();

            DatosConclusiones = new AUD_DatosConclusiones();
        }

        private AUD_InspeccionTB inspeccion;
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //codigo
        private string reciboPago;
        [StringLength(250)]
        public string ReciboPago { get => reciboPago; set => SetProperty(ref reciboPago, value); }

        //Datos del Establecimiento
        private AUD_DatosEstablecimiento datosEstablecimiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosEstablecimiento DatosEstablecimiento { get => datosEstablecimiento; set => SetProperty(ref datosEstablecimiento, value); }

        //Datos del Solicitante
        private AUD_DatosSolicitante datosSolicitante;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosSolicitante DatosSolicitante { get => datosSolicitante; set => SetProperty(ref datosSolicitante, value); }

        //Datos del Regente
        private AUD_DatosRegente datosRegente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRegente DatosRegente { get => datosRegente; set => SetProperty(ref datosRegente, value); }

        //Datos del Regente
        private AUD_DatosRepresentLegal datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRepresentLegal DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }

        private AUD_DatosCondicionesLocal datosCondicionesLocal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosCondicionesLocal DatosCondicionesLocal { get => datosCondicionesLocal; set => SetProperty(ref datosCondicionesLocal, value); }

        //Datos Conclusión de Inspección
        private AUD_DatosConclusiones datosConclusiones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosConclusiones DatosConclusiones { get => datosConclusiones; set => SetProperty(ref datosConclusiones, value); }

    }
}
