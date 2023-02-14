using DataModel.Helper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspRutinaVigAgenciaTB : SystemId
    {
        public AUD_InspRutinaVigAgenciaTB()
        {
            GeneralesEmpresa = new AUD_GeneralesEmpresa();
            DatosRegente = new AUD_DatosRegente();
            DatosRepresentLegal = new AUD_DatosRepresentLegal();

            InventarioMedicamento = new AUD_InventarioMedicamento();

            DatosConclusiones = new AUD_DatosConclusiones();

            InicializaData();
        }

        private AUD_InspeccionTB inspeccion;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual AUD_InspeccionTB Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }


        //Generales Empresa
        private AUD_GeneralesEmpresa generalesEmpresa;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_GeneralesEmpresa GeneralesEmpresa { get => generalesEmpresa; set => SetProperty(ref generalesEmpresa, value); }

        //DATOS GENERALES DEL REGENTE FARMACÉUTICO
        private AUD_DatosRegente datosRegente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRegente DatosRegente { get => datosRegente; set => SetProperty(ref datosRegente, value); }

        //Datos del Representante Legal
        private AUD_DatosRepresentLegal datosRepresentLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosRepresentLegal DatosRepresentLegal { get => datosRepresentLegal; set => SetProperty(ref datosRepresentLegal, value); }


        //GENERALIDADES DEL ESTABLECIMIENTO
        private AUD_ContenidoTablas genEstablecimiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas GenEstablecimiento { get => genEstablecimiento; set => SetProperty(ref genEstablecimiento, value); }

        //AREA RECEPCION PRODUCTOS
        private AUD_ContenidoTablas areaRecepProductos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaRecepProductos { get => areaRecepProductos; set => SetProperty(ref areaRecepProductos, value); }

        //AREA ALMACENAMIENTO
        private AUD_ContenidoTablas areaAlmacenamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaAlmacenamiento { get => areaAlmacenamiento; set => SetProperty(ref areaAlmacenamiento, value); }

        //AREA PRODUCTOS DEVUELTOS
        private AUD_ContenidoTablas areaProdDevueltos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaProdDevueltos { get => areaProdDevueltos; set => SetProperty(ref areaProdDevueltos, value); }

        //AREA DESPACHO PRODUCTOS
        private AUD_ContenidoTablas areaDespachoProductos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaDespachoProductos { get => areaDespachoProductos; set => SetProperty(ref areaDespachoProductos, value); }

        //Existe área de almacenamiento de productos que requieren cadena de frío?
        private AUD_ContenidoTablas areaAlmCadenaFrio;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaAlmCadenaFrio { get => areaAlmCadenaFrio; set => SetProperty(ref areaAlmCadenaFrio, value); }

        //Existe un área de almacén de desperdicios que se generan y no pueden ser colocados en el área de 
        private AUD_ContenidoTablas areaDesperdicio;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaDesperdicio { get => areaDesperdicio; set => SetProperty(ref areaDesperdicio, value); }

        //SUSTANCIAS CONTROLADAS (CUANDO APLIQUE).
        private AUD_ContenidoTablas areaSustanciasControladas;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas AreaSustanciasControladas { get => areaSustanciasControladas; set => SetProperty(ref areaSustanciasControladas, value); }

        //PROCEDIMIENTOS.
        private AUD_ContenidoTablas procedimientos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Procedimientos { get => procedimientos; set => SetProperty(ref procedimientos, value); }

        //TRANSPORTE
        private AUD_ContenidoTablas transporte;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas Transporte { get => transporte; set => SetProperty(ref transporte, value); }

        //EL ESTABLECIMIENTO SE DEDICA A LA ACTIVIDAD DE DISTRIBUCION DE
        private AUD_ContenidoTablas actividadDistribucion;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_ContenidoTablas ActividadDistribucion { get => actividadDistribucion; set => SetProperty(ref actividadDistribucion, value); }


        //REPORTE DE INVENTARIO DE MEDICAMENTOS DE USO CONTROLADO
        private AUD_InventarioMedicamento inventarioMedicamento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_InventarioMedicamento InventarioMedicamento { get => inventarioMedicamento; set => SetProperty(ref inventarioMedicamento, value); }

        //Datos Conclusión de Inspección
        private AUD_DatosConclusiones datosConclusiones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_DatosConclusiones DatosConclusiones { get => datosConclusiones; set => SetProperty(ref datosConclusiones, value); }


        // Se realizó inventario al azar 
        private enumAUD_TipoSeleccion inventarioAlAzar;
        public enumAUD_TipoSeleccion InventarioAlAzar { get => inventarioAlAzar; set => SetProperty(ref inventarioAlAzar, value); }


        private enumAUD_TipoSeleccion inventarioCompleto;
        public enumAUD_TipoSeleccion InventarioCompleto { get => inventarioCompleto; set => SetProperty(ref inventarioCompleto, value); }


        private void InicializaData()
        {
            //////////////////////
            GenEstablecimiento = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "El local está ubicado en área residencial (está prohibido operar en unifamiliares habitadas o en áreas no clasificadas para la actividad comercial o áreas residenciales)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe letrero visible que identifique la empresa",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El ambiente donde se sitúa el local presenta riesgo mínimo de contaminación a los productos (ver área externa del local)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Dispone de área administrativa",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Dispone de servicios sanitarios y lavamanos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Distribuye sus productos a establecimientos que están debidamente autorizados por la Dirección Nacional de Farmacia y Drogas",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Mantiene registros de las importaciones oficiales aprobadas por la Dirección Nacional de Farmacia y Drogas",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Hay evidencias de que el establecimiento verifica que los productos cumplan con las especificaciones consignadas en el certificado de registro sanitario",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            //////////////////////
            AreaRecepProductos = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "¿Existe área de Recepción de productos?",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Identificada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ordenada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Aseada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Delimitada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Está esta área protegida de las inclemencias del tiempo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe rampa para carga y descarga (cuando sea necesario)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los productos dispuestos para la recepción están colocados sobre tarimas u otro mobiliario",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ///////
            AreaAlmacenamiento = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {

                    new ContenidoTablas()
                    {
                        Titulo = "Dispone de área de Almacenamiento?",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Identificada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ordenada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Aseada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Delimitada ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tamaño aproximado del Depósito",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "De acuerdo al criterio técnico del Farmacéutico inspector, la capacidad del área es suficiente para almacenar productos, manejo adecuado de productos y circulación del personal",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "De ser negativa la respuesta, indicar motivo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Son adecuadas las condiciones:",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Piso",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Techos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Paredes",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Iluminación",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ventilación",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Suministros eléctricos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Disponen de suficiente equipo para el control de incendios",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Extintores",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Alarma ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Detectores de humo ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Duchas",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Mangueras",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Otros",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe señalización de rutas de evacuación en caso de siniestros",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe salida de emergencia identificada del local",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Dispone de estructuras donde almacenan los productos",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Racks",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tarimas",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Anaqueles",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Estantes",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Tablillas ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Otros ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Son adecuadas y suficientes estas estructuras",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los muebles son colocados manteniendo un pie de distancia de las paredes y del techo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe un sistema para monitorear la temperatura y humedad relativa de acuerdo a las especificaciones de almacenamiento del fabricante",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se mantiene monitoreo de la temperatura y humedad de esta área ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Valor de T° actual",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Valor de Humedad actual",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se mantiene registro",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Es adecuada la temperatura de almacenamiento de los productos allí almacenados (verifique)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe un sistema para el control de fauna nociva",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen señalizaciones de no comer, no fumar, no guardar plantas y comida",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe flujo lógico de operaciones",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los productos cumplen con las normas de etiquetado",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe un sistema de codificación que permite la rápida ubicación del producto",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El establecimiento utiliza el sistema FIFO/FEFO para el almacenamiento",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Dispone de un área destinada exclusivamente para almacenar materiales y productos de limpieza",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Esta área es exclusiva para almacenar medicamentos y otros productos para la salud humana y no están mezclados o juntos con otros productos (alimentos, hidrocarburos, plaguicidas, otros) que pudieran afectar adversamente a los mismos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            AreaProdDevueltos = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Dispone de área para productos devueltos o retirados del mercado",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Está identificada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Está asegurada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se lleva un registro de los productos a destruir y de los productos ya destruidos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuenta con un área de cuarentena",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Señale las condiciones del área que pueden afectar los productos ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            AreaDespachoProductos = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Existe área de despacho de productos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Está identificada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Está asegurada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se lleva un registro de los productos a destruir y de los productos ya destruidos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuenta con un área de cuarentena",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Señale las condiciones del área que pueden afectar los productos ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            AreaAlmCadenaFrio = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Existe área de almacenamiento de productos que requieren cadena de frío?",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Identificada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "delimitada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se mantiene monitoreo de la temperatura en esta área",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se mantiene registro de monitoreo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Valor de T° actual",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            AreaDesperdicio = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Existe un área de almacén de desperdicios que se generan y no pueden ser colocados en el área de almacenamiento",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Identificada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ordenada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Aseada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Delimitada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            AreaSustanciasControladas = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Manejan productos sujetos a control?",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Medidas aproximadas del área:",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader = true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Largo ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Ancho ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Altura  ",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El área se encuentra:",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Identificada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Asegurada (llave y/o candado)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Independiente de otras áreas",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Delimitada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Posee un área identificada de vencidos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Iluminación y Ventilación",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Responsables del Área",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Describa el lugar donde se almacenan y las medidas de seguridad",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se mantiene un registro para el manejo de las sustancias controladas",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se lleva un registro de las sustancias a distribuir",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Todas las sustancias controladas almacenadas poseen su registro sanitario o en situaciones excepcionales han sido autorizada por la Dirección Nacional de Farmacia y Drogas",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Todos los vales están con copia de la factura, pre declaración y archivados en orden cronológico.",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los permisos de importación, exportación o reexportación están archivados por secuencia numérica y con toda la documentación de la transacción.",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El inventario físico de las sustancias controladas coinciden con los registros en el libro o sistema automatizado.",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El establecimiento cumple con la prohibición del manejo de muestras médicas.",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            Procedimientos = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Existe Manual de Procedimientos Operativos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Estos procedimientos se encuentran en un formato para procedimientos operativos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Estos procedimientos están firmados por la persona que los elaboró, revisó y aprobó",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Este manual de Procedimientos Operativos posee una vigencia establecida",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existen Procedimientos Operativos?",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Recepción de los productos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Almacenamiento de los productos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Despacho de los productos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Retiro y reemplazo de productos del mercado",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Limpieza de las áreas",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se evidencia el cumplimiento de limpieza de áreas",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Manejo de los productos de cadena de frío (si aplica)",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se evidencia el manejo de los productos de cadena de frio una vez entregado al cliente de que el producto cumple con la cadena de frio",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Manejo de quejas y reclamos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Incluye la coordinación del retiro del producto del mercado",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Incluye las recomendaciones de las medidas a tomar",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se les comunica a las autoridades correspondientes",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Distribución de los productos. El registro de distribución cuenta con:",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre, presentación y forma farmacéutica",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Número de lote",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre y dirección del consignatario",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Fecha y cantidad despachada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Número de factura o documentación de embarque según sea el caso",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Nombre del laboratorio fabricante",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se mantienen actualizados los registros de distribución en carpeta o archivos electrónicos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Transporte de los productos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Control de Fauna Nociva",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Registros respectivos del control de fauna nociva",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los productos utilizados cuentan con las autorizaciones correspondientes",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Manejo de la disposición final de desechos farmacéuticos de los productos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Autoinspección",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El establecimiento registra con qué frecuencia se va a realizar la autoinspección",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Presenta evidencias de reportes realizados de la autoinspección",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Realizan un reporte de los resultados y de as acciones correctivas",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuentan con un programa de Capacitación del personal",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se evidencia que desarrolla programas de capacitación del personal",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuentan con un programa de Mantenimiento Preventivo",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuentan con un programa de Salud Ocupacional",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuentan con un expediente para el archivo cronológico de las inspecciones y Auditorías realizadas por la Dirección Nacional de Farmacia y Drogas",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            Transporte = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {

                    new ContenidoTablas()
                    {
                        Titulo = "Existe transporte adecuado, según sea el caso para el traslado de los productos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El transporte cuenta con controles de T° y Humedad relativa",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El transporte mantiene los productos protegidos de la luz",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Los productos que requieren cadena de frío, se trasladan en vehículos o envases que permiten mantener la temperatura requerida",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "En los camiones se colocan los productos sobre tarimas",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
            ActividadDistribucion = new AUD_ContenidoTablas()
            {
                LContenido = new List<ContenidoTablas>()
                {
                    new ContenidoTablas()
                    {
                        Titulo = "Productos Inflamables",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe un área separada e identificada para el almacenamiento de estos productos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cuenta con los equipos y implementos para la prevención de incendios",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Plaguicidas",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se almacenan en área segregada, delimitada e identificada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Se cumple la prohibición de almacenar en conjunto con medicamentos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cosméticos",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Cumplen con los requisitos de etiqueta",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "La etiqueta tiene información en español.",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Declaran propiedades comprobantes y autorizadas en el registro sanitario",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Materia Prima",
                        Evaluacion = enumAUD_TipoSeleccion.NA,
                        IsHeader=true,
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Todas as materias primas que manejan cuentan con su certificado de inscripción vigente",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "Existe área delimitada e identificada",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                    new ContenidoTablas()
                    {
                        Titulo = "El área reúne las condiciones adecuadas para almacenar estos productos",
                        Evaluacion = enumAUD_TipoSeleccion.NA
                    },
                }
            };
            ////////
        }

    }

    public class AUD_InventarioMedicamento:SystemId
    {
        public AUD_InventarioMedicamento()
        {
            LProductos = new List<AUD_InvProducto>();
        }

        private List<AUD_InvProducto> lProductos;
        public List<AUD_InvProducto> LProductos { get => lProductos; set => SetProperty(ref lProductos, value); }

        private enumAUD_TipoSeleccion inventarioAlAzar;
        public enumAUD_TipoSeleccion InventarioAlAzar { get => inventarioAlAzar; set => SetProperty(ref inventarioAlAzar, value); }

        private string cantidadAlAzar;
        public string CantidadAlAzar { get => cantidadAlAzar; set => SetProperty(ref cantidadAlAzar, value); }


        private enumAUD_TipoSeleccion inventarioProductosVenta;
        public enumAUD_TipoSeleccion InventarioProductosVenta { get => inventarioProductosVenta; set => SetProperty(ref inventarioProductosVenta, value); }

    }

    public class AUD_InvProducto : SystemId
    {
        private string nombre;
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }


        private long? fabricanteId;
        public long? FabricanteId { get => fabricanteId; set => SetProperty(ref fabricanteId, value); }

        private string fabricante;
        public string Fabricante { get => fabricante; set => SetProperty(ref fabricante, value); }

        private string lote;
        public string Lote { get => lote; set => SetProperty(ref lote, value); }

        private DateTime? fechaVencimiento;
        public DateTime? FechaVencimiento { get => fechaVencimiento; set => SetProperty(ref fechaVencimiento, value); }


        private string existencia;
        public string Existencia { get => existencia; set => SetProperty(ref existencia, value); }

        private string registrados;
        public string Registrados { get => registrados; set => SetProperty(ref registrados, value); }

        // Registro en Libro o sistema

        private string registroSistema;
        public string RegistroSistema { get => registroSistema; set => SetProperty(ref registroSistema, value); }

        private int cantidad;
        public int Cantidad { get => cantidad; set => SetProperty(ref cantidad, value); }

        private string presentacion;
        public string Presentacion { get => presentacion; set => SetProperty(ref presentacion, value); }

        private string motivos;
        public string Motivos { get => motivos; set => SetProperty(ref motivos, value); }

    }

}
