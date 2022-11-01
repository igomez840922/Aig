using Aig.Farmacoterapia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities
{
    public class AigPais: BaseAuditableEntity
    {
        public string Iso { get; set; }
        public string Nombre { get; set; }
        [JsonIgnore]
        public virtual ICollection<AigFabricante> Fabricantes { get; set; }
    }
}
