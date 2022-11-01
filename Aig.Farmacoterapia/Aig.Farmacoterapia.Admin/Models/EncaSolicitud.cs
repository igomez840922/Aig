using System;
using System.Collections.Generic;

namespace Aig.Farmacoterapia.Admin.Models
{
    public partial class EncaSolicitud
    {
        public int CodigoSol { get; set; }
        public DateOnly? FechaSol { get; set; }
        public string? TipoSol { get; set; }
        public string TipoRegistroSol { get; set; } = null!;
        public string TipoMedicamentoSol { get; set; } = null!;
        public string ProductoSol { get; set; } = null!;
        public string PrincipioSol { get; set; } = null!;
        public string ConcentracionSol { get; set; } = null!;
        public string FormafarmaceuticaSol { get; set; } = null!;
        public string ViaSol { get; set; } = null!;
        public string CondicionventaSol { get; set; } = null!;
        public string CodigoAtcSol { get; set; } = null!;
        public string EnvaseSol { get; set; } = null!;
        public string MedicamentoSol { get; set; } = null!;
        public string ComposicionSol { get; set; } = null!;
        public string FormaSol { get; set; } = null!;
        public string QuimicoSol { get; set; } = null!;
        public string PropiedadesSol { get; set; } = null!;
        public string PropiedadesFarmacoSol { get; set; } = null!;
        public string IndicacionesSol { get; set; } = null!;
        public string ContraindicacionesSol { get; set; } = null!;
        public string AdvertenciasSol { get; set; } = null!;
        public string EmbarazoSol { get; set; } = null!;
        public string ConducirSol { get; set; } = null!;
        public string InteraccionesSol { get; set; } = null!;
        public string ReaccionesSol { get; set; } = null!;
        public string PosologiaSol { get; set; } = null!;
        public string SobredosificacionSol { get; set; } = null!;
        public string PreclinicosSol { get; set; } = null!;
        public string ExcipientesSol { get; set; } = null!;
        public string IncompatiblesSol { get; set; } = null!;
        public string ValidezSol { get; set; } = null!;
        public string PrecaucionesSol { get; set; } = null!;
        public string DescripcionEnvaseSol { get; set; } = null!;
        public string FabricanteproductoSol { get; set; } = null!;
        public string VersiondocumentoSol { get; set; } = null!;
        public string RefereciasSol { get; set; } = null!;
        public string PreparaciónSol { get; set; } = null!;
        public string ElaboradoSol { get; set; } = null!;
        public string AprobadoSol { get; set; } = null!;
        public int? CodigoU { get; set; }
        public string? NumeroSol { get; set; }
        public int? CodigoUEvaluador { get; set; }
        public string? Estado { get; set; }
        public string? ArchivoFirmado { get; set; }
        public string? VidaUtil { get; set; }
        public string? Condicion { get; set; }
        public string? VersionDocumento { get; set; }
        public string? DocumentoFirmadoResponsable { get; set; }
        public string? RegistroRenovacion { get; set; }
        public double? TipoPagoSol { get; set; }
        public string? NumeroRegistroIn { get; set; }
        public string? NumeroRegistroLetrasIn { get; set; }
        public int? VigenciaIn { get; set; }
        public string? LibroIn { get; set; }
        public string? FolioIn { get; set; }
        public DateOnly? FechaExpedicionIn { get; set; }
        public string? DatosProtegidos { get; set; }
        public string? RegistroNumeroIn { get; set; }
        public string? RegistroLetraIn { get; set; }
        public string? TextoDosis { get; set; }
    }
}
