using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class ProductoEstablecimientoTB : SystemId
	{
		//nombre
		private string nombre;
		[StringLength(300)]
		[Required(ErrorMessage = "requerido")]
		public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //nombre
        private string descripcion;
        [StringLength(500)]
        public string Descripcion { get => descripcion; set => SetProperty(ref descripcion, value); }
    }
}
