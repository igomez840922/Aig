using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class AdjuntosCo
    {
        public int Correlativo { get; set; }
        public int? CodigoSol { get; set; }
        public string ReciboTasaSol { get; set; } = null!;
        public string PoderSol { get; set; } = null!;
        public string CertificadoLibreSol { get; set; } = null!;
        public string CertificadoManufacturaSol { get; set; } = null!;
        public string FormulaCualiSol { get; set; } = null!;
        public string DocAvalSol { get; set; } = null!;
        public string ProductoTerminadoSol { get; set; } = null!;
        public string AclaratoriosSol { get; set; } = null!;
        public string FotoMuestraSol { get; set; } = null!;
        public string PresentacionSol { get; set; } = null!;
        public string? ReciboSol { get; set; }
    }
}
