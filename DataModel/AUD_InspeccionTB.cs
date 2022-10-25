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
        public long? EstablecimientoId { get => establecimientoId; set => SetProperty(ref establecimientoId, value); }
        private AUD_EstablecimientoTB? establecimiento;
        public virtual AUD_EstablecimientoTB? Establecimiento { get => establecimiento; set => SetProperty(ref establecimiento, value); }

        //ubicacion del establecimiento
        private string ubicacionEstablecimiento;
        [StringLength(500)]
        public string UbicacionEstablecimiento { get => ubicacionEstablecimiento; set => SetProperty(ref ubicacionEstablecimiento, value); }


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

        //participante del DNFD
        private string particDNFD;
        [StringLength(500)]
        public string ParticipantesDNFD { get => particDNFD; set => SetProperty(ref particDNFD, value); }

        //participante Establecimiento
        private string particEstablecimiento;
        [StringLength(500)]
        public string ParticEstablecimiento { get => particEstablecimiento; set => SetProperty(ref particEstablecimiento, value); }

        //participante Establecimiento Cargo
        private string particEstablecimientoCargo;
        [StringLength(250)]
        public string ParticEstablecimientoCargo { get => particEstablecimientoCargo; set => SetProperty(ref particEstablecimientoCargo, value); }

        //participante Establecimiento Identificacion
        private string particEstablecimientoCIP;
        [StringLength(250)]
        public string ParticEstablecimientoCIP { get => particEstablecimientoCIP; set => SetProperty(ref particEstablecimientoCIP, value); }

        //participante del DNFD Firma1
        private string firmaDNFD1;
        public string FirmaDNFD1 { get => firmaDNFD1; set => SetProperty(ref firmaDNFD1, value); }
       
        //participante del DNFD NumRegDNFD1
        private string numRegDNFD1;
        [StringLength(250)]
        public string NumRegDNFD1 { get => numRegDNFD1; set => SetProperty(ref numRegDNFD1, value); }

        //participante del DNFD Firma2
        private string firmaDNFD2;
        [StringLength(250)]
        public string FirmaDNFD2 { get => firmaDNFD2; set => SetProperty(ref firmaDNFD2, value); }

        //participante del DNFD NumRegDNFD2
        private string numRegDNFD2;
        public string NumRegDNFD2 { get => numRegDNFD2; set => SetProperty(ref numRegDNFD2, value); }

        //participante del Establecimiento Firma1
        private string firmaEstablec1;
        public string FirmaEstablec1 { get => firmaEstablec1; set => SetProperty(ref firmaEstablec1, value); }

        //participante del Establecimiento Firma2
        private string firmaEstablec2;
        public string FirmaEstablec2 { get => firmaEstablec2; set => SetProperty(ref firmaEstablec2, value); }

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

        

        //También debe permitir la opción de adjuntar evidencia como fotos o algún documento escaneado.
        private List<AttachmentTB> lAttachments;
        public virtual List<AttachmentTB> LAttachments { get => lAttachments; set => SetProperty(ref lAttachments, value); }

    }
}
