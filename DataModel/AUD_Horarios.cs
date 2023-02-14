using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_Horarios:SystemId
    {
        //Horario de atención
        private List<AUD_DatosHorario> horariosAtencion;
        public List<AUD_DatosHorario> HorariosAtencion { get => horariosAtencion; set => SetProperty(ref horariosAtencion, value); }

    }
}
