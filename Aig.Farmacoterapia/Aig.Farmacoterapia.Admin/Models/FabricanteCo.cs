using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class FabricanteCo
    {
        public int CodigoFabricante { get; set; }
        public int? CodigoSol { get; set; }
        public string FabricanteSol { get; set; } = null!;
        public string CodigoPFabricante { get; set; } = null!;
        public string DireccionFabricante { get; set; } = null!;
        public string CorreoFabricante { get; set; } = null!;
        public string? EsAcondicionador { get; set; }
        public string? EsTitular { get; set; }
    }
}
