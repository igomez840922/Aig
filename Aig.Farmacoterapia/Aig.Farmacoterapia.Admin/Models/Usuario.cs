using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class Usuario
    {
        public int CodigoU { get; set; }
        public string? EstadoU { get; set; }
        public string? NombreU { get; set; }
        public string? EmailU { get; set; }
        public string? UsuarioU { get; set; }
        public string? ClaveU { get; set; }
        public string? RoleU { get; set; }
        public string? InicialesU { get; set; }
    }
}
