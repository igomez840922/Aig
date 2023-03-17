using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models {
    
    public class InspeccionModel {
        public string NumeroActa { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }

        public DatosEstablecimiento DatosEstablecimiento { get; set; }
        public AUD_DatosRepresentLegal DatosRepresentLegal { get; set; }
        public AUD_DatosRegente DatosRegente { get; set; }
    }

    public class DatosEstablecimiento  {
        
        public string Nombre { get; set; }

        public string NumLicencia { get; set; }
        
        public string AvisoOperaciones { get; set; }

        public string ReciboPago { get; set; }

        public string ProvinciaNombre { get; set; }
        public string ProvinciaCodigo { get; set; }


        public string DistritoNombre { get; set; }
        public string DistritoCodigo { get; set; }


        public string CorregimientoNombre { get; set; }
        public string CorregimientoCodigo { get; set; }
        
       public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Correo { get; set; }


    }

}
