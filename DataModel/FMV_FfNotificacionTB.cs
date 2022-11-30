using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_FfNotificacionTB:SystemId
    {
        public FMV_FfNotificacionTB()
        {
            FallaReportada  = new FMV_FfNotificacionFallaReportada();
        }

        private long ffId;
        public long FfId { get => ffId; set => SetProperty(ref ffId, value); }
        private FMV_FfTB ff;
        public virtual FMV_FfTB Ff { get => ff; set => SetProperty(ref ff, value); }

        // Presentación
        private string presentacion;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string Presentacion { get => presentacion; set => SetProperty(ref presentacion, value); }

        // ATC
        private string atc;
        [StringLength(250)]
        public string Atc { get => atc; set => SetProperty(ref atc, value); }

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
        private string subGrupoTer;
        [StringLength(250)]
        public string SubGrupoTer { get => subGrupoTer; set => SetProperty(ref subGrupoTer, value); }

        // Fabricante
        private string fabricante;
        [StringLength(250)]
        public string Fabricante { get => fabricante; set => SetProperty(ref fabricante, value); }

        // Lote
        private string lote;
        [StringLength(250)]
        public string Lote { get => lote; set => SetProperty(ref lote, value); }

        // Expira
        private DateTime? expira;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Expira { get => expira; set => SetProperty(ref expira, value); }

        // Registro sanitario
        private string regSanitario;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string RegSanitario { get => regSanitario; set => SetProperty(ref regSanitario, value); }

        // Tipo de notificador: Médico, Farmacéutico, Enfermera, Otro profesional de salud, Paciente, Insdustria Farmacéutica
        private enumFMV_RAMNotificationType tipoNotificador;
        public enumFMV_RAMNotificationType TipoNotificador { get => tipoNotificador; set => SetProperty(ref tipoNotificador, value); }


        // Tipo de Organización/Institución: CSS, Minsa, Patronatos, Clinica_Hospital_Privados, Farmacias_Privadas, Industria Farmacéutica, No_hay_información, No_aplica
        private enumFMV_RAMOrganizationType tipoOrgInst;
        public enumFMV_RAMOrganizationType TipoOrgInst { get => tipoOrgInst; set => SetProperty(ref tipoOrgInst, value); }

        // Provincia/Región/Origen: Los valores de la lista varia según las filas
        private string provRegionOrigen;
        [StringLength(250)]
        public string ProvRegionOrigen { get => provRegionOrigen; set => SetProperty(ref provRegionOrigen, value); }

        // Nombre de Organización/Institución: Los valores de la lista varia según las filas 
        private string nombreOrgInst;
        [StringLength(250)]
        public string NombreOrgInst { get => nombreOrgInst; set => SetProperty(ref nombreOrgInst, value); }


        // Notificador
        private string notificador;
        [StringLength(350)]
        public string Notificador { get => notificador; set => SetProperty(ref notificador, value); }


        // Incidendia de caso: Total=2. Inicial, Seguimiento
        private enumFMV_FfTipoIncidenciaCaso incidenciaCaso;
        public enumFMV_FfTipoIncidenciaCaso IncidenciaCaso { get => incidenciaCaso; set => SetProperty(ref incidenciaCaso, value); }

        //FALLA REPORTADA
        private FMV_FfNotificacionFallaReportada fallaReportada;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_FfNotificacionFallaReportada FallaReportada { get => fallaReportada; set => SetProperty(ref fallaReportada, value); }


        //TAB CONCLUSIONES

        // Revisión de RS (Especificaciones, inserto, otro): Total=3. Realizado, Pendiente, No Requerido
        private enumFMV_FfAcciones revisionRs;
        public enumFMV_FfAcciones RevisionRs { get => revisionRs; set => SetProperty(ref revisionRs, value); }

        // Monitoreo: Total=3. Realizado, Pendiente, No Requerido
        private enumFMV_FfAcciones monitoreo;
        public enumFMV_FfAcciones Monitoreo { get => monitoreo; set => SetProperty(ref monitoreo, value); }

        // Notificacion al RFV: Total=3. Realizado, Pendiente, No Requerido
        private enumFMV_FfAcciones notificacionRFV;
        public enumFMV_FfAcciones NotificacionRFV { get => notificacionRFV; set => SetProperty(ref notificacionRFV, value); }

        // Control de calidad: Total=3. Solicitado, Pendiente, No requerido
        private enumFMV_FfAcciones controlCalidad;
        public enumFMV_FfAcciones ControlCalidad { get => controlCalidad; set => SetProperty(ref controlCalidad, value); }

        // Resultados de control de calidad: Total=4. Satisfactorios, No satisfactorios, En espera, No aplica
        private enumFMV_FfResultControlCal resultControlCalidad;
        public enumFMV_FfResultControlCal ResultControlCalidad { get => resultControlCalidad; set => SetProperty(ref resultControlCalidad, value); }

        // Investigación de campo: Total=3. Realizado, Pendiente, No Requerido
        private enumFMV_FfAcciones investCampo;
        public enumFMV_FfAcciones InvestCampo { get => investCampo; set => SetProperty(ref investCampo, value); }

        // Investigación al DAC: Total=3. Solicitado, Pendiente, No requerido
        private enumFMV_FfAcciones investDAC;
        public enumFMV_FfAcciones InvestDAC { get => investDAC; set => SetProperty(ref investDAC, value); }

        // Acciones regulatorias recomendadas: Total=3. Suspensión y retiro de lote(s), Suspensìón y registro sanitario, No requerido
        private enumFMV_FfRecomendAccRegulat accRegRecomendada;
        public enumFMV_FfRecomendAccRegulat AccRegRecomendada { get => accRegRecomendada; set => SetProperty(ref accRegRecomendada, value); }

        // Grado
        private int grado;
        public int Grado { get => grado; set => SetProperty(ref grado, value); }

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
    }
}
