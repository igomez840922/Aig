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
    /// Datos de Estructura Organizacional del Establecimiento
    /// </summary>
    public class AUD_DatosEstructuraOrganizacional : SystemId
    {
        public AUD_DatosEstructuraOrganizacional()
        {
            HorariosAtencion = new List<AUD_DatosHorario>();
        }

        //Dispone de su letrero de Identificación
        private bool letreroIdentificacion;
        public bool LetreroIdentificacion { get => letreroIdentificacion; set => SetProperty(ref letreroIdentificacion, value); }

        //El horario de Operación coincide con lo señalado en la solicitud de licencia de operación
        private bool horarioOpeIgualSolic;
        public bool HorarioOpeIgualSolic { get => horarioOpeIgualSolic; set => SetProperty(ref horarioOpeIgualSolic, value); }

        //El establecimiento utilizará plataformas tecnológicas para la comercialización de medicamentos de venta sin prescripción médica y otros productos para la salud humana
        private bool utilizaPlatafComercial;
        public bool UtilizaPlatafComercial { get => utilizaPlatafComercial; set => SetProperty(ref utilizaPlatafComercial, value); }

        //Horario de atención
        private List<AUD_DatosHorario> horariosAtencion;
        public List<AUD_DatosHorario> HorariosAtencion { get => horariosAtencion; set => SetProperty(ref horariosAtencion, value); }

    }
}
