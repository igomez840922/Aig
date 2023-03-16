using DataModel;
using DataModel.Models;

namespace Aig.Auditoria.Events.Inspections
{   
    public class AddEditCloseEvent    {       
        public AUD_InspeccionTB Inspeccion { get; set; }
    }

    public class AddEditDTOEvent {
        public InspeccionDTO Inspeccion { get; set; }
    }
}
