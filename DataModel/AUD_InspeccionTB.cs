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
    //Tabla padre de las inspecciones para generar las actas

    public  class AUD_InspeccionTB:SystemId
    {
        public AUD_InspeccionTB()
        {
            FechaInicio=DateTime.Now;
        }
        /// <summary>
        /// /////////Generalidades de la Farmacia y Solicitante
        /// </summary>

        //numero de acta ... debe ser Autogenerado Secuencial
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string NumActa { get { return Id.ToString("000000"); } set { }  }

        //tipo de acta ... va a determinar el formulario a mostrar
        private enumAUD_TipoActa tipoActa;
        public enumAUD_TipoActa TipoActa { get => tipoActa; set => SetProperty(ref tipoActa, value); }

        //fecha y Hora de inicio del acta
        private DateTime fechaInicio;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime FechaInicio { get => fechaInicio; set => SetProperty(ref fechaInicio, value); }

        ////////////////
        ///
        //---- Estos los tenemos en la relación de establecimiento ---
        //Tipo de establecimiento
        //Nombre del Establecimiento 

        //Establecimiento
        private long? establecimientoId;
        public long? EstablecimientoId { get => establecimientoId; set => SetProperty(ref establecimientoId, value); }
        private AUD_EstablecimientoTB? establecimiento;
        public virtual AUD_EstablecimientoTB? Establecimiento { get => establecimiento; set => SetProperty(ref establecimiento, value); }
                
        ///////////////////////
        /// LOS FORMULARIOS

        //Formulario de Apertura y Cambio de Ubicación de Farmacias
        private long? inspAperCambUbicFarmId;
        public long? InspAperCambUbicFarmId { get => inspAperCambUbicFarmId; set => SetProperty(ref inspAperCambUbicFarmId, value); }
        private AUD_InspAperCambUbicFarmTB? inspAperCambUbicFarm;
        public virtual AUD_InspAperCambUbicFarmTB? InspAperCambUbicFarm { get => inspAperCambUbicFarm; set => SetProperty(ref inspAperCambUbicFarm, value); }


        //Formulario de Retiro y Retencion de Productos
        private long? inspRetiroRetencionId;
        public long? InspRetiroRetencionId { get => inspRetiroRetencionId; set => SetProperty(ref inspRetiroRetencionId, value); }
        private AUD_InspRetiroRetencionTB? inspRetiroRetencion;
        public virtual AUD_InspRetiroRetencionTB? InspRetiroRetencion { get => inspRetiroRetencion; set => SetProperty(ref inspRetiroRetencion, value); }


    }
}
