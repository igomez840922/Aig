using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_RamObservacionInfoNotifica:SystemId
    {
        // Incongruencia Conducta_No Disminuyó Dosis /Evolución.
        /*
            FÓRMULA: Si [conductaDosis]="" y [evoDosis]="" entonces [incongruenciaCondDosisEvo]=""
                     sino: Si [conductaDosis]="No disminuyó la dosis" entonces
                                Si [evoDosis]="Desapareció la reacción al disminuir la dosis" o [evoDosis]="Permanece la reacción al disminuir la dosis" entonces [incongruenciaCondDosisEvo]="Incongruente"
                                sino entonces [incongruenciaCondDosisEvo]=""
        */
        private string incongruenciaCondDosisEvo;
        [StringLength(250)]
        public string IncongruenciaCondDosisEvo { get => incongruenciaCondDosisEvo; set => SetProperty(ref incongruenciaCondDosisEvo, value); }

        // Incongruencia Conducta_Mantuvo la Terapia/Evolución
        /*
            FÓRMULA: Si [conductaTerapia]="" y [evoTerapia]="" entonces [incongruenciaCondTerapiaEvo]=""
                     sino: Si [conductaTerapia]="Mantuvo la terapia" entonces
                                Si [evoTerapia]="Desapareció la reacción al suspender el uso de medicamento sospechoso" o [evoTerapia]="Permanece la reacción al suspender el uso de medicamento sospechoso" entonces [incongruenciaCondTerapiaEvo]="Incongruente"
                                sino entonces [incongruenciaCondTerapiaEvo]=""
        */
        private string incongruenciaCondTerapiaEvo;
        [StringLength(250)]
        public string IncongruenciaCondTerapiaEvo { get => incongruenciaCondTerapiaEvo; set => SetProperty(ref incongruenciaCondTerapiaEvo, value); }

        // Incongruencia Conducta_Suspendió la terapia/ REEX
        /*
            FÓRMULA: Si [conductaTerapia]="" y [reexposicion]="" entonces [incongruenciaCondSuspTerapiaReex]=""
                     sino: Si [conductaTerapia]="Suspendió la terapia" y [reexposicion]="Sí" entonces [incongruenciaCondSuspTerapiaReex]="Incongruente"
                           sino entonces [incongruenciaCondSuspTerapiaReex]=""
        */
        private string incongruenciaCondSuspTerapiaReex;
        [StringLength(250)]
        public string IncongruenciaCondSuspTerapiaReex { get => incongruenciaCondSuspTerapiaReex; set => SetProperty(ref incongruenciaCondSuspTerapiaReex, value); }

        // Incongruencia Conducta_Mantuvo la terapia/ REEX
        /*
            FÓRMULA: Si [conductaTerapia]="" y [reexposicion]="" entonces [incongruenciaCondMantTerapiaReex]=""
                     sino: Si [conductaTerapia]="Mantuvo la terapia" y [reexposicion]="No" entonces [incongruenciaCondMantTerapiaReex]="Incongruente"
                           sino entonces [incongruenciaCondMantTerapiaReex]=""
        */
        private string incongruenciaCondMantTerapiaReex;
        [StringLength(250)]
        public string IncongruenciaCondMantTerapiaReex { get => incongruenciaCondMantTerapiaReex; set => SetProperty(ref incongruenciaCondMantTerapiaReex, value); }

        // Incongruencia Reexposición/Consecuencia de REEX
        /*
            FÓRMULA: Si [reexposicion]="" y [conReexposicion]="" entonces [incongruenciaConReex]=""
                     sino: Si [reexposicion]="No" entonces
                                Si [conReexposicion]="Reapareció la reacción luego de reexposición" o [conReexposicion]="No reapareció la reacción luego de reexposición" entonces [incongruenciaConReex]="Incongruente"
                                sino entonces [incongruenciaConReex]=""
        */
        private string incongruenciaConReex;
        [StringLength(250)]
        public string IncongruenciaConReex { get => incongruenciaConReex; set => SetProperty(ref incongruenciaConReex, value); }

    }
}
