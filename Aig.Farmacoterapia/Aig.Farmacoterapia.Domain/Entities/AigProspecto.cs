using Aig.Farmacoterapia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities
{
    public class AigProspecto
    {
        public string ModoDeUso { get; set; }
        public string Composicion { get; set; }
        public string Forma { get; set; }
        public string Envase { get; set; }
        public string? VidaUtil { get; set; }
        public string? Condicion { get; set; }
        public string? InformaciónAdicional { get; set; }
    }
}