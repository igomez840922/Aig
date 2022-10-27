using DataModel;

namespace Aig.FarmacoVigilancia.Events.Province
{       
    public class ProvinceAddEdit_CloseEvent
    {
        public ProvinciaTB Data { get; set; }
    }

    public class ProvinceAddEdit_OpenEvent
    {
        public ProvinciaTB Data { get; set; }
    }
}
