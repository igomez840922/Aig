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
        private string dias;
        [StringLength(250)]
        [Required(ErrorMessage = "RequiredField")]
        public string Dias { get => dias; set => SetProperty(ref dias, value); }

        //horario Inicio
        private string horarios;
        [StringLength(250)]
        [Required(ErrorMessage = "RequiredField")]
        public string Horarios { get => horarios; set => SetProperty(ref horarios, value); }


    }
}
