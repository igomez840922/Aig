using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Products
{
    public class AigExcipient
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Descripcion")]
        public string Descripcion { get; set; }

        [JsonPropertyName("Concentracion")]
        public string Concentracion { get; set; }
    }
}
