using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class AbogadoCo
    {
        public int CodigoAbogado { get; set; }
        public int? CodigoSol { get; set; }
        public string CedulaAbogadoSol { get; set; } = null!;
        public string AbogadoSol { get; set; } = null!;
        public string TelefonoAbogadoSol { get; set; } = null!;
        public string CorreoAbogadoSol { get; set; } = null!;
        public string DireccionAbogadoSol { get; set; } = null!;
        public string IdoneidadAbogadoSol { get; set; } = null!;
        public string FirmaAbogadoSol { get; set; } = null!;
    }
}
