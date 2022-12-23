using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_RamEvaluacionCalidadInfo:SystemId
    {


        // Fecha de Tratamiento. null
        private DateTime? fechaTratamiento;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaTratamiento { get => fechaTratamiento; set => SetProperty(ref fechaTratamiento, value); }

        // Fecha de RAM, null
        private DateTime? fechaRam;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRam { get => fechaRam; set => SetProperty(ref fechaRam, value); }

        // Desenlace. Total=7. Recuperado con secuelas, Recuperado sin secuelas, En recuperación, No recuperado, Desconocido, Muerte, null
        private enumFMV_RAMDesenlace desenlace;
        public enumFMV_RAMDesenlace Desenlace { get => desenlace; set => SetProperty(ref desenlace, value); }

        // Indicación. null
        private string indicacion;
        [StringLength(250)]
        public string Indicacion { get => indicacion; set => SetProperty(ref indicacion, value); }

        // Conducta sobre Dosis. Total=3. Disminuyó la dosis, No disminuyó la dosis, null
        private enumFMV_RAMConductaDosis conductaDosis;
        public enumFMV_RAMConductaDosis ConductaDosis { get => conductaDosis; set => SetProperty(ref conductaDosis, value); }

        // Conducta sobre Terapia. Total=3. Suspendió la terapia, Mantuvo la terapia, null
        private enumFMV_RAMConductaTerapia conductaTerapia;
        public enumFMV_RAMConductaTerapia ConductaTerapia { get => conductaTerapia; set => SetProperty(ref conductaTerapia, value); }

        // Evolución sobre Dosis. Total=3. Desapareció la reacción al diminuir la dosis, Permanece la reacción al disminuir la dosis, null
        private enumFMV_RAMEvolucionDosis evoDosis;
        public enumFMV_RAMEvolucionDosis EvoDosis { get => evoDosis; set => SetProperty(ref evoDosis, value); }

        // Evolución sobre Terapia. Total=3. Desapareció la reacción al suspender el uso del medicamento sospechoso, Permanece la reacción al suspender el uso del medicamento sospechoso, null
        private enumFMV_RAMEvolucionTerapia evoTerapia;
        public enumFMV_RAMEvolucionTerapia EvoTerapia { get => evoTerapia; set => SetProperty(ref evoTerapia, value); }

        // Otros Diagnósticos. null
        private string otrosDiagnosticos;
        [StringLength(400)]
        public string OtrosDiagnosticos { get => otrosDiagnosticos; set => SetProperty(ref otrosDiagnosticos, value); }


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

        // Datos de Laboratorio, null
        private string datosLab;
        [StringLength(500)]
        public string DatosLab { get => datosLab; set => SetProperty(ref datosLab, value); }

        // Reexposición. Total=3. Si, No, null
        private enumOpcionSiNo reexposicion;
        public enumOpcionSiNo Reexposicion { get => reexposicion; set => SetProperty(ref reexposicion, value); }

        // Consecuencia de Reexposición. Total=3. Reapareció la reacción luego de reexposición, No reaparece la reacción luego de reexposición, null
        private enumFMV_RAMConsecuenciaReexposicion conReexposicion;
        public enumFMV_RAMConsecuenciaReexposicion ConReexposicion { get => conReexposicion; set => SetProperty(ref conReexposicion, value); }

        // RAM con una sola Dosis. Total=3. Si, No, null
        private enumOpcionSiNo ramUnaDosis;
        public enumOpcionSiNo RamUnaDosis { get => ramUnaDosis; set => SetProperty(ref ramUnaDosis, value); }


        // Grado 0
        /* FÓRMULA: Si [farSosDCI]="", [hayRam]="", [fechaTratamiento]="" y [hayRam]="" entonces grado0=""
                     sino: Si [farSosDCI]!="", [hayRam]="Sí hay RAM" entonces
                                Si [fechaTratamiento]="" o [hayRam]="" entonces grado0=Grado 0
                                sino: grado0=""
        */
        private string grado;
        [StringLength(250)]
        public string Grado { get => grado; set => SetProperty(ref grado, value); }

    }
}
