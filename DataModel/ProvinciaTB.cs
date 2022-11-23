using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class ProvinciaTB : SystemId
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

		//pais
		private long? paisId;
		public long? PaisId { get => paisId; set => SetProperty(ref paisId, value); }
		private PaisTB? pais;
		public virtual PaisTB? Pais { get => pais; set => SetProperty(ref pais, value); }

        private List<DistritoTB> lDistritos;
        public virtual List<DistritoTB> LDistritos { get => lDistritos; set => SetProperty(ref lDistritos, value); }
    }
}
