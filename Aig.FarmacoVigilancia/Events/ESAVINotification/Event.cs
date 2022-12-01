using DataModel;

namespace Aig.FarmacoVigilancia.Events.ESAVINotification
{       
    public class AddEdit_CloseEvent
    {
        public FMV_EsaviNotificacionTB Data { get; set; }
    }

    public class AddEdit_OpenEvent
    {
        public FMV_EsaviNotificacionTB Data { get; set; }
    }
}
