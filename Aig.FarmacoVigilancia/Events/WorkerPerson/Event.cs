using DataModel;

namespace Aig.FarmacoVigilancia.Events.WorkerPerson
{       
    public class PersonAddEdit_CloseEvent
    {
        public PersonalTrabajadorTB Data { get; set; }
    }

    public class PersonAddEdit_OpenEvent
    {
        public PersonalTrabajadorTB Data { get; set; }
    }
}
