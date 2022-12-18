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
                            Capitulo="6.1.1",
                            Articulo="",
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
                        Titulo = "¿Se cuenta con los contratos correspondientes de producción, envase, empaque y control analítico que incluyan aspectos de Buenas Prácticas de Manufactura? ",
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
                        Titulo = "Área de líquidos no estériles",
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
                        Titulo = "¿Tiene el laboratorio fabricante organigramas generales y específicos de cada uno de los departamentos, se encuentran actualizados y aprobados? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe independencia de responsabilidades entre producción y control de la calidad?",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Titulo = "Cumple el responsable de la Dirección de Producción con las siguientes responsabilidades:",
                        Criterio = "MAYOR",
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
                        Titulo = "Cumplen los responsables de producción y control de calidad con las responsabilidades compartidas, las cuales son las siguientes:",
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
                        Titulo = "Utiliza diariamente el personal dedicado a la producción, que este en contacto directo con el producto, uniforme completo:",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="7.5.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "De manga larga",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Sin bolsas en la parte superior",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cierre oculto",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Gorro que cubra la totalidad del cabello,",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Utilizar maquillaje, joyas, relojes, teléfonos celulares, radio localizadores, u otro elemento ajeno al área",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Llevar barba o bigote al descubierto durante la jornada de trabajo en los procesos de dispensado, producción y subdivisión",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Salir fuera del áreade producción con el uniforme de trabajo",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Realiza el laboratorio controles microbiológicos de las manos del personal de acuerdo a un programa y procedimiento establecido?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="7.5.8",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿De acuerdo a los resultados se realizan las medidas correctivas? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con registros?",
                        Criterio = "MAYOR",
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
                        Criterio = "CRITICO",
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
                        Titulo = "¿Las áreas de producción, almacenamiento y control de calidad no se utilizan como áreas de paso?",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="8.1.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los equipos y materiales están ubicados de forma que eviten el riesgo de confusión, contaminación cruzada y omisión entre los distintos productos y sus componentes en cualquiera de las operaciones de producción, control y almacenamiento?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="8.1.10",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son las áreas de almacenamiento, producción y control de calidadexclusivas para el uso previsto y se mantienen libres de objetos y materiales extraños al proceso?",
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
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de drenajes para evitar la contracorriente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.1.14",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta con reposaderas o tapas de tipo sanitario?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
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
                        Criterio = "CRITICO",
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
                        Titulo = "¿Las materias primas y productos que requieren condiciones especiales de enfriamiento, se encuentran en cámara fría?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Titulo = "¿El muestreo de materia prima se efectúa en área separada o en el área de pesaje o dispensado?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="8.2.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El área de muestreo cumple con las siguientes características:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Las paredes, pisos y techos son lisos y con curvas sanitarias.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Existen controles de limpieza, temperatura y humedad dentro del área de muestreo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) La iluminación es suficiente para el desempeño del proceso",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) El sistema de aire es independiente. ",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Titulo = "¿Se utilizan materias primas psicotrópicas o estupefacientes?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="8.2.10",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen áreas separadas, bajo llave, de acceso restringido e identificadas para almacenar materias primas y productos psicotrópicos y estupefacientes?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área para almacenamiento de productos inflamables y explosivos alejada de las otras instalaciones, es ventilada y cuenta con medidas de seguridad contra incendios o explosiones, según la legislación nacional?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="8.2.11",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área separada y de acceso restringido para almacenar material impreso (etiquetas, estuches, insertos y envases impresos)?",
                        Criterio = "CRITICO",
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
            ////////
            AreaDispMatPrima = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área separada e identificada, para llevar a cabo las operaciones de dispensación? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="8.3.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene paredes, pisos, techos lisos y curvas sanitarias?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta con un sistema de inyección y extracción de aire que garanticen la no contaminación cruzada y seguridad del operario?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mide la presión diferencial periódicamente?",
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
                        Titulo = "¿Dispone de vestidor propio en caso de no estar ubicada en el área productiva? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de un sector fuera del área para el lavado de utensilios usados en las pesadas y medidas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registros de temperatura y humedad, cuando se requiera?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El operario dispone de uniforme completo y elementos de protección?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito de limpieza del área?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se toman las precauciones necesarias cuando se trabaja con materias primas fotosensibles?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cuenta con sistemas para la extracción localizada de polvos, cuando aplique?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El soporte donde se colocan las balanzas y otros equipos sensibles es capaz de contrarrestar las vibraciones que afectan su buen funcionamiento?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="8.3.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está el área equipada con balanzas y material volumétrico calibrados de acuerdo al rango de medida de los materiales a dispensar?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="8.3.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los equipos utilizados están dentro de un programa de calibración de acuerdo a su uso?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son verificados con frecuencia definida?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área adyacente al área de dispensado, que se encuentre delimitada e identificada en donde se coloquen las materias primas que serán pesadas o medidas y las materias primas dispensadas que se utilizarán en la producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.3.4",
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
                        Titulo = "¿El laboratorio cuenta con áreas de tamaño, diseño y servicios (aire comprimido, agua, luz, ventilación, etc.) para efectuar los procesos de producción que corresponden?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="8.4.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las áreas de producción (elaboración): ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="8.4.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Están identificadas y separadas para la producción de sólidos, líquidos y semisólidos?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen paredes, pisos y techos lisos con curvas sanitarias de tal forma que permitan la fácil limpieza y sanitización?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Las tuberías y puntos de ventilación son de material que permitan su fácil limpieza y están correctamente ubicados?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Están las tomas de gases y fluidos identificados y no son intercambiables?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Las ventanas y las lámparas con difusores lisos están empotrados?",
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
                        Titulo = "g) ¿Están libres de materiales y equipo que no estén involucrados en el proceso?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) ¿Cuentan con equipo de control de aire, que permita el manejo de los diferenciales de presión de acuerdo a los requerimientos de cada área?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) ¿Cuentan con registros de temperatura y humedad, cuando se requiera?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) ¿Las condiciones de temperatura y humedad relativa se ajusta a los requerimientos de los productos que en ella se realizan?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) ¿Se toman las precauciones necesarias cuando se trabaja con materias primas fotosensibles?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) ¿Tienen drenajes que no permiten la contracorriente y tienen tapa sanitaria?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las áreas de empaque primario:",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="8.4.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Están identificadas y separadas para el empaque primario de sólidos, líquidos y semisólidos?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen paredes, pisos y techos lisos con curvas sanitarias de tal forma que permitan la fácil limpieza y sanitización?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Las tuberías y puntos de ventilación son de material que permitan su fácil limpieza y están correctamente ubicados",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Están las tomas de gases y fluidos identificados?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Las ventanas y las lámparas con difusores lisos están empotrados?",
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
                        Titulo = "g) ¿Están libres de materiales y equipo que no estén involucrados en el proceso?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) ¿Cuentan con equipo de control de aire, que permita el manejo de los diferenciales de presión de acuerdo a los requerimientos de cada área?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) ¿Cuentan con registros de temperatura y humedad, cuando se requiera?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) ¿Tienen drenajes que no permiten la contracorriente y tienen tapa sanitaria?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) ¿Se toman las precauciones necesarias cuando se trabaja con productos fotosensibles?",
                        Criterio = "",
                        Capitulo="¿Existe un área exclusiva para el lavado de equipos móviles, recipientes y utensilios? ",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área exclusiva para el lavado de equipos móviles, recipientes y utensilios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.4.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las instalaciones tienen curvas sanitarias y servicios para el trabajo que allí se ejecuta? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se encuentra en buenas condiciones de orden y limpieza?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El piso de esta área cuenta con desnivel hacia el desagüe, para evitar que se acumule el agua? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área separada, identificada, limpia y ordenada para colocar equipo limpio que no se esté utilizando? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.4.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Tienen paredes, pisos y techos lisos que permitan la fácil limpieza y sanitización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿No son utilizadas como áreas de paso?",
                        Criterio = "MAYOR",
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
                        Titulo = "El área de empaque:",
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
                        Criterio = "CRITICO",
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
                        Titulo = "¿Tiene una campana de extracción para los vapores nocivos?",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Dispone de áreas de almacenamiento para las muestras, reactivos, archivos y patrones referencia, de acuerdo a las especificaciones correspondientes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Según las operaciones que se realizan se dispone de las siguientes áreas:",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fisicoquímicas",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Instrumental",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Microbiología",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Lavado de cristalería y utensilios",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe equipo de seguridad como:",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ducha",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Lava ojos",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Extintores",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Elementos de protección",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El área está diseñada para proteger el equipo e instrumentos sensibles del efecto de las vibraciones, interferencias eléctricas, humedad y temperatura?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.6.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El área de microbiología es exclusiva para el proceso de la siembra de productos estériles y no estériles que lo requieran?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="8.6.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área de microbiología separada de las otras áreas, para la siembra de productos estériles?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El área de microbiología para productos estériles cuenta con:",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Paredes, techos y pisos lisos de fácil limpieza y curvas sanitarias.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Un sistema de aire independiente con filtros HEPA ubicados a nivel del techo o campana de flujo laminar.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Lámparas con difusor liso.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Mesa de trabajo lisa de preferencia de acero inoxidable u otro material que garantice la no contaminación.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Ventanas con vidrio fijo al ras de la pared.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Vestidor exclusivo con filtros HEPA o manejo de diferenciales de presión.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica periódicamente el estado de los filtros del flujo laminar?",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los vestidores están comunicados directamente con las áreas de producción? ",
                        Criterio = "CRITICO",
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
                        Titulo = "Existen registros de la ejecución de la limpieza y sanitización",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="8.7.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Poseen procedimientos escritos para realizar el lavado y secado por separado de uniformes por tipo de área no estéril, estériles y mantenimiento?",
                        Criterio = "CRITICO",
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
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área destinada para investigación y desarrollo de sus productos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="8.7.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El área tiene las siguientes condiciones:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Paredes lisas que faciliten su limpieza?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Paredes lisas que faciliten su limpieza?",
                        Criterio = "MAYOR",
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
                        Criterio = "CRITICO",
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
                        Titulo = "¿Se verifica en el equipo la integridad de los tamices y filtros? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen secadores de lecho estático?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen secadores de lecho fluido?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El proceso de limpieza del juego de mangas garantiza la no contaminación cruzada?",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Se verifica la integridad, medidas e identidad de los punzones? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registros?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen detectores de metales en las tableteadoras?",
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
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se establece un período de vigencia de la limpieza de los equipos y utensilios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todas las mangueras, tubos y tuberías empleadas en la transferencia de fluidos deben almacenarse identificadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es validada su limpieza?",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Si el equipo es muy pesado, está diseñado para que se pueda ejecutar su limpieza, sanitización o esterilización en el área de producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se identifican todos los equipos limpios con una etiqueta que indique la siguiente información:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="9.1.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre del equipo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha cuando fue realizada la limpieza.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre y número de lote del último producto fabricado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre y número de lote del producto a fabricar, cuando aplique",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre o firma del operario que realizó la limpieza y de quién la verificó",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son las superficies de los equipos que tienen contacto directo con las materias primas, productos en proceso, de acero inoxidable de acuerdo a su uso u otro material que no sea reactivo, aditivo y adsorbente?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="9.1.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evita el contacto entre el producto y las sustancias lubricantes requeridas para el buen funcionamiento del equipo?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está libre de impurezas el aire inyectado en los equipos de recubrimiento?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los filtros empleados en los equipos son descartables?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si los filtros no son descartables, se les da el debido mantenimiento?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Los soportes de los equipos que lo requieran son de acero inoxidable u otro material que no contamine?",
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
                        Titulo = "¿Se realiza calibración de los instrumentos de medición y dispositivos de registro o cualquier otro que lo requiera?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="9.2.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La calibración se realiza a intervalos convenientes y establecidos de acuerdo con un programa escrito que contenga como mínimo frecuencias, límites de exactitud, precisión y previsiones para acciones preventivas y correctivas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen registros escritos de las inspecciones? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen registros escritos de las verificaciones?",
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
                        Titulo = "¿Los instrumentos están correctamente rotulados indicando la fecha de calibración?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza la calibración de cada equipo y dispositivos usando patrones de referencia certificados?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="9.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SISTEMA DE AGUA",
                        Criterio = "",
                        Capitulo="9.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe suministro de agua potable que le permita satisfacer sus necesidades?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="9.3.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El agua que abastece el sistema de tratamiento de agua es clorada, existe un sistema para retirar el cloro residual?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Posee un sistema de tratamiento de agua que le permita obtenerla cumpliendo con las especificaciones de los libros oficiales para la producción?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="9.3.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuál es el sistema utilizado para obtener agua?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resinas de intercambio iónico.",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Osmosis inversa.",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Destilación",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Otros, especificar cuáles?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene diagrama del sistema de tratamiento, planos de la red de distribución del agua y sus puntos de muestreo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sistema de agua está construido en material de tipo sanitario?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La distribución del agua, se hace por tuberías y válvulas de material sanitario?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sistema de producción de agua es no continuo? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sistema de producción de agua es continuo?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe procedimiento escrito para la regeneración de las resinas y la frecuencia de la misma?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Son monitoreados regularmente los sistemas de suministro, tratamiento de agua y el agua tratada? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="9.3.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen registros del monitoreo y de las acciones realizadas?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe un procedimiento escrito de muestreo del agua?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay rotación de los puntos de muestreo del sistema de tratamiento de agua y de su red de distribución, cuando aplique?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se proporciona mantenimiento planificado al sistema de tratamiento de agua y su red de distribución?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="9.3.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registros?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos escritos para operar y sanitizar el sistema de tratamiento de agua, su red de distribución y puntos de muestreo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuenta con un programa de sanitización del sistema de tratamiento de agua y su red de distribución?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registro de su ejecución? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se investiga la existencia de residuos de los agentes químicos utilizados en la sanitización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay registros?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los filtros utilizados en el sistema de distribución:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se sanitizan?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registros del reemplazo de los filtros? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Para la producción de los productos y el enjuague final en la limpieza de los recipientes y equipos, se utiliza agua que cumpla las especificaciones de los libros oficiales?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="9.3.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cumplen los tanques o cisternas para almacenamiento de agua (potable y agua calidad farmacéutica) con condiciones que aseguren la calidad del agua almacenada?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="9.3.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos escritos para llevar a cabo la limpieza, sanitización y control de los tanques o cisternas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se registra la frecuencia de las acciones llevadas a cabo (rutinarias y correctivas) y puntos de muestreo de:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La ejecución de la limpieza? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La sanitización? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuál es el tiempo de almacenamiento del agua de cálidafarmacéutica?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de que se almacene por más de 24 horas, esta permanece en recirculación?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se realizan controles fisicoquímicos y microbiológicos del agua potable y calidad farmacéutica indicando la frecuencia? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="9.3.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se realizan controles fisicoquímicos del agua de calidad farmacéutica de acuerdo a farmacopeas oficiales o según métodos alternativos validados, de cada lote o día de producción?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles microbiológicos en los días de uso del agua en la producción, o con una frecuencia establecida debidamente validada? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cada vez que se exceda el límite de alerta en los controles microbiológicos, se lleva a cabo una investigación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registro de dicha investigación y medidas correctivas? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SISTEMA DE AIRE",
                        Criterio = "",
                        Capitulo="9.4",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe un sistema de tratamiento de aire que evite el riesgo de la contaminación de los productos y las personas? ",
                        Criterio = "",
                        Capitulo="",
                        Articulo="9.4.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene un sistema de aire central? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene un sistema de aire individual? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El sistema de aire es:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Abierto",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cerrado",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sistema de aire está ubicado de manera que facilite su limpieza y mantenimiento? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen prefiltros, filtros y todo equipo necesario para garantizar el grado de aire que se requiere en las diferentes áreas de producción?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="9.4.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Están convenientemente ubicadas las rejillas de inyección y extracción de aire?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se manejan diferenciales de presión?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se tienen instrumentos de medición para verificar los diferenciales de presión?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para el mantenimiento y calibración de estos instrumentos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registros del mantenimiento y calibración de estos instrumentos?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se llevan registros de temperatura, humedad relativa y diferenciales de presión en las áreas de acuerdo a los productos que se fabriquen?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tiene un sistema de inyección y extracción de aire en las áreas de:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Dispensado? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Producción:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Estériles (ver Anexo A).",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "No estériles",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Empaque primario.",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Almacenes, cuando aplique.",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Laboratorios de control",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Pasillos de circulación, cuando aplique.",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para el sistema de aire que abarquen las instrucciones y precauciones para su manejo?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="9.4.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe un programa de mantenimiento preventivo que abarque los controles periódicos del sistema de aire?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="9.4.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registros?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se llevan registros escritos de los cambios de los filtros y prefiltros?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las operaciones de mantenimiento y reparación se llevan a cabo tomando en cuenta que no presenten riesgo a la calidad de los productos?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se llevan registros escritos del mantenimiento preventivo y correctivo de los equipos del sistema de aire y donde se realizó?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="9.4.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe procedimiento escrito para la destrucción de los residuos y filtros que se utilizaron en el sistema de inyección y extracción de aire?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="9.4.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay registros de estas destrucciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe programa y procedimiento escrito para realizar los controles microbiológicos ambientales que garanticen la calidad del aire?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="9.4.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se llevan los registros respectivos?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de que estos controles microbiológicos se salgan de los límites específicos, se investiga y se toman medidas correctivas?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Luego de realizar la medida correctiva se verifican nuevamente los controles microbiológicos en forma inmediata?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de todo lo que se efectuó y de los nuevos controles microbiológicos?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
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
                        Titulo = "Almacenamiento de materiales y productos",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="10.0.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de calidad emite la aprobación o rechazo de los materiales y productos? ",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Son retenidas las muestras de materia prima, por lo menos durante un año después de la fecha de expiración del último  lote del producto fabricado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si una entrega de material está compuesta por diferentes lotes, se considera cada lote por separado para efectos de muestreo, análisis y aprobación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.1.9",
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
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Número de ingreso.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Situación del material.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Nombre del proveedor.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Fecha de vencimiento, cuando aplique.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Número de análisis/ lote interno.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El rótulo está adherido al cuerpo del contenedor y no a su parte removible?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "MATERIAS PRIMAS",
                        Criterio = "",
                        Capitulo="10.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los recipientes o contenedores de materias primas son inspeccionados visualmente, para verificar su estado físico en el momento de su ingreso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.2.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El sistema de cierre de estos recipientes o contenedores garantiza su integridad e inviolabilidad? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cada lote de materia prima está identificado con una etiqueta que contenga lo siguiente: ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre de la materia prima.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Código interno",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre del fabricante",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre del proveedor",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cantidad del material ingresado",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Código o número de lote del fabricante",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha de expiración",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Condiciones de almacenamiento",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Advertencia y precauciones, cuando aplique",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha de análisis.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha de re-análisis, cuando aplique",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Estado o situación (cuarentena, muestreado, aprobado o rechazado).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Observaciones",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si utiliza un sistema de identificación electrónica debe contener la información anterior?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si una materia prima es removida del envase original y trasvasado a otro envase, el nuevo recipiente cumple con los requisitos de identidad establecidos en el anterior?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="10.2.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El recipiente utilizado para el trasvasado ha sido usado para el mismo tipo de materia prima o es otro recipiente que garantice su integridad?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se deja registro de la sustancia contenida anteriormente en el envase?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es toda la materia prima muestreada, examinada y analizada de acuerdo a procedimientos escritos?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="10.2.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Es toda la materia prima aprobada de acuerdo a sus especificaciones?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "De no cumplir con especificaciones se rechaza?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La materia prima que ha estado expuesta a condiciones extremas (aire, temperatura, humedad o cualquier otra condición que pudiera afectarla negativamente), es separada e identificada según procedimiento escrito?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="10.2.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de todo lo anterior?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utilizan únicamente las materias primas aprobadas? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="10.2.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las materias primas son fraccionadas por personal designado para tal fin? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe procedimiento escrito que garantice que se pesan o midan de forma precisa y exacta? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los recipientes están limpios e identificados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Son identificadas y agrupadas para evitar riesgo de confusión?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las materias primas de un lote, ya pesadas o medidas ¿son separadas físicamente de las de otro lote ya pesado?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Si las órdenes ya fraccionadas no son dispensadas a planta en forma inmediata, ¿cuenta con un área de acceso restringido y bajo llave o sistema electrónico que evite confusiones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La materia prima después de ser pesada o medida es etiquetada inmediatamente a fin de evitar confusiones?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="10.2.8",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En esa etiqueta, consta: ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.2.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader =true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre de la materia prima",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Código o número de lote o número de ingreso.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Nombre del producto a fabricar.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Código de lote del producto a fabricar",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Contenido neto (sistema internacional de unidades de medida, SI).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Fecha de dispensado.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Nombre y firma de la persona que dispenso",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Nombre y firma de la persona que revisó",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son identificadas y agrupadas para evitar riesgo de confusión? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="10.2.10",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las materias primas de un lote, ya pesadas o medidas ¿son separadas físicamente de las de otro lote ya pesado?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Si las órdenes ya fraccionadas no son dispensadas a planta en forma inmediata, ¿cuenta con un área de acceso restringido y bajo llave o sistema electrónico que evite confusiones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los recipientes que contienen una materia prima ya pesada ¿son transferidos con seguridad al área de producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de área para la limpieza y sanitización de los contenedores con materias primas antes de fraccionar?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los contenedores de las materias primas ya pesadas o medidas ¿están bien cerrados e identificados?",
                        Criterio = "MAYOR",
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
                        Titulo = "¿Los envases y cierres son hechos de material que no sea reactivo, aditivo y adsorbente al producto?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="10.3.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los requerimientos de los envases y cierres están sustentados en los estudios de formulación y pruebas de estabilidad?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los envases y cierres son adquiridos de proveedores aprobados?",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Se manipulan y almacenan los productos intermedios y a granel de tal manera que se evite cualquier contaminación o ponga en riesgo la calidad de los productos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="10.4.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área de almacenamiento de productos intermedios y a granel?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En dónde están ubicados?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se identifican todos los productos intermedios o a granel?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Titulo = "MATERIALES Y PRODUCTOS RECHAZADOS",
                        Criterio = "",
                        Capitulo="10.6",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Criterio = "MAYOR",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Material de acondicionamiento.",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Productos intermedios o granel.",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Producto terminado",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="11.2.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está la fórmula maestra actualizada y autorizada?",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="11.2.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si se hace cambio de la fórmula cuali-cuantitativa, estos cambios son comunicados y aprobados por la Autoridad Reguladora competente?",
                        Criterio = "CRITICO",
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
                        Titulo = "l) De ser necesario un ajuste de concentración del principio activo, la modificación está firmada por el responsable.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se adjuntan las etiquetas de fraccionamiento de las materias primas? ",
                        Criterio = "MAYOR",
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
                        Titulo = "f) Los resultados de los análisis del proceso. ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) El personal responsable realiza la verificación de peso de las materias primas empleadas en la elaboración de cada lote.",
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
                        Articulo="11.2.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Cantidad del producto a envasar o empacar.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="11.2.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Fecha de inicio y finalización de las operaciones de acondicionamiento.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="11.2.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fecha de expiración para cada lote y vida útil del producto",
                        Criterio = "",
                        Capitulo="",
                        Articulo="11.2.9",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos y registros escritos correspondientes a las actividades realizadas sobre:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="11.3.512.1.1",
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
            Produccion = new AUD_ContenidoTablas()
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
                        Criterio = "MAYOR",
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
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La operación de envasado se realiza en línea?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso que no se realiza en línea existen procedimientos escritos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los productos líquidos o semisólidos se envasan en su totalidad en su presentación final?",
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
                        Titulo = "¿Los reprocesos se efectúan solamente en casos en donde lacalidad del producto no es afectada y reúne todas las especificaciones del mismo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="12.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evalúa el reproceso de conformidad con un procedimiento definido y autorizado, una vez realizada la evaluación de los riesgos existentes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registra y se le asigna un nuevo número al lote reprocesado?",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="12.1.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evita la mezcla de productos diferentes o lotes distintos del mismo producto mediante separación física entre las líneas de envasado?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el área de empaque secundario existen líneas identificadas, definidas y separadas para cada producto que se está empacando?",
                        Criterio = "CRITICO",
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
                        Titulo = "¿La toma de la muestra de los productos intermedios y productos terminados se basa en criterios estadísticos que contemplan la aleatoriedad y representatividad?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="12.1.8",
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
                        Titulo = "¿Esta se realiza en el área a de producción?",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="12.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Para evitar la contaminación cruzada se tiene: ",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Los frascos son transferidos al área de llenado protegidos de la contaminación ambiental?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La transferencia de semielaborados o graneles entre una etapa y otra, se realiza de tal forma que evite la contaminación de los mismos?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica la eficacia de las medidas destinadas a prevenir la contaminación cruzada?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para evitar la contaminación con microorganismos patógenos y mantener los recuentos microbianos dentro de especificaciones de los productos no estériles?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="12.2.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cumplen y están validados? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CONTROLES EN PROCESO ",
                        Criterio = "",
                        Capitulo="12.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Antes de iniciar las operaciones de producción, ¿se realiza el despeje del área, se verifica que los equipos estén limpios y libres de materiales, productos y documentos de una operación anterior y cualquier otro material extraño al proceso de producción?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="12.3.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles durante el proceso en las distintas etapas de producción? ",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles en línea durante el envasado y empaque?",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las unidades descartadas por sistemas automáticos, en caso de reintegrarse a la línea son previamente inspeccionadas y autorizadas por personal con responsabilidad asignada (cuando aplique)?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa y procedimiento escrito para realizar los controles microbiológicos de superficie?",
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
                        Criterio = "MAYOR",
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
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan los controles ambientales durante el proceso, cuando estos sean requeridos (temperatura, humedad)?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="12.3.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="13.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Los medicamentos se diseñan y desarrollan de forma que se tenga en cuenta lo requerido por las buenas prácticas de manufactura?",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="14.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Control de calidad realiza controles",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fisicoquímicos",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Microbiológicos",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Titulo = "¿Tiene la unidad de control de calidad el equipo necesario para realizar los análisis? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="14.1.8",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Adjuntar listado de equipos.",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de no tener el equipo especializado para realizar un análisis específico, ¿Contrata los servicios de un Laboratorio de Control de Calidad externo, que está debidamente autorizado por la Autoridad Reguladora?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué análisis se realizan en el Laboratorio de Control de Calidad externo?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio contratado, ¿posee toda la información técnica necesaria para que pueda realizar los controles en total concordancia con las técnicas de control de la empresa titular?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio de control de calidad de la empresa titular, recibe del laboratorio contratado los resultados de los ensayos y tiene acceso a todos los datos para verificar estos resultados?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay un programa de mantenimiento preventivo para todos los equipos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="14.1.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registro que acrediten el cumplimiento del programa?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
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
                        Titulo = "¿Se indica en el mismo cuales operaciones son realizadas en forma interna y cuales por servicios contratados? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los equipos están correctamente rotulados indicando la vigencia de la calibración?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha de su última calibración:",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En el caso de calibraciones internas ¿el laboratorio cuenta con patrones certificados?",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Titulo = "c) ¿Metodología analítica escrita de cada materia prima y producto terminado, con su referencia? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Procedimientos escritos de control de calidad y resultados de las pruebas de materiales, productos, áreas y personal?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de los informes o certificados analíticos de las pruebas de materiales, productos, áreas y personal?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los analistas disponen de registro de laboratorio foliado en el que se registran los resultados de laboratorio?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los cálculos fechados y firmados por el analista?",
                        Criterio = "MAYOR",
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
                        Titulo = "g) ¿Procedimientos escritos de validación de todos los métodos de ensayo?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de validación de cada uno de los métodos de ensayo?",
                        Criterio = "CRITICO",
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
                        Titulo = "i) ¿Procedimientos escritos del mantenimiento del equipo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros del mantenimiento del equipo? ",
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
                        Titulo = "",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) ¿Procedimientos escritos y programa de sanitización de áreas?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) ¿Procedimientos escritos para el uso de todo el instrumental?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MAYOR",
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
                        Titulo = "n) ¿Procedimiento escrito para el mantenimiento de instalaciones de control de calidad?",
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
                        Titulo = "ñ) ¿Procedimiento escrito para el manejo y desecho de solventes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "o) ¿Procedimiento escrito para el lavado de cristalería?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "p) ¿Procedimientos escritos para la recepción, identificación, preparación, manejo y almacenamiento de reactivos y estándares?",
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
                        Criterio = "¿",
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
                        Titulo = "materias primas.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
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
                        Titulo = "producto intermedio o semielaborado.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "producto terminado.",
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
                        Titulo = "b) El equipo que debe utilizarse",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen el equipo necesario para el muestreo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El equipo se conserva en buen estado y está debidamente almacenado e identificado?",
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
                        Titulo = "d) Instrucciones para la eventual subdivisión de la muestra",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Tipo y condiciones del envase que debe utilizarse para la muestra",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Identificación de los recipientes muestreados",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Precauciones especiales que deben observarse, especialmente en relación con el muestreo de material estéril o de uso delicado",
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
                        Titulo = "La cantidad de muestra que se recolecta es estadísticamente representativa del lote de",
                        Criterio = "",
                        Capitulo="",
                        Articulo="14.3.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "materias primas",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "materiales de envase y empaque",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "producto intermedio o semielaborado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "producto terminado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El número de envases muestreados coincide con el procedimiento de muestreo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza muestreo y análisis de identidad del contenido de cada recipiente de materia prima?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las muestras están identificadas con una etiqueta que tiene la siguiente información:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="14.3.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del material o producto",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Cantidad.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Número de lote",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fecha de muestreo. ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Recipientes de los que se han tomado las muestras",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Nombre y firma de la persona que realiza el muestreo",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se conservan muestras de referencia de cada lote de:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="14.3.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Ingredientes activos.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Producto terminado.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las muestras de referencia de cada lote, se almacenan hasta un año después de la fecha de expiración?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La cantidad de las muestras de referencia es suficiente para permitir al menos un análisis completo de acuerdo al procedimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las muestras de referencia de producto terminado se conservan en su empaque final? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las muestras de referencia de producto terminado se mantienen en las condiciones de almacenamiento según especificación del producto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan exámenes visuales de las muestras de referencia por lo menos una vez al año?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen registro de estas inspecciones, en caso de encontrar desviaciones se documenta las acciones correctivas?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "METODOLOGÍA ANALÍTICA",
                        Criterio = "",
                        Capitulo="14.4",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen todos los métodos analíticos por escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="14.4.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los métodos analíticos empleados están aprobados y validados? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de validación de los métodos analíticos utilizados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de cumplimiento de este programa?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los formatos de informes o certificados analíticos tienen la siguiente información registrada:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="14.4.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del material o producto.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Forma farmacéutica (cuando aplique).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Presentación farmacéutica (cuando aplique).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Número de lote",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Nombre del fabricante y proveedor, cuando se declare",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Referencias de las especificaciones y procedimientos analíticos pertinentes.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Resultados de los análisis, con observaciones, cálculos, gráficas, cromatogramas y referencias.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Fechas de los análisis.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Firma registrada de las personas que realizan los análisis.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Firma registrada de las personas que verifican los análisis y los cálculos.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Registro de aprobación o rechazo (u otra decisión sobre la consideración del producto), fecha y firma del responsable designado.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los informes se encuentran accesibles y tienen la información indicada anteriormente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para realizar todos los controles durante el proceso de producción de acuerdo a los métodos aprobados por control de calidad?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="14.4.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay personal asignado para realizar los controles en proceso, durante el proceso de producción?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha capacitado el personal para esta función? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de los resultados de los controles en proceso?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "De acuerdo a condiciones definidas y escritas se prepara y se conserva los: ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="14.4.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Reactivos químicos.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de los reactivos necesarios para la realización de los análisis físicos químicos de rutina? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para la preparación, uso y conservación de cada una de las soluciones valoradas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿A los reactivos recibidos se les rotula con fecha de recepción, de apertura y vencimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantiene un control de las fecha de expiración de estos reactivos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Medios de cultivo.",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone de los medios de cultivo necesarios para realizar los controles microbiológicos de rutina?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentran dentro del periodo de validez?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para la preparación de cada uno de los medios de cultivo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los medios de cultivo deshidratados ¿se almacenan en condiciones de humedad y temperatura indicadas por el fabricante?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran los parámetros de cada ciclo de esterilización de medios de cultivo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza el test de promoción de crecimiento cada vez que se utilizan nuevos lotes de medios de cultivo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Cepas de referencia.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen cepas microbianas de referencia?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En caso de existir ¿son certificadas por un organismo reconocido internacionalmente?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de identificación y uso de cepas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está establecida la frecuencia de los repiques/ resiembras? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran los repiques/resiembras? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan a cabo controles periódicos para verificar la identidad morfológica y bioquímica de estas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se mantiene un control de las fecha de expiración de estas cepas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan ensayos de determinación de potencia de antibióticos, cuando aplique? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se efectúa la verificación estadística de la determinación de potencia y validez del ensayo, cuando aplique? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con áreas o sectores asignados para la preparación de muestras, lavado y acondicionamiento de materiales y preparación de medios de cultivo?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sector de microbiología, cuenta con un sistema para descontaminación bacteriana? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento escrito para el manejo y eliminación de desechos químicos y microbiológicos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son eliminados en forma sanitaria a intervalos regulares y frecuentes evitando la contaminación?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Patrones de referencia.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen patrones y materiales de referencia?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan los registros de los patrones primarios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan los registros de los patrones secundarios?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan los registros de los materiales de referencia?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todos los patrones secundarios y materiales de referencia tienen certificado analítico vigente? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantiene un control de las fechas de expiración de estos patrones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para la preparación, uso y conservación de cada uno de los patrones secundarios y materiales de referencia?",
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
                        Titulo = "Cada envase de reactivos químicos, medios de cultivo, cepas y patrones de referencia, preparados en el laboratorio lleva una etiqueta de identificación con la siguiente información:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="14.4.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Concentración-factor de normalización (cuando aplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Fecha de preparación y valoración (cuando aplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Nombre y firma de la persona que realizo la preparación (cuando aplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Fecha de revaloración (cuando aplique).",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Fecha de vencimiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Condiciones de almacenamiento",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Categoría de seguridad",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Referencia al procedimiento.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTABILIDAD",
                        Criterio = "",
                        Capitulo="14.5",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La unidad de control de calidad realiza estudios de estabilidad de los productos terminados, con el fin de garantizar que el producto cumpla con las especificaciones de calidad durante su vida útil?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="14.5.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dichos estudios de estabilidad se determinan antes de la comercialización?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan estudios de estabilidad después de cualquier modificación significativa en la fabricación de los productos?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen los estudios de estabilidad acelerada?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen los estudios de estabilidad en estante o de largo plazo?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa permanente para la determinación de la estabilidad de los productos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="14.5.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cumple el programa?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen protocolos de estudios de estabilidad de los productos?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye: ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Descripción completa del producto objeto del estudio?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Parámetros controlados y métodos analíticos validados que demuestren la estabilidad del producto de acuerdo a las especificaciones establecidas?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Cantidad suficiente de muestras para cumplir con el programa?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Cronograma de los ensayos analíticos a realizar para cada producto?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Condiciones especiales de almacenamiento?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Un resumen y datos obtenidos incluyendo las evaluaciones y conclusiones del estudio?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Un número suficiente de lotes? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las fechas de caducidad y las condiciones de almacenamiento de los productos son establecidas basándose en los estudios de estabilidad?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="14.5.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un sistema de seguimiento de los productos comercializados que permita verificar el plazo de validez establecido?",
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
                        Titulo = "¿Se establece en el contrato la persona responsable de autorizar la liberación de cada lote para su comercialización y de emitir el certificado de análisis?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="15.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El contrato a terceros tiene la siguiente información: ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="15.1.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Es redactado por personas competentes y autorizadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Aceptación de los términos del contrato por las partes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Cumplimiento de las Buenas Prácticas de Manufactura?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Abarca la producción y el análisis o cualquier otra gestión técnica relacionada con estos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Describe el manejo de materias primas, material de acondicionamiento, graneles y producto terminado, en caso sean rechazados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Permite el ingreso del contratante a las instalaciones del contratista (contratado), para auditorías?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿Permite el ingreso del contratista (contratado) a las instalaciones del contratante?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) ¿Existe una lista de los productos o servicios de análisis objeto del contrato?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de análisis por contrato, el contratista (contratado) acepta que puede ser inspeccionado por la Autoridad Reguladora?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="15.1.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se contempla dentro del contrato?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
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
                        Titulo = "b) Tramita y obtiene el registro sanitario del producto(s) a fabricar",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El programa de validación incluye:",
                        Criterio = "MAYOR",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Métodos analíticos.",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Procesos de producción de no estériles.",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Procesos de producción de estériles (ver Anexo A Productos Estériles).",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Procedimientos de limpieza. ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Sistema de agua (ver desglose).",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Sistema de aire (ver desglose).",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Sistema de vapor (calderas y otros), cuando aplique",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Instalaciones. ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Sistemas informáticos (cuando aplique).",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SE REALIZA Y DOCUMENTA LA CALIFICACION Y VALIDACION DE SISTEMA DE AGUA",
                        Criterio = "",
                        Capitulo="",
                        Articulo="f",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha realizado la calificación de la instalación del sistema de agua (CI o IQ)?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe protocolo e informe de la calificación de la instalación del sistema de agua?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Revisión de las instalaciones",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Especificaciones de equipos versus diseño.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Pruebas de rugosidad de soldaduras en tuberías",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ausencia de puntos/tramos muertos de tuberías",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Pasivación de tuberías y tanques",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Revisión de los planos del sistema como fue construido(as built)?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Revisión de procedimientos de operación, de limpieza y sanitización, de mantenimiento preventivo?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Calibración de instrumentos de medición.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe incluye lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusión/ resumen",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción del ensayo realizado",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Referencias del protocolo.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha realizado la calificación de la operación del sistema de agua (CO u OQ)?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe protocolo e informe de la calificación de la operación del sistema de agua?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Capacidad de producción del sistema de agua (L/min).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tipo de flujo y velocidad del agua.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de válvulas.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de sistemas de alarma.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de controles.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe incluye:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusión/ resumen",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción del ensayo realizado",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Referencias del protocolo",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se ha realizado la calificación de desempeño (performance) del sistema de agua (CD o PQ): Fase 1, Fase 2 y Fase 3?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Validación Fase 1:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están definidos los parámetros operacionales?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están definidos los procedimientos de limpieza y sanitización; incluyendo sus frecuencias?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con los registros de muestreo diario de cada punto de pre-tratamiento y de cada punto de uso, efectuado durante un período de 2 a 4 semanas?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen los procedimientos escritos del sistema de agua?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Validación Fase 2:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con los registros de muestreo diario de cada punto de pre-tratamiento y de cada punto de uso, efectuado durante las siguientes 4 a 5 semanas después de cumplida la Fase 1?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los resultados de estos registros demuestran que el sistema está controlado (cumple con los parámetros definidos en las especificaciones respecto de la calidad de agua y cumple con los parámetros del sistema de agua)?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Disponen de los informes que resumen los resultados de las fases 1 y 2 de la validación?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Validación Fase 3:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con los registros de muestreo semanal de todos los puntos de uso correspondientes a un período de un año?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los resultados de estos registros demuestran que el sistema está controlado?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Disponen del informe resumen de la validación?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los componentes del sistema se encuentran en buen estado?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe el protocolo e informe de la calificación del desempeño (performance) del sistema: Fase 1, Fase 2 y Fase 3?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Plano del sistema con indicación de puntos de uso.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Programa de rotación de puntos de muestreo (en caso que no se muestreen siempre todos los puntos de uso).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Protocolos de análisis fisicoquímicos y microbiológicos",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Programa de frecuencia de análisis para la liberación del sistema de agua",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Programa de frecuencia de análisis para el seguimiento del sistema de agua",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe incluye lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusión/ resumen",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción del ensayo realizado",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Referencias del protocolo",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están los instrumentos críticos de medición calibrados?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen los informes de calibración?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Poseen etiquetas donde figuren fecha de la última calibración?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El informe final de la validación del sistema de agua estáavalado por la firma de todos los involucrados, la verificación y firma de garantía de calidad?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SE REALIZA Y DOCUMENTA LA CALIFICACION Y VALIDACION DE SISTEMA DE AIRE.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha realizado la calificación de la instalación del sistema de aire (CI o IQ)?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe protocolo e informe de la calificación de la instalación del sistema de aire?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Revisión de las instalaciones",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Especificaciones de equipos versus diseño",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Revisión de los planos del sistema como fue construido (as built)?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Revisión de procedimientos de operación, de limpieza y desinfección, de mantenimiento preventivo",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Calibración de instrumentos de medición",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Evaluación del sistema de inyección de aire",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Evaluación del sistema de extracción de aire",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe incluye lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader =true
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resumen",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción del ensayo realizado",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Referencias del protocolo",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha realizado la calificación de la operación del sistema de aire (CO u OQ)?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe protocolo e informe de la calificación de la operación del sistema de aire?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las pruebas son realizadas en las áreas en reposo?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tipo de flujo",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Diferencial de presión sobre el filtro",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Diferencial de presión del área.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Velocidad/ Uniformidad del flujo del aire",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Volumen/ Velocidad del flujo de aire",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Paralelismo",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Patrón del flujo de aire",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tiempo de recuperación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Clasificación del área (partículas transportadas por el aire).",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Temperatura y humedad",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de sistemas de alarma",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de controles",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe incluye:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resumen",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción de los ensayos realizados",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Referencias del protocolo",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha realizado la calificación del desempeño (performance) del sistema de aire (CD o PQ)?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe protocolo e informe de la calificación del desempeño (performance) del sistema de aire (CD o PQ)?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las pruebas son realizadas en las áreas en funcionamiento (operacionalmente)?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El protocolo incluye lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tipo de flujo",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Diferencial de presión sobre el filtro",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Diferencial de presión del área",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Velocidad/ Uniformidad del flujo del aire",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Volumen/ Velocidad del flujo de aire.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Paralelismo",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Patrón del flujo de aire.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tiempo de recuperación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Clasificación del área (partículas transportadas por el aire)",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Temperatura y humedad",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de sistemas de alarma",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Operación de controles",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El informe incluye:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resumen",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción del ensayos realizados",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Referencias del protocolo",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Validación Microbiológica del Sistema de Aire",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Definición de límites de alerta/ de acción como una función de la limpieza del área",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Identificación y marcado de los puntos de muestreo",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Definición de las condiciones de transporte, almacenamiento e incubación de las muestras.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuáles son los límites de alerta?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuáles son los límites de acción?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué procedimientos se siguen si se exceden estos puntos?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentran documentados?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las pruebas son realizadas en las áreas en reposo?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las pruebas son realizadas en las áreas en funcionamiento (operacionalmente)?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen protocolos de calificación de operación (CO u OQ) en los que tengan la siguiente información:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Introducción",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Responsabilidades",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ensayos realizados.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Criterios de aceptación de la calificación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Registro y reporte de datos.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen los informes de la calificación de operación (CO u OQ) en los que tengan lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resumen",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción de ensayos realizados",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos obtenidos.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen protocolos de calificación del desempeño de equipos (CD o PQ) en los que tengan la siguiente información:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Introducción",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Responsabilidades",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ensayos realizados",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Criterios de aceptación de la calificación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Registro y reporte de datos",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen los informes de la calificación del desempeño de equipos (CD o PQ) en los que tengan lo siguiente:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resumen",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Descripción de ensayos realizados",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablas de datos obtenidos.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Resultados",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conclusiones",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Firmas de revisión y aprobación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El informe final de la validación del sistema de aire estáavalado por la firma de todos los involucrados, la verificación y firma de garantía de calidad?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "DE NUEVA FÓRMULA",
                        Criterio = "",
                        Capitulo="16.5",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuando se realiza cambios en la formulación o en el método de preparación, ¿se toman las medidas para demostrar que las modificaciones realizadas aseguran un producto con la calidad exigida?",
                        Criterio = "CRITICO",
                        Capitulo="16.5",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene el laboratorio procedimientos escritos para documentar el control de cambios?",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
            QuejasGenerales = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>() {
                    new ContenidoTablas()
                    {
                        Titulo = "GENERALIDADES",
                        Criterio = "MAYOR",
                        Capitulo="17.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos escritos sobre el manejo de:",
                        Criterio = "MAYOR",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Titulo = "¿Realiza el laboratorio fabricante autoinspecciones y auditorias periódicas?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="18.1.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene el laboratorio fabricante un procedimiento y programa de autoinspecciones que contempla todos los aspectos de las buenas prácticas de manufactura?",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Acciones correctivas y preventivas",
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
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
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="18.1.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se ha documentado esa capacitación?",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Se realizan auditorias de calidad internas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="18.2.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de las auditorías?",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Las auditorias de calidad son realizadas por personal de la misma compañía?",
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
                        Titulo = "¿Se da seguimiento a las acciones correctivas y preventivas de las auditorias de calidad?",
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
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            FabProdFarmEsteril_A = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Qué tipo de producto fábrica:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Sólidos estériles",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Líquidos estériles",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Pequeño volumen",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Gran volumen",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
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
                        Capitulo="A.1",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La producción de productos farmacéuticos estériles se realiza en instalaciones especiales para minimizar el riesgo de contaminación?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El ingreso de materiales, equipo y personal, a las áreas estériles se realiza por medio de esclusas?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.1.3A.6.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las siguientes operaciones se llevan acabo en áreas separadas dentro del área limpia?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="A.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a - Preparación de materiales.",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b- Producción",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c- Esterilización",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuál es la metodología de esterilización de los productos fabricados?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="A.1.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a- Producción aséptica.",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b- Con esterilización final.",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c- Esterilización con filtración. ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El diseño de las áreas garantiza la calidad del aire en reposo y en funcionamiento?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.1.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cumplen las áreas de fabricación de estériles con las características exigidas del aire, en grados?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.1.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a- A",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b- B",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c- C",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d- D",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se controla el nivel de partículas de los distintos grados en las áreas en funcionamiento?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.1.8",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan los controles microbiológicos de las áreas en funcionamiento?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.1.9",
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
                        Titulo = "¿Se tienen establecidos límites de alerta? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.1.10",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se documentan y se llevan a cabo las acciones correctivas al sobrepasar estos límites?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            FabProdFarmEsteril_A2 = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCCIÓN ASÉPTICA",
                        Criterio = "MAYOR",
                        Capitulo="A.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La producción aséptica se realiza con materiales estériles? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.2.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza en un ambiente grado A con un entorno grado B? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento para el traslado de los recipientes parcialmente cerrados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.2.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza el traslado en un ambiente grado A con un entorno grado B? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La operación de lavado de frascos y de ampollas vacías, se efectúa en un área clase D cómo mínimo? ",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCCIÓN CON ESTERILIZACIÓN FINAL",
                        Criterio = "",
                        Capitulo="A.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las soluciones se elaboran como mínimo en un ambiente de grado C?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.3.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El llenado de preparaciones parenterales se efectúa en un área de trabajo con flujo laminar grado A?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El llenado de preparaciones no parenterales se efectúa en un ambiente grado C? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La elaboración y llenado de productos estériles semisólidos se realizan en un ambiente grado C?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCCIÓN CON ESTERILIZACIÓN POR FILTRACIÓN",
                        Criterio = "",
                        Capitulo="A.4",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se realiza el llenado en una área de trabajo bajo alguna de las siguientes condiciones:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="A.4.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Grado A con ambiente grado B",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Grado B con ambiente grado C",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            FabProdFarmEsteril_A3 = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "PERSONAL",
                        Criterio = "",
                        Capitulo="A.5",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cuenta con el número mínimo de personas en las áreas de producción aséptica?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.5.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan las inspecciones y controles de las áreas limpias, demuestran que el número mínimo de personas no produce contaminación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El personal (incluido el de limpieza y mantenimiento) se somete regularmente a capacitación en BPM de productos estériles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.5.2",
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
                        Titulo = "¿El personal a cargo de la producción de productos estériles cumple con los procedimientos de higiene y limpieza?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.5.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Comunican a sus superiores cualquier detrimento de salud?",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Se efectúan exámenes médicos periódicos al personal?",
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
                        Titulo = "¿Existen procedimientos para el ingreso a las áreas limpias?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.5.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.5.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utiliza vestimenta acorde a las áreas y tareas que se realizan, según procedimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.5.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los uniformes para el área aséptica están limpios y en buenas condiciones? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.5.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son esterilizados previo a su uso, existen registros?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.5.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza el lavado de uniformes en un área limpia y exclusiva?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.5.8",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el procedimiento escrito se declara la precaución para evitar adherencia de partículas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe y se cumple los procedimientos para lavado de uniformes? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "INSTALACIONES",
                        Criterio = "",
                        Capitulo="A.6",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las instalaciones están diseñadas a fin de permitir que todas las operaciones puedan ser observadas desde el exterior, para fines de supervisión y control?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.6.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen áreas separadas físicamente para cada una de las etapas de producción?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las paredes, pisos, techos y curvas son superficies lisas e impermeables, que permitan la aplicación de agentes de limpieza y sanitizantes?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.6.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de existir cielos falsos o cielos rasos, son lisos y sellados herméticamente?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.6.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las tuberías, ductos y otros servicios se encuentran empotrados e instalados de manera que faciliten su limpieza?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.6.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las tuberías fijas de servicio están identificadas indicando además la dirección del flujo si fuera necesario?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las instalaciones eléctricas visibles están en buen estado de conservación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los vestidores están diseñados con esclusas con diferenciales de presión? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.6.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El vestidor en su etapa final tiene en estado de reposo, el mismo grado del área a que conduce como mínimo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está ubicado el lavado de manos en la primera parte del vestidor?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Disponen las esclusas de un sistema para prevenir la apertura simultánea de las puertas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.6.8",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué grado de aire existen en las esclusas? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.6.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Grado A",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Grado B",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Grado C",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Grado D",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿De acuerdo a la clasificación anterior, existen registros de control de aire?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica la efectividad de las esclusas, considerando?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="A.6.10",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Proceso de transferencia",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Calidad del aire interior y exterior",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Sanitización",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la efectividad de las esclusas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SISTEMAS DE AIRE",
                        Criterio = "",
                        Capitulo="A.7",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen gradientes de presión entre las áreas?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.7.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En las áreas de ambiente controlado (B,C,D) existe registros del número de renovaciones horarias? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sistema de alarma detecta fallas en el suministro de aire?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.7.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se dispone de manómetros para registrar diferenciales de presión?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los diferenciales de presión se registran periódicamente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las operaciones de mantenimiento y reparaciones en la medida de lo posible, se realiza fuera del área estéril?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.7.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento que garantice la no contaminación cuando el mantenimiento y reparaciones se realicen en el área estéril?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica la integridad y sellado de los filtros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento de revisión y cambio de los filtros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SISTEMAS DE AGUA",
                        Criterio = "",
                        Capitulo="A.8",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El agua para la producción de productos estériles cuenta con los siguientes procedimientos?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.8.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Manipulación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Distribución",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Almacenamiento",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Conservación",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registros que demuestren que se evita el crecimiento microbiano?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La obtención del agua para estériles tiene como base agua tratada con mecanismos de purificación? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.8.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué sistema de tratamiento se emplea para la obtención de agua para productos estériles?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de realizarse sanitización química se investiga la existencia de residuos de los agentes sanitizantes?",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Se monitorea periódicamente el agua, para la evaluación de contaminación química, microbiológica y endotoxinas?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.8.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen diagramas del sistema de tratamiento, planos de la red de distribución, puntos de muestreo y rotación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.8.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de los resultados del monitoreo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuándo se requiera almacenar agua, al ser utilizado en producción, se garantiza la calidad de la misma?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.8.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen controles? ",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Está construido el tanque de material sanitario?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene filtro de venteo hidrófobo absoluto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles periódicos de su integridad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las tuberías de distribución del agua hasta los puntos de uso son de material sanitario? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se aprueba por control de calidad, el agua a utilizar para cada lote de fabricación? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.8.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de esta evaluación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "EQUIPO",
                        Criterio = "",
                        Capitulo="A.9.0",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué métodos se usan para la esterilización de los equipos?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Vapor",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Calor seco",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Otros",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los hornos de secado y de vapor tienen registros de temperatura y tiempo de esterilización?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los ciclos de despirogenado están validados?",
                        Criterio = "CRITICO",
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
                        Titulo = "¿El diseño de los equipos, accesorios y servicios permiten que las operaciones de mantenimiento y las reparaciones se realicen fuera de las áreas limpias?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.9.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se sanitiza y esterilizan las partes de los equipos que fueron reparados antes de ingresar a las áreas? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estas esterilizaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento para dar mantenimiento a los equipos dentro del área? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.9.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los instrumentos y herramientas se sanitizan y esterilizan antes de ingresar?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se sanitiza el área, después de efectuado el mantenimiento del equipo?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento de mantenimiento preventivo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.9.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe un programa de mantenimiento preventivo para:",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los equipos",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los sistemas de esterilización",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los sistemas de aire",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los sistemas de tratamiento y almacenamiento de agua.",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "SANITIZACIÓN",
                        Criterio = "",
                        Capitulo="A.10",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento para la sanitización de las áreas limpias?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.10.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de rotación de los sanitizantes? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estas rotaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los detergentes y sanitizantes están sometidos a control microbiológico así como sus diluciones? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.10.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estos controles?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento para la preparación almacenamiento, rotulación y conservación de las soluciones sanitizantes y detergentes?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa para el monitoreo del conteo microbiano de aire, superficies y de partículas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.10.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estos monitoreos y se incluye en la orden de producción? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen controles de las áreas, aún si no están produciendo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "PRODUCCIÓN",
                        Criterio = "",
                        Capitulo="A.11",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es el movimiento del personal controlado y metódico?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.11.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se controla la temperatura y la humedad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se reduce al mínimo la presencia de envases y materiales que puedan desprender fibras?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.11.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se evita completamente estos materiales cuando se estáefectuando un proceso aséptico? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento para la manipulación de los componentes, envases y equipos de forma que no se contaminen después de su sanitización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.11.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se identifican adecuadamente de acuerdo a la etapa del proceso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se determina de acuerdo a un procedimiento el tiempo máximo permitido para el intervalo de las operaciones de:",
                        Criterio = "",
                        Capitulo="",
                        Articulo="A.11.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Lavado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Secado",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Esterilización de componentes",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Esterilización de equipos, cuando aplique",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se define un tiempo máximo autorizado entre el inicio de la preparación de una solución y su esterilización o filtración a través de un filtro de retención microbiana, para cada producto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.11.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se toma en cuenta su composición y el método de almacenamiento previsto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica el límite microbiano máximo permitido de la esterilización del producto?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.11.7",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son las soluciones especialmente las parenterales de gran volumen, pasadas a través de un filtro de esterilización inmediatamente antes del proceso de llenado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se protegen todos los orificios de salida de presión de los recipientes cerrados herméticamente que contienen las soluciones acuosas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento para el ingreso de los materiales, envases y equipos al área limpia? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.11.8",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se suministran los gases no combustibles filtrados a través de filtros de retención microbiana?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.11.9",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan la comprobación de las operaciones de asepsia empleando medio de cultivo que estimulan el crecimiento microbiano, en las condiciones normales de trabajo y a intervalos regulares?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.11.10",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan sobre un mínimo de 3,000 unidades o acorde a la capacidad del equipo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se considera no conforme el ensayo que obtiene una cifra mayor al 0.1% de las unidades contaminadas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estos ensayos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investigan las causas de cualquier contaminación detectada? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de estas investigaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de las acciones tomadas en estos casos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTERILIZACIÓN",
                        Criterio = "",
                        Capitulo="A.12",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué método de esterilización se emplea?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.12.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Calor húmedo o seco",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Óxido de etileno",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Filtración",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Radiación ionizante",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Otros",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se validan y documentan los procesos de esterilización?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.12.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se demuestra que el proceso de esterilización es eficaz para alcanzar los niveles de esterilización deseados, según procedimiento escrito?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.12.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica a intervalos programados, como mínimo una vez al año la validez del proceso de esterilización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica cada vez que se han realizado modificaciones significativas al equipo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuándo se utilizan indicadores biológicos, que precauciones se adoptan para evitar la transferencia de contaminación microbiana a partir de los mismos?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.12.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se almacenan y utilizan de acuerdo a las instrucciones y precauciones del fabricante?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.17.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica su calidad?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para evitar la confusión de los productos que han sido esterilizados de aquellos que no lo han sido?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.12.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de cada ciclo de esterilización? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.12.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTERILIZACIÓN POR CALOR",
                        Criterio = "",
                        Capitulo="A.13",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registra cada ciclo de esterilización mediante equipo calificado?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.13.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el momento de validación se determinó el punto másfrío de la carga o de la cámara cargada?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son los controles realizados parte del registro del lote? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se determina el tiempo necesario para que la carga alcance la temperatura requerida, antes de iniciar el cómputo del tiempo de esterilización?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.13.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTERILIZACIÓN POR CALOR HÚMEDO",
                        Criterio = "",
                        Capitulo="A.14",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utiliza la esterilización por calor húmedo únicamente para esterilizar materiales que puedan humedecerse y para soluciones acuosas?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.14.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registra la temperatura y la presión durante todo el ciclo de esterilización? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se comprueba la ausencia de fugas en la cámara cuando forma parte del ciclo una fase de vacío? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El material de empaque impide la contaminación después de la esterilización?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El vapor que se utiliza en la esterilización tiene la calidad necesaria y no contiene aditivos en un grado que pudiera provocar la contaminación del producto o del equipo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.14.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTERILIZACIÓN POR CALOR SECO",
                        Criterio = "",
                        Capitulo="A.15",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El aire suministrado a la cámara de esterilización pasa a través de filtro HEPA?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.15.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El aire suministrado a la cámara de esterilización circula manteniéndose con presión positiva?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuándo el objetivo es eliminar los pirógenos se utilizan como parte de la validación pruebas con cargas de endotoxinas?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTERILIZACIÓN POR RADIACIÓN",
                        Criterio = "",
                        Capitulo="A.16",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utiliza la esterilización por radiación principalmente para esterilizar materiales y productos sensibles al calor?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.16.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está documentada la investigación de los efectos nocivos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mide la dosis de radiación empleando dosímetros?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.16.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Indican una medida cuantitativa de la dosis recibida por el producto?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuándo se utilizan dosímetros plásticos se utilizan dentro del tiempo límite de su calibración?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifican las absorbancias poco después de su exposición a la radiación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utilizan simultáneamente indicadores biológicos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Toda la información obtenida forma parte del registro del lote?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se toman en cuenta los efectos de las variaciones en la densidad de los envases al realizar la validación del procedimiento de radiación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.16.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los procedimientos de manipulación de materiales evitan la confusión entre materiales irradiados y no irradiados?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.16.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utilizan en cada paquete discos de color sensibles a la radiación para distinguir entre envases que se han sometido a la radiación y los que no?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se determina previamente la dosis de radiación total que debe administrarse en un periodo de tiempo?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.16.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ESTERILIZACIÓN CON OXIDO DE ETILENO",
                        Criterio = "",
                        Capitulo="A.17",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En la validación del proceso se demuestra que no existe ningún efecto nocivo sobre el producto? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.17.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se asegura que las condiciones y el tiempo son los requeridos para reducir el óxido de etileno a niveles permitidos?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se toman precauciones para evitar la presencia de microorganismos, están descritos en el procedimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.17.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se establece antes de la exposición al gas, un equilibrio entre los materiales, la humedad y la temperatura y tiempo requerido por el proceso, según lo declare el procedimiento?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.17.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se controla cada ciclo de esterilización con indicadores biológicos apropiados? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.17.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utilizan el número de unidades de indicadores de acuerdo al tamaño de la carga?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utilizan el número de unidades de indicadores de acuerdo al tamaño de la carga?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Esta información se incluye en los registros del lote?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En cada ciclo de esterilización se llevan los siguientes registros:",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.17.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tiempo empleado en completar el ciclo",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Presión",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Temperatura",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Humedad",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Concentración del gas",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cantidad total del gas utilizada",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "FILTRACIÓN DE PRODUCTOS QUE NO PUEDEN ESTERILIZARSE EN SU ENVASE FINAL",
                        Criterio = "",
                        Capitulo="A.18",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utiliza un filtro bacteriológico de 0.22 micras o menos para los productos que no se esterilizan en su envase final?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.18.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Estádocumentada la esterilización de los recipientes? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Para productos no parenterales estériles, cuando la solución no contiene preservantes el filtro bacteriológico a utilizar es el de 0.22 de micras?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Para productos no parenterales estériles, cuando la solución contiene preservantes el filtro bacteriológico a utilizar es el de 0.45 de micras o menos?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza una pre-filtración utilizando filtros de retención microbiana? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.18.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La segunda filtración se realiza inmediatamente antes del llenado?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe el procedimiento de filtración, en este se incluye la especificaciones del filtro?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.18.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de su cumplimiento? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se comprueba la integridad del filtro antes y durante o después de su utilización con los siguientes métodos aprobados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.18.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Punto de burbuja",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Flujo de difusión",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Mantenimiento de la presión.",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se determina el tiempo empleado en filtrar un volumen conocido de solución a granel?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Estos valores se determinan durante la validación? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investiga cualquier diferencia importante que se de en estos parámetros durante la fabricación normal?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utiliza un filtro por día de trabajo?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.18.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso contrario existe un procedimiento escrito y validado?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se demuestra que el filtro no afecta al producto reteniendo componentes de éste, ni le añade sustancias?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.18.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "ACABADO DE PRODUCTOS ESTÉRILES",
                        Criterio = "",
                        Capitulo="A.19",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el cierre y sellado de los envases, se verifica la integridad? ",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="A.19.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos y registros?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="A.19.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se inspeccionan los productos parenterales llenos en un 100%?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.19.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si la inspección es visual se efectúa bajo condiciones controladas de iluminación y fondo?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está documentado el periodo de descanso de los inspectores?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Si se utilizan otros métodos de inspección, están validados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se chequean los aparatos utilizados a intervalos regulares?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registran los resultados?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se someten a los operadores a exámenes de la vista regularmente?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CONTROL DE CALIDAD",
                        Criterio = "",
                        Capitulo="A.20",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dentro del conjunto de controles con los que se garantiza la calidad del producto, se contempla siempre la prueba de esterilidad?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="A.20.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se incluyen en los controles, los registros de las condiciones ambientales en el proceso de fabricación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las muestras que se toman para el control de calidad están de acuerdo a un sistema de muestreo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="A.20.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuándo una prueba de control de calidad no cumpla con las especificaciones de calidad, se realizan las investigaciones correspondientes?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="A.20.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan las acciones correctivas o preventivas del caso?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento?",
                        Criterio = "MENOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la investigación y de las acciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza el monitoreo de lo siguiente?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="A.20.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Del agua",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "De los productos intermedios",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "De los productos terminados",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza por parte del control de calidad la prueba de endotoxinas?",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Los métodos no oficiales utilizados por control de calidad están validados?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            /////////////
            Lactamicos = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "PERSONAL",
                        Criterio = "",
                        Capitulo="B.2",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de rotación del personal, éste pasa por un periodo de cuarentena no menor de siete días, o se cuenta con un procedimiento validado de monitoreo para justificar la disminución de este periodo?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="B.2.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Al personal se le realiza la prueba de sensibilidad al menos una vez al año?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="B.2.2",
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
                        Titulo = "¿Al personal de primer ingreso se le realiza la prueba de sensibilidad? ",
                        Criterio = "CRITICO",
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
                        Titulo = "¿Se realiza esta prueba a otras personas autorizadas antes de ingresar a las instalaciones? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza la capacitación específica para el personal de esta área? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="B.2.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se tienen registros de la evaluación práctica de la capacitación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento que garantice la disminución del riesgo de contaminación al personal que labora en estas áreas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="B.2.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cubre el uniforme la totalidad del cuerpo?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="B.2.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es de uso exclusivo para este propósito?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento escrito para descontaminar o desactivar el uniforme antes de lavarse o desecharse?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Utilizan los operarios equipo de protección durante todas las etapas del proceso productivo donde hay contacto directo con el principio activo?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="B.2.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "INSTALACIONES",
                        Criterio = "",
                        Capitulo="B.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El acceso a las áreas de producción es sólo del personal y para personas autorizadas, previa capacitación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="B.3.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la capacitación previa? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para el acceso a las áreas de trabajo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen exclusas independientes para el ingreso de operarios y materiales para todas las áreas de producción ( a excepción de empaque secundario)?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="B.3.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan las esclusas con diferencial de presión que eviten la salida de contaminación a las áreas adyacentes?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cuenta con un procedimiento escrito para la desactivación y sanitización de las áreas? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="B.3.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza análisis de trazas después de la desactivación y sanitización de las áreas? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="B.3.5",
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
                        Titulo = "¿Cuenta el laboratorio fabricante con un sistema para el tratamiento de aguas residuales?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="B.3.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cumple con los parámetros ambientales establecidos en la legislación ambiental?",
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
                        Titulo = "SISTEMA DE AIRE",
                        Criterio = "",
                        Capitulo="B.4",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica que el aire recirculado carece de contaminación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="B.4.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros que garanticen la no contaminación del ambiente?  ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Utiliza filtros HEPA terminal?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen dispositivos para medir los diferenciales de presión?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="B.4.2",
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
                        Titulo = "¿Existe un procedimiento escrito para la desactivación, limpieza de ductos, destrucción de residuos y filtros usados en las instalaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="B.4.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros del cumplimiento? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "EQUIPOS",
                        Criterio = "",
                        Capitulo="B.5",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son los equipos exclusivos para éstas áreas?",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="B.5.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta con un procedimiento escrito para la desactivación y sanitización de los equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="B.5.2",
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
                        Titulo = "¿Se realiza análisis de trazas después de la desactivación y sanitización de los equipos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="B.5.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza el mantenimiento preventivo de los equipos de acuerdo a un programa y procedimiento escrito, dentro de las instalaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="B.5.4",
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
                        Titulo = "CONTROL DE CALIDAD",
                        Criterio = "MAYOR",
                        Capitulo="B.6",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para desactivar el recipiente en el que se traslada la muestra a otras instalaciones de la empresa para la verificación de la calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="B.6.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            //////////
            ProdCitostatico = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "PERSONAL",
                        Criterio = "",
                        Capitulo="C.3",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el personal que elabora en citostáticos y hormonales, con la indumentaria siguiente? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="C.3.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Uniformes protectores desechables confeccionados con materiales de baja permeabilidad?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El uniforme: ¿es de manga larga, con puños y tobillos ajustados?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se usan guantes desechables y libres de talco?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Poseen mascarillas o respirador de vapores con filtros HEPA?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con lentes protectores?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con cofia y escafandra?",
                        Criterio = "",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza la capacitación específica para el personal de esta área? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="C.3.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se tienen registros de la evaluación práctica de la capacitación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento que garantice la disminución del riesgo de contaminación al personal que labora en estas áreas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="C.3.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se controla los niveles hormonales y citostáticos a todo el personal que labora en éstas áreas?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="C.3.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos y registro de estos análisis? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El acceso a las áreas de producción es sólo del personal y para personas autorizadas, previa capacitación?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="C.3.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de la capacitación previa?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para el acceso a las áreas de trabajo? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "INSTALACIONES",
                        Criterio = "",
                        Capitulo="C.4",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son independientes las esclusas para el ingreso de operarios y materiales, a las áreas de producción? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="C.4.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan las esclusas con diferenciales de presión que impidan la salida de contaminantes a las áreas adyacentes? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento escrito para la desactivación y sanitización de las áreas?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="C.4.2",
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
                        Titulo = "¿Se realiza análisis de trazas después de la desactivación y sanitización de las áreas? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="C.4.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el laboratorio fabricante con un sistema para el tratamiento de aguas residuales?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="C.4.4",
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
                        Titulo = "SISTEMA DE AIRE",
                        Criterio = "",
                        Capitulo="C.5",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica que el aire recirculado carece de contaminación? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="C.5.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros que garanticen la no contaminación del ambiente?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Utiliza filtros HEPA terminal?",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen dispositivos para medir los diferenciales de presión?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="C.5.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de su cumplimiento?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para la desactivación, limpieza de ductos, destrucción de residuos y filtros usados en las instalaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="C.5.3",
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
                        Titulo = "EQUIPOS",
                        Criterio = "",
                        Capitulo="C.6",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son los equipos exclusivos para estas áreas? ",
                        Criterio = "INFORMATIVO",
                        Capitulo="",
                        Articulo="C.6.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuenta con un procedimiento escrito para la desactivación y sanitización de los equipos? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="C.6.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan análisis de trazas después de la desactivación y sanitización de los equipos? ",
                        Criterio = "CRITICO",
                        Capitulo="",
                        Articulo="C.6.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registros de los mismos?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa y procedimiento escrito para el mantenimiento preventivo de los equipos que se realiza dentro de las instalaciones?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="C.6.4",
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
                        Titulo = "¿Existe procedimiento que contemple la inactivación e incineración de los residuos y materiales de limpieza? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="C.6.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento escrito que contemple la inactivación e incineración de la indumentaria protectora desechable?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "CONTROL DE CALIDAD",
                        Criterio = "",
                        Capitulo="C.7",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para desactivar el recipiente en el que se traslada la muestra a otras instalaciones de la empresa para la verificación de la calidad?",
                        Criterio = "MAYOR",
                        Capitulo="",
                        Articulo="C.7.1",
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
                }
            };

        }
    }
}
