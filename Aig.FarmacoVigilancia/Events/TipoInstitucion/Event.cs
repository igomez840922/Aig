using DataModel;

namespace Aig.FarmacoVigilancia.Events.TipoInstitucion
{       
    public class AddEdit_CloseEvent
    {
        public TipoInstitucionTB Data { get; set; }
    }

    public class AddEdit_OpenEvent
    {
        public TipoInstitucionTB Data { get; set; }
    }
}
