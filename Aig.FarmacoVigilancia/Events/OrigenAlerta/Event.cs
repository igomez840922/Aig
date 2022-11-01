using DataModel;

namespace Aig.FarmacoVigilancia.Events.OrigenAlerta
{       
    public class OrigenAlertaAddEdit_CloseEvent
    {
        public FMV_OrigenAlertaTB Data { get; set; }
    }

    public class OrigenAlertaAddEdit_OpenEvent
    {
        public FMV_OrigenAlertaTB Data { get; set; }
    }
}
