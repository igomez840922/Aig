
using Aig.Farmacoterapia.Domain.Entities.Studies.Enums;

namespace Aig.Farmacoterapia.Wasm.Client.Model
{
    public class BaseFilter
    {
        public BaseFilter()
        {
            Term = string.Empty;
        }
        public string Term { get; set; }
    }
    public class MedicamentFilter : BaseFilter
    {
        public MedicamentFilter() : base()
        {
            StartDate = null;
            EndDate = null;
            StartExpirationDate = null;
            EndExpirationDate = null;
        }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartExpirationDate { get; set; }
        public DateTime? EndExpirationDate { get; set; }
        public string Fabricante { get; set; }

    }

    public class StudiesDNFDFilter : BaseFilter
    {
        public StudiesDNFDFilter() : base()
        {
            StartDate = null;
            EndDate = null;
            StartExpirationDate = null;
            EndExpirationDate = null;
        }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartExpirationDate { get; set; }
        public DateTime? EndExpirationDate { get; set; }
        public EstadoEstudioDNFD Status { get; set; }

    }

    public class StudiesFilter : BaseFilter
    {
        public StudiesFilter() : base()
        {
            StartDate = null;
            EndDate = null;
            StartExpirationDate = null;
            EndExpirationDate = null;
        }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartExpirationDate { get; set; }
        public DateTime? EndExpirationDate { get; set; }
        public EstadoEstudio Status { get; set; }

    }
}
