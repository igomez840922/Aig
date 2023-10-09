using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class APP_Corregimientos : SystemId
	{        

        //Datos del Representante Legal
        private List<CorregimientoTB> lCorregimientos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public List<CorregimientoTB> LCorregimientos { get => lCorregimientos; set => SetProperty(ref lCorregimientos, value); }

    }
}
