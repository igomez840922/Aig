using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Agencia
    {
        public int CodigoAg { get; set; }
        public string? LicenciaAg { get; set; }
        public string? EstablecimientoAg { get; set; }
        public string? ActividadAg { get; set; }
        public string? UbicacionAg { get; set; }
        public DateTime? VigenciaDesdeAg { get; set; }
        public DateTime? VigenciaHastaAg { get; set; }
        public string? FarmaceuticoAg { get; set; }
        public string? RegistroFarmaceuticoAg { get; set; }
    }
}
