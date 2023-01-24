using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_FfOtrasEspecificaciones:SystemId
    {
        // Número de Ingreso a Vigiflow
        private string numIngresoVigiflow;
        public string NumIngresoVigiflow { get => numIngresoVigiflow; set => SetProperty(ref numIngresoVigiflow, value); }

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

        //private string grado;
        //[StringLength(250)]
        //public string Grado { get => grado; set => SetProperty(ref grado, value); }

    }
}
