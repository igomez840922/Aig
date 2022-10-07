using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class AUD_AreaControladoTB : SystemId
	{
		//nombre de establecimiento
		private string nombre;
		[StringLength(250)]
		[Required(ErrorMessage = "RequiredField")]
		public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

		
		//descripcion
		private string descripcion;
		[StringLength(500)]
		public string Descripcion { get => descripcion; set => SetProperty(ref descripcion, value); }
	}
}
