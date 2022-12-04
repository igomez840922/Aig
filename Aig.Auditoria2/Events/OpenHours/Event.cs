using DataModel;

namespace Aig.Auditoria2.Events.OpenHours
{       
    public class OpenHoursAddEdit_CloseEvent
    {
        public AUD_DatosHorario Data { get; set; }
    }

    public class OpenHoursAddEdit_OpenEvent
    {
        public AUD_DatosHorario Data { get; set; }
    }
}
