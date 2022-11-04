using DataModel;

namespace Aig.FarmacoVigilancia.Events.Alerta
{       
    public class AlertAddEdit_CloseEvent
    {
        public FMV_AlertaTB Data { get; set; }
    }

    public class AlertaAddEdit_OpenEvent
    {
        public FMV_AlertaTB Data { get; set; }
    }
}
