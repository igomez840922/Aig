using DataModel;

namespace Aig.FarmacoVigilancia.Events.FTNotification
{       
    public class AddEdit_CloseEvent
    {
        public FMV_FtNotificacionTB Data { get; set; }
    }

    public class AddEdit_OpenEvent
    {
        public FMV_FtNotificacionTB Data { get; set; }
    }
}
