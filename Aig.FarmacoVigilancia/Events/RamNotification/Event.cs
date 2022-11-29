using DataModel;

namespace Aig.FarmacoVigilancia.Events.RamNotification
{       
    public class AddEdit_CloseEvent
    {
        public FMV_RamNotificacionTB Data { get; set; }
    }

    public class AddEdit_OpenEvent
    {
        public FMV_RamNotificacionTB Data { get; set; }
    }
}
