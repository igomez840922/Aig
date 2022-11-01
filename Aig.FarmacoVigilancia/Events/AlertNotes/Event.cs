using DataModel;

namespace Aig.FarmacoVigilancia.Events.AlertNotes
{       
    public class AlertNotesAddEdit_CloseEvent
    {
        public FMV_AlertaNotaSeguridadTB Data { get; set; }
    }

    public class AlertNotesAddEdit_OpenEvent
    {
        public FMV_AlertaNotaSeguridadTB Data { get; set; }
    }
}
