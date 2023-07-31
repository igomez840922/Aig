using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Products
{
    public class AigDistributor
    {
        [JsonPropertyName("NombreDistribuidorNacional")]
        public string NombreDistribuidorNacional { get; set; }

        [JsonPropertyName("NombreTitular")]
        public string NombreTitular { get; set; }

        [JsonPropertyName("NombreAcondicionadorPrimario")]
        public string NombreAcondicionadorPrimario { get; set; }

        [JsonPropertyName("NombreAcondicionadorSecundario")]
        public string NombreAcondicionadorSecundario { get; set; }
    }
}
