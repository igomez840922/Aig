using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Entities.Studies.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Studies
{
    public class AigTramitanteEstudio
    {
        public string Nombre { get; set; }
        public string Idoneidad { get; set; }
        public string Telefono{ get; set; }
        public string Correo { get; set; }
    }
}
