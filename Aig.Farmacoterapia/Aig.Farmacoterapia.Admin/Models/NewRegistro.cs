using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class NewRegistro
    {
        public int? _ { get; set; }
        public int? IdRegistroSanitario { get; set; }
        public int? IdEvaluacion { get; set; }
        public int? IdProducto { get; set; }
        public int? NumeroRegistroSanitario { get; set; }
        public int? RenovNumero { get; set; }
        public string? RenovTexto { get; set; }
        public string? NombreProducto { get; set; }
        public string? DescripcionEnvases { get; set; }
        public string? TipoMedicamento { get; set; }
        public string? CondicionVenta { get; set; }
        public string? FechaExpedicion { get; set; }
        public string? FechaExpiracion { get; set; }
        public string? Principio { get; set; }
        public string? ViaAdministracion { get; set; }
        public string? FormaFarmaceutica { get; set; }
        public string? FabricanteNombre { get; set; }
        public string? FabricanteDireccion { get; set; }
        public string? FabricanteCorreo { get; set; }
        public string? FabricantePais { get; set; }
        public string? FabricanteIso2 { get; set; }
        public string? FabricanteIso3 { get; set; }
        public string? NombreDistribuidorNacional { get; set; }
        public string? NombreTitular { get; set; }
        public string? NombreAcondicionadorPrimario { get; set; }
        public string? NombreAcondicionadorSecundario { get; set; }
    }
}
