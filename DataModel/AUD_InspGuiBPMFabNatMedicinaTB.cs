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

            RespProduccion = new DatosPersona();

            RespControlCalidad = new DatosPersona();

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

        //RESPONSABLE DE PRODUCCIÓN
        private DatosPersona respProduccion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual DatosPersona RespProduccion { get => respProduccion; set => SetProperty(ref respProduccion, value); }

        //RESPONSABLE DE CONTROL DE CALIDAD:
        private DatosPersona respControlCalidad;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual DatosPersona RespControlCalidad { get => respControlCalidad; set => SetProperty(ref respControlCalidad, value); }


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
        private AUD_ContenidoTablas sistemaAria;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas SistemaAria { get => sistemaAria; set => SetProperty(ref sistemaAria, value); }

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
                        Titulo = "Razón social:\r\n",
                        Criterio = "INFORMATIVO",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre de la empresa:\r\n",
                        Criterio = "INFORMATIVO",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Dirección del domicilio legal de la empresa:\r\n",
                        Criterio = "INFORMATIVO",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Dirección del laboratorio fabricante: \r\n",
                        Criterio = "INFORMATIVO",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Motivo de la inspección: \r\n",
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
                        Titulo = "¿Se cuenta con licencia sanitaria o permiso sanitario de funcionamiento?\r\n",
                        Criterio = "INFORMATIVO",
                        Articulo="5.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Indicar número:\r\n",
                        Criterio = "INFORMATIVO",
                        Articulo="5.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha de vencimiento:\r\n",
                        Criterio = "INFORMATIVO",
                        Articulo="5.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se desarrollan las operaciones de fabricación aprobadas en la licencia sanitaria o permiso sanitario?\r\n",
                        Criterio = "CRITICO",
                        Articulo="5.2\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Formas farmacéuticas autorizadas:\r\n",
                        Criterio = "INFORMATIVO",
                        Articulo="5.2\r\n",
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
                        Titulo = "¿Existe un organigrama general y especifico actualizado de la empresa? Anexar copia cuando aplique\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.1.1\r\n13.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe independencia de responsabilidades entre producción y control de la calidad?\r\n",
                        Criterio = "CRITICO",
                        Articulo="6.1.1\r\n13.1.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen descripciones de responsabilidades y funciones para cada puesto incluido en el organigrama?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se especifica el grado académico y las habilidades que el personal debe tener para ocuparlos?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio fabricante dispone de un Director Técnico o Regente Farmacéutico responsable de la calidad y seguridad de los productos que se fabrican y está presente durante el horario de su funcionamiento?\r\n",
                        Criterio = "CRITICO",
                        Articulo="6.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Indicar nombre y número de colegiado o de inscripción profesional \r\n",
                        Criterio = "INFORMATIVO",
                        Articulo="6.1.4",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En casos de jornadas continuas o extraordinarias el regente garantiza los mecanismos de supervisión de acuerdo a la legislación nacional de cada Estado Parte?\r\n",
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
                        Titulo = "¿Dispone el laboratorio fabricante de personal con la calificación y experiencia práctica según el puesto asignado? \r\n",
                        Criterio = "CRITICO",
                        Articulo="6.2.1\r\n6.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las funciones asignadas a cada persona son congruentes con el nivel de responsabilidad que asumen de acuerdo a la descripción del puesto, y no constituyen un riesgo a la calidad del producto?\r\n",
                        Criterio = "CRITICO",
                        Articulo="6.2.1\r\n6.1.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los profesionales responsables o personal calificado de las unidades de investigación y desarrollo y garantía de la calidad (según requerimiento de la empresa), producción y control ¿tienen experiencia técnica para el puesto que ocupan?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.2.2",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros que el personal que labora en el laboratorio, cuenta con preparación académica, capacitación y experiencia o una combinación de esas condiciones, para ocupar el puesto asignado?\r\n",
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
                        Articulo = "6.3.1\r\n",
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Asegura que los productos se fabriquen y almacenen en concordancia con la documentación aprobada, a fin de obtener la \r\ncalidad prevista",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Aprueba los documentos maestros relacionados con las operaciones de producción, incluyendo los controles durante el proceso \r\ny asegurar su estricto cumplimiento",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Verifica que la orden de producción esté completa y firmada por las personas designadas, antes de que se pongan a disposición \r\ndel departamento asignado",
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
                        Titulo = "g) Asegura que se lleve a cabo la capacitación inicial y continua del personal de producción y que dicha capacitación se adapte a \r\nlas necesidades",
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
                        Articulo = "6.3.2\r\n",
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) Aprueba o rechaza, según procede, las materias primas, materiales de acondicionamiento, producto intermedio, a granel y \r\nterminado",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) Revisa que toda la documentación de un lote de producto que se ha finalizado, esté completa, la cual también puede ser \r\nresponsabilidad de garantía de calidad",
                        Criterio = "CALIFICABLE",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) Aprueba las instrucciones de muestreo, métodos de análisis y otros procedimientos de control de calidad y verificar las \r\nespecificaciones.",
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
                        Titulo = "f) Asegura que se lleve a cabo la capacitación inicial y continua del personal de control de calidad y que dicha capacitación se \r\nadapte a las necesidades.",
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
                        Titulo="Cumple el responsable de la Dirección o Jefatura de Producción y Control de Calidad con las siguientes responsabilidades \r\ncompartidas:",
                        Articulo = "6.3.3\r\n",
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
                        Titulo = "e) Participan en la selección, evaluación (aprobación) y control de los proveedores de materiales, de equipo y otros, involucrados \r\nen el proceso de producción",
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
                        Titulo = "¿Existe un procedimiento de inducción en BPM para nuevos empleados que incluye capacitación (teórica y práctica) específica en las funciones que desempeñarán?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen registros actualizados? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de capacitación continua en BPM para todo el personal incluyendo capacitación específica (las funciones propias del puesto, las regulaciones vigentes, los procedimientos escritos de Buenas Prácticas de Manufactura, todo lo relacionado con la función de su departamento)? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.2,\r\n6.4.3\r\n6.4.4,\r\n6.4.5.\r\n10.3.5 f)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza y se evalúa la capacitación al personal en BPM al menos 2 veces al año?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.2,\r\n6.4.3\r\n6.4.4,\r\n6.4.5.\r\n10.3.5 f)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza una evaluación de la ejecución del programa de capacitación al menos una vez al año?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.2,\r\n6.4.3\r\n6.4.4,\r\n6.4.5.\r\n10.3.5 f)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se mantienen registros?\r\n",
                        Criterio = "CRITICO",
                        Articulo="6.4.2,\r\n6.4.3\r\n6.4.4,\r\n6.4.5.\r\n10.3.5 f)",
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
                        Titulo = "¿La admisión / contratación del personal es precedida de un examen médico?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio fabricante se responsabiliza de que el personal presente anualmente o de acuerdo a la legislación de cada país, la certificación médica o su equivalente, garantizando que no padece de enfermedades infectocontagiosas?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los procedimientos relacionados con la higiene personal incluyendo el uso de ropa protectoras, se aplican a todo el personal permanente o temporal y visitantes que ingresan a las áreas de producción?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe prohibición que el personal con signos de enfermedad o que sufre de lesiones abiertas no manipule materia prima o productos en proceso, hasta que se considere que la condición ha desaparecido? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Es obligatorio para el personal que participa en los procesos de fabricación informar sobre sus condiciones de salud que puedan afectar negativamente la calidad de los productos?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los uniformes, del personal destinado a la producción, que están en contacto directo con los productos, cumple con las siguientes características: ¿manga larga, limpio, sin bolsas en la parte superior de la vestimenta, confortable y confeccionada con un material que no desprenda partículas, con cierres ocultos y en buenas condiciones?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta el personal con equipo de protección, gorros que cubran la totalidad del cabello, mascarillas, guantes, protección de ojos y oídos en procesos donde se requiera y zapato cerrado para áreas de producción?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Hay procedimientos escritos donde se establezcan el uso correcto y el tipo de uniforme a utilizar en cada área? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "Existen rótulos de prohibiciones al ingreso de las áreas de producción, Control de Calidad y cualquier otra área donde esas \r\nactividades puedan influir negativamente en la calidad de los productos sobre: ",
                        Criterio = "",
                        Articulo="6.5.6",
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) No comer, beber, fumar, masticar, así como guardar comida, bebida, cigarrillos, medicamentos personales",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) No usar maquillaje, joyas, relojes, teléfonos celulares e instrumentos ajenos al uniforme, así como manipular dinero en áreas \r\nde riesgo para los productos",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) No llevar barba o bigote al descubierto, durante la jornada de trabajo en los procesos de dispensado, producción y empaque\r\nprimario",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) No usar el uniforme fuera de las áreas para la que fue diseñado.",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
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
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se instruye al personal a lavarse las manos antes de ingresar a las áreas de producción?",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe en todas las áreas de vestidores y servicios sanitarios rótulos que indiquen la obligación de lavarse las manos antes de salir \r\nde este lugar?",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se realiza controles microbiológicos de manos del personal de acuerdo a programas y procedimientos establecidos? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El acceso a las áreas de producción y control de calidad es restringido? ",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen rótulos que indiquen que sólo el personal autorizado puede ingresar a aquellas áreas de los edificios e instalaciones \r\ndesignadas como de acceso restringido?",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de ingresar visitantes o personal no capacitado a las áreas de producción, es supervisado por un acompañante autorizado \r\ny se cumplen los procedimientos de higiene personal y el uso de ropas protectoras?",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Cuenta la empresa con un botiquín o un área destinada a primeros auxilios, suficientemente dotado para un adecuado \r\nfuncionamiento?",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
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
                        Titulo = "¿Las instalaciones están diseñadas, construidas, y se mantienen de acuerdo a las operaciones que se realizan? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Su disposición y diseño permite el flujo adecuado de personal y materiales, la limpieza y el mantenimiento efectivo para evitar la contaminación cruzada, la confusión y errores, la acumulación de polvo o suciedad, protegida contra el ingreso de plagas?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El edificio está ubicado lejos de fuentes de contaminación? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "¿Se cuenta con planos y diagramas actualizados de lo siguiente?\r\n",
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a. Planos de construcción y remodelaciones. \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b. Plano de distribución de áreas.\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c. Diagrama de flujo de personal. \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d. Diagrama de flujo de materiales. \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e. Diagrama de flujo de procesos\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f. Plano o diagramas cuando aplique, de servicios (sistemas de inyección y extracción de aire, aire comprimido, aguas, desagües, aguas servidas, aguas negras, electricidad, vapor, vapor puro y gases, cuando aplique). \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g. Plano o diagrama de evacuación del personal en caso de emergencia y plano o diagrama de ubicación de salidas de emergencia, señalando la ubicación de los extintores y las lámparas de emergencia.\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h. Diagrama del sistema de tratamiento de aguas para la producción. \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "",
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un programa de mantenimiento preventivo de las instalaciones?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas de acceso restringido están debidamente delimitadas e identificadas? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas de producción, empaque, almacenamiento y control de calidad no se utilizan como lugar de paso por el personal que no trabaje en las mismas?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los pasillos de circulación ¿se encuentran libres de materiales, equipos y productos en tránsito?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los drenajes no permiten la contracorriente y tienen tapa sanitaria?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Son las áreas exclusivas para el uso previsto y se mantienen libres de objetos y materiales extraños al proceso? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas se encuentran separadas físicamente e identificadas para las diferentes etapas de manufactura, tomando en cuenta el flujo, tamaño y espacio de acuerdo a sus procesos?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las tuberías, artefactos lumínicos, puntos de ventilación y otros servicios, ¿están diseñados y ubicados, de tal forma que no dificulten la limpieza? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Se encuentran en buen estado?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas del laboratorio permiten que los equipos y materiales estén ubicados de forma que eviten el riesgo de confusión, contaminación cruzada y omisión entre los distintos productos y sus componentes en cualquiera de las operaciones de producción, control y almacenamiento?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = " ¿Existe protección contra el ingreso de insectos y otros animales?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El laboratorio dispone de equipamiento para el cumplimiento de la normativa de seguridad industrial vigente en cada uno de los Estados Parte?",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las condiciones ambientales (iluminación, temperatura, humedad y ventilación), ¿no influyen negativamente, directa o indirectamente en los productos, durante su producción y almacenamiento?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las áreas ¿Están diseñadas y adaptadas para que las condiciones de iluminación, temperatura, humedad y ventilación no influyan directa o indirectamente de forma negativa en los productos durante su producción y almacenamiento?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros de temperatura y humedad?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
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
                        Titulo = "¿Tienen las áreas de almacenamiento suficiente capacidad para permitir el almacenamiento ordenado de las diferentes categorías de materiales y productos de acuerdo a las necesidades de la empresa?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están debidamente identificados, ordenados y en buenas condiciones de mantenimiento?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los pisos, paredes y techos están en buen estado de conservación e higiene, son de fácil limpieza, y no afectan la calidad de los materiales y productos que se almacene?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las estanterías y tarimas están separadas de pisos y paredes de manera que permitan la limpieza e inspección del almacén? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Están debidamente identificados, ordenados y en buenas condiciones de mantenimiento? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Las áreas de recepción y despacho, de los productos y materiales ¿están protegidos de las condiciones ambientales?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Está diseñada de forma que los contenedores puedan limpiarse si fuese necesario antes de su almacenamiento? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Las áreas de cuarentena de materiales y productos están definidas y marcadas y el acceso a las mismas se limita a personal autorizado?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área físicamente separada e identificada para el muestreo de materias primas? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿De no existir dicha área, el muestreo se realiza en el área de pesaje o dispensado de tal forma que impida la contaminación y la contaminación cruzada?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Los materiales y productos rechazados, retirados del mercado o devueltos son almacenados en un área separada, identificada y de acceso restringido?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = " ¿Existe un área para almacenamiento de productos inflamables?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área separada, identificada, bajo llave y de acceso restringido para almacenar materiales impresos (etiqueta, estuches, insertos y envases impresos)?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
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
                        Titulo = "¿De ser necesario el laboratorio cuenta con un área para la recepción, limpieza, segregación y acondicionamiento de la materia prima natural fresca o seca?, \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="6.4.1\r\n10.3.5 f)\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },


                    new ContenidoTablas()
                    {
                        Titulo = "El área para la recepción, limpieza, segregación y acondicionamiento de la materia prima natural fresca o seca tiene las siguientes \r\ncaracterísticas",
                        IsHeader=true,
                        Articulo="7.3.2\r\n",
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
                        Titulo = "c) ¿Están protegidas de la incidencia de la luz directa? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Cuentan con recolectores de polvo y sistema de inyección y extracción de aire, cuando aplique?\r\n",
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
                        Titulo = "¿En el área para la recepción, limpieza, segregación y acondicionamiento, se colocan las materias primas identificada sobre mesas, tarimas o estanterías que permitan el proceso de tratamiento?\r\n",
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
                        Titulo = "¿Existen áreas independientes y separadas físicamente para llevar a cabo las siguientes operaciones?\r\n",
                        IsHeader=true,
                        Articulo="7.4.1\r\n",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Secado\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Molienda\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Extracción. \r\n",
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
                        Titulo = "c) ¿Están protegidas de la incidencia de la luz directa? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo=" ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Cuentan con recolectores de polvo y sistema de inyección y extracción de aire, cuando aplique?\r\n",
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
                        Titulo = "¿Existe un área físicamente exclusiva identificada como área restringida para el dispensado (pesado)?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="7.5.1.\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "Con las siguientes características:\r\n",
                        IsHeader=true,
                        Articulo="7.5.1.\r\n",
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
                        Titulo = "b) ¿Limpia y ordenada?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "c) ¿Con sistema de inyección y extracción de aire?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "d) ¿Condiciones controladas de temperatura y humedad, si se requiere?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "e) ¿Adecuadamente iluminada?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "f) ¿Con la advertencia que no debe utilizarse como área de lavado o como área de almacenamiento?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                     new ContenidoTablas()
                    {
                        Titulo = "¿El soporte donde se colocan las balanzas y otros equipos sensibles es capaz de contrarrestar las vibraciones que afecten su buen funcionamiento?\r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿La capacidad y sensibilidad de las balanzas, utensilios calibrados corresponden con las cantidades que se pesan y se miden? \r\n",
                        Criterio = "CALIFICABLE",
                        Articulo="",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                     new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área delimitada e identificada en la que se colocarán las materias primas que serán pesadas y las materias primas dispensadas que serán utilizadas en la producción?\r\n",
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
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },

                    new ContenidoTablas()
                    {
                        Titulo = "Tienen las áreas de producción y empaque primario las siguientes condiciones",
                        IsHeader=true,
                        Articulo="7.6.2\r\n7.7.1",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Están identificadas y separadas para la producción y empaque primario de sólidos, líquidos y semisólidos, tienen paredes,\r\npisos y techos lisos, con curvas sanitarias, sin grietas ni fisuras, no utilizan madera, no liberan partículas y permite su limpieza y \r\nsanitización?",
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
                        Articulo="7.6.3\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿El área se mantiene en buenas condiciones de orden y limpieza, cuenta con curvas sanitarias y servicios para el trabajo que allí \r\nse ejecuta?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.3\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe un área identificada, limpia, ordenada y separada para colocar equipo y utensilios limpios que no se esté utilizando? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.4\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Todas las mangueras, tubos y tuberías y otros utensilios empleados en la transferencia de fluidos ¿Están identificadas y en buen \r\nestado de conservación? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.4\r\n10.3.5 c)\r\n",
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
                        Articulo="7.7.2\r\n7.7.2.1\r\n",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a) ¿Están separadas, identificadas y son de tamaño adecuado? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b) ¿Tienen paredes, pisos y techos lisos, sin grietas, ni fisuras y son de fácil limpieza? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c) ¿No se utiliza madera en esta área? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d) ¿Tiene identificadas la toma de energía eléctrica?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e) ¿Tienen ventanas fijas y lámparas con difusores lisos, que sean de fácil limpieza y eviten la acumulación de polvo? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f) ¿Cuentan con ventilación e iluminación que asegure condiciones confortables al personal y no afecte negativamente la calidad \r\ndel producto?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
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
                        Articulo="7.8.1\r\n",
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "a. Identificados correctamente.",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "b. Un número de servicios sanitarios para hombres y para mujeres de acuerdo al número de trabajadores.",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "c. Mantenerse limpios y ordenados",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "d. Deben existir procedimientos y registros para la limpieza y sanitización. ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "e. Los servicios sanitarios deben estar accesibles a las áreas de producción, pero no deben comunicarse directamente",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "f. Deben contar con lavamanos y duchas. ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "g. Disponer de espejos, toallas de papel o secador eléctrico de manos, jaboneras con jabón líquido desinfectante y papel higiénico",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "h. Los vestidores deben estar separados de los servicios sanitarios por una pared.",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "i. Casilleros, zapateras y las bancas necesarias (deben ser de un material adecuado que no libere partículas y no provoque \r\ncontaminación).",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "j. Rótulos o letreros que enfaticen la higiene personal. ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "K. Se prohíbe mantener, guardar, preparar y consumir alimentos en esta área. ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.6.1\r\n",
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
                        Articulo="7.8.3\r\n10.3.5 g)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen procedimientos para el lavado y preparación de uniformes? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.3\r\n10.3.5 g)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existen registros?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.3\r\n10.3.5 g)",
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
                        Titulo = "¿Existe un área de mantenimiento o un espacio para el almacenamiento de herramientas o implementos utilizados para el \r\nmantenimiento que este separado de las áreas productivas? ",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿Excepcionalmente en el caso de no contar con un área de mantenimiento, el laboratorio posee procedimientos escritos y registros \r\ndonde se describa las actividades realizadas de mantenimiento?",
                        Criterio = "CALIFICABLE",
                        Articulo="7.8.5",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "¿En caso de contar con equipo obsoleto o en mal estado que no interviene en los procesos se dispone de un área exclusiva para \r\nalmacenar dicho equipo?\r\n",
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
                        Titulo = "a) Está diseñado de acuerdo a las operaciones que realiza, las áreas para controles fisicoquímicos y microbiológicos se encuentran \r\nfísicamente separados.",
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
                        Titulo = "d) Disponer de área de almacenamiento en condiciones adecuadas para las muestras, reactivos, patrones de referencia (cuando \r\naplique), muestras de retención, archivos, bibliografía, documentación y cristalería.\r\n",
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
                        Titulo = "¿El área instrumental está diseñada para proteger el equipo e instrumentos sensibles del efecto de las vibraciones, interferencias \r\neléctricas, humedad y temperatura y las que el fabricante del equipo recomiende? ",
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
                
                }
            };



        }
    }


}
