using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_CorrespondenciaContactoTB:SystemId
    {
        //Nombre a quien va dirigido
        private string nombre;
        [StringLength(300)]
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //Correo a quien va dirigido
        private string email;
        [StringLength(300)]
        [Required(ErrorMessage = "requerido")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
        public string Email { get => email; set => SetProperty(ref email, value); }

        private List<AUD_CorrespondenciaTB> lCorrespondencia;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<AUD_CorrespondenciaTB> LCorrespondencia { get => lCorrespondencia; set => SetProperty(ref lCorrespondencia, value); }
    }
}
