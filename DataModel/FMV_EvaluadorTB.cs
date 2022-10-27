using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_EvaluadorTB : SystemId
    {
        //num de licencia o aviso de operaciones
        private string nombreCompleto;
        [StringLength(500)]
        [Required(ErrorMessage = "RequiredField")]
        public string NombreCompleto { get => nombreCompleto; set => SetProperty(ref nombreCompleto, value); }

        private string telefono;
        [StringLength(250)]
        public string Telefono { get => telefono; set => SetProperty(ref telefono, value); }

        private string correo;
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "InvalidEmail")]
        [StringLength(250)]
        public string Correo { get => correo; set => SetProperty(ref correo, value); }

        private List<FMV_RamTB> lRam;
        public virtual List<FMV_RamTB> LRam { get => lRam; set => SetProperty(ref lRam, value); }

    }
}
