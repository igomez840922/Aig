using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class EmpresaSolicitante
    {
        public int CodigoEmpresaSolicitante { get; set; }
        public int? CodigoSol { get; set; }
        public string EmpresaSol { get; set; } = null!;
        public string TelefonoEmpresaSol { get; set; } = null!;
        public string CorreoEmpresaSol { get; set; } = null!;
        public string RucEmpresaSol { get; set; } = null!;
        public string DireccionEmpresaSol { get; set; } = null!;
    }
}
