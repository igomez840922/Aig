using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class FMV_SocTB : SystemId
	{
		//nombre
		private string nombre;
		[StringLength(250)]
		[Required(ErrorMessage = "requerido")]
		public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }


        private List<FMV_TerMedraTB> lTerMedras;
        public virtual List<FMV_TerMedraTB> LTerMedras { get => lTerMedras; set => SetProperty(ref lTerMedras, value); }

    }
}
