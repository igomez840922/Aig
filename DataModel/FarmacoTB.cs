using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{    
    public class FarmacoTB : SystemId
    {
        //nombre
        private string nombreDCI;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string NombreDCI { get => nombreDCI; set => SetProperty(ref nombreDCI, value); }

        //nombre
        private string nombreComercial;
        [StringLength(250)]
        //[Required(ErrorMessage = "requerido")]
        public string NombreComercial { get => nombreComercial; set => SetProperty(ref nombreComercial, value); }
               
    }
}
