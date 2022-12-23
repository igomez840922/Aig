using DataModel;

namespace Aig.FarmacoVigilancia.Events.SOC
{       
    public class AddEdit_CloseEvent
    {
        public FMV_SocTB Data { get; set; }
    }

    public class AddEdit_OpenEvent
    {
        public FMV_SocTB Data { get; set; }
    }
}
