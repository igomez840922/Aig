using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_Farmaceutico:SystemId
    {
        private string numReg;
        public string NumReg { get => numReg; set => SetProperty(ref numReg, value); }

        private string nombreCompleto;
        [Required(ErrorMessage = "requerido")]
        public string NombreCompleto { get => nombreCompleto; set => SetProperty(ref nombreCompleto, value); }

        private string provincia;
        public string Provincia { get => provincia; set => SetProperty(ref provincia, value); }

        private string distrito;
        public string Distrito { get => distrito; set => SetProperty(ref distrito, value); }

        private string corregimiento;
        public string Corregimiento { get => corregimiento; set => SetProperty(ref corregimiento, value); }

        private string direccion;
        public string Direccion { get => direccion; set => SetProperty(ref direccion, value); }

        private string telefono;
        public string Telefono { get => telefono; set => SetProperty(ref telefono, value); }

        private string folio;
        public string Folio { get => folio; set => SetProperty(ref folio, value); }

        private string cedula;
        public string Cedula { get => cedula; set => SetProperty(ref cedula, value); }

        private string sector;
        public string Sector { get => sector; set => SetProperty(ref sector, value); }

        private string telefonoTrabajo;
        public string TelefonoTrabajo { get => telefonoTrabajo; set => SetProperty(ref telefonoTrabajo, value); }
        
        private string direccionTrabajo;
        public string DireccionTrabajo { get => direccionTrabajo; set => SetProperty(ref direccionTrabajo, value); }


        private string horario;
        public string Horario { get => horario; set => SetProperty(ref horario, value); }

        private string observaciones;
        public string Observaciones { get => observaciones; set => SetProperty(ref observaciones, value); }

        private string historial;
        public string Historial { get => historial; set => SetProperty(ref historial, value); }

        private bool visitadorMed;
        public bool VisitadorMed { get => visitadorMed; set => SetProperty(ref visitadorMed, value); }

    }
}
