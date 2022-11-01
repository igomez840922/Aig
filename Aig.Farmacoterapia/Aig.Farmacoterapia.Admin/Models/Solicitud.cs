using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Solicitud
    {
        public int Id { get; set; }
        public DateTime? FechaSol { get; set; }
        public string? ProductoSol { get; set; }
        public string? FabricanteSol { get; set; }
        public string? EmpresaSol { get; set; }
        public string? RepresentantelegalSol { get; set; }
        public string? FarmaceuticoSol { get; set; }
    }
}
