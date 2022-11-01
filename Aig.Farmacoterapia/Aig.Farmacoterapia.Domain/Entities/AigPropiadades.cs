using Aig.Farmacoterapia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities
{
    public class AigPropiadades
    {
        public string Quimico { get; set; }
        public string Propiedades { get; set; }
        public string PropiedadesFarmaco { get; set; }
        public string Indicaciones { get; set; }
        public string Contraindicaciones { get; set; }
        public string Advertencias { get; set; }
        public string Embarazo { get; set; }
        public string Conducir { get; set; }
        public string Interacciones { get; set; }
        public string Reacciones { get; set; }
        public string Posologia { get; set; }
        public string Sobredosificacion { get; set; }
        public string Preclinicos { get; set; }
    }
}