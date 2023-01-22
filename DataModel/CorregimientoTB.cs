using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{	
	public class CorregimientoTB : SystemId
	{
		//nombre
		private string nombre;
		[StringLength(250)]
		[Required(ErrorMessage = "requerido")]
		public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

		//codigo
		private string codigo;
		[StringLength(250)]
		public string Codigo { get => codigo; set => SetProperty(ref codigo, value); }


		//distrito
		private long? distritoId;
		public long? DistritoId { get => distritoId; set => SetProperty(ref distritoId, value); }
		private DistritoTB? distrito;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual DistritoTB? Distrito { get => distrito; set => SetProperty(ref distrito, value); }
	}
}
