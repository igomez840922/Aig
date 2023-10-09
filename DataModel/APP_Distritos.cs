using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class APP_Distritos : SystemId
	{        

        //Datos del Representante Legal
        private List<DistritoTB> lDistritos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public List<DistritoTB> LDistritos { get => lDistritos; set => SetProperty(ref lDistritos, value); }

    }
}
