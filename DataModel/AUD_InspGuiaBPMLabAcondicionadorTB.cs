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
        public AUD_InspGuiaBPMLabAcondicionadorTB()
        {
            AuditoriaSanitaria = new AUD_AuditoriaSanitaria();
            RepresentLegal = new DatosPersona();
            RegenteFarmaceutico = new DatosPersona();
            OtrosFuncionarios = new AUD_OtrosFuncionarios();
            GeneralesEmpresa = new AUD_GeneralesEmpresa();
            RespProduccion = new DatosPersona();
            RespControlCalidad = new DatosPersona();
            RequisitosLegales = new AUD_ContenidoTablas();

            DatosConclusiones = new AUD_DatosConclusiones();


            InicializaData();
        }

        private AUD_InspeccionTB inspeccion;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }


        //Autoridad Sanitaria
        private AUD_AuditoriaSanitaria auditoriaSanitaria;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_AuditoriaSanitaria AuditoriaSanitaria { get => auditoriaSanitaria; set => SetProperty(ref auditoriaSanitaria, value); }

        //Datos del Representante Legal
        private DatosPersona representLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona RepresentLegal { get => representLegal; set => SetProperty(ref representLegal, value); }

        //Regente farmacéutico /Director Técnico y número de Registro
        private DatosPersona regenteFarmaceutico;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona RegenteFarmaceutico { get => regenteFarmaceutico; set => SetProperty(ref regenteFarmaceutico, value); }

        //Otros Funcionarios
        private AUD_OtrosFuncionarios otrosFuncionarios;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_OtrosFuncionarios OtrosFuncionarios { get => otrosFuncionarios; set => SetProperty(ref otrosFuncionarios, value); }

        //Generales Empresa
        private AUD_GeneralesEmpresa generalesEmpresa;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_GeneralesEmpresa GeneralesEmpresa { get => generalesEmpresa; set => SetProperty(ref generalesEmpresa, value); }

        //RESPONSABLE DE PRODUCCIÓN
        private DatosPersona respProduccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona RespProduccion { get => respProduccion; set => SetProperty(ref respProduccion, value); }

        //RESPONSABLE DE CONTROL DE CALIDAD:
        private DatosPersona respControlCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public DatosPersona RespControlCalidad { get => respControlCalidad; set => SetProperty(ref respControlCalidad, value); }

        //REQUISITOS LEGALES
        private AUD_ContenidoTablas requisitosLegales;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas RequisitosLegales { get => requisitosLegales; set => SetProperty(ref requisitosLegales, value); }

        // observaciones
        private string observaciones;
        public string Observaciones { get => observaciones; set => SetProperty(ref observaciones, value); }

        // ¿Está el establecimiento sometido a un proceso periódico de vigilancia y control sanitario por la autoridad competente?
        private enumAUD_TipoSeleccion procesoVigilanciaSanit;
        public enumAUD_TipoSeleccion ProcesoVigilanciaSanit { get => procesoVigilanciaSanit; set => SetProperty(ref procesoVigilanciaSanit, value); }

        // Fecha de la última visita
        private DateTime? fechaUltimaVista;
        public DateTime? FechaUltimaVista { get => fechaUltimaVista; set => SetProperty(ref fechaUltimaVista, value); }


        //CLASIFICACION DE ACTIVIDADES
        private AUD_ContenidoTablas clasifActComerciales;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas ClasifActComerciales { get => clasifActComerciales; set => SetProperty(ref clasifActComerciales, value); }

        //CLASIFICACIÓN DEL ESTABLECIMIENTO
        //¿PRODUCEN, ENVASAN, EMPACAN Y ANALIZAN PRODUCTOS A TERCEROS? Informativo
        //¿SE CUENTA CON CONTRATOS PARA LA PRODUCCIÓN, ENVASE, EMPAQUE Y CONTROL ANALÍTICO DE SUS PRODUCTOS CON TERCEROS? (CRITICO)
        //TIENEN APROBADAS POR PARTE DE LA AUTORIDAD REGULADORA LAS CONDICIONES PARA LAS SIGUIENTES ÁREAS DE PRODUCCIÓN: (Informativo )
        private AUD_ContenidoTablas clasifEstablecimiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas ClasifEstablecimiento { get => clasifEstablecimiento; set => SetProperty(ref clasifEstablecimiento, value); }

        //ORGANIZACIÓN Y PERSONAL -> ORGANIZACIÓN - PERSONAL - RESPONSABILIDADES DEL PERSONAL - CAPACITACIÓN - SALUD E HIGIENE DEL PERSONAL
        private AUD_ContenidoTablas organizacionPersonal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas OrganizacionPersonal { get => organizacionPersonal; set => SetProperty(ref organizacionPersonal, value); }

        //8. EDIFICIOS E INSTALACIONES -> GENERALIDADES - 
        private AUD_ContenidoTablas edifInstalaciones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas EdifInstalaciones { get => edifInstalaciones; set => SetProperty(ref edifInstalaciones, value); }

        //8. EDIFICIOS E INSTALACIONES -> Almacenes
        private AUD_ContenidoTablas almacenes;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas Almacenes { get => almacenes; set => SetProperty(ref almacenes, value); }

        ////8. EDIFICIOS E INSTALACIONES -> ÁREA DE ACONDICIONAMIENTO
        //private AUD_ContenidoTablas areaDispMatPrima;
        //[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        //public AUD_ContenidoTablas AreaDispMatPrima { get => areaDispMatPrima; set => SetProperty(ref areaDispMatPrima, value); }

        ////8. EDIFICIOS E INSTALACIONES -> ÁREA DE PRODUCCIÓN
        //private AUD_ContenidoTablas areaProduccion;
        //[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        //public AUD_ContenidoTablas AreaProduccion { get => areaProduccion; set => SetProperty(ref areaProduccion, value); }

        //8. EDIFICIOS E INSTALACIONES -> ÁREAS DE ACONDICIONAMIENTO PARA EMPAQUE SECUNDARIO - ÁREA DE CONTROL DE CALIDAD - ÁREAS AUXILIARES
        private AUD_ContenidoTablas areaAcondicionamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas AreaAcondicionamiento { get => areaAcondicionamiento; set => SetProperty(ref areaAcondicionamiento, value); }

        //9. EQUIPO - GENERALIDADES
        private AUD_ContenidoTablas equiposGeneralidades;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas EquiposGeneralidades { get => equiposGeneralidades; set => SetProperty(ref equiposGeneralidades, value); }

        ////9. EQUIPO - siguientes - CALIBRACIÓN - SISTEMA DE AIRE - 
        //private AUD_ContenidoTablas equipos;
        //[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        //public AUD_ContenidoTablas Equipos { get => equipos; set => SetProperty(ref equipos, value); }

        //10. MATERIALES Y PRODUCTOS - GENERALIDADES - MATERIAS PRIMAS - MATERIALES DE ACONDICIONAMIENTO - PRODUCTOS INTERMEDIOS Y A GRANEL - PRODUCTOS TERMINADOS - MATERIALES Y PRODUCTOS RECHAZADOS - PRODUCTOS DEVUELTOS -  
        private AUD_ContenidoTablas matProducts;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas MatProducts { get => matProducts; set => SetProperty(ref matProducts, value); }

        //11. DOCUMENTACIÓN - GENERALIDADES - DOCUMENTOS EXIGIDOS - PROCEDIMIENTOS Y REGISTROS - 
        private AUD_ContenidoTablas documentacion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas Documentacion { get => documentacion; set => SetProperty(ref documentacion, value); }

        //12. ACONDICIONAMIENTO
        private AUD_ContenidoTablas acondicionamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas Acondicionamiento { get => acondicionamiento; set => SetProperty(ref acondicionamiento, value); }

        //13. GARANTÍA DE CALIDAD - GENERALIDADES
        private AUD_ContenidoTablas garantiaCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas GarantiaCalidad { get => garantiaCalidad; set => SetProperty(ref garantiaCalidad, value); }

        // 14. CONTROL DE CALIDAD - GENERALIDADES - DOCUMENTACIÓN - MUESTREO - METODOLOGÍA ANALÍTICA - ESTABILIDAD - 
        private AUD_ContenidoTablas controlCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas ControlCalidad { get => controlCalidad; set => SetProperty(ref controlCalidad, value); }

        //15. PRODUCCIÓN Y ANÁLISIS POR CONTRATO - GENERALIDADES - DEL CONTRATANTE - DEL CONTRATISTA - 
        private AUD_ContenidoTablas prodAnalisisContrato;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas ProdAnalisisContrato { get => prodAnalisisContrato; set => SetProperty(ref prodAnalisisContrato, value); }

        //16. VALIDACIÓN - GENERALIDADES - CONFORMACIÓN DE EQUIPOS - PROTOCOLOS E INFORMES - CALIFICACIÓN Y VALIDACIÓN - DE NUEVA FÓRMULA - DE LA VALIDACIÓN DE MODIFICACIONES - REVALIDACIÓN - 
        private AUD_ContenidoTablas valGenerales;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas ValGenerales { get => valGenerales; set => SetProperty(ref valGenerales, value); }

        //17. QUEJAS, RECLAMOS Y RETIRO DE PRODUCTOS - GENERALIDADES - QUEJAS O RECLAMOS - RETIROS - 
        private AUD_ContenidoTablas quejasReclamos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas QuejasReclamos { get => quejasReclamos; set => SetProperty(ref quejasReclamos, value); }

        //18. AUTOINSPECCIÓN Y auditorías DE CALIDAD - AUTOINSPECCIONES - AUDITORÍAS - 
        private AUD_ContenidoTablas autoInspecAuditCal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas AutoInspecAuditCal { get => autoInspecAuditCal; set => SetProperty(ref autoInspecAuditCal, value); }

        //Datos Conclusión de Inspección
        private AUD_DatosConclusiones datosConclusiones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosConclusiones DatosConclusiones { get => datosConclusiones; set => SetProperty(ref datosConclusiones, value); }


        private void InicializaData()
        {
            RequisitosLegales = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                        {
                            Titulo = "El laboratorio fabricante posee permiso sanitario de funcionamiento o licencia sanitaria, autorizada por la autoridad reguladora del país.",
                            Criterio = "CRÍTICO",
                            Capitulo="6.1",
                            Articulo="6.1.1",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "El permiso sanitario de funcionamiento o licencia de operación se encuentra vigente",
                            Criterio = "CRÍTICO",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "El permiso sanitario de funcionamiento o licencia de operación se encuentra colocado en un lugar visible al público",
                            Criterio = "MENOR",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        }
                }
            };
            //////////////////////
            ///
            ClasifActComerciales = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Compra local?",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es importador?",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Exigen certificado de análisis de del fabricante?",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentran disponibles los certificados de análisis?",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Es importador de:",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                        {
                            Titulo = "¿Producto terminado?",
                            Criterio = "Informativo",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "¿Producto semielaborado?",
                            Criterio = "Informativo",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "¿Producto a granel?",
                            Criterio = "Informativo",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "¿Exigen certificado de análisis del fabricante?",
                            Criterio = "Informativo",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "¿Se encuentran disponibles los certificados de análisis?",
                            Criterio = "Informativo",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        }
                }
            };
            //////////////////////
            ///
            ClasifEstablecimiento = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                    {
                        Titulo = "Medicamentos Humanos?",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Medicamentos Veterinarios?",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Medicamentos Cosméticos?",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Productos Naturales?",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Productos Homeopáticos?",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Otros indiquen",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Acondicionan y analizan productos a terceros?",
                        Criterio = "CRÍTICO",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuáles y de qué empresa(s)?. Anexar Listado ",
                        Criterio = "CRÍTICO",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Que tipo de acondicionamiento realizan?",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con contratos para el acondicionamiento y análisis de productos a terceros?",
                        Criterio = "Crítico",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            ////////
            OrganizacionPersonal = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "ORGANIZACIÓN",
                        Criterio = "",
                        Capitulo="7.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene el laboratorio fabricante organigramas generales y específicos de cada uno de los departamentos, se encuentran actualizados y aprobados? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe independencia de responsabilidades entre producción y control de la calidad?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta con descripciones escritas de las funciones y responsabilidades de cada puesto incluido en el organigrama?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de un Director técnico / Regente Farmacéutico? ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="7.1.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El director técnico del establecimiento cumple con el horario de funcionamiento del laboratorio fabricante?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de jornadas continuas o extraordinarias el Director técnico / Regente garantiza los mecanismos de supervisión de acuerdo a la Legislación de cada Estado Parte?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Participa en las inspecciones realizadas?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PERSONAL",
                        Criterio = "",
                        Capitulo="7.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone el laboratorio fabricante de personal con la calificación y experiencia práctica según el puesto asignado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.2.1, 7.2.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las funciones asignadas a cada persona deben ser congruentes con el nivel de responsabilidad que asuma y que no constituyan un riesgo a la calidad del producto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las unidades de producción, control de calidad, garantía de calidad e investigación y desarrollo, están a cargo de profesionales farmacéuticos o profesionales calificados?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="7.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "RESPONSABILIDADES DEL PERSONAL",
                        Criterio = "",
                        Capitulo="7.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cumple el responsable de la Dirección de Producción (Acondicionamiento) con las siguientes responsabilidades:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="7.3.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Asegura que los productos se elaboren y almacenen en concordancia con la documentación aprobada",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Aprueba los documentos maestros relacionados con las operaciones de producción incluyendo los controles durante el proceso y asegurar su estricto cumplimiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Garantiza que la orden de producción esté completa y firmada por las personas designadas antes de que se pongan a disposición del Depto. de Control de Calidad",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Vigila el mantenimiento del departamento en general, instalaciones y equipo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Asegura que se lleve a cabo los procesos de producción de acuerdo a los parámetros establecidos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Autoriza los procedimientos del Departamento de producción, y verifica que se cumplan dejando constancia escrita",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Asegura que se lleve a cabo la capacitación inicial y continua del personal de producción y que dicha capacitación se adapte a las necesidades del departamento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cumple el responsable de la Dirección de Control de Calidad con las siguientes responsabilidades:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="7.3.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Aprueba o rechaza, según proceda las materias primas, productos intermedios, a granel, terminado y material de acondicionamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Verifica que toda la documentación de un lote de producto terminado esté completa",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Aprueba las especificaciones, instrucciones de muestreo, métodos de análisis y otros procedimientos de control de calidad",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Aprueba los análisis llevados a cabo por contrato a terceros.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Lleva registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Vigila el mantenimiento del departamento, las instalaciones y equipo;",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Verifica que se efectúen las validaciones correspondientes a los procedimientos analíticos y de los equipos de control.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Asegura que se lleve a cabo la capacitación inicial y continua del personal de control de calidad y que dicha capacitación se adapte a las necesidades.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cumplen los responsables de producción (Acondicionamiento) y control de calidad con las responsabilidades compartidas, las cuales son las siguientes:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="7.3.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Autorizan los procedimientos escritos y otros documentos, incluyendo sus modificaciones.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Vigilan y controlanlas áreas de producción.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Vigilan la higiene de las instalaciones de las áreas productivas.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Validan los procesos, califican y calibran los equipos e instrumentos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Aseguran la capacitación del personal.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Participan en la selección, evaluación (aprobación) y control de los proveedores de materiales, de equipo y otros involucrados en el proceso de producción",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Aprueban y controlan la fabricación por terceros. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Establecen y controlan las condiciones de almacenamiento de materiales y productos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Conservan la documentación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Vigilan el cumplimiento de las Buenas Prácticas de Manufactura",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Inspeccionan, investigan y muestrean con el fin de controlar los factores que puedan afectar a la calidad",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CAPACITACIÓN",
                        Criterio = "",
                        Capitulo="7.4",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con un procedimiento escrito de inducción general de buenas prácticas de manufactura para el personal de nuevo ingreso y es específica de acuerdo a sus funciones y atribuciones asignadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.4.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen los registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa escrito de capacitación continua en buenas prácticas de manufactura, para todo el personal operativo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.4.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está la capacitación acorde a las funciones propias de cada puesto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las capacitaciones se efectúan como mínimo dos veces al año?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.4.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza evaluación del programa de capacitación tomando en cuenta su ejecución y los resultados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.4.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para el ingreso de personas ajenas a las áreas de producción y control de calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.4.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SALUD E HIGIENE DEL PERSONAL",
                        Criterio = "",
                        Capitulo="7.5",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todo el personal previo a ser contratado se somete a examen médico?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.5.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El Laboratorio Fabricante garantiza que el personal presente anualmente la certificación médica o su equivalente de acuerdo a la legislación del país?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿De acuerdo a las áreas de desempeño, el personal es sometido a exámenes médicos, al menos una vez al año?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito en donde el personal enfermo comunique de inmediato a su superior, cualquier estado de salud que influya negativamente en la producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.5.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos relacionados con la higiene del personal incluyendo el uso de ropas protectoras, que incluyan a todas las personas que ingresan a las áreas de producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.5.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se garantiza que al ingresar a las áreas de producción, los empleados permanentes, temporales o visitantes, utilizan vestimenta/uniforme acorde a las tareas que se realizan, los cuales están limpios y en buenas condiciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Utiliza diariamente el personal dedicado a la producción (Acondicionamiento), que este en contacto directo con el producto terminado, uniforme completo:",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="7.5.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Gorro que cubra la totalidad del cabello",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Mascarilla",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Guantes desechables",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Zapatos de superficie lisa, cerrados y suela antideslizante",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El personal utiliza el uniforme de acuerdo al área de trabajo? ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En las áreas de producción, almacenamiento y control de calidad existe la prohibición de:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="7.5.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Comer, beber, fumar, masticar, así como guardar comida, bebida, cigarrillos, medicamentos personales",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Utilizar maquillaje, joyas, relojes, teléfonos celulares, radio localizadores, u otro elemento ajeno al área",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Llevar barba o bigote al descubierto durante la jornada de trabajo en los procesos de dispensado, producción y subdivisión",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Salir fuera del áreade producción con el uniforme de trabajo",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen rótulos que indiquen tales prohibiciones?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento que instruya al personal a lavarse las manos antes de ingresar a las áreas de producción? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.5.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen carteles, rótulos alusivos que indiquen al personal la obligación de lavarse las manos después de utilizar los servicios sanitarios y después de comer? ",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el laboratorio con botiquín y área destinada a primeros auxilios?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="7.5.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    }
                },
            };
            ////////
            EdifInstalaciones = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "",
                        Capitulo="8.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está diseñado el edificio de tal manera que facilite la limpieza, mantenimiento y ejecución apropiada de las operaciones?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="8.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los espacios libres (exteriores) y no productivos pertenecientes a la empresa ¿se encuentran en condiciones de orden y limpieza?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las vías de acceso interno a las instalaciones ¿están pavimentadas o construidas de manera tal que el polvo no sea fuente de contaminación en el interior de la planta? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentran actualizados los planos y diagramas de las instalaciones y edificio?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="8.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen fuentes de contaminación ambiental en el área circundante al edificio? En caso afirmativo, ¿se adoptan medidas de resguardo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.1.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos, programa y registros del mantenimiento realizado a las instalaciones y edificios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está diseñado y equipado el edificio de tal forma que ofrezca la máxima protección contra el ingreso de insectos y animales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.1.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está diseñado el edificio, de tal manera que permita el flujo de materiales, procesos y personal evitando la confusión, contaminación y errores?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="8.1.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se supervisa el ingreso de personas ajenas a estas áreas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están las áreas de acceso restringido debidamente delimitadas e identificadas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas de producción (Acondicionamiento) y almacenamiento no se utilizan como áreas de paso?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="8.1.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los pasillos de circulación se encuentran libres de materiales, productos y equipo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las condiciones de iluminación, temperatura, humedad y ventilación, para la producción y almacenamiento, están acordes con los requerimientos del producto?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="8.1.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los equipos y materiales están ubicados de forma que eviten el riesgo de confusión, contaminación cruzada y omisión entre los distintos productos y sus componentes en cualquiera de las operaciones de producción, control y almacenamiento?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="8.1.10",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son las áreas de almacenamiento y producción (Acondicionamiento)\r\nexclusivas para el uso previsto y se mantienen libres de objetos y materiales \r\nextraños al proceso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.1.11",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las tuberías, artefactos lumínicos, puntos de ventilación y otros servicios, están diseñados y ubicados, de tal forma que faciliten la limpieza? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.1.12",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone el edificio de extintores adecuados a las áreas y se encuentran estos ubicados en lugares estratégicos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.1.13",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                }
            };
            ////////
            Almacenes = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "ALMACENES",
                        Criterio = "",
                        Capitulo="8.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen las áreas de almacenamiento suficiente capacidad para permitir el almacenamiento ordenado de las diferentes categorías de materiales y productos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.2.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están debidamente identificados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los pisos, paredes, techos de los almacenes están construidos de tal forma que no afectan la calidad de los materiales y productos que se almacenan y permite la fácil limpieza? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las instalaciones eléctricas están diseñadas y ubicadas de tal forma que facilitan la limpieza?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.1.12",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los desagües y tuberías están en buen estado de conservación e higiene?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.1.14",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas de almacenamiento se mantienen limpias y ordenadas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.2.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay instrumentos para medir la temperatura y humedad y estas mediciones están dentro de los parámetros establecidos para los materiales y productos almacenados?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los productos que requieren condiciones especiales de enfriamiento, se encuentran en cámara fría?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un sistema de alerta que indique los desvíos de la temperatura programada en la cámara fría?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales y productos están protegidos de las condiciones ambientales en los lugares de recepción y despacho?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.2.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El área de recepción está diseñada de tal manera que los contenedores de materiales puedan limpiarse antes de su almacenamiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área de despacho de producto terminado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas donde se almacenan materiales y productos sometidos a cuarentena están claramente definidas y marcadas, el acceso a las mismas está limitado sólo al personal autorizado?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="8.2.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Si se cuenta con un sistema informático este debe ofrecer la misma seguridad que la identificación manual del producto",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe documentación que lo demuestre?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "El área de muestreo cumple con las \r\nsiguientes características:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "a) Las paredes, pisos y techos son lisos y con \r\ncurvas sanitarias\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                      new ContenidoTablas()
                    {
                        Titulo = "b) Existen controles de limpieza, \r\ntemperatura y humedad dentro del área de \r\nmuestreo.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                       new ContenidoTablas()
                    {
                        Titulo = "c) La iluminación es suficiente para el \r\ndesempeño del proceso.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                         new ContenidoTablas()
                    {
                        Titulo = "d) El sistema de aire es independiente.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el laboratorio con áreas de almacenamiento separadas para productos rechazados, retirados y devueltos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.2.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen estas áreas acceso restringido y bajo llave?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos que permitan identificar, separar, retirar y destruir los productos rechazados, retirados, vencidos y devueltos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la ejecución de estos procedimientos?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se almacenan los materiales de manera que faciliten la rotación de los mismos, siguiendo el sistema PEPS?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.2.8",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se almacenan los productos de manera que faciliten la rotación de los mismos, siguiendo el sistema PVPS?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los materiales y productos identificados y colocados sobre tarimas o estanterías separadas de paredes de manera que permitan la limpieza e inspección? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.2.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los contenedores o envases de materiales y productos están bien cerrados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los movimientos y operaciones, se realizan de forma tal que no contaminen el ambiente ni los materiales allí almacenados? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen áreas separadas, bajo llave, de acceso restringido e identificadas para almacenar materias primas y productos psicotrópicos y estupefacientes?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="8.2.10",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área separada y de acceso restringido para almacenar material impreso (etiquetas, estuches, insertos y envases impresos)?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="8.2.12, 10.3.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está identificada?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            /////////////
            AreaAcondicionamiento = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio cuenta con áreas de tamaño, diseño y servicios \r\n(aire comprimido, agua, luz, ventilación, etc.) para efectuar los \r\nprocesos de acondicionamiento que corresponden?",
                        Criterio = "INFORMATIVO",
                        Capitulo="8.4",
                        Articulo="8.4.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las áreas de acondicionamiento (elaboración):",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="8.4.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Están identificadas las áreas de acondicionamiento?\r\n",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen paredes, pisos y techos lisos con curvas sanitarias de tal \r\nforma que permitan la fácil limpieza y sanitización?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Las tuberías y puntos de ventilación son de material que \r\npermitan su fácil limpieza y están correctamente ubicados?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Las ventanas y las lámparas con difusores lisos están \r\nempotrados?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Disponen de sistemas de inyección y extracción de aire?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿No son utilizadas como áreas de paso?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿Están libres de materiales y equipo que no estén involucrados \r\nen el proceso?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) ¿Cuentan con equipo de control de aire?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) ¿Cuentan con registros de temperatura y humedad, cuando se \r\nrequiera?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) ¿Las condiciones de temperatura y humedad relativa se ajustan \r\na los requerimientos de los productos que en ella se realizan?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) ¿Se toman las precauciones necesarias cuando se trabaja con \r\nmaterias primas fotosensibles?\r\n",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) ¿Tienen drenajes que no permiten la contracorriente y tienen \r\ntapa sanitaria? Si aplica",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las áreas de Empaque Primario:",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="8.4.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Están identificadas y separadas para el empaque primario de \r\nsólidos, líquidos y semisólidos?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen paredes, pisos y techos lisos con curvas sanitarias de tal \r\nforma que permitan la fácil limpieza y sanitización?\r\n",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Las tuberías y puntos de ventilación son de material que \r\npermitan su fácil limpieza y están correctamente ubicados?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Las ventanas y las lámparas con difusores lisos están \r\nempotrados?\r\n",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Disponen de sistemas de inyección y extracción de aire?\r\n",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿No son utilizadas como áreas de paso?\r\n",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿Están libres de materiales y equipo que no estén involucrados \r\nen el proceso?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) ¿Cuentan con equipo de control de aire?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) ¿Cuentan con registros de temperatura y humedad, cuando se \r\nrequiera?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) ¿Tienen drenajes que no permiten la contracorriente y tienen tapa \r\nsanitaria? si aplica",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) ¿Se toman las precauciones necesarias cuando se trabaja con \r\nproductos fotosensibles?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área exclusiva para el lavado de equipos móviles, \r\nrecipientes y utensilios? Si aplica:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.4.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las instalaciones tienen curvas sanitarias y servicios para el \r\ntrabajo que allí se ejecuta?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentra en buenas condiciones de orden y limpieza?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El piso de esta área cuenta con desnivel hacia el desagüe, para \r\nevitar que se acumule el agua? Si aplica",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área separada, identificada, limpia y ordenada para \r\ncolocar equipo limpio que no se esté utilizando?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.4.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Tienen paredes, pisos y techos lisos que permitan la fácil \r\nlimpieza y sanitización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿No son utilizadas como áreas de paso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ÁREAS DE ACONDICIONAMIENTO PARA EMPAQUE SECUNDARIO",
                        Criterio = "",
                        Capitulo="8.5",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está el área de empaque secundario separada e identificada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.5.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El área tiene el tamaño de acuerdo a su capacidad y línea de producción, con el fin de evitar confusiones? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El área se encuentra ordenada y limpia?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ÁREAS DE EMPAQUE",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.5.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Tienen paredes, pisos y techos lisos de tal forma que permitan la fácil limpieza y sanitización?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Están las tomas de gases y fluidos identificados?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Las ventanas y las lámparas con difusores lisos están empotrados?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Tiene ventilación e iluminación que asegure condiciones confortables al personal y no afecten negativamente la calidad del producto?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿No son utilizadas como áreas de paso, ni cuarentena?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Están libres de materiales y equipo que no estén involucrados en el proceso?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿No se utiliza madera en esta área?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ÁREA DE CONTROL DE CALIDAD",
                        Criterio = "",
                        Capitulo="8.6",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader= true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área destinada para el laboratorio de control de calidad que se encuentra identificada y separada del área de producción?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="8.6.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El laboratorio de control de calidad tiene las siguientes condiciones:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="8.6.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está diseñado de acuerdo a las operaciones que se realizan?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene paredes lisas que faciliten su limpieza?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene suficiente iluminación y ventilación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de suficiente espacio para evitar confusiones y contaminación cruzada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ÁREAS AUXILIARES",
                        Criterio = "",
                        Capitulo="8.7",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los servicios sanitarios accesibles a las áreas de trabajo y no se comunican directamente con las áreas de producción?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="8.7.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los vestidores están comunicados directamente con las áreas de producción? ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los vestidores y servicios sanitarios tienen las siguientes condiciones:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Identificados correctamente.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La cantidad de servicios sanitarios para hombres y mujeres está de acuerdo al número de trabajadores.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se mantienen limpios y ordenados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos para la limpieza y sanitización",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros sanitización",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuentan con lavamanos y duchas provistas de agua.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Dispone de espejos, toallas de papel o secador eléctrico de manos, jaboneras con jabón líquido desinfectante y papel higiénico.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Están separados los vestidores de los servicios sanitarios, manteniendo un flujo adecuado.",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Casilleros, zapateras y las bancas necesarias (no de madera)",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Rótulos o letreros que enfaticen la higiene personal (lavarse las manos antes de salir de este lugar).",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se prohíbe mantener, guardar, preparar y consumir alimentos en esta área, manteniendo rótulos que indiquen esta disposición",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se prohíbe fumar en estas áreas (rótulo). ",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con un comedor separado de las demás áreas productivas e identificada, en buenas condiciones de orden y limpieza? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.7.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con un área de lavandería separada y exclusiva para el lavado y secado de los uniformes utilizados por el personal?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="8.7.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Poseen procedimientos escritos para realizar el lavado y secado por separado de uniformes por tipo de área no estéril, estériles y mantenimiento?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área separada a las áreas de producción destinada al mantenimiento de equipos y al almacenamiento de herramientas y repuestos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.7.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de un área destinada al almacenamiento del equipo obsoleto o en mal estado que no interviene en los procesos de producción?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            /////////////
            EquiposGeneralidades = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "",
                        Capitulo="9.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está el equipo utilizado en la producción diseñado y construido de acuerdo a la operación que en él se realice?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="9.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La ubicación del equipo facilita su limpieza así como la del área en la que se encuentra?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el equipo con un código de identificación único?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todo equipo empleado en la producción, control de calidad, empaque y almacenaje, cuenta con un procedimiento en el cual se especifiquen en forma clara las instrucciones y precauciones para su operación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="9.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registros del uso de los equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todos los instrumentos de medición son utilizados de acuerdo a su rango y capacidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son las piezas o partes de los equipos almacenadas en un lugar seguro y se mantienen en buen estado de conservación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La reparación y mantenimiento de los equipos se efectúa de tal forma que no presente ningún riesgo para la calidad de los productos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="9.1.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de mantenimiento preventivo de los equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="9.1.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los equipos en reparación se identifican como tales? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros del mantenimiento preventivo y correctivo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los equipos declarados fuera de servicio son identificados como tales y retirados de las áreas productivas, según procedimiento escrito? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de mantenimiento de equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="9.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos de la limpieza del equipo incluyendo utensilios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se establece un período de vigencia de la limpieza de los equipos y \r\nutensilios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si el equipo es muy pesado, está diseñado para que se pueda ejecutar su \r\nlimpieza y/o sanitización en el área de acondicionamiento? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="9.1.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se identifican todos los equipos limpios con una etiqueta que indique la \r\nsiguiente información:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="9.1.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "-Nombre del equipo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "-Fecha cuando fue realizada la limpieza. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "-Nombre y número de lote del último producto acondicionado. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "-Nombre y número de lote del producto a fabricar, cuando aplique.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las superficies de trabajo, que tienen contacto con productos en proceso \r\n(acondicionamiento), son de acero inoxidable u otro material no reactivo?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="9.1.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los filtros empleados en los equipos son descartables? En caso de \r\nacondicionamiento primario?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="9.1.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si los filtros no son descartables, se les da el debido mantenimiento?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran los cambios de los filtros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los soportes de los equipos que lo requieran son de acero inoxidable u \r\notro material que no contamine?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="9.1.8",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CALIBRACIÓN",
                        Criterio = "",
                        Capitulo="9.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza calibración de los instrumentos de medición y dispositivos de \r\nregistro o cualquier otro que lo requiera?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="9.2.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen registros escritos de las inspecciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen registros escritos de las verificaciones? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen registros escritos de las calibraciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los instrumentos están correctamente rotulados indicando la fecha de \r\ncalibración?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza la calibración de cada equipo y dispositivos usando patrones de \r\nreferencia certificados?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="9.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            /////////////
            MatProducts = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "",
                        Capitulo="10.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se documenta y registra el ingreso y egreso de los materiales, según procedimiento?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="10.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El material que se recibe es debidamente etiquetado?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos escritos que describan las operaciones de:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Recepción e identificación de materiales y productos. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Almacenamiento de materiales y productos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Manejo de materiales y productos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Muestreo, análisis y aprobación o rechazo de materiales y productos conforme a las especificaciones de cada uno de ellos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales y productos se manejan y almacenan de tal manera que se evite cualquier contaminación o situación que pongan en riesgo su calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los recipientes o contenedores de materiales se encuentran cerrados e identificados? ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="10.1.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales están ubicados en tarimas o estantes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe espacio suficiente para realizar la limpieza e inspección y se encuentran las tarimas o estantes separados de las paredes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están identificados los materiales con su correspondiente número de control de acuerdo a la codificación establecida?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Proceden los materiales solamente de proveedores aprobados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.1.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales son suministrados según especificaciones proporcionadas por control de calidad, producción e investigación y desarrollo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica en cada entrega la integridad y cierres de los recipientes? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.0.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se comprueba la correspondencia entre la nota de entrega y la etiqueta colocada en el recipiente de materiales que entrega el proveedor?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Permanece cada lote de materiales en cuarentena mientras no sea muestreado, examinado y analizado por control de calidad?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="10.0.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de calidad emite la aprobación o rechazo de los materiales y productos? ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan muestreos estadísticamente representativos en cada ingreso de materiales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.1.8",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La etiqueta de identificación de materiales contiene la siguiente información? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.1.10",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre y código del material.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Número de ingreso.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Situación del material.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Nombre del proveedor.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "MATERIALES DE ACONDICIONAMIENTO",
                        Criterio = "",
                        Capitulo="10.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los envases y cierres son hechos de material que no sea reactivo, aditivo y adsorbente al producto? En caso de acondicionamiento primario",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="10.3.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los requerimientos de los envases y cierres están sustentados en los estudios de formulación y pruebas de estabilidad? En caso de acondicionamiento primario",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los envases y cierres son adquiridos de proveedores aprobados? En caso de acondicionamiento primario",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se manipulan y limpian los envases, cierres y medidas dosificadoras según procedimiento escrito, cuando aplique? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.3.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registro de su ejecución?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son todos los materiales de acondicionamiento examinados respecto a su cantidad, identidad y conformidad con las respectivas instrucciones de la orden de envasado, antes de ser enviados al área?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.3.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todos los materiales impresos se manipulan por personal autorizado de forma tal que se evite cualquier confusión? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.3.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCTOS INTERMEDIOS Y A GRANEL",
                        Criterio = "",
                        Capitulo="10.4",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCTOS TERMINADOS",
                        Criterio = "",
                        Capitulo="10.5",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los productos terminados se encuentran en cuarentena hasta su aprobación final?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="10.5.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los productos terminados se mantienen almacenados en las condiciones requeridas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.2.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los productos terminados son comercializados solamente después de su aprobación?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="10.5.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la distribución de productos terminados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para el manejo de materiales, productos intermedios, a granel y productos terminados que han sido rechazados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.6.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "MATERIALES Y PRODUCTOS RECHAZADOS",
                        Criterio = "",
                        Capitulo="10.6",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son identificados mediante el uso de una etiqueta roja justificando la causa del rechazo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son devueltos o destruidos los materiales rechazados de acuerdo a procedimiento establecido cumpliendo con la normativa ambiental existente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.6.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de su ejecución? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El material obsoleto o desactualizado está identificado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.6.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es manejado y destruido según procedimiento escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCTOS DEVUELTOS",
                        Criterio = "",
                        Capitulo="10.7",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para la devolución de producto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.7.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Define este procedimiento las personas responsables y los criterios de tratamiento de los productos devueltos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son almacenados los productos devueltos en un área separada y con acceso restringido? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.7.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentran identificados como tales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Quiénes son los responsables de decidir el tratamiento de las devoluciones?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="10.7.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Actúan conjuntamente con garantía de calidad o control de calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son destruidos los productos farmacéuticos devueltos que hayan sido sometidos a condiciones extremas de manejo o almacenamiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.7.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento escrito para la destrucción de estos productos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Todas las acciones efectuadas y las decisiones tomadas son registradas, detallando:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.7.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del producto",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Forma farmacéutica.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Número de lote.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Motivo de la devolución",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Cantidad devuelta.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Fecha de la devolución.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investiga la causa de la devolución y se determina si afecta cualquier otro lote?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.7.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de las acciones correctivas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            /////////////
            Documentacion = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "",
                        Capitulo="11.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están las especificaciones, fórmulas, métodos e instrucciones de fabricación y procedimientos en forma impresa, debidamente revisadas y aprobadas?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="11.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los documentos diseñados, revisados y distribuidos de acuerdo a un procedimiento escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los documentos aprobados, firmados y fechados por las personas autorizadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.1.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las modificaciones están autorizadas?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tienen los documentos las siguientes características:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="11.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Están redactados en forma clara, ordenada y libre de expresiones ambiguas, permitiendo su fácil comprensión?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Son fácilmente verificables?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Se revisan periódicamente y se mantienen actualizados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Son reproducidos en forma clara e indeleble?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La introducción de datos se realiza con letra clara legible y con tinta indeleble?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.1.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay en los documentos que lo requieran, espacio para permitir la realización del registro de datos? ",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los documentos y datos registrados se encuentran en medio electrónicos?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="11.1.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen controles especiales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Sólo las personas autorizadas acceden o modifican los datos en la computadora? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de los cambios y las eliminaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está el acceso restringido por contraseñas u otros medios? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cualquier corrección realizada en un documento de un dato escrito está firmada y fechada? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.1.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La corrección no impide la lectura del dato inicial?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Indica la causa de la corrección, cuando sea necesario?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de todas las acciones efectuadas o completadas de tal forma que haya trazabilidad de todas las operaciones de los procesos de fabricación de los productos farmacéuticos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.1.8",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen todos los registros incluyendo lo referente a los procedimientos de operación, un año después de la fecha de expiración del producto terminado? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un listado maestro de documentos disponible?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="11.1.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se identifica el estado de los mismos?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los documentos actualizados en los sitios relacionados a las operaciones esenciales para cada proceso? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.1.10",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son retirados los documentos invalidados u obsoletos de todos los puntos de uso? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.1.11",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un archivo histórico identificado para almacenar los originales de los documentos obsoletos?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "DOCUMENTOS EXIGIDOS",
                        Criterio = "",
                        Capitulo="11.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen especificaciones autorizadas y fechadas por control de calidad para:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="11.2.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Materia prima.",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Material de acondicionamiento.",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Productos intermedios o granel.",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Producto terminado",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Incluyen las especificaciones de la materia prima, material de acondicionamiento, productos intermedios o granel y producto terminado lo siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del material (denominación común internacional, cuando corresponda).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Código de referencia interna.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Referencia, si la hubiere de los libros oficiales.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Formula química (cuando aplique).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Requisitos cuali y cuantitativos con límites de aceptación (cuando aplique).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Las técnicas analíticas o procedimiento.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Procedimiento de muestreo.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Muestra del material impreso (cuando aplique).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Cantidad requerida para la muestra de retención.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Condiciones de almacenamiento y precauciones.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Proveedores aprobados y marcas comerciales (cuando aplique).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Descripción de la forma farmacéutica y detalle del empaque (cuando aplique).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "m) Vida en anaquel (cuando aplique).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Realizan revisión periódica de las especificaciones analíticas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.2.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están de acuerdo a los libros oficiales? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Disponen de una fórmula maestra para cada producto?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="11.2.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está la fórmula maestra actualizada y autorizada?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Quién la actualiza y autoriza?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Contiene la fórmula maestra los datos siguientes:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.2.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre y código del producto correspondiente a su especificación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Descripción de la forma farmacéutica, potencia o concentración del principio activo y tamaño de lote.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Fórmula cuali-cuantitativa expresada en el sistema métrico decimal, de las materias primas a emplearse, haciendo mención de cualquier sustancia que pueda desaparecer durante el proceso, usando el nombre y código que es exclusivo para cada material.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Lista de material de empaque primario y secundario a emplearse, indicando la cantidad de cada uno y el código que es exclusivo para cada material.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Indicación del rendimiento teórico con los límites de aceptabilidad.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Indicación de las áreas en las que deben ser realizadas cada una de las etapas del proceso y de los principales equipos a ser empleados.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Instrucciones detalladas de los pasos a seguir en el proceso de producción, mencionando los distintos procedimientos relacionados con las etapas de producción y operación de equipos",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Instrucciones referentes a los controles a realizar durante el proceso de producción, indicando especificaciones del producto.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Indicaciones para el almacenamiento de los productos(semielaborados o graneles y terminado), incluyendo el contenedor, el etiquetado y cualquier otra condición de almacenamiento cuando las características del producto lo requieran. ",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) ¿Precauciones especiales que deben tomarse en cuenta en las distintas etapas del proceso? ",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Nombres y firmas de las personas responsables en la emisión, revisión y aprobación de la fórmula maestra y fecha de la aprobación.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Exceso de principios activos (si procede)",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Coinciden las fórmulas maestras de todos los productos fabricados con las presentadas en la documentación para obtención del registro sanitario?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="11.2.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si se hace cambio de la fórmula cuali-cuantitativa, estos cambios son comunicados y aprobados por la Autoridad Reguladora competente?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La orden de producción correspondiente a un lote, ¿es emitida por el departamento asignado para este fin? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.2.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Quién la emite?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es una reproducción del registro de la fórmula maestra, que al asignarle un número de lote se convierte en orden de producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La orden de producción está autorizada por las personas asignadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tiene la orden de producción además de lo indicado en la fórmula maestra la información siguiente: ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.2.8",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Código o número de lote.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Fecha de inicio y finalización de la producción.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Fecha de expiración del producto",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Firma de las personas que autorizan la orden de producción.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Número de lote de la materia prima y cantidades reales utilizadas de cada uno de ellos",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Firma de la persona que despacha, recibe y verifica los insumos",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Firma de las personas que intervienen y supervisan la ejecución de cada etapa de los procesos.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Resultados de los análisis del producto en proceso.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Hojas para el registro de controles durante el proceso y espacio para anotar observaciones.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Espacios para anotar rendimientos intermedios y reales.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Instrucciones para la toma de muestras en las etapas que sean necesarias.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se adjuntan las etiquetas de identificación de áreas y equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se registra en la orden de producción lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) La liberación de áreas y equipos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) La fecha, hora de inicio y de finalización para cada etapa",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Los valores de las variables operacionales a controlar durante el proceso. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fecha de emisión.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Los rendimientos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Además de lo indicado en la fórmula maestra, incluye la orden de envasado y empaque lo siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.2.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Código o número de lote.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Cantidad del producto a envasar o empacar.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Fecha de inicio y finalización de las operaciones de acondicionamiento.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fecha de expiración para cada lote y vida útil del producto",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Firma de las personas que autorizan la orden de envase y empaque.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Número de lote, cantidades, tipos y tamaños de cada material de envase y empaque utilizado",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Firma de las personas que despacha, recibe y verifica los insumos",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Firma de las personas que intervienen y supervisan los procesos de envasado y empaque.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Hojas para el registro de controles durante el proceso de empaque y espacio para anotar observaciones hechas por el personal de empaque y control de calidad.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Muestras del material de acondicionamiento impreso que se haya utilizado, incluyendo muestras con el número de lote, fecha de expiración y cualquier impresión suplementaria.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Cantidades de los materiales impresos de acondicionamiento que han sido devueltos al almacén o destruidos y las cantidades de producto obtenido, con el fin de obtener el balance.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Número de registro sanitario.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Rendimiento de la operación de empaque (cantidad real obtenida y conciliación). ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se registran la(s) fecha(s) y hora(s) de las operaciones de envasado y empaque? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran notas acerca de cualquier problema especial, incluyendo detalles de cualquier desviación de las instrucciones de envasado, con la autorización escrita de la persona responsable?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PROCEDIMIENTOS Y REGISTROS",
                        Criterio = "",
                        Capitulo="11.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se dispone de procedimientos escritos para el control de la producción y demás actividades relacionadas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.3.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registra la ejecución de las actividades respectivas firmándolas de conformidad con el registro de firmas, inmediatamente después de su realización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Queda registrada y justificada cualquier desviación de los procedimientos, por un evento atípico que afecta la calidad del producto?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cada lote de producto cuenta con los registros generados en producción y control que garantizan el cumplimiento de los procedimientos escritos y aprobados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.3.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de calidad o garantía de calidad revisan, aprueban y verifican todos los registros de producción y control de cada lote terminado, así comolos procedimientos escritos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.3.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para el manejo de la desviación en la producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investiga ampliamente cualquier desviación no justificada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se extiende la investigación a otros lotes producidos y a otros productos que puedan estar asociados con la discrepancia encontrada?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para el archivo y conservación de la documentación de un lote cerrado de producción incluyendo el certificado de análisis del producto terminado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="11.3.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se recopila toda la documentación involucrada en la producción de un lote de producto terminado (orden de producción, orden de envasado y empaque, etiquetas, muestras del material de empaque codificado)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se conserva esta documentación archivada por lo menos hasta un año después de la fecha de vencimiento del lote?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se lleva registro correlativo/ secuencial y rastreable de cada producción?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos y registros escritos correspondientes a las actividades realizadas sobre:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="11.3.5  12.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Mantenimiento, limpieza y sanitización de instalaciones, áreas y servicios.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="12.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Uso, mantenimiento, limpieza y sanitización de equipos y utensilios",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Sanitización y mantenimiento de tuberías y de las tomas de fluidos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Calibración de equipo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Asignación de número de lote. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Capacitación del personal (inducción, específica, continua)",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Uso, lavado y secado de uniformes.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Control de las condiciones ambientales (controles microbiológicos de ambiente y superficies)",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Prevención y exterminio de plagas con insecticidas y agentes de fumigación, aprobados por la Autoridad Sanitaria respectiva",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Recolección, clasificación y manejo de basuras y desechos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Muestreo (materiales y productos). ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Validaciones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cada procedimiento escrito tiene claramente definido el propósito, alcance, referencias y responsabilidades?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            /////////////
            Acondicionamiento = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "",
                        Capitulo="12.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos o instrucciones escritas para el manejo de materiales, graneles y productos en las operaciones de:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="12.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuarentena",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Etiquetado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Muestreo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Almacenamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Despacho",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Elaboración",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Envasado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Distribución",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registro de la ejecución de estos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evita cualquier desviación a las instrucciones o procedimientos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="12.1.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las desviaciones en las instrucciones o procedimientos son aprobadas por escrito, por la persona asignada con participación del departamento de control de calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de los controles de proceso y forman parte de toda la documentación del lote del producto fabricado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="12.1.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En un área de producción ¿se lleva a cabo una sola operación de un determinado producto? ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="12.1.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evita la mezcla de productos diferentes o lotes distintos del mismo producto mediante separación física entre las líneas de envasado?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el área de empaque secundario existen líneas identificadas, definidas y separadas para cada producto que se está empacando?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se identifica durante todo el proceso todos los materiales, graneles, equipos y áreas utilizadas con una etiqueta que tenga la siguiente información:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="12.1.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre del producto que se está elaborando",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Número de lote o código",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fase del proceso",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas y los equipos son destinados únicamente para la producción de medicamentos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="12.1.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PREVENCIÓN DE LA CONTAMINACIÓN CRUZADA Y MICROBIANA EN LA PRODUCCIÓN",
                        Criterio = "",
                        Capitulo="12.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos que indiquen medidas preventivas para evitar la contaminación cruzada en todas las fases de producción, los productos y materiales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="12.2.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="12.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Para evitar la contaminación cruzada se tiene: ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="12.2.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Esclusas (cuando aplique).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Áreas con diferenciales de presión.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Sistema de inyección y extracción que garantice la calidad de aire",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Ropa protectora dentro de las áreas en las que se elaboren productos",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Procedimientos de limpieza y sanitización.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Pruebas para detectar residuos (trazas) en los productos altamente activos (cuando aplique).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Etiquetas que indique la situación del estado de limpieza del equipo y áreas.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los materiales y productos son protegidos de la contaminación?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica la eficacia de las medidas destinadas a prevenir la contaminación cruzada?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CONTROLES EN PROCESO",
                        Criterio = "",
                        Capitulo="12.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Antes de iniciar las operaciones de producción, ¿se realiza el despeje del área, se verifica que los equipos estén limpios y libres de materiales, productos y documentos de una operación anterior y cualquier otro material extraño al proceso de producción?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="12.3.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles durante el proceso en las distintas etapas de producción? ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="12.3.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Estos controles se realizan dentro de las áreas de producción?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Estos controles no ponen en riesgo la producción del producto?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles en línea durante el envasado y empaque?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="12.3.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Estos controles incluyen los siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Revisión general de los envases",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b)Verificación de la cantidad de material de acondicionamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Verificar que el código o número de lote y la fecha de expiración sean los correctos y legibles.",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Verificar el funcionamiento correcto de la línea. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Se verifica la integridad de los cierres",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si se utilizan máquinas automáticas para controlar dimensiones, pesos, etiquetas, prospectos, códigos de barras, se verifica su correcto funcionamiento (cuando aplique)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las unidades descartadas por sistemas automáticos, en caso de reintegrarse a la línea son previamente inspeccionadas y autorizadas por personal con responsabilidad asignada (cuando aplique)?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa y procedimiento escrito para realizar los controles microbiológicos de superficie? En caso de acondicionamiento primario",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="12.3.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registros de estos controles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En caso de que estos controles microbiológicos se salgan de los límites específicos ¿se realiza alguna medida correctiva?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuál?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles microbiológicos en forma inmediata después de la medida correctiva?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de todo lo que se efectuó?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan los controles ambientales durante el proceso, cuando estos sean requeridos (temperatura, humedad)?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="12.3.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se inspecciona y verifica el material impreso antes de la codificación del número de lote y fecha de vencimiento de cada producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="12.3.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de esta actividad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los envases primarios vacíos impresos llevan número de lote y fecha de vencimiento, cuando aplique?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si los envases primarios vacíos no llevan lote y fecha de vencimiento, se codifican manual o automáticamente?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si la impresión de etiquetas y estuches se realizan fuera de la línea de empaque, la operación se lleva a cabo en un área exclusiva?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se codifican por sistema manual o automático? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de la persona que realiza la actividad? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica por personal autorizado el correcto número de lote y fecha de vencimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La información impresa o estampada es legible e indeleble?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se efectúa la operación de etiquetado o empaque final después del envasado y cierre?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="12.3.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuando no se realiza en línea, ¿se toman la medidas para asegurar que no haya confusión o errores en el etiquetado y empaque final?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cómo se dispensan las etiquetas? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito donde se indican las medidas de seguridad que se deben tomar para evitar mezclas y confusiones de las etiquetas o cualquier material de acondicionamiento durante el empaque?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las muestras tomadas de la línea de envasado y empaque para análisis, se descartan después de ser analizadas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="12.3.8",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investiga cualquier desviación significativa del rendimiento esperado del lote de un producto? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="12.3.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de esta desviación y de la investigación realizada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos establecidos para la conciliación de las etiquetas o material de acondicionamiento impreso, entregadas, usadas, devueltas en buen estado y destruidas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="12.3.10",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza una evaluación de las diferencias encontradas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investigan las causas de estas diferencias?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estos resultados, conclusiones y de las acciones correctivas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El material impreso y codificado sobrante se destruye?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de esta destrucción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El material impreso no codificado sobrante, se devuelve al almacén de material de acondicionamiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de este material devuelto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            GarantiaCalidad = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "",
                        Capitulo="13.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe una política de calidad definida y está documentada?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="13.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Garantía de calidad cuenta con el respaldo y compromiso de la dirección de la empresa?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay evidencia de este respaldo y compromiso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Garantía de calidad exige la participación y el compromiso del personal de los diferentes departamentos y a todos los niveles dentro de la empresa?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe en la empresa el personal competente que coordine el sistema de garantía de la calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La política de calidad es divulgada en todos los niveles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para esta divulgación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El sistema de garantía de calidad asegura que:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="13.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Los medicamentos se diseñan y desarrollan de forma que se tenga en cuenta lo requerido por las buenas prácticas de manufactura?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se disponen de protocolos y registros de todos los productos de manera que se verifica, que cada lote de producto es fabricado y controlado correctamente de acuerdo con los procedimientos definidos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Si en la revisión de los registros de producción se detectan desvíos de los procedimientos establecidos, ¿garantía de calidad es responsable de asegurar su completa investigación y que las conclusiones finales estén justificadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen documentos originales de todos los procedimientos y registros de distribución de las copias autorizadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Estén claras las especificaciones de las operaciones de producción y control?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿El personal directivo tenga las responsabilidades claramente especificadas y divulgadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Se tengan los requisitos establecidos para la adquisición y utilización de los materiales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Se realice la evaluación y aprobación de los diferentes proveedores?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Todos los controles durante el proceso sean llevados acabo de acuerdo a procedimientos establecidos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿El producto terminado se ha elaborado y controlado de forma correcta, según procedimientos definidos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Exista un procedimiento para la recopilación de toda la documentación del producto que se ha elaborado? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) ¿Los medicamentos sean liberados para la venta o suministro con la autorización de la persona calificada y asignada para hacerlo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) ¿Los medicamentos sean almacenados y distribuidos de manera que la calidad se mantenga durante todo el período de vida útil?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) ¿Verifica que se realizan periódicamente la autoinspección y auditoría de calidad mediante el cual se evalúe la eficacia y aplicabilidad del sistema de garantía de la calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) ¿Verifica que existan y ejecuten los procedimientos, programas y registros de los Estudios de Estabilidad de los productos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "m) ¿Verifica que exista, se ejecute y se cumpla el plan maestro de validación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Da seguimiento a las actividades de validación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Garantía de Calidad verifica el cumplimiento de los planes de capacitación del personal?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se archiva la documentación de cada lote producido?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            ControlCalidad = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "",
                        Capitulo="14.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene control de calidad toda la documentación para asegurar la calidad de los materiales y los productos? ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="14.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está establecido un flujo claramente definido de muestras y documentación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio fabricante cuenta con una unidad de control de calidad?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="14.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de calidad interviene en todas las operaciones y decisiones que afectan la calidad del producto? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La unidad de control de calidad es independiente de producción?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="14.1.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿A quién reporta?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Esta unidad está bajo el cargo de un profesional farmacéutico o un profesional calificado?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué profesión tiene?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de calidad cuenta con los recursos que garanticen la confiabilidad en la toma de las decisiones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La unidad de control de calidad tiene las siguientes obligaciones:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="14.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Valida y aplica todos sus procedimientos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Conserva las muestras de referencia o retención de materiales y productos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Garantiza el etiquetado correcto de los materiales y productos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Realiza la estabilidad de los productos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Participa en la investigación de reclamos relativos a la calidad del producto.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Aprueba o rechaza los materiales y productos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos de estas actividades?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registro de la ejecución de todas estas actividades?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cada lote de producto terminado es aprobado por la persona responsable, previa evaluación de las especificaciones establecidas, incluyendo las condiciones de producción, análisis en proceso y la documentación para su aprobación final?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="14.1.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay personal con responsabilidad asignada y destinado a inspeccionar los procesos de producción (propios y de terceros)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investigan y documentan las desviaciones de los parámetros establecidos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="14.1.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se da seguimiento de las acciones correctivas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se documentan?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene acceso el personal de control de calidad a las áreas de producción con fines de muestreo, inspección e investigación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="14.1.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay un programa de calibración para los equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros que acrediten el cumplimiento del programa?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se indica en el mismo cuales operaciones son realizadas en forma interna y \r\ncuales por servicios contratados?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los equipos están correctamente rotulados indicando la vigencia de la\r\ncalibración?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha de su última calibración",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En el caso de calibraciones internas ¿el laboratorio cuenta con patrones \r\ncertificados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen los certificados correspondientes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "DOCUMENTACIÓN",
                        Criterio = "",
                        Capitulo="14.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La unidad de control de calidad tiene a su disposición la documentación siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="14.2.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Especificaciones escritas de los materiales, producto semielaborado y producto terminado?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Procedimiento escrito para manejo de muestra de retención?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Procedimientos escritos de control de calidad y resultados de las pruebas de materiales, productos, áreas y personal?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de los informes o certificados analíticos de las pruebas de materiales, productos, áreas y personal?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Si se observan modificaciones de datos, la enmienda realizada ¿está fechada, firmada y permite visualizar el dato original?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Los formatos para los informes o certificados analíticos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En caso de contar con sistemas computarizados para la obtención de datos, los mismos ¿permiten ser verificados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los resultados y graficas impresos y archivados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Existen registro de los resultados de las condiciones ambientales de las áreas de producción? Cuando aplique",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) ¿Procedimientos escritos para la calibración de instrumentos y equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la calibración de instrumentos y equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los certificados o informes de calibración indican la trazabilidad a patrones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los certificados o informes de calibración indican la incertidumbre de la medida correspondiente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) ¿Procedimientos escritos de selección y calificación de proveedores?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un registro de proveedores aprobados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de evaluación y auditorías a proveedores?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estas evaluaciones y auditorías?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza una evaluación de los resultados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se adoptan medidas cuando los resultados no son favorables?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) ¿Procedimientos escritos y programa de sanitización de áreas?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "m) ¿Procedimiento escrito para la aprobación y rechazo de materiales y producto terminado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de calidad conserva toda la documentación relativa a un lote según la legislación de cada país?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="14.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "MUESTREO",
                        Criterio = "",
                        Capitulo="14.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos escritos para el muestreo de:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="14.3.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "materiales de envase y empaque.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "producto acondicionado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Estos procedimientos contemplan la siguiente información:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) El método de muestreo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) La cantidad de muestra que debe recolectarse",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Condiciones de almacenamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Instrucciones de limpieza y almacenamiento del equipo de muestreo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro que garantice el cumplimiento de los procedimientos de muestreo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La cantidad de muestra es estadísticamente representativa del total de",
                        Criterio = "",
                        Capitulo="",
                        Articulo="14.3.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "materiales de envase (si aplica) y empaque. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            ProdAnalisisContrato = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "",
                        Capitulo="15.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio fabricante realiza actividades de producción o análisis a terceros?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="15.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Especifique:",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe contrato?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El contrato a terceros para la producción o análisis está debidamente legalizado, definido y de mutuo consentimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="15.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El contrato estipula las obligaciones de cada una de las partes con relación a: ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="15.1.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },

                    // ***** INICIO DE LAS CORRECCIONES *****

                    new ContenidoTablas()
                    {
                        Titulo = "a) Acondicionamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Manejo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Almacenamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Liberación del producto.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se establece en el contrato la persona responsable de autorizar la liberación de cada lote para su comercialización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="15.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El contrato a terceros tiene la siguiente información:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="15.1.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Es redactado por personas competentes y autorizadas?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Aceptación de los términos del contrato por las partes?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Cumplimiento de las Buenas Prácticas de Manufactura?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Abarca acondicionamiento o cualquier otra gestión técnica relacionada con estos?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Describe el manejo de material de acondicionamiento, y producto terminado, en caso sean rechazados?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Permite el ingreso del contratante a las instalaciones del contratista (contratado), para auditorías?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿Permite el ingreso del contratista (contratado) a las instalaciones del contratante?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) ¿Existe una lista de los productos o servicios de objeto del contrato?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },

                    // ***** FIN DE LAS CORRECCIONES *****

                    /* ***** INICIO DEL CÓDIGO ANTES DE LA CORRECCIÓN *****
                    new ContenidoTablas()
                    {
                        Titulo = "a) Fabricación.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Manejo.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Almacenamiento.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Control de calidad.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Análisis. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Liberación del producto.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿Permite el ingreso del contratista (contratado) a las instalaciones del \r\ncontratante?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) ¿Existe una lista de los productos o servicios de objeto del contrato?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    }, 

                    ***** FIN DEL CÓDIGO ANTES DE LA CORRECCIÓN ***** */

                    new ContenidoTablas()
                    {
                        Titulo = "DEL CONTRATANTE",
                        Criterio = "",
                        Capitulo="15.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ha verificado el contratante que el contratista (contratado):",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="15.2.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Cumple con los requisitos legales, para su funcionamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Cumple con las buenas prácticas de manufactura y de laboratorio, con instalaciones, equipo, conocimientos y experiencia para llevar a cabo satisfactoriamente el trabajo contratado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Posee certificado vigente de buenas prácticas de manufactura.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Entrega los productos elaborados cumpliendo con las especificaciones correspondientes y que han sido aprobados por una persona calificada.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Entrega los certificados de análisis con su documentación de soporte, cuando aplique según contrato",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "DEL CONTRATISTA",
                        Criterio = "",
                        Capitulo="15.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ha verificado el contratista (contratado) que el contratante:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="15.3.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Cumple con los requisitos legales de funcionamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Proporciona toda la información necesaria para que las operaciones se realicen de acuerdo al registro sanitario y otros requisitos legales",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se indica en el contrato que el contratista (contratado) no puede ceder a terceros todo o parte del trabajo que se le asigno por contrato?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="15.3.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            ValGenerales = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "",
                        Capitulo="16.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un plan maestro de validación?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="16.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El plan maestro de validación contempla lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Recursos y responsables de su ejecución",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Identificación de los sistemas y procesos a validarse. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Documentación y procedimientos escritos, instrucciones de trabajo y estándares (normas nacionales e internacionales que apliquen).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Lista de validación: instalaciones físicas, procesos, productos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Criterios de aceptación claves.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Formato de los protocolos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Cada actividad de la validación incluida la revalidación.(Programa de validación y revalidación).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está incluido en el plan maestro de validación, control de calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Garantía de calidad da seguimiento a las actividades del programa?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El programa de validación incluye:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Cronograma",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Ubicación de cada actividad.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Responsables de la ejecución. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Los procesos de importancia crítica se validan.",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Prospectivamente?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Retrospectivamente?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Concurrentemente?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cumplen los plazos establecidos en los programas de validación y revalidación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un comité multidisciplinario responsable de coordinar e implementar el plan maestro y todas las actividades de validación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="16.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CONFORMACIÓN DE EQUIPOS",
                        Criterio = "",
                        Capitulo="16.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen equipos conformados por personal calificado en los diferentes aspectos a validar?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="16.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El personal que participa en las actividades ha recibido capacitación en el tema de validación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PROTOCOLOS E INFORMES",
                        Criterio = "",
                        Capitulo="16.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los protocolos de validación están aprobados?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="16.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los protocolos de validación incluyen lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Procedimiento para la realización de la validación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Criterios de aceptación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Informe final aprobado de resultados y conclusiones.",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La documentación de validación esta resguardada y se localiza fácilmente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CALIFICACIÓN Y VALIDACIÓN",
                        Criterio = "",
                        Capitulo="16.4",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se realizan y documentan las calificaciones y validaciones de:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Equipos de producción y control de calidad. ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Procedimientos de limpieza. ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Instalaciones. ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Sistemas informáticos (cuando aplique).",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "DE LA VALIDACIÓN DE MODIFICACIONES",
                        Criterio = "",
                        Capitulo="16.6",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se valida toda modificación importante del proceso de fabricación, incluyendo cualquier cambio en equipos, áreas de fabricación y materiales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="16.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todos los cambios son requeridos formalmente, documentados y aprobados por el comité multidisciplinario? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evalúan estos cambios para determinar si es necesario una re-validación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "REVALIDACIÓN",
                        Criterio = "",
                        Capitulo="16.7",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se establecen los criterios para evaluar los cambios que dan origen a una revalidación? ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="16.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan análisis de tendencia para evaluar la necesidad de revalidar a efectos de asegurar que los procesos y procedimientos sigan obteniendo los resultados deseados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se han definido tiempos para revalidar los procesos,equipos, métodos y sistemas críticos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            QuejasReclamos = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "",
                        Capitulo="17.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos escritos sobre el manejo de:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="17.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Quejas o reclamos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Retiro de productos del mercado.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un sistema para retirar del mercado en forma rápida y efectiva un producto cuando tenga un defecto o exista sospecha de ello, según procedimiento?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "QUEJAS O RECLAMOS",
                        Criterio = "",
                        Capitulo="17.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El procedimiento indica quien es la persona responsable de atender las quejas o reclamos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="17.2.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El procedimiento indica que medida deben de adoptarse en conjunto con el personal de otros departamentos involucrados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Quien coordina la recepción y seguimiento de las quejas o reclamos?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El procedimiento sobre el manejo de quejas o reclamos de productos tiene la siguiente información:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="17.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del producto.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Forma y presentación farmacéutica.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Código o número de lote del producto.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fecha de expiración.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Nombre y datos generales de la persona que realizó el reclamo.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Fecha del reclamo. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Motivo del reclamo.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Revisión de las condiciones del producto cuando se recibe",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Investigación que se realiza",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Determinación de las acciones correctivas y medidas adoptadas.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evalúan otros lotes relacionados con el producto al cual se refiere la queja o reclamo, se indica en el procedimiento escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="17.2.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se documenta esta evaluación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran todas las acciones y medidas generadas como resultado de la investigación de una queja, se indica en el procedimiento escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="17.2.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El registro es claro e identifica el lote o lotes investigados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan revisiones periódicas para evaluar las tendencias de las quejas de manera que se puedan tomar acciones preventivas, se indica en el procedimiento escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="17.2.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se documenta esta revisión periódica?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Informa el fabricante a la Autoridad Reguladora sobre acciones o medidas específicas tomadas como resultado de una queja o reclamo grave, se indica en el procedimiento escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="17.2.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "RETIROS",
                        Criterio = "",
                        Capitulo="17.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está definido en sus procedimientos que la orden de retiro de un producto del mercado es una decisión del mismo laboratorio o de la Autoridad Reguladora?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="17.3.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un responsable de la coordinación del proceso de retiro de un producto del mercado y es totalmente independiente del departamento de ventas?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="17.3.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se indica en el procedimiento escrito quien es el responsable del proceso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito, actualizado para retirar productos del mercado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="17.3.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El procedimiento contempla que se debe elaborar un registro y un informe final?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran las verificaciones del procedimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los registros de distribución están disponibles y son de fácil acceso en el caso que se tuviera que recuperar un producto del mercado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="17.3.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El responsable del proceso tiene acceso a estos registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros del retiro y un informe final del retiro de productos del mercado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="17.3.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Quién recibe copia del informe final? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los productos retirados se identifican y almacenan independientemente, en un área segura mientras se espera la decisión de su destino final?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="17.3.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            AutoInspecAuditCal = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                    {
                        Titulo = "AUTOINSPECCIONES",
                        Criterio = "",
                        Capitulo="18.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Realiza el laboratorio fabricante autoinspecciones y auditorías periódicas?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="18.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene el laboratorio fabricante un procedimiento y programa de autoinspecciones que contempla todos los aspectos de las buenas prácticas de manufactura?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="18.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe de estas autoinspecciones incluye:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Las evaluaciones que se realizaron.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Los resultados.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Conclusiones",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Acciones correctivas y preventivas",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las autoinspecciones se documentan?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="18.1.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de seguimiento a las acciones correctivas y preventivas?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se determina el grado de cumplimiento de las acciones correctivas y preventivas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el procedimiento escrito de autoinspecciones se indica la frecuencia? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="18.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cada aspecto se inspecciona al menos una vez al año?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El personal que realiza las autoinspecciones está calificado y capacitado en buenas prácticas de manufactura? ",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="18.1.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha documentado esa capacitación?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utiliza alguna guía para realizar las autoinspecciones?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="18.1.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuál?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "AUDITORÍAS",
                        Criterio = "",
                        Capitulo="18.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan auditorías de calidad internas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="18.2.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de las auditorías?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan evaluaciones de calidad a los proveedores y contratistas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las auditorías de calidad son realizadas por personal de la misma compañía?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="18.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las auditorías de calidad son realizadas por personal externo?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene el laboratorio un procedimiento escrito para realizar las auditorías de calidad? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="18.2.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se genera un informe que incluye:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Resultados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Conclusiones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se da seguimiento a las acciones correctivas y preventivas de las auditorías de calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen registros de las inspecciones efectuadas por parte de la Autoridad Reguladora?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="18.2.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se da seguimiento a las acciones correctivas y preventivas de las inspecciones de la Autoridad Reguladora?",
                        Criterio = "CRÍTICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////

        }
    }
}
