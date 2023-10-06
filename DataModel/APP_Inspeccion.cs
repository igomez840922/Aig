using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class APP_Inspeccion : SystemId
	{
        public long InspeccionId { get; set; }

        public string NumActa { get; set; }

        //Datos del Representante Legal
        private AUD_InspeccionTB inspeccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

    }
}
