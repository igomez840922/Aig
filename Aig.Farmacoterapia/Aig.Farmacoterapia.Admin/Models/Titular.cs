using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Titular
    {
        public int CodigoTitular { get; set; }
        public int? CodigoSol { get; set; }
        public string TitularSol { get; set; } = null!;
        public string CodigoPTitular { get; set; } = null!;
        public string DireccionTitular { get; set; } = null!;
        public string CorreoTitular { get; set; } = null!;
    }
}
