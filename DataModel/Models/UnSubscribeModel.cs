using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class UnSubscribeModel:SystemId
    {
        //correo principal
        private string correo;
        [StringLength(300)]
        [Required(ErrorMessage = "requerido")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
        public string Correo { get => correo; set => SetProperty(ref correo, value); }

    }
}
