using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class PaisTB:SystemId
	{
		//nombre
		private string nombre;
		[StringLength(250)]
		[Required(ErrorMessage = "RequiredField")]
		public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

		//codigo
		private string codigo;
		[StringLength(250)]
		public string Codigo { get => codigo; set => SetProperty(ref codigo, value); }

	}
}
