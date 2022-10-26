using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	
	public class DistritoTB : SystemId
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


		//provincia
		private long? provinciaId;
		public long? ProvinciaId { get => provinciaId; set => SetProperty(ref provinciaId, value); }
		private ProvinciaTB? provincia;
		public virtual ProvinciaTB? Provincia { get => provincia; set => SetProperty(ref provincia, value); }

        private List<CorregimientoTB> lCorregimientos;
        public virtual List<CorregimientoTB> LCorregimientos { get => lCorregimientos; set => SetProperty(ref lCorregimientos, value); }
    }
}
