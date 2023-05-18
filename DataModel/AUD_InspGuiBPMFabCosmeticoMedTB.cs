using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    //Fabricante de Cosmeticos y Descinfectantes
    public class AUD_InspGuiBPMFabCosmeticoMedTB : SystemId
    {
        private AUD_InspeccionTB inspeccion;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        //Datos del Representante Legal
        private DatosPersona datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }

        //Datos del Regente
        private DatosPersona datosRegente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona DatosRegente { get => datosRegente; set => SetProperty(ref datosRegente, value); }

        //Otros Funcionarios
        private AUD_OtrosFuncionarios otrosFuncionarios;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_OtrosFuncionarios OtrosFuncionarios { get => otrosFuncionarios; set => SetProperty(ref otrosFuncionarios, value); }

        //REQUISITOS LEGALES
        private AUD_ContenidoGenerico requisitosLegales;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico RequisitosLegales { get => requisitosLegales; set => SetProperty(ref requisitosLegales, value); }

        // observaciones
        private string observaciones;
        public string Observaciones { get => observaciones; set => SetProperty(ref observaciones, value); }

        // Está el establecimiento sometido a un proceso periódico de vigilancia y control sanitario por la autoridad competente?
        private enumAUD_TipoSeleccion procesoVigilanciaSanit;
        public enumAUD_TipoSeleccion ProcesoVigilanciaSanit { get => procesoVigilanciaSanit; set => SetProperty(ref procesoVigilanciaSanit, value); }

        // Fecha de la última visita
        private DateTime? fechaUltimaVista;
        public DateTime? FechaUltimaVista { get => fechaUltimaVista; set => SetProperty(ref fechaUltimaVista, value); }

        //CLASIFICACION DE ACTIVIDADES
        private AUD_ContenidoGenerico clasifActComerciales;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico ClasifActComerciales { get => clasifActComerciales; set => SetProperty(ref clasifActComerciales, value); }

        //CLASIFICACION DE ESTABLECIMIENTOS
        private AUD_ContenidoGenerico clasifEstablecimiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico ClasifEstablecimiento { get => clasifEstablecimiento; set => SetProperty(ref clasifEstablecimiento, value); }

        //ADMINISTRACIÓN E INFORMACIÓN GENERAL
        private AUD_ContenidoGenerico adminInfoGeneral;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AdminInfoGeneral { get => adminInfoGeneral; set => SetProperty(ref adminInfoGeneral, value); }

        //A -- Condiciones Externas de los Almacenes
        private AUD_ContenidoGenerico condExtAlmacenas;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico CondExtAlmacenas { get => condExtAlmacenas; set => SetProperty(ref condExtAlmacenas, value); }
        
        //B -- Condiciones Internas de los Almacenes
        private AUD_ContenidoGenerico condIntAlmacenas;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico CondIntAlmacenas { get => condIntAlmacenas; set => SetProperty(ref condIntAlmacenas, value); }

        //C-- Área de Recepción de Materia Prima 
        private AUD_ContenidoGenerico areaRecepMateriaPrima;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaRecepMateriaPrima { get => areaRecepMateriaPrima; set => SetProperty(ref areaRecepMateriaPrima, value); }

        //CH -- Almacén de Materia Prima
        private AUD_ContenidoGenerico almacenMateriaPrima;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AlmacenMateriaPrima { get => almacenMateriaPrima; set => SetProperty(ref almacenMateriaPrima, value); }

        //D -- Área de almacenamiento de Materiales de Acondicionamiento, Empaque y Envase
        private AUD_ContenidoGenerico almacenMatAcondicionamineto;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AlmacenMatAcondicionamineto { get => almacenMatAcondicionamineto; set => SetProperty(ref almacenMatAcondicionamineto, value); }

        //E- Recepción de Producto Terminado (De producción al almacén)
        private AUD_ContenidoGenerico recepProductoTerminado;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico RecepProductoTerminado { get => recepProductoTerminado; set => SetProperty(ref recepProductoTerminado, value); }

        //E.1 -- Almacén de Producto Terminado
        private AUD_ContenidoGenerico almacenProductoTerminado;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AlmacenProductoTerminado { get => almacenProductoTerminado; set => SetProperty(ref almacenProductoTerminado, value); }

        //F -- Área de productos Devueltos y/o Rechazado
        private AUD_ContenidoGenerico productoDevueltoRechazado;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico ProductoDevueltoRechazado { get => productoDevueltoRechazado; set => SetProperty(ref productoDevueltoRechazado, value); }

        //G -- Distribución de Productos Terminados
        private AUD_ContenidoGenerico distProductoTerminado;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico DistProductoTerminado { get => distProductoTerminado; set => SetProperty(ref distProductoTerminado, value); }

        //H -- Manejo de quejas y reclamos de productos comercializados
        private AUD_ContenidoGenerico manejoQuejaReclamos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico ManejoQuejaReclamos { get => manejoQuejaReclamos; set => SetProperty(ref manejoQuejaReclamos, value); }

        //I -- Retiro de Productos del Mercado
        private AUD_ContenidoGenerico retiroProcMercado;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico RetiroProcMercado { get => retiroProcMercado; set => SetProperty(ref retiroProcMercado, value); }


        //3.1 Sistemas e Instalaciones de Agua
        private AUD_ContenidoGenerico sistemaInstAgua;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico SistemaInstAgua { get => sistemaInstAgua; set => SetProperty(ref sistemaInstAgua, value); }

        //3.1.1 OSMOSIS INVERSA
        private AUD_ContenidoGenerico osmosisInversa;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico OsmosisInversa { get => osmosisInversa; set => SetProperty(ref osmosisInversa, value); }


        //3.1.2 SISTEMA DE DEIONIZACION
        private AUD_ContenidoGenerico sistemaDeIonizacion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico SistemaDeIonizacion { get => sistemaDeIonizacion; set => SetProperty(ref sistemaDeIonizacion, value); }

        //3.2 Calibraciones y Verificaciones de equipo
        private AUD_ContenidoGenerico calibraVerifEquipo;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico CalibraVerifEquipo { get => calibraVerifEquipo; set => SetProperty(ref calibraVerifEquipo, value); }

        //3.3 Validaciones
        private AUD_ContenidoGenerico validaciones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Validaciones { get => validaciones; set => SetProperty(ref validaciones, value); }

        //3.4 Mantenimiento de áreas y equipos
        private AUD_ContenidoGenerico mantAreaEquipos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico MantAreaEquipos { get => mantAreaEquipos; set => SetProperty(ref mantAreaEquipos, value); }

        //Capitulo IV - ÁREAS DE PRODUCCIÓN - 4.1.A Condiciones Externas
        private AUD_ContenidoGenerico areaProdCondExternas;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaProdCondExternas { get => areaProdCondExternas; set => SetProperty(ref areaProdCondExternas, value); }

        private AUD_ContenidoGenerico areaProdCondInternas;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaProdCondInternas { get => areaProdCondInternas; set => SetProperty(ref areaProdCondInternas, value); }
        
        private AUD_ContenidoGenerico areaOrganizaDocumentacion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaOrganizaDocumentacion { get => areaOrganizaDocumentacion; set => SetProperty(ref areaOrganizaDocumentacion, value); }

        private AUD_ContenidoGenerico areaDispensionOrdFab;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaDispensionOrdFab { get => areaDispensionOrdFab; set => SetProperty(ref areaDispensionOrdFab, value); }


        //4.4.1 Fabricación de Productos Desinfectante
        private AUD_ContenidoGenerico fabProdDesinfectante;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico FabProdDesinfectante { get => fabProdDesinfectante; set => SetProperty(ref fabProdDesinfectante, value); }

        //4.5.1 Fabricación de Plaguicida
        private AUD_ContenidoGenerico fabPlaguicida;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico FabPlaguicida { get => fabPlaguicida; set => SetProperty(ref fabPlaguicida, value); }

        //4.6 COSMÉTICOS 4.6.1 Fabricación de Cosmético
        private AUD_ContenidoGenerico fabCosmeticos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico FabCosmeticos { get => fabCosmeticos; set => SetProperty(ref fabCosmeticos, value); }

        //5.1 Área de Envasad
        private AUD_ContenidoGenerico areaEnvasado;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaEnvasado { get => areaEnvasado; set => SetProperty(ref areaEnvasado, value); }

        //5.2. Área de Etiquetado y Empaque
        private AUD_ContenidoGenerico areaEtiquetadoEmpaque;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaEtiquetadoEmpaque { get => areaEtiquetadoEmpaque; set => SetProperty(ref areaEtiquetadoEmpaque, value); }

        //6.1 Laboratorio de Control de Calidad 
        private AUD_ContenidoGenerico labControlCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico LabControlCalidad { get => labControlCalidad; set => SetProperty(ref labControlCalidad, value); }

        //6.2 Análisis por Contrato 
        private AUD_ContenidoGenerico analisisContrato;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AnalisisContrato { get => analisisContrato; set => SetProperty(ref analisisContrato, value); }

        //Capítulo VII- Inspecciones y Auditoría
        private AUD_ContenidoGenerico inspeccionAudito;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico InspeccionAudito { get => inspeccionAudito; set => SetProperty(ref inspeccionAudito, value); }


        public void Inicializa_RequisitosLegales()
        {
            RequisitosLegales = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                {
                    Titulo = "De la autorización de funcionamiento.",
                    IsHeader=true,
                    Capitulo = "6.1"
                },
                    new ContenidoPreguntas()
                {
                    Titulo = "El laboratorio fabricante posee permiso sanitario de funcionamiento o licencia sanitaria, autorizada por la autoridad reguladora del país.",
                    Criterio = "CRITICO",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    Articulo="6.1.1"
                },
            new ContenidoPreguntas()
               {
                   Titulo = "El permiso sanitario de funcionamiento o licencia de operación se encuentra vigente",
                   Criterio = "CRITICO",
                   LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
               },
            new ContenidoPreguntas()
               {
                   Titulo = "El permiso sanitario de funcionamiento o licencia de operación se encuentra colocado en un lugar visible al público",
                   Criterio = "MENOR",
                   LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
               }
                }
            };

        }
        public void Inicializa_ClasifActComerciales()
        {
            ClasifActComerciales = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
            {
                Titulo = "Adquisición de Materias Primas y Materiales",
                Criterio = "",
                IsHeader = true
            },
                    new ContenidoPreguntas()
            {
                Titulo = "Compra local?",
                Criterio = "",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
                {
                    Titulo = "Es importador?",
                Criterio = "",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Exigen certificado de análisis de del fabricante?",
                    Criterio = "Informativo",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Se encuentran disponibles los certificados de análisis?",
                    Criterio = "",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Es importador de:",
                    Criterio = "",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Producto terminado?",
                    Criterio = "",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Producto semielaborado?",
                    Criterio = "",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Producto a granel?",
                    Criterio = "",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Exigen certificado de análisis del fabricante?",
                    Criterio = "",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            new ContenidoPreguntas()
                {
                    Titulo = "Se encuentran disponibles los certificados de análisis?",
                    Criterio = "",
                    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                }
                }
            };

        }
        public void Inicializa_ClasifEstablecimiento()
        {
            ClasifEstablecimiento = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
            {
                Titulo = "Laboratorio Fabricante de:",
                Criterio = "",
                IsHeader = true
            },new ContenidoPreguntas()
            {
                Titulo = "Medicamentos Humanos?",
                Criterio = "",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Medicamentos Veterinarios?",
                Criterio = "",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Cosméticos?",
                Criterio = "",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Productos Naturales?",
                Criterio = "",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Productos Homeopáticos?",
                Criterio = "",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Otros indiquen",
                Criterio = "",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Fabrican y Analizan productos a tercero? Cuales de que empresa?. Anexar listado",
                Criterio = "CRÍTICO",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Qué tipo de acondicionamiento realizan?",
                Criterio = "Informativo",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Cuentan con contratos para el acondicionamiento y análisis de productos a terceros?",
                Criterio = "CRÍTICO",
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
                }
            };

        }
        public void Inicializa_AdminInfoGeneral()
        {
            AdminInfoGeneral = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {new ContenidoPreguntas()
            {
                Titulo = "Capitulo I - Administración e Información General",
                IsHeader = true,
            },
                    new ContenidoPreguntas()
            {
                Titulo = "A - Generalidades - Estructura Organizativa",                
                IsHeader = true,
            },
                    new ContenidoPreguntas()
            {
                Titulo = "El Regente Farmacéutico tiene el cargo de Jefe de Control de Calidad o de Producción? Especifique el cargo",
                Criterio = "C",
                Articulo="399",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El Regente Farmacéutico está presente al momento de la Auditoria?",
                Criterio = "C",
                Articulo="398",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "La empresa dispone de un organigrama general? (Anexar Copia)",
                Criterio = "INF",
                Articulo="397",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen organigramas específicos para las áreas de? (Anexar Copia)",
                Criterio = "INF",
                Articulo="397",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Producción" },
                    new ContenidoSubPreguntas(){ Nombre="Control de Calidad" },
                    new ContenidoSubPreguntas(){ Nombre="Gestión o Aseguramiento de la Calidad" },
                },
            },
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Producción",
            //    //PuntosMax = (decimal)0.16,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Control de Calidad",
            //    //PuntosMax = (decimal)0.16,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Gestión o Aseguramiento de la Calidad",
            //    //PuntosMax = (decimal)0.18,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            new ContenidoPreguntas()
            {
                Titulo = "Está vigente la Licencia de Operación?",
                Criterio = "C",
                Articulo="Ley #1 Art. 86",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El personal conoce los organigramas describiendo las líneas de Autoridad?",
                Criterio = "R",
                Articulo="397",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen manuales que describan las funciones y responsabilidades del personal, según su área específica de labores?",
                Criterio = "R",
                Articulo="400",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen manuales de procedimientos que describan las normas de higiene y comportamiento del personal según cada área?",
                Criterio = "R",
                Articulo="357, 407, 409",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Son del conocimiento del personal? (Verifique con la Capacitación)",
                Criterio = "R",
                Articulo = "409",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen programas de capacitación continua para el personal?",
                Criterio = "INF",
                Articulo="401",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existe evidencia escrita de la capacitación adquirida por el personal?",
                Criterio = "INF",
                Articulo="401",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existe evidencia escrita de capacitación específica para el personal que trabaja en áreas de riesgo de contaminación?",
                Criterio = "INF",
                Articulo="401",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Manejo de Materiales Tóxicos, Infecciosos o sensibilizantes" }
                },
            },
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Manejo de Materiales Tóxicos, Infecciosos o sensibilizantes",
            //    PuntosMax = (decimal)0.5,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            new ContenidoPreguntas()
            {
                Titulo = "Se encuentran las áreas técnicas (Producción, Control de Calidad y demás) separadas?",
                Criterio = "C",
                Articulo="413",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "La empresa dota de uniformes de trabajo a su personal según el área y función que desempeña?",
                Criterio = "C",
                Articulo="403",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen áreas controladas en la empresa que requieren que el ingreso del personal lo efectúe con condiciones específicas de uniformes y otros implementos?",
                Criterio = "C",
                Articulo="404",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El personal de Producción y Control de Calidad cumplen con las medidas higiénicas y la ropa protectora para ingresar a las áreas?",
                Criterio = "INF",
                Articulo="404, 407",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Los uniformes se conservan en adecuadas condiciones y estado de limpieza?",
                Criterio = "R",
                Articulo="403",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Los productos que se comercializan en el local poseen Registro Sanitario vigente? Anexe Listado",
                Criterio = "C",
                Articulo="Ley #1 Art. 41",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen productos en trámite de Registro Sanitario?",
                Criterio = "INF",
                Articulo="Ley #1 Art. 41",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "La empresa dispone de un Programa de Calificación de Proveedores? (Anexar Evidencia)",
                Criterio = "INF",
                Articulo="515",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            }
                }
            };

        }
        public void Inicializa_CondExtAlmacenas()
        {
            CondExtAlmacenas = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas()
            {
                Titulo = "Capítulo II - Almacenes",
                IsHeader=true,
            },
                    new ContenidoPreguntas()
            {
                Titulo = "A -- Condiciones Externas de los Almacenes",
                IsHeader=true,
            },
            new ContenidoPreguntas()
            {
                Titulo = "Son adecuadas las condiciones externas del local? (Ausencia de rajaduras, pintura descascarillada, filtraciones, crecimiento de moho) ",
                Criterio = "R",
                Articulo="360",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El área externa del local presenta riesgo mínimo de contaminación? (Terrenos limpios, Jardines tratados)",
                Criterio = "R",
                Articulo="361",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existe un sistema de control de Fauna nociva? Anexe registro de control, Listado de Productos empleados (Concentración del principio activo, número de registro sanitario, clasificación para la industria)",
                Criterio = "R",
                Articulo="362",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            }, 
                }
                };

        }
        public void Inicializa_CondIntAlmacenas()
        {
            CondIntAlmacenas = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas()
            {
                Titulo = "B -- Condiciones Internas de los Almacenes",
                IsHeader=true,
            },
            new ContenidoPreguntas()
            {
                Titulo = "El piso cumple con la característica de ser liso?",
                Criterio = "R",
                Articulo="415",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
            new ContenidoPreguntas()
            {
                Titulo = "El piso presenta rajaduras, agujeros, roturas, depresiones o desprendimiento de partículas?",
                Criterio = "R",
                Articulo="415",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El piso puede limpiarse fácilmente?",
                Criterio = "R",
                Articulo="415",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Las paredes son lisas y de fácil limpieza?",
                Criterio = "R",
                Articulo="415",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Presentan las paredes desprendimiento de pintura?",
                Criterio = "R",
                Articulo="415",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El techo es liso, está limpio y en buen estado?",
                Criterio = "R",
                Articulo="415",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El drenaje es de tamaño adecuado, limpio y no permite contracorriente?",
                Criterio = "R",
                Articulo="416",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El drenaje tiene tapa sanitaria?",
                Criterio = "R",
                Articulo="416",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
                }
            };

        }
        public void Inicializa_AreaRecepMateriaPrima()
        {
            AreaRecepMateriaPrima = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas()
            {
                Titulo = "C -- Areas de Recepción de Materia Prima",
                IsHeader=true,
            },
                    new ContenidoPreguntas()
            {
                Titulo = "Se encuentra Identificada con letrero, diseñada y equipada de forma que permita la limpieza de los productos antes de su almacenamiento?",
                Criterio = "R",
                Articulo="369, 370",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Es adecuada la iluminación?",
                Criterio = "R",
                Articulo="363",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Es adecuada la ventilación?",
                Criterio = "R",
                Articulo="363",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Se observa limpia y ordenada?",
                Criterio = "N",
                Articulo="366",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen procedimientos escritos para la recepción de materia prima?",
                Criterio = "C",
                Articulo="470",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen registros de entrada de la materia prima? (Verifique) ?",
                Criterio = "C",
                Articulo="470",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Son adecuados los documentos y formatos empleados para la recepción?",
                Criterio = "R",
                Articulo="470",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El área está protegida de las inclemencias del tiempo?",
                Criterio = "R",
                Articulo="421",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "La materia prima está etiquetada con la siguiente información?",
                Criterio = "N",
                Articulo="442",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Nombre" },
                    new ContenidoSubPreguntas(){ Nombre="Número de lote del proveedor" },
                    new ContenidoSubPreguntas(){ Nombre="Estatus de la materia prima" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de expiración o fecha de reanálisis" },
                },
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen criterios de aceptación o rechazo de la materia prima?",
                Criterio = "N",
                Articulo="470",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "La empresa cuenta con base de datos sistematizada?",
                Criterio = "N",
                Articulo="442",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Al momento de la recepción, la empresa cuenta con un sistema interno de codificación de la materia prima?",
                Criterio = "N",
                Articulo="366",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El empleo de esta numeración permite la identificación de la materia prima durante toda su utilización? (Trazabilidad) ",
                Criterio = "N",
                Articulo="442",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Todas las materias primas son sometidas a análisis de control de calidad de acuerdo con métodos de análisis apropiados?",
                Criterio = "N",
                Articulo="444",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Cuentan con procedimiento para el muestreo de Materia Prima?",
                Criterio = "C",
                Articulo="471",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existe área especial, identificada para el muestreo de la Materia Prima?",
                Criterio = "N",
                Articulo="423",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "La persona encargada del muestreo de la Materia Prima pertenece al Laboratorio de Control de Calidad?",
                Criterio = "N",
                Articulo="491",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Todos los productos en estatus de cuarentena están colocados sobre tarimas?",
                Criterio = "N",
                Articulo="371",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            }
            };

        }
        public void Inicializa_AlmacenMateriaPrima()
        {
            AlmacenMateriaPrima = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>() {
            new ContenidoPreguntas()
            {
                Titulo = "CH -- Almacén de Materia Prima",
                IsHeader=true,
            },new ContenidoPreguntas()
            {
                Titulo = "El almacén de Materia Prima se encuentra identificado y delimitado?",
                Criterio = "N",
                Articulo="366",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Solo el personal autorizado puede ingresar a esta área?",
                Criterio = "R",
                Articulo="406",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Todas las Materias Primas se almacenan sobre tarimas, arma rápidos o andamios?",
                Criterio = "N",
                Articulo="371",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Las Materias Primas en estatus de cuarentena son identificadas con su correspondiente etiqueta?",
                Criterio = "N",
                Articulo="442, 467",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Cuenta con un área destinada para el almacenamiento de Materias Primas Inflamables (Alcohol, Esencias) separada, debidamente delimitada, identificada, ventilada; con equipos necesarios para sofocar siniestros o accidentes tales como:",
                Criterio = "C",
                Articulo="420, 422",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Extintores vigentes" },
                    new ContenidoSubPreguntas(){ Nombre="Mangueras" },
                    new ContenidoSubPreguntas(){ Nombre="Detector de humo" },
                    new ContenidoSubPreguntas(){ Nombre="Tanque de arena con su pala o Kit de seguridad ( Cuando Aplique)" },
                },
            },
            new ContenidoPreguntas()
            {
                Titulo = "De tratarse de Alcohol, Los tanques son colocados sobre estructuras separados del piso?",
                Criterio = "N",
                Articulo="420",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existe solo Materia Prima inflamable en esta área?",
                Criterio = "R",
                Articulo="420",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            // new ContenidoPreguntas()
            // {
            //     Titulo = "El área está protegida de las inclemencias del tiempo?",
            //     Criterio = "R",
            //     Articulo="421",
            //     LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            // },
            new ContenidoPreguntas()
            {
                Titulo = "Existen reactivos del Laboratorio de Control de Calidad en esta área?",
                Criterio = "N",
                Articulo="419",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
            },
            new ContenidoPreguntas()
            {
                Titulo = "Se dispone de procedimiento escrito para el almacenamiento de la materia prima?",
                Criterio = "C",
                Articulo="470",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen ductos o tuberías expuestas en el almacén?",
                Criterio = "INF",
                Articulo="430",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "En la Etiqueta de identificación de Materia Prima Aprobada, se detalla:",
                Criterio = "C",
                Articulo="442, 467",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Nombre del Producto" },
                    new ContenidoSubPreguntas(){ Nombre="Número de Lote del Proveedor" },
                    new ContenidoSubPreguntas(){ Nombre="Cantidad aprobada" },
                    new ContenidoSubPreguntas(){ Nombre="Nombre del proveedor y país de procedencia" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de expiración o vencimiento" },
                    new ContenidoSubPreguntas(){ Nombre="Número de Análisis" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de Análisis" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de Re-Análisis" },
                    new ContenidoSubPreguntas(){ Nombre="Número de entrada al almacén" },
                    new ContenidoSubPreguntas(){ Nombre="Total de recipientes aprobados" },
                },
            },
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Nombre del Producto",
            //    PuntosMax = (decimal)0.2,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Número de Lote del Proveedor",
            //    PuntosMax = (decimal)0.2,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Cantidad aprobada",
            //    PuntosMax = (decimal)0.2,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Nombre del proveedor y país de procedencia",
            //    PuntosMax = (decimal)0.2,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Fecha de expiración o vencimiento",
            //    PuntosMax = (decimal)0.2,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Número de Análisis",
            //    PuntosMax = (decimal)0.2,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Fecha de Análisis",
            //    PuntosMax = (decimal)0.2,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Fecha de Re-Análisis",
            //    PuntosMax = (decimal)0.2,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Número de entrada al almacén",
            //    PuntosMax = (decimal)0.2,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Total de recipientes aprobados",
            //    PuntosMax = (decimal)0.2,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            new ContenidoPreguntas()
            {
                Titulo = "Están identificados los ductos o tuberías expuestas?",
                Criterio = "INF",
                Articulo="430",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Las Materias Primas almacenadas se localizan e inspeccionan fácilmente, ya que el almacén está organizado y codificado por áreas?",
                Criterio = "R",
                Articulo="366",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existe un programa que garantice la integridad de los productos almacenados mediante: (Verifique)?",
                Criterio = "R",
                Articulo="491",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Control o repetición de análisis de Control de Calidad" },
                    new ContenidoSubPreguntas(){ Nombre="Verificación física de los envases" },
                },
            },
            new ContenidoPreguntas()
            {
                Titulo = "Las Materias Primas Rechazadas:",
                Criterio = "C",
                Articulo="454",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Poseen etiquetas que indiquen su estatus" },
                    new ContenidoSubPreguntas(){ Nombre="Se encuentran almacenadas separadamente" },
                    new ContenidoSubPreguntas(){ Nombre="Identificadas y en un área restringida" },
                },
            },
            new ContenidoPreguntas()
            {
                Titulo = "En el almacén de Materia Prima aprobada, existen otros materiales no relacionados con el área? (Materiales en Desuso o Equipos Dañados). Descríbalos:",
                Criterio = "R",
                Articulo="420",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "La Materia Prima que se emplea en la fabricación, se despacha respetándose el Sistema (FIFO) primera que entra, primera que sale? Primera que sale o primera fecha de expiración primera en salir (FEFO)",
                Criterio = "C",
                Articulo="366",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen recipientes para la recolección de basura?",
                Criterio = "R",
                Articulo="374-457",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Los recipientes para la recolección de la basura, se encuentran tapados?",
                Criterio = "R",
                Articulo="374-457",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Estos recipientes, están ubicados en lugares apropiados?",
                Criterio = "R",
                Articulo="374-457",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Los recipientes de recolección de la basura se vacían a intervalos frecuentes?",
                Criterio = "R",
                Articulo="374-457",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            }
        };

        }
        public void Inicializa_AlmacenMatAcondicionamineto()
        {
            AlmacenMatAcondicionamineto = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>() {
            new ContenidoPreguntas()
            {
                Titulo = "D -- Area de Almacenamiento de Materiales de Acondicionamiento, Empaque y Envase",
                IsHeader=true,
            },new ContenidoPreguntas()
            {
                Titulo = "Está el área Identificada, delimitada o separada?",
                Criterio = "R",
                Articulo="425",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "La calidad de la iluminación es adecuada en esta área?",
                Criterio = "R",
                Articulo="363",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "La ventilación es adecuada?",
                Criterio = "R",
                Articulo="363",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El área se observa limpia y ordenada?",
                Criterio = "N",
                Articulo="363",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existe procedimiento para la recepción de los materiales de acondicionamiento, empaque y envase? Cuentan con criterios de aceptación o rechazo de los mismos?",
                Criterio = "R",
                Articulo="438, 470",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Todos los materiales sin excepción son sometidos a verificación por Control de Calidad?",
                Criterio = "N",
                Articulo="438, 444",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Son adecuados los documentos o formatos empleados para la recepción? (Nombre, Número de Lote y Fecha de Expiración)",
                Criterio = "R",
                Articulo="470",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Todos los materiales tienen adherida la etiqueta definiendo el estatus de Cuarentena?",
                Criterio = "N",
                Articulo="438, 467",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Al momento de la recepción de los materiales se les asigna un número de registro de entrada?",
                Criterio = "N",
                Articulo="442",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
            },
            new ContenidoPreguntas()
            {
                Titulo = "Con el número asignado, se pueden identificar los materiales durante su utilización? (Trazabilidad)",
                Criterio = "N",
                Articulo="442",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existe un área delimitada e identificada para el muestreo del material de acondicionamiento, empaque y envase?",
                Criterio = "N",
                Articulo="423",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El personal destinado al muestreo de materiales labora en Control de Calidad?",
                Criterio = "N",
                Articulo="491",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Todos los productos en estatus de cuarentena están colocados sobre tarimas? ",
                Criterio = "N",
                Articulo="371",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El almacén de materiales de acondicionamiento, envase y empaque está construido con materiales adecuados (Que faciliten la Limpieza), en:" ,
                Criterio = "C",
                Articulo="425",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Paredes" },
                    new ContenidoSubPreguntas(){ Nombre="Piso" },
                    new ContenidoSubPreguntas(){ Nombre="Techo" },
                },
            },
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Paredes",
            //    PuntosMax = (decimal)0.66,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Piso",
            //    PuntosMax = (decimal)0.66,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Techo",
            //    PuntosMax = (decimal)0.68,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            new ContenidoPreguntas()
            {
                Titulo = "Se observan almacenados otros enseres diferentes a los materiales de acondicionamiento, empaque y envase (Materiales que no pertenecen al área o que se encuentran en desuso? Descríbalos",
                Criterio = "R",
                Articulo="425",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Todos los materiales que salen de este almacén cumplen con el sistema FIFO o FEFO?",
                Criterio = "C",
                Articulo="366",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen recipientes para la recolección de la basura?",
                Criterio = "R",
                Articulo="457",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Los recipientes de la recolección de la basura se vacían frecuentemente?",
                Criterio = "R",
                Articulo="457",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Los materiales de acondicionamiento, envase y empaque, detallan en su etiqueta de identificación lo siguiente?" ,
                Criterio = "C",
                Articulo="442, 448",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Código o número interno de entrada al almacén" },
                    new ContenidoSubPreguntas(){ Nombre="Número de Lote (Cuando Aplique)" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de aprobación por Control de Calidad" },
                    new ContenidoSubPreguntas(){ Nombre="Cantidad Aprobada" },
                    new ContenidoSubPreguntas(){ Nombre="Total de Bultos Aprobados" },
                },
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existe procedimiento escrito para el almacenamiento de los Materiales de Acondicionamiento, envase y empaque? (Verifique cumplimiento)",
                Criterio = "C",
                Articulo="470",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen ductos o tuberías expuestas en este almacén?",
                Criterio = "INF",
                Articulo="430",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
            },
            new ContenidoPreguntas()
            {
                Titulo = "Se identifican los ductos y tuberías expuestas?",
                Criterio = "INF",
                Articulo="430",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
            },
            new ContenidoPreguntas()
            {
                Titulo = "Todos los materiales de acondicionamiento, envase y empaque se encuentran colocados sobre tarimas, armarrápidos o andamios?",
                Criterio = "N",
                Articulo="371",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
            },
            new ContenidoPreguntas()
            {
                Titulo = "Los materiales de acondicionamiento, envase y empaque en estatus de cuarentena se identifican con la respectiva etiqueta?",
                Criterio = "N",
                Articulo="442, 448",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
            },
            new ContenidoPreguntas()
            {
                Titulo = "El almacén de material de acondicionamiento, envase y empaque dispone de un área delimitada e identificada para almacenar las etiquetas?",
                Criterio = "N",
                Articulo="425",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
            },
            new ContenidoPreguntas()
            {
                Titulo = "El área donde se almacenan las etiquetas, permanece bajo llave?",
                Criterio = "N",
                Articulo="425",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
            },
            new ContenidoPreguntas()
            {
                Titulo = "Control de Calidad es el encargado de liberar de estatus (Cuarentena, aprobado o rechazado) los materiales de Acondicionamiento, envase y empaque?",
                Criterio = "C",
                Articulo="444",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
            },
            new ContenidoPreguntas()
            {
                Titulo = "Todo el material de acondicionamiento, envase y empaque aprobado posee etiqueta indicando su estatus?",
                Criterio = "C",
                Articulo="442",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
            },
            new ContenidoPreguntas()
            {
                Titulo = "Los bultos de material de acondicionamiento, envase y empaque se encuentran estibados de manera segura en tarimas, separadas del techo, de manera que facilite la limpieza del área?",
                Criterio = "R",
                Articulo="371",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
            },
            }
            };

        }
        public void Inicializa_RecepProductoTerminado()
        {
            RecepProductoTerminado = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>() {
            new ContenidoPreguntas()
            {
                Titulo = "E -- Recepción de Producto Terminado (De Producción al Almacén)",
                IsHeader=true,
            },new ContenidoPreguntas()
            {
                Titulo = "El área está identificada y delimitada?",
                Criterio = "R",
                Articulo="366",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "La calidad de la iluminación es adecuada?",
                Criterio = "R",
                Articulo="363",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "La ventilación es adecuada?",
                Criterio = "R",
                Articulo="412",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Son adecuadas las condiciones de?",
                Criterio = "C",
                Articulo="371, 415",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Pisos" },
                    new ContenidoSubPreguntas(){ Nombre="Techos" },
                    new ContenidoSubPreguntas(){ Nombre="Paredes" },
                    new ContenidoSubPreguntas(){ Nombre="Tarimas" },
                },
            },
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Pisos",
            //    PuntosMax = (decimal)0.5,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Techos",
            //    PuntosMax = (decimal)0.5,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Paredes",
            //    PuntosMax = (decimal)0.5,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            //new ContenidoPreguntas()
            //{
            //    Titulo = "Tarimas",
            //    PuntosMax = (decimal)0.5,
            //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            //},
            new ContenidoPreguntas()
            {
                Titulo = "Existen procedimientos escritos para el recibo de productos terminados?",
                Criterio = "C",
                Articulo="470",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Existen criterios para la aceptación o rechazo de los productos terminados?",
                Criterio = "R",
                Articulo="470",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Son adecuados los documentos o formatos empleados para la recepción? (Nombre, Número de Lote y Fecha de Expiración)",
                Criterio = "R",
                Articulo="468",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Todos los productos terminados tienen su etiqueta de cuarentena?",
                Criterio = "N",
                Articulo="438, 452",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "Se emplea algún número diferente al número de lote, como registro de recepción? ",
                Criterio = "N",
                Articulo="366",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El producto terminado en estatus de cuarentena, es liberado sólo por Control de Calidad?",
                Criterio = "N",
                Articulo="438",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },
            new ContenidoPreguntas()
            {
                Titulo = "El producto terminado es colocado sobre tarimas?",
                Criterio = "N",
                Articulo="371",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
            },      
                }

        };

        }
        public void Inicializa_AlmacenProductoTerminado()
        {
            AlmacenProductoTerminado = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                Titulo = "E.1 -- Almacén de Productos Terminados",
                IsHeader= true,
                },
                new ContenidoPreguntas()
                {
                Titulo = "Temperatura",
                Criterio = "",
                Articulo="",
                PuntosMax = 0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Humedad",
                Criterio = "",
                Articulo="",
                PuntosMax = 0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El almacén de producto terminado está debidamente identificado y delimitado?",
                Criterio = "C",
                Articulo="413",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se Observa limpio y ordenado?",
                Criterio = "R",
                Articulo="420",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se encuentran identificados los rangos de la Temperatura y Humedad Relativa?",
                Criterio = "C",
                Articulo="367",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se lleva registro cronológico de la temperatura y Humedad Relativa? (Verifique)",
                Criterio = "R",
                Articulo="367",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se mantiene un sistema de registro de ingreso y control de existencias del producto terminado?",
                Criterio = "R",
                Articulo="470",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se incluye en el sistema de registro y control de los despachos, la correlación entre la fecha de ingreso / fecha de egreso y la observación de la fecha de vencimiento?",
                Criterio = "R",
                Articulo="469",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Todo Producto terminado se encuentra almacenado sobre tarimas o estanterías separadas de la pared (que permita la limpieza y circulación del personal)? ",
                Criterio = "C",
                Articulo="371",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El Producto Terminado se almacena conservando el orden y seguridad, evitando posibles confusiones en su control y despacho, así como accidentes en su manipulación?",
                Criterio = "R",
                Articulo="420",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los Productos Terminados se observan estibados con seguridad?",
                Criterio = "C",
                Articulo="371",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                // new ContenidoPreguntas()
                // {
                // Titulo = "Los Productos Terminados se observan estibados con seguridad?",
                // Criterio = "C",
                // Articulo="371",
                // LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                // },
                new ContenidoPreguntas()
                {
                Titulo = "El almacén está protegido contra la entrada de aves, insectos, roedores u otros animales?",
                Criterio = "N",
                Articulo="411",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos para el control o eliminación de la fauna nociva?",
                Criterio = "N",
                Articulo="470, 411",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un programa de control contra la proliferación de fauna nociva?",
                Criterio = "R",
                Articulo="411",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe suficiente equipo (Extintores cargados, mangueras, otros) para combatir incendios o un sistema automático contra incendios?",
                Criterio = "N",
                Articulo="411",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen indicaciones en las áreas para el personal que requiere evacuar el almacén en caso de emergencia? (Rutas de evacuación)",
                Criterio = "N",
                Articulo="358",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los implementos necesarios para atender una emergencia están?",
                Criterio = "R",
                Articulo="358",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Bien Ubicados" },
                    new ContenidoSubPreguntas(){ Nombre="Claramente Identificados" },
                    new ContenidoSubPreguntas(){ Nombre="Accesibles al Personal" },
                },
                },
            }
        };

        }
        public void Inicializa_ProductoDevueltoRechazado()
        {
            ProductoDevueltoRechazado = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                Titulo = "F -- Area de Productos Devueltos y/o Rechazados",
                IsHeader= true,
                },new ContenidoPreguntas()
                {
                Titulo = "Los productos devueltos o rechazados se encuentran en un área identificada y asegurada?",
                Criterio = "N",
                Articulo="454",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cuentan con procedimiento escrito para el manejo de devoluciones y/o rechazo de productos?",
                Criterio = "C",
                Articulo="470",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se identifican los productos con su correspondiente etiqueta, indicando el estatus de rechazo o devolución?",
                Criterio = "C",
                Articulo="467",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se registran las causas de las devoluciones y rechazos?",
                Criterio = "N",
                Articulo="455",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Control de Calidad participa activamente en las decisiones adoptadas en las Devoluciones y Rechazos?",
                Criterio = "C",
                Articulo="454",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }
        };

        }
        public void Inicializa_DistProductoTerminado()
        {
            DistProductoTerminado = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                Titulo = "G -- Distribución de Productos Terminados",
                IsHeader= true,
                },new ContenidoPreguntas()
                {
                Titulo = "Solo los productos aprobados por el Laboratorio de Control de Calidad son autorizados para su distribución?",
                Criterio = "C",
                Articulo="491",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos que regulen la distribución primaria de los productos?",
                Criterio = "C",
                Articulo="470",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El registro de distribución primaria del producto se conserva hasta un año después de la fecha de vencimiento del lote?",
                Criterio = "R",
                Articulo="469",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Contiene el registro de distribución la información siguiente?",
                Criterio = "N",
                Articulo="469",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Nombre, presentación y forma farmacéutica del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Número de lote o número de control" },
                    new ContenidoSubPreguntas(){ Nombre="Nombre y dirección del consignatario" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha y cantidad despachada" },
                    new ContenidoSubPreguntas(){ Nombre="Número de factura o documento de embarque según sea el caso" },
                },
                },
            }

        };

        }
        public void Inicializa_ManejoQuejaReclamos()
        {
            ManejoQuejaReclamos = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                Titulo = "H -- Manejo de quejas y reclamos de productos comercializados",
                IsHeader= true,
                },new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos en los cuales la empresa plasme la política de manejo de quejas y reclamos de productos comercializados?",
                Criterio = "N",
                Articulo="384",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se registran y archivan las decisiones y medidas adoptadas por la empresa como resultado de una queja o reclamo?",
                Criterio = "R",
                Articulo="384",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Participa activamente el laboratorio de Control de Calidad en las investigaciones de una queja o reclamo?",
                Criterio = "C",
                Articulo="384, 508",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se comunica al Regente Farmacéutico y Gerente de la empresa sobre los resultados de la investigación de una queja o reclamo?",
                Criterio = "C",
                Articulo="506",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }
        };

        }
        public void Inicializa_RetiroProcMercado()
        {
            RetiroProcMercado = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                Titulo = "I -- Retiro de Productos del Mercado",
                IsHeader= true,
                },new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos para el retiro de los productos del mercado?",
                Criterio = "R",
                Articulo="507",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se incluye la comunicación inmediata a la Autoridad Sanitaria correspondiente sobre la causa del retiro del producto?",
                Criterio = "C",
                Articulo="510",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Hay personas responsables designadas para la coordinación y ejecución del procedimiento del retiro?",
                Criterio = "R",
                Articulo="381",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los registros de distribución primarios quedan disponibles para la pronta acción de retiro del mercado?",
                Criterio = "R",
                Articulo="511",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Contienen estos registros la información necesaria que permita el rastreo y determinación de los destinatarios resultantes de la distribución primaria?",
                Criterio = "N",
                Articulo="511",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Es adecuada y segura el área para el almacenamiento de los productos retirados del mercado mientras aguardan su destino?",
                Criterio = "C",
                Articulo="373",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen informes finales sobre el balance entre cantidades entregadas y cantidades recuperadas del producto?",
                Criterio = "C",
                Articulo="512",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen Informes de los retiros de productos del mercado y sus causas? (Verifique)",
                Criterio = "INF",
                Articulo="386",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "En el informe final se contempla el destino de los productos retirados del mercado?",
                Criterio = "R",
                Articulo="512",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }

        };

        }
        public void Inicializa_SistemaInstAgua()
        {
            SistemaInstAgua = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                    Titulo = "Capitulo III - Sistemas Críticos de Apoyo",
                    IsHeader = true,
                },
                    new ContenidoPreguntas()
                {
                Titulo = "3.1 -- Sistemas e Instalaciones de Agua",
                IsHeader= true,
                },new ContenidoPreguntas()
                {
                Titulo = "La empresa cuenta con un piso técnico delimitado e Identificado, en el cual se localizan los sistemas críticos de apoyo?",
                Criterio = "C",
                Articulo="436",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El abastecimiento de agua a la planta proviene de:",
                Criterio = "N",
                Articulo="436",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Servicio Municipal" },
                    new ContenidoSubPreguntas(){ Nombre="Pozo Colectivo" },
                    new ContenidoSubPreguntas(){ Nombre="Pozo Propio" },
                },
                },
                new ContenidoPreguntas()
                {
                Titulo = "Sistemas de purificación del agua?",
                Criterio = "INF",
                Articulo="436",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Hay cisternas o tanques para el almacenamiento de agua? De qué material está construido? Dónde está ubicado? Tiempo de almacenamiento del agua? De qué material está revestido el tanque de reserva internamente? Qué capacidad tiene el tanque?",
                Criterio = "INF",
                Articulo="436",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se hacen los muestreos y análisis correspondientes al agua que será empleada en los procesos de producción? con qué frecuencia?",
                Criterio = "C",
                Articulo="437",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un procedimiento escrito para el muestreo del agua? Se describen los puntos de muestreo?",
                Criterio = "N",
                Articulo="437",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se lleva un registro cronológico del muestreo del agua?",
                Criterio = "N",
                Articulo="437",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los controles que se le hacen al agua son:" ,
                Criterio = "C",
                Articulo="437",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Químicos" },
                    new ContenidoSubPreguntas(){ Nombre="Físicos" },
                    new ContenidoSubPreguntas(){ Nombre="Microbiológicos" },
                    new ContenidoSubPreguntas(){ Nombre="Conductividad Eléctrica" },
                },
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se llevan los registros de estos resultados?",
                Criterio = "C",
                Articulo="437",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se hace limpieza a los tanques de almacenamiento o cisternas? Existe procedimiento?",
                Criterio = "C",
                Articulo="436",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen registros de esta actividad? (Verifique)",
                Criterio = "N",
                Articulo="437",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Las tuberías que conducen el agua potable, externamente se observan en buen estado? De qué material están construidas?",
                Criterio = "R",
                Articulo="436",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El flujo de agua potable hacia la planta, se hace bajo una constante y continua presión positiva y dentro de un sistema libre de defectos (libre de fugas)?",
                Criterio = "R",
                Articulo="",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El agua potable se emplea como fuente de alimentación para los sistemas de producción de agua purificada? (No observándose puntos muertos en las tuberías)",
                Criterio = "R",
                Articulo="",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }
        };

        }
        public void Inicializa_OsmosisInversa()
        {
            OsmosisInversa = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                    Titulo = "3.1.1 Osmosis Inversa",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "El agua de abastecimiento de Ósmosis Inversa es tratada previamente? Cómo se trata?",
                Criterio = "INF",
                Articulo="436",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Existe personal capacitado y responsable para operar el Sistema?",
                Criterio = "R",
                Articulo="436",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Existe Manual de Operación del Sistema? Es utilizado? ",
                Criterio = "R",
                Articulo="436",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Existe un tanque de almacenamiento para el agua tratada por Ósmosis Inversa?",
                Criterio = "R",
                Articulo="436",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Se le hace algún tratamiento para evitar la contaminación bacteriológica (radiación UV, filtración, ozonización, etc.) ",
                Criterio = "C",
                Articulo="437",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Con qué frecuencia?",
                Criterio = "R",
                Articulo="437",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Existen registros?",
                Criterio = "R",
                Articulo="437",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "La conducción de agua se hace a través de tuberías? Detalle el tipo de materiales",
                Criterio = "N",
                Articulo="436",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "El agua producida es utilizada como materia prima para productos no estériles?",
                Criterio = "INF",
                Articulo="436",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "El agua por Ósmosis Inversa es liberada una vez que Control de Calidad aprueba su utilización?",
                Criterio = "C",
                Articulo="437",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Le hacen lavado al sistema de Ósmosis Inversa? Cómo se hace? Cuál es la frecuencia? Existen Registros?",
                Criterio = "N",
                Articulo="436",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos para la sanitización del sistema?",
                Criterio = "R",
                Articulo="436",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Se hace mantenimiento preventivo a los equipos del sistema? Cuál es la frecuencia? Existen registros?",
                Criterio = "R",
                Articulo="436",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Existe algún tipo de filtro en el sistema? Cuál? (Detalle)",
                Criterio = "INF",
                Articulo="436",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Se hace sanitización a los medios filtrantes?",
                Criterio = "INF",
                Articulo="437",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Cuál es la frecuencia?",
                Criterio = "INF",
                Articulo="437",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Existen registros?",
                Criterio = "R",
                Articulo="437",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos para la sanitización de los medios filtrantes? Son utilizados? (Verifique) ",
                Criterio = "R",
                Articulo="437",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                 new ContenidoPreguntas()
                {
                Titulo = "Está validado el sistema de Ósmosis Inversa?",
                Criterio = "R",
                Articulo="479",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }
        };

        }
        public void Inicializa_SistemaDeIonizacion()
        {
            SistemaDeIonizacion = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                    Titulo = "3.1.2 Sistema de Deionizacion",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "El agua que abastece al sistema de deionización es previamente tratada? Cómo se hace? (Describa) ",
                Criterio = "INF",
                Articulo="436",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe personal capacitado y responsable para operar el sistema? (Verifique capacitación) ",
                Criterio = "R",
                Articulo="436",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un manual de procedimiento escrito para la operación del sistema? El operario dispone de copia autorizada de este manual?",
                Criterio = "R",
                Articulo="436",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Con que frecuencia son regeneradas las resinas? (Detalle)",
                Criterio = "R",
                Articulo="437",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen registros cronológicos de la frecuencia de regeneración?",
                Criterio = "N",
                Articulo="437",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Si el agua que abastece el sistema de deionización es clorada, existe un sistema para retirar el cloro antes de que ingrese al de ionizador? (Descríbalo brevemente) ",
                Criterio = "N",
                Articulo="437",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe algún tratamiento empleado para evitar la contaminación bacteriológica (radiación UV, filtración ozonización, etc.)? Detalle el tratamiento",
                Criterio = "C",
                Articulo="437",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Detalle cuáles, frecuencia,y si existen registros actualizados? (Verifique) ",
                Criterio = "N",
                Articulo="437",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El agua deionizada se transporta por tuberías?",
                Criterio = "INF",
                Articulo="436",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se hace sanitización al sistema de conducción de agua? (Verifique) ",
                Criterio = "N",
                Articulo="436",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Describa como se sanitiza. Frecuencia. Verificar registros",
                Criterio = "N",
                Articulo="436",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos para la Sanitización del Sistema?",
                Criterio = "R",
                Articulo="437, 470",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se observa que se cumplen estos procedimientos?",
                Criterio = "R",
                Articulo="436",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se hace mantenimiento preventivo en los equipos que conforman todas las partes del sistema?",
                Criterio = "R",
                Articulo="437",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen registros de este mantenimiento? (Verifique frecuencia)",
                Criterio = "INF",
                Articulo="437",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe algún filtro en el Sistema? Detalle cuál?",
                Criterio = "INF",
                Articulo="436",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se hace sanitización a los medios filtrantes?",
                Criterio = "INF",
                Articulo="437",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Con que frecuencia?",
                Criterio = "INF",
                Articulo="437",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen Registros? (Verifique)",
                Criterio = "R",
                Articulo="437",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos para la sanitización de los medios filtrantes? Son utilizados? (Verifique)",
                Criterio = "C",
                Articulo="437, 470",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen registros cronológicos del cambio de los medios filtrantes?",
                Criterio = "R",
                Articulo="437",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El agua por Deionización es liberada una vez que Control de Calidad aprueba su utilización? ",
                Criterio = "C",
                Articulo="437",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El Sistema de purificación de agua está validado? Existen registros?",
                Criterio = "R",
                Articulo="479",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }
        };

        }
        public void Inicializa_CalibraVerifEquipo()
        {
            CalibraVerifEquipo = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                    Titulo = "3.2 Calibraciones y Verificaciones de Equipo",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "La Empresa cuenta con un Departamento de Calibración y Verificación de Equipo? (Cuando Aplique) ",
                Criterio = "R",
                Articulo="431",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Este Departamento dispone del equipo e instrumentos necesarios para efectuar las Calibraciones y Verificaciones, Anexe listados? (Cuando Aplique)",
                Criterio = "N",
                Articulo="431, 483",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos para efectuar las calibraciones y verificaciones de los equipos?",
                Criterio = "R",
                Articulo="431, 468",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe cronograma establecido para la calibración de los equipos? Existen registros?",
                Criterio = "N",
                Articulo="431, 483",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cada que tiempo se envían los patrones para su rectificación (ver cronograma de actividades). Cuando Aplique A dónde son enviados? ",
                Criterio = "R",
                Articulo="431, 483",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe documentación que indica que el equipo está apto para su utilización? (Verificar certificaciones) ",
                Criterio = "N",
                Articulo="483",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }
        };

        }
        public void Inicializa_Validaciones()
        {
            Validaciones = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                    Titulo = "3.3 Validaciones",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "La empresa cuenta con un Plan Maestro de Validación? ",
                Criterio = "C",
                Articulo="479",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Este Departamento está integrado por personal técnico altamente calificado?",
                Criterio = "C",
                Articulo="399",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "La empresa cuenta con un protocolo de Validación? ",
                Criterio = "C",
                Articulo="479",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Qué procesos son validados?",
                Criterio = "N",
                Articulo="479",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Sistemas Críticos de Apoyo" },
                    new ContenidoSubPreguntas(){ Nombre="Sistema digitalizado" },
                    new ContenidoSubPreguntas(){ Nombre="Equipos de Producción (Calificación)" },
                    new ContenidoSubPreguntas(){ Nombre="Procedimientos de Limpieza" },
                    new ContenidoSubPreguntas(){ Nombre="Métodos Analíticos" },
                },
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen registro actualizados de las Validaciones efectuadas? (Verifique) ",
                Criterio = "C",
                Articulo="479",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }
        };

        }
        public void Inicializa_MantAreaEquipos()
        {
            MantAreaEquipos = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                    Titulo = "3.4 Mantenimientos de áreas y equipos",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "Existe una sección encargada del mantenimiento de las áreas y los equipos? ",
                Criterio = "R",
                Articulo="427",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un procedimiento escrito para el mantenimiento programado de edificios e instalaciones? ",
                Criterio = "R",
                Articulo="410",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen programas para el mantenimiento de las áreas?",
                Criterio = "INF",
                Articulo="410",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un almacén de herramientas y partes de equipos?",
                Criterio = "N",
                Articulo="427",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El almacén de herramientas o área de mantenimiento está alejado de las áreas de producción?",
                Criterio = "N",
                Articulo="427",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Las tuberías están identificadas?",
                Criterio = "R",
                Articulo = "430",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen extractores de polvo en la empresa? (Cuando aplique) ",
                Criterio = "INF",
                Articulo = "102",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                }
            }
        };

        }
        public void Inicializa_AreaProdCondExternas()
        {
            AreaProdCondExternas = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                    Titulo = "Capítulo IV - Areas de Producción",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                    Titulo = "4.1 Generalidades",
                    IsHeader = true,
                },
                     new ContenidoPreguntas()
                {
                    Titulo = "4.1A Condiciones Externas",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "Los alrededores del edificio están limpios? ",
                Criterio = "R",
                Articulo="411",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe riesgo de contaminación de materiales y productos en el área? ",
                Criterio = "C",
                Articulo="410",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "La instalación es sólida, facilita la limpieza y mantenimiento? ",
                Criterio = "N",
                Articulo="410",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe protección contra la entrada de roedores, insectos, aves u otros animales a las áreas de producción?",
                Criterio = "R",
                Articulo="411",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }
        };

        }
        public void Inicializa_AreaProdCondInternas()
        {
            AreaProdCondInternas = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                 new ContenidoPreguntas()
                {
                    Titulo = "4.1B Condiciones Internas",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "Las áreas productivas están limpias?",
                Criterio = "R",
                Articulo="415",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los techos, paredes y pisos están en buen estado?",
                Criterio = "R",
                Articulo="415",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un procedimiento escrito de limpieza para el área?",
                Criterio = "R",
                Articulo="415",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se prohíbe ingerir alimentos y fumar en sectores productivos? Existen rótulos? ",
                Criterio = "C",
                Articulo="404",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se cumple con esta prohibición?",
                Criterio = "N",
                Articulo="404",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen vestidores para damas y caballeros?",
                Criterio = "N",
                Articulo="426",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen sanitarios próximos al área de producción en cantidad suficiente?",
                Criterio = "INF",
                Articulo="426",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los sanitarios están limpios equipados con jabón, papel toalla o secadores con aire caliente? ",
                Criterio = "N",
                Articulo="426",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El manejo de desperdicios y otros desechos, dentro y fuera del edificio y de las inmediaciones se hace en forma segura y sanitaria? ",
                Criterio = "N",
                Articulo="374",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "La empresa dispone de un comedor separado de las otras áreas? ",
                Criterio = "INF",
                Articulo="426",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "La empresa cuenta con procedimiento y programa para la limpieza de áreas auxiliares (vestidores, baños, comedor)? ",
                Criterio = "N",
                Articulo="426",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se prohíbe el ingreso a las áreas de producción a personas vestidas inadecuadamente? ",
                Criterio = "N",
                Articulo="406",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                }
        };

        }
        public void Inicializa_AreaOrganizaDocumentacion()
        {
            AreaOrganizaDocumentacion = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                 new ContenidoPreguntas()
                {
                    Titulo = "4.2 Organización y Documentación",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "Quién es el responsable de dirigir la producción? Qué profesión tiene?",
                Criterio = "C",
                Articulo="399",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Posee capacitación adecuada para el desempeño de sus funciones? (Verifique capacitación- Por actividad)",
                Criterio = "C",
                Articulo="401",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se documenta la capacitación que se realiza? (Ver Registro)",
                Criterio = "R",
                Articulo="401",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un programa de capacitación para el personal de primer ingreso al área de producción? ",
                Criterio = "R",
                Articulo="401",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe instructivo o procedimiento para que el personal que manifiesta lesiones en su piel, enfermedades o lesiones abiertas en la superficie del cuerpo que puedan afectar la calidad de los productos lo reporte? ",
                Criterio = "C",
                Articulo="409",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cada producto tiene su fórmula Maestra? ",
                Criterio = "C",
                Articulo="464",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos para la modificación de la formula maestra?",
                Criterio = "R",
                Articulo="470",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe una hoja de ruta de fabricación que indique paso a paso las instrucciones, utensilios, precauciones, tiempos, áreas empleadas para la fabricación y su estatus?",
                Criterio = "N",
                Articulo="464 pto 10",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un procedimiento de limpieza tanto de las áreas de fabricación como de los equipos?",
                Criterio = "C",
                Articulo="426",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un programa para la limpieza del área, llevan registros cronológicos?",
                Criterio = "N",
                Articulo="426",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen instrucciones que indiquen la intervención de Control de Calidad para la extracción de muestras de producción en proceso?",
                Criterio = "N",
                Articulo="475",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Siempre se fabrica de acuerdo con la capacidad del equipo? (Tamaño de lote estándar)",
                Criterio = "N",
                Articulo="428",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se exige anexar al expediente en proceso, los rótulos de identificación de las materias primas, materiales empleados, rótulos del producto final con el número de lote y fecha de expiración?",
                Criterio = "R",
                Articulo="465",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se hacen los cálculos de rendimiento real obtenido en las diversas etapas de la fabricación y la relación con el rendimiento teórico?",
                Criterio = "N",
                Articulo="472",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se observan reportes de las cantidades de envases utilizados estuches y otros materiales empleados? Se reportan las relaciones entre las cantidades utilizadas y las entregadas o surtidas por el almacén? ",
                Criterio = "N",
                Articulo="472",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Todos los envases, líneas de producción, equipos utilizados durante la producción, están identificados para indicar su contenido y la etapa del proceso de cada lote?",
                Criterio = "N",
                Articulo="473",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Una vez finalizada la fabricación, toda la documentación sobre el lote producido (registro de producción, rótulos, resultados analíticos en proceso y productos terminados) son firmados por todas las personas responsables y luego son archivados?",
                Criterio = "N",
                Articulo="465",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }
        };

        }
        public void Inicializa_AreaDispensionOrdFab()
        {
            AreaDispensionOrdFab = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                    Titulo = "4.3 Area de Dispensación de Ordenes de Fabricación",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "Temperatura",
                Criterio = "",
                Articulo="",
                PuntosMax = 0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                  new ContenidoPreguntas()
                {
                Titulo = "Humedad Relativa",
                Criterio = "",
                Articulo="",
                PuntosMax = 0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                    new ContenidoPreguntas()
                {
                Titulo = "Existe un área separada e identificada para la dispensación de órdenes de fabricación? Existe esclusa?",
                Criterio = "C",
                Articulo="424",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El área se encuentra equipada con?",
                Criterio = "N",
                Articulo="424",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Sistema de inyección y extracción de Aire" },
                    new ContenidoSubPreguntas(){ Nombre="Balanzas calibradas" },
                    new ContenidoSubPreguntas(){ Nombre="Se identifican con etiquetas una vez han sido pesadas las materias primas" },
                    new ContenidoSubPreguntas(){ Nombre=" Disponen de un sitio para colocar la materia prima pesada" },
                },
                },
                new ContenidoPreguntas()
                {
                Titulo = "Son adecuadas las condiciones de?",
                Criterio = "N",
                Articulo="424",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Paredes" },
                    new ContenidoSubPreguntas(){ Nombre="Pisos" },
                    new ContenidoSubPreguntas(){ Nombre="Techos" },
                    new ContenidoSubPreguntas(){ Nombre="Curva sanitaria" },
                },
                },
                //new ContenidoPreguntas()
                //{
                //Titulo = "Paredes",
                //PuntosMax = (decimal)0.37,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Pisos",
                //PuntosMax = (decimal)0.37,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Techos",
                //PuntosMax = (decimal)0.37,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Curva sanitaria",
                //PuntosMax = (decimal)0.39,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                new ContenidoPreguntas()
                {
                Titulo = "Cuentan con procedimiento escrito para la dispensación de órdenes de fabricación? ",
                Criterio = "C",
                Articulo="471",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El material limpio se guarda en un lugar que asegure su limpieza y orden?",
                Criterio = "R",
                Articulo="418",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un área independiente, destinada para el lavado de los implementos utilizados? ",
                Criterio = "N",
                Articulo="418",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los equipos se encuentran calibrados? Existe un programa para la calibración de los equipos? Se lleva un registro?",
                Criterio = "C",
                Articulo="431",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cuándo se efectúan las pesadas y/o medidas, el personal que dispensa cuenta con?",
                Criterio = "C",
                Articulo="403",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Ropa adecuada (uniformes limpios)" },
                    new ContenidoSubPreguntas(){ Nombre="Cubre boca" },
                    new ContenidoSubPreguntas(){ Nombre="Anteojos de seguridad" },
                    new ContenidoSubPreguntas(){ Nombre="Máscaras de protección" },
                    new ContenidoSubPreguntas(){ Nombre="Cubre cabellos o cofias" },
                    new ContenidoSubPreguntas(){ Nombre="Guantes" },
                    new ContenidoSubPreguntas(){ Nombre="Protección auditiva (Cuando aplique)" },
                    new ContenidoSubPreguntas(){ Nombre="Zapatos especiales" },
                },
                },
                //new ContenidoPreguntas()
                //{
                //Titulo = "Ropa adecuada (uniformes limpios)",
                //PuntosMax = (decimal)0.25,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Cubre boca",
                //PuntosMax = (decimal)0.25,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Anteojos de seguridad",
                //PuntosMax = (decimal)0.25,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Máscaras de protección",
                //PuntosMax = (decimal)0.25,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Cubre cabellos o cofias",
                //PuntosMax = (decimal)0.25,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Guantes",
                //PuntosMax = (decimal)0.25,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Protección auditiva (Cuando aplique)",
                //PuntosMax = (decimal)0.25,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Zapatos especiales",
                //PuntosMax = (decimal)0.25,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos de limpieza del área de dispensación de órdenes de Fabricación? ",
                Criterio = "R",
                Articulo="426",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe programa de limpieza para esta área?",
                Criterio = "R",
                Articulo="426",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Dónde está ubicada el área de dispensación? ",
                Criterio = "INF",
                Articulo="424",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Área de Almacenamiento" },
                    new ContenidoSubPreguntas(){ Nombre="Área de Producción" },
                },
                },
                //new ContenidoPreguntas()
                //{
                //Titulo = "Área de Almacenamiento",
                //PuntosMax = (decimal)0.25,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Área de Producción",
                //PuntosMax = (decimal)0.25,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                new ContenidoPreguntas()
                {
                Titulo = "Los materiales, una vez medidos o pesados, son identificados evitando así confusiones?",
                Criterio = "N",
                Articulo="424",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }
        };

        }
        public void Inicializa_FabProdDesinfectante()
        {
            FabProdDesinfectante = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                   new ContenidoPreguntas()
                {
                    Titulo = "4.4.1 Fabricación de Productos Desinfectantes",
                    IsHeader = true,
                }, new ContenidoPreguntas()
                {
                Titulo = "Temperatura",
                Criterio = "",
                Articulo="",
                PuntosMax = 0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El área esta físicamente delimitada e identificada? Cuenta con esclusa?",
                Criterio = "INF",
                Articulo="413",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Son adecuadas las condiciones de?",
                Criterio = "C",
                Articulo="415, 416, 417",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Iluminación" },
                    new ContenidoSubPreguntas(){ Nombre="Ventilación" },
                    new ContenidoSubPreguntas(){ Nombre="Paredes" },
                    new ContenidoSubPreguntas(){ Nombre="Pisos" },
                    new ContenidoSubPreguntas(){ Nombre="Instalación de Control de aire, incluyendo Temperatura y Humedad" },
                    new ContenidoSubPreguntas(){ Nombre="Curvas Sanitarias" },
                    new ContenidoSubPreguntas(){ Nombre="Gradiente hacia el desagüe" },
                },
                },
                //new ContenidoPreguntas()
                //{
                //Titulo = "Iluminación",
                //PuntosMax = (decimal)0.28,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Ventilación",
                //PuntosMax = (decimal)0.28,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Paredes",
                //PuntosMax = (decimal)0.28,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Pisos",
                //PuntosMax = (decimal)0.28,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Instalación de Control de aire, incluyendo Temperatura y Humedad",
                //PuntosMax = (decimal)0.28,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Curvas Sanitarias",
                //PuntosMax = (decimal)0.28,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Gradiente hacia el desagüe",
                //PuntosMax = (decimal)0.32,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                new ContenidoPreguntas()
                {
                Titulo = "Existe un sistema de suministro de aire que permita una adecuada ventilación?",
                Criterio = "R",
                Articulo="417",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un sistema de extracción de aire que permita la adecuada ventilación?",
                Criterio = "N",
                Articulo="417",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El área cuenta con",
                Criterio = "C",
                Articulo="422",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Detector de humo" },
                    new ContenidoSubPreguntas(){ Nombre="Extintores contra incendios cargados y operando adecuadamente" },
                    new ContenidoSubPreguntas(){ Nombre="Los extintores se localizan en lugares y cantidades convenientes" }
                },
                },
                //new ContenidoPreguntas()
                //{
                //Titulo = "Detector de humo",
                //PuntosMax = (decimal)0.66,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Extintores contra incendios cargados y operando adecuadamente",
                //PuntosMax = (decimal)0.66,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Los extintores se localizan en lugares y cantidades convenientes",
                //PuntosMax = (decimal)0.68,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                new ContenidoPreguntas()
                {
                Titulo = "El sistema de tuberías de servicio (agua, electricidad, gases, etc.…) se observa limpio e identificado?",
                Criterio = "R",
                Articulo="430",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se observa el área limpia?",
                Criterio = "N",
                Articulo="402",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un programa escrito de limpieza? Existen registros cronológicos de esta actividad?",
                Criterio = "N",
                Articulo="402",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se prohíbe en el área de fabricación comer, fumar o ingerir bebidas?",
                Criterio = "C",
                Articulo="404",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen vestidores y servicios sanitarios suficientes para damas y caballeros?",
                Criterio = "INF",
                Articulo="426",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen suficientes lavamanos con dispensadores de jabón, toalla, papel toalla o secadores de aire?",
                Criterio = "N",
                Articulo="426",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen carteles alusivos al lavado de manos?",
                Criterio = "R",
                Articulo="405",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El personal utiliza uniformes especiales para esta área?",
                Criterio = "N",
                Articulo="403",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los operarios al momento de la Auditoría, se encuentran debidamente uniformados?:",
                Criterio = "C",
                Articulo="403",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Ropa adecuada (uniformes limpios)" },
                    new ContenidoSubPreguntas(){ Nombre="Cubre boca" },
                    new ContenidoSubPreguntas(){ Nombre="Anteojos de seguridad" },
                    new ContenidoSubPreguntas(){ Nombre="Máscaras de protección" },
                    new ContenidoSubPreguntas(){ Nombre="Guantes" },
                    new ContenidoSubPreguntas(){ Nombre="Protección Auditiva (Cuando Aplique)" },
                },
                },
                //new ContenidoPreguntas()
                //{
                //Titulo = "Ropa adecuada (uniformes limpios)",
                //PuntosMax = (decimal)0.28,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "cubre boca",
                //PuntosMax = (decimal)0.28,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "anteojos de seguridad",
                //PuntosMax = (decimal)0.28,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "máscaras de protección",
                //PuntosMax = (decimal)0.28,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "cubre cabellos o cofias",
                //PuntosMax = (decimal)0.28,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "guantes",
                //PuntosMax = (decimal)0.28,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Protección auditiva (Cuando aplique)",
                //PuntosMax = (decimal)0.32,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                new ContenidoPreguntas()
                {
                Titulo = "Los uniformes se encuentran en buenas condiciones?",
                Criterio = "N",
                Articulo="403",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se considera que el área física es adecuada para el volumen de operaciones que se desarrollan?",
                Criterio = "N",
                Articulo="417",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los equipos y materiales se identifican adecuadamente?",
                Criterio = "N",
                Articulo="473",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen recipientes de basura adecuados?",
                Criterio = "INF",
                Articulo="457",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se vacían con frecuencia?",
                Criterio = "R",
                Articulo="457",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un procedimiento escrito para controlar el ingreso de personal ajeno a esta área?",
                Criterio = "R",
                Articulo="474",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se observan prohibiciones al personal que ingresa al área de producción sobre uso de maquillaje, relojes, joyas, teléfonos celulares, radio localizadores e instrumentos ajenos al proceso?",
                Criterio = "R",
                Articulo="404",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El área de circulación está libre de obstáculos?",
                Criterio = "R",
                Articulo="484",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe una fórmula de elaboración que sea fiel copia de la fórmula maestra?",
                Criterio = "C",
                Articulo="464",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "La fórmula maestra contiene",
                Criterio = "C",
                Articulo="464",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Nombre del Producto y Código del Producto" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de emisión de la fórmula" },
                    new ContenidoSubPreguntas(){ Nombre="Descripción de la forma farmacéutica, potencia del producto y tamaño del lote" },
                    new ContenidoSubPreguntas(){ Nombre="Fórmula unitaria" },
                    new ContenidoSubPreguntas(){ Nombre="Fórmula industrial" },
                    new ContenidoSubPreguntas(){ Nombre="Lista de materia prima y cantidades utilizadas" },
                    new ContenidoSubPreguntas(){ Nombre="Rendimiento teórico y rendimiento final esperado con sus límites aceptados" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de revisión de la fórmula maestra o su sustitución por otra" },
                    new ContenidoSubPreguntas(){ Nombre="Listado del Equipo de Producción" },
                    new ContenidoSubPreguntas(){ Nombre="Instrucciones detalladas para cada paso en el proceso de verificación delos materiales, pretratamientos, secuencia en la adición de las materias primas,tiempo de mezclado, temperatura y otros (hoja de ruta)" },
                    new ContenidoSubPreguntas(){ Nombre="Instrucciones para cualquier control durante el proceso con sus límites" },
                    new ContenidoSubPreguntas(){ Nombre="Cualquier precaución a seguir" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de expiración del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Lista de los materiales de acondicionamiento, cantidad y tipo de cada uno de ellos" },
                 },
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cada etapa de elaboración es ejecutada y firmada por el operario y aprobado por su superior inmediato?",
                Criterio = "N",
                Articulo="465",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen normas escritas de limpieza de los recipientes utilizados en la elaboración?",
                Criterio = "N",
                Articulo="402",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se identifica el área con el nombre y número de lote del producto a fabricar?",
                Criterio = "N",
                Articulo="473",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cuándo los recipientes están limpios son identificados y reubicados en un lugar destinado para tal fin?",
                Criterio = "N",
                Articulo="418",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los recipientes conteniendo el producto envasado, están debidamente identificadoscon los siguientes datos?",
                Criterio = "N",
                Articulo="463",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Nombre del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Concentración del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Volumen total del contenido del recipiente" },
                    new ContenidoSubPreguntas(){ Nombre="Número de lote" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de vencimiento" },
                 },
                },
                new ContenidoPreguntas()
                {
                Titulo = "Están en buen estado?",
                Criterio = "N",
                Articulo="435",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Reactores" },
                    new ContenidoSubPreguntas(){ Nombre="Filtros" },
                    new ContenidoSubPreguntas(){ Nombre="Agitadores" },
                    new ContenidoSubPreguntas(){ Nombre="Bombas" },
                    new ContenidoSubPreguntas(){ Nombre="Recipientes empleados en la fabricación" },
                 },
                },
                    //new ContenidoPreguntas(){PuntosMax = (decimal)0.3,LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}, Titulo="reactores" },
                    //new ContenidoPreguntas(){PuntosMax = (decimal)0.3,LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}, Titulo="filtros" },
                    //new ContenidoPreguntas(){PuntosMax = (decimal)0.3,LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}, Titulo="agitadores" },
                    //new ContenidoPreguntas(){PuntosMax = (decimal)0.3,LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}, Titulo="bombas" },
                    //new ContenidoPreguntas(){PuntosMax = (decimal)0.3,LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}, Titulo="recipientes empleados en la fabricación" },
                new ContenidoPreguntas()
                {
                Titulo = "Las balanzas se calibran periódicamente?",
                Criterio = "N",
                Articulo="431",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe registro de las calibraciones? (Verifique) ",
                Criterio = "N",
                Articulo="431",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se verifica la relación entre el rendimiento real y teórico? ",
                Criterio = "R",
                Articulo="472",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se explica por escrito cualquier discrepancia que exista?",
                Criterio = "R",
                Articulo="465",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se efectúan controles en proceso, a fin de garantizar la uniformidad del lote?",
                Criterio = "N",
                Articulo="465",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Control de Calidad libera el lote o granel, para ser envasado?",
                Criterio = "N",
                Articulo="491",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un área destinada e identificada para el envasado final de los productos?",
                Criterio = "N",
                Articulo="486",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                //new ContenidoPreguntas()
                //{
                //Titulo = "Existe un área destinada e identificada para el envasado final de los productos?",
                //Criterio = "N",
                //Articulo="486",
                //PuntosMax = (decimal)0.5,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                //new ContenidoPreguntas()
                //{
                //Titulo = "Existe un área destinada e identificada para el envasado final de los productos?",
                //Criterio = "N",
                //Articulo="486",
                //PuntosMax = (decimal)1.5,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                new ContenidoPreguntas()
                {
                Titulo = "Es ordenada y racional la distribución de los equipos?",
                Criterio = "INF",
                Articulo="414",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se efectúa despeje de líneas antes de comenzar las operaciones para eliminar la presencia de material remanente de productos anteriores?",
                Criterio = "N",
                Articulo="466, 485",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos para la entrada de materias primas, materiales y equipos al área de fabricación?",
                Criterio = "N",
                Articulo="470",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los equipos están construidos de material no reactivo? Afectan la calidad y seguridad del producto?",
                Criterio = "C",
                Articulo="428",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "La ubicación de los equipos obstaculiza el flujo de procesos y movimientos del personal?",
                Criterio = "R",
                Articulo="429",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe en el área de producción equipo en desuso u obsoleto? Está identificado?",
                Criterio = "N",
                Articulo="434",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El Registro de Producción de Lote (Batch Record) contiene la siguienteinformación?",
                Criterio = "C",
                Articulo="465",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Registro del despeje de áreas" },
                    new ContenidoSubPreguntas(){ Nombre="Nombre del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Número de lote fabricado" },
                    new ContenidoSubPreguntas(){ Nombre="Nombre de la persona responsable de las operaciones del proceso" },
                    new ContenidoSubPreguntas(){ Nombre="Iniciales del operario en los diferentes pasos de la producción" },
                     new ContenidoSubPreguntas(){ Nombre="Nombre de la persona que verifica cada una de las operaciones" },
                     new ContenidoSubPreguntas(){ Nombre="Número de lote y/o número de control analítico de las materias primas" },
                     new ContenidoSubPreguntas(){ Nombre="Cantidades pesadas de cada materia prima" },
                     new ContenidoSubPreguntas(){ Nombre="Registro de controles en proceso con iniciales de personas que los realizaron y resultados obtenidos" },
                     new ContenidoSubPreguntas(){ Nombre="Cantidad de producto obtenido en la fabricación" },
                     new ContenidoSubPreguntas(){ Nombre="Comentarios o explicaciones de las desviaciones significativas con relación alrendimiento esperado" },
                     new ContenidoSubPreguntas(){ Nombre="Firma de autorización por cualquier desviación de la fórmula maestra" },
                     new ContenidoSubPreguntas(){ Nombre="Registro de envasado" },
                     new ContenidoSubPreguntas(){ Nombre="Registro de etiquetado" },
                     new ContenidoSubPreguntas(){ Nombre="Ejemplares de los materiales impresos con el número de lote, fecha de expiración y cualquier impresión adicional o foto de estos" },
                 },
                },
                    }
        };

        }
        public void Inicializa_FabPlaguicida()
        {
            FabPlaguicida = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                    Titulo = "4.5.1 Fabricación de Plaguicidas",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "Esta área esta físicamente delimitada e identificada? Cuenta con esclusa?",
                Criterio = "INF",
                Articulo="413",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Son adecuadas las condiciones de?",
                Criterio = "C",
                Articulo="415, 416, 417",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Iluminación" },
                    new ContenidoSubPreguntas(){ Nombre="Paredes" },
                    new ContenidoSubPreguntas(){ Nombre="Pisos" },
                    new ContenidoSubPreguntas(){ Nombre="Ventilación" },
                    new ContenidoSubPreguntas(){ Nombre="Instalación de Control de aire, incluyendo Temperatura y Humedad" },
                    new ContenidoSubPreguntas(){ Nombre="Curvas Sanitarias" },
                    new ContenidoSubPreguntas(){ Nombre="Gradiente hacia el desagüe" },
                },
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un sistema de suministro y renovación de aire en el area?",
                Criterio = "N",
                Articulo="417",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un sistema de extracción de aire que permita la adecuada ventilación?",
                Criterio = "N",
                Articulo="417",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El área cuenta con",
                Criterio = "C",
                Articulo="422",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Detector de humo" },
                    new ContenidoSubPreguntas(){ Nombre="Extintores contra incendios cargados y operando adecuadamente" },
                    new ContenidoSubPreguntas(){ Nombre="Los extintores se localizan en lugares y cantidades convenientes" },
                },
                },                
                new ContenidoPreguntas()
                {
                Titulo = "El sistema de tuberías de servicio (agua, electricidad, gases) se encuentran limpias e identificadas según códigos oficiales?",
                Criterio = "R",
                Articulo="430",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se observa el área limpia?",
                Criterio = "N",
                Articulo="402",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un programa escrito de limpieza? Existen registros cronológicos de esta actividad?",
                Criterio = "N",
                Articulo="426",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se prohíbe en el área de fabricación comer, fumar o ingerir bebidas?",
                Criterio = "C",
                Articulo="404",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen vestidores y servicios sanitarios suficientes para damas y caballeros?",
                Criterio = "INF",
                Articulo="426",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen suficientes lavamanos con dispensadores de jabón, toalla, papel toalla o secadores de aire?",
                Criterio = "N",
                Articulo="426",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                }
                ,new ContenidoPreguntas()
                {
                Titulo = "Existen carteles alusivos al lavado de manos? ",
                Criterio = "R",
                Articulo="405",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "La eliminación de aguas residuales o servidas, desperdicios de producción y otros desechos, dentro y fuera del edificio se hace en forma segura y periódica?",
                Criterio = "N",
                Articulo="374",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El personal utiliza uniformes especiales para esta área?",
                Criterio = "N",
                Articulo="403",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se observa que estos uniformes se encuentran en buenas condiciones?",
                Criterio = "N",
                Articulo="403",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los operarios al momento de la Auditoría, se encuentran debidamente uniformados?:",
                Criterio = "C",
                Articulo="403",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Ropa adecuada (uniformes limpios)" },
                    new ContenidoSubPreguntas(){ Nombre="Cubre boca" },
                    new ContenidoSubPreguntas(){ Nombre="Anteojos de seguridad" },
                    new ContenidoSubPreguntas(){ Nombre="Máscaras de protección" },
                    new ContenidoSubPreguntas(){ Nombre="Cubre cabellos o cofias" },
                    new ContenidoSubPreguntas(){ Nombre="Guantes" },
                    new ContenidoSubPreguntas(){ Nombre="Protección auditiva (Cuando aplique)" },
                },
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se considera que el área física es adecuada para el volumen de operaciones que se desarrollan?",
                Criterio = "N",
                Articulo="417",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los equipos y materiales se identifican adecuadamente?",
                Criterio = "N",
                Articulo="473",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen suficientes recipientes recolectores de basura?",
                Criterio = "INF",
                Articulo="457",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los desperdicios se vacían con frecuencia?",
                Criterio = "R",
                Articulo="457",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un procedimiento escrito para controlar el ingreso de personal ajeno a esta área?",
                Criterio = "R",
                Articulo="404",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se observan prohibiciones al personal que ingresa al área de producción sobre uso de maquillaje, relojes, joyas, teléfonos celulares, radio localizadores e instrumentos ajenos al proceso?",
                Criterio = "R",
                Articulo="404",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El área de circulación está libre de obstáculos?",
                Criterio = "R",
                Articulo="484",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe una fórmula de elaboración que sea fiel copia de la fórmula maestra?",
                Criterio = "C",
                Articulo="464",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "La fórmula maestra contiene",
                Criterio = "C",
                Articulo="464",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Nombre del Producto y Código del Producto" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de emisión de la fórmula" },
                    new ContenidoSubPreguntas(){ Nombre="Descripción de la forma farmacéutica, potencia del producto y tamañodel lote" },
                    new ContenidoSubPreguntas(){ Nombre="Fórmula unitaria" },
                    new ContenidoSubPreguntas(){ Nombre="Fórmula industrial" },
                    new ContenidoSubPreguntas(){ Nombre="Lista de materia prima y cantidades utilizadas" },
                    new ContenidoSubPreguntas(){ Nombre="Rendimiento teórico y rendimiento final esperado con sus límites aceptados" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de revisión de la fórmula maestra o su sustitución por otra" },
                    new ContenidoSubPreguntas(){ Nombre="Listado del Equipo de Producción" },
                    new ContenidoSubPreguntas(){ Nombre="Instrucciones detalladas para cada paso en el proceso de verificación delos materiales, pretratamientos, secuencia en la adición de las materias primas,tiempo de mezclado, temperatura y otros (hoja de ruta)" },
                    new ContenidoSubPreguntas(){ Nombre="Instrucciones para cualquier control durante el proceso con sus límites" },
                    new ContenidoSubPreguntas(){ Nombre="Cualquier precaución a seguir" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de expiración del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Lista de los materiales de acondicionamiento, cantidad y tipo de cada uno de ellos" },
                },
                },
                   
                new ContenidoPreguntas()
                {
                Titulo = "Cada etapa de elaboración es ejecutada y firmada por el operario y aprobado por su superior inmediato?",
                Criterio = "N",
                Articulo="465",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen un programa para la limpieza de los recipientes utilizados en la elaboración?",
                Criterio = "N",
                Articulo="402",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cuándo los recipientes están limpios son identificados y reubicados en un lugar destinado para tal fin?",
                Criterio = "N",
                Articulo="462",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los recipientes conteniendo el producto envasado, están debidamente identificadoscon los siguientes datos?",
                Criterio = "N",
                Articulo="463",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Nombre del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Lote del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Concentración del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Volumen total del contenido del recipiente" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de vencimiento" },
                },
                },                   
                new ContenidoPreguntas()
                {
                Titulo = "Se observa que están en buen estado?",
                Criterio = "N",
                Articulo="435",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Reactores" },
                    new ContenidoSubPreguntas(){ Nombre="Filtros" },
                    new ContenidoSubPreguntas(){ Nombre="Agitadores" },
                    new ContenidoSubPreguntas(){ Nombre="Bombas" },
                    new ContenidoSubPreguntas(){ Nombre="Recipientes empleados en la fabricación?" },
                },
                },                    
                new ContenidoPreguntas()
                {
                Titulo = "Las balanzas se calibran periódicamente?",
                Criterio = "N",
                Articulo="431",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe registro de las calibraciones? (Verifique) ",
                Criterio = "R",
                Articulo="431",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se verifica la relación entre el rendimiento real y teórico? ",
                Criterio = "R",
                Articulo="472",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se explica por escrito cualquier discrepancia que exista?",
                Criterio = "R",
                Articulo="465",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Control de Calidad libera el lote o granel, para ser envasado?",
                Criterio = "N",
                Articulo="491",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El área de circulación está libre de obstáculos?",
                Criterio = "R",
                Articulo="484",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se efectúa despeje de líneas antes de comenzar las operaciones para eliminar la presencia de material remanente de productos anteriores?",
                Criterio = "N",
                Articulo="485",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos para la entrada de materias primas, materiales y equipos al área de fabricación de Químicos, Agroquímicos e Insecticidas?",
                Criterio = "N",
                Articulo="470",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los equipos están construidos de material no reactivo? No afectan la calidad y seguridad del producto?",
                Criterio = "C",
                Articulo="428",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "La ubicación de los equipos obstaculiza el flujo de procesos y movimientos del personal?",
                Criterio = "R",
                Articulo="429",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe en el área de producción equipo en desuso u obsoleto? Está identificado?",
                Criterio = "N",
                Articulo="434",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El Registro de Producción de Lote (Batch Record) contiene la siguiente información?",
                Criterio = "C",
                Articulo="464",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Registro del despeje de áreas" },
                    new ContenidoSubPreguntas(){ Nombre="Nombre del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Número de lote fabricado" },
                    new ContenidoSubPreguntas(){ Nombre="Nombre de la persona responsable de las operaciones del proceso" },
                    new ContenidoSubPreguntas(){ Nombre="Iniciales del operario en los diferentes pasos de la producción" },
                    new ContenidoSubPreguntas(){ Nombre="Nombre de la persona que verifica cada una de las operaciones" },
                    new ContenidoSubPreguntas(){ Nombre="Número de lote y/o número de control analítico de las materias primas" },
                    new ContenidoSubPreguntas(){ Nombre="Cantidades pesadas de cada materia prima" },
                    new ContenidoSubPreguntas(){ Nombre="Registro de controles en proceso con iniciales de personas que los realizaron y resultados obtenidos" },
                    new ContenidoSubPreguntas(){ Nombre="Cantidad de producto obtenido en la fabricación" },
                    new ContenidoSubPreguntas(){ Nombre="Comentarios o explicaciones de las desviaciones significativas con relación alrendimiento esperado" },
                    new ContenidoSubPreguntas(){ Nombre="Firma de autorización por cualquier desviación de la fórmula maestra" },
                     new ContenidoSubPreguntas(){ Nombre="Registro de envasado" },
                     new ContenidoSubPreguntas(){ Nombre="Registro de etiquetado" },
                     new ContenidoSubPreguntas(){ Nombre="Ejemplares de los materiales impresos con el número de lote, fecha de expiración y cualquier impresión adicional o foto de estos" },
               },
                },
            }
        };

        }
        public void Inicializa_FabCosmeticos()
        {
            FabCosmeticos = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                    Titulo = "4.6.1 Fabricación de Cosméticos",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "Temperatura",
                Criterio = "",
                Articulo="",
                PuntosMax = 0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Humedad Relativa",
                Criterio = "",
                Articulo="",
                PuntosMax = 0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                    new ContenidoPreguntas()
                {
                Titulo = "Esta área esta físicamente delimitada e identificada? Cuenta con esclusa?",
                Criterio = "C",
                Articulo="413",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Son adecuadas las condiciones de?",
                Criterio = "C",
                Articulo="415, 416, 417",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Iluminación" },
                    new ContenidoSubPreguntas(){ Nombre="Paredes" },
                    new ContenidoSubPreguntas(){ Nombre="Pisos" },
                    new ContenidoSubPreguntas(){ Nombre="Ventilación" },
                    new ContenidoSubPreguntas(){ Nombre="Instalación de Control de aire, incluyendo Temperatura y Humedad" },
                    new ContenidoSubPreguntas(){ Nombre="Curvas Sanitarias" },
                    new ContenidoSubPreguntas(){ Nombre="Gradiente hacia el desagüe" }, },
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un sistema de suministro y renovación de aire en el área?",
                Criterio = "N",
                Articulo="417",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un sistema de extracción de aire que permita la adecuada ventilación?",
                Criterio = "N",
                Articulo="417",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El área cuenta con",
                Criterio = "C",
                Articulo="422",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Detector de humo" },
                    new ContenidoSubPreguntas(){ Nombre="Extintores contra incendios cargados y operando adecuadamente" },
                    new ContenidoSubPreguntas(){ Nombre="Los extintores se localizan en lugares y cantidades convenientes" },
                 },
                },
                new ContenidoPreguntas()
                {
                Titulo = "El sistema de tuberías de servicio (agua, electricidad, gases) se encuentran limpias e identificadas según cádigos oficiales?",
                Criterio = "R",
                Articulo="430",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se observa el área limpia?",
                Criterio = "N",
                Articulo="402",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un programa escrito de limpieza? Existen registros cronológicos de esta actividad?",
                Criterio = "N",
                Articulo="402",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se prohíbe en el área de fabricación comer, fumar o ingerir bebidas?",
                Criterio = "C",
                Articulo="404",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen vestidores y servicios sanitarios suficientes para damas y caballeros?",
                Criterio = "INF",
                Articulo="426",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen suficientes lavamanos con dispensadores de jabón, toalla, papel toalla o secadores de aire?",
                Criterio = "N",
                Articulo="426",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen carteles alusivos al lavado de manos?",
                Criterio = "R",
                Articulo="405",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El personal utiliza uniformes especiales para esta área?",
                Criterio = "N",
                Articulo="403",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Al momento de la Auditoría los operarios se encuentran debidamente uniformados:",
                Criterio = "C",
                Articulo="403",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Ropa adecuada (uniformes limpios)" },
                    new ContenidoSubPreguntas(){ Nombre="Cubre boca" },
                    new ContenidoSubPreguntas(){ Nombre="Anteojos de seguridad" },
                    new ContenidoSubPreguntas(){ Nombre="Máscaras de protección" },
                    new ContenidoSubPreguntas(){ Nombre="Cubre cabellos o cofias" },
                    new ContenidoSubPreguntas(){ Nombre="Guantes" },
                    new ContenidoSubPreguntas(){ Nombre="Protección auditiva (Cuando aplique)" },
                 },
                },
                    new ContenidoPreguntas()
                {
                Titulo = "Los uniformes se encuentran limpios y en buenas condiciones?",
                Criterio = "N",
                Articulo="403",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },

                new ContenidoPreguntas()
                {
                Titulo = "Se considera que el área física es adecuada para el volumen de operaciones que se desarrollan?",
                Criterio = "N",
                Articulo="417",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los equipos y materiales se identifican adecuadamente?",
                Criterio = "N",
                Articulo="473",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen suficientes recipientes recolectores de basuras?",
                Criterio = "INF",
                Articulo="457",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los desperdicios se vacían con frecuencia?",
                Criterio = "R",
                Articulo="457",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un procedimiento escrito para controlar el ingreso de personal ajeno a esta área?",
                Criterio = "R",
                Articulo="404",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se observan prohibiciones al personal que ingresa al área de producción sobre uso de maquillaje, relojes, joyas, teléfonos celulares, radio localizadores e instrumentos ajenos al proceso?",
                Criterio = "R",
                Articulo="404",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El área de circulación está libre de obstáculos?",
                Criterio = "R",
                Articulo="484",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe una fórmula de elaboración que sea fiel copia de la fórmula maestra?",
                Criterio = "C",
                Articulo="464",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "La fórmula maestra contiene",
                Criterio = "C",
                Articulo="464",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Nombre del Producto y Código del Producto" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de emisión de la fórmula" },
                    new ContenidoSubPreguntas(){ Nombre="Descripción de la forma farmacéutica, potencia del producto y tamañodel lote" },
                    new ContenidoSubPreguntas(){ Nombre="Fórmula unitaria" },
                    new ContenidoSubPreguntas(){ Nombre="Fórmula industrial" },
                    new ContenidoSubPreguntas(){ Nombre="Lista de materia prima y cantidades utilizadas" },
                    new ContenidoSubPreguntas(){ Nombre="Rendimiento teórico y rendimiento final esperado con sus límites aceptados" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de revisión de la fórmula maestra o su sustitución por otra" },
                    new ContenidoSubPreguntas(){ Nombre="Listado del Equipo de Producción" },
                    new ContenidoSubPreguntas(){ Nombre="Instrucciones detalladas para cada paso en el proceso de verificación delos materiales, pretratamientos, secuencia en la adición de las materias primas,tiempo de mezclado, temperatura y otros (hoja de ruta)" },
                    new ContenidoSubPreguntas(){ Nombre="Instrucciones para cualquier control durante el proceso con sus límites" },
                    new ContenidoSubPreguntas(){ Nombre="Cualquier precaución a seguir" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de expiración del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Lista de los materiales de acondicionamiento, cantidad y tipo de cadauno de ellos" },
                 },
                },
                  
                new ContenidoPreguntas()
                {
                Titulo = "Cada etapa de elaboración es ejecutada y firmada por el operario y aprobado por su superior inmediato?",
                Criterio = "N",
                Articulo="465",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen un programa para la limpieza de los recipientes utilizados en la elaboración?",
                Criterio = "N",
                Articulo="402",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cuándo los recipientes están limpios son identificados y reubicados en un lugar destinado para tal fin?",
                Criterio = "N",
                Articulo="462",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los recipientes conteniendo el producto envasado, están debidamente identificadoscon los siguientes datos?",
                Criterio = "N",
                Articulo="463",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Nombre del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Lote del Producto" },
                    new ContenidoSubPreguntas(){ Nombre="Concentración del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Volumen total del contenido en el recipiente" },
                    new ContenidoSubPreguntas(){ Nombre="Fecha de vencimiento" },
                 },
                },
                   
                new ContenidoPreguntas()
                {
                Titulo = "Se observa que están en buen estado?",
                Criterio = "N",
                Articulo="435",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Reactores" },
                    new ContenidoSubPreguntas(){ Nombre="Filtros" },
                    new ContenidoSubPreguntas(){ Nombre="Agitadores" },
                    new ContenidoSubPreguntas(){ Nombre="Bombas" },
                    new ContenidoSubPreguntas(){ Nombre="Recipientes empleados en la fabricación" },
                 },
                },
                new ContenidoPreguntas()
                {
                Titulo = "Las balanzas se calibran periódicamente?",
                Criterio = "N",
                Articulo="431",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe registro de las calibraciones? (Verifique) ",
                Criterio = "R",
                Articulo="431",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se verifica la relación entre el rendimiento real y teórico? ",
                Criterio = "R",
                Articulo="472",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se explica por escrito cualquier discrepancia que exista?",
                Criterio = "R",
                Articulo="465",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Control de Calidad libera el lote o granel, para ser envasado?",
                Criterio = "N",
                Articulo="491",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El área de circulación está libre de obstáculos?",
                Criterio = "R",
                Articulo="484",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se efectúa despeje de líneas antes de comenzar las operaciones para eliminar la presencia de material remanente de productos anteriores?",
                Criterio = "N",
                Articulo="485",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos para la entrada de materias primas, materiales y equipos al área de fabricación de Químicos, Agroquímicos e Insecticidas?",
                Criterio = "N",
                Articulo="470",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Los equipos están construidos de material no reactivo? No afectan la calidad y seguridad del producto?",
                Criterio = "C",
                Articulo="428",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "La ubicación de los equipos obstaculiza el flujo de procesos y movimientos del personal?",
                Criterio = "R",
                Articulo="429",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe en el área de producción equipo en desuso u obsoleto? Está identificado?",
                Criterio = "N",
                Articulo="434",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El Registro de Producción de Lote (Batch Record) contiene la siguiente información?",
                Criterio = "C",
                Articulo="464",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Registro del despeje de áreas" },
                    new ContenidoSubPreguntas(){ Nombre="Nombre del producto" },
                    new ContenidoSubPreguntas(){ Nombre="Número de lote fabricado" },
                    new ContenidoSubPreguntas(){ Nombre="Nombre de la persona responsable de las operaciones del proceso" },
                    new ContenidoSubPreguntas(){ Nombre="Iniciales del operario en los diferentes pasos de la producción" },
                    new ContenidoSubPreguntas(){ Nombre="Nombre de la persona que verifica cada una de las operaciones" },
                    new ContenidoSubPreguntas(){ Nombre="Número de lote y/o número de control analítico de las materias primas" },
                    new ContenidoSubPreguntas(){ Nombre="Cantidades pesadas de cada materia prima" },
                    new ContenidoSubPreguntas(){ Nombre="Registro de controles en proceso con iniciales de personas que los realizaron y resultados obtenidos" },
                    new ContenidoSubPreguntas(){ Nombre="Cantidad de producto obtenido en la fabricación" },
                    new ContenidoSubPreguntas(){ Nombre="Comentarios o explicaciones de las desviaciones significativas con relación alrendimiento esperado" },
                    new ContenidoSubPreguntas(){ Nombre="Firma de autorización por cualquier desviación de la fórmula maestra" },
                    new ContenidoSubPreguntas(){ Nombre="Registro de envasado" },
                    new ContenidoSubPreguntas(){ Nombre="Registro de etiquetado" },
                    new ContenidoSubPreguntas(){ Nombre="Ejemplares de los materiales impresos con el número de lote, fecha de expiración y cualquier impresión adicional o foto de estos" },
                 },
                },
            }
        };

        }
        public void Inicializa_AreaEnvasado()
        {
            AreaEnvasado = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                    new ContenidoPreguntas()
                {
                    Titulo = "Capítulo V - Acondicionamiento",
                    IsHeader = true,
                },
                new ContenidoPreguntas()
                {
                    Titulo = "5.1 Area de embasado",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "La empresa cuenta con un área delimitada e identificada para el envasado final de los productos?",
                Criterio = "N",
                Articulo="413",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "La distribución de los equipos obstaculiza el flujo de operación y movimientos del personal? Están identificados?",
                Criterio = "INF",
                Articulo="429",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen recipientes adecuados para la recolección de los desperdicios?",
                Criterio = "R",
                Articulo="457",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El área cuenta con adecuadas condiciones de?",
                Criterio = "C",
                Articulo="417",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Iluminación" },
                    new ContenidoSubPreguntas(){ Nombre="Ventilación" },
                    new ContenidoSubPreguntas(){ Nombre="Instalación de Control de aire, incluyendo Temperatura y Humedad" },
                    new ContenidoSubPreguntas(){ Nombre="Acabados sanitarios" },
                 },
                },
                new ContenidoPreguntas()
                {
                Titulo = "Las paredes, piso y techo son lisos y de fácil limpieza?",
                Criterio = "R",
                Articulo="415",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Hay desprendimiento de partículas del piso, techo y paredes?",
                Criterio = "N",
                Articulo="415",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El piso se ha construido en gradiente hacia el desagüe?",
                Criterio = "N",
                Articulo="416",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Las instalaciones de servicio (electricidad, aire comprimido) están identificadas y en buenas condiciones?",
                Criterio = "R",
                Articulo="412",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cuentan con procedimiento escrito y registros del envasado de productos o granel?",
                Criterio = "C",
                Articulo="471",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El personal está adecuadamente uniformado? ",
                Criterio = "N",
                Articulo="403",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Al momento de la Auditoría, los operarios se encuentran debidamente uniformados?:",
                Criterio = "N",
                Articulo="403",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Ropa adecuada (uniformes limpios)" },
                    new ContenidoSubPreguntas(){ Nombre="Cubre boca" },
                    new ContenidoSubPreguntas(){ Nombre="Anteojos de seguridad" },
                    new ContenidoSubPreguntas(){ Nombre="Máscaras de protección" },
                    new ContenidoSubPreguntas(){ Nombre="Cubre cabellos o cofias" },
                    new ContenidoSubPreguntas(){ Nombre="Guantes" },
                    new ContenidoSubPreguntas(){ Nombre="Protección auditiva (Cuando aplique)" },
                 },
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se hace despeje de líneas antes de iniciar la operación de envasado?",
                Criterio = "N",
                Articulo="485",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se registra la actividad?",
                Criterio = "N",
                Articulo="485",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Control de Calidad libera el lote o granel, para ser envasado?",
                Criterio = "N",
                Articulo="491",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se realiza tratamiento de limpieza a los envases de acondicionamiento?",
                Criterio = "C",
                Articulo="",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se evita la mezcla de productos diferentes o de lotes distintos del mismo producto mediante suficiente separación entre las líneas de envasado?",
                Criterio = "N",
                Articulo="484",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe separación física o virtual entre las líneas de envasado?",
                Criterio = "R",
                Articulo="484",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se identifica la etapa de acondicionamiento con nombre y número de lote del producto?",
                Criterio = "N",
                Articulo="473",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se realizan controles en línea durante el acondicionamiento?",
                Criterio = "C",
                Articulo="488",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen procedimientos escritos y registros cronológicos de limpieza de esta área y sus equipos? (Verifique) ",
                Criterio = "N",
                Articulo="426",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se registra fecha y hora de inicio y finalización del envasado? ",
                Criterio = "R",
                Articulo="466",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se hace una conciliación entre el número de envases usados versus la cantidad de producto a granel entregado?",
                Criterio = "R",
                Articulo="489",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cualquier discrepancia significativa es investigada y explicada?",
                Criterio = "R",
                Articulo="489",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El registro de actividades de envasado tiene el nombre de la persona responsable y las iniciales de los operarios de cada uno de los pasos?",
                Criterio = "C",
                Articulo="466",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Solo personal autorizado ingresa al área de almacenamiento de rótulos y etiquetado?",
                Criterio = "N",
                Articulo="406",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }

        };

        }
        public void Inicializa_AreaEtiquetadoEmpaque()
        {
            AreaEtiquetadoEmpaque = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                    Titulo = "5.2 Area de Etiquetado y Empaque",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "Se verifican las etiquetas y rótulos antes de entregarse a las líneas de empaque? ",
                Criterio = "N",
                Articulo="450",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se verifican las máquinas de rotulado o etiquetado antes de utilizarlas para eliminar la existencia de etiquetas o rótulos de operaciones anteriores?",
                Criterio = "N",
                Articulo="487",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se realiza el despeje de las líneas de empaque antes de utilizarlas? ",
                Criterio = "N",
                Articulo="485",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se efectúan controles a los rótulos y etiquetas antes o durante las operaciones, con el objetivo de corroborar que realmente coinciden las etiquetas o rótulos con el producto envasado y luego empacado? ",
                Criterio = "C",
                Articulo="488",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Una vez concluida la operación de etiquetado y empaque, los rótulos y etiquetas que tienen impreso el número de lote y fecha de expiración se envían a \"destrucción\"? Se mantiene registro de la destrucción?",
                Criterio = "N",
                Articulo="490",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se investiga y registra toda desviación o discrepancia entre el número de envases rotulados o etiquetados y el número de rótulo o etiquetado recibidas?",
                Criterio = "R",
                Articulo="489",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se hace una reconciliación entre el número de etiquetas o rótulos usados incluyendo los dañados y destruidos?",
                Criterio = "R",
                Articulo="489",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Si las etiquetas o rótulos sobrantes no han sido grabados o no están impresos con el número de lote o fecha de expiración o vencimiento, estos son devueltos al almacén de etiquetado?",
                Criterio = "R",
                Articulo="490",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un procedimiento escrito y registros cronológicos de todas las operaciones que se relacionan con el área de etiquetado y empaque?",
                Criterio = "C",
                Articulo="468",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Control de Calidad autoriza o libera el producto en su presentación comercial para ser ubicado en el área de almacén de producto terminado aprobado? ",
                Criterio = "C",
                Articulo="491",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }
        };

        }
        public void Inicializa_LabControlCalidad()
        {
            LabControlCalidad = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                    Titulo = "Capítulo VI - Control de Calidad",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                    Titulo = "6.1 Laboratorio de Control de la Calidad",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "La empresa dentro de su organización tiene incluido el Laboratorio de Control de Calidad? ",
                Criterio = "C",
                Articulo="397",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Control de Calidad es un departamento independiente de las áreas de producción?",
                Criterio = "N",
                Articulo="399",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Indique la escolaridad del encargado del laboratorio de Control de Calidad? ",
                Criterio = "INF",
                Articulo="399",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe descripción de puestos y funciones para estos cargos? ",
                Criterio = "R",
                Articulo="400",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Las instalaciones físicas del laboratorio de Control de Calidad son adecuadas al volumen de operaciones que desarrollan? ",
                Criterio = "INF",
                Articulo="419",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cuentan con equipos e implementos de seguridad de acuerdo con las actividades desarrolladas. Describa? ",
                Criterio = "N",
                Articulo="419",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El laboratorio de Control de Calidad cuenta con el equipo y materiales adecuados para desarrollar los controles que efectúan? Anexe listado de equipos ",
                Criterio = "C",
                Articulo="419",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen programas de verificación del funcionamiento de estos equipos? Existen registros de su cumplimiento?",
                Criterio = "R",
                Articulo="435",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se observa que los equipos y materiales están ubicados de manera que permitan su correcto funcionamiento?",
                Criterio = "R",
                Articulo="432",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un programa de mantenimiento preventivo y calibraciones, claramente definido? Hay registros de cumplimiento del programa?",
                Criterio = "R",
                Articulo="431, 435",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El laboratorio de Control de Calidad es responsable de aprobar o rechazar:",
                Criterio = "C",
                Articulo="444, 438",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Productos intermedios y sus contenedores" },
                    new ContenidoSubPreguntas(){ Nombre="Productos terminados" },
                    new ContenidoSubPreguntas(){ Nombre="Material de envase" },
                    new ContenidoSubPreguntas(){ Nombre="Material de empaque" },
                    new ContenidoSubPreguntas(){ Nombre="Etiquetas" },
                 },
                },
                new ContenidoPreguntas()
                {
                Titulo = "El Departamento de Control de Calidad cuenta con procedimientos escritos para?",
                Criterio = "N",
                Articulo="444, 491",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Muestreo de materias primas (Representativo del total de lote)" },
                    new ContenidoSubPreguntas(){ Nombre="Aprobación o rechazo de las materias primas (Representativo del total de lote)" },
                    new ContenidoSubPreguntas(){ Nombre="Aprobación o rechazo de los productos terminados (Representativo del total de lote)" },
                    new ContenidoSubPreguntas(){ Nombre="Aprobación o rechazo de materiales de acondicionamiento, envases y empaques (Representativo del total de lote)" },
                    new ContenidoSubPreguntas(){ Nombre="Aprobación o rechazo de etiquetas (Representativo del total de lote)" },
                },
                },                    
                new ContenidoPreguntas()
                {
                Titulo = "Control de Calidad tiene escrita las especificaciones y métodos analíticos para el control de?",
                Criterio = "N",
                Articulo="461, 462, 463",
                PuntosMax = (decimal)1.5,
                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Materias primas" },
                    new ContenidoSubPreguntas(){ Nombre="Material de envase y empaque" },
                    new ContenidoSubPreguntas(){ Nombre="Etiquetas" },
                    new ContenidoSubPreguntas(){ Nombre="Productos intermedios" },
                },
                },                     
                new ContenidoPreguntas()
                {
                Titulo = "Son consultados los métodos analíticos para proceder con su ejecución?",
                Criterio = "N",
                Articulo="492, 494",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El Departamento de Control de Calidad mantiene los registros de los análisis efectuados?",
                Criterio = "C",
                Articulo="419",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se mantienen muestras de reservas de las materias primas empleadas?",
                Criterio = "N",
                Articulo="497",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se define el tiempo de conservación?",
                Criterio = "R",
                Articulo="497",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se almacenan muestras de cada lote de producto terminado?",
                Criterio = "C",
                Articulo="497",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cuenta el laboratorio con área para el lavado de cristalería y utensilios?",
                Criterio = "N",
                Articulo="419",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Las muestras de retención de productos terminados se mantienen en su acondicionamiento final y almacenadas bajo condiciones estipuladas por el fabricante?",
                Criterio = "N",
                Articulo="497",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Por cuánto tiempo se conservan las muestras de retención?",
                Criterio = "R",
                Articulo="497",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe un procedimiento escrito detallando el plazo de re-control de materias primas? Se sigue este procedimiento? (Verifique) ?",
                Criterio = "R",
                Articulo="460",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen patrones y materiales de referencia? Se sigue este procedimiento? (Verifique)?",
                Criterio = "N",
                Articulo="419",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El Departamento de Control de Calidad asigna a una persona que verifica toda la documentación que se genera en el proceso de fabricación para cada producto, y así certifica la correcta ejecución de este o efectúa la correcta investigación de cualquier desvío del proceso?",
                Criterio = "C",
                Articulo="471",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El encargado del Dpto. De Control de Calidad verifica si cada lote elaborado cumple con las especificaciones establecidas antes de liberarlo? Existen registros? (Verifique)?",
                Criterio = "C",
                Articulo="492",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se efectúan análisis microbiológicos?",
                Criterio = "R",
                Articulo="478",
                PuntosMax = (decimal)1.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen registros cronológicos?",
                Criterio = "N",
                Articulo="480",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existen protocolos de ingreso para el personal que labora en estas áreas?",
                Criterio = "N",
                Articulo="407, 409",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                //new ContenidoPreguntas()
                //{
                //Titulo = "Existen protocolos de ingreso para el personal que labora en estas áreas?",
                //Criterio = "N",
                //Articulo="407, 409",
                //PuntosMax = (decimal)1.0,
                //LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                //},
                new ContenidoPreguntas()
                {
                Titulo = "Al momento de la Auditoría, los operarios se encuentran debidamente uniformados?:",
                Criterio = "N",
                Articulo="403",
                PuntosMax = (decimal)1.5,
                 LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                LSubPreguntas = new List<ContenidoSubPreguntas>(){
                    new ContenidoSubPreguntas(){ Nombre="Ropa adecuada (uniformes limpios)" },
                    new ContenidoSubPreguntas(){ Nombre="Cubre boca" },
                    new ContenidoSubPreguntas(){ Nombre="Anteojos de seguridad" },
                    new ContenidoSubPreguntas(){ Nombre="Máscaras de protección" },
                    new ContenidoSubPreguntas(){ Nombre="Cubre cabellos o cofias" },
                    new ContenidoSubPreguntas(){ Nombre="Guantes" },
                    new ContenidoSubPreguntas(){ Nombre="Protección auditiva (Cuando aplique)" },
                },
                },
                }

        };

        }
        public void Inicializa_AnalisisContrato()
        {
            AnalisisContrato = new AUD_ContenidoGenerico()
            {

                LContenido = new List<ContenidoPreguntas>()
            {
                 new ContenidoPreguntas()
                {
                    Titulo = "6.2 Análisis por Contrato",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "Laboratorios de Control de Calidad ajenos a la empresa, son contratados para que desarrollen los controles de calidad a los productos?",
                Criterio = "INF",
                Articulo="498",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cuenta con contrato? (Verifique)",
                Criterio = "C",
                Articulo="498",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Qué tipo de controles desarrollan? (Detalle Brevemente) ",
                Criterio = "INF",
                Articulo="498",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El Departamento de Control de Calidad es el responsable de aprobar o rechazar productos elaborados, acondicionados o mantenidos bajo contratos por terceros? ",
                Criterio = "C",
                Articulo="498",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El contrato establece claramente las funciones y responsabilidades de cada parte?  ",
                Criterio = "N",
                Articulo="498",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El contrato establece que la aprobación final del producto la dará el contratante a través del responsable de Control de Calidad?",
                Criterio = "C",
                Articulo="500",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "El contrato establece si el contratista debe o no tomar las muestras en los locales del fabricante?",
                Criterio = "C",
                Articulo="503",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }

        };

        }
        public void Inicializa_InspeccionAudito()
        {
            InspeccionAudito = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
            {
                new ContenidoPreguntas()
                {
                    Titulo = "Capítulo VII - Inspecciones y Auditorías",
                    IsHeader = true,
                },new ContenidoPreguntas()
                {
                Titulo = "Cuenta con un procedimiento de autoinspección?",
                Criterio = "C",
                Articulo="513",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Elaboran el informe luego de una autoinspección?",
                Criterio = "C",
                Articulo="513",
                PuntosMax = (decimal)2.0,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Existe evidencia escrita de que la empresa es sometida a Inspecciones o Auditorías de Calidad por entidades oficiales y externas del País?",
                Criterio = "N",
                Articulo="514",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Cuándo fue la última visita oficial? ",
                Criterio = "INF",
                Articulo="514",
                PuntosMax = (decimal)0.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "Se indican en estas Inspecciones o Auditorías de Calidad las desviaciones detalladas? ",
                Criterio = "N",
                Articulo="514",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
                new ContenidoPreguntas()
                {
                Titulo = "La empresa en base a estas desviaciones, diseña un Plan de Acciones correctivas?",
                Criterio = "N",
                Articulo="514",
                PuntosMax = (decimal)1.5,
                LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                },
            }

        };

        }


    }


    public class AUD_AuditoriaSanitaria : SystemId
    {
        public AUD_AuditoriaSanitaria()
        {
            LPersona = new List<DatosPersona>();
        }

        private List<DatosPersona> lPersona;
        public List<DatosPersona> LPersona { get => lPersona; set => SetProperty(ref lPersona, value); }
    }

    public class AUD_OtrosFuncionarios : SystemId
    {
        public AUD_OtrosFuncionarios()
        {
            LPersona = new List<DatosPersona>();
            RespProduccion = new DatosPersona();
            RespControlCalidad = new DatosPersona();
        }

        //RESPONSABLE DE PRODUCCIÓN
        private DatosPersona respProduccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona RespProduccion { get => respProduccion; set => SetProperty(ref respProduccion, value); }

        //RESPONSABLE DE CONTROL DE CALIDAD:
        private DatosPersona respControlCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona RespControlCalidad { get => respControlCalidad; set => SetProperty(ref respControlCalidad, value); }

        private List<DatosPersona> lPersona;
        public List<DatosPersona> LPersona { get => lPersona; set => SetProperty(ref lPersona, value); }
    }

    public class AUD_GeneralesEmpresa : SystemId
    {
        // Nombre
        private string nombre;
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        // provincia
        private string provincia;
        public string Provincia { get => provincia; set => SetProperty(ref provincia, value); }

        // Distrito
        private string distrito;
        public string Distrito { get => distrito; set => SetProperty(ref distrito, value); }

        // corregimiento
        private string corregimiento;
        public string Corregimiento { get => corregimiento; set => SetProperty(ref corregimiento, value); }

        // direccion
        private string direccion;
        public string Direccion { get => direccion; set => SetProperty(ref direccion, value); }

        // ciudad
        private string ciudad;
        public string Ciudad { get => ciudad; set => SetProperty(ref ciudad, value); }

        // telefono
        private string telefono;
        public string Telefono { get => telefono; set => SetProperty(ref telefono, value); }

        //correo electronico
        private string email;
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
        public string Email { get => email; set => SetProperty(ref email, value); }

        // Razon Social
        private string razonSocial;
        public string RazonSocial { get => razonSocial; set => SetProperty(ref razonSocial, value); }

        // Nº de Licencia de operación
        private string numLicOperacion;
        public string NumLicOperacion { get => numLicOperacion; set => SetProperty(ref numLicOperacion, value); }

        // Fecha de vencimiento Lic Operacion
        private DateTime? fechaVencLicOperacion;
        public DateTime? FechaVencLicOperacion { get => fechaVencLicOperacion; set => SetProperty(ref fechaVencLicOperacion, value); }

        // Horario de Operación 
        private string horarioOperacion;
        public string HorarioOperacion { get => horarioOperacion; set => SetProperty(ref horarioOperacion, value); }

        // Nº de Licencia Especial de Sustancias Controladas 
        private string numLicEspecial;
        public string NumLicEspecial { get => numLicEspecial; set => SetProperty(ref numLicEspecial, value); }

        // Fecha de vencimiento Lic Especial
        private DateTime? fechaVencLicEspecial;
        public DateTime? FechaVencLicEspecial { get => fechaVencLicEspecial; set => SetProperty(ref fechaVencLicEspecial, value); }

        // Actividad comercial aprobada
        private string actComercialAprobada;
        public string ActComercialAprobada { get => actComercialAprobada; set => SetProperty(ref actComercialAprobada, value); }


    }

    public class AUD_ContenidoTablas : SystemId
    {
        public AUD_ContenidoTablas()
        {
            LContenido = new List<ContenidoTablas>();
        }
       
        private int numero;
        public int Numero { get => numero; set => SetProperty(ref numero, value); }
        
        private string titulo;
        public string Titulo { get => titulo; set => SetProperty(ref titulo, value); }

        private string temperatura;
        public string Temperatura { get => temperatura; set => SetProperty(ref temperatura, value); }

        private string humedad;
        public string Humedad { get => humedad; set => SetProperty(ref humedad, value); }

        private List<ContenidoTablas> lContenido;
        public List<ContenidoTablas> LContenido { get => lContenido; set => SetProperty(ref lContenido, value); }

        public decimal TotalPtos { get { return LContenido?.Sum(x=>x.PuntosObtenido)??0; } set { } }
    }

    public class ContenidoTablas : SystemId
    {
        public ContenidoTablas()
        {
            IsHeader = false;
            LSubContenido = new List<SubContenidoTablas>();
        }

        private int numero;
        public int Numero { get => numero; set => SetProperty(ref numero, value); }


        private bool isHeader;
        public bool IsHeader { get => isHeader; set => SetProperty(ref isHeader, value); }


        private decimal puntosMax;
        public decimal PuntosMax { get => puntosMax; set => SetProperty(ref puntosMax, value); }


        private decimal puntosObtenido;
        public decimal PuntosObtenido { get => puntosObtenido; set => SetProperty(ref puntosObtenido, value); }

        // Titulo
        private string titulo;
        public string Titulo { get => titulo; set => SetProperty(ref titulo, value); }

        // Capitulo
        private string capitulo;
        public string Capitulo { get => capitulo; set => SetProperty(ref capitulo, value); }


        // Articulo
        private string articulo;
        public string Articulo { get => articulo; set => SetProperty(ref articulo, value); }

        // Evaluacion
        private enumAUD_TipoSeleccion evaluacion;
        public enumAUD_TipoSeleccion Evaluacion { get { return evaluacion; } set { SetProperty(ref evaluacion, value); PuntosObtenido = evaluacion == enumAUD_TipoSeleccion.Si ? PuntosMax : 0;  } }

        // Evaluacion
        private enumAUD_TipoSeleccion evaluacion2;
        public enumAUD_TipoSeleccion Evaluacion2 { get => evaluacion2; set => SetProperty(ref evaluacion2, value); }

        // Evaluacion
        private enumAUD_TipoSeleccion evaluacion3;
        public enumAUD_TipoSeleccion Evaluacion3 { get => evaluacion3; set => SetProperty(ref evaluacion3, value); }

        // Evaluacion
        private enumAUD_TipoSeleccion evaluacion4;
        public enumAUD_TipoSeleccion Evaluacion4 { get => evaluacion4; set => SetProperty(ref evaluacion4, value); }

        // Evaluacion
        private enumAUD_TipoSeleccion evaluacion5;
        public enumAUD_TipoSeleccion Evaluacion5 { get => evaluacion5; set => SetProperty(ref evaluacion5, value); }

        // Evaluacion
        private enumAUD_TipoSeleccion evaluacion6;
        public enumAUD_TipoSeleccion Evaluacion6 { get => evaluacion6; set => SetProperty(ref evaluacion6, value); }

        // Evaluacion
        private enumAUD_TipoSeleccion evaluacion7;
        public enumAUD_TipoSeleccion Evaluacion7 { get => evaluacion7; set => SetProperty(ref evaluacion7, value); }


        // Criterio
        private string criterio;
        public string Criterio { get => criterio; set => SetProperty(ref criterio, value); }

        // Observaciones
        private string observaciones;
        public string Observaciones { get => observaciones; set => SetProperty(ref observaciones, value); }


        // SubContenido Tablas
        private List<SubContenidoTablas> lSubContenido;
        public List<SubContenidoTablas> LSubContenido { get => lSubContenido; set => SetProperty(ref lSubContenido, value); }

        private bool isQuestion;
        public bool IsQuestion { get => isQuestion; set => SetProperty(ref isQuestion, value); }

        private string temperatura;
        public string Temperatura { get => temperatura; set => SetProperty(ref temperatura, value); }

        private string humedad;
        public string Humedad { get => humedad; set => SetProperty(ref humedad, value); }

    }

    public class SubContenidoTablas : SystemId
    {
        // Titulo
        private string titulo;
        public string Titulo { get => titulo; set => SetProperty(ref titulo, value); }

        // Criterio
        private string criterio;
        public string Criterio { get => criterio; set => SetProperty(ref criterio, value); }

        // seleccion
        private enumAUD_TipoSeleccion seleccion;
        public enumAUD_TipoSeleccion Seleccion { get => seleccion; set => SetProperty(ref seleccion, value); }

        // Evaluacion
        private enumAUD_TipoSeleccion evaluacion;
        public enumAUD_TipoSeleccion Evaluacion { get => evaluacion; set => SetProperty(ref evaluacion, value); }


        // descripcion
        private string descripcion;
        public string Descripcion { get => descripcion; set => SetProperty(ref descripcion, value); }

    }

    ///////////////////////////////
    ///
        
    public class ContenidoPreguntas : SystemId
    {
        public ContenidoPreguntas()
        {
            IsHeader = false;
        }        

        private bool isHeader;
        public bool IsHeader { get => isHeader; set => SetProperty(ref isHeader, value); }

        private bool isSubHeader;
        public bool IsSubHeader { get => isSubHeader; set => SetProperty(ref isSubHeader, value); }

        // Capitulo
        private string capitulo;
        public string Capitulo { get => capitulo; set => SetProperty(ref capitulo, value); }

        // Articulo
        private string articulo;
        public string Articulo { get => articulo; set => SetProperty(ref articulo, value); }

        // Titulo
        private string titulo;
        public string Titulo { get => titulo; set => SetProperty(ref titulo, value); }

        // Criterio
        private string criterio;
        public string Criterio { get => criterio; set => SetProperty(ref criterio, value); }

        //// Evaluacion
        //enumAUD_TipoSeleccion? evaluacion = null;
        //public enumAUD_TipoSeleccion? Evaluacion { get { return evaluacion; } set { SetProperty(ref evaluacion, value); } }

        // Evaluacion
        List<OpcionEvaluacion> lEvaluacion = null;
        public List<OpcionEvaluacion> LEvaluacion { get { return lEvaluacion; } set { SetProperty(ref lEvaluacion, value); } }

        // Evaluacion
        List<ContenidoSubPreguntas> lSubPreguntas = null;
        public List<ContenidoSubPreguntas> LSubPreguntas { get { return lSubPreguntas; } set { SetProperty(ref lSubPreguntas, value); } }

        // Observaciones
        private string observaciones;
        public string Observaciones { get => observaciones; set => SetProperty(ref observaciones, value); }

        // PuntosMax
        private decimal puntosMax;
        public decimal PuntosMax { get => puntosMax; set => SetProperty(ref puntosMax, value); }

        // PuntosMax
        private decimal puntosObtenido;
        public decimal PuntosObtenido { 
            get {
                //puntosObtenido = 0;
                //if (LEvaluacion?.All(x => x.Evaluacion == enumAUD_TipoSeleccion.Si)??false)
                //{
                //    puntosObtenido = puntosMax;
                //}
                return puntosObtenido;
            } 
            set => SetProperty(ref puntosObtenido, value); }
        
        private int numero;
        public int Numero { get => numero; set => SetProperty(ref numero, value); }

    }

    public class OpcionEvaluacion : SystemId
    {
        private bool hideEvaluacion = false;
        public bool HideEvaluacion { get => hideEvaluacion; set => SetProperty(ref hideEvaluacion, value); }

        enumAUD_TipoSeleccion evaluacion;
        public enumAUD_TipoSeleccion Evaluacion { get { return evaluacion; } set { SetProperty(ref evaluacion, value); } }
    }

    public class ContenidoSubPreguntas : SystemId
    {
        private string nombre;
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }
        
        private bool hideEvaluacion = false;
        public bool HideEvaluacion { get => hideEvaluacion; set => SetProperty(ref hideEvaluacion, value); }

        enumAUD_TipoSeleccion evaluacion;
        public enumAUD_TipoSeleccion Evaluacion { get { return evaluacion; } set { SetProperty(ref evaluacion, value); } }
        
    }
}
