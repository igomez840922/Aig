using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class ViaAdministracion
    {
        public int CodigoVia { get; set; }
        public string? NumeroVia { get; set; }
        public string? DescripcionVia { get; set; }
        public string? Estado { get; set; }
    }
}
