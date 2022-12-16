using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspGuiaBPMFabricanteMedTB : SystemId
    {
        public AUD_InspGuiaBPMFabricanteMedTB()
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

        //8. EDIFICIOS E INSTALACIONES -> ÁREA DE DISPENSADO DE MATERIA PRIMA
        private AUD_ContenidoTablas areaDispMatPrima;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas AreaDispMatPrima { get => areaDispMatPrima; set => SetProperty(ref areaDispMatPrima, value); }

        //8. EDIFICIOS E INSTALACIONES -> ÁREA DE PRODUCCIÓN
        private AUD_ContenidoTablas areaProduccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas AreaProduccion { get => areaProduccion; set => SetProperty(ref areaProduccion, value); }

        //8. EDIFICIOS E INSTALACIONES -> ÁREAS DE ACONDICIONAMIENTO PARA EMPAQUE SECUNDARIO - ÁREA DE CONTROL DE CALIDAD - ÁREAS AUXILIARES
        private AUD_ContenidoTablas areaAcondicionamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas AreaAcondicionamiento { get => areaAcondicionamiento; set => SetProperty(ref areaAcondicionamiento, value); }

        //9. EQUIPO - GENERALIDADES
        private AUD_ContenidoTablas equiposGeneralidades;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas EquiposGeneralidades { get => equiposGeneralidades; set => SetProperty(ref equiposGeneralidades, value); }

        //9. EQUIPO - siguientes - CALIBRACIÓN - SISTEMA DE AIRE - 
        private AUD_ContenidoTablas equipos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas Equipos { get => equipos; set => SetProperty(ref equipos, value); }

        //10. MATERIALES Y PRODUCTOS - GENERALIDADES - MATERIAS PRIMAS - MATERIALES DE ACONDICIONAMIENTO - PRODUCTOS INTERMEDIOS Y A GRANEL - PRODUCTOS TERMINADOS - MATERIALES Y PRODUCTOS RECHAZADOS - PRODUCTOS DEVUELTOS -  
        private AUD_ContenidoTablas matProducts;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas MatProducts { get => matProducts; set => SetProperty(ref matProducts, value); }

        //11. DOCUMENTACIÓN - GENERALIDADES - DOCUMENTOS EXIGIDOS - PROCEDIMIENTOS Y REGISTROS - 
        private AUD_ContenidoTablas documentacion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas Documentacion { get => documentacion; set => SetProperty(ref documentacion, value); }

        //12. PRODUCCIÓN - GENERALIDADES - PREVENCIÓN DE LA CONTAMINACIÓN CRUZADA Y MICROBIANA EN LA PRODUCCIÓN - CONTROLES EN PROCESO - 
        private AUD_ContenidoTablas produccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas Produccion { get => produccion; set => SetProperty(ref produccion, value); }

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

        //
        private AUD_ContenidoTablas quejasGenerales;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas QuejasGenerales { get => quejasGenerales; set => SetProperty(ref quejasGenerales, value); }

        //17. QUEJAS, RECLAMOS Y RETIRO DE PRODUCTOS - GENERALIDADES - QUEJAS O RECLAMOS - RETIROS - 
        private AUD_ContenidoTablas quejasReclamos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas QuejasReclamos { get => quejasReclamos; set => SetProperty(ref quejasReclamos, value); }

        //18. AUTOINSPECCIÓN Y AUDITORIAS DE CALIDAD - AUTOINSPECCIONES - AUDITORÍAS - 
        private AUD_ContenidoTablas autoInspecAuditCal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas AutoInspecAuditCal { get => autoInspecAuditCal; set => SetProperty(ref autoInspecAuditCal, value); }


        //A. FABRICACIÓN DE PRODUCTOS FARMACÉUTICOS ESTÉRILES
        private AUD_ContenidoTablas fabProdFarmEsteril_A;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas FabProdFarmEsteril_A { get => fabProdFarmEsteril_A; set => SetProperty(ref fabProdFarmEsteril_A, value); }

        //A. FABRICACIÓN DE PRODUCTOS FARMACÉUTICOS ESTÉRILES - GENERALIDADES
        private AUD_ContenidoTablas fabProdFarmEsteril_Gen;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas FabProdFarmEsteril_Gen { get => fabProdFarmEsteril_Gen; set => SetProperty(ref fabProdFarmEsteril_Gen, value); }

        //A. FABRICACIÓN DE PRODUCTOS FARMACÉUTICOS ESTÉRILES - PRODUCCIÓN ASÉPTICA - PRODUCCIÓN CON ESTERILIZACIÓN FINAL - PRODUCCIÓN CON ESTERILIZACIÓN POR FILTRACIÓ
        private AUD_ContenidoTablas fabProdFarmEsteril_A2;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas FabProdFarmEsteril_A2 { get => fabProdFarmEsteril_A2; set => SetProperty(ref fabProdFarmEsteril_A2, value); }

        //A. FABRICACIÓN DE PRODUCTOS FARMACÉUTICOS ESTÉRILES - PERSONAL - INSTALACIONES - SISTEMAS DE AIRE - SISTEMAS DE AGUA - EQUIPO - SANITIZACIÓN - PRODUCCIÓN - ESTERILIZACIÓN - ESTERILIZACIÓN POR CALOR - ESTERILIZACIÓN POR CALOR HÚMEDO - ESTERILIZACIÓN POR CALOR SECO - ESTERILIZACIÓN POR RADIACIÓN - ESTERILIZACIÓN CON OXIDO DE ETILENO - FILTRACIÓN DE PRODUCTOS QUE NO PUEDEN ESTERILIZARSE EN SU ENVASE FINAL - ACABADO DE PRODUCTOS ESTÉRILES - CONTROL DE CALIDAD - 
        private AUD_ContenidoTablas fabProdFarmEsteril_A3;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas FabProdFarmEsteril_A3 { get => fabProdFarmEsteril_A3; set => SetProperty(ref fabProdFarmEsteril_A3, value); }


        //B. FABRICACIÓN DE PRODUCTOS FARMACÉUTICOS β-LACTÁMICOS - PERSONAL - INSTALACIONES - SISTEMA DE AIRE - EQUIPOS - CONTROL DE CALIDAD - 
        private AUD_ContenidoTablas lactamicos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas Lactamicos { get => lactamicos; set => SetProperty(ref lactamicos, value); }

        //C. FABRICACIÓN DE PRODUCTOS CON HORMONAS Y PRODUCTOS CITOSTÁTICOS -> PERSONAL - INSTALACIONES - SISTEMA DE AIRE - EQUIPOS - CONTROL DE CALIDAD
        private AUD_ContenidoTablas prodCitostatico;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoTablas ProdCitostatico { get => prodCitostatico; set => SetProperty(ref prodCitostatico, value); }


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
                            Criterio = "CRITICO",
                            Evaluacion = enumAUD_TipoSeleccion.NA
                        },
                    new ContenidoTablas()
                        {
                            Titulo = "El permiso sanitario de funcionamiento o licencia de operación se encuentra vigente",
                            Criterio = "CRITICO",
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
                        Titulo = "Adquisición de materia prima:",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
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
                            Titulo = "¿EProducto a granel?",
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
                        Titulo = "Laboratorio fabricante de:",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
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
                        Titulo = "¿Producen, envasan, empacan y analizan productos a terceros?",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuáles?",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿De qué empresa (s)? ",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cuenta con los contratos correspondientes de producción, envase, empaque y control analítico que incluyan aspectos de Buenas Prácticas de \r\nManufactura? ",
                        Criterio = "CRITICO",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Con qué empresa(s)?",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tienen aprobadas por parte de la autoridad reguladora las condiciones para las siguientes áreas de producción:",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Área de sólidos no estériles",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Área de líquidos no estériles\r\n",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Semisólidos no estériles",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Área de productos estériles",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Área especiales de fabricación",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Lactámicos",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Biológicos",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Citostáticos",
                        Criterio = "Informativo",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hormonales",
                        Criterio = "Informativo",
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
                        Criterio = "MAYOR",
                        Capitulo="7.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene el laboratorio fabricante organigramas generales y específicos de \r\ncada uno de los departamentos, se encuentran actualizados y aprobados? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe independencia de responsabilidades entre producción y control de la \r\ncalidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta con descripciones escritas de las funciones y responsabilidades de \r\ncada puesto incluido en el organigrama?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de un Director técnico / Regente Farmacéutico? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El director técnico del establecimiento cumple con el horario de \r\nfuncionamiento del laboratorio fabricante?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de jornadas continuas o extraordinarias el Director técnico / \r\nRegente garantiza los mecanismos de supervisión de acuerdo a la Legislación \r\nde cada Estado Parte?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Participa en las inspecciones realizadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PERSONAL",
                        Criterio = "MAYOR",
                        Capitulo="7.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone el laboratorio fabricante de personal con la calificación y \r\nexperiencia práctica según el puesto asignado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las funciones asignadas a cada persona deben ser congruentes con el nivel \r\nde responsabilidad que asuma y que no constituyan un riesgo a la calidad del \r\nproducto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las unidades de producción, control de calidad, garantía de calidad e \r\ninvestigación y desarrollo, están a cargo de profesionales farmacéuticos o \r\nprofesionales calificados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "RESPONSABILIDADES DEL PERSONAL",
                        Criterio = "MAYOR",
                        Capitulo="7.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cumple el responsable de la Dirección de Producción con las siguientes \r\nresponsabilidades:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.3.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Asegura que los productos se elaboren y almacenen en concordancia con la \r\ndocumentación aprobada",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Aprueba los documentos maestros relacionados con las operaciones de \r\nproducción incluyendo los controles durante el proceso y asegurar su estricto \r\ncumplimiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Garantiza que la orden de producción esté completa y firmada por las \r\npersonas designadas antes de que se pongan a disposición del Depto. de \r\nControl de Calidad",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Vigila el mantenimiento del departamento en general, instalaciones y \r\nequipo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Asegura que se lleve a cabo los procesos de producción de acuerdo a los \r\nparámetros establecidos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Autoriza los procedimientos del Departamento de producción, y verifica \r\nque se cumplan dejando constancia escrita",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Asegura que se lleve a cabo la capacitación inicial y continua del personal \r\nde producción y que dicha capacitación se adapte a las necesidades del \r\ndepartamento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cumple el responsable de la Dirección de Control de Calidad con las \r\nsiguientes responsabilidades:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Aprueba o rechaza, según proceda las materias primas, productos \r\nintermedios, a granel, terminado y material de acondicionamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Verifica que toda la documentación de un lote de producto terminado esté \r\ncompleta",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Aprueba las especificaciones, instrucciones de muestreo, métodos de \r\nanálisis y otros procedimientos de control de calidad",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Aprueba los análisis llevados a cabo por contrato a terceros.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Lleva registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Vigila el mantenimiento del departamento, las instalaciones y equipo;",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Verifica que se efectúen las validaciones correspondientes a los \r\nprocedimientos analíticos y de los equipos de control.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Asegura que se lleve a cabo la capacitación inicial y continua del personal \r\nde control de calidad y que dicha capacitación se adapte a las necesidades.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cumplen los responsables de producción y control de calidad con las \r\nresponsabilidades compartidas, las cuales son las siguientes:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Autorizan los procedimientos escritos y otros documentos, incluyendo sus \r\nmodificaciones.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Vigilan y controlanlas áreas de producción.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Vigilan la higiene de las instalaciones de las áreas productivas.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Validan los procesos, califican y calibran los equipos e instrumentos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Aseguran la capacitación del personal.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Participan en la selección, evaluación (aprobación) y control de los \r\nproveedores de materiales, de equipo y otros involucrados en el proceso de \r\nproducción",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Aprueban y controlan la fabricación por terceros. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Establecen y controlan las condiciones de almacenamiento de materiales y \r\nproductos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Conservan la documentación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Vigilan el cumplimiento de las Buenas Prácticas de Manufactura",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Inspeccionan, investigan y muestrean con el fin de controlar los factores \r\nque puedan afectar a la calidad",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CAPACITACIÓN",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con un procedimiento escrito de inducción general de buenas \r\nprácticas de manufactura para el personal de nuevo ingreso y es específica de \r\nacuerdo a sus funciones y atribuciones asignadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen los registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa escrito de capacitación continua en buenas prácticas de \r\nmanufactura, para todo el personal operativo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está la capacitación acorde a las funciones propias de cada puesto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las capacitaciones se efectúan como mínimo dos veces al año?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza evaluación del programa de capacitación tomando en cuenta su \r\nejecución y los resultados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para el ingreso de personas ajenas a las \r\náreas de producción y control de calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SALUD E HIGIENE DEL PERSONAL",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todo el personal previo a ser contratado se somete a examen médico?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El Laboratorio Fabricante garantiza que el personal presente anualmente la \r\ncertificación médica o su equivalente de acuerdo a la legislación del país?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿De acuerdo a las áreas de desempeño, el personal es sometido a exámenes \r\nmédicos, al menos una vez al año?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito en donde el personal enfermo comunique \r\nde inmediato a su superior, cualquier estado de salud que influya \r\nnegativamente en la producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos relacionados con la higiene del personal incluyendo \r\nel uso de ropas protectoras, que incluyan a todas las personas que ingresan a \r\nlas áreas de producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se garantiza que al ingresar a las áreas de producción, los empleados \r\npermanentes, temporales o visitantes, utilizan vestimenta/uniforme acorde a \r\nlas tareas que se realizan, los cuales están limpios y en buenas condiciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Utiliza diariamente el personal dedicado a la producción, que este en contacto \r\ndirecto con el producto, uniforme completo:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "De manga larga",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Sin bolsas en la parte superior",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cierre oculto",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Gorro que cubra la totalidad del cabello,",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Mascarilla",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Guantes desechables",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Zapatos de superficie lisa, cerrados y suela antideslizante",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El personal utiliza el uniforme de acuerdo al área de trabajo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En las áreas de producción, almacenamiento y control de calidad existe la \r\nprohibición de:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Comer, beber, fumar, masticar, así como guardar comida, bebida, \r\ncigarrillos, medicamentos personales",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Utilizar maquillaje, joyas, relojes, teléfonos celulares, radio localizadores, \r\nu otro elemento ajeno al área",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Llevar barba o bigote al descubierto durante la jornada de trabajo en los \r\nprocesos de dispensado, producción y subdivisión",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Salir fuera del áreade producción con el uniforme de trabajo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen rótulos que indiquen tales prohibiciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento que instruya al personal a lavarse las manos antes \r\nde ingresar a las áreas de producción? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen carteles, rótulos alusivos que indiquen al personal la obligación de \r\nlavarse las manos después de utilizar los servicios sanitarios y después de \r\ncomer? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Realiza el laboratorio controles microbiológicos de las manos del personal \r\nde acuerdo a un programa y procedimiento establecido?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿De acuerdo a los resultados se realizan las medidas correctivas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el laboratorio con botiquín y área destinada a primeros auxilios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
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
                        Criterio = "MAYOR",
                        Capitulo="7.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está diseñado el edificio de tal manera que facilite la limpieza, \r\nmantenimiento y ejecución apropiada de las operaciones?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los espacios libres (exteriores) y no productivos pertenecientes a la empresa \r\n¿se encuentran en condiciones de orden y limpieza?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las vías de acceso interno a las instalaciones ¿están pavimentadas o \r\nconstruidas de manera tal que el polvo no sea fuente de contaminación en el \r\ninterior de la planta? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentran actualizados los planos y diagramas de las instalaciones y \r\nedificio?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen fuentes de contaminación ambiental en el área circundante al \r\nedificio? En caso afirmativo, ¿se adoptan medidas de resguardo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos, programa y registros del mantenimiento realizado \r\na las instalaciones y edificios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está diseñado y equipado el edificio de tal forma que ofrezca la máxima \r\nprotección contra el ingreso de insectos y animales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está diseñado el edificio, de tal manera que permita el flujo de materiales, \r\nprocesos y personal evitando la confusión, contaminación y errores?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se supervisa el ingreso de personas ajenas a estas áreas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están las áreas de acceso restringido debidamente delimitadas e \r\nidentificadas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas de producción, almacenamiento y control de calidad no se \r\nutilizan como áreas de paso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los pasillos de circulación se encuentran libres de materiales, productos y \r\nequipo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las condiciones de iluminación, temperatura, humedad y ventilación, para \r\nla producción y almacenamiento, están acordes con los requerimientos del \r\nproducto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los equipos y materiales están ubicados de forma que eviten el riesgo de \r\nconfusión, contaminación cruzada y omisión entre los distintos productos y \r\nsus componentes en cualquiera de las operaciones de producción, control y \r\nalmacenamiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son las áreas de almacenamiento, producción y control de calidadexclusivas \r\npara el uso previsto y se mantienen libres de objetos y materiales extraños al \r\nproceso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las tuberías, artefactos lumínicos, puntos de ventilación y otros servicios, \r\nestán diseñados y ubicados, de tal forma que faciliten la limpieza? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone el edificio de extintores adecuados a las áreas y se encuentran estos \r\nubicados en lugares estratégicos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de drenajes para evitar la contracorriente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de drenajes para evitar la contracorriente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
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
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen las áreas de almacenamiento \r\nsuficiente capacidad para permitir el \r\nalmacenamiento ordenado de las \r\ndiferentes categorías de materiales y \r\nproductos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están debidamente identificados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los pisos, paredes, techos de los \r\nalmacenes están construidos de tal forma \r\nque no afectan la calidad de los \r\nmateriales y productos que se almacenan \r\ny permite la fácil limpieza? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las instalaciones eléctricas están \r\ndiseñadas y ubicadas de tal forma que \r\nfacilitan la limpieza?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los desagües y tuberías están en buen \r\nestado de conservación e higiene?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas de almacenamiento se \r\nmantienen limpias y ordenadas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay instrumentos para medir la \r\ntemperatura y humedad y estas \r\nmediciones están dentro de los \r\nparámetros establecidos para los \r\nmateriales y productos almacenados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las materias primas y productos que \r\nrequieren condiciones especiales de \r\nenfriamiento, se encuentran en cámara \r\nfría?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un sistema de alerta que indique \r\nlos desvíos de la temperatura programada \r\nen la cámara fría?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales y productos están \r\nprotegidos de las condiciones ambientales \r\nen los lugares de recepción y despacho?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El área de recepción está diseñada de tal \r\nmanera que los contenedores de \r\nmateriales puedan limpiarse antes de su \r\nalmacenamiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área de despacho de producto \r\nterminado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas donde se almacenan \r\nmateriales y productos sometidos a \r\ncuarentena están claramente definidas y \r\nmarcadas, el acceso a las mismas está \r\nlimitado sólo al personal autorizado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Si se cuenta con un sistema informático \r\neste debe ofrecer la misma seguridad que \r\nla identificación manual del producto",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe documentación que lo demuestre?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El muestreo de materia prima se efectúa \r\nen área separada o en el área de pesaje o \r\ndispensado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El área de muestreo cumple con las \r\nsiguientes características:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Las paredes, pisos y techos son lisos y \r\ncon curvas sanitarias.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Existen controles de limpieza, \r\ntemperatura y humedad dentro del área de \r\nmuestreo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) La iluminación es suficiente para el \r\ndesempeño del proceso",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) El sistema de aire es independiente. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el laboratorio con áreas de \r\nalmacenamiento separadas para productos \r\nrechazados, retirados y devueltos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen estas áreas acceso restringido y bajo llave?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos que \r\npermitan identificar, separar, retirar y \r\ndestruir los productos rechazados, \r\nretirados, vencidos y devueltos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la ejecución de estos \r\nprocedimientos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se almacenan los materiales de manera \r\nque faciliten la rotación de los mismos, \r\nsiguiendo el sistema PEPS?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se almacenan los productos de manera \r\nque faciliten la rotación de los mismos, \r\nsiguiendo el sistema PVPS?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los materiales y productos \r\nidentificados y colocados sobre tarimas o \r\nestanterías separadas de paredes de \r\nmanera que permitan la limpieza e \r\ninspección? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los contenedores o envases de \r\nmateriales y productos están bien \r\ncerrados?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los movimientos y operaciones, se \r\nrealizan de forma tal que no contaminen \r\nel ambiente ni los materiales allí \r\nalmacenados? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utilizan materias primas psicotrópicas \r\no estupefacientes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen áreas separadas, bajo llave, de \r\nacceso restringido e identificadas para \r\nalmacenar materias primas y productos \r\npsicotrópicos y estupefacientes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área para almacenamiento de \r\nproductos inflamables y explosivos \r\nalejada de las otras instalaciones, es \r\nventilada y cuenta con medidas de \r\nseguridad contra incendios o explosiones, según la legislación nacional?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área separada y de acceso \r\nrestringido para almacenar material \r\nimpreso (etiquetas, estuches, insertos y \r\nenvases impresos)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está identificada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            AreaDispMatPrima = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área separada e identificada, para llevar a cabo las \r\noperaciones de dispensación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene paredes, pisos, techos lisos y curvas sanitarias?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta con un sistema de inyección y extracción de aire \r\nque garanticen la no contaminación cruzada y seguridad del \r\noperario?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mide la presión diferencial periódicamente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de vestidor propio en caso de no estar ubicada en el \r\nárea productiva? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de un sector fuera del área para el lavado de \r\nutensilios usados en las pesadas y medidas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registros de temperatura y humedad, cuando se \r\nrequiera?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El operario dispone de uniforme completo y elementos de \r\nprotección?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito de limpieza del área?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se toman las precauciones necesarias cuando se trabaja con \r\nmaterias primas fotosensibles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cuenta con sistemas para la extracción localizada de \r\npolvos, cuando aplique?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El soporte donde se colocan las balanzas y otros equipos \r\nsensibles es capaz de contrarrestar las vibraciones que afectan \r\nsu buen funcionamiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está el área equipada con balanzas y material volumétrico \r\ncalibrados de acuerdo al rango de medida de los materiales \r\na dispensar?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los equipos utilizados están dentro de un programa de \r\ncalibración de acuerdo a su uso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son verificados con frecuencia definida?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área adyacente al área de dispensado, que se \r\nencuentre delimitada e identificada en donde se coloquen las \r\nmaterias primas que serán pesadas o medidas y las materias \r\nprimas dispensadas que se utilizarán en la producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                }
            };
            ////////
            AreaProduccion = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio cuenta con áreas de tamaño, diseño y servicios \r\n(aire comprimido, agua, luz, ventilación, etc.) para efectuar los \r\nprocesos de producción que corresponden?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las áreas de producción (elaboración): ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Están identificadas y separadas para la producción de \r\nsólidos, líquidos y semisólidos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen paredes, pisos y techos lisos con curvas sanitarias de \r\ntal forma que permitan la fácil limpieza y sanitización?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Las tuberías y puntos de ventilación son de material que \r\npermitan su fácil limpieza y están correctamente ubicados?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Están las tomas de gases y fluidos identificados y no son \r\nintercambiables?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Las ventanas y las lámparas con difusores lisos están \r\nempotrados?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Disponen de sistemas de inyección y extracción de aire?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿No son utilizadas como áreas de paso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿Están libres de materiales y equipo que no estén \r\ninvolucrados en el proceso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) ¿Cuentan con equipo de control de aire, que permita el \r\nmanejo de los diferenciales de presión de acuerdo a los \r\nrequerimientos de cada área?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) ¿Cuentan con registros de temperatura y humedad, cuando \r\nse requiera?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) ¿Las condiciones de temperatura y humedad relativa se \r\najusta a los requerimientos de los productos que en ella se \r\nrealizan?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) ¿Se toman las precauciones necesarias cuando se trabaja \r\ncon materias primas fotosensibles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) ¿Tienen drenajes que no permiten la contracorriente y tienen \r\ntapa sanitaria?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las áreas de empaque primario:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Están identificadas y separadas para el empaque primario \r\nde sólidos, líquidos y semisólidos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen paredes, pisos y techos lisos con curvas sanitarias de \r\ntal forma que permitan la fácil limpieza y sanitización?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Las tuberías y puntos de ventilación son de material que \r\npermitan su fácil limpieza y están correctamente ubicados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Están las tomas de gases y fluidos identificados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Las ventanas y las lámparas con difusores lisos están \r\nempotrados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Disponen de sistemas de inyección y extracción de aire?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿No son utilizadas como áreas de paso?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿Están libres de materiales y equipo que no estén \r\ninvolucrados en el proceso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) ¿Cuentan con equipo de control de aire, que permita el \r\nmanejo de los diferenciales de presión de acuerdo a los \r\nrequerimientos de cada área?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) ¿Cuentan con registros de temperatura y humedad, cuando \r\nse requiera?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) ¿Tienen drenajes que no permiten la contracorriente y tienen \r\ntapa sanitaria?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) ¿Se toman las precauciones necesarias cuando se trabaja \r\ncon productos fotosensibles?",
                        Criterio = "MAYOR",
                        Capitulo="¿Existe un área exclusiva para el lavado de equipos móviles, \r\nrecipientes y utensilios? ",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las instalaciones tienen curvas sanitarias y servicios para el \r\ntrabajo que allí se ejecuta? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las instalaciones tienen curvas sanitarias y servicios para el \r\ntrabajo que allí se ejecuta? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El piso de esta área cuenta con desnivel hacia el desagüe, \r\npara evitar que se acumule el agua? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área separada, identificada, limpia y ordenada para \r\ncolocar equipo limpio que no se esté utilizando? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Tienen paredes, pisos y techos lisos que permitan la fácil \r\nlimpieza y sanitización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿No son utilizadas como áreas de paso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
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
                        Titulo = "¿Está el área de empaque secundario separada e \r\nidentificada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El área tiene el tamaño de acuerdo a su capacidad y línea \r\nde producción, con el fin de evitar confusiones? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El área se encuentra ordenada y limpia?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El área de empaque:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Tienen paredes, pisos y techos lisos de tal forma que \r\npermitan la fácil limpieza y sanitización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Están las tomas de gases y fluidos identificados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Las ventanas y las lámparas con difusores lisos están \r\nempotrados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Tiene ventilación e iluminación que asegure \r\ncondiciones confortables al personal y no afecten \r\nnegativamente la calidad del producto?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿No son utilizadas como áreas de paso, ni cuarentena?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Están libres de materiales y equipo que no estén \r\ninvolucrados en el proceso?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿No se utiliza madera en esta área?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ÁREA DE CONTROL DE CALIDAD",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader= true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área destinada para el laboratorio de control de \r\ncalidad que se encuentra identificada y separada del área de \r\nproducción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El laboratorio de control de calidad tiene las siguientes \r\ncondiciones:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está diseñado de acuerdo a las operaciones que se \r\nrealizan?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene paredes lisas que faciliten su limpieza?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene una campana de extracción para los vapores \r\nnocivos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene suficiente iluminación y ventilación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de suficiente espacio para evitar confusiones y \r\ncontaminación cruzada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de áreas de almacenamiento para las muestras, \r\nreactivos, archivos y patrones referencia, de acuerdo a las \r\nespecificaciones correspondientes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Según las operaciones que se realizan se dispone de las \r\nsiguientes áreas:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "Fisicoquímicas",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Instrumental",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Microbiología",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Lavado de cristalería y utensilios",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe equipo de seguridad como:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ducha",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Lava ojos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Extintores",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Elementos de protección",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El área está diseñada para proteger el equipo e \r\ninstrumentos sensibles del efecto de las vibraciones, \r\ninterferencias eléctricas, humedad y temperatura?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El área de microbiología es exclusiva para el proceso de la \r\nsiembra de productos estériles y no estériles que lo requieran?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área de microbiología separada de las otras \r\náreas, para la siembra de productos estériles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El área de microbiología para productos estériles cuenta \r\ncon:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Paredes, techos y pisos lisos de fácil limpieza y \r\ncurvas sanitarias\r\n.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Un sistema de aire independiente con filtros HEPA \r\nubicados a nivel del techo o campana de flujo laminar\r\n.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Lámparas con difusor liso\r\n.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Mesa de trabajo lisa de preferencia de acero \r\ninoxidable u otro material que garantice la no \r\ncontaminación\r\n.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Ventanas con vidrio fijo al ras de la pared\r\n.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Vestidor exclusivo con filtros HEPA o manejo de \r\ndiferenciales de presión\r\n.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica periódicamente el estado de los filtros del flujo \r\nlaminar?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ÁREAS AUXILIARES",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los servicios sanitarios accesibles a las áreas de \r\ntrabajo y no se comunican directamente con las áreas de producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los vestidores están comunicados directamente con las \r\náreas de producción? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los vestidores y servicios sanitarios tienen las siguientes \r\ncondiciones:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Identificados correctamente\r\n.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La cantidad de servicios sanitarios para hombres y mujeres \r\nestá de acuerdo al número de trabajadores\r\n.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se mantienen limpios y ordenados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos para la limpieza y sanitización",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros de la ejecución de la limpieza y \r\nsanitización",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuentan con lavamanos y duchas provistas de agua\r\n.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Dispone de espejos, toallas de papel o secador eléctrico de \r\nmanos, jaboneras con jabón líquido desinfectante y papel \r\nhigiénico\r\n.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Están separados los vestidores de los servicios sanitarios, manteniendo un flujo adecuado.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Casilleros, zapateras y las bancas necesarias (no de \r\nmadera)",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Rótulos o letreros que enfaticen la higiene personal \r\n(lavarse las manos antes de salir de este lugar).\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se prohíbe mantener, guardar, preparar y consumir \r\nalimentos en esta área, manteniendo rótulos que indiquen \r\nesta disposición",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se prohíbe fumar en estas áreas (rótulo). ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con un comedor separado de las demás áreas \r\nproductivas e identificada, en buenas condiciones de orden \r\ny limpieza? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con un área de lavandería separada y exclusiva \r\npara el lavado y secado de los uniformes utilizados por el \r\npersonal?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Poseen procedimientos escritos para realizar el lavado y \r\nsecado por separado de uniformes por tipo de área no \r\nestéril, estériles y mantenimiento?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área separada a las áreas de producción destinada \r\nal mantenimiento de equipos y al almacenamiento de \r\nherramientas y repuestos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de un área destinada al almacenamiento del \r\nequipo obsoleto o en mal estado que no interviene en los \r\nprocesos de producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área destinada para investigación y desarrollo de \r\nsus productos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El área tiene las siguientes condiciones:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Paredes lisas que faciliten su limpieza?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
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
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está el equipo utilizado en la producción diseñado y construido de acuerdo a la operación que en él se realice?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La ubicación del equipo facilita su limpieza así como la del \r\nárea en la que se encuentra?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el equipo con un código de identificación único?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todo equipo empleado en la producción, control de calidad, \r\nempaque y almacenaje, cuenta con un procedimiento en el \r\ncual se especifiquen en forma clara las instrucciones y \r\nprecauciones para su operación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registros del uso de los equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todos los instrumentos de medición son utilizados de \r\nacuerdo a su rango y capacidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica en el equipo la integridad de los tamices y filtros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La ubicación del equipo facilita su limpieza así como la del \r\nárea en la que se encuentra?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el equipo con un código de identificación único? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todo equipo empleado en la producción, control de calidad, \r\nempaque y almacenaje, cuenta con un procedimiento en el \r\ncual se especifiquen en forma clara las instrucciones y \r\nprecauciones para su operación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registros del uso de los equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todos los instrumentos de medición son utilizados de \r\nacuerdo a su rango y capacidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica en el equipo la integridad de los tamices y filtros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen secadores de lecho estático?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen secadores de lecho fluido?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El proceso de limpieza del juego de mangas garantiza la no \r\ncontaminación cruzada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son las piezas o partes de los equipos almacenadas en un \r\nlugar seguro y se mantienen en buen estado de conservación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica la integridad, medidas e identidad de los \r\npunzones? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen detectores de metales en las tableteadoras?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La reparación y mantenimiento de los equipos se efectúa de \r\ntal forma que no presente ningún riesgo para la calidad de los \r\nproductos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de mantenimiento preventivo de los \r\nequipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los equipos en reparación se identifican como tales? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros del mantenimiento preventivo y correctivo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los equipos declarados fuera de servicio son identificados \r\ncomo tales y retirados de las áreas productivas, según \r\nprocedimiento escrito? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            /////////////
            Equipos = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de mantenimiento de equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos de la limpieza del equipo \r\nincluyendo utensilios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se establece un período de vigencia de la limpieza de los \r\nequipos y utensilios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todas las mangueras, tubos y tuberías empleadas en la \r\ntransferencia de fluidos deben almacenarse identificadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es validada su limpieza?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si el equipo es muy pesado, está diseñado para que se pueda \r\nejecutar su limpieza, sanitización o esterilización en el área \r\nde producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se identifican todos los equipos limpios con una etiqueta que \r\nindique la siguiente información:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre del equipo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha cuando fue realizada la limpieza.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre y número de lote del último producto fabricado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre y número de lote del producto a fabricar, cuando \r\naplique",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre o firma del operario que realizó la limpieza y de \r\nquién la verificó",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son las superficies de los equipos que tienen contacto \r\ndirecto con las materias primas, productos en proceso, de \r\nacero inoxidable de acuerdo a su uso u otro material que no \r\nsea reactivo, aditivo y adsorbente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evita el contacto entre el producto y las sustancias \r\nlubricantes requeridas para el buen funcionamiento del \r\nequipo?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está libre de impurezas el aire inyectado en los equipos de \r\nrecubrimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los filtros empleados en los equipos son descartables?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si los filtros no son descartables, se les da el debido \r\nmantenimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran los cambios de los filtros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los soportes de los equipos que lo requieran son de acero \r\ninoxidable u otro material que no contamine?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CALIBRACIÓN",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza calibración de los instrumentos de medición y \r\ndispositivos de registro o cualquier otro que lo requiera?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La calibración se realiza a intervalos convenientes y \r\nestablecidos de acuerdo con un programa escrito que \r\ncontenga como mínimo frecuencias, límites de exactitud, \r\nprecisión y previsiones para acciones preventivas y \r\ncorrectivas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen registros escritos de las inspecciones? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen registros escritos de las verificaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen registros escritos de las calibraciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los instrumentos están correctamente rotulados indicando la \r\nfecha de calibración?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza la calibración de cada equipo y dispositivos \r\nusando patrones de referencia certificados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SISTEMA DE AGUA",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe suministro de agua potable que le permita satisfacer \r\nsus necesidades?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El agua que abastece el sistema de tratamiento de agua es \r\nclorada, existe un sistema para retirar el cloro residual?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Posee un sistema de tratamiento de agua que le permita \r\nobtenerla cumpliendo con las especificaciones de los libros \r\noficiales para la producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuál es el sistema utilizado para obtener agua?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resinas de intercambio iónico.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Osmosis inversa.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Destilación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Otros, especificar cuáles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene diagrama del sistema de tratamiento, planos de la red \r\nde distribución del agua y sus puntos de muestreo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sistema de agua está construido en material de tipo \r\nsanitario?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La distribución del agua, se hace por tuberías y válvulas de \r\nmaterial sanitario?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sistema de producción de agua es no continuo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sistema de producción de agua es continuo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe procedimiento escrito para la regeneración de las \r\nresinas y la frecuencia de la misma?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Son monitoreados regularmente los sistemas de suministro, \r\ntratamiento de agua y el agua tratada? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen registros del monitoreo y de las acciones \r\nrealizadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe un procedimiento escrito de muestreo del agua?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay rotación de los puntos de muestreo del sistema de \r\ntratamiento de agua y de su red de distribución, cuando \r\naplique?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se proporciona mantenimiento planificado al sistema de \r\ntratamiento de agua y su red de distribución?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos escritos para operar y sanitizar el \r\nsistema de tratamiento de agua, su red de distribución y \r\npuntos de muestreo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuenta con un programa de sanitización del sistema de \r\ntratamiento de agua y su red de distribución?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registro de su ejecución? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se investiga la existencia de residuos de los agentes \r\nquímicos utilizados en la sanitización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los filtros utilizados en el sistema de distribución:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se sanitizan?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registros del reemplazo de los filtros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Para la producción de los productos y el enjuague final en \r\nla limpieza de los recipientes y equipos, se utiliza agua que \r\ncumpla las especificaciones de los libros oficiales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cumplen los tanques o cisternas para almacenamiento de \r\nagua (potable y agua calidad farmacéutica) con condiciones \r\nque aseguren la calidad del agua almacenada?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos escritos para llevar a cabo la \r\nlimpieza, sanitización y control de los tanques o cisternas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se registra la frecuencia de las acciones llevadas a cabo \r\n(rutinarias y correctivas) y puntos de muestreo de:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La ejecución de la limpieza? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La sanitización? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuál es el tiempo de almacenamiento del agua de cálida\r\nfarmacéutica?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de que se almacene por más de 24 horas, esta \r\npermanece en recirculación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se realizan controles fisicoquímicos y microbiológicos del \r\nagua potable y calidad farmacéutica indicando la frecuencia? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se realizan controles fisicoquímicos del agua de calidad \r\nfarmacéutica de acuerdo a farmacopeas oficiales o según \r\nmétodos alternativos validados, de cada lote o día de \r\nproducción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles microbiológicos en los días de uso del \r\nagua en la producción, o con una frecuencia establecida \r\ndebidamente validada? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cada vez que se exceda el límite de alerta en los controles \r\nmicrobiológicos, se lleva a cabo una investigación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registro de dicha investigación y medidas correctivas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SISTEMA DE AIRE",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe un sistema de tratamiento de aire que evite el riesgo \r\nde la contaminación de los productos y las personas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene un sistema de aire central? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene un sistema de aire individual? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El sistema de aire es:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Abierto",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cerrado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sistema de aire está ubicado de manera que facilite su \r\nlimpieza y mantenimiento? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen prefiltros, filtros y todo equipo necesario para \r\ngarantizar el grado de aire que se requiere en las diferentes \r\náreas de producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Están convenientemente ubicadas las rejillas de inyección y \r\nextracción de aire?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se manejan diferenciales de presión?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se tienen instrumentos de medición para verificar los \r\ndiferenciales de presión?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para el mantenimiento y \r\ncalibración de estos instrumentos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registros del mantenimiento y calibración de estos \r\ninstrumentos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se llevan registros de temperatura, humedad relativa y \r\ndiferenciales de presión en las áreas de acuerdo a los \r\nproductos que se fabriquen?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tiene un sistema de inyección y extracción de aire en las \r\náreas de:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Dispensado? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Producción:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Estériles (ver Anexo A).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "No estériles",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Empaque primario.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Almacenes, cuando aplique.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Laboratorios de control",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Pasillos de circulación, cuando aplique.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Pasillos de circulación, cuando aplique.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe un programa de mantenimiento preventivo que \r\nabarque los controles periódicos del sistema de aire?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se llevan registros escritos de los cambios de los filtros y \r\nprefiltros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las operaciones de mantenimiento y reparación se llevan a \r\ncabo tomando en cuenta que no presenten riesgo a la calidad \r\nde los productos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se llevan registros escritos del mantenimiento preventivo y \r\ncorrectivo de los equipos del sistema de aire y donde se \r\nrealizó?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe procedimiento escrito para la destrucción de los \r\nresiduos y filtros que se utilizaron en el sistema de inyección \r\ny extracción de aire?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registros de estas destrucciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe programa y procedimiento escrito para realizar los \r\ncontroles microbiológicos ambientales que garanticen la \r\ncalidad del aire?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se llevan los registros respectivos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de que estos controles microbiológicos se salgan de \r\nlos límites específicos, se investiga y se toman medidas \r\ncorrectivas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Luego de realizar la medida correctiva se verifican \r\nnuevamente los controles microbiológicos en forma \r\ninmediata?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de todo lo que se efectuó y de los nuevos \r\ncontroles microbiológicos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
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
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se documenta y registra el ingreso y egreso de los \r\nmateriales, según procedimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El material que se recibe es debidamente etiquetado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos escritos que describan las operaciones de:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Recepción e identificación de materiales y productos. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Almacenamiento de materiales y productos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Almacenamiento de materiales y productos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Muestreo, análisis y aprobación o rechazo de materiales y \r\nproductos conforme a las especificaciones de cada uno de \r\nellos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales y productos se manejan y almacenan de tal \r\nmanera que se evite cualquier contaminación o situación que \r\npongan en riesgo su calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los recipientes o contenedores de materiales se encuentran \r\ncerrados e identificados? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales están ubicados en tarimas o estantes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe espacio suficiente para realizar la limpieza e \r\ninspección y se encuentran las tarimas o estantes separados \r\nde las paredes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están identificados los materiales con su correspondiente \r\nnúmero de control de acuerdo a la codificación establecida?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Proceden los materiales solamente de proveedores \r\naprobados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales son suministrados según especificaciones \r\nproporcionadas por control de calidad, producción e \r\ninvestigación y desarrollo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica en cada entrega la integridad y cierres de los \r\nrecipientes? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se comprueba la correspondencia entre la nota de entrega y \r\nla etiqueta colocada en el recipiente de materiales que \r\nentrega el proveedor?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Permanece cada lote de materiales en cuarentena mientras \r\nno sea muestreado, examinado y analizado por control de \r\ncalidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de calidad emite la aprobación o rechazo de los \r\nmateriales y productos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan muestreos estadísticamente representativos en \r\ncada ingreso de materiales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son retenidas las muestras de materia prima, por lo menos \r\ndurante un año después de la fecha de expiración del último  lote del producto fabricado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si una entrega de material está compuesta por diferentes \r\nlotes, se considera cada lote por separado para efectos de \r\nmuestreo, análisis y aprobación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La etiqueta de identificación de materiales contiene la \r\nsiguiente información? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre y código del material.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Número de ingreso.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Situación del material.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Nombre del proveedor.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Fecha de vencimiento, cuando aplique.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Número de análisis/ lote interno.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El rótulo está adherido al cuerpo del contenedor y no a su \r\nparte removible?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "MATERIAS PRIMAS\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los recipientes o contenedores de materias primas son \r\ninspeccionados visualmente, para verificar su estado físico en \r\nel momento de su ingreso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El sistema de cierre de estos recipientes o contenedores \r\ngarantiza su integridad e inviolabilidad? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cada lote de materia prima está identificado con una etiqueta \r\nque contenga lo siguiente: ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre de la materia prima.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Código interno",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre del fabricante",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre del proveedor",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cantidad del material ingresado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Código o número de lote del fabricante",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha de expiración",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Condiciones de almacenamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Advertencia y precauciones, cuando aplique",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha de análisis.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha de re-análisis, cuando aplique",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Estado o situación (cuarentena, muestreado, aprobado o \r\nrechazado).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Observaciones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si utiliza un sistema de identificación electrónica debe \r\ncontener la información anterior?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si una materia prima es removida del envase original y \r\ntrasvasado a otro envase, el nuevo recipiente cumple con los \r\nrequisitos de identidad establecidos en el anterior?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El recipiente utilizado para el trasvasado ha sido usado para \r\nel mismo tipo de materia prima o es otro recipiente que \r\ngarantice su integridad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se deja registro de la sustancia contenida anteriormente en \r\nel envase?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es toda la materia prima muestreada, examinada y analizada \r\nde acuerdo a procedimientos escritos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Es toda la materia prima aprobada de acuerdo a sus \r\nespecificaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "De no cumplir con especificaciones se rechaza?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La materia prima que ha estado expuesta a condiciones \r\nextremas (aire, temperatura, humedad o cualquier otra \r\ncondición que pudiera afectarla negativamente), es separada e \r\nidentificada según procedimiento escrito?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de todo lo anterior?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utilizan únicamente las materias primas aprobadas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las materias primas son fraccionadas por personal \r\ndesignado para tal fin? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe procedimiento escrito que garantice que se pesan o \r\nmidan de forma precisa y exacta? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los recipientes están limpios e identificados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Son identificadas y agrupadas para evitar riesgo de \r\nconfusión?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las materias primas de un lote, ya pesadas o medidas ¿son \r\nseparadas físicamente de las de otro lote ya pesado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Si las órdenes ya fraccionadas no son dispensadas a planta en \r\nforma inmediata, ¿cuenta con un área de acceso restringido y \r\nbajo llave o sistema electrónico que evite confusiones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La materia prima después de ser pesada o medida es \r\netiquetada inmediatamente a fin de evitar confusiones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En esa etiqueta, consta: ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader =true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre de la materia prima",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Código o número de lote o número de ingreso.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Nombre del producto a fabricar.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Código de lote del producto a fabricar",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Contenido neto (sistema internacional de unidades de \r\nmedida, SI).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Fecha de dispensado.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Nombre y firma de la persona que dispenso",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Nombre y firma de la persona que revisó",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son identificadas y agrupadas para evitar riesgo de \r\nconfusión? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las materias primas de un lote, ya pesadas o medidas ¿son \r\nseparadas físicamente de las de otro lote ya pesado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Si las órdenes ya fraccionadas no son dispensadas a planta en \r\nforma inmediata, ¿cuenta con un área de acceso restringido y \r\nbajo llave o sistema electrónico que evite confusiones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los recipientes que contienen una materia prima ya pesada \r\n¿son transferidos con seguridad al área de producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de área para la limpieza y sanitización de los \r\ncontenedores con materias primas antes de fraccionar?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los contenedores de las materias primas ya pesadas o \r\nmedidas ¿están bien cerrados e identificados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "MATERIALES DE ACONDICIONAMIENTO",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los envases y cierres son hechos de material que no sea \r\nreactivo, aditivo y adsorbente al producto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los requerimientos de los envases y cierres están \r\nsustentados en los estudios de formulación y pruebas de \r\nestabilidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los envases y cierres son adquiridos de proveedores \r\naprobados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se manipulan y limpian los envases, cierres y medidas \r\ndosificadoras según procedimiento escrito, cuando aplique? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registro de su ejecución?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son todos los materiales de acondicionamiento examinados \r\nrespecto a su cantidad, identidad y conformidad con las \r\nrespectivas instrucciones de la orden de envasado, antes de \r\nser enviados al área?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todos los materiales impresos se manipulan por personal \r\nautorizado de forma tal que se evite cualquier confusión? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCTOS INTERMEDIOS Y A GRANEL",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se manipulan y almacenan los productos intermedios y a \r\ngranel de tal manera que se evite cualquier contaminación o \r\nponga en riesgo la calidad de los productos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área de almacenamiento de productos intermedios \r\ny a granel?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En dónde están ubicados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se identifican todos los productos intermedios o a granel?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCTOS TERMINADOS",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los productos terminados se encuentran en cuarentena hasta \r\nsu aprobación final?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los productos terminados se mantienen almacenados en las \r\ncondiciones requeridas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los productos terminados son comercializados solamente \r\ndespués de su aprobación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la distribución de productos \r\nterminados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "MATERIALES Y PRODUCTOS RECHAZADOS",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para el manejo de \r\nmateriales, productos intermedios, a granel y productos \r\nterminados que han sido rechazados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son identificados mediante el uso de una etiqueta roja \r\njustificando la causa del rechazo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son devueltos o destruidos los materiales rechazados de \r\nacuerdo a procedimiento establecido cumpliendo con la \r\nnormativa ambiental existente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de su ejecución? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El material obsoleto o desactualizado está identificado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es manejado y destruido según procedimiento escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCTOS DEVUELTOS",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para la devolución de \r\nproducto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Define este procedimiento las personas responsables y los \r\ncriterios de tratamiento de los productos devueltos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son almacenados los productos devueltos en un área \r\nseparada y con acceso restringido? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentran identificados como tales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Quiénes son los responsables de decidir el tratamiento de las \r\ndevoluciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Actúan conjuntamente con garantía de calidad o control de \r\ncalidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son destruidos los productos farmacéuticos devueltos que \r\nhayan sido sometidos a condiciones extremas de manejo o \r\nalmacenamiento?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento escrito para la destrucción de estos \r\nproductos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Todas las acciones efectuadas y las decisiones tomadas son \r\nregistradas, detallando:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del producto",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Forma farmacéutica.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Número de lote.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Motivo de la devolución",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Cantidad devuelta.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Fecha de la devolución.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investiga la causa de la devolución y se determina si \r\nafecta cualquier otro lote?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
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
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están las especificaciones, fórmulas, métodos e \r\ninstrucciones de fabricación y procedimientos en forma \r\nimpresa, debidamente revisadas y aprobadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los documentos diseñados, revisados y distribuidos de \r\nacuerdo a un procedimiento escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los documentos aprobados, firmados y fechados por \r\nlas personas autorizadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las modificaciones están autorizadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tienen los documentos las siguientes características:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Están redactados en forma clara, ordenada y libre de \r\nexpresiones ambiguas, permitiendo su fácil comprensión?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Son fácilmente verificables?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Se revisan periódicamente y se mantienen actualizados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Son reproducidos en forma clara e indeleble?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La introducción de datos se realiza con letra clara legible y \r\ncon tinta indeleble?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay en los documentos que lo requieran, espacio para \r\npermitir la realización del registro de datos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los documentos y datos registrados se encuentran en medio \r\nelectrónicos?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen controles especiales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Sólo las personas autorizadas acceden o modifican los \r\ndatos en la computadora? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de los cambios y las eliminaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está el acceso restringido por contraseñas u otros medios? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cualquier corrección realizada en un documento de un dato \r\nescrito está firmada y fechada? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La corrección no impide la lectura del dato inicial?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Indica la causa de la corrección, cuando sea necesario?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de todas las acciones efectuadas o \r\ncompletadas de tal forma que haya trazabilidad de todas las operaciones de los procesos de fabricación de los productos \r\nfarmacéuticos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen todos los registros incluyendo lo referente a \r\nlos procedimientos de operación, un año después de la fecha \r\nde expiración del producto terminado? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un listado maestro de documentos disponible?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se identifica el estado de los mismos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los documentos actualizados en los sitios relacionados \r\na las operaciones esenciales para cada proceso? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son retirados los documentos invalidados u obsoletos de \r\ntodos los puntos de uso? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un archivo histórico identificado para almacenar los \r\noriginales de los documentos obsoletos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "DOCUMENTOS EXIGIDOS",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen especificaciones autorizadas y fechadas por control \r\nde calidad para:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Materia prima.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Material de acondicionamiento.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Productos intermedios o granel.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Producto terminado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Incluyen las especificaciones de la materia prima, material de \r\nacondicionamiento, productos intermedios o granel y \r\nproducto terminado lo siguiente:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del material (denominación común internacional, \r\ncuando corresponda).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Código de referencia interna.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Referencia, si la hubiere de los libros oficiales.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Formula química (cuando aplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Requisitos cuali y cuantitativos con límites de aceptación \r\n(cuando aplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Las técnicas analíticas o procedimiento.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Procedimiento de muestreo.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Muestra del material impreso (cuando aplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Cantidad requerida para la muestra de retención.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Condiciones de almacenamiento y precauciones.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Proveedores aprobados y marcas comerciales (cuando \r\naplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Descripción de la forma farmacéutica y detalle del \r\nempaque (cuando aplique).\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "m) Vida en anaquel (cuando aplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Realizan revisión periódica de las especificaciones \r\nanalíticas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están de acuerdo a los libros oficiales? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Disponen de una fórmula maestra para cada producto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está la fórmula maestra actualizada y autorizada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Quién la actualiza y autoriza?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Contiene la fórmula maestra los datos siguientes:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre y código del producto correspondiente a su \r\nespecificación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Descripción de la forma farmacéutica, potencia o \r\nconcentración del principio activo y tamaño de lote.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Fórmula cuali-cuantitativa expresada en el sistema métrico \r\ndecimal, de las materias primas a emplearse, haciendo \r\nmención de cualquier sustancia que pueda desaparecer \r\ndurante el proceso, usando el nombre y código que es \r\nexclusivo para cada material.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Lista de material de empaque primario y secundario a \r\nemplearse, indicando la cantidad de cada uno y el código que \r\nes exclusivo para cada material.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Indicación del rendimiento teórico con los límites de \r\naceptabilidad.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Indicación de las áreas en las que deben ser realizadas cada \r\nuna de las etapas del proceso y de los principales equipos a \r\nser empleados.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Instrucciones detalladas de los pasos a seguir en el proceso \r\nde producción, mencionando los distintos procedimientos \r\nrelacionados con las etapas de producción y operación de \r\nequipos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Instrucciones referentes a los controles a realizar durante el proceso de producción, indicando especificaciones del \r\nproducto.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Indicaciones para el almacenamiento de los productos\r\n(semielaborados o graneles y terminado), incluyendo el \r\ncontenedor, el etiquetado y cualquier otra condición de \r\nalmacenamiento cuando las características del producto lo \r\nrequieran. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) ¿Precauciones especiales que deben tomarse en cuenta en \r\nlas distintas etapas del proceso? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Nombres y firmas de las personas responsables en la \r\nemisión, revisión y aprobación de la fórmula maestra y fecha \r\nde la aprobación.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Exceso de principios activos (si procede)",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Coinciden las fórmulas maestras de todos los productos \r\nfabricados con las presentadas en la documentación para \r\nobtención del registro sanitario?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si se hace cambio de la fórmula cuali-cuantitativa, estos \r\ncambios son comunicados y aprobados por la Autoridad \r\nReguladora competente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La orden de producción correspondiente a un lote, ¿es \r\nemitida por el departamento asignado para este fin? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Quién la emite?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es una reproducción del registro de la fórmula maestra, que \r\nal asignarle un número de lote se convierte en orden de \r\nproducción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La orden de producción está autorizada por las personas \r\nasignadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tiene la orden de producción además de lo indicado en la \r\nfórmula maestra la información siguiente: ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Código o número de lote.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Fecha de inicio y finalización de la producción.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Fecha de expiración del producto",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Firma de las personas que autorizan la orden de \r\nproducción.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Número de lote de la materia prima y cantidades reales \r\nutilizadas de cada uno de ellos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Firma de la persona que despacha, recibe y verifica los insumos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Firma de las personas que intervienen y supervisan la \r\nejecución de cada etapa de los procesos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Resultados de los análisis del producto en proceso.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Hojas para el registro de controles durante el proceso y \r\nespacio para anotar observaciones.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Espacios para anotar rendimientos intermedios y reales.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Instrucciones para la toma de muestras en las etapas que \r\nsean necesarias.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) De ser necesario un ajuste de concentración del principio \r\nactivo, la modificación está firmada por el responsable.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se adjuntan las etiquetas de fraccionamiento de las materias \r\nprimas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se adjuntan las etiquetas de identificación de áreas y \r\nequipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se registra en la orden de producción lo siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) La liberación de áreas y equipos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) La fecha, hora de inicio y de finalización para cada etapa",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Los valores de las variables operacionales a controlar \r\ndurante el proceso. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fecha de emisión.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Los rendimientos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Los resultados de los análisis del proceso. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) El personal responsable realiza la verificación de peso de \r\nlas materias primas empleadas en la elaboración de cada lote.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Además de lo indicado en la fórmula maestra, incluye la \r\norden de envasado y empaque lo siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Código o número de lote.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Cantidad del producto a envasar o empacar.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Fecha de inicio y finalización de las operaciones de \r\nacondicionamiento.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fecha de expiración para cada lote y vida útil del \r\nproducto",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Firma de las personas que autorizan la orden de envase y \r\nempaque.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Número de lote, cantidades, tipos y tamaños de cada \r\nmaterial de envase y empaque utilizado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Firma de las personas que despacha, recibe y verifica los \r\ninsumos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Firma de las personas que intervienen y supervisan los \r\nprocesos de envasado y empaque.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Hojas para el registro de controles durante el proceso de \r\nempaque y espacio para anotar observaciones hechas por el \r\npersonal de empaque y control de calidad.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Muestras del material de acondicionamiento impreso que se \r\nhaya utilizado, incluyendo muestras con el número de lote, \r\nfecha de expiración y cualquier impresión suplementaria.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Cantidades de los materiales impresos de \r\nacondicionamiento que han sido devueltos al almacén o \r\ndestruidos y las cantidades de producto obtenido, con el fin \r\nde obtener el balance.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Número de registro sanitario.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Rendimiento de la operación de empaque (cantidad real \r\nobtenida y conciliación). ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se registran la(s) fecha(s) y hora(s) de la\r\ns operaciones de \r\nenvasado y empaque? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran notas acerca de cualquier problema especial, \r\nincluyendo detalles de cualquier desviación de las \r\ninstrucciones de envasado, con la autorización escrita de la \r\npersona responsable?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PROCEDIMIENTOS Y REGISTROS",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se dispone de procedimientos escritos para el control de la \r\nproducción y demás actividades relacionadas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registra la ejecución de las actividades respectivas \r\nfirmándolas de conformidad con el registro de firmas, \r\ninmediatamente después de su realización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Queda registrada y justificada cualquier desviación de los \r\nprocedimientos, por un evento atípico que afecta la calidad \r\ndel producto?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cada lote de producto cuenta con los registros generados en \r\nproducción y control que garantizan el cumplimiento de los \r\nprocedimientos escritos y aprobados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de \r\ncalidad o \r\ngarantía de \r\ncalidad revisan, aprueban y verifican todos los registros de producción y control de cada \r\nlote terminado, así comolos procedimientos escritos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para el manejo de la \r\ndesviación en la producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investiga ampliamente cualquier desviación no \r\njustificada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se extiende la investigación a otros lotes producidos y a \r\notros productos que puedan estar asociados con la \r\ndiscrepancia encontrada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para el archivo y \r\nconservación de la documentación de un lote cerrado de \r\nproducción incluyendo el certificado de análisis del producto \r\nterminado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se recopila toda la documentación involucrada en la \r\nproducción de un lote de producto terminado (orden de \r\nproducción, orden de envasado y empaque, etiquetas, \r\nmuestras del material de empaque codificado)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se conserva esta documentación archivada por lo menos \r\nhasta un año después de la fecha de vencimiento del lote?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se lleva registro correlativo/ secuencial y rastreable de cada \r\nproducción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos y registros escritos \r\ncorrespondientes a las actividades realizadas sobre:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Mantenimiento, limpieza y sanitización de instalaciones, \r\náreas y servicios.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Uso, mantenimiento, limpieza y sanitización de equipos y \r\nutensilios",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Sanitización y mantenimiento de tuberías y de las tomas de \r\nfluidos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Calibración de equipo\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Asignación de número de lote. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Capacitación del personal (inducción, específica, continua)",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Uso, lavado y secado de uniformes.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Control de las condiciones ambientales (controles \r\nmicrobiológicos de ambiente y superficies)",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Prevención y exterminio de plagas con insecticidas y \r\nagentes de fumigación, aprobados por la Autoridad Sanitaria respectiva",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Recolección, clasificación y manejo de basuras y desechos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Muestreo (materiales y productos). ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Validaciones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cada procedimiento escrito tiene claramente definido el \r\npropósito, alcance, referencias y responsabilidades?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            /////////////
            Produccion = new AUD_ContenidoTablas() {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos o instrucciones escritas para el \r\nmanejo de materiales, graneles y productos en las \r\noperaciones de:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuarentena",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Etiquetado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Muestreo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Almacenamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Despacho",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Elaboración",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Envasado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Distribución",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registro de la ejecución de estos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La operación de envasado se realiza en línea?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso que no se realiza en línea existen procedimientos \r\nescritos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los productos líquidos o semisólidos se envasan en su \r\ntotalidad en su presentación final?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evita cualquier desviación a las instrucciones o \r\nprocedimientos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las desviaciones en las instrucciones o procedimientos son aprobadas por escrito, por la persona asignada con \r\nparticipación del departamento de control de calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los reprocesos se efectúan solamente en casos en donde la\r\ncalidad del producto no es afectada y reúne todas las \r\nespecificaciones del mismo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evalúa el reproceso de conformidad con un \r\nprocedimiento definido y autorizado, una vez realizada la \r\nevaluación de los riesgos existentes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registra y se le asigna un nuevo número al lote \r\nreprocesado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de los controles de proceso y forman parte \r\nde toda la documentación del lote del producto fabricado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En un área de producción ¿se lleva a cabo una sola operación \r\nde un determinado producto? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evita la mezcla de productos diferentes o lotes distintos \r\ndel mismo producto mediante separación física entre las \r\nlíneas de envasado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el área de empaque secundario existen líneas \r\nidentificadas, definidas y separadas para cada producto que \r\nse está empacando?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se identifica durante todo el proceso todos los materiales, \r\ngraneles, equipos y áreas utilizadas con una etiqueta que \r\ntenga la siguiente información:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre del producto que se está elaborando",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Número de lote o código",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fase del proceso",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La toma de la muestra de los productos intermedios y \r\nproductos terminados se basa en criterios estadísticos que \r\ncontemplan la aleatoriedad y representatividad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas y los equipos son destinados únicamente para la \r\nproducción de medicamentos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PREVENCIÓN DE LA CONTAMINACIÓN CRUZADA Y MICROBIANA EN LA PRODUCCIÓN",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos que indiquen medidas \r\npreventivas para evitar la contaminación cruzada en todas \r\nlas fases de producción, los productos y materiales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Para evitar la contaminación cruzada se tiene: ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Esclusas (cuando aplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Áreas con diferenciales de presión.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Sistema de inyección y extracción que garantice la calidad \r\nde aire",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Ropa protectora dentro de las áreas en las que se elaboren \r\nproductos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Procedimientos de limpieza y sanitización.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Pruebas para detectar residuos (trazas) en los productos \r\naltamente activos (cuando aplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Etiquetas que indique la situación del estado de limpieza \r\ndel equipo y áreas.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los materiales y productos son protegidos de la \r\ncontaminación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los frascos son transferidos al área de llenado protegidos \r\nde la contaminación ambiental?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La transferencia de semielaborados o graneles entre una \r\netapa y otra, se realiza de tal forma que evite la \r\ncontaminación de los mismos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica la eficacia de las medidas destinadas a prevenir \r\nla contaminación cruzada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para evitar la \r\ncontaminación con microorganismos patógenos y mantener \r\nlos recuentos microbianos dentro de especificaciones de los \r\nproductos no estériles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cumplen y están validados? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CONTROLES EN PROCESO ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Antes de iniciar las operaciones de producción, ¿se realiza el \r\ndespeje del área, se verifica que los equipos estén limpios y \r\nlibres de materiales, productos y documentos de una operación anterior y cualquier otro material extraño al \r\nproceso de producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles durante el proceso en las distintas \r\netapas de producción? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Estos controles se realizan dentro de las áreas de \r\nproducción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Estos controles no ponen en riesgo la producción del \r\nproducto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles en línea durante el envasado y \r\nempaque?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Estos controles incluyen los siguiente:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Revisión general de los envases",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b)Verificación de la cantidad de material de \r\nacondicionamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Verificar que el código o número de lote y la fecha de \r\nexpiración sean los correctos y legibles.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Verificar el funcionamiento correcto de la línea. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Se verifica la integridad de los cierres",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si se utilizan máquinas automáticas para controlar \r\ndimensiones, pesos, etiquetas, prospectos, códigos de barras, \r\nse verifica su correcto funcionamiento (cuando aplique)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las unidades descartadas por sistemas automáticos, en caso \r\nde reintegrarse a la línea son previamente inspeccionadas y \r\nautorizadas por personal con responsabilidad asignada \r\n(cuando aplique)?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las unidades descartadas por sistemas automáticos, en caso \r\nde reintegrarse a la línea son previamente inspeccionadas y \r\nautorizadas por personal con responsabilidad asignada \r\n(cuando aplique)?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registros de estos controles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En caso de que estos controles microbiológicos se salgan de \r\nlos límites específicos ¿se realiza alguna medida correctiva?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuál?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles microbiológicos en forma inmediata \r\ndespués de la medida correctiva?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de todo lo que se efectuó?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan los controles ambientales durante el proceso, \r\ncuando estos sean requeridos (temperatura, humedad)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se inspecciona y verifica el material impreso antes de la \r\ncodificación del número de lote y fecha de vencimiento de \r\ncada producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de esta actividad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los envases primarios vacíos impresos llevan número de \r\nlote y fecha de vencimiento, cuando aplique?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si los envases primarios vacíos no llevan lote y fecha de \r\nvencimiento, se codifican manual o automáticamente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si la impresión de etiquetas y estuches se realizan fuera de \r\nla línea de empaque, la operación se lleva a cabo en un área \r\nexclusiva?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se codifican por sistema manual o automático? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de la persona que realiza la actividad? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica por personal autorizado el correcto número de \r\nlote y fecha de vencimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La información impresa o estampada es legible e indeleble?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se efectúa la operación de etiquetado o empaque final \r\ndespués del envasado y cierre?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuando no se realiza en línea, ¿se toman la medidas para \r\nasegurar que no haya confusión o errores en el etiquetado y \r\nempaque final?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cómo se dispensan las etiquetas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito donde se indican las \r\nmedidas de seguridad que se deben tomar para evitar \r\nmezclas y confusiones de las etiquetas o cualquier material \r\nde acondicionamiento durante el empaque?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las muestras tomadas de la línea de envasado y empaque \r\npara análisis, se descartan después de ser analizadas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investiga cualquier desviación significativa del \r\nrendimiento esperado del lote de un producto? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de esta desviación y de la investigación realizada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos establecidos para la \r\nconciliación de las etiquetas o material de acondicionamiento \r\nimpreso, entregadas, usadas, devueltas en buen estado y \r\ndestruidas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza una evaluación de las diferencias encontradas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investigan las causas de estas diferencias?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estos resultados, conclusiones y de las \r\nacciones correctivas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El material impreso y codificado sobrante se destruye?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de esta destrucción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El material impreso no codificado sobrante, se devuelve al \r\nalmacén de material de acondicionamiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de este material devuelto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            GarantiaCalidad = new AUD_ContenidoTablas() {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe una política de calidad definida y está documentada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Garantía de calidad cuenta con el respaldo y compromiso de \r\nla dirección de la empresa?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay evidencia de este respaldo y compromiso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Garantía de calidad exige la participación y el compromiso \r\ndel personal de los diferentes departamentos y a todos los \r\nniveles dentro de la empresa?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe en la empresa el personal competente que coordine el \r\nsistema de garantía de la calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La política de calidad es divulgada en todos los niveles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para esta divulgación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El sistema de garantía de calidad asegura que:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Los medicamentos se diseñan y desarrollan de forma que se tenga en cuenta lo requerido por las buenas prácticas de \r\nmanufactura?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se disponen de protocolos y registros de todos los productos \r\nde manera que se verifica, que cada lote de producto es \r\nfabricado y controlado correctamente de acuerdo con los \r\nprocedimientos definidos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Si en la revisión de los registros de producción se detectan \r\ndesvíos de los procedimientos establecidos, ¿garantía de \r\ncalidad es responsable de asegurar su completa investigación \r\ny que las conclusiones finales estén justificadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen documentos originales de todos los \r\nprocedimientos y registros de distribución de las copias \r\nautorizadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Estén claras las especificaciones de las operaciones de \r\nproducción y control?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿El personal directivo tenga las responsabilidades \r\nclaramente especificadas y divulgadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Se tengan los requisitos establecidos para la adquisición y \r\nutilización de los materiales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Se realice la evaluación y aprobación de los diferentes \r\nproveedores?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Todos los controles durante el proceso sean llevados \r\nacabo de acuerdo a procedimientos establecidos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿El producto terminado se ha elaborado y controlado de \r\nforma correcta, según procedimientos definidos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Exista un procedimiento para la recopilación de toda la \r\ndocumentación del producto que se ha elaborado? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) ¿Los medicamentos sean liberados para la venta o \r\nsuministro con la autorización de la persona calificada y \r\nasignada para hacerlo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) ¿Los medicamentos sean almacenados y distribuidos de \r\nmanera que la calidad se mantenga durante todo el período de \r\nvida útil?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) ¿Verifica que se realizan periódicamente la autoinspección \r\ny auditoría de calidad mediante el cual se evalúe la eficacia y \r\naplicabilidad del sistema de garantía de la calidad?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) ¿Verifica que existan y ejecuten los procedimientos, \r\nprogramas y registros de los Estudios de Estabilidad de los \r\nproductos?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "m) ¿Verifica que exista, se ejecute y se cumpla el plan \r\nmaestro de validación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Da seguimiento a las actividades de validación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Garantía de Calidad verifica el cumplimiento de los planes \r\nde capacitación del personal?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se archiva la documentación de cada lote producido?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            ControlCalidad = new AUD_ContenidoTablas() {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene control de calidad toda la documentación para \r\nasegurar la calidad de los materiales y los productos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Control de calidad realiza controles",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fisicoquímicos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Microbiológicos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está establecido un flujo claramente definido de muestras y \r\ndocumentación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio fabricante cuenta con una unidad de control \r\nde calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de calidad interviene en todas las operaciones y \r\ndecisiones que afectan la calidad del producto? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La unidad de control de calidad es independiente de \r\nproducción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿A quién reporta?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Esta unidad está bajo el cargo de un profesional \r\nfarmacéutico o un profesional calificado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué profesión tiene?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de calidad cuenta con los recursos que garanticen la \r\nconfiabilidad en la toma de las decisiones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La unidad de control de calidad tiene las siguientes \r\nobligaciones:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Valida y aplica todos sus procedimientos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Conserva las muestras de referencia o retención de \r\nmateriales y productos.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Garantiza el etiquetado correcto de los materiales y \r\nproductos.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Realiza la estabilidad de los productos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Participa en la investigación de reclamos relativos a la \r\ncalidad del producto.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Aprueba o rechaza los materiales y productos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos de estas actividades?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registro de la ejecución de todas estas actividades?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cada lote de producto terminado es aprobado por la persona \r\nresponsable, previa evaluación de las especificaciones \r\nestablecidas, incluyendo las condiciones de producción, \r\nanálisis en proceso y la documentación para su aprobación \r\nfinal?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay personal con responsabilidad asignada y destinado a \r\ninspeccionar los procesos de producción (propios y de \r\nterceros)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investigan y documentan las desviaciones de los \r\nparámetros establecidos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se da seguimiento de las acciones correctivas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se documentan?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene acceso el personal de control de calidad a las áreas de \r\nproducción con fines de muestreo, inspección e \r\ninvestigación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene la unidad de control de calidad el equipo necesario \r\npara realizar los análisis? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Adjuntar listado de equipos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de no tener el equipo especializado para realizar un \r\nanálisis específico, ¿Contrata los servicios de un Laboratorio \r\nde Control de Calidad externo, que está debidamente \r\nautorizado por la Autoridad Reguladora?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué análisis se realizan en el Laboratorio de Control de \r\nCalidad externo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio contratado, ¿posee toda la información técnica \r\nnecesaria para que pueda realizar los controles en total \r\nconcordancia con las técnicas de control de la empresa \r\ntitular?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio de control de calidad de la empresa titular, \r\nrecibe del laboratorio contratado los resultados de los ensayos \r\ny tiene acceso a todos los datos para verificar estos \r\nresultados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay un programa de mantenimiento preventivo para todos \r\nlos equipos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registro que acrediten el cumplimiento del \r\nprograma?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay un programa de calibración para los equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se indica en el mismo cuales operaciones son realizadas en \r\nforma interna y cuales por servicios contratados? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los equipos están correctamente rotulados indicando la vigencia de la calibración?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha de su última calibración:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En el caso de calibraciones internas ¿el laboratorio cuenta \r\ncon patrones certificados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen los certificados correspondientes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "DOCUMENTACIÓN",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La unidad de control de calidad tiene a su disposición la \r\ndocumentación siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Especificaciones escritas de los materiales, producto \r\nsemielaborado y producto terminado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Procedimiento escrito para manejo de muestra de \r\nretención?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Metodología analítica escrita de cada materia prima y \r\nproducto terminado, con su referencia? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Procedimientos escritos de control de calidad y resultados \r\nde las pruebas de materiales, productos, áreas y personal?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de los informes o certificados analíticos \r\nde las pruebas de materiales, productos, áreas y personal?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los analistas disponen de registro de laboratorio foliado en \r\nel que se registran los resultados de laboratorio?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los cálculos fechados y firmados por el analista?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Si se observan modificaciones de datos, la enmienda \r\nrealizada ¿está fechada, firmada y permite visualizar el dato \r\noriginal?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Los formatos para los informes o certificados analíticos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En caso de contar con sistemas computarizados para la \r\nobtención de datos, los mismos ¿permiten ser verificados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los resultados y graficas impresos y archivados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Existen registro de los resultados de las condiciones \r\nambientales de las áreas de producción? Cuando aplique",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿Procedimientos escritos de validación de todos los \r\nmétodos de ensayo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de validación de cada uno de los métodos \r\nde ensayo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) ¿Procedimientos escritos para la calibración de \r\ninstrumentos y equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la calibración de instrumentos y \r\nequipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los certificados o informes de calibración indican la \r\ntrazabilidad a patrones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los certificados o informes de calibración indican la \r\nincertidumbre de la medida correspondiente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) ¿Procedimientos escritos del mantenimiento del equipo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros del mantenimiento del equipo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) ¿Procedimientos escritos de selección y calificación de \r\nproveedores?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un registro de proveedores aprobados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de evaluación y auditorías a \r\nproveedores?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estas evaluaciones y auditorías?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza una evaluación de los resultados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se adoptan medidas cuando los resultados no son \r\nfavorables?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) ¿Procedimientos escritos y programa de sanitización de \r\náreas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) ¿Procedimientos escritos para el uso de todo el \r\ninstrumental?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "m) ¿Procedimiento escrito para la aprobación y rechazo de \r\nmateriales y producto terminado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "n) ¿Procedimiento escrito para el mantenimiento de \r\ninstalaciones de control de calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ñ) ¿Procedimiento escrito para el manejo y desecho de \r\nsolventes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "o) ¿Procedimiento escrito para el lavado de cristalería?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "p) ¿Procedimientos escritos para la recepción, identificación, \r\npreparación, manejo y almacenamiento de reactivos y \r\nestándares?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de calidad conserva toda la documentación relativa \r\na un lote según la legislación de cada país?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "MUESTREO",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos escritos para el muestreo de:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "materias primas.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "materiales de envase y empaque.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "producto intermedio o semielaborado.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "producto terminado.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Estos procedimientos contemplan la siguiente información",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) El método de muestreo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) El equipo que debe utilizarse",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen el equipo necesario para el muestreo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El equipo se conserva en buen estado y está debidamente \r\nalmacenado e identificado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) La cantidad de muestra que debe recolectarse",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Instrucciones para la eventual subdivisión de la muestra",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Tipo y condiciones del envase que debe utilizarse para la \r\nmuestra",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Identificación de los recipientes muestreados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Precauciones especiales que deben observarse, \r\nespecialmente en relación con el muestreo de material estéril \r\no de uso delicado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Condiciones de almacenamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Instrucciones de limpieza y almacenamiento del equipo \r\nde muestreo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro que garantice el cumplimiento de los \r\nprocedimientos de muestreo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La cantidad de muestra que se recolecta es estadísticamente \r\nrepresentativa del lote de",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "materias primas",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "materiales de envase y empaque",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "producto intermedio o semielaborado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "producto terminado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El número de envases muestreados coincide con el \r\nprocedimiento de muestreo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza muestreo y análisis de identidad del contenido de cada recipiente de materia prima?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las muestras están identificadas con una etiqueta que tiene la \r\nsiguiente información:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del material o producto",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Cantidad.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Número de lote",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fecha de muestreo. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Recipientes de los que se han tomado las muestras",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Nombre y firma de la persona que realiza el muestreo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se conservan muestras de referencia de cada lote de:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Ingredientes activos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Producto terminado.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las muestras de referencia de cada lote, se almacenan hasta \r\nun año después de la fecha de expiración?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La cantidad de las muestras de referencia es suficiente para \r\npermitir al menos un análisis completo de acuerdo al \r\nprocedimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las muestras de referencia de producto terminado se \r\nconservan en su empaque final? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las muestras de referencia de producto terminado se \r\nmantienen en las condiciones de almacenamiento según \r\nespecificación del producto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan exámenes visuales de las muestras de referencia \r\npor lo menos una vez al año?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen registro de estas inspecciones, en caso de \r\nencontrar desviaciones se documenta las acciones \r\ncorrectivas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "METODOLOGÍA ANALÍTICA",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen todos los métodos analíticos por escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los métodos analíticos empleados están aprobados y \r\nvalidados? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de validación de los métodos analíticos \r\nutilizados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de cumplimiento de este programa?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los formatos de informes o certificados analíticos tienen la \r\nsiguiente información registrada:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del material o producto.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Forma farmacéutica (cuando aplique).\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Presentación farmacéutica (cuando aplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Número de lote",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Nombre del fabricante y proveedor, cuando se declare",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Referencias de las especificaciones y procedimientos \r\nanalíticos pertinentes.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Resultados de los análisis, con observaciones, cálculos, \r\ngráficas, cromatogramas y referencias.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Fechas de los análisis.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Firma registrada de las personas que realizan los análisis.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Firma registrada de las personas que verifican los análisis \r\ny los cálculos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Registro de aprobación o rechazo (u otra decisión sobre la \r\nconsideración del producto), fecha y firma del responsable \r\ndesignado.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los informes se encuentran accesibles y tienen la \r\ninformación indicada anteriormente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para realizar todos los \r\ncontroles durante el proceso de producción de acuerdo a los \r\nmétodos aprobados por control de calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay personal asignado para realizar los controles en \r\nproceso, durante el proceso de producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha capacitado el personal para esta función? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de los resultados de los controles en \r\nproceso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "De acuerdo a condiciones definidas y escritas se prepara y se \r\nconserva los: ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Reactivos químicos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de los reactivos necesarios para la realización de \r\nlos análisis físicos químicos de rutina? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para la preparación, uso y \r\nconservación de cada una de las soluciones valoradas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿A los reactivos recibidos se les rotula con fecha de \r\nrecepción, de apertura y vencimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantiene un control de las fecha de expiración de estos \r\nreactivos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Medios de cultivo.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de los medios de cultivo necesarios para realizar \r\nlos controles microbiológicos de rutina?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentran dentro del periodo de validez?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para la preparación de cada \r\nuno de los medios de cultivo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los medios de cultivo deshidratados ¿se almacenan en \r\ncondiciones de humedad y temperatura indicadas por el \r\nfabricante?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran los parámetros de cada ciclo de esterilización de \r\nmedios de cultivo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza el test de promoción de crecimiento cada vez que \r\nse utilizan nuevos lotes de medios de cultivo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Cepas de referencia.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen cepas microbianas de referencia?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En caso de existir ¿son certificadas por un organismo \r\nreconocido internacionalmente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de identificación y uso de cepas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está establecida la frecuencia de los repiques/ resiembras? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran los repiques/resiembras? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan a cabo controles periódicos para verificar la \r\nidentidad morfológica y bioquímica de estas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se mantiene un control de las fecha de expiración de estas \r\ncepas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan ensayos de determinación de potencia de \r\nantibióticos, cuando aplique? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se efectúa la verificación estadística de la determinación de \r\npotencia y validez del ensayo, cuando aplique? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con áreas o sectores asignados para la preparación \r\nde muestras, lavado y acondicionamiento de materiales y preparación de medios de cultivo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sector de microbiología, cuenta con un sistema para \r\ndescontaminación bacteriana? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento escrito para el manejo y eliminación \r\nde desechos químicos y microbiológicos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son eliminados en forma sanitaria a intervalos regulares y \r\nfrecuentes evitando la contaminación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Patrones de referencia.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen patrones y materiales de referencia?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan los registros de los patrones primarios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan los registros de los patrones secundarios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan los registros de los materiales de referencia?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todos los patrones secundarios y materiales de referencia \r\ntienen certificado analítico vigente? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantiene un control de las fechas de expiración de estos \r\npatrones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para la preparación, uso y \r\nconservación de cada uno de los patrones secundarios y \r\nmateriales de referencia?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cada envase de reactivos químicos, medios de cultivo, cepas \r\ny patrones de referencia, preparados en el laboratorio lleva \r\nuna etiqueta de identificación con la siguiente información:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Concentración-factor de normalización (cuando aplique).\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Fecha de preparación y valoración (cuando aplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Nombre y firma de la persona que realizo la preparación \r\n(cuando aplique).\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Fecha de revaloración (cuando aplique).\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Fecha de vencimiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Condiciones de almacenamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Categoría de seguridad",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Referencia al procedimiento.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTABILIDAD",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La unidad de control de calidad realiza estudios de \r\nestabilidad de los productos terminados, con el fin de \r\ngarantizar que el producto cumpla con las especificaciones de \r\ncalidad durante su vida útil?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dichos estudios de estabilidad se determinan antes de la \r\ncomercialización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan estudios de estabilidad después de cualquier \r\nmodificación significativa en la fabricación de los productos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen los estudios de estabilidad acelerada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen los estudios de estabilidad en estante o de largo \r\nplazo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa permanente para la determinación de la \r\nestabilidad de los productos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cumple el programa?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen protocolos de estudios de estabilidad de los \r\nproductos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye: ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Descripción completa del producto objeto del estudio?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Parámetros controlados y métodos analíticos validados \r\nque demuestren la estabilidad del producto de acuerdo a las \r\nespecificaciones establecidas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Cantidad suficiente de muestras para cumplir con el \r\nprograma?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Cronograma de los ensayos analíticos a realizar para cada \r\nproducto?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Condiciones especiales de almacenamiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Un resumen y datos obtenidos incluyendo las \r\nevaluaciones y conclusiones del estudio?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Un número suficiente de lotes? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las fechas de caducidad y las condiciones de \r\nalmacenamiento de los productos son establecidas basándose \r\nen los estudios de estabilidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un sistema de seguimiento de los productos \r\ncomercializados que permita verificar el plazo de validez \r\nestablecido?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
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
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio fabricante realiza actividades de producción o \r\nanálisis a terceros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Especifique:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe contrato?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El contrato a terceros para la producción o análisis está \r\ndebidamente legalizado, definido y de mutuo \r\nconsentimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El contrato estipula las obligaciones de cada una de las partes \r\ncon relación a: ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Fabricación.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Manejo.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Almacenamiento.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Control de calidad.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Análisis. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Liberación del producto.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se establece en el contrato la persona responsable de \r\nautorizar la liberación de cada lote para su comercialización y \r\nde emitir el certificado de análisis?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El contrato a terceros tiene la siguiente información: ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Es redactado por personas competentes y autorizadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Aceptación de los términos del contrato por las partes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Cumplimiento de las Buenas Prácticas de Manufactura?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Abarca la producción y el análisis o cualquier otra gestión \r\ntécnica relacionada con estos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Describe el manejo de materias primas, material de \r\nacondicionamiento, graneles y producto terminado, en caso \r\nsean rechazados?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Permite el ingreso del contratante a las instalaciones del \r\ncontratista (contratado), para auditorías?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿Permite el ingreso del contratista (contratado) a las \r\ninstalaciones del contratante?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) ¿Existe una lista de los productos o servicios de análisis \r\nobjeto del contrato?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de análisis por contrato, el contratista (contratado) \r\nacepta que puede ser inspeccionado por la Autoridad \r\nReguladora?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se contempla dentro del contrato?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "DEL CONTRATANTE",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ha verificado el contratante que el contratista (contratado):",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Cumple con los requisitos legales, para su funcionamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Cumple con las buenas prácticas de manufactura y de \r\nlaboratorio, con instalaciones, equipo, conocimientos y \r\nexperiencia para llevar a cabo satisfactoriamente el trabajo \r\ncontratado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Posee certificado vigente de buenas prácticas de \r\nmanufactura.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Entrega los productos elaborados cumpliendo con las \r\nespecificaciones correspondientes y que han sido aprobados \r\npor una persona calificada.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Entrega los certificados de análisis con su documentación \r\nde soporte, cuando aplique según contrato",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "DEL CONTRATISTA",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ha verificado el contratista (contratado) que el contratante:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Cumple con los requisitos legales de funcionamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Tramita y obtiene el registro sanitario del producto(s) a \r\nfabricar",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Proporciona toda la información necesaria para que las \r\noperaciones se realicen de acuerdo al registro sanitario y \r\notros requisitos legales",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se indica en el contrato que el contratista (contratado) no \r\npuede ceder a terceros todo o parte del trabajo que se le \r\nasigno por contrato?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            ValGenerales = new AUD_ContenidoTablas() {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un plan maestro de validación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El plan maestro de validación contempla lo siguiente:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Recursos y responsables de su ejecución",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Identificación de los sistemas y procesos a validarse. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Documentación y procedimientos escritos, instrucciones de \r\ntrabajo y estándares (normas nacionales e internacionales que \r\napliquen).\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Lista de validación: instalaciones físicas, procesos, \r\nproductos.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Criterios de aceptación claves.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Formato de los protocolos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Cada actividad de la validación incluida la \r\nrevalidación.(Programa de validación y revalidación).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está incluido en el plan maestro de validación, control de \r\ncalidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Garantía de calidad da seguimiento a las actividades del \r\nprograma?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El programa de validación incluye:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Cronograma",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Ubicación de cada actividad.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Responsables de la ejecución. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Los procesos de importancia crítica se validan.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Prospectivamente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Retrospectivamente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Concurrentemente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cumplen los plazos establecidos en los programas de \r\nvalidación y revalidación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un comité multidisciplinario responsable de coordinar \r\ne implementar el plan maestro y todas las actividades de \r\nvalidación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CONFORMACIÓN DE EQUIPOS\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen equipos conformados por personal calificado en los \r\ndiferentes aspectos a validar?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El personal que participa en las actividades ha recibido \r\ncapacitación en el tema de validación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PROTOCOLOS E INFORMES\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los protocolos de validación están aprobados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los protocolos de validación incluyen lo siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Procedimiento para la realización de la validación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Criterios de aceptación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Informe final aprobado de resultados y conclusiones.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La documentación de validación esta resguardada y se \r\nlocaliza fácilmente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CALIFICACIÓN Y VALIDACIÓN",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se realizan y documentan las calificaciones y validaciones \r\nde:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Equipos de producción y control de calidad. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Métodos analíticos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Procesos de producción de no estériles.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Procesos de producción de estériles (ver Anexo A \r\nProductos Estériles).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Procedimientos de limpieza. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Sistema de agua (ver desglose).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Sistema de aire (ver desglose).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Sistema de vapor (calderas y otros), cuando aplique",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Instalaciones. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Sistemas informáticos (cuando aplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SE REALIZA Y DOCUMENTA LA CALIFICACION Y \r\nVALIDACION DE SISTEMA DE AGUA",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha realizado la calificación de la instalación del sistema \r\nde agua (CI o IQ)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe protocolo e informe de la calificación de la \r\ninstalación del sistema de agua?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye lo siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Revisión de las instalaciones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Especificaciones de equipos versus diseño.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Pruebas de rugosidad de soldaduras en tuberías",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ausencia de puntos/tramos muertos de tuberías",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Pasivación de tuberías y tanques",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Revisión de los planos del sistema como fue construido(as \r\nbuilt)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Revisión de procedimientos de operación, de limpieza y \r\nsanitización, de mantenimiento preventivo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Calibración de instrumentos de medición.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe incluye lo siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusión/ resumen",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción del ensayo realizado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Referencias del protocolo.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha realizado la calificación de la operación del sistema de \r\nagua (CO u OQ)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe protocolo e informe de la calificación de la operación \r\ndel sistema de agua?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye lo siguiente:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Capacidad de producción del sistema de agua (L/min).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tipo de flujo y velocidad del agua.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de válvulas.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de sistemas de alarma.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de controles.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe incluye:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusión/ resumen",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción del ensayo realizado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Referencias del protocolo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se ha realizado la calificación de desempeño (performance) \r\ndel sistema de agua (CD o PQ): Fase 1, Fase 2 y Fase 3?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Validación Fase 1:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están definidos los parámetros operacionales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están definidos los procedimientos de limpieza y \r\nsanitización; incluyendo sus frecuencias?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con los registros de muestreo diario de cada punto \r\nde pre-tratamiento y de cada punto de uso, efectuado durante \r\nun período de 2 a 4 semanas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen los procedimientos escritos del sistema de agua?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Validación Fase 2:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con los registros de muestreo diario de cada punto \r\nde pre-tratamiento y de cada punto de uso, efectuado durante \r\nlas siguientes 4 a 5 semanas después de cumplida la Fase 1?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los resultados de estos registros demuestran que el sistema \r\nestá controlado (cumple con los parámetros definidos en las \r\nespecificaciones respecto de la calidad de agua y cumple con \r\nlos parámetros del sistema de agua)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Disponen de los informes que resumen los resultados de las \r\nfases 1 y 2 de la validación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Validación Fase 3:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con los registros de muestreo semanal de todos los \r\npuntos de uso correspondientes a un período de un año?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los resultados de estos registros demuestran que el sistema \r\nestá controlado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Disponen del informe resumen de la validación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los componentes del sistema se encuentran en buen estado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe el protocolo e informe de la calificación del \r\ndesempeño (performance) del sistema: Fase 1, Fase 2 y Fase \r\n3?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye lo siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Plano del sistema con indicación de puntos de uso.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Programa de rotación de puntos de muestreo (en caso que \r\nno se muestreen siempre todos los puntos de uso).\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Protocolos de análisis fisicoquímicos y microbiológicos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Programa de frecuencia de análisis para la liberación del \r\nsistema de agua",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Programa de frecuencia de análisis para el seguimiento del \r\nsistema de agua",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe incluye lo siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusión/ resumen",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción del ensayo realizado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Referencias del protocolo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los instrumentos críticos de medición calibrados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen los informes de calibración?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Poseen etiquetas donde figuren fecha de la última \r\ncalibración?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El informe final de la validación del sistema de agua está\r\navalado por la firma de todos los involucrados, la verificación \r\ny firma de garantía de calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SE REALIZA Y DOCUMENTA LA CALIFICACION Y \r\nVALIDACION DE SISTEMA DE AIRE.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha realizado la calificación de la instalación del sistema \r\nde aire (CI o IQ)?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe protocolo e informe de la calificación de la \r\ninstalación del sistema de aire?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye lo siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Revisión de las instalaciones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Especificaciones de equipos versus diseño",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Revisión de los planos del sistema como fue construido (as \r\nbuilt)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Revisión de procedimientos de operación, de limpieza y \r\ndesinfección, de mantenimiento preventivo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Calibración de instrumentos de medición",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Evaluación del sistema de inyección de aire",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Evaluación del sistema de extracción de aire",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe incluye lo siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader =true
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resumen",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción del ensayo realizado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Referencias del protocolo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha realizado la calificación de la operación del sistema de \r\naire (CO u OQ)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe protocolo e informe de la calificación de la operación \r\ndel sistema de aire?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las pruebas son realizadas en las áreas en reposo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye lo siguiente:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tipo de flujo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Diferencial de presión sobre el filtro",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Diferencial de presión del área.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Velocidad/ Uniformidad del flujo del aire",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Volumen/ Velocidad del flujo de aire",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Paralelismo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Patrón del flujo de aire",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tiempo de recuperación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Clasificación del área (partículas transportadas por el aire).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Temperatura y humedad",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de sistemas de alarma",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de controles",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe incluye:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resumen",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción de los ensayos realizados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Referencias del protocolo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha realizado la calificación del desempeño (performance) \r\ndel sistema de aire (CD o PQ)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe protocolo e informe de la calificación del desempeño \r\n(performance) del sistema de aire (CD o PQ)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las pruebas son realizadas en las áreas en funcionamiento \r\n(operacionalmente)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye lo siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tipo de flujo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Diferencial de presión sobre el filtro",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Diferencial de presión del área",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Velocidad/ Uniformidad del flujo del aire",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Volumen/ Velocidad del flujo de aire.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Paralelismo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Patrón del flujo de aire.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tiempo de recuperación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Clasificación del área (partículas transportadas por el aire)",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Temperatura y humedad",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de sistemas de alarma",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de controles",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe incluye:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resumen",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción del ensayos realizados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Referencias del protocolo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Validación Microbiológica del Sistema de Aire",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Definición de límites de alerta/ de acción como una función \r\nde la limpieza del área",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Identificación y marcado de los puntos de muestreo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Definición de las condiciones de transporte, almacenamiento \r\ne incubación de las muestras.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuáles son los límites de alerta?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuáles son los límites de acción?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué procedimientos se siguen si se exceden estos puntos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentran documentados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las pruebas son realizadas en las áreas en reposo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las pruebas son realizadas en las áreas en funcionamiento \r\n(operacionalmente)?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen protocolos de calificación de operación (CO u OQ) \r\nen los que tengan la siguiente información:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Introducción",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Responsabilidades",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ensayos realizados.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Criterios de aceptación de la calificación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Registro y reporte de datos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen los informes de la calificación de operación (CO u \r\nOQ) en los que tengan lo siguiente:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resumen",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción de ensayos realizados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos obtenidos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen protocolos de calificación del desempeño de equipos \r\n(CD o PQ) en los que tengan la siguiente información:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Introducción",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Responsabilidades",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ensayos realizados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Criterios de aceptación de la calificación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Registro y reporte de datos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen los informes de la calificación del desempeño de \r\nequipos (CD o PQ) en los que tengan lo siguiente:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resumen",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción de ensayos realizados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos obtenidos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El informe final de la validación del sistema de aire está\r\navalado por la firma de todos los involucrados, la verificación \r\ny firma de garantía de calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "DE NUEVA FÓRMULA",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuando se realiza cambios en la formulación o en el método \r\nde preparación, ¿se toman las medidas para demostrar que las \r\nmodificaciones realizadas aseguran un producto con la \r\ncalidad exigida?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene el laboratorio procedimientos escritos para \r\ndocumentar el control de cambios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "DE LA VALIDACIÓN DE MODIFICACIONES",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se valida toda modificación importante del proceso de \r\nfabricación, incluyendo cualquier cambio en equipos, áreas \r\nde fabricación y materiales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todos los cambios son requeridos formalmente, \r\ndocumentados y aprobados por el comité multidisciplinario? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evalúan estos cambios para determinar si es necesario \r\nuna re-validación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "REVALIDACIÓN",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se establecen los criterios para evaluar los cambios que dan \r\norigen a una revalidación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan análisis de tendencia para evaluar la necesidad \r\nde revalidar a efectos de asegurar que los procesos y \r\nprocedimientos sigan obteniendo los resultados deseados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se han definido tiempos para revalidar los procesos,\r\nequipos, métodos y sistemas críticos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            QuejasGenerales = new AUD_ContenidoTablas() {
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos escritos sobre el manejo de:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Quejas o reclamos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Retiro de productos del mercado.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un sistema para retirar del mercado en forma rápida y \r\nefectiva un producto cuando tenga un defecto o exista \r\nsospecha de ello, según procedimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "QUEJAS O RECLAMOS",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El procedimiento indica quien es la persona responsable de \r\natender las quejas o reclamos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El procedimiento indica que medida deben de adoptarse en \r\nconjunto con el personal de otros departamentos \r\ninvolucrados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Quien coordina la recepción y seguimiento de las quejas o \r\nreclamos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El procedimiento sobre el manejo de quejas o reclamos de \r\nproductos tiene la siguiente información:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del producto.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Forma y presentación farmacéutica.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Código o número de lote del producto.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fecha de expiración.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Nombre y datos generales de la persona que realizó el \r\nreclamo.\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Fecha del reclamo. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Motivo del reclamo.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Revisión de las condiciones del producto cuando se recibe",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Investigación que se realiza",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Determinación de las acciones correctivas y medidas \r\nadoptadas.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evalúan otros lotes relacionados con el producto al cual \r\nse refiere la queja o reclamo, se indica en el procedimiento \r\nescrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se documenta esta evaluación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran todas las acciones y medidas generadas como \r\nresultado de la investigación de una queja, se indica en el \r\nprocedimiento escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El registro es claro e identifica el lote o lotes investigados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan revisiones periódicas para evaluar las tendencias \r\nde las quejas de manera que se puedan tomar acciones \r\npreventivas, se indica en el procedimiento escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se documenta esta revisión periódica?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Informa el fabricante a la Autoridad Reguladora sobre \r\nacciones o medidas específicas tomadas como resultado de \r\nuna queja o reclamo grave, se indica en el procedimiento \r\nescrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "RETIROS",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está definido en sus procedimientos que la orden de retiro \r\nde un producto del mercado es una decisión del mismo \r\nlaboratorio o de la Autoridad Reguladora?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un responsable de la coordinación del proceso de \r\nretiro de un producto del mercado y es totalmente \r\nindependiente del departamento de ventas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se indica en el procedimiento escrito quien es el responsable \r\ndel proceso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito, actualizado para retirar \r\nproductos del mercado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El procedimiento contempla que se debe elaborar un \r\nregistro y un informe final?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran las verificaciones del procedimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los registros de distribución están disponibles y son de fácil \r\nacceso en el caso que se tuviera que recuperar un producto \r\ndel mercado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El responsable del proceso tiene acceso a estos registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros del retiro y un informe final del retiro de \r\nproductos del mercado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Quién recibe copia del informe final? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los productos retirados se identifican y almacenan \r\nindependientemente, en un área segura mientras se espera la \r\ndecisión de su destino final?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            AutoInspecAuditCal = new AUD_ContenidoTablas() { 
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                    {
                        Titulo = "AUTOINSPECCIONES",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Realiza el laboratorio fabricante autoinspecciones y \r\nauditorias periódicas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene el laboratorio fabricante un procedimiento y \r\nprograma de autoinspecciones que contempla todos los \r\naspectos de las buenas prácticas de manufactura?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe de estas autoinspecciones incluye:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Las evaluaciones que se realizaron.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Los resultados.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Conclusiones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Acciones correctivas y preventivas",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las autoinspecciones se documentan?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de seguimiento a las acciones \r\ncorrectivas y preventivas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se determina el grado de cumplimiento de las acciones \r\ncorrectivas y preventivas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el procedimiento escrito de autoinspecciones se indica la \r\nfrecuencia? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cada aspecto se inspecciona al menos una vez al año?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El personal que realiza las autoinspecciones está calificado y \r\ncapacitado en buenas prácticas de manufactura? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha documentado esa capacitación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utiliza alguna guía para realizar las autoinspecciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuál?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "AUDITORÍAS",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan auditorias de calidad internas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de las auditorías?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan evaluaciones de calidad a los proveedores y \r\ncontratistas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las auditorias de calidad son realizadas por personal de la \r\nmisma compañía?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las auditorías de calidad son realizadas por personal \r\nexterno?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene el laboratorio un procedimiento escrito para realizar \r\nlas auditorías de calidad? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se genera un informe que incluye:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Resultados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Conclusiones",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se da seguimiento a las acciones correctivas y preventivas \r\nde las auditorias de calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen registros de las inspecciones efectuadas por \r\nparte de la Autoridad Reguladora?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se da seguimiento a las acciones correctivas y preventivas \r\nde las inspecciones de la Autoridad Reguladora?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            FabProdFarmEsteril_A = new AUD_ContenidoTablas() {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Qué tipo de producto fábrica:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Sólidos estériles",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Líquidos estériles",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Pequeño volumen",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Gran volumen",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            FabProdFarmEsteril_Gen = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La producción de productos farmacéuticos estériles se \r\nrealiza en instalaciones especiales para minimizar el riesgo de \r\ncontaminación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El ingreso de materiales, equipo y personal, a las áreas \r\nestériles se realiza por medio de esclusas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las siguientes operaciones se llevan acabo en áreas \r\nseparadas dentro del área limpia?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a - Preparación de materiales.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b- Producción",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c- Esterilización",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuál es la metodología de esterilización de los productos \r\nfabricados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a- Producción aséptica.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b- Con esterilización final.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c- Esterilización con filtración. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El diseño de las áreas garantiza la calidad del aire en reposo \r\ny en funcionamiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cumplen las áreas de fabricación de estériles con las \r\ncaracterísticas exigidas del aire, en grados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a- A",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b- B",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c- C\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d- D",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se controla el nivel de partículas de los distintos grados en \r\nlas áreas en funcionamiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan los controles microbiológicos de las áreas en \r\nfuncionamiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se tienen establecidos límites de alerta? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se documentan y se llevan a cabo las acciones correctivas al \r\nsobrepasar estos límites?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            FabProdFarmEsteril_A2 = new AUD_ContenidoTablas() {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCCIÓN ASÉPTICA",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La producción aséptica se realiza con materiales \r\nestériles? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza en un ambiente grado A con un entorno grado \r\nB? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento para el traslado de los \r\nrecipientes parcialmente cerrados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza el traslado en un ambiente grado A con un \r\nentorno grado B? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La operación de lavado de frascos y de ampollas vacías, \r\nse efectúa en un área clase D cómo mínimo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCCIÓN CON ESTERILIZACIÓN FINAL",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las soluciones se elaboran como mínimo en un ambiente \r\nde grado C?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El llenado de preparaciones parenterales se efectúa en un \r\nárea de trabajo con flujo laminar grado A?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El llenado de preparaciones no parenterales se efectúa en \r\nun ambiente grado C? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La elaboración y llenado de productos estériles \r\nsemisólidos se realizan en un ambiente grado C?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCCIÓN CON ESTERILIZACIÓN POR \r\nFILTRACIÓN\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se realiza el llenado en una área de trabajo bajo alguna de \r\nlas siguientes condiciones:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Grado A con ambiente grado B",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Grado B con ambiente grado C",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            FabProdFarmEsteril_A3 = new AUD_ContenidoTablas() {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "PERSONAL",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cuenta con el número mínimo de personas en las áreas \r\nde producción aséptica?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan las inspecciones y controles de las áreas \r\nlimpias, demuestran que el número mínimo de personas \r\nno produce contaminación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El personal (incluido el de limpieza y mantenimiento) se \r\nsomete regularmente a capacitación en BPM de productos \r\nestériles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El personal a cargo de la producción de productos \r\nestériles cumple con los procedimientos de higiene y \r\nlimpieza?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Comunican a sus superiores cualquier detrimento de \r\nsalud?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se efectúan exámenes médicos periódicos al personal?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos para el ingreso a las áreas \r\nlimpias?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utiliza vestimenta acorde a las áreas y tareas que se realizan, según procedimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los uniformes para el área aséptica están limpios y en \r\nbuenas condiciones? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son esterilizados previo a su uso, existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza el lavado de uniformes en un área limpia y \r\nexclusiva?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el procedimiento escrito se declara la precaución para \r\nevitar adherencia de partículas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe y se cumple los procedimientos para lavado de \r\nuniformes? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "INSTALACIONES",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las instalaciones están diseñadas a fin de permitir que \r\ntodas las operaciones puedan ser observadas desde el \r\nexterior, para fines de supervisión y control?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen áreas separadas físicamente para cada una de las \r\netapas de producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las paredes, pisos, techos y curvas son superficies lisas e \r\nimpermeables, que permitan la aplicación de agentes de \r\nlimpieza y sanitizantes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de existir cielos falsos o cielos rasos, son lisos y \r\nsellados herméticamente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las tuberías, ductos y otros servicios se encuentran \r\nempotrados e instalados de manera que faciliten su \r\nlimpieza?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las tuberías fijas de servicio están identificadas indicando \r\nademás la dirección del flujo si fuera necesario?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las instalaciones eléctricas visibles están en buen estado \r\nde conservación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los vestidores están diseñados con esclusas con \r\ndiferenciales de presión? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El vestidor en su etapa final tiene en estado de reposo, el mismo grado del área a que conduce como mínimo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está ubicado el lavado de manos en la primera parte del \r\nvestidor?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Disponen las esclusas de un sistema para prevenir la \r\napertura simultánea de las puertas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué grado de aire existen en las esclusas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Grado A",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Grado B",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Grado C",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Grado D",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿De acuerdo a la clasificación anterior, existen registros de \r\ncontrol de aire?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica la efectividad de las esclusas, considerando?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Proceso de transferencia",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Calidad del aire interior y exterior",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Sanitización",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la efectividad de las esclusas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SISTEMAS DE AIRE",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen gradientes de presión entre las áreas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En las áreas de ambiente controlado (B,C,D) existe \r\nregistros del número de renovaciones horarias? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sistema de alarma detecta fallas en el suministro de \r\naire?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se dispone de manómetros para registrar diferenciales de \r\npresión?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los diferenciales de presión se registran periódicamente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las operaciones de mantenimiento y reparaciones en la \r\nmedida de lo posible, se realiza fuera del área estéril?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento que garantice la no \r\ncontaminación cuando el mantenimiento y reparaciones se realicen en el área estéril?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica la integridad y sellado de los filtros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento de revisión y cambio de los \r\nfiltros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SISTEMAS DE AGUA",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El agua para la producción de productos estériles cuenta \r\ncon los siguientes procedimientos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Manipulación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Distribución",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Almacenamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conservación",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registros que demuestren que se evita el \r\ncrecimiento microbiano?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La obtención del agua para estériles tiene como base agua \r\ntratada con mecanismos de purificación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué sistema de tratamiento se emplea para la obtención \r\nde agua para productos estériles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de realizarse sanitización química se investiga la \r\nexistencia de residuos de los agentes sanitizantes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se monitorea periódicamente el agua, para la evaluación \r\nde contaminación química, microbiológica y endotoxinas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen diagramas del sistema de tratamiento, planos de \r\nla red de distribución, puntos de muestreo y rotación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de los resultados del monitoreo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuándo se requiera almacenar agua, al ser utilizado en \r\nproducción, se garantiza la calidad de la misma?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen controles? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está construido el tanque de material sanitario?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene filtro de venteo hidrófobo absoluto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles periódicos de su integridad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las tuberías de distribución del agua hasta los puntos de \r\nuso son de material sanitario? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se aprueba por control de calidad, el agua a utilizar para \r\ncada lote de fabricación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de esta evaluación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "EQUIPO",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué métodos se usan para la esterilización de los \r\nequipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Vapor",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Calor seco",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Otros",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los hornos de secado y de vapor tienen registros de \r\ntemperatura y tiempo de esterilización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los ciclos de despirogenado están validados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El diseño de los equipos, accesorios y servicios permiten \r\nque las operaciones de mantenimiento y las reparaciones \r\nse realicen fuera de las áreas limpias?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se sanitiza y esterilizan las partes de los equipos que \r\nfueron reparados antes de ingresar a las áreas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estas esterilizaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento para dar mantenimiento a los \r\nequipos dentro del área? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los instrumentos y herramientas se sanitizan y esterilizan \r\nantes de ingresar?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se sanitiza el área, después de efectuado el \r\nmantenimiento del equipo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento de mantenimiento preventivo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe un programa de mantenimiento preventivo para:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los equipos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los sistemas de esterilización",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los sistemas de aire",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los sistemas de tratamiento y almacenamiento de agua.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SANITIZACIÓN",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento para la sanitización de las áreas \r\nlimpias?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de rotación de los sanitizantes? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estas rotaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los detergentes y sanitizantes están sometidos a control \r\nmicrobiológico así como sus diluciones? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estos controles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento para la preparación \r\nalmacenamiento, rotulación y conservación de las \r\nsoluciones sanitizantes y detergentes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa para el monitoreo del conteo \r\nmicrobiano de aire, superficies y de partículas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estos monitoreos y se incluye en la \r\norden de producción? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCCIÓN",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es el movimiento del personal controlado y metódico?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se controla la temperatura y la humedad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se reduce al mínimo la presencia de envases y materiales que puedan desprender fibras?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evita completamente estos materiales cuando se está\r\nefectuando un proceso aséptico? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento para la manipulación de los \r\ncomponentes, envases y equipos de forma que no se \r\ncontaminen después de su sanitización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se identifican adecuadamente de acuerdo a la etapa del \r\nproceso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se determina de acuerdo a un procedimiento el tiempo \r\nmáximo permitido para el intervalo de las operaciones de:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Lavado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Secado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Esterilización de componentes",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Esterilización de equipos, cuando aplique",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se define un tiempo máximo autorizado entre el inicio de \r\nla preparación de una solución y su esterilización o \r\nfiltración a través de un filtro de retención microbiana, \r\npara cada producto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se toma en cuenta su composición y el método de \r\nalmacenamiento previsto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica el límite microbiano máximo permitido de la \r\nesterilización del producto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son las soluciones especialmente las parenterales de gran \r\nvolumen, pasadas a través de un filtro de esterilización \r\ninmediatamente antes del proceso de llenado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se protegen todos los orificios de salida de presión de los \r\nrecipientes cerrados herméticamente que contienen las \r\nsoluciones acuosas?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento para el ingreso de los materiales, \r\nenvases y equipos al área limpia? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se suministran los gases no combustibles filtrados a \r\ntravés de filtros de retención microbiana?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan la comprobación de las operaciones de asepsia \r\nempleando medio de cultivo que estimulan el crecimiento \r\nmicrobiano, en las condiciones normales de trabajo y a \r\nintervalos regulares?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan sobre un mínimo de 3,000 unidades o acorde a \r\nla capacidad del equipo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se considera no conforme el ensayo que obtiene una cifra \r\nmayor al 0.1% de las unidades contaminadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estos ensayos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investigan las causas de cualquier contaminación \r\ndetectada? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estas investigaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de las acciones tomadas en estos casos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTERILIZACIÓN",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué método de esterilización se emplea?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Calor húmedo o seco",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Óxido de etileno",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Filtración",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Radiación ionizante",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Otros",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se validan y documentan los procesos de esterilización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se demuestra que el proceso de esterilización es eficaz \r\npara alcanzar los niveles de esterilización deseados, según \r\nprocedimiento escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica a intervalos programados, como mínimo una \r\nvez al año la validez del proceso de esterilización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica cada vez que se han realizado modificaciones significativas al equipo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuándo se utilizan indicadores biológicos, que \r\nprecauciones se adoptan para evitar la transferencia de \r\ncontaminación microbiana a partir de los mismos?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se almacenan y utilizan de acuerdo a las instrucciones y \r\nprecauciones del fabricante?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica su calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para evitar la confusión \r\nde los productos que han sido esterilizados de aquellos que \r\nno lo han sido?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de cada ciclo de esterilización? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTERILIZACIÓN POR CALOR",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registra cada ciclo de esterilización mediante equipo \r\ncalificado?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el momento de validación se determinó el punto más\r\nfrío de la carga o de la cámara cargada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son los controles realizados parte del registro del lote? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se determina el tiempo necesario para que la carga \r\nalcance la temperatura requerida, antes de iniciar el \r\ncómputo del tiempo de esterilización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTERILIZACIÓN POR CALOR HÚMEDO",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utiliza la esterilización por calor húmedo únicamente \r\npara esterilizar materiales que puedan humedecerse y para \r\nsoluciones acuosas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registra la temperatura y la presión durante todo el \r\nciclo de esterilización? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se comprueba la ausencia de fugas en la cámara cuando \r\nforma parte del ciclo una fase de vacío? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El material de empaque impide la contaminación después de la esterilización?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El vapor que se utiliza en la esterilización tiene la calidad \r\nnecesaria y no contiene aditivos en un grado que pudiera \r\nprovocar la contaminación del producto o del equipo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTERILIZACIÓN POR CALOR SECO",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El aire suministrado a la cámara de esterilización pasa a \r\ntravés de filtro HEPA?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El aire suministrado a la cámara de esterilización circula \r\nmanteniéndose con presión positiva?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuándo el objetivo es eliminar los pirógenos se utilizan \r\ncomo parte de la validación pruebas con cargas de \r\nendotoxinas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTERILIZACIÓN POR RADIACIÓN",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utiliza la esterilización por radiación principalmente \r\npara esterilizar materiales y productos sensibles al calor?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está documentada la investigación de los efectos \r\nnocivos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mide la dosis de radiación empleando dosímetros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Indican una medida cuantitativa de la dosis recibida por \r\nel producto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuándo se utilizan dosímetros plásticos se utilizan dentro \r\ndel tiempo límite de su calibración?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifican las absorbancias poco después de su \r\nexposición a la radiación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utilizan simultáneamente indicadores biológicos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Toda la información obtenida forma parte del registro del \r\nlote?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se toman en cuenta los efectos de las variaciones en la \r\ndensidad de los envases al realizar la validación del \r\nprocedimiento de radiación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los procedimientos de manipulación de materiales evitan la confusión entre materiales irradiados y no irradiados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utilizan en cada paquete discos de color sensibles a la \r\nradiación para distinguir entre envases que se han sometido \r\na la radiación y los que no?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se determina previamente la dosis de radiación total que \r\ndebe administrarse en un periodo de tiempo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTERILIZACIÓN CON OXIDO DE ETILENO",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En la validación del proceso se demuestra que no existe \r\nningún efecto nocivo sobre el producto? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se asegura que las condiciones y el tiempo son los \r\nrequeridos para reducir el óxido de etileno a niveles \r\npermitidos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se toman precauciones para evitar la presencia de \r\nmicroorganismos, están descritos en el procedimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se establece antes de la exposición al gas, un equilibrio \r\nentre los materiales, la humedad y la temperatura y tiempo \r\nrequerido por el proceso, según lo declare el \r\nprocedimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se controla cada ciclo de esterilización con indicadores \r\nbiológicos apropiados? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utilizan el número de unidades de indicadores de \r\nacuerdo al tamaño de la carga?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utilizan el número de unidades de indicadores de \r\nacuerdo al tamaño de la carga?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Esta información se incluye en los registros del lote?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En cada ciclo de esterilización se llevan los siguientes \r\nregistros:\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tiempo empleado en completar el ciclo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Presión",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Temperatura",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Humedad",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Concentración del gas",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cantidad total del gas utilizada",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "FILTRACIÓN DE PRODUCTOS QUE NO PUEDEN \r\nESTERILIZARSE EN SU ENVASE FINAL",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utiliza un filtro bacteriológico de 0.22 micras o menos \r\npara los productos que no se esterilizan en su envase final?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Estádocumentada la esterilización de los recipientes? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Para productos no parenterales estériles, cuando la \r\nsolución no contiene preservantes el filtro bacteriológico a \r\nutilizar es el de 0.22 de micras?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Para productos no parenterales estériles, cuando la \r\nsolución contiene preservantes el filtro bacteriológico a \r\nutilizar es el de 0.45 de micras o menos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza una pre-filtración utilizando filtros de \r\nretención microbiana? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La segunda filtración se realiza inmediatamente antes del \r\nllenado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe el procedimiento de filtración, en este se incluye \r\nla especificaciones del filtro?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se comprueba la integridad del filtro antes y durante o \r\ndespués de su utilización con los siguientes métodos \r\naprobados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Punto de burbuja",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Flujo de difusión",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Mantenimiento de la presión.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se determina el tiempo empleado en filtrar un volumen \r\nconocido de solución a granel?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Estos valores se determinan durante la validación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investiga cualquier diferencia importante que se de en \r\nestos parámetros durante la fabricación normal?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utiliza un filtro por día de trabajo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso contrario existe un procedimiento escrito y \r\nvalidado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se demuestra que el filtro no afecta al producto \r\nreteniendo componentes de éste, ni le añade sustancias?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ACABADO DE PRODUCTOS ESTÉRILES",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el cierre y sellado de los envases, se verifica la \r\nintegridad? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos y registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se inspeccionan los productos parenterales llenos en un \r\n100%?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si la inspección es visual se efectúa bajo condiciones \r\ncontroladas de iluminación y fondo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está documentado el periodo de descanso de los \r\ninspectores?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si se utilizan otros métodos de inspección, están \r\nvalidados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se chequean los aparatos utilizados a intervalos \r\nregulares?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran los resultados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se someten a los operadores a exámenes de la vista \r\nregularmente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CONTROL DE CALIDAD",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dentro del conjunto de controles con los que se garantiza \r\nla calidad del producto, se contempla siempre la prueba de \r\nesterilidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se incluyen en los controles, los registros de las \r\ncondiciones ambientales en el proceso de fabricación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las muestras que se toman para el control de calidad \r\nestán de acuerdo a un sistema de muestreo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuándo una prueba de control de calidad no cumpla con \r\nlas especificaciones de calidad, se realizan las \r\ninvestigaciones correspondientes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan las acciones correctivas o preventivas del \r\ncaso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la investigación y de las acciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza el monitoreo de lo siguiente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Del agua",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "De los productos intermedios",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "De los productos terminados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza por parte del control de calidad la prueba de \r\nendotoxinas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los métodos no oficiales utilizados por control de calidad \r\nestán validados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            Lactamicos = new AUD_ContenidoTablas() {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "PERSONAL",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de rotación del personal, éste pasa por un \r\nperiodo de cuarentena no menor de siete días, o se cuenta \r\ncon un procedimiento validado de monitoreo para \r\njustificar la disminución de este periodo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Al personal se le realiza la prueba de sensibilidad al \r\nmenos una vez al año?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Al personal de primer ingreso se le realiza la prueba de \r\nsensibilidad? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza esta prueba a otras personas autorizadas antes \r\nde ingresar a las instalaciones? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza la capacitación específica para el personal de \r\nesta área? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se tienen registros de la evaluación práctica de la \r\ncapacitación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento que garantice la disminución del \r\nriesgo de contaminación al personal que labora en estas \r\náreas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cubre el uniforme la totalidad del cuerpo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es de uso exclusivo para este propósito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento escrito para descontaminar o \r\ndesactivar el uniforme antes de lavarse o desecharse?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Utilizan los operarios equipo de protección durante todas \r\nlas etapas del proceso productivo donde hay contacto \r\ndirecto con el principio activo?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "INSTALACIONES",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El acceso a las áreas de producción es sólo del personal y \r\npara personas autorizadas, previa capacitación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la capacitación previa? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para el acceso a las áreas \r\nde trabajo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen exclusas independientes para el ingreso de \r\noperarios y materiales para todas las áreas de producción ( \r\na excepción de empaque secundario)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan las esclusas con diferencial de presión que eviten \r\nla salida de contaminación a las áreas adyacentes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cuenta con un procedimiento escrito para la \r\ndesactivación y sanitización de las áreas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza análisis de trazas después de la desactivación y \r\nsanitización de las áreas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el laboratorio fabricante con un sistema para el \r\ntratamiento de aguas residuales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cumple con los parámetros ambientales establecidos en la \r\nlegislación ambiental?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SISTEMA DE AIRE",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica que el aire recirculado carece de \r\ncontaminación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica que el aire recirculado carece de \r\ncontaminación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Utiliza filtros HEPA terminal?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen dispositivos para medir los diferenciales de \r\npresión?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para la desactivación, \r\nlimpieza de ductos, destrucción de residuos y filtros usados \r\nen las instalaciones?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros del cumplimiento? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "EQUIPOS",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son los equipos exclusivos para éstas áreas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta con un procedimiento escrito para la \r\ndesactivación y sanitización de los equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza análisis de trazas después de la desactivación y \r\nsanitización de los equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza el mantenimiento preventivo de los equipos de \r\nacuerdo a un programa y procedimiento escrito, dentro de \r\nlas instalaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CONTROL DE CALIDAD",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para desactivar el \r\nrecipiente en el que se traslada la muestra a otras \r\ninstalaciones de la empresa para la verificación de la \r\ncalidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            //////////
            ProdCitostatico = new AUD_ContenidoTablas() {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "PERSONAL",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el personal que elabora en citostáticos y \r\nhormonales, con la indumentaria siguiente? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Uniformes protectores desechables confeccionados con \r\nmateriales de baja permeabilidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El uniforme: ¿es de manga larga, con puños y tobillos \r\najustados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se usan guantes desechables y libres de talco?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Poseen mascarillas o respirador de vapores con filtros \r\nHEPA?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con lentes protectores?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con cofia y escafandra?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza la capacitación específica para el personal de \r\nesta área? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se tienen registros de la evaluación práctica de la \r\ncapacitación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento que garantice la disminución del riesgo de contaminación al personal que labora en estas \r\náreas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se controla los niveles hormonales y citostáticos a todo \r\nel personal que labora en éstas áreas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos y registro de estos \r\nanálisis? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El acceso a las áreas de producción es sólo del personal y \r\npara personas autorizadas, previa capacitación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la capacitación previa?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para el acceso a las áreas \r\nde trabajo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "INSTALACIONES",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son independientes las esclusas para el ingreso de \r\noperarios y materiales, a las áreas de producción? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan las esclusas con diferenciales de presión que \r\nimpidan la salida de contaminantes a las áreas adyacentes? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento escrito para la desactivación y \r\nsanitización de las áreas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza análisis de trazas después de la desactivación y \r\nsanitización de las áreas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el laboratorio fabricante con un sistema para el \r\ntratamiento de aguas residuales?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SISTEMA DE AIRE",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica que el aire recirculado carece de \r\ncontaminación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros que garanticen la no contaminación del \r\nambiente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Utiliza filtros HEPA terminal?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen dispositivos para medir los diferenciales de \r\npresión?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de su cumplimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para la desactivación, \r\nlimpieza de ductos, destrucción de residuos y filtros usados \r\nen las instalaciones?\r\n",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "EQUIPOS",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son los equipos exclusivos para estas áreas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuenta con un procedimiento escrito para la desactivación \r\ny sanitización de los equipos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan análisis de trazas después de la desactivación \r\ny sanitización de los equipos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registros de los mismos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa y procedimiento escrito para el \r\nmantenimiento preventivo de los equipos que se realiza \r\ndentro de las instalaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento que contemple la inactivación e \r\nincineración de los residuos y materiales de limpieza? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento escrito que contemple la \r\ninactivación e incineración de la indumentaria protectora \r\ndesechable?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CONTROL DE CALIDAD",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para desactivar el \r\nrecipiente en el que se traslada la muestra a otras \r\ninstalaciones de la empresa para la verificación de la \r\ncalidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };

        }
    }
}
