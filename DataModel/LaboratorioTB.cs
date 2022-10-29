using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class LaboratorioTB:SystemId
    {
        //nombre de establecimiento
        private string nombre;
        [StringLength(250)]
        [Required(ErrorMessage = "RequiredField")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }


        private List<FMV_PmrProductoTB> lProductos;
        public virtual List<FMV_PmrProductoTB> LProductos { get => lProductos; set => SetProperty(ref lProductos, value); }

        private List<FMV_IpsTB> lIps;
        public virtual List<FMV_IpsTB> LIps { get => lIps; set => SetProperty(ref lIps, value); }
    }
}
