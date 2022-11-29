using DataModel;

namespace Aig.FarmacoVigilancia.Events.Ram
{       
    public class AddEdit_CloseEvent
    {
        public FMV_RamTB Data { get; set; }
    }

    public class AddEdit_OpenEvent
    {
        public FMV_RamTB Data { get; set; }
    }
}
