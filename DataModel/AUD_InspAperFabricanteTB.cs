using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspAperFabricanteTB:SystemId
    {

        private AUD_InspeccionTB inspeccion;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //Datos del Representante Legal
        private AUD_DatosRepresentLegal datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRepresentLegal DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }

        //Datos del Regente
        private AUD_DatosRegente datosRegente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRegente DatosRegente { get => datosRegente; set => SetProperty(ref datosRegente, value); }

        //Productos que fabricarán 
        private AUD_InspAperFabricanteProdFabrican prodFabrican;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_InspAperFabricanteProdFabrican ProdFabrican { get => prodFabrican; set => SetProperty(ref prodFabrican, value); }

        //PERSONAL
        private AUD_ContenidoGenerico personal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Personal { get => personal; set => SetProperty(ref personal, value); }

        //INSTALACIONES
        private AUD_ContenidoGenerico instalaciones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Instalaciones { get => instalaciones; set => SetProperty(ref instalaciones, value); }

        //ÁREAS DE ALMACENAMIENTO
        private AUD_ContenidoGenerico areaAlmacenamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaAlmacenamiento { get => areaAlmacenamiento; set => SetProperty(ref areaAlmacenamiento, value); }

        //ÁREA DE DISPENSADO DE MATERIA PRIMA
        private AUD_ContenidoGenerico areaDispMateriaPrima;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaDispMateriaPrima { get => areaDispMateriaPrima; set => SetProperty(ref areaDispMateriaPrima, value); }

        //ÁREA DE PRODUCCIÓN
        private AUD_ContenidoGenerico areaProduccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaProduccion { get => areaProduccion; set => SetProperty(ref areaProduccion, value); }

        //ÁREAS DE ACONDICIONAMIENTO SECUNDARIO
        private AUD_ContenidoGenerico areaAcondSecundario;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaAcondSecundario { get => areaAcondSecundario; set => SetProperty(ref areaAcondSecundario, value); }

        //CONTROL DE CALIDAD
        private AUD_ContenidoGenerico controlCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico ControlCalidad { get => controlCalidad; set => SetProperty(ref controlCalidad, value); }

        //ÁREAS AUXILIARES
        private AUD_ContenidoGenerico areaAuxiliares;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaAuxiliares { get => areaAuxiliares; set => SetProperty(ref areaAuxiliares, value); }

        //EQUIPOS
        private AUD_ContenidoGenerico equipos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Equipos { get => equipos; set => SetProperty(ref equipos, value); }
                
        //MATERIALES Y PRODUCTOS
        private AUD_ContenidoGenerico materialesProductos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico MaterialesProductos { get => materialesProductos; set => SetProperty(ref materialesProductos, value); }

        public void Inicializa_Personal()
        {
            Personal = new AUD_ContenidoGenerico();
            Personal.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Regente Farmacéutico o director técnico",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Responsable de investigación y desarrollo",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Responsable de producción",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Responsable de control de calidad",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Responsable de garantía de la calidad",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Organigramas generales",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Organigramas específicos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Personal calificado y experiencia práctica según el puesto asignado",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "CAPACITACIÓN",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Procedimiento escrito de inducción general de buenas prácticas de manufactura (acondicionamiento) para el personal de nuevo ingreso y específica de acuerdo con sus funciones y atribuciones asignadas",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Formato de registros",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Procedimiento escrito para el ingreso de personas ajenas a las áreas de producción",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "SALUD E HIGIENE DEL PERSONAL",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Todo el personal previo a ser contratado se somete a examen médico?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Procedimiento escrito en donde el personal enfermo comunique de inmediato a su superior, cualquier estado de salud que influya negativamente en la producción.",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Formatos de registro",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Procedimientos relacionados con la higiene del personal incluyendo el uso de ropas protectoras, que incluyan a todas las personas que ingresan a las áreas de producción.",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Formatos para registros",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Utiliza diariamente el personal dedicado a la producción, que esté en contacto directo con el producto:\r\n- gorro que cubra la totalidad del cabello\r\n- mascarilla\r\n- guantes desechables\r\n- zapatos cerrados y suela antideslizante \r\n",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Procedimiento que instruya al personal a lavarse las manos antes de ingresar a las áreas de producción.",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_Instalaciones()
        {
            Instalaciones = new AUD_ContenidoGenerico();
            Instalaciones.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "ÁREA EXTERNA",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El establecimiento se encuentra identificado exteriormente, mediante letrero?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Está diseñado el edificio de tal manera que facilite la limpieza, mantenimiento y ejecución apropiada de las operaciones?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las vías de acceso interno a las instalaciones. Están pavimentadas o construidas de manera tal que el polvo no sea fuente de contaminación en el interior de la planta?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se encuentran actualizados los planos y diagramas de las instalaciones del edificio?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existen fuentes de contaminación ambiental en el área circundante al edificio? En caso afirmativo, se adoptan medidas de resguardo?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existen procedimientos, programa y registros del mantenimiento realizado a las instalaciones y edificios?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Está diseñado y equipado el edificio de tal forma que ofrezca la máxima protección contra el ingreso de insectos y animales?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "ÁREAS INTERNAS",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Está diseñado el edificio, de tal manera que permita el flujo de materiales, procesos y personal evitando la confusión, contaminación y errores?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Están las áreas de acceso restringido debidamente delimitadas e identificadas?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se utilizan como áreas de paso las áreas de producción, almacenamiento y control de calidad?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los equipos y materiales están ubicados de forma que eviten el riesgo de confusión, contaminación cruzada y omisión entre los distintos productos y sus componentes en cualquiera de las operaciones de producción, control de calidad y almacenamiento?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las condiciones de iluminación, temperatura, humedad y ventilación, para la producción y almacenamiento, están acordes con los requerimientos del producto?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las tuberías, artefactos lumínicos, puntos de ventilación y otros servicios, están diseñados y ubicados, de tal forma que faciliten la limpieza?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Dispone el edificio de extintores adecuados a las áreas y se encuentran estos ubicados en lugares estratégicos?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Señalización de rutas de evacuación y salidas de emergencia",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_AreaAlmacenamiento()
        {
            AreaAlmacenamiento = new AUD_ContenidoGenerico();
            AreaAlmacenamiento.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Están debidamente identificadas?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los pisos, paredes, techos de los almacenes están construidos de tal forma que no afectan la calidad de los materiales y productos que se almacenan y permite la fácil limpieza?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tienen las áreas de almacenamiento suficiente capacidad para permitir el almacenamiento ordenado de las diferentes categorías de materiales y productos?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las áreas de almacenamiento se mantienen limpias y ordenadas?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las instalaciones eléctricas están diseñadas y ubicadas de tal forma que facilitan la limpieza?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Hay instrumentos para medir la temperatura y humedad y estas mediciones están dentro de los parámetros establecidos para los materiales y productos almacenados? Formatos de registros?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Para las materias primas y productos que requieren condiciones especiales de enfriamiento, existe cámara fría? Formatos de registros?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "¿Existe un sistema de alerta que indique los \r\ndesvíos de la temperatura programada en la cámara fría?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Están protegidas de las condiciones ambientales las áreas de recepción y despacho?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un área de despacho de producto terminado?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las áreas donde se almacenan materiales y productos sometidos a cuarentena están claramente definidas y marcadas, el acceso a las mismas está limitado sólo al personal autorizado?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El muestreo de materia prima se efectúa en área separada o en el área de pesaje o dispensado?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El área de muestreo cumple con las siguientes características",
                         LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), },
                   },
                        new ContenidoPreguntas(){
                        Titulo = "a) Las paredes, pisos y techos son lisos y con curvas sanitarias",
                         LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), },
                   },
                        new ContenidoPreguntas(){
                        Titulo = "b) Existen controles de limpieza, temperatura y humedad relativa dentro del área",
                         LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), },
                   },
                        new ContenidoPreguntas(){
                        Titulo = "c) La iluminación es suficiente para el desempeño del proceso",
                         LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), },
                   },
                        new ContenidoPreguntas(){
                        Titulo = "d) El sistema de aire es independiente",
                         LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), },
                   },
                        new ContenidoPreguntas(){
                        Titulo = "Se utilizan materias primas psicotrópicas o estupefacientes?",
                         LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), },
                   },
                        new ContenidoPreguntas(){
                        Titulo = "Existen áreas separadas, bajo llave, de acceso restringido e identificadas para almacenar materias primas y productos psicotrópicos y estupefacientes?",
                       LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), },
                     },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta el laboratorio con áreas de almacenamiento separadas para productos rechazados, retirados y devueltos?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tienen estas áreas acceso restringido y bajo llave?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion(), },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existen procedimientos escritos para identificar, separar, retirar y destruir los productos rechazados, retirados, vencidos y devueltos? Formatos de registros?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un área separada y de acceso restringido para almacenar material impreso (etiquetas, estuches, insertos y envases impresos)?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , },
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Está identificada?",
                       LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , },
                     },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un área para almacenamiento de productos inflamables y explosivos alejada de las otras instalaciones, es ventilada y cuenta con medidas de seguridad contra incendios o explosiones según la legislación nacional?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , },
                    },
             };
        }
        public void Inicializa_AreaDispMateriaPrima()
        {
            AreaDispMateriaPrima = new AUD_ContenidoGenerico();
            AreaDispMateriaPrima.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Existe un área separada e identificada, para llevar a cabo las operaciones de dispensación?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tiene paredes, pisos, techos lisos y curvas sanitarias?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con un sistema de inyección y extracción de aire que garanticen la no contaminación cruzada y seguridad del operario?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mide la presión diferencial? Formatos de registro?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se toman las precauciones necesarias cuando se trabaja con materias primas fotosensibles?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se cuenta con sistemas para la extracción localizada de polvos, cuando aplique?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un área adyacente al área de dispensado, que se encuentre delimitada e identificada en donde se coloquen las materias primas que serán pesadas o medidas y las materias primas dispensadas que se utilizarán en la producción?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se dispone de un sector fuera del área para el lavado de utensilio usados en las pesadas y medidas?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los operarios disponen de uniforme completo y elementos de protección?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un procedimiento escrito para limpieza del área? Formatos de registros?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_AreaProduccion()
        {
            AreaProduccion = new AUD_ContenidoGenerico();
            AreaProduccion.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con esclusas?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El laboratorio cuenta con áreas de tamaño, diseño y servicios (aire comprimido, agua, luz, ventilación, etc.) para efectuar los procesos de producción que corresponden?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las áreas de producción:",
                           LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                 },
                        new ContenidoPreguntas(){
                        Titulo = "Están identificadas y separadas las áreas para la producción de sólidos, líquidos y semisólidos?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tienen paredes, pisos y techos lisos con curvas sanitarias de tal forma que permitan la fácil limpieza y sanitización?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tienen drenajes que no permiten la contracorriente y tienen tapa sanitaria?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las tuberías y puntos de ventilación son de material que permitan su fácil limpieza y están correctamente ubicados?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Están las tomas de gases y fluidos identificados y no son intercambiables?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Disponen de sistemas de inyección y extracción de aire?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuentan con equipo de control de aire, que permita el manejo de los diferenciales de presión de acuerdo con los requerimientos de cada área?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las condiciones de temperatura y humedad relativa se ajustan a los requerimientos de los productos que en ella se realizan? Formatos de registro?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se toman las precauciones necesarias cuando se trabaja con materias primas fotosensibles?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las áreas de empaque primario:",
                         LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                   },
                        new ContenidoPreguntas(){
                        Titulo = "Están identificadas y separadas las áreas para el empaque primario de sólidos, líquidos y semisólidos?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tienen paredes, pisos y techos lisos con curvas sanitarias de tal forma que permitan la fácil limpieza y sanitización?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tienen drenajes que no permiten la contracorriente y tienen tapa sanitaria?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las tuberías y puntos de ventilación son de material que permitan su fácil limpieza y están correctamente ubicados?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Están las tomas de gases y fluidos identificados?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Disponen de sistemas de inyección y extracción de aire?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuentan con equipo de control de aire, que permita el manejo de los diferenciales de presión de acuerdo con los requerimientos de cada área?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las condiciones de temperatura y humedad relativa se ajustan a los requerimientos de los productos que en ella se realizan? Formatos de registro?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un área exclusiva para el lavado de equipos móviles, recipientes y utensilios?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un área separada, identificada, limpia y ordenada para colocar equipo limpio que no se esté utilizando?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Qué sistema utilizan para el tratamiento de agua?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_AreaAcondSecundario()
        {
            AreaAcondSecundario = new AUD_ContenidoGenerico();
            AreaAcondSecundario.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Está el área de empaque secundario separada e identificada?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tienen paredes, pisos y techos lisos de tal forma que permitan la fácil limpieza y sanitización?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El área tiene el tamaño de acuerdo con su capacidad y línea de producción, con el fin de evitar confusiones?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El área se encuentra limpia y ordenada?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Están las tomas de gases y fluidos identificados?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tiene ventilación e iluminación que asegure condiciones confortables al personal y no afecten negativamente la calidad del producto?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Están libres de materiales y equipos que no están involucrados en el proceso?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_ControlCalidad()
        {
            ControlCalidad = new AUD_ContenidoGenerico();
            ControlCalidad.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Existe un área destinada para el laboratorio de control de calidad que se encuentra identificada y separada del área de producción?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tiene paredes lisas que faciliten su limpieza?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tiene una campana de extracción para los vapores nocivos?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tiene suficiente iluminación y ventilación?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de suficiente espacio para evitar confusiones y contaminación cruzada?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Según las operaciones que se realizan se dispone de las siguientes áreas:",
                                   LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                  },
                        new ContenidoPreguntas(){
                        Titulo = "- microbiología",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "- fisicoquímicas",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "- instrumental",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "- lavado de cristalería y utensilios",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe equipo de seguridad como:",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "- ducha",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "- lava ojos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "- extintores",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "- elementos de protección",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_AreaAuxiliares()
        {
            AreaAuxiliares = new AUD_ContenidoGenerico();
            AreaAuxiliares.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Están los servicios sanitarios accesibles a las áreas de trabajo y no se comunican directamente con las áreas de producción?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los vestidores están comunicados directamente con las áreas de producción?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los vestidores y servicios sanitarios están Identificados correctamente",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "La cantidad de servicios sanitarios para hombres y mujeres está de acuerdo con el número de trabajadores?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuentan con lavamanos y duchas provistas de agua?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de espejos, toallas de papel o secador eléctrico de manos, jaboneras con jabón líquido desinfectante y papel higiénico?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Casilleros, zapateras y las bancas necesarias (no de madera)",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantienen limpios y ordenados?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existen procedimientos para la limpieza y sanitización? Formatos de registros?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se prohíbe mantener, guardar, preparar y consumir alimentos en esta área, manteniendo rótulos que indiquen esta disposición",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se prohíbe fumar en estas áreas (rótulo).",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuentan con un comedor separado de las demás áreas productivas e identificada, en buenas condiciones de orden y limpieza?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuentan con un área de lavandería separada y exclusiva para el lavado y secado de los uniformes utilizados por el personal?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un área destinada para investigación y desarrollo de sus productos?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un área separada a las áreas de producción destinada al mantenimiento y almacenamiento de equipos, equipos obsoletos, herramientas y repuestos?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_Equipos()
        {
            Equipos = new AUD_ContenidoGenerico();
            Equipos.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Está el equipo utilizado en la producción diseñado y construido de acuerdo con la operación que en él se realice?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "La ubicación del equipo facilita su limpieza, así como la del área en la que se encuentra?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Si el equipo es muy pesado, está diseñado para que se pueda ejecutar su limpieza, sanitización o esterilización en el área de producción?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Son las superficies de los equipos que tienen contacto directo con las materias primas, productos en proceso, de acero inoxidable de acuerdo con su uso u otro material que no sea reactivo, aditivo y adsorbente?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los soportes de los equipos que lo requieran son de acero inoxidable u otro material que no contamine?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion(), new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Todo equipo empleado, cuenta con un procedimiento en el cual se especifiquen en forma clara las instrucciones y precauciones para su operación?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe formato para registros del uso de los equipos?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Procedimientos de la limpieza/mantenimiento del equipo incluyendo utensilios.",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Formato de registros",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se realiza calibración de los instrumentos de medición y dispositivos de registro o cualquier otro que lo requiera?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tienen registros escritos de las calibraciones?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe suministro de agua potable que le permita satisfacer sus necesidades?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Posee un sistema de tratamiento de agua que le permita obtenerla cumpliendo con las especificaciones de los libros oficiales para la producción?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un procedimiento escrito para el muestreo de agua? Formatos de registro?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un procedimiento/programa escrito para operar y sanitizar el sistema de tratamiento de agua, su red de distribución y puntos de muestreo? Formatos de registro?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un procedimiento/programa escrito para llevar a cabo la limpieza, sanitización y control de los tanques o cisternas? Formatos de registro?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un sistema de tratamiento de aire que evite el riesgo de la contaminación de los productos y las personas?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un programa de mantenimiento preventivo para este sistema? Formatos de registro?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_MaterialesProductos()
        {
            MaterialesProductos = new AUD_ContenidoGenerico();
            MaterialesProductos.LContenido = new List<ContenidoPreguntas>() {
                        
                        new ContenidoPreguntas(){
                        Titulo = "Existen procedimientos escritos que describan las operaciones de:",
                       LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "- Recepción e identificación de materiales y productos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "- Almacenamiento de materiales y productos.",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "- Manejo de materiales y productos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "- Muestreo, análisis y aprobación o rechazo de materiales y productos conforme a las especificaciones de cada uno de ellos.",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe espacio suficiente para realizar la limpieza e inspección y se encuentran las tarimas o estantes separados de las paredes?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Procedimiento de muestreo y análisis de materia prima",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe procedimiento escrito que garantice que se pesan o midan de forma precisa y exacta?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Si las ordenes ya fraccionadas no son dispensadas a la planta en forma inmediata, cuenta con un área de acceso restringido y bajo llave o sistema electrónico que evite confusiones?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de área para limpieza y sanitización de los contenedores con materias primas antes de fraccionar?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "MATERIALES DE ACONDICIONAMIENTO",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se manipulan y limpian los envases, cierres y medidas dosificadores según procedimiento escrito, cuando aplique?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Formatos de registros de su ejecución",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "PRODUCTOS INTERMEDIOS Y A GRANEL",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un área de almacenamiento de productos intermedios y a granel?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "En dónde está ubicado?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "PRODUCTOS TERMINADOS",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los productos terminados se mantienen almacenados en las condiciones requeridas? Condiciones del área que se utilizará para el almacenamiento",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "MATERIALES Y PRODUCTOS RECHAZADOS",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Procedimientos escritos para el manejo de materiales, productos intermedios, a granel y productos terminados que han sido rechazados",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Procedimiento escrito para la devolución de producto",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Formato de registros",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Procedimiento escrito para manejo y destrucción de material obsoleto o desactualizado.",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Formato de registros",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "PRODUCTOS DEVUELTOS",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un procedimiento escrito para la devolución de producto?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Formatos de registros",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Procedimiento escrito para la destrucción de estos productos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "PRODUCCIÓN",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existen procedimientos o instrucciones escritas para el manejo de materiales, graneles y productos en las operaciones de:\r\n-  Cuarentena.\r\n-  Etiquetado.\r\n-  Muestreo.\r\n-Acondicionamiento\r\n- Almacenamiento.\r\n-  Despacho.\r\n-  Elaboración.\r\n-  Envasado.\r\n-  Distribución.\r\nSe llevan registro de la ejecución de estos?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "PREVENCIÓN DE LA CONTAMINACIÓN CRUZADA Y MICROBIANA EN LA PRODUCCIÓN",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existen procedimientos escritos que indiquen medidas preventivas para evitar la contaminación cruzada en todas las fases de producción?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existen formato de registros?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "CONTROL DE CALIDAD Documentación",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Control de calidad realiza controles Físicos químicos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Control de calidad realiza controles Microbiológicos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "La unidad de control de calidad es independiente de producción?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "A quién reporta?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Esta unidad está bajo el cargo de un profesional farmacéutico o un profesional calificado?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Qué profesión tiene?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Programa de calibración para los equipos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "La unidad de control de calidad tiene a su disposición la documentación siguiente:",
                       LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                     },
                        new ContenidoPreguntas(){
                        Titulo = "a) Especificaciones escritas de los materiales, producto semielaborado y producto terminado.",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "b) Procedimiento escrito para manejo de muestra de retención",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "c) Procedimientos escritos para la calibración de instrumentos y equipos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "d) Procedimientos escritos de selección y calificación de proveedores",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "e) Procedimientos escritos y programa de sanitización de área",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "f) Existen formatos de registros",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "g) Procedimiento escrito para la aprobación y rechazo de materiales y productos terminados",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "PRODUCCIÓN Y ANÁLISIS POR CONTRATO",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El laboratorio realiza actividades de producción o análisis a terceros?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Especifique:",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe contrato?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El contrato a terceros para la producción o análisis está debidamente legalizado, definido y de mutuo consentimiento?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El contrato estipula las obligaciones de cada una de las partes con relación a:\r\na) Fabricación y/o acondicionamiento \r\nb) Manejo.\r\nc) Almacenamiento.\r\nd) Control de Calidad.\r\ne) Análisis.\r\nf) Liberación del producto.",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "QUEJAS, RECLAMOS Y RETIRO DE PRODUCTOS",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existen procedimientos escritos sobre el manejo de Quejas o reclamos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existen procedimientos escritos sobre el manejo de Retiro de productos del mercado",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "AUTOINSPECCIÓN Y AUDITORIAS DE CALIDAD",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "AUTOINSPECCIONES\r\nTiene el laboratorio fabricante y/o acondicionador un procedimiento y programa de autoinspecciones que contempla todos   los aspectos de las buenas prácticas de Manufactura?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
                        
    }

    public class AUD_InspAperFabricanteProdFabrican : SystemId
    {
        private string productosDesc;
        public string ProductosDesc { get => productosDesc; set => SetProperty(ref productosDesc, value); }

        //codigo
        private enumTipoProductosImportacion tipoProductos;
        public enumTipoProductosImportacion TipoProductos { get => tipoProductos; set => SetProperty(ref tipoProductos, value); }

        //lista de productos
        private List<AttachmentTB> lAttachments;
        public List<AttachmentTB> LAttachments { get => lAttachments; set => SetProperty(ref lAttachments, value); }

    }


}
