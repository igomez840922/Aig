using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class CosmeticosEnc
    {
        public int CodRc { get; set; }
        public DateOnly FechaSolicitud { get; set; }
        public string TipoSolicitud { get; set; } = null!;
        public string NumeroSolicitud { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string? NumeroRenovacion { get; set; }
        public string NombreProducto { get; set; } = null!;
        public string Variante { get; set; } = null!;
        public string IdViaAdmin { get; set; } = null!;
        public string? IdClasificacion { get; set; }
        public string DescEnvase { get; set; } = null!;
        public string? Comentario { get; set; }
        public string? ComentarioInterno { get; set; }
        public int? CodigoUEvaluador { get; set; }
        public int? CodigoU { get; set; }
        public double? TipoPagoSol { get; set; }
        public string? NumeroRegistroIn { get; set; }
        public string? NumeroRegistroLetrasIn { get; set; }
        public int? VigenciaIn { get; set; }
        public string? LibroIn { get; set; }
        public string? FolioIn { get; set; }
        public DateOnly? FechaExpedicionIn { get; set; }
        public string? RegistroNumeroIn { get; set; }
        public string? RegistroLetraIn { get; set; }
    }
}
