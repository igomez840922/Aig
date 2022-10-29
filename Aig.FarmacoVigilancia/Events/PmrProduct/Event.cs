using DataModel;

namespace Aig.FarmacoVigilancia.Events.PmrProduct
{       
    public class AddEdit_CloseEvent
    {
        public FMV_PmrProductoTB Data { get; set; }
    }

    public class AddEdit_OpenEvent
    {
        public FMV_PmrProductoTB Data { get; set; }
    }
}
