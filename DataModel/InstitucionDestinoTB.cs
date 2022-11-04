using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class InstitucionDestinoTB : SystemId
    {
        //nombre de establecimiento
        private string nombre;
        [StringLength(250)]
        [Required(ErrorMessage = "RequiredField")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //descripcion de establecimiento
        private string descripcion;
        public string Descripcion { get => descripcion; set => SetProperty(ref descripcion, value); }


        private List<FMV_NotaTB> lNotas;
        public virtual List<FMV_NotaTB> LNotas { get => lNotas; set => SetProperty(ref lNotas, value); }       

    }
}
