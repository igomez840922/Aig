using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_RamNotificacionTB : SystemId
    {       
        public FMV_RamNotificacionTB()
        {
            EvaluacionCalidadInfo = new FMV_RamEvaluacionCalidadInfo();
            EvaluacionCausalidad = new FMV_RamEvaluacionCausalidad();
            ObservacionInfoNotifica= new FMV_RamObservacionInfoNotifica();
            AccionesRegulatoria = new FMV_RamAccionesRegulatoria();
        }

        private long ramId;
        public long RamId { get => ramId; set => SetProperty(ref ramId, value); }
        private FMV_RamTB ram;
        public virtual FMV_RamTB Ram { get => ram; set => SetProperty(ref ram, value); }


        // Código Externo
        private string codExterno;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string CodExterno { get => codExterno; set => SetProperty(ref codExterno, value); }

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





        // Número de ingreso a Vigiflow
        private string numIngresoVigiflow;
        [Required(ErrorMessage = "requerido")]
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
