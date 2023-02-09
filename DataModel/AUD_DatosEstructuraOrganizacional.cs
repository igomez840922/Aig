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
            
        }

        
        private List<ContenidoPreguntas> lContenido;
        public List<ContenidoPreguntas> LContenido { get => lContenido; set => SetProperty(ref lContenido, value); }


        //Horario de atención
        private List<AUD_DatosHorario> horariosAtencion;
        public List<AUD_DatosHorario> HorariosAtencion { get => horariosAtencion; set => SetProperty(ref horariosAtencion, value); }

        public void Inicializa()
        {
            LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de su letrero de identificación visible al público",
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El establecimiento utilizará plataformas tecnológicas para la comercialización de medicamentos de venta sin prescripción médica y otros productos para la salud humana",
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El establecimiento se compromete al fiel cumplimiento del Artículo 386 del Decreto Ejecutivo 115 De 16 de agosto de 2022",
                    },
             };
        }

        /// <summary>
        /// ///////////////////////////////////////////////
        /// </summary>


        //Dispone de su letrero de Identificación
        private bool letreroIdentificacion;
        public bool LetreroIdentificacion { get => letreroIdentificacion; set => SetProperty(ref letreroIdentificacion, value); }

        private string letreroIdentificacionDesc;
        public string LetreroIdentificacionDesc { get => letreroIdentificacionDesc; set => SetProperty(ref letreroIdentificacionDesc, value); }


        //El horario de Operación coincide con lo señalado en la solicitud de licencia de operación
        private bool horarioOpeIgualSolic;
        public bool HorarioOpeIgualSolic { get => horarioOpeIgualSolic; set => SetProperty(ref horarioOpeIgualSolic, value); }

        //El horario de Operación coincide con lo señalado en la solicitud de licencia de operación
        private string horarioOpeIgualSolicDesc;
        public string HorarioOpeIgualSolicDesc { get => horarioOpeIgualSolicDesc; set => SetProperty(ref horarioOpeIgualSolicDesc, value); }


        //El establecimiento utilizará plataformas tecnológicas para la comercialización de medicamentos de venta sin prescripción médica y otros productos para la salud humana
        private bool utilizaPlatafComercial;
        public bool UtilizaPlatafComercial { get => utilizaPlatafComercial; set => SetProperty(ref utilizaPlatafComercial, value); }

        //El establecimiento utilizará plataformas tecnológicas para la comercialización de medicamentos de venta sin prescripción médica y otros productos para la salud humana
        private string utilizaPlatafComercialDesc;
        public string UtilizaPlatafComercialDesc { get => utilizaPlatafComercialDesc; set => SetProperty(ref utilizaPlatafComercialDesc, value); }


        
    }
}
