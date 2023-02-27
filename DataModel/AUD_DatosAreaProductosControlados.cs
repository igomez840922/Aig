using DataBindable;
using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    /// <summary>
    /// Datos de Area Productos Controlados
    /// </summary>
    public class AUD_DatosAreaProductosControlados : SystemId
    {
        private List<ContenidoPreguntas> lContenido;
        public List<ContenidoPreguntas> LContenido { get => lContenido; set => SetProperty(ref lContenido, value); }

        public void Inicializa()
        {
            LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                            Titulo = "Identificada",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Delimitada",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Asegurado bajo llave u otro sistema de seguridad comprobada",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Posee un área identificada de vencidos",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Independiente de otras áreas",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Medidas aproximadas",
                            IsHeader=true,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Largo",
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Ancho",
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Altura",
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Descripción del lugar donde se almacenan y las medidas de seguridad",
                        },
             };
        }



        /// <summary>
        /// ////////////////////
        /// </summary>



        //El área se encuentra identificada
        private enumAUD_TipoSeleccion areaIdentificada;
        public enumAUD_TipoSeleccion AreaIdentificada { get => areaIdentificada; set => SetProperty(ref areaIdentificada, value); }
        
        //Debe desplegar un área de texto para las observaciones.
        private string areaIdentificadaDesc;
        public string AreaIdentificadaDesc { get => areaIdentificadaDesc; set => SetProperty(ref areaIdentificadaDesc, value); }

        //El área se encuentra asegurada(llave y/o candado)
        private enumAUD_TipoSeleccion areaAsegurada;
        public enumAUD_TipoSeleccion AreaAsegurada { get => areaAsegurada; set => SetProperty(ref areaAsegurada, value); }
        
        //Debe desplegar un área de texto para las observaciones.
        private string areaAseguradaDesc;
        public string AreaAseguradaDesc { get => areaAseguradaDesc; set => SetProperty(ref areaAseguradaDesc, value); }

        //El área se encuentra independiente de otras áreas
        private enumAUD_TipoSeleccion areaIndependiente;
        public enumAUD_TipoSeleccion AreaIndependiente { get => areaIndependiente; set => SetProperty(ref areaIndependiente, value); }
        
        //Debe desplegar un área de texto para las observaciones.
        private string areaIndependienteDesc;
        public string AreaIndependienteDesc { get => areaIndependienteDesc; set => SetProperty(ref areaIndependienteDesc, value); }

        //El área se encuentra delimitada
        private enumAUD_TipoSeleccion areaDelimitada;
        public enumAUD_TipoSeleccion AreaDelimitada { get => areaDelimitada; set => SetProperty(ref areaDelimitada, value); }
        
        //Debe desplegar un área de texto para las observaciones.
        private string areaDelimitadaDesc;
        public string AreaDelimitadaDesc { get => areaDelimitadaDesc; set => SetProperty(ref areaDelimitadaDesc, value); }

        //El área posee una ubicación  identificada para productos vencidos
        private enumAUD_TipoSeleccion areaIdentProdVencido;
        public enumAUD_TipoSeleccion AreaIdentProdVencido { get => areaIdentProdVencido; set => SetProperty(ref areaIdentProdVencido, value); }
        
        //Debe desplegar un área de texto para las observaciones.
        private string areaIdentProdVencidoDesc;
        public string AreaIdentProdVencidoDesc { get => areaIdentProdVencidoDesc; set => SetProperty(ref areaIdentProdVencidoDesc, value); }

        //El área se encuentra con iluminación y ventilación
        private enumAUD_TipoSeleccion areaIluminaVentila;
        public enumAUD_TipoSeleccion AreaIluminaVentila { get => areaIluminaVentila; set => SetProperty(ref areaIluminaVentila, value); }
        
        //Debe desplegar un área de texto para las observaciones.
        private string areaIluminaVentilaDesc;
        public string AreaIluminaVentilaDesc { get => areaIluminaVentilaDesc; set => SetProperty(ref areaIluminaVentilaDesc, value); }

        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string lugarAlmacenMedidasSegDesc;
        public string LugarAlmacenMedidasSegDesc { get => lugarAlmacenMedidasSegDesc; set => SetProperty(ref lugarAlmacenMedidasSegDesc, value); }

        //Medidas aproximadas 
        private decimal dimLargo;
        public decimal DimLargo { get => dimLargo; set => SetProperty(ref dimLargo, value); }

        private decimal dimAncho;
        public decimal DimAncho { get => dimAncho; set => SetProperty(ref dimAncho, value); }

        private decimal dimAltura;
        public decimal DimAltura { get => dimAltura; set => SetProperty(ref dimAltura, value); }
    }
}
