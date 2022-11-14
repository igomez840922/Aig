using Aig.Farmacoterapia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities
{
   
    public partial class AigViaAdministracion: BaseAuditableEntity
    {
        public string? Nombre { get; set; }
        public string Estado { get; set; } = "I";

        [JsonIgnore]
        public virtual ICollection<AigMedicamento> Medicamentos { get; set; }
    }
}
