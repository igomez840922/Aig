using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosExpedienteColaborador : SystemId
    {
        public AUD_DatosExpedienteColaborador()
        {
            LColaboradores = new List<ExpedienteColaborador>();
        }

        //Lista de Personal Tecnico
        private List<ExpedienteColaborador> lColaboradores;
        public List<ExpedienteColaborador> LColaboradores { get => lColaboradores; set => SetProperty(ref lColaboradores, value); }

    }
}
