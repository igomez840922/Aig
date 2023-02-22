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
    public class AigEstudioDNFD : AigEstudioBase
    {
        public string RegistroProtocoloDIGESA { get; set; }
        public string ComiteBioetica { get; set; }
        public string? NotaEvaluacion { get; set; }
        public DateTime? FechaEvaluacion { get; set; } = DateTime.Today;
        public string? ObservacionesEvaluador { get; set; }

        public long AigCodigoEstudioId { get; set; }
        public virtual AigCodigoEstudio AigCodigo { get; set; }

        private ICollection<AigEstudio> _aigEstudios;
        public virtual ICollection<AigEstudio> AigEstudios => _aigEstudios ??= new HashSet<AigEstudio>();

    }

}
