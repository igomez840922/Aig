using DataModel;

namespace Aig.Auditoria.Events.Participants
{       
    public class ParticipantsAddEdit_CloseEvent
    {
        public Participante Data { get; set; }
    }

    public class ParticipantsAddEdit_OpenEvent
    {
        public Participante Data { get; set; }
    }
}
