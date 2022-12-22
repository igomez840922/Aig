using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_FfTB:SystemId
    {
        public FMV_FfTB()
        {
            FallaReportada = new FMV_FfFallaReportada();
            OtrasEspecificaciones = new FMV_FfOtrasEspecificaciones();
            Adjunto= new AttachmentData();
        }

        // Código del CNFV
        private string codCNFV;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string CodCNFV { get => codCNFV; set => SetProperty(ref codCNFV, value); }

        // Código externo
        private string codExt;
        [StringLength(250)]
        public string CodExt { get => codExt; set => SetProperty(ref codExt, value); }

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

        private string nombreComercial;
        [Required(ErrorMessage = "requerido")]
        [StringLength(300)]
        public string NombreComercial { get => nombreComercial; set => SetProperty(ref nombreComercial, value); }

        private string nombreDci;
        [Required(ErrorMessage = "requerido")]
        [StringLength(300)]
        public string NombreDci { get => nombreDci; set => SetProperty(ref nombreDci, value); }

        private string presentacion;
        [StringLength(500)]
        public string Presentacion { get => presentacion; set => SetProperty(ref presentacion, value); }
        
        private string atc;
        [StringLength(250)]
        public string ATC { get => atc; set => SetProperty(ref atc, value); }

        // ATC 2do Nivel
        /*
            FÓRMULA: Extraer de [act] los 3 primeros caracteres. Ej. act=A01AB22 => atc2=A01 
        */
        private string atc2;
        [StringLength(250)]
        public string Atc2 { get => atc2; set => SetProperty(ref atc2, value); }

        // Subgrupo terapéutico
        /*
            FÓRMULA: Si [atc2] existe en [atc] entonces subGrupoTer= subgrupo terapéutico
                     sino: subGrupoTer=""
        */
        private string subGrupoTerapeutico;
        [StringLength(500)]
        public string SubGrupoTerapeutico { get => subGrupoTerapeutico; set => SetProperty(ref subGrupoTerapeutico, value); }

        //private string fabricante;
        //[StringLength(500)]
        //public string Fabricante { get => fabricante; set => SetProperty(ref fabricante, value); }
        //Laboratorio
        private long? fabricanteId;
        public long? FabricanteId { get => fabricanteId; set => SetProperty(ref fabricanteId, value); }
        private LaboratorioTB? fabricant;
        public virtual LaboratorioTB? Fabricant { get => fabricant; set => SetProperty(ref fabricant, value); }

        private string lote;
        [StringLength(500)]
        public string Lote { get => lote; set => SetProperty(ref lote, value); }

        private string fechaExp;
        [StringLength(500)]
        public string FechaExp { get => fechaExp; set => SetProperty(ref fechaExp, value); }

        private string regSanitario;
        [StringLength(250)]
        public string RegSanitario { get => regSanitario; set => SetProperty(ref regSanitario, value); }

        // Tipo de notificador: Médico, Farmacéutico, Enfermera, Otro profesional de salud, Paciente, Insdustria Farmacéutica
        private enumFMV_RAMNotificationType tipoNotificador;
        public enumFMV_RAMNotificationType TipoNotificador { get => tipoNotificador; set => SetProperty(ref tipoNotificador, value); }

        //Tipo de Notificacion
        private enumFMV_RAMNotificationType tipoNotificacion;
        public enumFMV_RAMNotificationType TipoNotificacion { get => tipoNotificacion; set => SetProperty(ref tipoNotificacion, value); }

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

        // Notificador
        private string notificador;
        [StringLength(350)]
        [Required(ErrorMessage = "requerido")]
        public string Notificador { get => notificador; set => SetProperty(ref notificador, value); }

        // Incidendia de caso: Total=2. Inicial, Seguimiento
        private enumFMV_FfTipoIncidenciaCaso incidenciaCaso;
        public enumFMV_FfTipoIncidenciaCaso IncidenciaCaso { get => incidenciaCaso; set => SetProperty(ref incidenciaCaso, value); }


        //FALLAS REPORTADAS
        private FMV_FfFallaReportada fallaReportada;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_FfFallaReportada FallaReportada { get => fallaReportada; set => SetProperty(ref fallaReportada, value); }

        //OTRAS ESPECIFICACIONES
        private FMV_FfOtrasEspecificaciones otrasEspecificaciones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_FfOtrasEspecificaciones OtrasEspecificaciones { get => otrasEspecificaciones; set => SetProperty(ref otrasEspecificaciones, value); }


        //TAB CONCLUSIONES        
        // Grado
        
        // Fecha de trámite
        private DateTime? fechaTramite;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaTramite { get => fechaTramite; set => SetProperty(ref fechaTramite, value); }

        // Fecha de evaluación
        private DateTime? fechaEvalua;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEvalua { get => fechaEvalua; set => SetProperty(ref fechaEvalua, value); }

        // Estatus: Total=3. Por Tramitar, Tramitada, Evaluada
        private enumFMV_RAMStatus estatus;
        public enumFMV_RAMStatus Estatus { get => estatus; set => SetProperty(ref estatus, value); }

        // Resoluciones emitidas
        private string resolEmitidas;
        [StringLength(500)]
        public string ResolEmitidas { get => resolEmitidas; set => SetProperty(ref resolEmitidas, value); }

        // Observaciones
        private string observaciones;
        [StringLength(500)]
        public string Observaciones { get => observaciones; set => SetProperty(ref observaciones, value); }

        //Ficheros Adjuntos
        private AttachmentData adjunto;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AttachmentData Adjunto { get => adjunto; set => SetProperty(ref adjunto, value); }

    }
}
