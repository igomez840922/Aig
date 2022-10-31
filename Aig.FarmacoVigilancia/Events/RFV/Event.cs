using DataModel;

namespace Aig.FarmacoVigilancia.Events.PMR
{       
    public class RfvAddEdit_CloseEvent
    {
        public FMV_RfvTB Data { get; set; }
    }

    public class RfvAddEdit_OpenEvent
    {
        public FMV_RfvTB Data { get; set; }
    }
}
