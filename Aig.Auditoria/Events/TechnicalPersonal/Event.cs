using DataModel;

namespace Aig.Auditoria.Events.TechnicalPersonal
{       
    public class TechnicalPersonalAddEdit_CloseEvent
    {
        public PersonalTecnico Data { get; set; }
    }

    public class TechnicalPersonalAddEdit_OpenEvent
    {
        public PersonalTecnico Data { get; set; }
    }
}
