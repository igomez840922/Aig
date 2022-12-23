using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    //Notificaciones de Reacciones Adversas a Medicamentos
    public class FMV_RamTB:SystemId
    {
        public FMV_RamTB()
        {
            //LNotificaciones = new List<FMV_RamNotificacionTB>();

            EvaluacionCalidadInfo = new FMV_RamEvaluacionCalidadInfo();
            EvaluacionCausalidad = new FMV_RamEvaluacionCausalidad();
            ObservacionInfoNotifica = new FMV_RamObservacionInfoNotifica();
            AccionesRegulatoria = new FMV_RamAccionesRegulatoria();
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

        private string farmacoSospechosoComercial;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string FarmacoSospechosoComercial { get => farmacoSospechosoComercial; set => SetProperty(ref farmacoSospechosoComercial, value); }

        private string farmacoSospechosoDci;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string FarmacoSospechosoDci { get => farmacoSospechosoDci; set => SetProperty(ref farmacoSospechosoDci, value); }

        private string atc;
        [StringLength(250)]
        public string Atc { get => atc; set => SetProperty(ref atc, value); }

        private string atc2;
        [StringLength(250)]
        public string Atc2 { get => atc2; set => SetProperty(ref atc2, value); }

        private string subGrupoTerapeutico;
        [StringLength(250)]
        public string SubGrupoTerapeutico { get => subGrupoTerapeutico; set => SetProperty(ref subGrupoTerapeutico, value); }

        private enumFMV_RAMType ramType;
        public enumFMV_RAMType RamType { get => ramType; set => SetProperty(ref ramType, value); }

        private enumFMV_RAMOrigenType ramOrigenType;
        public enumFMV_RAMOrigenType RamOrigenType { get => ramOrigenType; set => SetProperty(ref ramOrigenType, value); }

        private string codigoNotiFacedra;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string CodigoNotiFacedra { get => codigoNotiFacedra; set => SetProperty(ref codigoNotiFacedra, value); }

        private string idFacedra;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string IdFacedra { get => idFacedra; set => SetProperty(ref idFacedra, value); }

        private string codigoCNFV;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string CodigoCNFV { get => codigoCNFV; set => SetProperty(ref codigoCNFV, value); }

        // Valores Únicos - Código del CNFV. Total=2. 1, 0
        /*FÓRMULA: Si la cantidad de valores totales en toda la columna [codCNFV] es mayor que 1 entonces [valUnicos]=0 si no: [valUnicos]=1 */
        //Total
        //private int valUnico;
        //public int ValUnico { 
        //    get { return LNotificaciones?.Count > 1 ? 0 : 1; }
        //    set => SetProperty(ref valUnico, value); 
        //}

        ////PROCEDENCIA DE NOTIFICACION - Lista de Procedencias
        //private List<FMV_RamNotificacionTB> lNotificaciones;
        //public virtual List<FMV_RamNotificacionTB> LNotificaciones { get => lNotificaciones; set => SetProperty(ref lNotificaciones, value); }

        // Código Externo
        private string codExterno;
        //[Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string CodExterno { get => codExterno; set => SetProperty(ref codExterno, value); }

        //// Tipo de notificador: Médico, Farmacéutico, Enfermera, Otro profesional de salud, Paciente, Insdustria Farmacéutica
        //private enumFMV_RAMNotificationType tipoNotificador;
        //public enumFMV_RAMNotificationType TipoNotificador { get => tipoNotificador; set => SetProperty(ref tipoNotificador, value); }

        //// Tipo de Organización/Institución: CSS, Minsa, Patronatos, Clinica_Hospital_Privados, Farmacias_Privadas, Industria Farmacéutica, No_hay_información, No_aplica
        //private enumFMV_RAMOrganizationType tipoOrgInst;
        //public enumFMV_RAMOrganizationType TipoOrgInst { get => tipoOrgInst; set => SetProperty(ref tipoOrgInst, value); }

        //// Provincia/Región/Origen: Los valores de la lista varia según las filas
        //private string provRegionOrigen;
        //[StringLength(250)]
        //public string ProvRegionOrigen { get => provRegionOrigen; set => SetProperty(ref provRegionOrigen, value); }

        //// Nombre de Organización/Institución: Los valores de la lista varia según las filas 
        //private string nombreOrgInst;
        //[StringLength(250)]
        //public string NombreOrgInst { get => nombreOrgInst; set => SetProperty(ref nombreOrgInst, value); }

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

        // RAM
        private string ram;
        [StringLength(500)]
        public string Ram { get => ram; set => SetProperty(ref ram, value); }

        // Número de ingreso a Vigiflow
        private string numIngresoVigiflow;
        [StringLength(250)]
        public string NumIngresoVigiflow { get => numIngresoVigiflow; set => SetProperty(ref numIngresoVigiflow, value); }

        // Fecha de Evaluación
        private DateTime? fechaEvaluacion;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEvaluacion { get => fechaEvaluacion; set => SetProperty(ref fechaEvaluacion, value); }

        // Estatus. Total=4. Evaluada, Sin Evaluar, Tramitada, Sin Tramitar
        private enumFMV_RAMStatus estatus;
        public enumFMV_RAMStatus Estatus { get => estatus; set => SetProperty(ref estatus, value); }


        //EVALUACION DE LA CALIDAD DE LA INFORMACION
        private FMV_RamEvaluacionCalidadInfo evaluacionCalidadInfo;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_RamEvaluacionCalidadInfo EvaluacionCalidadInfo { get => evaluacionCalidadInfo; set => SetProperty(ref evaluacionCalidadInfo, value); }

        //EVALUACION DE CAUSALIDAD
        private FMV_RamEvaluacionCausalidad evaluacionCausalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_RamEvaluacionCausalidad EvaluacionCausalidad { get => evaluacionCausalidad; set => SetProperty(ref evaluacionCausalidad, value); }

        //OBSERVACIONES SOBRE LA INFORMACION DE LA NOTIFICACION
        private FMV_RamObservacionInfoNotifica observacionInfoNotifica;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_RamObservacionInfoNotifica ObservacionInfoNotifica { get => observacionInfoNotifica; set => SetProperty(ref observacionInfoNotifica, value); }

        //ACCIONES REGULATORIAS
        private FMV_RamAccionesRegulatoria accionesRegulatoria;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_RamAccionesRegulatoria AccionesRegulatoria { get => accionesRegulatoria; set => SetProperty(ref accionesRegulatoria, value); }

    }
}
