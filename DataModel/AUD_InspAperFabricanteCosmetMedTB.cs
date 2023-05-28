using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspAperFabricanteCosmetMedTB : SystemId
    {
        public AUD_InspAperFabricanteCosmetMedTB()
        {
            DatosResponsable = new DatosPersona();
        }

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

        //Datos del Responsable
        private DatosPersona datosResponsable;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona DatosResponsable { get => datosResponsable; set => SetProperty(ref datosResponsable, value); }

        //Productos que fabricarán 
        private AUD_InspAperFabricanteProdFabrican prodFabrican;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_InspAperFabricanteProdFabrican ProdFabrican { get => prodFabrican; set => SetProperty(ref prodFabrican, value); }


        //Estructura Organizativa
        private AUD_ContenidoGenerico documantacion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Documantacion { get => documantacion; set => SetProperty(ref documantacion, value); }

        //Estructura Organizativa
        private AUD_ContenidoGenerico almacenes;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Almacenes { get => almacenes; set => SetProperty(ref almacenes, value); }
        
        //Areas Auxiliares
        private AUD_ContenidoGenerico areasAuxiliares;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreasAuxiliares { get => areasAuxiliares; set => SetProperty(ref areasAuxiliares, value); }



        //Estructura Organizativa
        private AUD_ContenidoGenerico estructuraOrganizativa;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico EstructuraOrganizativa { get => estructuraOrganizativa; set => SetProperty(ref estructuraOrganizativa, value); }

        
        //Estructura Organizativa
        private AUD_ContenidoGenerico almacenes2;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Almacenes2 { get => almacenes2; set => SetProperty(ref almacenes2, value); }

        //SISTEMAS CRITICOS DE APOYO
        private AUD_ContenidoGenerico sistemaCriticoApoyo;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico SistemaCriticoApoyo { get => sistemaCriticoApoyo; set => SetProperty(ref sistemaCriticoApoyo, value); }

        //ÁREAS DE PRODUCCIÓN
        private AUD_ContenidoGenerico areaProduccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaProduccion { get => areaProduccion; set => SetProperty(ref areaProduccion, value); }

        //ACONDICIONAMIENTO 
        private AUD_ContenidoGenerico acondicionamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Acondicionamiento { get => acondicionamiento; set => SetProperty(ref acondicionamiento, value); }

        //CONTROL DE CALIDAD 
        private AUD_ContenidoGenerico controlCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico ControlCalidad { get => controlCalidad; set => SetProperty(ref controlCalidad, value); }

        //INSPECCIONES Y AUDITORÍA
        private AUD_ContenidoGenerico inspeccionAuditoria;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico InspeccionAuditoria { get => inspeccionAuditoria; set => SetProperty(ref inspeccionAuditoria, value); }


        public void Inicializa_Documantacion()
        {
            Documantacion = new AUD_ContenidoGenerico();
            Documantacion.LContenido =
                new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Organización y Personal",
                                 IsHeader=true,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "El establecimiento se encuentra identificado exteriormente, mediante letrero?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Organigramas (General y específicos)",
                                 IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Descripción de puestos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Responsable de investigación y desarrollo",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Responsable de producción,",
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
                        Titulo = "Inducción del personal",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Programas",
                                 IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Programa de limpieza e higiene",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Programa que contemple exámenes médicos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Programa para el control de la fauna nociva",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuando la documentación se mantiene por procesamiento electrónico de datos, el acceso está restringido por claves de acceso",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Fórmula maestra",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Producción y Análisis por Contrato",
                                 IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Contrato por escrito que establezca las funciones y responsabilidades de cada parte",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Análisis por contrato: el contrato establece que la aprobación final del producto lo hará el contratante a través del responsable de Control de Calidad.",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El contrato establece donde se tomarán las muestras para su análisis",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Fabricación por contrato: realizada por un fabricante con Licencia de Operación.",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Reclamos y Productos retirados del mercado",
                                 IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Persona encargada",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Locales",
                                 IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El local está limpio y ordenado",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Instrucciones que no se debe permitir fumar, comer, beber, masticar o guardar plantas, comidas, bebidas, material de fumar y medicamentos personales",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Áreas externas limpias, ordenadas y libres de materiales extraños",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Áreas externas limpias, ordenadas y libres de materiales extraños",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Condiciones adecuadas de:",
                                 IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = " - suministros eléctricos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = " - iluminación",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = " - temperatura",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = " - humedad",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = " - ventilación",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Estado de conservación del edificio",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Señalización de las vías o rutas de evacuación",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Equipo para el control de incendios",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Área de Producción",
                                 IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Orden lógico de las operaciones",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Condiciones adecuadas (lisas, sin grietas ni fisuras, no desprende partículas, permite limpieza fácil) de:",
                                 IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = " - paredes",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = " - pisos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = " - techos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Vestidores, lavados, servicios sanitarios",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Implementos (mascarillas, gorros, guantes)",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los servicios sanitarios no comunican directamente con el área de producción",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Si almacenan piezas y herramientas en esta área, están colocadas en armarios reservados para este fin.",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Letreros indicando el acceso restringido a personal autorizado",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Equipo",
                                 IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Adecuadamente localizado",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las tuberías fijas conectados al equipo están rotulados claramente indicando su contenido",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las tuberías de servicios (agua, gases, otros), están identificados",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Laboratorio de Control de Calidad",
                                 IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Equipo e instrumentos de laboratorio de control son apropiados a los procedimientos de análisis que se realizarán",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Área para almacenar los patrones",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuentan con especificaciones para",
                                 IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = " - Materia prima",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = " - Material de acondicionamiento",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = " - Productos semi-elaborados y a granel",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = " - Productos terminados",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    }
             };

        }
        public void Inicializa_Almacenes()
        {
            Almacenes = new AUD_ContenidoGenerico();
            Almacenes.LContenido = new List<ContenidoPreguntas> {

                    new ContenidoPreguntas(){
                        Titulo = "Cuenta con un área para",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Capacidad suficiente para permitir el almacenamiento ordenado de los productos y que facilite el manejo y circulación en el área",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "El área se encuentra",
                                 IsHeader = true,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- limpia ",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- seca",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- dentro de límites aceptables de temperatura",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- delimitada",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- identificada",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- ordenada",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- adecuada iluminación",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- adecuadas condiciones de pisos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- adecuadas condiciones de paredes",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- adecuadas condiciones de techos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Sistema para los controles ambientales de temperatura y humedad relativa.",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Formatos para Registro de temperatura y humedad relativa",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Letreros visibles de los rangos de temperatura y humedad de almacenamiento (según lo estipulado por el fabricante)",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Recepción y despacho protegida de las inclemencias   del tiempo",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Áreas de cuarentena: identificadas y de acceso restringido",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área para almacenar productos rechazados, retirados o devueltos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área para almacenar sustancias con riesgo a fuego o explosión",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área de almacenamiento para Etiquetas, material impreso",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion() { HideEvaluacion=true},new OpcionEvaluacion(),new OpcionEvaluacion(){ HideEvaluacion=true}},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Existen advertencias o prohibiciones de: no comer, no beber, no fumar, no guardar plantas comidas y bebidas",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Los servicios sanitarios no comunican directamente",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Señalización de las vías o rutas de evacuación en casos de siniestro o catástrofe",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Equipo para el control de incendios",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
            };

        }

        public void Inicializa_AreasAuxiliares()
        {
            AreasAuxiliares = new AUD_ContenidoGenerico();
            AreasAuxiliares.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Áreas de descanso y comedores separados de áreas técnicas",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Servicios sanitarios, lavamanos y en cantidad suficiente",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Casilleros para el personal ",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Áreas de mantenimiento separadas de las áreas de producción",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    }
             };
        }





        public void Inicializa_Almacenes2()
        {
            Almacenes = new AUD_ContenidoGenerico();
            Almacenes.LContenido = new List<ContenidoPreguntas> {

                    new ContenidoPreguntas(){
                        Titulo = "Cuenta con un área para",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Capacidad suficiente para permitir el almacenamiento ordenado de los productos y que facilite el manejo y circulación en el área",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "El área se encuentra",
                                 IsHeader = true,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- limpia ",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- seca",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- dentro de límites aceptables de temperatura",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- delimitada",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- identificada",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- ordenada",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- adecuada iluminación",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- adecuadas condiciones de pisos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- adecuadas condiciones de paredes",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "- adecuadas condiciones de techos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Sistema para los controles ambientales de temperatura y humedad relativa.",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Formatos para Registro de temperatura y humedad relativa",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Letreros visibles de los rangos de temperatura y humedad de almacenamiento (según lo estipulado por el fabricante)",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Recepción y despacho protegida de las inclemencias   del tiempo",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Áreas de cuarentena: identificadas y de acceso restringido",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área para almacenar productos rechazados, retirados o devueltos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área para almacenar sustancias con riesgo a fuego o explosión",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Área de almacenamiento para Etiquetas, material impreso",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion() { HideEvaluacion=true},new OpcionEvaluacion(),new OpcionEvaluacion(){ HideEvaluacion=true}},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Existen advertencias o prohibiciones de: no comer, no beber, no fumar, no guardar plantas comidas y bebidas",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Los servicios sanitarios no comunican directamente",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Señalización de las vías o rutas de evacuación en casos de siniestro o catástrofe",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Equipo para el control de incendios",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(),new OpcionEvaluacion(),new OpcionEvaluacion()},
                    },
            };
        }

        public void Inicializa_SistemaCriticoApoyo()
        {
            SistemaCriticoApoyo = new AUD_ContenidoGenerico();
            SistemaCriticoApoyo.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Sistema e Instalación de agua",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "La empresa cuenta con un piso técnico delimitado e identificado, en el cual se localizan los sistemas críticos de apoyo.",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existe un procedimiento para el muestreo del agua. (Se describen los puntos de muestreo y controles a realizar)",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "-Formato de registro cronológico del muestreo del agua",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existe un procedimiento de limpieza de tanques de almacenamiento de agua",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "-Formato de limpieza de los tanques de almacenamiento",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Tratamiento del Agua",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "- Sistema de Osmosis Inversa",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Sistema de deionización",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Otros",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existe un manual de procedimiento escrito para la operación del sistema de agua. El operario dispone de copia autorizada de este manual\r\n",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existen procedimientos escritos para la sanitización de los medios filtrantes (describe la frecuencia) en Osmosis Inversa o Deionización.",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Se realiza mantenimiento preventivo a los equipos que forman parte del sistema. (Procedimiento) Cuál es la frecuencia",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Formatos de registros de mantenimiento preventivo",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Calibraciones y Verificaciones de equipo",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "Existen procedimientos escritos para efectuar las calibraciones y verificaciones de los equipos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Formato de registro calibraciones y verificaciones de los equipos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Validaciones",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "La empresa cuenta con un Plan Maestro de Validación",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Mantenimiento de áreas y equipos",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "Existen programas para el mantenimiento de las áreas y equipos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_AreaProduccion()
        {
            AreaProduccion = new AUD_ContenidoGenerico();
            AreaProduccion.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Condiciones Externas",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "La instalación es sólida, facilita la limpieza y mantenimiento",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existe protección contra la entrada de roedores, insectos, aves u otros animales a las áreas de producción",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Condiciones Internas",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "Existe un procedimiento escrito de limpieza para el área",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "-Formato de registro de limpieza",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existe un procedimiento de limpieza tanto de las áreas de fabricación como de los equipos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existe un programa para la limpieza del área, llevan registros cronológicos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "La empresa cuenta con procedimiento y programa para la limpieza de áreas auxiliares (vestidores, baños, comedor)",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "El local está limpio y ordenado",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Instrucciones que no se debe permitir fumar, comer, beber, masticar o guardar plantas, comidas, bebidas, material de fumar y medicamentos personales",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Áreas externas limpias, ordenadas y libres de materiales extraños",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Condiciones adecuadas de:",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "- Suministros Eléctricos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Iluminación",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Temperatura",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Humedad",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Ventilación",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Estado de conservación del edificio",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Señalización de las vías o rutas de evacuación",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Equipo para el control de incendios",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existe instructivo o procedimiento para que el personal que manifiesta lesiones en su piel, enfermedades o lesiones abiertas en la superficie del cuerpo que puedan afectar la calidad de los productos lo reporte.",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existen procedimientos escritos para la modificación de la formula maestra",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existen instrucciones que indiquen la intervención de Control de Calidad para la extracción de muestras de producción en proceso",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    }, new ContenidoPreguntas(){
                        Titulo = "Área de Dispensación de Ordenes de Fabricación",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "Temperatura",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Humedad Relativa",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existe un área separada e identificada para la dispensación de órdenes de fabricación",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "- Paredes",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Pisos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Techos ",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Curvas sanitarias",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Sistemas de aire ",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "El área se encuentra equipada con Equipo (balanzas) e utensilios",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existe procedimiento para la dispensación de órdenes de fabricación",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existe un área independiente, destinada para el lavado de los implementos utilizados",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Los equipos se encuentran calibrados. \r\nExiste un programa para la calibración de los equipos. Se lleva un registro\r\n",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existen procedimiento de limpieza del área de dispensación de órdenes de Fabricación",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existe programa de limpieza para esta área",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    }
             };
        }
        public void Inicializa_Acondicionamiento()
        {
            Acondicionamiento = new AUD_ContenidoGenerico();
            Acondicionamiento.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Área de Envasado",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "La empresa cuenta con un área delimitada e identificada para el envasado final de los productos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "El área cuenta con adecuadas condiciones de:",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "- Iluminación",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Ventilación",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Instalación de Control de aire, incluyendo Temperatura y Humedad",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Acabados Sanitarios",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Las paredes, piso y techo son lisos y de fácil limpieza",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Cuentan con procedimiento escrito y registros del envasado de productos o granel",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existen procedimientos escritos y registros cronológicos de limpieza de esta área y sus equipos (Verifique)",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Área de Etiquetado y Empaque",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "Existe un procedimiento escrito y formato de registros cronológicos de todas las operaciones que se relacionan con el área de etiquetado y empaque",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    }
             };
        }
        public void Inicializa_ControlCalidad()
        {
            ControlCalidad = new AUD_ContenidoGenerico();
            ControlCalidad.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Laboratorio de Control de Calidad",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "Control de Calidad es un departamento independiente de las áreas de producción?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Las instalaciones físicas del laboratorio de Control de Calidad son adecuadas al volumen de operaciones que desarrollan?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "El laboratorio de Control de Calidad cuenta con el equipo y materiales adecuados para desarrollar los controles que efectúan? Anexe listado de equipos",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existen programas de verificación del funcionamiento de estos equipos? Existen registros de su cumplimiento?",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "El Departamento de Control de Calidad cuenta con procedimientos escritos para",
                                 IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "- Muestreo de materias primas (Representativo del total de lote)",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Aprobación o rechazo de las materias primas (Representativo del total de lote)",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Aprobación o rechazo de los productos terminados (Representativo del total de lote)",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Aprobación o rechazo de materiales de acondicionamiento, envases y empaques  (Representativo del total de lote)",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "- Aprobación o rechazo de etiquetas   (Representativo del total de lote)",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "El Departamento de Control de Calidad mantiene los formatos de registros de los análisis efectuados",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existe un procedimiento escrito detallando el plazo de re-análisis de materias primas",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Existen protocolos de ingreso para el personal que labora en estas áreas.",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_InspeccionAuditoria()
        {
            InspeccionAuditoria = new AUD_ContenidoGenerico();
            InspeccionAuditoria.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con un procedimiento de autoinspección",
                                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    }
             };
        }


    }

}
