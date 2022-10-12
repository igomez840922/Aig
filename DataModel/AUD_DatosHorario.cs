using DataBindable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    /// <summary>
    /// Datos del Regente
    /// </summary>
    public class AUD_DatosHorario : SystemId
    {
        //dia
        private string dia;
        [StringLength(250)]
        public string Dia { get => dia; set => SetProperty(ref dia, value); }

        //horario Inicio
        private string horarioInicio;
        [StringLength(250)]
        public string HorarioInicio { get => horarioInicio; set => SetProperty(ref horarioInicio, value); }

        //horario Fin
        private string horarioFin;
        [StringLength(250)]
        public string HorarioFin { get => horarioFin; set => SetProperty(ref horarioFin, value); }

    }
}
