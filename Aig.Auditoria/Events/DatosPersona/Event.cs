using DataModel;

namespace Aig.Auditoria.Events.DatosPersona
{       
    public class AddEdit_CloseEvent
    {
        public DataModel.DatosPersona Data { get; set; }
    }

    public class AddEdit_OpenEvent
    {
        public DataModel.DatosPersona Data { get; set; }
    }
}
