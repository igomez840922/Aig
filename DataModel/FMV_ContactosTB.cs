using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_ContactosTB:SystemId
    {
        //Nombre
        private string nombre;
        [StringLength(300)]
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //Cargo
        private string cargo;
        [StringLength(300)]
        //[Required(ErrorMessage = "requerido")]
        public string Cargo { get => cargo; set => SetProperty(ref cargo, value); }

        //profesion
        private string profesion;
        [StringLength(300)]
        public string Profesion { get => profesion; set => SetProperty(ref profesion, value); }

        //instlacion / region
        private string instalacion;
        [StringLength(300)]
        [Required(ErrorMessage = "requerido")]
        public string Instalacion { get => instalacion; set => SetProperty(ref instalacion, value); }

        //telefono
        private string telefono;
        [StringLength(300)]
        public string Telefono { get => telefono; set => SetProperty(ref telefono, value); }

        //correo principal
        private string correo;
        [StringLength(300)]
        [Required(ErrorMessage = "requerido")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
        public string Correo { get => correo; set => SetProperty(ref correo, value); }

        //correo principal
        private string correoSec;
        [StringLength(300)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
        public string CorreoSec { get => correoSec; set => SetProperty(ref correoSec, value); }

        private bool isManual;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public bool IsManual { get => isManual; set => SetProperty(ref isManual, value); }


    }
}
