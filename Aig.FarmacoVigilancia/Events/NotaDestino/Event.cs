using DataModel;

namespace Aig.FarmacoVigilancia.Events.NotaDestino
{       
    public class CloseEvent
    {
        public FMV_NotaDestinoTB Data { get; set; }
    }

    public class OpenEvent
    {
        public FMV_NotaDestinoTB Data { get; set; }
    }
}
