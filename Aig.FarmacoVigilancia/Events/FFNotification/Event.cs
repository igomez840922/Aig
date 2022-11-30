using DataModel;

namespace Aig.FarmacoVigilancia.Events.FFNotification
{       
    public class AddEdit_CloseEvent
    {
        public FMV_FfNotificacionTB Data { get; set; }
    }

    public class AddEdit_OpenEvent
    {
        public FMV_FfNotificacionTB Data { get; set; }
    }
}
