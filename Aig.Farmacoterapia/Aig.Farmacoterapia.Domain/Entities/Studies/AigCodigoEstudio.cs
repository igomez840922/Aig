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
    public class AigCodigoEstudio : BaseAuditableEntity
    {
        public string Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Note { get; set; }
    }
}
