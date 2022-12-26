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
        [Required(ErrorMessage = "requerido")]
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
        private string avisoOperacion;
        [StringLength(250)]
        public string AvisoOperacion { get => avisoOperacion; set => SetProperty(ref avisoOperacion, value); }

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
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
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

        //Formulario de Investigaciones
        private long? inspInvestigacionId;
        public long? InspInvestigacionId { get => inspInvestigacionId; set => SetProperty(ref inspInvestigacionId, value); }
        private AUD_InspInvestigacionTB? inspInvestigacion;
        public virtual AUD_InspInvestigacionTB? InspInvestigacion { get => inspInvestigacion; set => SetProperty(ref inspInvestigacion, value); }

        //Gui BPM Fabribacante Cosmetico Medicamento
        private long? inspGuiBPMFabCosmeticoMedId;
        public long? InspGuiBPMFabCosmeticoMedId { get => inspGuiBPMFabCosmeticoMedId; set => SetProperty(ref inspGuiBPMFabCosmeticoMedId, value); }
        private AUD_InspGuiBPMFabCosmeticoMedTB? inspGuiBPMFabCosmeticoMed;
        public virtual AUD_InspGuiBPMFabCosmeticoMedTB? InspGuiBPMFabCosmeticoMed { get => inspGuiBPMFabCosmeticoMed; set => SetProperty(ref inspGuiBPMFabCosmeticoMed, value); }

        //Apertura Cosméticos Artesanales
        private long? inspAperturaCosmetArtesanalId;
        public long? InspAperturaCosmetArtesanalId { get => inspAperturaCosmetArtesanalId; set => SetProperty(ref inspAperturaCosmetArtesanalId, value); }
        private AUD_InspAperturaCosmetArtesanalTB? inspAperturaCosmetArtesanal;
        public virtual AUD_InspAperturaCosmetArtesanalTB? InspAperturaCosmetArtesanal { get => inspAperturaCosmetArtesanal; set => SetProperty(ref inspAperturaCosmetArtesanal, value); }

        //Fabricantes Naturales medicinales
        private long? inspGuiBPMFabNatMedicinaId;
        public long? InspGuiBPMFabNatMedicinaId { get => inspGuiBPMFabNatMedicinaId; set => SetProperty(ref inspGuiBPMFabNatMedicinaId, value); }
        private AUD_InspGuiBPMFabNatMedicinaTB? inspGuiBPMFabNatMedicina;
        public virtual AUD_InspGuiBPMFabNatMedicinaTB? InspGuiBPMFabNatMedicina { get => inspGuiBPMFabNatMedicina; set => SetProperty(ref inspGuiBPMFabNatMedicina, value); }

        //Rutina o Vigilancia de Agencia
        private long? inspRutinaVigAgenciaId;
        public long? InspRutinaVigAgenciaId { get => inspRutinaVigAgenciaId; set => SetProperty(ref inspRutinaVigAgenciaId, value); }
        private AUD_InspRutinaVigAgenciaTB? inspRutinaVigAgencia;
        public virtual AUD_InspRutinaVigAgenciaTB? InspRutinaVigAgencia { get => inspRutinaVigAgencia; set => SetProperty(ref inspRutinaVigAgencia, value); }

        //Cierre de Operaciones
        private long? inspCierreOperacionId;
        public long? InspCierreOperacionId { get => inspCierreOperacionId; set => SetProperty(ref inspCierreOperacionId, value); }
        private AUD_InspCierreOperacionTB? inspCierreOperacion;
        public virtual AUD_InspCierreOperacionTB? InspCierreOperacion { get => inspCierreOperacion; set => SetProperty(ref inspCierreOperacion, value); }

        //Disposicion Final de Productos
        private long? inspDisposicionFinalId;
        public long? InspDisposicionFinalId { get => inspDisposicionFinalId; set => SetProperty(ref inspDisposicionFinalId, value); }
        private AUD_InspDisposicionFinalTB? inspDisposicionFinal;
        public virtual AUD_InspDisposicionFinalTB? InspDisposicionFinal { get => inspDisposicionFinal; set => SetProperty(ref inspDisposicionFinal, value); }


        //Disposicion Final de Productos
        private long? inspGuiaBPMFabricanteMedId;
        public long? InspGuiaBPMFabricanteMedId { get => inspGuiaBPMFabricanteMedId; set => SetProperty(ref inspGuiaBPMFabricanteMedId, value); }
        private AUD_InspGuiaBPMFabricanteMedTB? inspGuiaBPMFabricanteMed;
        public virtual AUD_InspGuiaBPMFabricanteMedTB? InspGuiaBPMFabricanteMed { get => inspGuiaBPMFabricanteMed; set => SetProperty(ref inspGuiaBPMFabricanteMed, value); }

        //Disposicion Final de Productos
        private long? inspGuiaBPMLabAcondicionadorId;
        public long? InspGuiaBPMLabAcondicionadorId { get => inspGuiaBPMLabAcondicionadorId; set => SetProperty(ref inspGuiaBPMLabAcondicionadorId, value); }
        private AUD_InspGuiaBPMLabAcondicionadorTB? inspGuiaBPMLabAcondicionador;
        public virtual AUD_InspGuiaBPMLabAcondicionadorTB? InspGuiaBPMLabAcondicionador { get => inspGuiaBPMLabAcondicionador; set => SetProperty(ref inspGuiaBPMLabAcondicionador, value); }


        //GUIA DE BUENAS PRACTICAS
        private long? inspGuiaBPM_BpaId;
        public long? InspGuiaBPM_BpaId { get => inspGuiaBPM_BpaId; set => SetProperty(ref inspGuiaBPM_BpaId, value); }
        private AUD_InspGuiaBPM_BpaTB? inspGuiaBPM_Bpa;
        public virtual AUD_InspGuiaBPM_BpaTB? InspGuiaBPM_Bpa { get => inspGuiaBPM_Bpa; set => SetProperty(ref inspGuiaBPM_Bpa, value); }


        //También debe permitir la opción de adjuntar evidencia como fotos o algún documento escaneado.
        private List<AttachmentTB> lAttachments;
        public virtual List<AttachmentTB> LAttachments { get => lAttachments; set => SetProperty(ref lAttachments, value); }

    }
}
