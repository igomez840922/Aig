using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class AUD_InspAperCambUbicFarmTB : SystemId
	{       
       
        private AUD_InspeccionTB inspeccion;

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }


        //Datos del Solicitante
        private AUD_DatosSolicitante datosSolicitante;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosSolicitante DatosSolicitante { get => datosSolicitante; set => SetProperty(ref datosSolicitante, value); }

        //Datos del Regente
        private AUD_DatosRegente datosRegente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRegente DatosRegente { get => datosRegente; set => SetProperty(ref datosRegente, value); }

        //Datos Estructura Organizacional
        private AUD_DatosEstructuraOrganizacional datosEstructuraOrganizacional;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosEstructuraOrganizacional DatosEstructuraOrganizacional { get => datosEstructuraOrganizacional; set => SetProperty(ref datosEstructuraOrganizacional, value); }

        //Datos Infraestructura
        private AUD_DatosInfraEstructura datosInfraEstructura;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosInfraEstructura DatosInfraEstructura { get => datosInfraEstructura; set => SetProperty(ref datosInfraEstructura, value); }


        //Datos Area Física
        private AUD_DatosAreaFisicas datosAreaFisica;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAreaFisicas DatosAreaFisica { get => datosAreaFisica; set => SetProperty(ref datosAreaFisica, value); }

        //Datos Preguntas Genericas
        private AUD_DatosPreguntasGenericas datosPreguntasGenericas;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosPreguntasGenericas DatosPreguntasGenericas { get => datosPreguntasGenericas; set => SetProperty(ref datosPreguntasGenericas, value); }

        //Datos Area Productos Controlados
        private AUD_DatosAreaProductosControlados datosAreaProductosControlados;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAreaProductosControlados DatosAreaProductosControlados { get => datosAreaProductosControlados; set => SetProperty(ref datosAreaProductosControlados, value); }

        //Datos Area Almacenamiento
        private AUD_DatosAreaAlmacenamiento datosAreaAlmacenamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosAreaAlmacenamiento DatosAreaAlmacenamiento { get => datosAreaAlmacenamiento; set => SetProperty(ref datosAreaAlmacenamiento, value); }

        
    }
}
