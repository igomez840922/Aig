using DataModel;

namespace Aig.FarmacoVigilancia.Events.Nota
{       
    public class NotaAddEdit_CloseEvent
    {
        public FMV_NotaTB Data { get; set; }
    }

    public class NotaAddEdit_OpenEvent
    {
        public FMV_NotaTB Data { get; set; }
    }
}
