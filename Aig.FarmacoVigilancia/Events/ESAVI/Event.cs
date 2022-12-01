using DataModel;

namespace Aig.FarmacoVigilancia.Events.ESAVI
{       
    public class AddEdit_CloseEvent
    {
        public FMV_EsaviTB Data { get; set; }
    }

    public class AddEdit_OpenEvent
    {
        public FMV_EsaviTB Data { get; set; }
    }
}
