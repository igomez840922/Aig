
using System.Collections.Generic;
using System.Net.Mail;

namespace DataModel
{
    public class AUD_ParticipantesDNFD:SystemId
    {
        public AUD_ParticipantesDNFD()
        {
            LParticipantes = new List<Participante>();
        }

        //Lista de Participantes
        private List<Participante> lParticipantes;
        public List<Participante> LParticipantes { get => lParticipantes; set => SetProperty(ref lParticipantes, value); }

    }
}
