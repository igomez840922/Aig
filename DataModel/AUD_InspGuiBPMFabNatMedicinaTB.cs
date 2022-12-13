using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspGuiBPMFabNatMedicinaTB : SystemId
    {
        public AUD_InspGuiBPMFabNatMedicinaTB()
        {
            AuditoriaSanitaria = new AUD_AuditoriaSanitaria();

            RepresentLegal = new DatosPersona();

            RegenteFarmaceutico = new DatosPersona();

            OtrosFuncionarios = new AUD_OtrosFuncionarios();

            GeneralesEmpresa = new AUD_GeneralesEmpresa();

            DatosConclusiones = new AUD_DatosConclusiones();

            InicializaData();
        }


        private AUD_InspeccionTB inspeccion;
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

        // Razon Social
        private string motivoInspeccion;
        public string MotivoInspeccion { get => motivoInspeccion; set => SetProperty(ref motivoInspeccion, value); }

        //Autoridad Sanitaria
        private AUD_AuditoriaSanitaria auditoriaSanitaria;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_AuditoriaSanitaria AuditoriaSanitaria { get => auditoriaSanitaria; set => SetProperty(ref auditoriaSanitaria, value); }

        //Datos del Representante Legal
        private DatosPersona representLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual DatosPersona RepresentLegal { get => representLegal; set => SetProperty(ref representLegal, value); }

        //Regente farmacéutico /Director Técnico y número de Registro
        private DatosPersona regenteFarmaceutico;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual DatosPersona RegenteFarmaceutico { get => regenteFarmaceutico; set => SetProperty(ref regenteFarmaceutico, value); }

        //Otros Funcionarios
        private AUD_OtrosFuncionarios otrosFuncionarios;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_OtrosFuncionarios OtrosFuncionarios { get => otrosFuncionarios; set => SetProperty(ref otrosFuncionarios, value); }

        //Generales Empresa
        private AUD_GeneralesEmpresa generalesEmpresa;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_GeneralesEmpresa GeneralesEmpresa { get => generalesEmpresa; set => SetProperty(ref generalesEmpresa, value); }

        //INFORMACIÓN GENERAL
        private AUD_ContenidoTablas infoGeneral;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas InfoGeneral { get => infoGeneral; set => SetProperty(ref infoGeneral, value); }

        //5. AUTORIZACIÓN DE FUNCIONAMIENTO
        private AUD_ContenidoTablas authFuncionamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AuthFuncionamiento { get => authFuncionamiento; set => SetProperty(ref authFuncionamiento, value); }

        //6.1 Organización
        private AUD_ContenidoTablas organizacion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Organizacion { get => organizacion; set => SetProperty(ref organizacion, value); }

        //6.2 Personal 
        private AUD_ContenidoTablas personal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Personal { get => personal; set => SetProperty(ref personal, value); }

        //6.3 Responsabilidades del personal
        private AUD_ContenidoTablas responPersonal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas ResponPersonal { get => responPersonal; set => SetProperty(ref responPersonal, value); }

        //6.4 De la capacitación
        private AUD_ContenidoTablas capacitacion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Capacitacion { get => capacitacion; set => SetProperty(ref capacitacion, value); }

        //6.5 Higiene y salud del personal
        private AUD_ContenidoTablas higieneSalud;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas HigieneSalud { get => higieneSalud; set => SetProperty(ref higieneSalud, value); }

        //7.1 Ubicación, diseño y características de la construcción
        private AUD_ContenidoTablas ubicacionDisenoConstruc;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas UbicacionDisenoConstruc { get => ubicacionDisenoConstruc; set => SetProperty(ref ubicacionDisenoConstruc, value); }

        //7.2 Almacenes
        private AUD_ContenidoTablas almacenes;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Almacenes { get => almacenes; set => SetProperty(ref almacenes, value); }

        //7.3 Áreas de recepción, limpieza, segregación y acondicionamiento de materia prima natural
        private AUD_ContenidoTablas areaRecepLimpieza;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaRecepLimpieza { get => areaRecepLimpieza; set => SetProperty(ref areaRecepLimpieza, value); }

        //7.4 Área de secado, molienda y extracción
        private AUD_ContenidoTablas areaSecadoMolienda;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaSecadoMolienda { get => areaSecadoMolienda; set => SetProperty(ref areaSecadoMolienda, value); }

        //7.5 Área de dispensado de materias primas 
        private AUD_ContenidoTablas areaDispensadoMatPrima;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaDispensadoMatPrima { get => areaDispensadoMatPrima; set => SetProperty(ref areaDispensadoMatPrima, value); }

        //7.6 Áreas de producción
        private AUD_ContenidoTablas areaProduccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaProduccion { get => areaProduccion; set => SetProperty(ref areaProduccion, value); }

        //7.7 Área de envasado / empaque 
        private AUD_ContenidoTablas areaEnvasadoEmpaque;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaEnvasadoEmpaque { get => areaEnvasadoEmpaque; set => SetProperty(ref areaEnvasadoEmpaque, value); }

        //7.8 Áreas auxiliares
        private AUD_ContenidoTablas areaAuxiliares;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaAuxiliares { get => areaAuxiliares; set => SetProperty(ref areaAuxiliares, value); }

        //7.9 Área de control de calidad
        private AUD_ContenidoTablas areaControlCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaControlCalidad { get => areaControlCalidad; set => SetProperty(ref areaControlCalidad, value); }

        //8.1 Generalidades
        private AUD_ContenidoTablas generalidades8;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Generalidades8 { get => generalidades8; set => SetProperty(ref generalidades8, value); }

        //8.2 Calibración
        private AUD_ContenidoTablas calibracion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Calibracion { get => calibracion; set => SetProperty(ref calibracion, value); }

        //8.4 Sistema de agua 
        private AUD_ContenidoTablas sistemaAgua;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas SistemaAgua { get => sistemaAgua; set => SetProperty(ref sistemaAgua, value); }

        //8.5 Sistema de aire 
        private AUD_ContenidoTablas sistemaAire;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas SistemaAire { get => sistemaAire; set => SetProperty(ref sistemaAire, value); }

        //9.1 Generalidades
        private AUD_ContenidoTablas generalidades9;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Generalidades9 { get => generalidades9; set => SetProperty(ref generalidades9, value); }

        //9.2 Del dispensado de materia prima
        private AUD_ContenidoTablas dispensadoMatPrima;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas DispensadoMatPrima { get => dispensadoMatPrima; set => SetProperty(ref dispensadoMatPrima, value); }

        //9.3 Materiales de acondicionamiento 
        private AUD_ContenidoTablas matAcondicionamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas MatAcondicionamiento { get => matAcondicionamiento; set => SetProperty(ref matAcondicionamiento, value); }

        //9.4 Productos a granel 
        private AUD_ContenidoTablas prodAGranel;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas ProdAGranel { get => prodAGranel; set => SetProperty(ref prodAGranel, value); }

        //9.5 Productos terminados
        private AUD_ContenidoTablas prodTerminados;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas ProdTerminados { get => prodTerminados; set => SetProperty(ref prodTerminados, value); }

        //9.6 Materiales y productos rechazados
        private AUD_ContenidoTablas prodRechazados;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas ProdRechazados { get => prodRechazados; set => SetProperty(ref prodRechazados, value); }

        //9.7 Productos devueltos 
        private AUD_ContenidoTablas prodDevueltos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas ProdDevueltos { get => prodDevueltos; set => SetProperty(ref prodDevueltos, value); }

        //10.1 Generalidades
        private AUD_ContenidoTablas generalidades10;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Generalidades10 { get => generalidades10; set => SetProperty(ref generalidades10, value); }

        //10.2 De los documentos exigidos
        private AUD_ContenidoTablas documentosExigido;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas DocumentosExigido { get => documentosExigido; set => SetProperty(ref documentosExigido, value); }

        //10.3 Procedimientos y registros
        private AUD_ContenidoTablas procedimientoReg;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas ProcedimientoReg { get => procedimientoReg; set => SetProperty(ref procedimientoReg, value); }

        //11. Producción y control de procesos
        private AUD_ContenidoTablas prodControlProceso;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas ProdControlProceso { get => prodControlProceso; set => SetProperty(ref prodControlProceso, value); }

        //12.1 De las generalidades
        private AUD_ContenidoTablas generalidades12;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Generalidades12 { get => generalidades12; set => SetProperty(ref generalidades12, value); }

        //12.2 Garantía de calidad
        private AUD_ContenidoTablas garantiaCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas GarantiaCalidad { get => garantiaCalidad; set => SetProperty(ref garantiaCalidad, value); }

        //13.1 Generalidades
        private AUD_ContenidoTablas generalidades13;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Generalidades13 { get => generalidades13; set => SetProperty(ref generalidades13, value); }

        //13.2 Muestreo
        private AUD_ContenidoTablas muestreo;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Muestreo { get => muestreo; set => SetProperty(ref muestreo, value); }

        //13.3 Metodología analítica 
        private AUD_ContenidoTablas metodologiaAnalitica;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas MetodologiaAnalitica { get => metodologiaAnalitica; set => SetProperty(ref metodologiaAnalitica, value); }

        //13.4 Materiales de referencia 
        private AUD_ContenidoTablas materialesReferencia;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas MaterialesReferencia { get => materialesReferencia; set => SetProperty(ref materialesReferencia, value); }

        //13.5 De la estabilidad
        private AUD_ContenidoTablas estabilidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Estabilidad { get => estabilidad; set => SetProperty(ref estabilidad, value); }

        //14.1 Generalidades
        private AUD_ContenidoTablas generalidades14;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Generalidades14 { get => generalidades14; set => SetProperty(ref generalidades14, value); }

        //14.2 Retiros 
        private AUD_ContenidoTablas retiros;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Retiros { get => retiros; set => SetProperty(ref retiros, value); }

        //15.1 Generalidades
        private AUD_ContenidoTablas generalidades15;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Generalidades15 { get => generalidades15; set => SetProperty(ref generalidades15, value); }

        //15.2 Del contratante 
        private AUD_ContenidoTablas contratante;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Contratante { get => contratante; set => SetProperty(ref contratante, value); }

        //15.3 Del contratista 
        private AUD_ContenidoTablas contratista;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Contratista { get => contratista; set => SetProperty(ref contratista, value); }

        //16. Auto-inspección y auditorías de calidad
        private AUD_ContenidoTablas auditoriaCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AuditoriaCalidad { get => auditoriaCalidad; set => SetProperty(ref auditoriaCalidad, value); }





        //Datos Conclusión de Inspección
        private AUD_DatosConclusiones datosConclusiones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosConclusiones DatosConclusiones { get => datosConclusiones; set => SetProperty(ref datosConclusiones, value); }


        private void InicializaData()
        {
            //////////////////////
            ///
            InfoGeneral = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Razón social: ",
                        Criterio = "INFORMATIVO",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre de la empresa: ",
                        Criterio = "INFORMATIVO",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Dirección del domicilio legal de la empresa: ",
                        Criterio = "INFORMATIVO",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Dirección del laboratorio fabricante:  ",
                        Criterio = "INFORMATIVO",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Motivo de la inspección:  ",
                        Criterio = "INFORMATIVO",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            //////////////////////
            ///
            AuthFuncionamiento = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cuenta con licencia sanitaria o permiso sanitario de funcionamiento? ",
                        Criterio = "INFORMATIVO",
                        Articulo="5.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Indicar número: ",
                        Criterio = "INFORMATIVO",
                        Articulo="5.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha de vencimiento: ",
                        Criterio = "INFORMATIVO",
                        Articulo="5.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se desarrollan las operaciones de fabricación aprobadas en la licencia sanitaria o permiso sanitario? ",
                        Criterio = "CRITICO",
                        Articulo="5.2 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Formas farmacéuticas autorizadas: ",
                        Criterio = "INFORMATIVO",
                        Articulo="5.2 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ///////
            Organizacion = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un organigrama general y especifico actualizado de la empresa? Anexar copia cuando aplique ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.1.1 13.1.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe independencia de responsabilidades entre producción y control de la calidad? ",
                        Criterio = "CRITICO",
                        Articulo="6.1.1 13.1.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen descripciones de responsabilidades y funciones para cada puesto incluido en el organigrama? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se especifica el grado académico y las habilidades que el personal debe tener para ocuparlos? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio fabricante dispone de un Director Técnico o Regente Farmacéutico responsable de la calidad y seguridad de los productos que se fabrican y está presente durante el horario de su funcionamiento? ",
                        Criterio = "CRITICO",
                        Articulo="6.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Indicar nombre y número de colegiado o de inscripción profesional  ",
                        Criterio = "INFORMATIVO",
                        Articulo="6.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En casos de jornadas continuas o extraordinarias el regente garantiza los mecanismos de supervisión de acuerdo a la legislación nacional de cada Estado Parte? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            Personal = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Dispone el laboratorio fabricante de personal con la calificación y experiencia práctica según el puesto asignado?  ",
                        Criterio = "CRITICO",
                        Articulo="6.2.1 6.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las funciones asignadas a cada persona son congruentes con el nivel de responsabilidad que asumen de acuerdo a la descripción del puesto, y no constituyen un riesgo a la calidad del producto? ",
                        Criterio = "CRITICO",
                        Articulo="6.2.1 6.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los profesionales responsables o personal calificado de las unidades de investigación y desarrollo y garantía de la calidad (según requerimiento de la empresa), producción y control ¿tienen experiencia técnica para el puesto que ocupan? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros que el personal que labora en el laboratorio, cuenta con preparación académica, capacitación y experiencia o una combinación de esas condiciones, para ocupar el puesto asignado? ",
                        Criterio = "CRITICO",
                        Articulo="6.2.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            ResponPersonal = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo="Cumple el responsable de la Dirección o Jefatura de Producción con las siguientes responsabilidades",
                        Articulo = "6.3.1 ",
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Asegura que los productos se fabriquen y almacenen en concordancia con la documentación aprobada, a fin de obtener la  calidad prevista",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Aprueba los documentos maestros relacionados con las operaciones de producción, incluyendo los controles durante el proceso  y asegurar su estricto cumplimiento",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Verifica que la orden de producción esté completa y firmada por las personas designadas, antes de que se pongan a disposición  del departamento asignado",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Vigila el mantenimiento del departamento en general, instalaciones y equipo",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Garantiza que los procesos de producción, se realizan bajo los parámetros definidos",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Autoriza los procedimientos del departamento de producción y verificar que se cumplan",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Asegura que se lleve a cabo la capacitación inicial y continua del personal de producción y que dicha capacitación se adapte a  las necesidades",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Conserva la documentación del departamento de producción",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Otras funciones inherentes al puesto",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo="Cumple el responsable de la Dirección o Jefatura de Control de Calidad con las siguientes responsabilidades:",
                        Articulo = "6.3.2 ",
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Aprueba o rechaza, según procede, las materias primas, materiales de acondicionamiento, producto intermedio, a granel y  terminado",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Revisa que toda la documentación de un lote de producto que se ha finalizado, esté completa, la cual también puede ser  responsabilidad de garantía de calidad",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Aprueba las instrucciones de muestreo, métodos de análisis y otros procedimientos de control de calidad y verificar las  especificaciones.",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Aprueba y controla los análisis llevados a cabo por contrato a terceros. ",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Vigila el mantenimiento del departamento, las instalaciones y los equipos.",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Asegura que se lleve a cabo la capacitación inicial y continua del personal de control de calidad y que dicha capacitación se  adapte a las necesidades.",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Conserva la documentación del departamento de control de calidad",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Supervisa despejes de líneas y controles en proceso",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Otras funciones inherentes al puesto",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo="Cumple el responsable de la Dirección o Jefatura de Producción y Control de Calidad con las siguientes responsabilidades  compartidas:",
                        Articulo = "6.3.3 ",
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Autorizan los procedimientos escritos y otros documentos, incluyendo sus modificaciones",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Vigilan y controlan las áreas de producción",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Vigilan la higiene de las instalaciones de las áreas productivas",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Capacitan al personal a su cargo sobre las Buenas Prácticas de Manufactura",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Participan en la selección, evaluación (aprobación) y control de los proveedores de materiales, de equipo y otros, involucrados  en el proceso de producción",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Aprueban y controlan la fabricación por terceros",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Establecen y controlan las condiciones de almacenamiento de materiales y productos",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Conservan la documentación",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Vigilan el cumplimiento de las Buenas Prácticas de Manufactura",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Inspeccionan, investigan y muestrean con el fin de controlar los factores que puedan afectar a la calidad. ",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Participan en el manejo de quejas y reclamos",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Participan en el manejo de desviaciones",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },


                }
            };
            ////////
            Capacitacion = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento de inducción en BPM para nuevos empleados que incluye capacitación (teórica y práctica) específica en las funciones que desempeñarán? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen registros actualizados?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de capacitación continua en BPM para todo el personal incluyendo capacitación específica (las funciones propias del puesto, las regulaciones vigentes, los procedimientos escritos de Buenas Prácticas de Manufactura, todo lo relacionado con la función de su departamento)?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.2, 6.4.3 6.4.4, 6.4.5. 10.3.5 f)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza y se evalúa la capacitación al personal en BPM al menos 2 veces al año? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.2, 6.4.3 6.4.4, 6.4.5. 10.3.5 f)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza una evaluación de la ejecución del programa de capacitación al menos una vez al año? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.2, 6.4.3 6.4.4, 6.4.5. 10.3.5 f)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen registros? ",
                        Criterio = "CRITICO",
                        Articulo="6.4.2, 6.4.3 6.4.4, 6.4.5. 10.3.5 f)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            HigieneSalud = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿La admisión / contratación del personal es precedida de un examen médico? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio fabricante se responsabiliza de que el personal presente anualmente o de acuerdo a la legislación de cada país, la certificación médica o su equivalente, garantizando que no padece de enfermedades infectocontagiosas? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los procedimientos relacionados con la higiene personal incluyendo el uso de ropa protectoras, se aplican a todo el personal permanente o temporal y visitantes que ingresan a las áreas de producción? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe prohibición que el personal con signos de enfermedad o que sufre de lesiones abiertas no manipule materia prima o productos en proceso, hasta que se considere que la condición ha desaparecido?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es obligatorio para el personal que participa en los procesos de fabricación informar sobre sus condiciones de salud que puedan afectar negativamente la calidad de los productos? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los uniformes, del personal destinado a la producción, que están en contacto directo con los productos, cumple con las siguientes características: ¿manga larga, limpio, sin bolsas en la parte superior de la vestimenta, confortable y confeccionada con un material que no desprenda partículas, con cierres ocultos y en buenas condiciones? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el personal con equipo de protección, gorros que cubran la totalidad del cabello, mascarillas, guantes, protección de ojos y oídos en procesos donde se requiera y zapato cerrado para áreas de producción? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay procedimientos escritos donde se establezcan el uso correcto y el tipo de uniforme a utilizar en cada área?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "Existen rótulos de prohibiciones al ingreso de las áreas de producción, Control de Calidad y cualquier otra área donde esas  actividades puedan influir negativamente en la calidad de los productos sobre: ",
                        Criterio = "",
                        Articulo="6.5.6",
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) No comer, beber, fumar, masticar, así como guardar comida, bebida, cigarrillos, medicamentos personales",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) No usar maquillaje, joyas, relojes, teléfonos celulares e instrumentos ajenos al uniforme, así como manipular dinero en áreas  de riesgo para los productos",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) No llevar barba o bigote al descubierto, durante la jornada de trabajo en los procesos de dispensado, producción y empaque primario",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) No usar el uniforme fuera de las áreas para la que fue diseñado.",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "",
                        Articulo="",
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registro de la capacitación sobre hábitos higiénicos al personal involucrado en el proceso de producción?",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se instruye al personal a lavarse las manos antes de ingresar a las áreas de producción?",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe en todas las áreas de vestidores y servicios sanitarios rótulos que indiquen la obligación de lavarse las manos antes de salir  de este lugar?",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza controles microbiológicos de manos del personal de acuerdo a programas y procedimientos establecidos? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El acceso a las áreas de producción y control de calidad es restringido? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen rótulos que indiquen que sólo el personal autorizado puede ingresar a aquellas áreas de los edificios e instalaciones  designadas como de acceso restringido?",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de ingresar visitantes o personal no capacitado a las áreas de producción, es supervisado por un acompañante autorizado  y se cumplen los procedimientos de higiene personal y el uso de ropas protectoras?",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta la empresa con un botiquín o un área destinada a primeros auxilios, suficientemente dotado para un adecuado  funcionamiento?",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                }
            };
            ////////
            UbicacionDisenoConstruc = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las instalaciones están diseñadas, construidas, y se mantienen de acuerdo a las operaciones que se realizan?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Su disposición y diseño permite el flujo adecuado de personal y materiales, la limpieza y el mantenimiento efectivo para evitar la contaminación cruzada, la confusión y errores, la acumulación de polvo o suciedad, protegida contra el ingreso de plagas? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El edificio está ubicado lejos de fuentes de contaminación?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cuenta con planos y diagramas actualizados de lo siguiente? ",
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a. Planos de construcción y remodelaciones.  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b. Plano de distribución de áreas. ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c. Diagrama de flujo de personal.  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d. Diagrama de flujo de materiales.  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e. Diagrama de flujo de procesos ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f. Plano o diagramas cuando aplique, de servicios (sistemas de inyección y extracción de aire, aire comprimido, aguas, desagües, aguas servidas, aguas negras, electricidad, vapor, vapor puro y gases, cuando aplique).  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g. Plano o diagrama de evacuación del personal en caso de emergencia y plano o diagrama de ubicación de salidas de emergencia, señalando la ubicación de los extintores y las lámparas de emergencia. ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h. Diagrama del sistema de tratamiento de aguas para la producción.  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "",
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de mantenimiento preventivo de las instalaciones? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas de acceso restringido están debidamente delimitadas e identificadas?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas de producción, empaque, almacenamiento y control de calidad no se utilizan como lugar de paso por el personal que no trabaje en las mismas? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los pasillos de circulación ¿se encuentran libres de materiales, equipos y productos en tránsito? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los drenajes no permiten la contracorriente y tienen tapa sanitaria? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son las áreas exclusivas para el uso previsto y se mantienen libres de objetos y materiales extraños al proceso?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas se encuentran separadas físicamente e identificadas para las diferentes etapas de manufactura, tomando en cuenta el flujo, tamaño y espacio de acuerdo a sus procesos? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las tuberías, artefactos lumínicos, puntos de ventilación y otros servicios, ¿están diseñados y ubicados, de tal forma que no dificulten la limpieza?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentran en buen estado? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas del laboratorio permiten que los equipos y materiales estén ubicados de forma que eviten el riesgo de confusión, contaminación cruzada y omisión entre los distintos productos y sus componentes en cualquiera de las operaciones de producción, control y almacenamiento? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = " ¿Existe protección contra el ingreso de insectos y otros animales? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio dispone de equipamiento para el cumplimiento de la normativa de seguridad industrial vigente en cada uno de los Estados Parte?",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las condiciones ambientales (iluminación, temperatura, humedad y ventilación), ¿no influyen negativamente, directa o indirectamente en los productos, durante su producción y almacenamiento? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las áreas ¿Están diseñadas y adaptadas para que las condiciones de iluminación, temperatura, humedad y ventilación no influyan directa o indirectamente de forma negativa en los productos durante su producción y almacenamiento? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de temperatura y humedad? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
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
                        Titulo = "¿Tienen las áreas de almacenamiento suficiente capacidad para permitir el almacenamiento ordenado de las diferentes categorías de materiales y productos de acuerdo a las necesidades de la empresa? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están debidamente identificados, ordenados y en buenas condiciones de mantenimiento? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los pisos, paredes y techos están en buen estado de conservación e higiene, son de fácil limpieza, y no afectan la calidad de los materiales y productos que se almacene? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las estanterías y tarimas están separadas de pisos y paredes de manera que permitan la limpieza e inspección del almacén?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están debidamente identificados, ordenados y en buenas condiciones de mantenimiento?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las áreas de recepción y despacho, de los productos y materiales ¿están protegidos de las condiciones ambientales? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está diseñada de forma que los contenedores puedan limpiarse si fuese necesario antes de su almacenamiento?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas de cuarentena de materiales y productos están definidas y marcadas y el acceso a las mismas se limita a personal autorizado? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área físicamente separada e identificada para el muestreo de materias primas?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿De no existir dicha área, el muestreo se realiza en el área de pesaje o dispensado de tal forma que impida la contaminación y la contaminación cruzada? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales y productos rechazados, retirados del mercado o devueltos son almacenados en un área separada, identificada y de acceso restringido? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = " ¿Existe un área para almacenamiento de productos inflamables? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área separada, identificada, bajo llave y de acceso restringido para almacenar materiales impresos (etiqueta, estuches, insertos y envases impresos)? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            AreaRecepLimpieza = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿De ser necesario el laboratorio cuenta con un área para la recepción, limpieza, segregación y acondicionamiento de la materia prima natural fresca o seca?,  ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1 10.3.5 f) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },


                    new ContenidoTablas()
                    {
                        Titulo = "El área para la recepción, limpieza, segregación y acondicionamiento de la materia prima natural fresca o seca tiene las siguientes  características",
                        IsHeader=true,
                        Articulo="7.3.2 ",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Está separada?",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Tiene pisos, paredes y techos de fácil limpieza y está cerrada?",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Están protegidas de la incidencia de la luz directa?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Cuentan con recolectores de polvo y sistema de inyección y extracción de aire, cuando aplique? ",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "",
                        IsHeader=true,
                        Articulo="",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el área para la recepción, limpieza, segregación y acondicionamiento, se colocan las materias primas identificada sobre mesas, tarimas o estanterías que permitan el proceso de tratamiento? ",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            AreaSecadoMolienda = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen áreas independientes y separadas físicamente para llevar a cabo las siguientes operaciones? ",
                        IsHeader=true,
                        Articulo="7.4.1 ",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Secado ",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Molienda ",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Extracción.  ",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },


                    new ContenidoTablas()
                    {
                        Titulo = "Las áreas donde se realizan las operaciones de secado, molienda y extracción cuentan con las siguientes características:",
                        IsHeader=true,
                        Articulo="7.4.2",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Son de uso exclusivo? ",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Tienen paredes, pisos y techos de fácil limpieza? ",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Están protegidas de la incidencia de la luz directa?  ",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Cuentan con recolectores de polvo y sistema de inyección y extracción de aire, cuando aplique? ",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                }
            };
            ////////
            AreaDispensadoMatPrima = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área físicamente exclusiva identificada como área restringida para el dispensado (pesado)? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.5.1. ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "Con las siguientes características: ",
                        IsHeader=true,
                        Articulo="7.5.1. ",
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "a) ¿Posee paredes, pisos y techos lisos, con curvas sanitarias ",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "b) ¿Limpia y ordenada? ",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "c) ¿Con sistema de inyección y extracción de aire? ",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "d) ¿Condiciones controladas de temperatura y humedad, si se requiere? ",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "e) ¿Adecuadamente iluminada? ",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "f) ¿Con la advertencia que no debe utilizarse como área de lavado o como área de almacenamiento? ",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                     new ContenidoTablas()
                    {
                        Titulo = "¿El soporte donde se colocan las balanzas y otros equipos sensibles es capaz de contrarrestar las vibraciones que afecten su buen funcionamiento? ",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿La capacidad y sensibilidad de las balanzas, utensilios calibrados corresponden con las cantidades que se pesan y se miden?  ",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área delimitada e identificada en la que se colocarán las materias primas que serán pesadas y las materias primas dispensadas que serán utilizadas en la producción? ",
                        Criterio = "CALIFICABLE",
                        Articulo="",
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
                        Titulo = "Las áreas de producción, ¿cuentan con el tamaño, diseño y servicios adecuados (ventilación, agua, luz y otros), para efectuar los procesos de producción?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "Tienen las áreas de producción y empaque primario las siguientes condiciones",
                        IsHeader=true,
                        Articulo="7.6.2 7.7.1",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Están identificadas y separadas para la producción y empaque primario de sólidos, líquidos y semisólidos, tienen paredes, pisos y techos lisos, con curvas sanitarias, sin grietas ni fisuras, no utilizan madera, no liberan partículas y permite su limpieza y  sanitización?",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Las tuberías y puntos de ventilación son de materiales que permiten su fácil limpieza y están correctamente ubicados?",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Las tomas de gases, fluidos y eléctricas están identificadas y en buen estado?",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Las ventanas de vidrio fijo, lámparas y difusores lisos y empotrados son de fácil limpieza y evitan la acumulación de polvo?",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Tienen inyección y extracción de aire que permite una ventilación adecuada? ",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Mantienen registros de temperatura y humedad?",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) ¿Se garantiza que las áreas productivas, no son utilizadas como áreas de paso?",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) ¿Están libres de materiales y equipo que no estén involucrados en el proceso?",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área exclusiva destinada para el lavado de equipos móviles, recipientes y utensilios?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.3 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El área se mantiene en buenas condiciones de orden y limpieza, cuenta con curvas sanitarias y servicios para el trabajo que allí  se ejecuta?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.3 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área identificada, limpia, ordenada y separada para colocar equipo y utensilios limpios que no se esté utilizando? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.4 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Todas las mangueras, tubos y tuberías y otros utensilios empleados en la transferencia de fluidos ¿Están identificadas y en buen  estado de conservación? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.4 10.3.5 c) ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            AreaEnvasadoEmpaque = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Las áreas de empaque secundario tienen las siguientes condiciones:",
                        IsHeader=true,
                        Articulo="7.7.2 7.7.2.1 ",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Están separadas, identificadas y son de tamaño adecuado? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Tienen paredes, pisos y techos lisos, sin grietas, ni fisuras y son de fácil limpieza? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿No se utiliza madera en esta área? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Tiene identificadas la toma de energía eléctrica?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Tienen ventanas fijas y lámparas con difusores lisos, que sean de fácil limpieza y eviten la acumulación de polvo? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Cuentan con ventilación e iluminación que asegure condiciones confortables al personal y no afecte negativamente la calidad  del producto?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            AreaAuxiliares = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Los vestidores y servicios sanitarios están:",
                        IsHeader=true,
                        Articulo="7.8.1 ",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a. Identificados correctamente.",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b. Un número de servicios sanitarios para hombres y para mujeres de acuerdo al número de trabajadores.",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c. Mantenerse limpios y ordenados",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d. Deben existir procedimientos y registros para la limpieza y sanitización. ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e. Los servicios sanitarios deben estar accesibles a las áreas de producción, pero no deben comunicarse directamente",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f. Deben contar con lavamanos y duchas. ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g. Disponer de espejos, toallas de papel o secador eléctrico de manos, jaboneras con jabón líquido desinfectante y papel higiénico",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h. Los vestidores deben estar separados de los servicios sanitarios por una pared.",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i. Casilleros, zapateras y las bancas necesarias (deben ser de un material adecuado que no libere partículas y no provoque  contaminación).",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j. Rótulos o letreros que enfaticen la higiene personal. ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "K. Se prohíbe mantener, guardar, preparar y consumir alimentos en esta área. ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1 ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "¿El área comedora está identificada, en buenas condiciones de orden y limpieza y separada de las demás áreas?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área de lavandería para los uniformes? ¿Se encuentra separada de las áreas productivas",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.3 10.3.5 g)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos para el lavado y preparación de uniformes? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.3 10.3.5 g)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.3 10.3.5 g)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio cuenta con un área exclusiva para el lavado de los utensilios de limpieza? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área o armario exclusivo para almacenar los utensilios utilizados en la limpieza?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen instrucciones escritas para mantener en buen estado el área y los utensilios de limpieza?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área de mantenimiento o un espacio para el almacenamiento de herramientas o implementos utilizados para el  mantenimiento que este separado de las áreas productivas? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Excepcionalmente en el caso de no contar con un área de mantenimiento, el laboratorio posee procedimientos escritos y registros  donde se describa las actividades realizadas de mantenimiento?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de contar con equipo obsoleto o en mal estado que no interviene en los procesos se dispone de un área exclusiva para  almacenar dicho equipo? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "Si el laboratorio realiza investigación y desarrollo cuenta con un área con las siguientes condiciones:",
                        IsHeader=true,
                        Articulo="7.8.6",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Es exclusiva y está identificada?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Tiene paredes lisas de fácil limpieza?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Cuenta con el equipo necesario para las operaciones que realiza?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.6",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                }
            };
            ////////
            AreaControlCalidad = new AUD_ContenidoTablas
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área destinada para el laboratorio de control de calidad que se encuentre identificada y separada del área de producción? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "El laboratorio de control de calidad tiene las siguientes condiciones:",
                        IsHeader=true,
                        Articulo="7.9.2",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Está diseñado de acuerdo a las operaciones que realiza, las áreas para controles fisicoquímicos y microbiológicos se encuentran  físicamente separados.",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Tiene paredes lisas que faciliten su limpieza. ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Dispone de suficiente espacio para evitar confusiones y contaminación cruzada",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Disponer de área de almacenamiento en condiciones adecuadas para las muestras, reactivos, patrones de referencia (cuando  aplique), muestras de retención, archivos, bibliografía, documentación y cristalería. ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Existen equipos de seguridad según la normativa de seguridad industrial ocupacional vigente de cada Estado parte? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "¿El área instrumental está diseñada para proteger el equipo e instrumentos sensibles del efecto de las vibraciones, interferencias  eléctricas, humedad y temperatura y las que el fabricante del equipo recomiende? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.3",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "El área de microbiología cuenta con:",
                        IsHeader=true,
                        Articulo="7.9.4",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Paredes, techos, pisos lisos de fácil limpieza y curvas sanitarias.",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Lámparas con difusor liso.",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c)Campana sanitaria o de flujo laminar",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Mesa de trabajo lisa",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Ventanas de vidrio fijo",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con procedimiento escrito y registros que evidencien los controles realizados durante el proceso?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },


                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un espacio exclusivo destinado al lavado de cristalería y utensilios utilizados en el laboratorio? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con instrucciones para el lavado? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El espacio se encuentra en buenas condiciones de orden y limpieza?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.9.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                }
            };
            ////////
            Generalidades8 = new AUD_ContenidoTablas
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "El equipo utilizado en la producción: ¿Está diseñado, construido y ubicado de tal forma que facilite las operaciones relacionadas  con su limpieza, mantenimiento y uso, con el fin de evitar la contaminación cruzada y todo aquello que pueda influir negativamente  en la calidad de los productos de acuerdo a las operaciones que en el mismo se realizan? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el equipo con un código de identificación único? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La superficie de los equipos en contacto directo con la materia prima o productos en proceso ¿no son reactivos, aditivos o  absorbentes?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La ubicación de los equipos:",
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿No obstaculiza los movimientos del personal?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Asegura el orden durante los procesos y minimiza el riesgo de confusión u omisión de alguna etapa del proceso? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿Facilita las operaciones para las cuales será utilizado, así como su limpieza y mantenimiento?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Esté físicamente separado y cuando sea necesario aislado de cualquier otro equipo, para evitar el congestionamiento de las  áreas de producción; así como la posibilidad de contaminación cruzada?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los equipos empleados en producción, control de calidad, empaque y almacenaje cuentan con un procedimiento escrito en donde  se especifiquen en forma clara las instrucciones, precauciones y registros para su operación? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las operaciones de reparación y mantenimiento de los equipos se realizan de tal forma que no representan riesgos para la calidad  de los productos?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza la limpieza de equipos y utensilios de acuerdo a procedimientos escritos?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El procedimiento escrito indica que solamente los equipos pesados e inmóviles serán lavados y sanitizados en el área de  producción?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Al equipo limpio se le coloca una etiqueta que indique lo siguiente? ",
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre e identificación del equipo",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Fecha cuando fue realizada la limpieza",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Nombre e identificación de lote del último producto fabricado",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Nombre e identificación de lote del producto a fabricar, (cuando aplique) ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Firma del operario que realizó la limpieza y de quien la verificó ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de mantenimiento preventivo y procedimientos de mantenimiento preventivo y correctivo de los equipos, de  producción y control de calidad?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registra su cumplimiento?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se identifican los equipos en mantenimiento?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen registros de los mantenimientos realizados que incluyan",
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre e identificación del equipo ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Fecha de realizado el mantenimiento ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Descripción breve de lo realizado",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Firma de las personas responsables de la ejecución, supervisión y recepción del mantenimiento realizado",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            Calibracion = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿La calibración de los instrumentos de medición, y dispositivos de registro o cualquier otro, se realiza a intervalos convenientes y  establecidos de acuerdo con un programa escrito que incluya frecuencia, límite de exactitud, precisión y previsiones para medidas  preventivas y correctivas?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se utilizan únicamente instrumentos que cumplen con las especificaciones establecidas?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen registros escritos de las inspecciones, verificaciones y calibraciones realizadas?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se usan patrones de referencia certificados para la calibración de cada equipo que lo requiera? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            SistemaAgua = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene, el laboratorio, un suministro de agua potable?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Red pública?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Pozos?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Otros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de ser necesario, ¿se hace algún tratamiento para potabilizar el agua antes de su almacenamiento?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El tratamiento elegido ¿garantiza la potabilización, de acuerdo a los requerimientos de cada país?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta con un sistema de tratamiento de agua que le permita obtener agua purificada que cumpla con las especificaciones de  acuerdo a los libros oficiales para la producción de sus productos?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Qué sistema utiliza?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Resinas de intercambio iónico?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Ósmosis Inversa?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Otro sistema?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cual?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para operar el sistema que abarquen las instrucciones y precauciones para su manejo?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos de limpieza y desinfección de tanques o cisternas de agua, que incluyan una frecuencia de  realización y puntos de muestreo? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuentan con registros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros del monitoreo continuo del sistema de tratamiento del agua purificada?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de mantenimiento preventivo del sistema de agua purificada?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El Laboratorio posee tanques de almacenamiento de agua? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El agua purificada ¿es almacenada?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El tanque o la cisterna para almacenamiento están construidos con material que asegure su calidad?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de que el agua purificada se almacene por más de 24 hrs, esta se mantiene en recirculación?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las tuberías, tomas de fluidos y sistemas de almacenamiento, ¿Cuentan con procedimiento de monitoreo y sanitización?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son rotados los sitios de muestreo de modo de cubrir todos los puntos de uso?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para el muestreo de agua?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles fisicoquímicos al agua potable?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles microbiológicos al agua potable?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles fisicoquímicos al agua purificada?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles microbiológicos al agua purificada?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de que estos controles se salgan de los límites establecidos se investiga y se toman medidas correctivas?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            SistemaAire = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen sistemas de inyección y extracción de aire que eviten el riesgo de la contaminación de los productos y las personas, para  cada área de producción dependiendo de los productos que en ellas se manipulen, a las operaciones realizadas y del ambiente  exterior?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La ubicación del sistema facilita la limpieza y el mantenimiento?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sistema de inyección y extracción de aire evita el riesgo de contaminación cruzada entre productos y procesos?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El sistema de inyección y extracción de aire incluye filtros, pre filtros y equipo necesario que garantiza la calidad del aire?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cuenta con procedimientos escritos que abarquen las instrucciones y precauciones para el manejo de los equipos?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de mantenimiento preventivo documentado, que abarque los controles periódicos del sistema de aire que  suministra a las diferentes áreas de producción? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento de mantenimiento preventivo que establece la periodicidad para el cambio de filtros y pre filtros, con el  fin de mantener su eficacia?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se toman las precauciones necesarias para que las operaciones de mantenimiento y reparación no pongan en riesgo la calidad de  los productos? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros escritos del mantenimiento preventivo y correctivo de los equipos del sistema de aire?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan controles microbiológicos al Sistema de aire de acuerdo al programa y procedimientos establecidos, para garantizar  la calidad de aire de las áreas de producción?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de que estos controles se salgan de los límites establecidos se investiga y se toman medidas correctivas?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            Generalidades9 = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Permanece cada lote de materiales y productos terminados en cuarentena mientras no sea muestreado, examinado y analizado por  control de calidad para su liberación",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza un examen visual en la recepción de los materiales, para verificar que los envases no presenten deterioro o daño y que  sus cierres estén íntegros, para no afectar la calidad del producto?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentren debidamente identificados y se verifica que exista correspondencia entre las especificaciones establecidas por el  laboratorio y las etiquetas del proveedor?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Para la utilización de la materia prima almacenada se sigue el sistema Primero que Vence Primero que Sale.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales y productos, se almacenan de tal manera que se evite la contaminación o cualquier situación que ponga en riesgo  su calidad? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las materias primas de origen natural que requieren de condiciones especiales de humedad, temperatura y protección contra la  luz, ¿son almacenadas bajo control de estos parámetros? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿se ubica sobre tarimas o estantes separadas de las paredes y techos facilitando su limpieza? ¿se encuentran debidamente rotulados?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos y registros para todas las operaciones que se realizan en esta área? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Recepción",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Identificación",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Almacenamiento",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Manejo",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Muestreo",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Análisis",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Aprobación o rechazo de materiales y productos conforme a la especificación de cada uno de los mismos",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cada lote de material de envase o empaque recibido es rotulado a su ingreso, con una etiqueta que incluye: ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre y código del material.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Número de ingreso asignado por el laboratorio",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Situación del material (cuarentena, aprobado, rechazado).",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Nombre del proveedor.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Fecha y número de análisis.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Cantidad.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Fecha de ingreso.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Nombre y firma del responsable que llenó la etiqueta.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cada envase de materia prima está identificado con una etiqueta que incluya: ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a. Nombre de la materia prima o identificación de la droga natural.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b. Código interno.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c. Nombre del fabricante u origen",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d. Nombre del proveedor",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e. Cantidad del material ingresado",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f. Código o número de lote del fabricante",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g. Fecha de fabricación",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h. Fecha de expiración, cuando aplique",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i. Fecha de ingreso",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j. Condiciones de almacenamiento, cuando requiera",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k. Advertencias y precauciones, cuando requiera",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l. Fecha de análisis",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "m. Fecha de re-análisis, siempre y cuando no haya expirado",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "n. Estado o situación (cuarentena, muestreado, aprobado o rechazado). ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "o. Observaciones",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las materias primas son removidas de los envases originales y trasvasados a otro envase? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se garantiza que el nuevo recipiente es inodoro, limpio, sanitizado, no reactivo? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es toda la materia prima muestreada, examinada y analizada de acuerdo a procedimientos escritos?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es toda la materia prima aprobada de acuerdo a sus especificaciones?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿De no cumplir con especificaciones se rechaza? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El agua purificada ¿es utilizada como materia prima para la manufactura?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La materia prima que ha estado expuesta a condiciones extremas (aire, temperatura, humedad o cualquier otra condición que  pudiera afectarla negativamente), es separada e identificada de inmediato según procedimiento escrito?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de calidad aprueba o rechaza de acuerdo con los resultados obtenidos luego del análisis, las materias primas que se  encuentran bajo esta condición? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los materiales aprobados ¿son debidamente identificados? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se asegura la utilización de materias primas aprobadas por control de calidad y que no hayan expirado? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para la manipulación de materiales y productos intermedios, a granel y terminados que han sido  rechazados?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se identifican los materiales y productos rechazados con una etiqueta roja justificando la causa del rechazo?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los envases/empaques primarios, proporcionan una protección adecuada al producto, contra factores externos durante su  almacenamiento, que pudieran causar su deterioro o contaminación?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los envases, cierres y medidas dosificadoras y envases primarios están sanitizados y se manipulan de acuerdo a procedimientos  escritos antes de ser puestos en contacto con el producto? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            DispensadoMatPrima = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las materias primas son fraccionadas por personal designado para tal fin siguiendo un procedimiento escrito?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se verifica que las materias primas se pesan o se miden en forma precisa y exacta, en recipientes limpios e identificados?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el procedimiento escrito se indica que no deben dispensarse varios lotes al mismo tiempo de diferente producto?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cada recipiente conteniendo materia prima dispensada se identifica con una etiqueta con la siguiente información",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre de la materia prima.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Código o número de lote o número de ingreso.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Nombre del producto a fabricar.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Código de lote del producto a fabricar. ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Contenido neto (Sistema Internacional de Unidades SI)",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Fecha de dispensado",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Nombre y firma de la persona que dispensó",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Nombre y firma de la persona que verificó.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los materiales, después de ser pesados o medidos ¿son agrupados e identificados de forma visible a fin de evitar confusiones?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            MatAcondicionamiento = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los envases y cierres primarios son de material que no sea reactivo, aditivo o adsorbente al producto? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cumplen los envases y cierres primarios con las especificaciones establecidas por el laboratorio? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales de acondicionamiento son examinados respecto a su cantidad, identidad y conformidad con las respectivas  instrucciones de la orden de envasado, antes de ser enviados al área? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            ProdAGranel = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se manipulan y almacenan los productos a granel de tal manera que se evite cualquier contaminación o riesgo en la calidad de  los productos? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            ProdTerminados = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Los productos terminados ¿son comercializados solamente después de su aprobación y liberación por control de calidad? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            ProdRechazados = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento de destrucción de materiales y productos rechazados?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Todo material obsoleto o desactualizado, es destruido según procedimiento y se registra el destino del mismo?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            ProdDevueltos = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito que defina las personas responsables y los criterios de manejo de los productos devueltos? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Se investiga y analiza de acuerdo a un procedimiento escrito los productos devueltos por reclamos de calidad?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área separada de acceso restringido para productos devueltos debidamente identificados, hasta que se decida su destino?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Se investigan y destruyen de acuerdo a un procedimiento escrito los productos devueltos por vencimiento o que hayan sido  sometidos a condiciones inadecuadas de almacenamiento?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros que incluyan la siguiente información: ¿nombre, forma farmacéutica, número de lote, motivo de la devolución,  cantidad devuelta y fecha de la devolución?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            Generalidades10 = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están las especificaciones, fórmulas, métodos e instrucciones de fabricación, procedimientos y registros en forma impresa o  electrónica, debidamente revisadas y aprobadas? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Están los documentos elaborados, revisados, aprobados y distribuidos de acuerdo a un procedimiento escrito? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "Cada Procedimiento",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "a) ¿Está redactado en forma clara, ordenada y libre de expresiones ambiguas permitiendo su fácil comprensión?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "b) ¿Es fácilmente verificable?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "c) ¿Existen registros de que los procedimientos se revisan periódicamente y se mantienen actualizados? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "d) ¿Es reproducido en forma clara, legible e indeleble?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento de control de las copias de los documentos?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Los documentos son aprobados, fechados y firmados por personas autorizadas?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Las modificaciones están autorizadas?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Se cuenta con procedimientos para la modificación de los documentos que impida el uso de versiones obsoletas? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿La introducción de datos se realiza con letra clara legible y con tinta indeleble? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Existe en los documentos que lo requieran, espacio para permitir la realización del registro de datos? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "En caso de almacenar la información de forma electrónica se lleva a cabo lo siguiente:",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Se crean controles especiales? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Sólo las personas autorizadas tienen acceso o modifican los datos en la computadora? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de los cambios y las eliminaciones?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Está el acceso restringido por contraseñas u otros medios?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "Si se observan modificaciones de un dato escrito en un documento, la enmienda realizada ¿está fechada, firmada y permite visualizar el dato original?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Indica la causa de la corrección, cuando sea necesario?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Existe registro de todas las acciones efectuadas o completadas de tal forma que haya trazabilidad de todas las operaciones de los  procesos de fabricación de los productos? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen todos los registros incluyendo lo referente a los procedimientos de operación, un año después de la fecha de  expiración del producto terminado?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Existe un listado maestro de documentos disponible?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Se identifica el estado de los mismos?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentran disponibles en cada área o sector productivo todos los procedimientos operativos estandarizados (Procedimiento Escritos) que se aplican en cada uno de ellos?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "En todas las áreas donde se efectúen operaciones ¿Existen copias controladas de los documentos vigentes? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Son retirados los documentos invalidados u obsoletos de todos los puntos de uso? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Existe un archivo histórico identificado para almacenar los originales de los documentos obsoletos?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            DocumentosExigido = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen especificaciones autorizadas y fechadas por control de calidad para? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Materias primas",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Materiales de envase y empaque",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Productos intermedios (semielaborados)",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Productos a grane",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Producto terminado.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las especificaciones de la materia prima, material de envase, empaque, productos intermedios o granel y producto terminado,  incluyen:",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del material o producto, (denominación común internacional, nombre científico cuando corresponda)",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Código de referencia interna",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Referencia, si la hubiere, de los libros oficiales vigentes.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fórmula química (cuando aplique)",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Requisitos cuali y cuantitativos con límites de aceptación (cuando aplique)",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Muestra del material impreso (cuando aplique).",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Condiciones de almacenamiento y precauciones (cuando aplique)",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Proveedores aprobados y marcas comerciales (cuando aplique)",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Descripción de la forma farmacéutica y detalles de empaque (cuando aplique).",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Estabilidad (cuando aplique).",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Vida útil para material de acondicionamiento",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Fecha de vencimiento para productos terminados.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las especificaciones de las materias primas naturales incluyen:",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre científico de la materia prima vegetal o animal o nombre de la materia prima mineral.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Parte utilizada y su estado",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Detalles de la procedencia (país o región de origen)",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Descripción de la materia prima, basado en la inspección organoléptica y macromorfológica.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Contenido de materias extrañas",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Contenido de humedad. ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Características microbiológicas",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Contaminación por plaguicidas, metales pesados o aflatoxinas, cuando aplique",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza una revisión periódica de las especificaciones analíticas?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están de acuerdo a los libros oficiales vigentes? (cuando aplique) ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe una fórmula maestra actualizada y autorizada para cada producto?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La fórmula maestra incluye lo siguiente? ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre y código del producto correspondiente a su especificación",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Número de registro sanitario. ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Descripción de la forma farmacéutica.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fecha de emisión.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Nombre de la Persona responsable que la emitió y su firma",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Fecha de aprobación",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Nombre de la Persona responsable que la aprobó y su firm",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Fórmula cuali-cuantitativa por unidad de dosis expresada en sistema internacional",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Código y nombre de la materia prima",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j). Proceso de manufactura",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Precauciones y medidas especiales durante el proceso de fabricación.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Equipo a usar",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "m) Análisis intermedios (control en procesos).",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "n) Especificaciones.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "o) Cualquier otro documento que se considere necesario.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En caso de ser necesario modificar la fórmula maestra, ¿existen procedimientos escritos sobre la revisión y actualización del  documento?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Coincide la fórmula maestra con la fórmula presentada en la documentación para la obtención de Registro Sanitario?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se comunican los cambios que afectan el registro sanitario del producto a la Autoridad Reguladora?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Todos los productos y sus presentaciones comercializados tienen su registro sanitario vigente?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se emite una orden de producción para cada lote de producto procesado?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Coincide la fórmula maestra con la declarada en la orden de producción?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está autorizada por personal responsable?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La Orden de producción además de lo indicado en la formula maestra contiene los siguientes datos",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Tamaño del lote.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Fecha de emisión. ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Número de lote",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fecha de inicio y finalización de la producción",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Fecha de expiración del producto.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Firma de las personas que autorizan la orden de producción.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Número de lote de la materia prima.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Firma de la persona que despacha, recibe y verifica los insumos.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Firma de las personas que intervienen y supervisan los procesos",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Instrucciones para la toma de muestras en las etapas que sean necesarias.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Resultados de los análisis del producto en proceso cuando aplique",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Registro de controles durante el proceso y espacio para anotar observaciones.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "m) Declaración del rendimiento real y teórico con los límites de aceptación.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "n) Indicaciones de las precauciones necesarias para el almacenamiento del producto a granel si fuera necesario.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "o) Fórmula aplicada al tamaño de lote. ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta la orden de envasado y empaque con la siguiente información?",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre completo y código del producto",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Forma farmacéutica ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Número de registro sanitario.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d)Tamaño del lote",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Fecha de emisión",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Número de lote",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Cantidad del producto a envasar o empacar.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Fecha de inicio y finalización de las operaciones de acondicionamiento.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Fecha de expiración del producto. ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Firma de las personas que autorizan la orden de envase y empaque",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Cantidad y número de lote de cada material de envase y empaque a utilizar.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Firma de la persona que despacha, recibe y verifica los insumos. ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Firma de la persona que despacha, recibe y verifica los insumos. ",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "n) Registro de controles durante el proceso y espacio para anotar observaciones",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "o) Muestras del material de acondicionamiento impreso que se haya utilizado, incluyendo muestras con el número de lote, fecha  de expiración y cualquier impresión suplementaria, en caso de que no se pueda adjuntar a la orden de producción las muestras  indicadas, se debe asegurar su trazabilidad a una muestra retenida",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "p) Cantidades de los materiales impresos de acondicionamiento que han sido devueltos al almacén o destruidos y las cantidades de producto obtenido.",
                        Criterio = "CRITICO",
                        Articulo="7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            ProcedimientoReg = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se dispone de procedimientos escritos para el control de la producción y demás actividades relacionadas?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registra la ejecución de las actividades respectivas firmándolas de conformidad con el registro de firmas, inmediatamente  después de su realización?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Queda registrado y justificado cualquier desviación de los procedimientos, por un evento atípico que afecta la calidad del  producto?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cada lote de producto cuenta con los registros generados en producción y control que garantizan el cumplimiento de los  procedimientos escritos y aprobados?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para archivar y conservar la documentación de un lote cerrado de producción por lo menos hasta  un año después de la fecha de vencimiento del lote?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen procedimientos y registros escritos correspondientes a las actividades realizadas sobre:",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Mantenimiento, limpieza y sanitización de edificios e instalaciones. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Uso, mantenimiento, limpieza y sanitización de equipos y utensilios.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Sanitización y mantenimiento de tuberías y de las tomas de fluidos.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Calibración de equipo",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Asignación de número de lote.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Capacitación del personal.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Uso y lavado de uniformes.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Control de las condiciones ambientales",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Prevención y exterminio de plagas con insecticidas y agentes de fumigación.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Indica las sustancias utilizadas para tal fin? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las sustancias empleadas ¿Están autorizadas por la Autoridad competente?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El procedimiento garantiza que se evite que rodenticidas y/o agentes fumigantes contaminen materias primas, materiales de  acondicionamiento, productos semielaborados y productos terminados?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Recolección, clasificación y manejo de basuras y desechos. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Muestreo",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Cualquier otro que sea necesario.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe procedimiento para el manejo y eliminación de desechos químicos y microbiológicos?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La unidad de control de calidad tiene a su disposición lo siguiente:",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Especificaciones de toda materia prima, producto a granel, producto terminado y material de acondicionamiento.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Procedimiento para manejo de muestra de retención. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Metodología analítica para el análisis de materia prima y producto terminado, con su referencia (cuando aplique).",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Procedimientos de control y resultados de las pruebas (incluyendo los documentos de trabajo utilizados en el análisis y registros  de laboratorio).",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Informes / certificados analíticos.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Registro de las condiciones ambientales, cuando aplique.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Procedimientos y registros de métodos de ensayo",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Procedimientos y registros para la calibración de instrumentos y equipos. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Procedimientos y registros del mantenimiento del equipo. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Procedimiento de selección y calificación de proveedores. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Procedimiento y programa de sanitización de áreas",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Procedimiento para el uso de instrumenta",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "m) Procedimiento para aprobación y rechazo de materiales y producto terminado.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "n) Procedimiento para el mantenimiento de instalaciones de control de calidad.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "o) Procedimiento para el manejo y desecho de solventes.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "p) Procedimiento para la recepción, identificación, preparación y almacenamiento de reactivos, medios de cultivo y estándares.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "q) Procedimiento para el lavado de cristalería",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "r) Cualquier otro procedimiento que sea necesario en el área de control de calidad.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            ProdControlProceso = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Antes de iniciar las operaciones de producción se cumple con lo siguiente:",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cuenta con la orden de producción y procedimientos y registros de manufactura?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza el despeje del área, se verifica que los equipos estén limpios y libres de materiales, productos y documentos de una  operación anterior y cualquier otro material extraño al proceso de producción?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos y registros sobre las siguientes operaciones de manejo de materiales y productos?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader= true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuarentena",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Muestreo",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Almacenamiento",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Etiquetado",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Despacho",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Elaboración",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Envasado",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Distribución",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En caso que exista desviación de las instrucciones o procedimientos, ¿las acciones tomadas son aprobadas por escrito por la  persona autorizada con participación de control de calidad?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El reproceso de productos ¿se realiza de conformidad a un procedimiento una vez realizada la evaluación de los riesgos existentes?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los reprocesos son previamente autorizados por Control/Garantía de Calidad?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se registra y se le asigna un nuevo número al lote reprocesado?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan a cabo y se registran los controles establecidos durante todo el proceso?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan y se registran los controles ambientales de manera que no presenten riesgo alguno para la calidad del producto?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En cada uno de los procesos: los materiales, recipientes con productos a granel, equipos principales y áreas utilizadas:  ¿Están identificados?, ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta la identificación con los siguientes datos:  ¿Nombre del producto o material que se está procesando, etapa del proceso (si fuera necesario) y número de lote?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas y los equipos se utilizan exclusivamente para la fabricación de productos naturales medicinales?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "De realizarse la fabricación de otro tipo de productos ¿Se encuentran autorizados por la Autoridad Reguladora? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Dichos productos se fabrican siguiendo un proceso de fabricación similar en el que se cumpla con los procedimientos de  programación de producción, limpieza y Buenas Prácticas de Manufactura",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se garantiza que los medios filtrantes empleados en la manufactura no afecten la calidad de los productos? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se prohíbe llevar a cabo operaciones simultáneas con diferentes productos en la misma área (a excepción del empaque  secundario)?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuando se emplean materiales secos en la producción, ¿Se toman precauciones especiales, para prevenir la generación de polvo  y su diseminación? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los productos a granel están identificados con una etiqueta que contenga la siguiente información?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a. Nombre del producto a granel. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b. Número de lote",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c. Etapa del proceso.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d. Tamaño de lote",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e. Fecha",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f. Firma de la persona responsable de ejecutar la última etapa. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se evita la contaminación cruzada utilizando entre otras las siguientes medidas:",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Existencia de esclusas (cuando aplique)",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Sistemas de inyección y extracción que garanticen la calidad de aire",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Utilizar vestimenta apropiada y medios de protección en las áreas donde se procesan los productos. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Emplear procedimientos de limpieza y sanitización",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Utilizar etiquetas que indiquen el estado de limpieza de los equipos y áreas ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se adoptan medidas antes de iniciar las operaciones de empaque, para asegurar que el área de trabajo, las líneas de envasado, las  máquinas impresoras y otros equipos estén limpios y libres de productos, materiales o documentos previamente usados que no  son necesarios para la nueva operación?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En las operaciones de llenado y empaque se: ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Identifican los materiales de empaque y producto en granel.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Efectúa despeje de línea, se verifica la limpieza de equipos y la ausencia de materiales correspondientes al envasado y empaque  anterior",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Verifican las instrucciones de empaque, muestreo y controles en proceso. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las líneas de empaque están físicamente separadas e identificadas, con el nombre y el número de lote que se está procesando,  evitando mezclas de productos diferentes o lotes distintos del mismo producto?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El material impreso para la rotulación de cada lote, es cuidadosamente inspeccionado para verificar y documentar, que su  identidad corresponde a la especificada en el registro de producción?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se efectúa el etiquetado inmediatamente después de las operaciones de envasado y cierre?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En caso contrario, ¿se adoptan medidas apropiadas para asegurar que no haya confusión o error en el etiquetado?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se asegura que las muestras tomadas para control de proceso y análisis de calidad, no se devuelven a la línea de envasado y  empaque?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se llevan registros de los rendimientos y conciliación en los procesos de producción y empaque? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investigan las causas de discrepancias significativas si son observadas durante la conciliación entre la cantidad del producto  a granel y los materiales de empaque impresos y el número de unidades producidas?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investiga tal situación hasta encontrar una explicación satisfactoria antes de autorizar la liberación de los productos?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Una vez completada la operación de empaque, todos los materiales que tengan el número de lote impreso, son destruidos?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales impresos no codificados son devueltos al inventario, según un procedimiento escrito? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            Generalidades12 = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe en la empresa un sistema de garantía de calidad?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La Dirección de la Empresa, es responsable del sistema de Garantía de Calidad?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Garantía de Calidad exige la participación y el compromiso del personal de los diferentes departamentos y a todos los niveles  dentro de la organización?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe una política de calidad definida y documentada en un sistema de garantía de calidad, para asegurar la calidad?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            GarantiaCalidad = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "El sistema de garantía de calidad asegura que:",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Los productos naturales medicinales se diseñan y desarrollan de forma que se tenga en cuenta lo requerido por las Buenas  Prácticas de Manufactura, disponiéndose de los procedimientos y registros correspondientes.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Las operaciones de producción y control estén claramente especificadas de acuerdo con las Buenas Prácticas de Manufactura",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Las responsabilidades del personal directivo estén claramente especificadas y divulgadas. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Se tengan requisitos establecidos para el abastecimiento y utilización de la materia prima, materiales de envase y empaque y  en la preparación de los productos",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Se realiza una evaluación y aprobación de los diferentes proveedores. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Se realizan todos los controles necesarios de los productos intermedios y cualquier otro tipo de controles durante el proceso.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) El producto terminado se ha elaborado y controlado de forma correcta, según procedimientos definidos.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Exista un procedimiento para la recopilación de la documentación del producto que se ha elaborado. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Los productos naturales medicinales para uso humano no se venden o suministran antes de que una persona calificada haya  aprobado que cada lote de producción se ha fabricado y controlado de acuerdo a los requisitos de la autorización de  comercialización. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Se tomen medidas adecuadas para asegurar, que los productos naturales medicinales sean almacenados y distribuidos de manera  que la calidad se mantenga durante todo el período de vida útil. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Existe un procedimiento de auto inspección y auditoría de la calidad que evalúa periódicamente la efectividad y aplicabilidad  del sistema de garantía de calidad. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "l) Existan procedimientos, programas y registros de los estudios de estabilidad de los productos, los cuales garanticen las  condiciones apropiadas de almacenamiento y fecha de expiración. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            Generalidades13 = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿El área de control de calidad está identificada y separada del área de producción? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de calidad es responsable de aprobar o rechazar las materias primas, materiales de envase, productos semielaborados y  producto terminado?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de calidad verifica si cada lote elaborado cumple con las especificaciones establecidas?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se siguen las instrucciones establecidas en el procedimiento escrito en todas las pruebas o ensayos realizados a cada material o  producto?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El resultado es registrado y verificado antes que el material o producto sea liberado o rechazado?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos escritos para realizar los controles durante todo el proceso de producción, de acuerdo a los métodos  aprobados por Control de Calidad?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los controles durante el proceso de producción ¿son llevados a cabo por personal asignado a dicho proceso?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de los resultados de los controles en proceso y forman parte de los registros de los lotes?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cada lote de producto terminado es aprobado por la persona responsable de acuerdo a un procedimiento escrito, previa evaluación  de las especificaciones establecidas, condiciones de producción, análisis en proceso y la documentación para su aprobación final?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son rechazados los productos cuyos resultados no están conformes de acuerdo a las especificaciones de calidad establecidas?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En caso excepcional, de llevarse a cabo el reproceso de un producto con desviación de calidad. ¿Antes de su aprobación y  liberación, se garantiza el cumplimiento de todas las especificaciones y otros criterios de calidad?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Control de Calidad revisa y aprueba todos los registros de producción y control de cada lote terminado de acuerdo a un  procedimiento escrito?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito para el manejo de la desviación en la producción o si un lote no cumple con las especificaciones  establecidas?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se investiga cualquier desviación no justificada y se extiende a otros lotes o productos que puedan estar asociados con la  discrepancia encontrada, se incluye dentro de la investigación las conclusiones, las acciones tomadas y su seguimiento? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta con registros?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tiene acceso el personal de control de calidad a las áreas de producción con fines de muestreo, inspección e investigación y otros  trabajos relacionados con las Buenas Prácticas de Manufactura?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La unidad de control de calidad cuenta con el equipo necesario para realizar los análisis requeridos?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En caso de no contar con equipo requerido para efectuar análisis específicos, ¿contrata los servicios analíticos de un laboratorio  de control de calidad externo debidamente autorizado? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen contratos?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen programas y registros escritos del mantenimiento, verificación y calibración de cada equipo de control de calidad que lo  requiera?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen programas y registros escritos del mantenimiento, verificación y calibración de cada equipo de control de calidad que lo  requiera?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            Muestreo = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cada lote de materiales, producto intermedio y producto terminado es muestreado, analizado y aprobado por control de calidad antes de su uso?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El muestreo está a cargo de personal de control de calidad?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El muestreo se realiza de acuerdo a procedimiento escrito establecido?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realizan el muestreo de manera que se evite la contaminación y otros problemas que puedan influir negativamente en la calidad  del producto? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El procedimiento de muestreo contiene lo siguiente?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) El método de muestreo",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) El equipo que debe utilizarse.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) La cantidad de muestra representativa que debe recolectarse.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Instrucciones para la eventual subdivisión de la muestra.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Tipo y condiciones del envase que debe utilizarse para la muestra.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Identificación de los recipientes muestreados",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Precauciones especiales que deben observarse, especialmente en relación con el muestreo de material de uso delicado.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Condiciones de almacenamiento.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Instrucciones de limpieza y almacenamiento del equipo de muestreo.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentra debidamente identificadas las muestras con una etiqueta que indique lo siguiente?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del material o producto. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Descripción de la muestra",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Cantidad",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Código o número de lote",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Fecha de muestreo.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Recipientes de los que se han tomado las muestras. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Nombre y firma de la persona que realiza el muestreo.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Fecha de expiración o reanálisis, según aplique. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las muestras tomadas se evalúan de acuerdo a las especificaciones de control de calidad?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿De cada lote producido se conserva una muestra de retención en su empaque final, en cantidad suficiente que permita el análisis  completo del producto, dicha muestra se conservan hasta por un año después de su fecha de vencimiento? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            ////////
            MetodologiaAnalitica = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Los métodos analíticos o ensayos empleados ¿Están por escrito y aprobados por el responsable de Dirección o Jefatura de Control  de Calidad?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los resultados de los análisis realizados están registrados en los correspondientes protocolos que incluyen los siguientes datos:",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del material o producto. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Forma farmacéutica (cuando aplique).",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Presentación farmacéutica (cuando aplique).",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Código o número de lote",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Referencias de las especificaciones y procedimientos analíticos pertinentes. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Resultados de los análisis, con observaciones, cálculos, gráficas, cromatogramas y referencias (cuando aplique).",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Fechas de los análisis. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Firma registrada de las personas que realicen los análisis",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Firma registrada de las personas que verifiquen los análisis y los cálculos.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Registro de aprobación o rechazo (u otra decisión sobre la consideración del producto).",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "k) Fecha y firma del responsable designado",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los reactivos químicos, medios de cultivos, patrones y las muestras o cepas de referencia son preparados, identificados,  conservados y utilizados de acuerdo con instrucciones definidas y escritas, manteniendo un control sobre las fechas de expiración?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cada envase de reactivos químicos del laboratorio lleva una etiqueta de identificación con la siguiente información:",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del reactivo",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Concentración o pureza (cuando aplique)",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Fecha de preparación (cuando aplique)",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fecha de vencimiento",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Nombre y firma de la persona que realizo la preparación (cuando aplique)",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Condiciones de almacenamiento (condiciones específicas) ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) para soluciones volumétricas: fecha de valoración y concentración ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cada medio microbiológico empleado por el laboratorio lleva una etiqueta de identificación con la siguiente información:",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Fecha de preparación.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Fecha de vencimiento.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Nombre y firma de la persona que los preparó.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Condiciones de almacenamiento (condiciones especificas)",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            ////////
            MaterialesReferencia = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen materiales de referencia? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Sustancia activa natural o Marcador",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Materia prima vegetal",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Material herborizado ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el caso de que la sustancia de referencia no esté descrita en la bibliografía oficial se cuenta con la documentación referida por  el fabricante o proveedor?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales de referencia se almacenan en un área segura bajo la responsabilidad de una persona designada para tal fin?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se conservan en condiciones de almacenamiento según las especificaciones del material de referencia?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            ////////
            Estabilidad = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio garantiza la estabilidad de los productos y establece el tiempo de vida útil de los mismos? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen informes de análisis de las pruebas físicas, químicas y microbiológicas realizadas a los productos, que demuestren que  se encuentra dentro de las especificaciones presentadas en el expediente de registro para el período de vida útil solicitado? (En  tanto no entre en vigencia el RTCA de Estudios de Estabilidad para Productos Naturales Medicinales)",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            ////////
            Generalidades14 = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito que establezca el mecanismo para investigar un reclamo, queja, retiro o cualquier información  relativa a productos defectuosos? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un procedimiento escrito que describa el sistema para retirar del mercado en forma rápida y efectiva un producto cuando  éste tenga un defecto o exista sospecha de ello?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los procedimientos indican el responsable de atender las quejas y reclamos y de decidir las medidas que deben adoptarse en  conjunto con personal de otros departamentos involucrados, que la asistan en esta tarea?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio cuenta con registros escritos para el manejo de productos, devueltos por quejas o reclamos que incluya la siguiente  información?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Nombre del producto natural medicinal. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Forma farmacéutica.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Número de lote del producto. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Número de lote del producto.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) Fecha de producción y fecha de expiración",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Nombre y datos generales de la persona que realizó el reclamo",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Fecha de reclamo",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Motivo de reclamo",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Revisión de las condiciones del producto cuando se recibe",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i) Investigación que se realiza.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j) Determinación de las acciones correctivas y medidas adoptadas",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Si se descubre un lote con defectos o sospechas de falla de calidad, ¿se evalúan otros lotes que pudieran haber sido afectados? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Quedan documentadas, en los registros de lote, las decisiones tomadas respecto de las quejas del producto? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Quedan documentadas, en los registros de lote, las decisiones tomadas respecto de las quejas del producto? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El fabricante Informa a la Autoridad Reguladora cuando exista una fabricación defectuosa, deterioro o cualquier otro problema  grave de calidad de un producto terminado ya comercializado y las medidas tomadas? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            ////////
            Retiros = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "En caso de existir una orden de retiro de un producto del mercado ¿Esta fue emitida por?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La Autoridad Reguladora",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El fabricante",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un responsable independiente del departamento de ventas encargado para la coordinación y ejecución del retiro de  producto, según el procedimiento escrito?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se notifica inmediatamente a las autoridades reguladoras de los diferentes países, los retiros de productos?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros e informes sobre todo el proceso del retiro de los productos del mercado? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se concilian los datos relacionados con las cantidades de producto distribuido y retirado? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los productos retirados se identifican y almacenan independientemente en un área separada y de acceso restringido mientras se  toma la decisión sobre su destino final?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            ////////
            Generalidades15 = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿La empresa realiza actividades de producción o análisis en o para terceros? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    }, 
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un contrato por escrito de mutuo consentimiento para la producción y análisis, entre el contratante y el contratista de  conformidad con la legislación de cada Estado Parte? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El contrato estipula claramente las obligaciones de cada una de las partes con relación a la fabricación, manejo, almacenamiento,  control y liberación del producto?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En el contrato se establece claramente la persona responsable de autorizar la liberación de cada lote para su comercialización y  de emitir el certificado de análisis?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El contrato a terceros contiene los siguientes aspectos:",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Fue redactado por personas competentes y autorizadas.?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Aceptación de los términos del contrato por las partes. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Aceptación del cumplimiento del Reglamento Centroamericano en Buenas Prácticas de Manufactura de productos naturales  medicinales para uso humano.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Aceptación del cumplimiento del Reglamento Centroamericano en Buenas Prácticas de Manufactura de productos naturales  medicinales para uso humano.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) Describe el manejo de materias primas, material de acondicionamiento, graneles y producto terminado, en caso de que sean  rechazados. ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) Permite el ingreso del contratante a las instalaciones del contratista (contratado), para auditorias.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g) Permite el ingreso del contratista (contratado) a las instalaciones del contratante.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h) Lista de cada uno de los productos o servicios de análisis objeto del contrato",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En caso de análisis o producción por contrato, ¿El contratista (contratado) es informado y acepta que puede ser inspeccionado por  la Autoridad Reguladora?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            ////////
            Contratante = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "El contratante debe asegurarse que el contratista (contratado): ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "a) Cumpla con los requisitos legales, para su funcionamiento.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    }, new ContenidoTablas()
                    {
                        Titulo = "b) Posea certificado vigente de buenas prácticas de manufactura para productos naturales medicinales para uso humano emitido  por la Autoridad Reguladora.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    }, new ContenidoTablas()
                    {
                        Titulo = "c) Entregue los productos elaborados cumpliendo con las especificaciones correspondientes y que han sido aprobados por una  persona calificada.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    }, 
                    new ContenidoTablas()
                    {
                        Titulo = "d) Entregue los certificados de análisis con su documentación de soporte, cuando aplique según contrato.",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            ////////
            Contratista = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "El contratista (contratado) debe asegurarse que el contratante:",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "a) Cumpla con los requisitos legales para su funcionamiento",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    }, new ContenidoTablas()
                    {
                        Titulo = "b) Solicite y obtenga el registro sanitario del producto a fabricar",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    }, new ContenidoTablas()
                    {
                        Titulo = "c) Proporcione toda la información necesaria para que las operaciones se realicen de acuerdo al registro sanitario y otros requisitos  legales",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se indica en el contrato que el contratista no puede ceder a un tercero en todo o en parte el trabajo que se le ha asignado por  contrato? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Verifica el contratante que el contratista no lleva a cabo otras actividades que puedan afectar la calidad del producto fabricado  o analizado? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };
            ////////
            AuditoriaCalidad = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio fabricante evalúa el cumplimiento de la Buenas Prácticas de Manufactura, en todos los aspectos de la producción  y control de calidad mediante autoinspecciones o auditorías internas?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Tienen un procedimiento y un programa de auditoría para verificar el cumplimiento de las Buenas Prácticas de Manufactura?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se emite un informe que incluya las medidas correctivas y preventivas necesarias? ",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿La auditoría interna se efectúa en forma regular por lo menos una vez al año o de forma parcial, garantizando que, a lo largo del  año, todos los departamentos hayan sido auditados?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las recomendaciones, referentes a medidas correctivas y preventivas, se ponen en práctica, se documentan e instituyen en un  programa efectivo de seguimiento y cumplimiento?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El personal del laboratorio asignado para realizar la auditoría interna tiene conocimiento de las Buenas Prácticas de Manufactura,  para evaluar de forma objetiva todos los aspectos?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El laboratorio, ¿Utiliza la Guía de Verificación de Buenas Prácticas de Manufactura para Laboratorios de Productos Naturales  Medicinales, para realizar la auditoría interna?",
                        Criterio = "CRITICO",
                        Articulo = "7.9.1",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                }
            };



        }


    }
}
