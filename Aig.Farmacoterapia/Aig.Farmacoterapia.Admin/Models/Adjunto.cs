using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Adjunto
    {
        public int Correlativo { get; set; }
        public int? CodigoSol { get; set; }
        public string ReciboSol { get; set; } = null!;
        public string PoderSol { get; set; } = null!;
        public string CertificadoSol { get; set; } = null!;
        public string CertificadoManufacturaSol { get; set; } = null!;
        public string MetodoManufacturaSol { get; set; } = null!;
        public string FormulaSol { get; set; } = null!;
        public string MetodoAnalisisSol { get; set; } = null!;
        public string CertificadoAnalisisSol { get; set; } = null!;
        public string EspecificacionesSol { get; set; } = null!;
        public string LoteSol { get; set; } = null!;
        public string EtiquetasSol { get; set; } = null!;
        public string MonografiaSol { get; set; } = null!;
        public string EstabilidadSol { get; set; } = null!;
        public string DesechoSol { get; set; } = null!;
        public string AclaratoriosSol { get; set; } = null!;
        public string MuestraSol { get; set; } = null!;
        public string PatronesSol { get; set; } = null!;
        public string TasaservicioSol { get; set; } = null!;
        public string? ProductoTerminado { get; set; }
        public string? Controles { get; set; }
        public string? ManejoRiesgo { get; set; }
        public string? Condiciones { get; set; }
        public string? ReciboMefSol { get; set; }
    }
}
