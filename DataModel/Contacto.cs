using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Contacto:SystemId
    {
        //nombre completo de contacto
        private string nombre;
        [StringLength(350)]
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //Descripcion de contacto
        private string descripcion;
        [StringLength(400)]
        public string Descripcion { get => descripcion; set => SetProperty(ref descripcion, value); }

        //telefono de contacto
        private string telefono;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string Telefono { get => telefono; set => SetProperty(ref telefono, value); }

        //Email de contacto
        private string email;
        [StringLength(250)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
        public string Email { get => email; set => SetProperty(ref email, value); }

    }
}
