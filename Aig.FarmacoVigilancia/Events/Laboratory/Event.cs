using DataModel;

namespace Aig.FarmacoVigilancia.Events.Laboratory
{       
    public class LaboratoryAddEdit_CloseEvent
    {
        public LaboratorioTB Data { get; set; }
    }

    public class LaboratoryAddEdit_OpenEvent
    {
        public LaboratorioTB Data { get; set; }
    }
}
