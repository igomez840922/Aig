using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class FMV_OrigenAlertaTB : SystemId
	{
		//nombre
		private string nombre;
		[StringLength(250)]
		[Required(ErrorMessage = "RequiredField")]
		public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

		//codigo
		private string descripcion;
		[StringLength(500)]
		public string Descripcion { get => descripcion; set => SetProperty(ref descripcion, value); }

		private List<FMV_AlertaTB> lAlertas;
        public virtual List<FMV_AlertaTB> LAlertas { get => lAlertas; set => SetProperty(ref lAlertas, value); }

    }
}
