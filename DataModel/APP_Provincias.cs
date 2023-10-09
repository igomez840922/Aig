using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class APP_Provincias : SystemId
	{        

        //Datos del Representante Legal
        private List<ProvinciaTB> lProvincias;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public List<ProvinciaTB> LProvincias { get => lProvincias; set => SetProperty(ref lProvincias, value); }

    }
}
