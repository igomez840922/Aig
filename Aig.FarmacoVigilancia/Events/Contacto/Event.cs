using DataModel;

namespace Aig.FarmacoVigilancia.Events.Contacto
{       
    public class CloseEvent
    {
        public DataModel.Contacto Data { get; set; }
    }

    public class OpenEvent
    {
        public DataModel.Contacto Data { get; set; }
    }
}
