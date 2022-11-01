using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Distribuidor
    {
        public int CodigoDistribuidor { get; set; }
        public int? CodigoSol { get; set; }
        public string LicenciaDistribuidor { get; set; } = null!;
        public string NombreDistribuidor { get; set; } = null!;
        public string TelefonoDistribuidor { get; set; } = null!;
        public string CorreoDistribuidor { get; set; } = null!;
        public int? CodigoU { get; set; }
        public string? Estado { get; set; }
    }
}
