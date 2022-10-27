using DataModel;

namespace Aig.FarmacoVigilancia.Events.District
{       
    public class DistrictAddEdit_CloseEvent
    {
        public DistritoTB Data { get; set; }
    }

    public class DistrictAddEdit_OpenEvent
    {
        public DistritoTB Data { get; set; }
    }
}
