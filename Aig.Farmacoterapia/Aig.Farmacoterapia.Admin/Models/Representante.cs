using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Representante
    {
        public int CodigoRepresentante { get; set; }
        public int? CodigoSol { get; set; }
        public string RepresentanteSol { get; set; } = null!;
        public string TelefonoRepresentanteSol { get; set; } = null!;
        public string CorreoRepresentanteSol { get; set; } = null!;
        public string DireccionRepresentanteSol { get; set; } = null!;
        public string? CedulaRepresentanteSol { get; set; }
    }
}
