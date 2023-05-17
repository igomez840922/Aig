using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspGuiaBPMLabAcondicionadorTB : SystemId
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

        //ORGANIZACIÓN Y PERSONAL -> ORGANIZACIÓN - PERSONAL - RESPONSABILIDADES DEL PERSONAL - CAPACITACIÓN - SALUD E HIGIENE DEL PERSONAL
        private AUD_ContenidoGenerico organizacionPersonal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico OrganizacionPersonal { get => organizacionPersonal; set => SetProperty(ref organizacionPersonal, value); }

        //8. EDIFICIOS E INSTALACIONES -> GENERALIDADES - 
        private AUD_ContenidoGenerico edifInstalaciones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico EdifInstalaciones { get => edifInstalaciones; set => SetProperty(ref edifInstalaciones, value); }

        //8. EDIFICIOS E INSTALACIONES -> Almacenes
        private AUD_ContenidoGenerico almacenes;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Almacenes { get => almacenes; set => SetProperty(ref almacenes, value); }

        //8. EDIFICIOS E INSTALACIONES -> ÁREAS DE ACONDICIONAMIENTO PARA EMPAQUE SECUNDARIO - ÁREA DE CONTROL DE CALIDAD - ÁREAS AUXILIARES
        private AUD_ContenidoGenerico areaAcondicionamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaAcondicionamiento { get => areaAcondicionamiento; set => SetProperty(ref areaAcondicionamiento, value); }

        //9. EQUIPO - GENERALIDADES
        private AUD_ContenidoGenerico equiposGeneralidades;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico EquiposGeneralidades { get => equiposGeneralidades; set => SetProperty(ref equiposGeneralidades, value); }

        //10. MATERIALES Y PRODUCTOS - GENERALIDADES - MATERIAS PRIMAS - MATERIALES DE ACONDICIONAMIENTO - PRODUCTOS INTERMEDIOS Y A GRANEL - PRODUCTOS TERMINADOS - MATERIALES Y PRODUCTOS RECHAZADOS - PRODUCTOS DEVUELTOS -  
        private AUD_ContenidoGenerico matProducts;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico MatProducts { get => matProducts; set => SetProperty(ref matProducts, value); }

        //11. DOCUMENTACIÓN - GENERALIDADES - DOCUMENTOS EXIGIDOS - PROCEDIMIENTOS Y REGISTROS - 
        private AUD_ContenidoGenerico documentacion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Documentacion { get => documentacion; set => SetProperty(ref documentacion, value); }

        //12. ACONDICIONAMIENTO
        private AUD_ContenidoGenerico acondicionamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Acondicionamiento { get => acondicionamiento; set => SetProperty(ref acondicionamiento, value); }

        //13. GARANTÍA DE CALIDAD - GENERALIDADES
        private AUD_ContenidoGenerico garantiaCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico GarantiaCalidad { get => garantiaCalidad; set => SetProperty(ref garantiaCalidad, value); }

        // 14. CONTROL DE CALIDAD - GENERALIDADES - DOCUMENTACIÓN - MUESTREO - METODOLOGÍA ANALÍTICA - ESTABILIDAD - 
        private AUD_ContenidoGenerico controlCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico ControlCalidad { get => controlCalidad; set => SetProperty(ref controlCalidad, value); }

        //15. PRODUCCIÓN Y ANÁLISIS POR CONTRATO - GENERALIDADES - DEL CONTRATANTE - DEL CONTRATISTA - 
        private AUD_ContenidoGenerico prodAnalisisContrato;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico ProdAnalisisContrato { get => prodAnalisisContrato; set => SetProperty(ref prodAnalisisContrato, value); }

        //16. VALIDACIÓN - GENERALIDADES - CONFORMACIÓN DE EQUIPOS - PROTOCOLOS E INFORMES - CALIFICACIÓN Y VALIDACIÓN - DE NUEVA FÓRMULA - DE LA VALIDACIÓN DE MODIFICACIONES - REVALIDACIÓN - 
        private AUD_ContenidoGenerico valGenerales;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico ValGenerales { get => valGenerales; set => SetProperty(ref valGenerales, value); }

        //17. QUEJAS, RECLAMOS Y RETIRO DE PRODUCTOS - GENERALIDADES - QUEJAS O RECLAMOS - RETIROS - 
        private AUD_ContenidoGenerico quejasReclamos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico QuejasReclamos { get => quejasReclamos; set => SetProperty(ref quejasReclamos, value); }

        //18. AUTOINSPECCIÓN Y auditorías DE CALIDAD - AUTOINSPECCIONES - AUDITORÍAS - 
        private AUD_ContenidoGenerico autoInspecAuditCal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AutoInspecAuditCal { get => autoInspecAuditCal; set => SetProperty(ref autoInspecAuditCal, value); }


        public void Inicializa_RequisitosLegales()
        {
            RequisitosLegales = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas()
                    {
                        Titulo = "De la autorización de funcionamiento",
                        IsHeader = true,
                    },new ContenidoPreguntas()
                        {
                            Titulo = "El laboratorio Acondicionador posee permiso sanitario de funcionamiento o licencia sanitaria, autorizada por la autoridad reguladora del país.",
                            Criterio = "CRÍTICO",
                            Articulo="6.1.1",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "El permiso sanitario de funcionamiento o licencia de operación se encuentra vigente.",
                            Criterio = "CRÍTICO",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "El permiso sanitario de funcionamiento o licencia de operación se encuentra colocado en un lugar visible al público.",
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
                        Titulo = "Adquisición de Materiales de acondicionamiento",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Compra local?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Es importador?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Exigen certificado de análisis de del fabricante?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se encuentran disponibles los certificados de análisis?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Es importador de:",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                        {
                            Titulo = "Producto terminado?",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "Producto semielaborado?",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "Producto a granel?",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "Exigen certificado de análisis del fabricante?",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        },
                    new ContenidoPreguntas()
                        {
                            Titulo = "Se encuentran disponibles los certificados de análisis?",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                        }
                }
            };

        }

        public void Inicializa_ClasifEstablecimiento()
        {
            ClasifEstablecimiento = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas()
                    {
                        Titulo = "LABORATORIO ACONDICIONADOR DE:",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Medicamentos Humanos?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Medicamentos Veterinarios?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Medicamentos Cosméticos?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Productos Naturales?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Productos Homeopáticos?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Otros indiquen",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Acondicionan y analizan productos a terceros?\r\nCuáles y de qué empresa(s)?. Anexar Listado",
                        IsHeader = true,
                        Criterio = "Crítico",
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Que tipo de acondicionamiento realizan?",
                        Criterio = "Informativo",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cuentan con contratos para el acondicionamiento y análisis de productos a terceros?",
                        Criterio = "Crítico",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                }
            };

        }

        public void Inicializa_OrganizacionPersonal()
        {
            OrganizacionPersonal = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                    {
                        Titulo = "ORGANIZACIÓN",
                        Capitulo="7.1",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tiene el laboratorio acondicionador los organigramas generales y específicos de cada uno de los departamentos, se encuentran actualizados y aprobados? ",
                        Criterio = "MAYOR",
                        Articulo="7.1.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe independencia de responsabilidades entre producción y control de la calidad?",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cuenta con descripciones escritas de las funciones y responsabilidades de cada puesto incluido en el organigrama?",
                        Criterio = "MAYOR",
                        Articulo="7.1.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Dispone de un Director técnico / Regente Farmacéutico? ",
                        Criterio = "CRÍTICO",
                        Articulo="7.1.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El director técnico del establecimiento cumple con el horario de funcionamiento del laboratorio acondicionador?",
                        Criterio = "MENOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "En caso de jornadas continuas o extraordinarias el Director técnico / Regente garantiza los mecanismos de supervisión de acuerdo con la Legislación de cada Estado Parte?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Participa en las inspecciones realizadas?",
                        Criterio = "MENOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe registro?",
                        Criterio = "MENOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "PERSONAL",
                        Capitulo="7.2",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Dispone el laboratorio acondicionador de personal con la calificación y experiencia práctica según el puesto asignado?",
                        Criterio = "MAYOR",
                        Articulo="7.2.1, 7.2.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las funciones asignadas a cada persona deben ser congruentes con el nivel de responsabilidad que asuma y que no constituyan un riesgo a la calidad del producto?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las unidades de producción, control de calidad y garantía de calidad, están a cargo de profesionales farmacéuticos o profesionales calificados?",
                        Criterio = "CRÍTICO",
                        Articulo="7.2.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "RESPONSABILIDADES DEL PERSONAL",
                        Capitulo="7.3",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cumple el responsable de la Dirección de Producción (Acondicionamiento) con las siguientes responsabilidades:",
                        Articulo="7.3.1",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Asegura que los productos se acondicionan y almacenen en concordancia con la documentación aprobada",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Aprueba los documentos maestros relacionados con las operaciones de acondicionamiento incluyendo los controles durante el proceso y asegurar su estricto cumplimiento",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Garantiza que la orden de acondicionamiento esté completa y firmada por las personas designadas antes de que se pongan a disposición del Depto. de Control de Calidad",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Vigila el mantenimiento del departamento en general, instalaciones y equipo",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Asegura que se lleve a cabo los procesos de acondicionamiento de acuerdo con los parámetros establecidos",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Autoriza los procedimientos del Departamento de producción (Acondicionamiento), y verifica que se cumplan dejando constancia escrita",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) Asegura que se lleve a cabo la capacitación inicial y continua del personal de producción (Acondicionamiento) y que dicha capacitación se adapte a las necesidades del departamento",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cumple el responsable de la Dirección de Control de Calidad con las siguientes responsabilidades:",
                        Articulo="7.3.2",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a)  Aprueba o rechaza, según proceda productos terminados y material de acondicionamiento",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Verifica que toda la documentación del acondicionamiento de un producto terminado esté completa.",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Aprueba las especificaciones, instrucciones de muestreo y otros procedimientos de control de calidad",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Vigila el mantenimiento del departamento, las instalaciones y equipo",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) Asegura que se lleve a cabo la capacitación inicial y continua del personal de control de calidad y que dicha capacitación se adapte a las necesidades.",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se llevan registros?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "e) Vigila el mantenimiento del departamento, las instalaciones y equipo;",
                    //    Criterio = "MAYOR",
                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "f) Verifica que se efectúen las validaciones correspondientes a los procedimientos analíticos y de los equipos de control.",
                    //    Criterio = "MAYOR",
                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "Se llevan registros?",
                    //    Criterio = "MAYOR",
                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cumplen los responsables de producción (Acondicionamiento) y control de calidad con las responsabilidades compartidas, las cuales son las siguientes:",
                        Articulo="7.3.3",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Autorizan los procedimientos escritos y otros documentos, incluyendo sus modificaciones.",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Vigilan y controlan las áreas de producción (Acondicionamiento).",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Vigilan la higiene de las instalaciones de las áreas de acondicionamiento.",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Validan los procesos, califican y calibran los equipos e instrumentos",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Aseguran la capacitación del personal.",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Participan en la selección, evaluación (aprobación) y control de los proveedores de materiales, de equipo y otros involucrados en el proceso de producción (Acondicionamiento)",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "g) Aprueban y controlan la fabricación por terceros. ",
                    //    Criterio = "MAYOR",
                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "h) Establecen y controlan las condiciones de almacenamiento de materiales y productos",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "i) Conservan la documentación",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "j) Vigilan el cumplimiento de las Buenas Prácticas de Manufactura (acondicionamiento)",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "k) Inspeccionan, investigan y muestrean con el fin de controlar los factores que puedan afectar a la calidad",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "CAPACITACIÓN",
                        Capitulo="7.4",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cuentan con procedimiento escrito de inducción general de buenas prácticas de manufactura (acondicionamiento) para el personal de nuevo ingreso y es específica de acuerdo con sus funciones y atribuciones asignadas?",
                        Criterio = "MAYOR",
                        Articulo="7.4.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se mantienen los registros?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un programa escrito de capacitación continua en buenas prácticas de manufactura, para todo el personal operativo?",
                        Criterio = "MAYOR",
                        Articulo="7.4.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Está la capacitación acorde a las funciones propias de cada puesto?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las capacitaciones se efectúan como mínimo dos veces al año?",
                        Criterio = "MAYOR",
                        Articulo="7.4.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realiza evaluación del programa de capacitación tomando en cuenta su ejecución y los resultados?",
                        Criterio = "MAYOR",
                        Articulo="7.4.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe procedimiento escrito para el ingreso de personas ajenas a las áreas de acondicionamiento y control de calidad?",
                        Criterio = "MAYOR",
                        Articulo="7.4.6",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "SALUD E HIGIENE DEL PERSONAL",
                        Capitulo="7.5",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Todo el personal previo a ser contratado se somete a examen médico?",
                        Criterio = "MAYOR",
                        Articulo="7.5.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El Laboratorio acondicionador garantiza que el personal presente anualmente la certificación médica o su equivalente de acuerdo con la legislación del país?",
                        Criterio = "MENOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "De acuerdo con las áreas de desempeño, el personal es sometido a exámenes médicos, al menos una vez al año?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un procedimiento escrito en donde el personal enfermo comunique de inmediato a su superior, cualquier estado de salud que influya negativamente en la producción (Acondicionamiento)?",
                        Criterio = "MAYOR",
                        Articulo="7.5.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe registro?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos relacionados con la higiene del personal incluyendo el uso de ropas protectoras, que incluyan a todas las personas que ingresan a las áreas de acondicionamiento?",
                        Criterio = "MAYOR",
                        Articulo="7.5.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se garantiza que al ingresar a las áreas de acondicionamiento los empleados permanentes, temporales o visitantes, utilizan vestimenta/uniforme acorde a las tareas que se realizan, los cuales están limpios y en buenas condiciones?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Utiliza diariamente el personal dedicado a la producción (Acondicionamiento), que este en contacto directo con el producto terminado, uniforme completo:",
                        Criterio = "CRÍTICO",
                        Articulo="7.5.5",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "- Gorro que cubra la totalidad del cabello",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "- Mascarilla",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "- Guantes desechables",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "- zapatos cerrados y suela antideslizante",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El personal utiliza el uniforme de acuerdo con el área de trabajo? ",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "En las áreas de acondicionamiento, almacenamiento y control de calidad existe la prohibición de:",
                        Articulo="7.5.6",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Comer, beber, fumar, masticar, así como guardar comida, bebida, cigarrillos, medicamentos personales",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Utilizar maquillaje, joyas, relojes, teléfonos celulares, radio localizadores, u otro elemento ajeno al área",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Llevar barba o bigote al descubierto durante la jornada de trabajo en los procesos de Acondicionamiento",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Salir del área de acondicionamiento con el uniforme de trabajo",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen rótulos que indiquen tales prohibiciones?",
                        Criterio = "MENOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un procedimiento que instruya al personal a lavarse las manos antes de ingresar a las áreas de acondicionamiento? ",
                        Criterio = "MAYOR",
                        Articulo="7.5.7",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen carteles, rótulos alusivos que indiquen al personal la obligación de lavarse las manos después de utilizar los servicios sanitarios y después de comer? ",
                        Criterio = "MENOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cuenta el laboratorio con botiquín y área destinada a primeros auxilios?",
                        Criterio = "MENOR",
                        Articulo="7.5.9",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    }
                },
            };

        }

        public void Inicializa_EdifInstalaciones()
        {
            EdifInstalaciones = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                    {
                        Titulo = "GENERALIDADES",
                        Capitulo="8.1",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Está diseñado el edificio de tal manera que facilite la limpieza, mantenimiento y ejecución apropiada de las operaciones?",
                        Criterio = "INFORMATIVO",
                        Articulo="8.1.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los espacios libres (exteriores) y no productivos pertenecientes a la empresa se encuentran en condiciones de orden y limpieza?",
                        Criterio = "MENOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las vías de acceso interno a las instalaciones están pavimentadas o construidas de manera tal que el polvo no sea fuente de contaminación en el interior de la planta? ",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se encuentran actualizados los planos y diagramas de las instalaciones y edificio?",
                        Criterio = "INFORMATIVO",
                        Articulo="8.1.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen fuentes de contaminación ambiental en el área circundante al edificio? En caso afirmativo, se adoptan medidas de resguardo?",
                        Criterio = "MAYOR",
                        Articulo="8.1.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos, programa y registros del mantenimiento realizado a las instalaciones y edificios?",
                        Criterio = "MAYOR",
                        Articulo="8.1.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Está diseñado y equipado el edificio de tal forma que ofrezca la máxima protección contra el ingreso de insectos y animales?",
                        Criterio = "MAYOR",
                        Articulo="8.1.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Está diseñado el edificio, de tal manera que permita el flujo de materiales, procesos y personal evitando la confusión, contaminación y errores?",
                        Criterio = "CRÍTICO",
                        Articulo="8.1.6",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se supervisa el ingreso de personas ajenas a estas áreas?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "Están las áreas de acceso restringido debidamente delimitadas e identificadas? ",
                    //    Criterio = "MAYOR",
                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las áreas de producción (Acondicionamiento) y almacenamiento no se utilizan como áreas de paso?",
                        Criterio = "CRÍTICO",
                        Articulo="8.1.7",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los pasillos de circulación se encuentran libres de materiales, productos y equipo?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las condiciones de iluminación, temperatura, humedad y ventilación, para la producción y almacenamiento, están acordes con los requerimientos del producto?",
                        Criterio = "CRÍTICO",
                        Articulo="8.1.9",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los equipos y materiales están ubicados de forma que eviten el riesgo de confusión, contaminación cruzada y omisión entre los distintos productos y sus componentes en cualquiera de las operaciones de producción (Acondicionamiento), control y almacenamiento?",
                        Criterio = "CRÍTICO",
                        Articulo="8.1.10",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Son las áreas de almacenamiento y producción (Acondicionamiento) exclusivas para el uso previsto y se mantienen libres de objetos y materiales extraños al proceso?",
                        Criterio = "MAYOR",
                        Articulo="8.1.11",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las tuberías, artefactos lumínicos, puntos de ventilación y otros servicios, están diseñados y ubicados, de tal forma que faciliten la limpieza? ",
                        Criterio = "MAYOR",
                        Articulo="8.1.12",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Dispone el edificio de extintores adecuados a las áreas y se encuentran estos ubicados en lugares estratégicos?",
                        Criterio = "MAYOR",
                        Articulo="8.1.13",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },

                }
            };

        }

        public void Inicializa_Almacenes()
        {
            Almacenes = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                    {
                        Titulo = "ALMACENES",
                        Capitulo="8.2",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tienen las áreas de almacenamiento suficiente capacidad para permitir el almacenamiento ordenado de las diferentes categorías de materiales y productos?",
                        Criterio = "MAYOR",
                        Articulo="8.2.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Están debidamente identificados?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los pisos, paredes, techos de los almacenes están construidos de tal forma que no afectan la calidad de los materiales y productos que se almacenan y permite la fácil limpieza? ",
                        Criterio = "MAYOR",
                        Articulo="8.2.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las instalaciones eléctricas están diseñadas y ubicadas de tal forma que facilitan la limpieza?",
                        Criterio = "MAYOR",
                        Articulo="8.1.12",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los desagües y tuberías están en buen estado de conservación e higiene?. Si aplica?",
                        Criterio = "MAYOR",
                        Articulo="8.1.14",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las áreas de almacenamiento se mantienen limpias y ordenadas? ",
                        Criterio = "MAYOR",
                        Articulo="8.2.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Hay instrumentos para medir la temperatura y humedad y estas mediciones están dentro de los parámetros establecidos para los materiales y productos almacenados?",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Para las materias primas y productos que requieren condiciones especiales de enfriamiento, existe cámara fría?",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se llevan registros?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los productos que requieren condiciones especiales de enfriamiento, se encuentran en cámara fría?",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros?",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un sistema de alerta que indique los desvíos de la temperatura programada en la cámara fría?",
                        Criterio = "INFORMATIVO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los materiales y productos están protegidos de las condiciones ambientales en los lugares de recepción y despacho?",
                        Criterio = "MAYOR",
                        Articulo="8.2.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El área de recepción está diseñada de tal manera que los contenedores de materiales puedan limpiarse antes de su almacenamiento?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un área de despacho de producto terminado?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las áreas donde se almacenan materiales y productos sometidos a cuarentena están claramente definidas y marcadas, el acceso a las mismas está limitado sólo al personal autorizado?",
                        Criterio = "CRÍTICO",
                        Articulo="8.2.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Si se cuenta con un sistema informático este debe ofrecer la misma seguridad que la identificación manual del producto",
                        Criterio = "INFORMATIVO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe documentación que lo demuestre?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                     new ContenidoPreguntas()
                    {
                        Titulo = "El área de muestreo cumple con las siguientes características:",
                        IsHeader=true,
                    },
                     new ContenidoPreguntas()
                    {
                        Titulo = "a) Las paredes, pisos y techos son lisos y con curvas sanitarias",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                      new ContenidoPreguntas()
                    {
                        Titulo = "b) Existen controles de limpieza, temperatura y humedad dentro del área de muestreo.",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                       new ContenidoPreguntas()
                    {
                        Titulo = "c) La iluminación es suficiente para el desempeño del proceso.",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                         new ContenidoPreguntas()
                    {
                        Titulo = "d) El sistema de aire es independiente.",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cuenta el laboratorio con áreas de almacenamiento separadas para productos rechazados, retirados y devueltos?",
                        Criterio = "MAYOR",
                        Articulo="8.2.7",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tienen estas áreas acceso restringido y bajo llave?",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos escritos que permitan identificar, separar, retirar y destruir los productos rechazados, retirados, vencidos y devueltos?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros de la ejecución de estos procedimientos?",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se almacenan los materiales de manera que faciliten la rotación de estos, siguiendo el sistema PEPS?",
                        Criterio = "MAYOR",
                        Articulo="8.2.8",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se almacenan los productos de manera que faciliten la rotación de los mismos, siguiendo el sistema PVPS?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Están los materiales y productos identificados y colocados sobre tarimas o estanterías separadas de paredes de manera que permitan la limpieza e inspección? ",
                        Criterio = "MAYOR",
                        Articulo="8.2.9",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los contenedores o envases de materiales y productos están bien cerrados?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los movimientos y operaciones se realizan de forma tal que no contaminen el ambiente ni los materiales allí almacenados? ",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen áreas separadas, bajo llave, de acceso restringido e identificadas para almacenar productos psicotrópicos y estupefacientes?",
                        Criterio = "CRÍTICO",
                        Articulo="8.2.10",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un área separada y de acceso restringido para almacenar material impreso (etiquetas, estuches, insertos y envases impresos)?",
                        Criterio = "CRÍTICO",
                        Articulo="8.2.12, 10.3.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Está identificada?",
                        Criterio = "MENOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion(), new OpcionEvaluacion() , new OpcionEvaluacion() , new OpcionEvaluacion() }
                    },
                }
            };

        }

        public void Inicializa_AreaAcondicionamiento()
        {
            AreaAcondicionamiento = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                    {
                        Titulo = "ÁREAS DE ACONDICIONAMIENTO",
                        Capitulo="8.4",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El laboratorio cuenta con áreas de tamaño, diseño y servicios (aire comprimido, agua, luz, ventilación, etc.) para efectuar los procesos de acondicionamiento que corresponden?",
                        Criterio = "INFORMATIVO",
                        Articulo="8.4.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las áreas de acondicionamiento (elaboración):",
                        Criterio = "CRÍTICO",
                        Articulo="8.4.2",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Están identificadas las áreas de acondicionamiento?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tienen paredes, pisos y techos lisos con curvas sanitarias de tal forma que permitan la fácil limpieza y sanitización?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Las tuberías y puntos de ventilación son de material que permitan su fácil limpieza y están correctamente ubicados?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Las ventanas y las lámparas con difusores lisos están empotrados?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Disponen de sistemas de inyección y extracción de aire?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) No son utilizadas como áreas de paso?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) Están libres de materiales y equipo que no estén involucrados en el proceso?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "h) Cuentan con equipo de control de aire?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "i) Cuentan con registros de temperatura y humedad, cuando se requiera?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "j) Las condiciones de temperatura y humedad relativa se ajustan a los requerimientos de los productos que en ella se realizan?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "k) Se toman las precauciones necesarias cuando se trabaja con materias primas fotosensibles?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "l) Tienen drenajes que no permiten la contracorriente y tienen tapa sanitaria? Si aplica",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las áreas de Empaque Primario:",
                        Criterio = "CRÍTICO",
                        Articulo="8.4.3",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Están identificadas y separadas para el empaque primario de sólidos, líquidos y semisólidos?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tienen paredes, pisos y techos lisos con curvas sanitarias de tal forma que permitan la fácil limpieza y sanitización?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Las tuberías y puntos de ventilación son de material que permitan su fácil limpieza y están correctamente ubicados?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Las ventanas y las lámparas con difusores lisos están empotrados?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Disponen de sistemas de inyección y extracción de aire?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) No son utilizadas como áreas de paso?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) Están libres de materiales y equipo que no estén involucrados en el proceso?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "h) Cuentan con equipo de control de aire?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "i) Cuentan con registros de temperatura y humedad, cuando se requiera?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "j) Tienen drenajes que no permiten la contracorriente y tienen tapa sanitaria? si aplica",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "k) Se toman las precauciones necesarias cuando se trabaja con productos fotosensibles?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un área exclusiva para el lavado de equipos móviles, recipientes y utensilios? Si aplica",
                        Criterio = "MAYOR",
                        Articulo="8.4.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las instalaciones tienen curvas sanitarias y servicios para el trabajo que allí se ejecuta?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se encuentra en buenas condiciones de orden y limpieza?",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El piso de esta área cuenta con desnivel hacia el desagüe, para evitar que se acumule el agua? Si aplica",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un área separada, identificada, limpia y ordenada para colocar equipo limpio que no se esté utilizando?",
                        Criterio = "MAYOR",
                        Articulo="8.4.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Tienen paredes, pisos y techos lisos que permitan la fácil limpieza y sanitización?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) No son utilizadas como áreas de paso?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "ÁREAS DE ACONDICIONAMIENTO PARA EMPAQUE SECUNDARIO",
                        Capitulo="8.5",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Está el área de empaque secundario separada e identificada?",
                        Criterio = "MAYOR",
                        Articulo="8.5.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El área tiene el tamaño de acuerdo con su capacidad y línea de producción, con el fin de evitar confusiones? ",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El área se encuentra ordenada y limpia?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "EL ÁREA DE EMPAQUE",
                        Criterio = "MAYOR",
                        Articulo="8.5.2",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Tienen paredes, pisos y techos lisos de tal forma que permitan la fácil limpieza y sanitización?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Están las tomas de gases y fluidos identificados?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Las ventanas y las lámparas con difusores lisos están empotrados?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Tiene ventilación e iluminación que asegure condiciones confortables al personal y no afecten negativamente la calidad del producto?",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) No son utilizadas como áreas de paso, ni cuarentena?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Están libres de materiales y equipo que no estén involucrados en el proceso?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) No se utiliza madera en esta área?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "ÁREA DE CONTROL DE CALIDAD (EN CASO DE EMPAQUE PRIMARIO)",
                        Capitulo="8.6",
                        IsHeader= true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un área destinada para el laboratorio de control de calidad que se encuentra identificada y separada del área de producción?",
                        Criterio = "CRÍTICO",

                        Articulo="8.6.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El laboratorio de control de calidad tiene las siguientes condiciones:",
                        Articulo="8.6.2",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Está diseñado de acuerdo con las operaciones que se realizan?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tiene paredes lisas que faciliten su limpieza?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tiene suficiente iluminación y ventilación?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Dispone de suficiente espacio para evitar confusiones?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "ÁREAS AUXILIARES",

                        Capitulo="8.7",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Están los servicios sanitarios accesibles a las áreas de trabajo y no se comunican directamente con las áreas de producción?",
                        Criterio = "CRÍTICO",

                        Articulo="8.7.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los vestidores están comunicados directamente con las áreas de producción? ",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los vestidores y servicios sanitarios tienen las siguientes condiciones:",

                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Identificados correctamente.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "La cantidad de servicios sanitarios para hombres y mujeres está de acuerdo con el número de trabajadores.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se mantienen limpios y ordenados",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos para la limpieza y sanitización",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros sanitización",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cuentan con lavamanos y duchas provistas de agua.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Dispone de espejos, toallas de papel o secador eléctrico de manos, jabón líquido desinfectante y papel higiénico.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Están separados los vestidores de los servicios sanitarios, manteniendo un flujo adecuado.",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Casilleros, zapateras y las bancas necesarias (no de madera)",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Rótulos o letreros que enfaticen la higiene personal (lavarse las manos antes de salir de este lugar).",
                        Criterio = "MENOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se prohíbe mantener, guardar, preparar y consumir alimentos en esta área, manteniendo rótulos que indiquen esta disposición",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se prohíbe fumar en estas áreas (rótulo). ",
                        Criterio = "MENOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cuentan con un comedor separado de las demás áreas de acondicionamiento e identificada, en buenas condiciones de orden y limpieza? ",
                        Criterio = "MAYOR",

                        Articulo="8.7.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cuentan con un área de lavandería separada y exclusiva para el lavado y secado de los uniformes utilizados por el personal?",
                        Criterio = "CRÍTICO",

                        Articulo="8.7.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Poseen procedimientos escritos para realizar el lavado y secado por separado de uniformes?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un área separada a las áreas de producción destinada al mantenimiento de equipos y al almacenamiento de herramientas y repuestos?",
                        Criterio = "MAYOR",

                        Articulo="8.7.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Dispone de un área destinada al almacenamiento del equipo obsoleto o en mal estado que no interviene en los procesos de acondicionamiento?",
                        Criterio = "MENOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                }
            };

        }

        public void Inicializa_EquiposGeneralidades()
        {
            EquiposGeneralidades = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                    {
                        Titulo = "GENERALIDADES",

                        Capitulo="9.1",

                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El equipo utilizado en el acondicionamiento, está diseñado y construido \r\nde acuerdo con la operación que se realiza?",
                        Criterio = "CRÍTICO",

                        Articulo="9.1.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "La ubicación del equipo facilita su limpieza, así como la del área en la que se encuentra?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cuenta el equipo con un código de identificación único?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Todo equipo empleado en el empaque y almacenaje, cuenta con un procedimiento en el cual se especifiquen en forma clara las instrucciones y precauciones para su operación?",
                        Criterio = "MAYOR",

                        Articulo="9.1.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros del uso de los equipos?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Todos los instrumentos de medición son utilizados de acuerdo con su rango y capacidad?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Son las piezas o partes de los equipos almacenadas en un lugar seguro y se mantienen en buen estado de conservación?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "La reparación y mantenimiento de los equipos se efectúa de tal forma que no presente ningún riesgo para la calidad de los productos?",
                        Criterio = "MAYOR",

                        Articulo="9.1.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un programa de mantenimiento preventivo de los equipos?",
                        Criterio = "MAYOR",

                        Articulo="9.1.6",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los equipos en reparación se identifican como tales? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros del mantenimiento preventivo y correctivo?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los equipos declarados fuera de servicio son identificados como tales y retirados de las áreas productivas, según procedimiento escrito? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un programa de mantenimiento de equipos?",
                        Criterio = "MAYOR",

                        Articulo="9.1.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos de la limpieza del equipo incluyendo utensilios?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se establece un período de vigencia de la limpieza de los equipos y utensilios?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Si el equipo es muy pesado, está diseñado para que se pueda ejecutar su limpieza y/o sanitización en el área de acondicionamiento? ",
                        Criterio = "MAYOR",

                        Articulo="9.1.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se identifican todos los equipos limpios con una etiqueta que indique la siguiente información:",
                        Articulo="9.1.5",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "-Nombre del equipo",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "-Fecha cuando fue realizada la limpieza. ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "-Nombre y número de lote del último producto acondicionado. ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "-Nombre y número de lote del producto a fabricar, cuando aplique.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "-Nombre o firma del operario que realizó la limpieza y de quien la verificó.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros?",
                        Criterio = "CRÍTICO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las superficies de trabajo, que tienen contacto con productos en proceso (acondicionamiento), son de acero inoxidable u otro material no reactivo?",
                        Criterio = "CRÍTICO",

                        Articulo="9.1.7",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los filtros empleados en los equipos son descartables? En caso de acondicionamiento primario?",
                        Criterio = "INFORMATIVO",

                        Articulo="9.1.7",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Si los filtros no son descartables, se les da el debido mantenimiento?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se registran los cambios de los filtros? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los soportes de los equipos que lo requieran son de acero inoxidable u otro material que no contamine?",
                        Criterio = "MENOR",

                        Articulo="9.1.8",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "CALIBRACIÓN",
                        Capitulo="9.2",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realiza calibración de los instrumentos de medición y dispositivos de registro o cualquier otro que lo requiera?",
                        Criterio = "CRÍTICO",
                        Articulo="9.2.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tienen registros escritos de las inspecciones?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tienen registros escritos de las verificaciones? ",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tienen registros escritos de las calibraciones?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los instrumentos están correctamente rotulados indicando la fecha de calibración?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realiza la calibración de cada equipo y dispositivos usando patrones de referencia certificados?",
                        Criterio = "CRÍTICO",
                        Articulo="9.2.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                }
            };

        }

        public void Inicializa_MatProducts()
        {
            MatProducts = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                    {
                        Titulo = "GENERALIDADES",
                        Capitulo="10.1",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se documenta y registra el ingreso y egreso de los materiales, según procedimiento?",
                        Criterio = "INFORMATIVO",
                        Articulo="10.1.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El material que se recibe es debidamente etiquetado?",
                        Criterio = "INFORMATIVO",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos escritos que describan las operaciones de:",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Recepción e identificación de materiales y productos. ",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Almacenamiento de materiales y productos",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Manejo de materiales y productos",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Muestreo y aprobación o rechazo de materiales y productos conforme a las especificaciones de cada uno de ellos",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los materiales y productos se manejan y almacenan de tal manera que se evite cualquier contaminación o situación que pongan en riesgo su calidad?",
                        Criterio = "MAYOR",

                        Articulo="10.1.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los recipientes o contenedores de materiales se encuentran cerrados e identificados? ",
                        Criterio = "CRÍTICO",

                        Articulo="10.1.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los materiales están ubicados en tarimas o estantes?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe espacio suficiente para realizar la limpieza e inspección y se encuentran las tarimas o estantes separados de las paredes?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Están identificados los materiales con su correspondiente número de control de acuerdo con la codificación establecida?",
                        Criterio = "MAYOR",

                        Articulo="10.1.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Proceden los materiales solamente de proveedores aprobados?",
                        Criterio = "MAYOR",

                        Articulo="10.1.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los materiales son suministrados según especificaciones proporcionadas por control de calidad, producción e investigación y desarrollo?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se verifica en cada entrega la integridad y cierres de los recipientes? en caso de acondicionamiento primario ",
                        Criterio = "MAYOR",

                        Articulo="10.1.6",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se comprueba la correspondencia entre la nota de entrega y la etiqueta colocada en el recipiente de materiales que entrega el proveedor?",
                        Criterio = "MENOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Permanecen los materiales en cuarentena mientras no sean muestreados y examinados por control de calidad?",
                        Criterio = "CRÍTICO",

                        Articulo="10.1.7",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Control de calidad emite la aprobación o rechazo de los materiales y productos? ",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realizan muestreos estadísticamente representativos en cada ingreso de materiales?",
                        Criterio = "MAYOR",

                        Articulo="10.1.8",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "La etiqueta de identificación de materiales contiene la siguiente información? ",
                        Criterio = "MAYOR",

                        Articulo="10.1.10",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Nombre y código del material.",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Número de ingreso.",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Situación del material (aprobado o rechazado).",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Nombre del proveedor.",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "MATERIALES DE ACONDICIONAMIENTO",
                        Capitulo="10.3",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los envases y cierres son hechos de material que no sea reactivo, aditivo y adsorbente al producto? En caso de acondicionamiento primario",
                        Criterio = "CRÍTICO",

                        Articulo="10.3.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los requerimientos de los envases y cierres están sustentados en los estudios de formulación y pruebas de estabilidad? En caso de acondicionamiento primario",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los envases y cierres son adquiridos de proveedores aprobados? En caso de acondicionamiento primario",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se manipulan y limpian los envases, cierres y medidas dosificadoras según procedimiento escrito, cuando aplique? ",
                        Criterio = "MAYOR",

                        Articulo="10.3.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se llevan registro de su ejecución?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Son todos los materiales de acondicionamiento examinados respecto a su cantidad, identidad y conformidad con las respectivas instrucciones de la orden de envasado, antes de ser enviados al área?",
                        Criterio = "MAYOR",

                        Articulo="10.3.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Todos los materiales impresos se manipulan por personal autorizado de forma tal que se evite cualquier confusión? ",
                        Criterio = "MAYOR",

                        Articulo="10.3.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "PRODUCTOS TERMINADOS",

                        Capitulo="10.5",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los productos terminados se encuentran en cuarentena hasta su aprobación final?",
                        Criterio = "CRÍTICO",

                        Articulo="10.5.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los productos terminados se mantienen almacenados en las condiciones requeridas?",
                        Criterio = "MAYOR",

                        Articulo="8.2.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los productos terminados son comercializados solamente después de su aprobación?",
                        Criterio = "CRÍTICO",

                        Articulo="10.5.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros de la distribución de productos terminados?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos escritos para el manejo de materiales, productos intermedios, a granel y productos terminados que han sido rechazados?",
                        Criterio = "MAYOR",

                        Articulo="10.6.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "MATERIALES Y PRODUCTOS RECHAZADOS",

                        Capitulo="10.6",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Son identificados mediante el uso de una etiqueta roja justificando la causa del rechazo?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Son devueltos o destruidos los materiales rechazados de acuerdo con procedimiento establecido cumpliendo con la normativa ambiental existente?",
                        Criterio = "MAYOR",

                        Articulo="10.6.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros de su ejecución? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El material obsoleto o desactualizado está identificado?",
                        Criterio = "MAYOR",

                        Articulo="10.6.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Es manejado y destruido según procedimiento escrito?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros?",
                        Criterio = "MENOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "PRODUCTOS DEVUELTOS",

                        Capitulo="10.7",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un procedimiento escrito para la devolución de producto?",
                        Criterio = "MAYOR",

                        Articulo="10.7.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Define este procedimiento las personas responsables y los criterios de tratamiento de los productos devueltos?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Son almacenados los productos devueltos en un área separada y con acceso restringido? ",
                        Criterio = "MAYOR",

                        Articulo="10.7.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se encuentran identificados como tales?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Quiénes son los responsables de decidir el tratamiento de las devoluciones?",
                        Criterio = "INFORMATIVO",

                        Articulo="10.7.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Actúan conjuntamente con garantía de calidad o control de calidad?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Son destruidos los productos farmacéuticos devueltos que hayan sido sometidos a condiciones extremas de manejo o almacenamiento?",
                        Criterio = "MAYOR",

                        Articulo="10.7.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe procedimiento escrito para la destrucción de estos productos? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Todas las acciones efectuadas y las decisiones tomadas son registradas, detallando:",
                        Criterio = "MAYOR",

                        Articulo="10.7.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Nombre del producto",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Forma farmacéutica.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Número de lote.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Motivo de la devolución",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Cantidad devuelta.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Fecha de la devolución.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se investiga la causa de la devolución y se determina si afecta cualquier otro lote?",
                        Criterio = "MAYOR",

                        Articulo="10.7.6",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },new ContenidoPreguntas()
                    {
                        Titulo = "Existe registro de las acciones correctivas?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                }
            };

        }

        public void Inicializa_Documentacion()
        {
            Documentacion = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                    {
                        Titulo = "GENERALIDADES",

                        Capitulo="11.1",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Están las especificaciones, métodos e instrucciones de acondicionamiento y procedimientos en forma impresa, debidamente revisadas y aprobadas?",
                        Criterio = "CRÍTICO",

                        Articulo="11.1.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Están los documentos diseñados, revisados y distribuidos de acuerdo con un procedimiento escrito?",
                        Criterio = "MAYOR",

                        Articulo="11.1.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Están los documentos aprobados, firmados y fechados por las personas autorizadas?",
                        Criterio = "MAYOR",

                        Articulo="11.1.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las modificaciones están autorizadas?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tienen los documentos las siguientes características:",


                        Articulo="11.1.4",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Están redactados en forma clara, ordenada y libre de expresiones ambiguas, permitiendo su fácil comprensión?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Son fácilmente verificables?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Se revisan periódicamente y se mantienen actualizados?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Son reproducidos en forma clara e indeleble?",
                        Criterio = "MENOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "La introducción de datos se realiza con letra clara legible y con tinta indeleble?",
                        Criterio = "MAYOR",

                        Articulo="11.1.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Hay en los documentos que lo requieran, espacio para permitir la realización del registro de datos? ",
                        Criterio = "MENOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los documentos y datos registrados se encuentran en medio electrónicos?",
                        Criterio = "INFORMATIVO",

                        Articulo="11.1.6",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen controles especiales?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Sólo las personas autorizadas acceden o modifican los datos en la computadora? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe registro de los cambios y las eliminaciones?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Está el acceso restringido por contraseñas u otros medios? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cualquier corrección realizada en un documento de un dato escrito está firmada y fechada? ",
                        Criterio = "MAYOR",

                        Articulo="11.1.7",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "La corrección no impide la lectura del dato inicial?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Indica la causa de la corrección, cuando sea necesario?",
                        Criterio = "MENOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe registro de todas las acciones efectuadas o completadas de tal forma que haya trazabilidad de todas las operaciones de los procesos de fabricación de los productos farmacéuticos?",
                        Criterio = "MAYOR",

                        Articulo="11.1.8",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se mantienen todos los registros incluyendo lo referente a los procedimientos de operación, un año después de la fecha de expiración del producto terminado? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un listado maestro de documentos disponible?",
                        Criterio = "MENOR",

                        Articulo="11.1.9",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se identifica el estado de estos?",
                        Criterio = "MENOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Están los documentos actualizados en los sitios relacionados a las operaciones esenciales para cada proceso? ",
                        Criterio = "MAYOR",

                        Articulo="11.1.10",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Son retirados los documentos invalidados u obsoletos de todos los puntos de uso? ",
                        Criterio = "MAYOR",

                        Articulo="11.1.11",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un archivo histórico identificado para almacenar los originales de los documentos obsoletos?",
                        Criterio = "MENOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "DOCUMENTOS EXIGIDOS",

                        Capitulo="11.2",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen especificaciones autorizadas y fechadas por control de calidad para:",


                        Articulo="11.2.1",
                        IsHeader = true,
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "a) Materia prima.",
                    //    Criterio = "CRÍTICO",


                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Material de acondicionamiento.",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Productos intermedios o granel. En caso de acondicionamiento",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Producto terminado",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Incluyen las especificaciones del material de acondicionamiento, productos intermedios o granel (si aplica) y producto terminado lo siguiente:",
                        Criterio = "MAYOR",

                        Articulo="11.2.2",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Nombre del material (denominación común internacional, cuando corresponda).",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Código de referencia interna.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Referencia, si la hubiere de los libros oficiales.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "d) Formula química (cuando aplique).",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "e) Requisitos cuali y cuantitativos con límites de aceptación (cuando aplique).",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "f) Las técnicas analíticas o procedimiento.",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) Procedimiento de muestreo.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "h) Muestra del material impreso (cuando aplique).",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "i) Cantidad requerida para la muestra de retención.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "j) Condiciones de almacenamiento y precauciones.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "k) Proveedores aprobados y marcas comerciales (cuando aplique).",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "l) Descripción de la forma farmacéutica y detalle del empaque (cuando aplique).",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "m) Vida en anaquel (cuando aplique).",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "Realizan revisión periódica de las especificaciones analíticas?",
                    //    Criterio = "MAYOR",

                    //    Articulo="11.2.3",
                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "Están de acuerdo a los libros oficiales? ",
                    //    Criterio = "MAYOR",


                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "Disponen de una fórmula maestra para cada producto?",
                    //    Criterio = "CRÍTICO",

                    //    Articulo="11.2.4",
                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "Está la fórmula maestra actualizada y autorizada?",
                    //    Criterio = "CRÍTICO",


                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "Quién la actualiza y autoriza?",
                    //    Criterio = "INFORMATIVO",


                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "Contiene la fórmula maestra los datos siguientes:",
                    //    Criterio = "MAYOR",

                    //    Articulo="11.2.5",
                    //    IsHeader = true,
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "a) Nombre y código del producto correspondiente a su especificación",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "b) Descripción de la forma farmacéutica, potencia o concentración del principio activo y tamaño de lote.",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "c) Fórmula cuali-cuantitativa expresada en el sistema métrico decimal, de las materias primas a emplearse, haciendo mención de cualquier sustancia que pueda desaparecer durante el proceso, usando el nombre y código que es exclusivo para cada material.",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "d) Lista de material de empaque primario y secundario a emplearse, indicando la cantidad de cada uno y el código que es exclusivo para cada material.",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "e) Indicación del rendimiento teórico con los límites de aceptabilidad.",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "f) Indicación de las áreas en las que deben ser realizadas cada una de las etapas del proceso y de los principales equipos a ser empleados.",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "g) Instrucciones detalladas de los pasos a seguir en el proceso de producción, mencionando los distintos procedimientos relacionados con las etapas de producción y operación de equipos",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "h) Instrucciones referentes a los controles a realizar durante el proceso de producción, indicando especificaciones del producto.",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "i) Indicaciones para el almacenamiento de los productos(semielaborados o graneles y terminado), incluyendo el contenedor, el etiquetado y cualquier otra condición de almacenamiento cuando las características del producto lo requieran. ",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "j) Precauciones especiales que deben tomarse en cuenta en las distintas etapas del proceso? ",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "k) Nombres y firmas de las personas responsables en la emisión, revisión y aprobación de la fórmula maestra y fecha de la aprobación.",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "l) Exceso de principios activos (si procede)",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "Coinciden las fórmulas maestras de todos los productos fabricados con las presentadas en la documentación para obtención del registro sanitario?",
                    //    Criterio = "CRÍTICO",

                    //    Articulo="11.2.6",
                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "Si se hace cambio de la fórmula cuali-cuantitativa, estos cambios son comunicados y aprobados por la Autoridad Reguladora competente?",
                    //    Criterio = "CRÍTICO",


                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "La orden de acondicionamiento correspondiente a un lote, es emitida por el departamento asignado para este fin? ",
                        Criterio = "MAYOR",

                        Articulo="11.2.7",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Quién la emite?",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "Es una reproducción del registro de la fórmula maestra, que al asignarle un número de lote se convierte en orden de producción?",
                    //    Criterio = "MAYOR",


                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "La orden de acondicionamiento está autorizada por las personas asignadas?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tiene la orden de acondicionamiento además de lo indicado en la fórmula maestra la información siguiente: ",
                        Criterio = "MAYOR",

                        Articulo="11.2.8",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Código o número de lote.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Fecha de inicio y finalización del acondicionamiento.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Fecha de expiración del producto",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Firma de las personas que autorizan la orden de acondicionamiento.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "e) Número de lote de la materia prima y cantidades reales utilizadas de cada uno de ellos",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Firma de la persona que despacha, recibe y verifica los insumos",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) Firma de las personas que intervienen y supervisan la ejecución de cada etapa de los procesos.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "h) Resultados de los análisis del producto en proceso.",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "i) Hojas para el registro de controles durante el proceso y espacio para anotar observaciones.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "j) Espacios para anotar rendimientos intermedios y reales.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "k) Instrucciones para la toma de muestras en las etapas que sean necesarias.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se adjuntan las etiquetas de identificación de áreas y equipos?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se registra en la orden de acondicionamiento lo siguiente:",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) La liberación de áreas y equipos.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) La fecha, hora de inicio y de finalización para cada etapa",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Los valores de las variables operacionales a controlar durante el proceso. ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Fecha de emisión.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Los rendimientos",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Además de lo indicado en la fórmula maestra, incluye la orden de envasado (si aplica) y empaque lo siguiente:",
                        Criterio = "MAYOR",

                        Articulo="11.2.9",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Código o número de lote.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Cantidad del producto a envasar (si aplica) o empacar.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Fecha de inicio y finalización de las operaciones de acondicionamiento.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Fecha de expiración para cada lote y vida útil del producto",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Firma de las personas que autorizan la orden de envase (si aplica) y empaque.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Número de lote, cantidades, tipos y tamaños de cada material de envase (si aplica) y empaque utilizado",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) Firma de las personas que despacha, recibe y verifica los insumos",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "h) Firma de las personas que intervienen y supervisan los procesos de envasado (si aplica) y empaque.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "i) Hojas para el registro de controles durante el proceso de empaque y espacio para anotar observaciones hechas por el personal de empaque y control de calidad.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "j) Muestras del material de acondicionamiento impreso que se haya utilizado incluyendo muestras con el número de lote, fecha de expiración y cualquier impresión suplementaria.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "k) Cantidades de los materiales impresos de acondicionamiento que han sido devueltos al almacén o destruidos y las cantidades de producto obtenido, con el fin de obtener el balance.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "l) Número de registro sanitario.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Rendimiento de la operación de empaque (cantidad real obtenida y conciliación). ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "¿Se registran la(s) fecha(s) y hora(s) de las operaciones de envasado (si aplica) y empaque?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se registran notas acerca de cualquier problema especial, incluyendo detalles de cualquier desviación de las instrucciones de envasado (si aplica), con la autorización escrita de la persona responsable?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "PROCEDIMIENTOS Y REGISTROS",

                        Capitulo="11.3",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se dispone de procedimientos escritos para el control del acondicionamiento y demás actividades relacionadas? ",
                        Criterio = "MAYOR",

                        Articulo="11.3.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se registra la ejecución de las actividades respectivas firmándolas de conformidad con el registro de firmas, inmediatamente después de su realización?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Queda registrada y justificada cualquier desviación de los procedimientos, por un evento atípico que afecta la calidad del producto?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Control de calidad o garantía de calidad revisan, aprueban y verifican todos los registros de acondicionamiento, así como los procedimientos escritos?",
                        Criterio = "MAYOR",

                        Articulo="11.3.3, 11.3.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un procedimiento escrito para el manejo de la desviación en el acondicionamiento?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se investiga ampliamente cualquier desviación no justificada?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se extiende la investigación a otros productos que puedan estar asociados con la discrepancia encontrada?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un procedimiento escrito para el archivo y conservación de la documentación de los productos acondicionados?",
                        Criterio = "MAYOR",

                        Articulo="11.3.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se recopila toda la documentación involucrada en el acondicionamiento de producto (orden de acondicionamiento, orden de envasado (si aplica) y empaque, etiquetas, muestras del material de empaque codificado)",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se conserva esta documentación archivada por lo menos hasta un año después de la fecha de vencimiento del producto?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se lleva registro correlativo/ secuencial y rastreable de cada acondicionamiento?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos y registros escritos correspondientes a las actividades realizadas sobre:",


                        Articulo="11.3.5  12.1.1",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Mantenimiento, limpieza y sanitización de instalaciones, áreas y servicios.",
                        Criterio = "MAYOR",

                        Articulo="12.1.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Uso, mantenimiento, limpieza y sanitización de equipos y utensilios",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "c) Sanitización y mantenimiento de tuberías y de las tomas de fluidos",
                    //    Criterio = "MAYOR",


                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Calibración de equipo",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "e) Asignación de número de lote. ",
                    //    Criterio = "MAYOR",


                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Capacitación del personal (inducción, específica, continua)",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) Uso, lavado y secado de uniformes.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "h) Control de las condiciones ambientales (controles microbiológicos de ambiente y superficies) en caso de empaque primario",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "i) Prevención y exterminio de plagas con insecticidas y agentes de fumigación, aprobados por la Autoridad Sanitaria respectiva",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "j) Recolección, clasificación y manejo de basuras y desechos.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "k) Muestreo (materiales y productos). ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "l) Validaciones",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cada procedimiento escrito tiene claramente definido el propósito, alcance, referencias y responsabilidades?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()}
                    },
                }
            };

        }

        public void Inicializa_Acondicionamiento()
        {
            Acondicionamiento = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                    {
                        Titulo = "GENERALIDADES",

                        Capitulo="12.1",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos o instrucciones escritas para el manejo de materiales, y productos en las operaciones de:",

                        Articulo="12.1.2",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cuarentena",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Etiquetado",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Muestreo",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Acondicionamiento",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Almacenamiento",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Despacho",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "Elaboración",
                    //    Criterio = "MAYOR",


                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    //},
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "Envasado",
                    //    Criterio = "MAYOR",


                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "Distribución",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se llevan registro de la ejecución de estos?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se evita cualquier desviación a las instrucciones o procedimientos? ",
                        Criterio = "MAYOR",

                        Articulo="12.1.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las desviaciones en las instrucciones o procedimientos son aprobadas por escrito, por la persona asignada con participación del departamento de control de calidad?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros de los controles de proceso y forman parte de toda la documentación del lote del producto acondicionado?",
                        Criterio = "MAYOR",

                        Articulo="12.1.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "En un área de acondicionamiento se lleva a cabo una sola operación de un determinado producto? ",
                        Criterio = "CRÍTICO",

                        Articulo="12.1.6",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se evita la mezcla de productos diferentes o lotes distintos del mismo producto mediante separación física entre las líneas de envasado? En caso de acondicionamiento primario",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "En el área de empaque secundario existen líneas identificadas, definidas y separadas para cada producto que se está empacando?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se identifica durante todo el proceso todos los materiales, graneles (si aplica), equipos y áreas utilizadas con una etiqueta que tenga la siguiente información:",

                        Articulo="12.1.7",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Nombre del producto que se está elaborando",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Número de lote o código",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Fase del proceso",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Fecha",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las áreas y los equipos son destinados únicamente para el acondicionamiento de medicamentos?",
                        Criterio = "MAYOR",

                        Articulo="12.1.9",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "PREVENCIÓN DE LA CONTAMINACIÓN CRUZADA Y MICROBIANA EN LA PRODUCCIÓN",

                        Capitulo="12.2",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos escritos que indiquen medidas preventivas para evitar la contaminación cruzada en todas las fases de acondicionamiento, los productos y materiales?",
                        Criterio = "MAYOR",

                        Articulo="12.2.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros?",
                        Criterio = "CRÍTICO",

                        Articulo="12.2.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Para evitar la contaminación cruzada se tiene: ",
                        Criterio = "CRÍTICO",

                        Articulo="12.2.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Esclusas (cuando aplique).",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "b) Áreas con diferenciales de presión.",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Sistema de inyección y extracción que garantice la calidad de aire",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Ropa protectora dentro de las áreas en las que se acondicionen productos",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Procedimientos de limpieza y sanitización.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "f) Pruebas para detectar residuos (trazas) en los productos altamente activos (cuando aplique).",



                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) Etiquetas que indique la situación del estado de limpieza del equipo y áreas.",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los materiales y productos son protegidos de la contaminación?",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se verifica la eficacia de las medidas destinadas a prevenir la contaminación cruzada?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "CONTROLES EN PROCESO",

                        Capitulo="12.3",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Antes de iniciar las operaciones de acondicionamiento se realiza el despeje del área, se verifica que los equipos estén limpios y libres de materiales, productos y documentos de una operación anterior y cualquier otro material extraño al proceso de acondicionamiento?",
                        Criterio = "CRÍTICO",

                        Articulo="12.3.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realizan controles durante el proceso en las distintas etapas de acondicionamiento? ",
                        Criterio = "CRÍTICO",

                        Articulo="12.3.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Estos controles se realizan dentro de las áreas de acondicionamiento?",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Estos controles no ponen en riesgo el acondicionamiento del producto?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realizan controles en línea durante el envasado (si aplica) y empaque?",
                        Criterio = "CRÍTICO",

                        Articulo="12.3.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Estos controles incluyen los siguiente:",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Revisión general de los envases",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Verificación de la cantidad de material de acondicionamiento",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Verificar que el código o número de lote y la fecha de expiración sean los correctos y legibles.",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Verificar el funcionamiento correcto de la línea. Si Aplica",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Se verifica la integridad de los cierres. Si Aplica",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Si se utilizan máquinas automáticas para controlar dimensiones, pesos, etiquetas, prospectos, códigos de barras, se verifica su correcto funcionamiento (cuando aplique)?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las unidades descartadas por sistemas automáticos, en caso de reintegrarse para controlar dimensiones, pesos, etiquetas, prospectos, códigos de barras, son verificadas para su correcto funcionamiento (cuando aplique)",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un programa y procedimiento escrito para realizar los controles microbiológicos de superficie? En caso de acondicionamiento primario",
                        Criterio = "MAYOR",

                        Articulo="12.3.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas()
                    {
                        Titulo = "Se llevan registros de estos controles?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "En caso de que estos controles microbiológicos se salgan de los límites específicos se realiza alguna medida correctiva?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cuál?",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realizan controles microbiológicos en forma inmediata después de la medida correctiva?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros de todo lo que se efectuó?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se llevan los controles ambientales durante el proceso, cuando estos sean requeridos (temperatura, humedad)?",
                        Criterio = "CRÍTICO",

                        Articulo="12.3.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se inspecciona y verifica el material impreso antes de la codificación del número de lote y fecha de vencimiento de cada producción?",
                        Criterio = "MAYOR",

                        Articulo="12.3.6",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe registro de esta actividad?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los envases primarios vacíos impresos llevan número de lote y fecha de vencimiento, cuando aplique?",
                        Criterio = "MENOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Si los envases primarios vacíos no llevan lote y fecha de vencimiento, se codifican manual o automáticamente?",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Si la impresión de etiquetas y estuches se realizan fuera de la línea de empaque, la operación se lleva a cabo en un área exclusiva?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se codifican por sistema manual o automático? ",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe registro de la persona que realiza la actividad? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se verifica por personal autorizado el correcto número de lote y fecha de vencimiento?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "La información impresa o estampada es legible e indeleble?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se efectúa la operación de etiquetado o empaque final después del envasado y cierre? En acondicionamiento primario",
                        Criterio = "MAYOR",

                        Articulo="12.3.7",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cuando no se realiza en línea, se toman las medidas para asegurar que no haya confusión o errores en el etiquetado y empaque final?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cómo se dispensan las etiquetas? ",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un procedimiento escrito donde se indican las medidas de seguridad que se deben tomar para evitar mezclas y confusiones de las etiquetas o cualquier material de acondicionamiento durante el empaque?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las muestras tomadas de la línea de envasado y empaque para análisis, se descartan después de ser analizadas? En caso de acondicionamiento primario.",
                        Criterio = "MAYOR",

                        Articulo="12.3.8",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se investiga cualquier desviación significativa del rendimiento esperado de los productos acondicionados? ",
                        Criterio = "MAYOR",

                        Articulo="12.3.9",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros de esta desviación y de la investigación realizada?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos escritos establecidos para la conciliación de las etiquetas o material de acondicionamiento impreso, entregadas, usadas, devueltas en buen estado y destruidas?",
                        Criterio = "MAYOR",

                        Articulo="12.3.10",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realiza una evaluación de las diferencias encontradas?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se investigan las causas de estas diferencias?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros de estos resultados, conclusiones y de las acciones correctivas? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El material impreso y codificado sobrante se destruye?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros de esta destrucción?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El material impreso no codificado sobrante, se devuelve al almacén de material de acondicionamiento?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros de este material devuelto?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                }
            };

        }

        public void Inicializa_GarantiaCalidad()
        {
            GarantiaCalidad = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                    {
                        Titulo = "GENERALIDADES",

                        Capitulo="13.1",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe una política de calidad definida y está documentada?",
                        Criterio = "CRÍTICO",

                        Articulo="13.1.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Garantía de calidad cuenta con el respaldo y compromiso de la dirección de la empresa?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Hay evidencia de este respaldo y compromiso?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Garantía de calidad exige la participación y el compromiso del personal de los diferentes departamentos y a todos los niveles dentro de la empresa?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe en la empresa el personal competente que coordine el sistema de garantía de la calidad?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "La política de calidad es divulgada en todos los niveles?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos escritos para esta divulgación?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El sistema de garantía de calidad asegura que:",


                        Articulo="13.1.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se disponen de protocolos y registros de todos los productos de manera que se verifica, que cada lote (para empaque primario) de producto es acondicionado y controlado correctamente de acuerdo con los procedimientos definidos?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Si en la revisión de los registros de acondicionamiento se detectan desvíos de los procedimientos establecidos, garantía de calidad es responsable de asegurar su completa investigación y que las conclusiones estén justificadas?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se mantienen documentos originales de todos los procedimientos y registros de distribución de las copias autorizadas?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Estén claras las especificaciones de las operaciones de acondicionamiento y control?",
                        Criterio = "MAYOR",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) El personal directivo tenga las responsabilidades claramente especificadas y divulgadas?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Se tengan los requisitos establecidos para la adquisición y utilización de los materiales?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Se realice la evaluación y aprobación de los diferentes proveedores?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Todos los controles durante el proceso sean llevados a cabo de acuerdo con procedimientos establecidos?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) El producto terminado se ha elaborado y controlado de forma correcta, según procedimientos definidos?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "h) Exista un procedimiento para la recopilación de toda la documentación del producto que se ha elaborado? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "i) Los medicamentos sean liberados para la venta o suministro con la autorización de la persona calificada y asignada para hacerlo? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "j) Los medicamentos sean almacenados y distribuidos de manera que la calidad se mantenga durante todo el período de vida útil?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "k) Verifica que se realizan periódicamente la autoinspección y auditoría de calidad mediante el cual se evalúe la eficacia y aplicabilidad del sistema de garantía de la calidad?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "l) Verifica que existan y ejecuten los procedimientos, programas y registros de los Estudios de Estabilidad de los productos? En caso de empaque primario",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "m) Verifica que exista, se ejecute y se cumpla el plan maestro de validación?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Da seguimiento a las actividades de validación?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Garantía de Calidad verifica el cumplimiento de los planes de capacitación del personal?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se archiva la documentación de cada lote (empaque primario) acondicionado?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                }
            };

        }

        public void Inicializa_ControlCalidad()
        {
            ControlCalidad = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                    {
                        Titulo = "GENERALIDADES",

                        Capitulo="14.1",

                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tiene control de calidad toda la documentación para asegurar la calidad de los materiales y los productos? ",
                        Criterio = "CRÍTICO",

                        Articulo="14.1.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Está establecido un flujo claramente definido de muestras y documentación?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El laboratorio acondicionador cuenta con una unidad de control de calidad?",
                        Criterio = "CRÍTICO",

                        Articulo="14.1.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Control de calidad interviene en todas las operaciones y decisiones que afectan la calidad del producto? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "La unidad de control de calidad es independiente de producción (acondicionamiento)?",
                        Criterio = "CRÍTICO",

                        Articulo="14.1.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "A quién reporta?",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Esta unidad está bajo el cargo de un profesional farmacéutico o un profesional calificado?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Qué profesión tiene?",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Control de calidad cuenta con los recursos que garanticen la confiabilidad en la toma de las decisiones?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "La unidad de control de calidad tiene las siguientes obligaciones:",


                        Articulo="14.1.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Valida y aplica todos sus procedimientos.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Conserva las muestras de referencia (en caso de empaque primario) o retención de materiales y productos.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Garantiza el etiquetado correcto de los materiales y productos.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    //new ContenidoPreguntas()
                    //{
                    //    Titulo = "d) Realiza la estabilidad de los productos",
                    //    Criterio = "MAYOR",


                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    //},
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Participa en la investigación de reclamos relativos a la calidad del producto.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Aprueba o rechaza los materiales y productos.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos escritos de estas actividades?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registro de la ejecución de todas estas actividades?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cada lote (empaque primario) de producto acondicionado es aprobado por la persona responsable, previa evaluación de las especificaciones establecidas, incluyendo las condiciones de acondicionamiento y la documentación para su aprobación final?",
                        Criterio = "CRÍTICO",

                        Articulo="14.1.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Hay personal con responsabilidad asignada y destinado a inspeccionar los procesos de acondicionamiento (propios y de terceros)?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se investigan y documentan las desviaciones de los parámetros establecidos?",
                        Criterio = "MAYOR",

                        Articulo="14.1.6",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se da seguimiento de las acciones correctivas?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se documentan?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tiene acceso el personal de control de calidad a las áreas de acondicionamiento con fines de muestreo, inspección e investigación?",
                        Criterio = "MAYOR",

                        Articulo="14.1.7",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Hay un programa de calibración para los equipos?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros que acrediten el cumplimiento del programa?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se indica en el mismo cuales operaciones son realizadas en forma interna y cuales por servicios contratados?",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los equipos están correctamente rotulados indicando la vigencia de la calibración?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Fecha de su última calibración",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "En el caso de calibraciones internas el laboratorio cuenta con patrones certificados?",
                        Criterio = "CRITICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen los certificados correspondientes?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "DOCUMENTACIÓN",

                        Capitulo="14.2",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "La unidad de control de calidad tiene a su disposición la documentación siguiente:",


                        Articulo="14.2.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Especificaciones escritas de los materiales y producto terminado?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Procedimiento escrito para manejo de muestra de retención? (en caso de empaque primario)",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Procedimientos escritos de control de calidad y resultados de las pruebas de materiales, áreas y personal (en caso de empaque primario)?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros de los informes de las pruebas de materiales, áreas y personal?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Si se observan modificaciones de datos, la enmienda realizada está fechada, firmada y permite visualizar el dato original?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Los formatos para los informes?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "En caso de contar con sistemas computarizados para la obtención de datos, los mismos permiten ser verificados?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Están los resultados y graficas impresos y archivados?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Existen registro de los resultados de las condiciones ambientales de las áreas de acondicionamiento? Cuando aplique",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "h) Procedimientos escritos para la calibración de instrumentos y equipos?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros de la calibración de instrumentos y equipos?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los certificados o informes de calibración indican la trazabilidad a patrones?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los certificados o informes de calibración indican la incertidumbre de la medida correspondiente?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "j) Procedimientos escritos de selección y calificación de proveedores?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un registro de proveedores aprobados?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un programa de evaluación y auditorías a proveedores?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros de estas evaluaciones y auditorías?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realiza una evaluación de los resultados?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se adoptan medidas cuando los resultados no son favorables?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "k) Procedimientos escritos y programa de sanitización de áreas?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "m) Procedimiento escrito para la aprobación y rechazo de materiales?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Control de calidad conserva toda la documentación relativa a los lotes acondicionados según la legislación de cada país?",
                        Criterio = "MAYOR",

                        Articulo="14.2.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "MUESTREO",

                        Capitulo="14.3",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos escritos para el muestreo de:",


                        Articulo="14.3.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "materiales de envase (si aplica) y empaque.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "producto acondicionado",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Estos procedimientos contemplan la siguiente información:",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) El método de muestreo",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c)  La cantidad de muestra de producto acondicionado",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "h) Condiciones de almacenamiento",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe registro que garantice el cumplimiento de los procedimientos de muestreo?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "La cantidad de muestra es estadísticamente representativa del total de",


                        Articulo="14.3.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "materiales de envase (si aplica) y empaque. ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                }
            };

        }

        public void Inicializa_ProdAnalisisContrato()
        {
            ProdAnalisisContrato = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                    {
                        Titulo = "GENERALIDADES",

                        Capitulo="15.1",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El laboratorio realiza actividades de acondicionamiento a terceros?",
                        Criterio = "INFORMATIVO",

                        Articulo="15.1.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Especifique:",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe contrato?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El contrato a terceros para el acondicionamiento está debidamente\r\nlegalizado, definido y de mutuo consentimiento?",
                        Criterio = "MAYOR",

                        Articulo="15.1.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El contrato estipula las obligaciones de cada una de las partes con relación a: ",

                        Articulo="15.1.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },

                    // ***** INICIO DE LAS CORRECCIONES *****

                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Acondicionamiento",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Manejo",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Almacenamiento",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Liberación del producto.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se establece en el contrato la persona responsable de autorizar la liberación de cada lote para su comercialización?",
                        Criterio = "MAYOR",

                        Articulo="15.1.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El contrato a terceros tiene la siguiente información:",
                        Criterio = "MAYOR",

                        Articulo="15.1.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Es redactado por personas competentes y autorizadas?",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Aceptación de los términos del contrato por las partes?",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Cumplimiento de las Buenas Prácticas de Manufactura?",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Abarca acondicionamiento o cualquier otra gestión técnica relacionada con estos?",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Describe el manejo de material de acondicionamiento, y producto terminado, en caso sean rechazados?",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Permite el ingreso del contratante a las instalaciones del contratista (contratado), para auditorías?",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) Permite el ingreso del contratista (contratado) a las instalaciones del contratante?",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "h) Existe una lista de los productos o servicios de objeto del contrato?",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },

                    // ***** FIN DE LAS CORRECCIONES *****

                    /* ***** INICIO DEL CÓDIGO ANTES DE LA CORRECCIÓN *****
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Fabricación.",
                        Criterio = "MAYOR",
                        
                        
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Manejo.",
                        Criterio = "MAYOR",
                        
                        
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Almacenamiento.",
                        Criterio = "MAYOR",
                        
                        
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Control de calidad.",
                        Criterio = "MAYOR",
                        
                        
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Análisis. ",
                        Criterio = "MAYOR",
                        
                        
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Liberación del producto.",
                        Criterio = "MAYOR",
                        
                        
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) Permite el ingreso del contratista (contratado) a las instalaciones del contratante?",
                        Criterio = "MAYOR",
                        
                        
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "h) Existe una lista de los productos o servicios de objeto del contrato?",
                        Criterio = "MAYOR",
                        
                        
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    }, 

                    ***** FIN DEL CÓDIGO ANTES DE LA CORRECCIÓN ***** */

                    new ContenidoPreguntas()
                    {
                        Titulo = "DEL CONTRATANTE",

                        Capitulo="15.2",

                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Ha verificado el contratante que el contratista (contratado):",

                        Articulo="15.2.1",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Cumple con los requisitos legales, para su funcionamiento",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Cumple con las buenas prácticas de manufactura y de laboratorio, con instalaciones, equipo, conocimientos y experiencia para llevar a cabo satisfactoriamente el trabajo contratado",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Posee certificado vigente de buenas prácticas de manufactura.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Entrega los productos elaborados cumpliendo con las especificaciones correspondientes y que han sido aprobados por una persona calificada.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Entrega los certificados de análisis con su documentación de soporte, cuando aplique según contrato",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "DEL CONTRATISTA",

                        Capitulo="15.3",

                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Ha verificado el contratista (contratado) que el contratante:",


                        Articulo="15.3.1",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Cumple con los requisitos legales de funcionamiento",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Proporciona toda la información necesaria para que las operaciones se realicen de acuerdo con el registro sanitario y otros requisitos legales",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se indica en el contrato que el contratista (contratado) no puede ceder a terceros todo o parte del trabajo que se le asigno, por contrato?",
                        Criterio = "MAYOR",

                        Articulo="15.3.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                }
            };

        }

        public void Inicializa_ValGenerales()
        {
            ValGenerales = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>()
                {
                    new ContenidoPreguntas()
                    {
                        Titulo = "GENERALIDADES",

                        Capitulo="16.1",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un plan maestro de validación?",
                        Criterio = "CRÍTICO",

                        Articulo="16.1.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El plan maestro de validación contempla lo siguiente:",

                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Recursos y responsables de su ejecución",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Identificación de los sistemas y procesos a validarse. ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Documentación y procedimientos escritos, instrucciones de trabajo y estándares (normas nacionales e internacionales que apliquen).",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Lista de validación: instalaciones físicas, procesos, productos.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Criterios de aceptación claves.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Formato de los protocolos.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) Cada actividad de la validación incluida la revalidación. (Programa de validación y revalidación).",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Está incluido en el plan maestro de validación, control de calidad?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Garantía de calidad da seguimiento a las actividades del programa?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El programa de validación incluye:",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Cronograma",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Ubicación de cada actividad.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Responsables de la ejecución. ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Los procesos de importancia crítica se validan.",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Prospectivamente?",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Retrospectivamente?",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Concurrentemente?",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se cumplen los plazos establecidos en los programas de validación y revalidación?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un comité multidisciplinario responsable de coordinar e implementar el plan maestro y todas las actividades de validación?",
                        Criterio = "MAYOR",

                        Articulo="16.1.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "CONFORMACIÓN DE EQUIPOS",

                        Capitulo="16.2",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen equipos conformados por personal calificado en los diferentes aspectos a validar?",
                        Criterio = "CRÍTICO",

                        Articulo="16.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El personal que participa en las actividades ha recibido capacitación en el tema de validación? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "PROTOCOLOS E INFORMES",

                        Capitulo="16.3",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los protocolos de validación están aprobados?",
                        Criterio = "CRÍTICO",

                        Articulo="16.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los protocolos de validación incluyen lo siguiente:",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Procedimiento para la realización de la validación",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Criterios de aceptación",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Informe final aprobado de resultados y conclusiones.",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "La documentación de validación esta resguardada y se localiza fácilmente?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "CALIFICACIÓN Y VALIDACIÓN",

                        Capitulo="16.4",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realizan y documentan las calificaciones y validaciones de:",

                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Equipos de acondicionamiento y control de calidad (si aplica) ",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Procedimientos de limpieza. ",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "i) Instalaciones. ",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "j) Sistemas informáticos (cuando aplique).",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "DE LA VALIDACIÓN DE MODIFICACIONES",

                        Capitulo="16.6",

                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se valida toda modificación importante del proceso de acondicionamiento, incluyendo cualquier cambio en equipos, áreas de acondicionamiento y materiales?",
                        Criterio = "MAYOR",

                        Articulo="16.6",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Todos los cambios son requeridos formalmente, documentados y aprobados por el comité multidisciplinario? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se evalúan estos cambios para determinar si es necesario una re-validación?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "REVALIDACIÓN",
                        Capitulo="16.7",
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se establecen los criterios para evaluar los cambios que dan origen a una revalidación? ",
                        Criterio = "CRÍTICO",

                        Articulo="16.7",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realizan análisis de tendencia para evaluar la necesidad de revalidar a efectos de asegurar que los procesos y procedimientos sigan obteniendo los resultados deseados?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se han definido tiempos para revalidar los procesos, equipos, métodos y sistemas críticos?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                }
            };

        }

        public void Inicializa_QuejasReclamos()
        {
            QuejasReclamos = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas()
                    {
                        Titulo = "GENERALIDADES",

                        Capitulo="17.1",

                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen procedimientos escritos sobre el manejo de:",


                        Articulo="17.1.1",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Quejas o reclamos.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Retiro de productos del mercado.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un sistema para retirar del mercado en forma rápida y efectiva un producto cuando tenga un defecto o exista sospecha de ello, según procedimiento?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "QUEJAS O RECLAMOS",

                        Capitulo="17.2",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El procedimiento indica quien es la persona responsable de atender las quejas o reclamos?",
                        Criterio = "MAYOR",

                        Articulo="17.2.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El procedimiento indica que medida deben de adoptarse en conjunto con el personal de otros departamentos involucrados?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Quien coordina la recepción y seguimiento de las quejas o reclamos?",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El procedimiento sobre el manejo de quejas o reclamos de productos tiene la siguiente información:",


                        Articulo="17.2.2",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Nombre del producto.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Forma y presentación farmacéutica.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Código o número de lote del producto.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Fecha de expiración.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "e) Nombre y datos generales de la persona que realizó el reclamo.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "f) Fecha del reclamo. ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "g) Motivo del reclamo.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "h) Revisión de las condiciones del producto cuando se recibe",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "i) Investigación que se realiza",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "j) Determinación de las acciones correctivas y medidas adoptadas.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se evalúan otros lotes (empaque primario) relacionados con el producto acondicionado al cual se refiere la queja o reclamo, se indica en el procedimiento escrito?",
                        Criterio = "MAYOR",

                        Articulo="17.2.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se documenta esta evaluación?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se registran todas las acciones y medidas generadas como resultado de la investigación de una queja, se indica en el procedimiento escrito?",
                        Criterio = "MAYOR",

                        Articulo="17.2.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El registro es claro e identifica el lote o lotes investigados?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realizan revisiones periódicas para evaluar las tendencias de las quejas de manera que se puedan tomar acciones preventivas, se indica en el procedimiento escrito?",
                        Criterio = "MAYOR",

                        Articulo="17.2.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se documenta esta revisión periódica?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Informa el laboratorio acondicionador a la Autoridad Reguladora sobre acciones o medidas específicas tomadas como resultado de una queja o reclamo grave, se indica en el procedimiento escrito?",
                        Criterio = "MAYOR",

                        Articulo="17.2.6",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "RETIROS (en caso de que aplique para el laboratorio acondicionador)",

                        Capitulo="17.3",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Está definido en sus procedimientos que la orden de retiro de un producto del mercado es una decisión del mismo laboratorio acondicionador o de la Autoridad Reguladora?",
                        Criterio = "MAYOR",

                        Articulo="17.3.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un responsable de la coordinación del proceso de retiro de un producto del mercado y es totalmente independiente del departamento de ventas?",
                        Criterio = "CRÍTICO",

                        Articulo="17.3.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se indica en el procedimiento escrito quien es el responsable del proceso?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un procedimiento escrito, actualizado para retirar productos del mercado?",
                        Criterio = "MAYOR",

                        Articulo="17.3.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El procedimiento contempla que se debe elaborar un registro y un informe final?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se registran las verificaciones del procedimiento?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los registros de distribución están disponibles y son de fácil acceso en el caso que se tuviera que recuperar un producto del mercado?",
                        Criterio = "MAYOR",

                        Articulo="17.3.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El responsable del proceso tiene acceso a estos registros? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros del retiro y un informe final del retiro de productos del mercado?",
                        Criterio = "MAYOR",

                        Articulo="17.3.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Quién recibe copia del informe final? ",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Los productos retirados se identifican y almacenan independientemente, en un área segura mientras se espera la decisión de su destino final?",
                        Criterio = "MAYOR",

                        Articulo="17.3.6",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                }
            };

        }

        public void Inicializa_AutoInspecAuditCal()
        {
            AutoInspecAuditCal = new AUD_ContenidoGenerico()
            {
                LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas()
                    {
                        Titulo = "AUTOINSPECCIONES",

                        Capitulo="18.1",
                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Realiza el laboratorio acondicionador autoinspecciones y auditorías periódicas?",
                        Criterio = "CRÍTICO",

                        Articulo="18.1.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tiene el laboratorio acondicionador un procedimiento y programa de autoinspecciones que contempla todos los aspectos de las buenas prácticas de manufactura (acondicionamiento)?",
                        Criterio = "CRÍTICO",

                        Articulo="18.1.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El informe de estas autoinspecciones incluye:",
                        Criterio = "MAYOR",

                        IsHeader = true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Las evaluaciones que se realizaron.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Los resultados.",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "c) Conclusiones",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "d) Acciones correctivas y preventivas",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las autoinspecciones se documentan?",
                        Criterio = "MAYOR",

                        Articulo="18.1.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existe un programa de seguimiento a las acciones correctivas y preventivas?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se determina el grado de cumplimiento de las acciones correctivas y preventivas?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "En el procedimiento escrito de autoinspecciones se indica la frecuencia? ",
                        Criterio = "MAYOR",

                        Articulo="18.1.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cada aspecto se inspecciona al menos una vez al año?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "El personal que realiza las autoinspecciones está calificado y capacitado en buenas prácticas de manufactura (acondicionamiento)? ",
                        Criterio = "CRÍTICO",

                        Articulo="18.1.5",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se ha documentado esa capacitación?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se utiliza alguna guía para realizar las autoinspecciones?",
                        Criterio = "INFORMATIVO",

                        Articulo="18.1.6",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Cuál?",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "AUDITORÍAS",

                        Capitulo="18.2",

                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realizan auditorías de calidad internas?",
                        Criterio = "MAYOR",

                        Articulo="18.2.1",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros de las auditorías?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se realizan evaluaciones de calidad a los proveedores y contratistas? ",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Existen registros?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las auditorías de calidad son realizadas por personal de la misma compañía?",
                        Criterio = "INFORMATIVO",

                        Articulo="18.2.2",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Las auditorías de calidad son realizadas por personal externo?",
                        Criterio = "INFORMATIVO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Tiene el laboratorio acondicionador un procedimiento escrito para realizar las auditorías de calidad? ",
                        Criterio = "MAYOR",

                        Articulo="18.2.3",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se genera un informe que incluye:",



                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        IsHeader=true,
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "a) Resultados",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "b) Conclusiones",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se da seguimiento a las acciones correctivas y preventivas de las auditorías de calidad?",
                        Criterio = "MAYOR",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se mantienen registros de las inspecciones efectuadas por parte de la Autoridad Reguladora?",
                        Criterio = "MAYOR",

                        Articulo="18.2.4",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas()
                    {
                        Titulo = "Se da seguimiento a las acciones correctivas y preventivas de las inspecciones de la Autoridad Reguladora?",
                        Criterio = "CRÍTICO",


                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                }
            };

        }


    }
}
