using Aig.Farmacoterapia.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities
{
    public class AigFabricante: BaseAuditableEntity
    {

        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        [JsonIgnore]
        public long PaisId { get; set; }
        public virtual AigPais Pais { get; set; }
        [JsonIgnore]
        public virtual ICollection<AigMedicamento> Medicamentos { get; set; }
    }
}
