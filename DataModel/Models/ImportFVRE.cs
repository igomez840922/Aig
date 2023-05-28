using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class ImportFVRE
    {
        public string NumNotificacion { get; set; }
        public DateTime? FechaNotificacion { get; set; }
        public string FarmacoNotificado { get; set; }
        public TipoTramiteFVRE TipoTramiteFVRE { get; set; }
    }
}
