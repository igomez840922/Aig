using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_Ram2TB : SystemId
    {
        public FMV_Ram2TB() {
            LFarmacos = new List<FMV_RamFarmacoTB>();
            ObservacionInfoNotifica= new FMV_RamObservacionInfoNotifica();
            AccionesRegulatoria = new FMV_RamAccionesRegulatoria();
            Concominantes = new FMV_RamConcominantes();
            Adjunto=new AttachmentData();
        }

        // Fecha de recibido (CNFV)
        private DateTime? fechaRecibidoCNFV;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRecibidoCNFV { get => fechaRecibidoCNFV; set => SetProperty(ref fechaRecibidoCNFV, value); }

        // Fecha de entrega al evaluador
        private DateTime? fechaEntregaEva;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEntregaEva { get => fechaEntregaEva; set => SetProperty(ref fechaEntregaEva, value); }

        // Evaluador
        private long? evaluadorId;
        public long? EvaluadorId { get => evaluadorId; set => SetProperty(ref evaluadorId, value); }
        private PersonalTrabajadorTB? evaluador;
        public virtual PersonalTrabajadorTB? Evaluador { get => evaluador; set => SetProperty(ref evaluador, value); }

        //Si hay ram
        private enumFMV_RAMType ramType;
        public enumFMV_RAMType RamType { get => ramType; set => SetProperty(ref ramType, value); }

        //Origen de la Ram
        private enumFMV_RAMOrigenType ramOrigenType;
        public enumFMV_RAMOrigenType RamOrigenType { get => ramOrigenType; set => SetProperty(ref ramOrigenType, value); }

        private string codigoNotiFacedra;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string CodigoNotiFacedra { get => codigoNotiFacedra; set => SetProperty(ref codigoNotiFacedra, value); }

        private string idFacedra;
        //[Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string IdFacedra { get => idFacedra; set => SetProperty(ref idFacedra, value); }

        private string codigoCNFV;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string CodigoCNFV { get => codigoCNFV; set => SetProperty(ref codigoCNFV, value); }
                
        // Código Externo
        private string codExterno;
        //[Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string CodExterno { get => codExterno; set => SetProperty(ref codExterno, value); }


        private string grado;
        [StringLength(250)]
        public string Grado { get => grado; set => SetProperty(ref grado, value); }

        /////////////////////////////
        ///PROCEDENCIA DE LA NOTIFICACION
        
        //Tipo de Notificacion
        private enumFMV_RAMNotificationType tipoNotificacion;
        public enumFMV_RAMNotificationType TipoNotificacion { get => tipoNotificacion; set => SetProperty(ref tipoNotificacion, value); }

        //Tipo de Notificacion
        private string tipoNotificacionDesc;
        [StringLength(300)]
        public string TipoNotificacionDesc { get => tipoNotificacionDesc; set => SetProperty(ref tipoNotificacionDesc, value); }


        private long? tipoInstitucionId;
        public long? TipoInstitucionId { get => tipoInstitucionId; set => SetProperty(ref tipoInstitucionId, value); }
        private TipoInstitucionTB? tipoInstitucion;
        public virtual TipoInstitucionTB? TipoInstitucion { get => tipoInstitucion; set => SetProperty(ref tipoInstitucion, value); }

        private long? provinciaId;
        public long? ProvinciaId { get => provinciaId; set => SetProperty(ref provinciaId, value); }
        private ProvinciaTB? provincia;
        public virtual ProvinciaTB? Provincia { get => provincia; set => SetProperty(ref provincia, value); }

        private long? institucionId;
        public long? InstitucionId { get => institucionId; set => SetProperty(ref institucionId, value); }
        private InstitucionDestinoTB? institucionDestino;
        public virtual InstitucionDestinoTB? InstitucionDestino { get => institucionDestino; set => SetProperty(ref institucionDestino, value); }

        /////////////////////////////
        ///DATOS DEL PACIENTE

        // Iniciales del Paciente
        private string inicialesPaciente;
        [StringLength(250)]
        public string InicialesPaciente { get => inicialesPaciente; set => SetProperty(ref inicialesPaciente, value); }

        // Iniciales del Paciente
        private string cedula;
        [StringLength(250)]
        public string Cedula { get => cedula; set => SetProperty(ref cedula, value); }

        // Sexo. Total=3. M, F, null
        private enumSexo sexo;
        public enumSexo Sexo { get => sexo; set => SetProperty(ref sexo, value); }

        // Edad (Años). null
        private string edad;
        [StringLength(100)]
        public string Edad { get => edad; set => SetProperty(ref edad, value); }

        // Historia Clínica, null
        private string histClinica;
        [StringLength(500)]
        public string HistClinica { get => histClinica; set => SetProperty(ref histClinica, value); }

        // Otros Diagnósticos. null
        private string otrosDiagnosticos;
        [StringLength(500)]
        public string OtrosDiagnosticos { get => otrosDiagnosticos; set => SetProperty(ref otrosDiagnosticos, value); }


        /////////////////////////////
        ///FARMACOS SOSPECHOSOS

        private List<FMV_RamFarmacoTB> lFarmacos;
        public virtual List<FMV_RamFarmacoTB> LFarmacos { get => lFarmacos; set => SetProperty(ref lFarmacos, value); }

        ///////////////////////////
        ///// DATOS DEL LABORATORIO
        
        //Datos de Laboratorio, null
        private string datosLab;
        [StringLength(500)]
        public string DatosLab { get => datosLab; set => SetProperty(ref datosLab, value); }


        //OBSERVACIONES SOBRE LA INFORMACION DE LA NOTIFICACION
        private FMV_RamObservacionInfoNotifica observacionInfoNotifica;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_RamObservacionInfoNotifica ObservacionInfoNotifica { get => observacionInfoNotifica; set => SetProperty(ref observacionInfoNotifica, value); }

        //ACCIONES REGULATORIAS
        private FMV_RamAccionesRegulatoria accionesRegulatoria;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_RamAccionesRegulatoria AccionesRegulatoria { get => accionesRegulatoria; set => SetProperty(ref accionesRegulatoria, value); }


        //FARMACOS CONCOMINANTES
        private FMV_RamConcominantes concominantes;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_RamConcominantes Concominantes { get => concominantes; set => SetProperty(ref concominantes, value); }

        //Ficheros Adjuntos
        private AttachmentData adjunto;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AttachmentData Adjunto { get => adjunto; set => SetProperty(ref adjunto, value); }

        ////////////
        ///

        // Fecha de Evaluación
        private DateTime? fechaEvaluacion;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEvaluacion { get => fechaEvaluacion; set => SetProperty(ref fechaEvaluacion, value); }

        // Estatus. Total=4. Evaluada, Sin Evaluar, Tramitada, Sin Tramitar
        private enumFMV_RAMStatus estatus;
        public enumFMV_RAMStatus Estatus { get => estatus; set => SetProperty(ref estatus, value); }

    }
}
