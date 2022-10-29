using DataModel;

namespace Aig.FarmacoVigilancia.Events.PMR
{       
    public class PmrAddEdit_CloseEvent
    {
        public FMV_PmrTB Data { get; set; }
    }

    public class PmrAddEdit_OpenEvent
    {
        public FMV_PmrTB Data { get; set; }
    }
}
