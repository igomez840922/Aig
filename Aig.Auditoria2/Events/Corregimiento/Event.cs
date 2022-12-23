using DataModel;

namespace Aig.Auditoria2.Events.Corregimiento
{       
    public class CorregimientoAddEdit_CloseEvent
    {
        public CorregimientoTB Data { get; set; }
    }

    public class CorregimientoAddEdit_OpenEvent
    {
        public CorregimientoTB Data { get; set; }
    }
}
