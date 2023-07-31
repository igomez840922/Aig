using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Aig.Farmacoterapia.Domain.Entities.Products
{
    public class AigMedication
    {
        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }

        [JsonPropertyName("DescripcionEnvase")]
        public string DescripcionEnvase { get; set; }

        [JsonPropertyName("ClasificacionMedica")]
        public string ClasificacionMedica { get; set; }

        [JsonPropertyName("CondicionVenta")]
        public string CondicionVenta { get; set; }

        [JsonPropertyName("PrincipioActivo")]
        public string PrincipioActivo { get; set; }

        [JsonPropertyName("ViaAdministracion")]
        public string ViaAdministracion { get; set; }

        [JsonPropertyName("FormaFarmaceutica")]
        public string FormaFarmaceutica { get; set; }

        [JsonPropertyName("VidaUtil")]
        public string VidaUtil { get; set; }
    }

}
