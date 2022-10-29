using DataModel;

namespace Aig.FarmacoVigilancia.Events.IPS
{       
    public class IpsAddEdit_CloseEvent
    {
        public FMV_IpsTB Data { get; set; }
    }

    public class IpsAddEdit_OpenEvent
    {
        public FMV_IpsTB Data { get; set; }
    }
}
