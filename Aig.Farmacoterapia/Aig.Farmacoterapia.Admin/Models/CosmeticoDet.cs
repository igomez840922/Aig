using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class CosmeticoDet
    {
        public int Correlativo { get; set; }
        public int? CodigoSol { get; set; }
        public string CosmeticoCod { get; set; } = null!;
    }
}
