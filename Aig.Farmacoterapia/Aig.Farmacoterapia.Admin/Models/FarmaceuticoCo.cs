using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class FarmaceuticoCo
    {
        public int CodigoFarmaceutico { get; set; }
        public int? CodigoSol { get; set; }
        public string CedulaFarmaceuticoSol { get; set; } = null!;
        public string IdoneidadFarmaceuticoSol { get; set; } = null!;
        public string FarmaceuticoSol { get; set; } = null!;
        public string TelefonoFarmaceuticoSol { get; set; } = null!;
        public string CorreoFarmaceuticoSol { get; set; } = null!;
        public string DireccionFarmaceuticoSol { get; set; } = null!;
        public string FirmaFarmaceuticoSol { get; set; } = null!;
        public string RefrendoFarmaceuticoSol { get; set; } = null!;
    }
}
