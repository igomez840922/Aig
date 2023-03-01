﻿using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_FtTB : SystemId
    {
        public FMV_FtTB()
        {
            OtrasEspecificaciones = new FMV_FfOtrasEspecificaciones();
            DatosPaciente = new FMV_FtDatosPaciente();
            EvaluacionCausalidad = new FMV_FtEvaluacionCausalidad();
            Concominantes = new FMV_RamConcominantes();
            Adjunto = new AttachmentData();
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

        // Año
        private int year;
        public int Year { get => year; set => SetProperty(ref year, value); }

        // Fecha de recibido (CNFV)
        private DateTime? fechaRecibidoCNFV;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRecibidoCNFV { get => fechaRecibidoCNFV; set { SetProperty(ref fechaRecibidoCNFV, value); Year = value.HasValue ? value.Value.Year : 0; } }

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

        private string concentracion;
        [StringLength(250)]
        public string Concentracion { get => concentracion; set => SetProperty(ref concentracion, value); }

        private string formaFarmaceutica;
        [StringLength(250)]
        public string FormaFarmaceutica { get => formaFarmaceutica; set => SetProperty(ref formaFarmaceutica, value); }

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
               
        // Fecha de Expiracion
        private DateTime? fechaExpira;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaExpira { get => fechaExpira; set => SetProperty(ref fechaExpira, value); }

        private string regSanitario;
        [StringLength(250)]
        public string RegSanitario { get => regSanitario; set => SetProperty(ref regSanitario, value); }

        //// Tipo de notificador: Médico, Farmacéutico, Enfermera, Otro profesional de salud, Paciente, Insdustria Farmacéutica
        //private enumFMV_RAMNotificationType tipoNotificador;
        //public enumFMV_RAMNotificationType TipoNotificador { get => tipoNotificador; set => SetProperty(ref tipoNotificador, value); }

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


        //TAB OTRAS ESPECIFICACIONES
        private FMV_FfOtrasEspecificaciones otrasEspecificaciones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_FfOtrasEspecificaciones OtrasEspecificaciones { get => otrasEspecificaciones; set => SetProperty(ref otrasEspecificaciones, value); }


        //Rutina o Vigilancia de Agencia
        private long? inspRutinaVigAgenciaId;
        public long? InspRutinaVigAgenciaId { get => inspRutinaVigAgenciaId; set => SetProperty(ref inspRutinaVigAgenciaId, value); }
        private AUD_InspRutinaVigAgenciaTB? inspRutinaVigAgencia;
        public virtual AUD_InspRutinaVigAgenciaTB? InspRutinaVigAgencia { get => inspRutinaVigAgencia; set => SetProperty(ref inspRutinaVigAgencia, value); }


        //TAB DATOS DEL PACIENTE
        private long? datosPacienteId;
        public long? DatosPacienteId { get => datosPacienteId; set => SetProperty(ref datosPacienteId, value); }
        private FMV_FtDatosPaciente datosPaciente;
        //[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual FMV_FtDatosPaciente DatosPaciente { get => datosPaciente; set => SetProperty(ref datosPaciente, value); }

        private long? evaluacionCausalidadId;
        public long? EvaluacionCausalidadId { get => evaluacionCausalidadId; set => SetProperty(ref evaluacionCausalidadId, value); }
        //TAB EVALUACION DE CAUSALIDAD
        private FMV_FtEvaluacionCausalidad evaluacionCausalidad;
        //[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual FMV_FtEvaluacionCausalidad EvaluacionCausalidad { get => evaluacionCausalidad; set => SetProperty(ref evaluacionCausalidad, value); }
               

        // Grado
        private string grado;
        [StringLength(250)]
        public string Grado { get => grado; set => SetProperty(ref grado, value); }

        //TAB CONCLUSIONES
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


        //FARMACOS CONCOMINANTES
        private FMV_RamConcominantes concominantes;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_RamConcominantes Concominantes { get => concominantes; set => SetProperty(ref concominantes, value); }


        //Ficheros Adjuntos
        private AttachmentData adjunto;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AttachmentData Adjunto { get => adjunto; set => SetProperty(ref adjunto, value); }

        //Falla Terapeutica
        private enumOpcionSiNoOnly reportaFallaTerapeutica;
        public enumOpcionSiNoOnly ReportaFallaTerapeutica { get => reportaFallaTerapeutica; set => SetProperty(ref reportaFallaTerapeutica, value); }


        // detalla de falla
        private string detalleFalla;
        public string DetalleFalla { get => detalleFalla; set => SetProperty(ref detalleFalla, value); }

    }
}
