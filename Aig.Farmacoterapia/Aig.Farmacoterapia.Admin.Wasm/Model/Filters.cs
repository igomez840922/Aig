
namespace Aig.Farmacoterapia.Admin.Wasm.Model
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
}
