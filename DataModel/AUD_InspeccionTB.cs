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

        //numero de acta...
        private string numActa;
        public string NumActa { get => numActa; set => SetProperty(ref numActa, value); }
        private int intNumActa;
        public int IntNumActa { get => intNumActa; set => SetProperty(ref intNumActa, value); }

        //status del acta
        private enum_StatusInspecciones statusInspecciones;
        public enum_StatusInspecciones StatusInspecciones { get => statusInspecciones; set => SetProperty(ref statusInspecciones, value); }


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
        [Required(ErrorMessage = "RequiredField")]
        public long? EstablecimientoId { get => establecimientoId; set => SetProperty(ref establecimientoId, value); }
        private AUD_EstablecimientoTB? establecimiento;
        public virtual AUD_EstablecimientoTB? Establecimiento { get => establecimiento; set => SetProperty(ref establecimiento, value); }

        //ubicacion del establecimiento
        private string ubicacionEstablecimiento;
        [StringLength(500)]
        public string UbicacionEstablecimiento { get => ubicacionEstablecimiento; set => SetProperty(ref ubicacionEstablecimiento, value); }

        //num de licencia o aviso de operaciones
        private string telefonoEstablecimiento;
        [StringLength(250)]
        public string TelefonoEstablecimiento { get => telefonoEstablecimiento; set => SetProperty(ref telefonoEstablecimiento, value); }

        //num de licencia o aviso de operaciones
        private string licenseNumber;
        [StringLength(250)]
        public string LicenseNumber { get => licenseNumber; set => SetProperty(ref licenseNumber, value); }

        //aviso de operaciones
        private string avisoOperación;
        [StringLength(250)]
        public string AvisoOperación { get => avisoOperación; set => SetProperty(ref avisoOperación, value); }

        //representante legal
        private string repreLegal;
        [StringLength(500)]
        public string RepreLegal { get => repreLegal; set => SetProperty(ref repreLegal, value); }

        //representante legal identificacion
        private string repreLegalIdentificacion;
        [StringLength(250)]
        public string RepreLegalIdentificacion { get => repreLegalIdentificacion; set => SetProperty(ref repreLegalIdentificacion, value); }

        
        //participante Establecimiento
        private string particEstablecimiento;
        [StringLength(500)]
        public string ParticEstablecimiento { get => particEstablecimiento; set => SetProperty(ref particEstablecimiento, value); }

        //participante Establecimiento Cargo
        private string particEstablecimientoCargo;
        [StringLength(250)]
        public string ParticEstablecimientoCargo { get => particEstablecimientoCargo; set => SetProperty(ref particEstablecimientoCargo, value); }

        //participante Establecimiento Cargo
        private string particEstablecimientoEmail;
        [StringLength(250)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "InvalidEmail")]
        public string ParticEstablecimientoEmail { get => particEstablecimientoEmail; set => SetProperty(ref particEstablecimientoEmail, value); }

        //participante Establecimiento Identificacion
        private string particEstablecimientoCIP;
        [StringLength(250)]
        public string ParticEstablecimientoCIP { get => particEstablecimientoCIP; set => SetProperty(ref particEstablecimientoCIP, value); }


        ///////////////////////
        /// LOS FORMULARIOS

        //Rutina o Vigilancia de Farmacia
        private long? inspRutinaVigFarmaciaId;
        public long? InspRutinaVigFarmaciaId { get => inspRutinaVigFarmaciaId; set => SetProperty(ref inspRutinaVigFarmaciaId, value); }
        private AUD_InspRutinaVigFarmaciaTB? inspRutinaVigFarmacia;
        public virtual AUD_InspRutinaVigFarmaciaTB? InspRutinaVigFarmacia { get => inspRutinaVigFarmacia; set => SetProperty(ref inspRutinaVigFarmacia, value); }

        //Formulario de Apertura y Cambio de Ubicación de Agencia
        private long? inspAperCambUbicAgenId;
        public long? InspAperCambUbicAgenId { get => inspAperCambUbicAgenId; set => SetProperty(ref inspAperCambUbicAgenId, value); }
        private AUD_InspAperCambUbicAgenTB? inspAperCambUbicAgen;
        public virtual AUD_InspAperCambUbicAgenTB? InspAperCambUbicAgen { get => inspAperCambUbicAgen; set => SetProperty(ref inspAperCambUbicAgen, value); }

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

        //Formulario de Apertura Fabricante
        private long? inspAperFabricanteId;
        public long? InspAperFabricanteId { get => inspAperFabricanteId; set => SetProperty(ref inspAperFabricanteId, value); }
        private AUD_InspAperFabricanteTB? inspAperFabricante;
        public virtual AUD_InspAperFabricanteTB? InspAperFabricante { get => inspAperFabricante; set => SetProperty(ref inspAperFabricante, value); }


        //También debe permitir la opción de adjuntar evidencia como fotos o algún documento escaneado.
        private List<AttachmentTB> lAttachments;
        public virtual List<AttachmentTB> LAttachments { get => lAttachments; set => SetProperty(ref lAttachments, value); }

    }
}
