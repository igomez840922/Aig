using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class APP_Paises : SystemId
	{        

        //Datos del Representante Legal
        private List<PaisTB> lPaises;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public List<PaisTB> LPaises { get => lPaises; set => SetProperty(ref lPaises, value); }

    }
}
