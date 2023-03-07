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

        //CONDICIONES Y CARACTERÍSTICAS DEL ESTABLECIMIENTO
        private AUD_ContenidoGenerico condCaractEstablecimiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico CondCaractEstablecimiento { get => condCaractEstablecimiento; set => SetProperty(ref condCaractEstablecimiento, value); }

        //ÁREA ADMINSITRATIVA
        private AUD_ContenidoGenerico areaAdministrativa;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaAdministrativa { get => areaAdministrativa; set => SetProperty(ref areaAdministrativa, value); }

        //ÁREA DE RECEPCIÓN DE PRODUCTOS
        private AUD_ContenidoGenerico areaRecepcionProducto;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaRecepcionProducto { get => areaRecepcionProducto; set => SetProperty(ref areaRecepcionProducto, value); }

        //ÁREA DE ALMACEN
        private AUD_ContenidoGenerico areaAlmacenamiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaAlmacenamiento { get => areaAlmacenamiento; set => SetProperty(ref areaAlmacenamiento, value); }

        //ÁREA PARA PRODUCTOS DEVUELTOS Y VENCIDOS
        private AUD_ContenidoGenerico areaProductosDevueltosVencidos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaProductosDevueltosVencidos { get => areaProductosDevueltosVencidos; set => SetProperty(ref areaProductosDevueltosVencidos, value); }

        //ÁREA PARA PRODUCTOS RETIRADOS DEL MERCADO
        private AUD_ContenidoGenerico areaProductosRetiradosMercado;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaProductosRetiradosMercado { get => areaProductosRetiradosMercado; set => SetProperty(ref areaProductosRetiradosMercado, value); }

        //	ÁREA DE DESPACHO DE PRODUCTOS
        private AUD_ContenidoGenerico areaDespachoProductos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaDespachoProductos { get => areaDespachoProductos; set => SetProperty(ref areaDespachoProductos, value); }

        //ÁREA DE ALMACENAMIENTO DE PRODUCTOS QUE REQUIEREN CADENA DE FRÍO 
        private AUD_ContenidoGenerico areaAlmacenProdReqCadenaFrio;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaAlmacenProdReqCadenaFrio { get => areaAlmacenProdReqCadenaFrio; set => SetProperty(ref areaAlmacenProdReqCadenaFrio, value); }

        //	ÁREA DE ALMACENAMIENTO DE PRODUCTOS VOLATILES  
        private AUD_ContenidoGenerico areaAlmacenProdVolatiles;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaAlmacenProdVolatiles { get => areaAlmacenProdVolatiles; set => SetProperty(ref areaAlmacenProdVolatiles, value); }

        //ÁREA DE ALMACENAMIENTO DE PLAGUICIDAS DE USO DOMÉSTICO Y DE SALUD PÚBLICA (CUANDO APLIQUE).
        private AUD_ContenidoGenerico areaAlmacenPlaguicidas;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaAlmacenPlaguicidas { get => areaAlmacenPlaguicidas; set => SetProperty(ref areaAlmacenPlaguicidas, value); }

        //ÁREA DE ALMACENAMIENTO DE MATERIA PRIMA PARA LA INDUSTRIA FARMACÉUTICA (CUANDO APLIQUE).
        private AUD_ContenidoGenerico areaAlmacenMateriaPrima;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaAlmacenMateriaPrima { get => areaAlmacenMateriaPrima; set => SetProperty(ref areaAlmacenMateriaPrima, value); }

        //ÁREA DE ALMACENAMIENTO DE PRODUCTOS SUJETOS A CONTROL (CUANDO APLIQUE)
        private AUD_ContenidoGenerico areaAlmacenProdSujetosControl;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico AreaAlmacenProdSujetosControl { get => areaAlmacenProdSujetosControl; set => SetProperty(ref areaAlmacenProdSujetosControl, value); }

        //PROCEDIMIENTOS
        private AUD_ContenidoGenerico procedimientos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Procedimientos { get => procedimientos; set => SetProperty(ref procedimientos, value); }

        //TRANSPORTE
        private AUD_ContenidoGenerico transporte;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Transporte { get => transporte; set => SetProperty(ref transporte, value); }

        //Actividades
        private AUD_ContenidoGenerico actividades;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Actividades { get => actividades; set => SetProperty(ref actividades, value); }

        //Productos
        private AUD_ContenidoGenerico productos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_ContenidoGenerico Productos { get => productos; set => SetProperty(ref productos, value); }

        //REPORTE DE INVENTARIO DE MEDICAMENTOS DE USO CONTROLADO
        private AUD_InventarioMedicamento inventarioMedicamento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AUD_InventarioMedicamento InventarioMedicamento { get => inventarioMedicamento; set => SetProperty(ref inventarioMedicamento, value); }


        public void Inicializa_CondCaractEstablecimiento()
        {
            CondCaractEstablecimiento = new AUD_ContenidoGenerico();
            CondCaractEstablecimiento.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "El local está ubicado en área residencial?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Está prohibido operar en unifamiliares habitadas o en áreas no clasificadas para la actividad comercial o áreas residenciales",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe letrero visible que identifique al establecimiento?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con área separada para la conservación y consumo de alimentos?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_AreaAdministrativa()
        {
            AreaAdministrativa = new AUD_ContenidoGenerico();
            AreaAdministrativa.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de área administrativa?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Dirección del área administrativa",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Mantiene almacenados productos o áreas de almacenamiento en el área descrita como área administrativa?",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_AreaRecepcionProducto()
        {
            AreaRecepcionProducto = new AUD_ContenidoGenerico();
            AreaRecepcionProducto.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Existe el área de recepción de productos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Separada (cuando sea posible)",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ordenada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de estructuras en esta área (Tarimas, mesa de trabajo).",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Está esta área protegida de las inclemencias del tiempo",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe rampa para carga y descarga (cuando sea necesario)",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_AreaAlmacenamiento()
        {
            AreaAlmacenamiento = new AUD_ContenidoGenerico();
            AreaAlmacenamiento.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ordenada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Seca",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tamaño aproximado del Depósito",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "La capacidad del área es suficiente para almacenar productos, manejo adecuado de productos y circulación del personal (de ser negativa la respuesta, indicar motivo)",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "SON ADECUADAS LAS CONDICIONES",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Piso",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Techo",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Paredes",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Iluminación",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Luces de emergencia",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    //    new ContenidoPreguntas(){
                    //    Titulo = "Ventilación",
                    //    LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    //},
                        new ContenidoPreguntas(){
                        Titulo = "Suministro eléctrico",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "DISPONEN DE SUFICIENTE EQUIPO PARA EL CONTROL DE INCENDIOS",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Alarma",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Detectores de humo",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Extintores Vigentes",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Otros",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe señalización de rutas de evacuación en caso de siniestros",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe salida de emergencia identificada del local",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "DISPONE DE ESTRUCTURAS DONDE ALMACENAN LOS PRODUCTOS",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Anaqueles",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Estantes",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tablillas",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tarimas",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Otros",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Son adecuadas, suficientes e identificadas estas estructuras",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los muebles son colocados manteniendo un pie de distancia de las paredes y del techo",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con área de desperdicios",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "CONDICIONES GENERALES",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El área de almacenamiento está libre de polvo",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un sistema para monitorear la temperatura y humedad relativa de acuerdo con las especificaciones de almacenamiento del fabricante",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Se mantiene monitoreo de la Temperatura y Humedad de esta área",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Temperatura",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Humedad Relativa",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene registro",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los registros se registran por lo menos tres veces al día",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Es adecuada la temperatura de almacenamiento de los productos allí almacenados (verifique)",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe letrero visible que identifique los rangos de temperatura y humedad",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un sistema para el control de fauna nociva (cebadera y certificado de fumigación)",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe flujo lógico de operaciones",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Disponen de un sistema interno de codificación que permita la localización de los productos en el mercado",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con un sistema para el almacenamiento de productos. Sistema FIFO/FEFO (Primera fecha de entrada, primera salida/ Primera fecha de expiración, primera salida",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Valor informativo:\r\nPrecauciones en el área de Almacenamiento. No se permite fumar, comer, guardar comidas o cualquier otro objeto que pudiera afectar la calidad de los productos. Art. 418. Decreto Ejecutivo 115 de 16 de agosto de 2022",
                        IsHeader=true,
                    },
             };
        }
        public void Inicializa_AreaProductosDevueltosVencidos()
        {
            AreaProductosDevueltosVencidos = new AUD_ContenidoGenerico();
            AreaProductosDevueltosVencidos.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las condiciones del área pueden afectar los productos devueltos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    }
             };
        }
        public void Inicializa_AreaProductosRetiradosMercado()
        {
            AreaProductosRetiradosMercado = new AUD_ContenidoGenerico();
            AreaProductosRetiradosMercado.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Separados en un área segura",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "En el área existen condiciones que pueden afectar los productos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Valor Informativo: \r\nLos productos retirados del mercado deben ser identificados y almacenados separadamente en un área segura e identificada, en espera de la orden de reexportación hacia el laboratorio fabricante o su destrucción en el país",
                        IsHeader = true,
                    }
             };
        }
        public void Inicializa_AreaDespachoProductos()
        {
            AreaDespachoProductos = new AUD_ContenidoGenerico();
            AreaDespachoProductos.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Separada (cuando sea posible).",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de estructuras en esta área (Tarimas, mesa de trabajo)",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Está esta área protegida de las inclemencias del tiempo",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe rampa para carga y descarga (cuando sea necesario)",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    }
             };
        }
        public void Inicializa_AreaAlmacenProdReqCadenaFrio()
        {
            AreaAlmacenProdReqCadenaFrio = new AUD_ContenidoGenerico();
            AreaAlmacenProdReqCadenaFrio.LContenido = new List<ContenidoPreguntas>() {
                        
                    new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene monitoreo de la Temperatura de esta área",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Temperatura",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuentan con el equipo necesario para la conservación de la temperatura de este tipo de productos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene registro",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El área de almacenamiento con temperatura controlada posee sistema de alarma",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El espacio es suficiente",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Codificación interna de ubicación de almacén",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_AreaAlmacenProdVolatiles()
        {
            AreaAlmacenProdVolatiles = new AUD_ContenidoGenerico();
            AreaAlmacenProdVolatiles.LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Separada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ordenada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con kit de derrame",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con control de incendio",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con adecuada ventilación, que impida la concentración de olores",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    }
             };
        }
        public void Inicializa_AreaAlmacenPlaguicidas()
        {
            AreaAlmacenPlaguicidas = new AUD_ContenidoGenerico();
            AreaAlmacenPlaguicidas.LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Separada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ordenada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Codificación interna de ubicación en el almacén",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se cumple la prohibición de almacenar en conjunto con medicamentos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_AreaAlmacenMateriaPrima()
        {
            AreaAlmacenMateriaPrima = new AUD_ContenidoGenerico();
            AreaAlmacenMateriaPrima.LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Separada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ordenada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Codificación interna de ubicación en el almacén",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_AreaAlmacenProdSujetosControl()
        {
            AreaAlmacenProdSujetosControl = new AUD_ContenidoGenerico();
            AreaAlmacenProdSujetosControl.LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Asegurada (llave y/o candado)",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Independiente de otras áreas",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Iluminación y Ventilación",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Posee un área identificada de vencidos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene monitoreo de la Temperatura y Humedad de esta área",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Temperatura",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Humedad Relativa",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene registro",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Responsable del Área",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Describa el lugar donde se almacenan y las medidas de seguridad",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Codificación interna de ubicación en el almacén",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene un registro para el manejo de las sustancias controladas",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se lleva un registro de las sustancias a distribuir",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los vales están con copia de la factura, pre declaración y archivados en orden cronológico",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los permisos de importación, exportación o reexportación están archivados por secuencia numérica y con toda la documentación de la transacción",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El inventario físico de las sustancias controladas coinciden con los registros en el libro o sistema automatizado",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El establecimiento cumple con la prohibición del manejo de muestras médicas",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_Procedimientos()
        {
            Procedimientos = new AUD_ContenidoGenerico();
            Procedimientos.LContenido = new List<ContenidoPreguntas>() {
                     new ContenidoPreguntas(){
                        Titulo = "La documentación integral que maneja el establecimiento farmacéutico forma parte del sistema de calidad y debe mantenerse en archivos físicos o digitales dentro del establecimiento y permanecer en custodia. Art. 403. Decreto Ejecutivo 115 de 16 de agosto de 2022",
                        IsHeader = true,
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Cargos y Funciones",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Organigrama",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de recepción de producto",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                     new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de despacho de producto",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de manejo de productos de cadena de frio (cuando aplique)",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de transporte",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de mantenimiento preventivo del local",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de retiro de producto",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de devolución de producto",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de disposición final de productos o materia prima del mercado",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de control de fauna nociva",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Otros procedimientos y sus correspondientes registros",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_Transporte()
        {
            Transporte = new AUD_ContenidoGenerico();
            Transporte.LContenido = new List<ContenidoPreguntas>() {
                     new ContenidoPreguntas(){
                        Titulo = "Existe transporte para el traslado de los productos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "El transporte cuenta con controles y registro de Temperatura y Humedad relativa",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Se mantienen registros",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "El transporte mantiene los productos protegidos de la luz",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Los productos que requieren cadena de frío se trasladan en vehículos o envases que permiten mantener la temperatura requerida",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "En los camiones se colocan los productos sobre tarimas",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "Presenta formato de verificación de mantenimiento y condiciones del vehículo",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "En caso de tercerización del transporte presenta contrato con la empresa que brindará el servicio",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },new ContenidoPreguntas(){
                        Titulo = "El transporte está identificado con el nombre de la empresa con licencia de operación vigente ante la Dirección Nacional de Farmacia y Drogas.  Si es tercerizado se permite coloque un letrero removible o en acrílico (colocar en la parte de enfrente del vidrio) o similar",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
             };
        }
        public void Inicializa_Actividades()
        {
            Actividades = new AUD_ContenidoGenerico();
            Actividades.LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas(){
                        Titulo = "Importación",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Exportación",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Reexportación",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Almacenamiento",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Distribución",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Transporte",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Comercialización al por mayor de materia prima para la industria farmacéutica",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Otros",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    }
             };
        }
        public void Inicializa_Productos()
        {
            Productos = new AUD_ContenidoGenerico();
            Productos.LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas(){
                        Titulo = "Materia prima para la industria farmacéutica",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Medicamentos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Suplementos vitamínicos con propiedad terapéutica",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cosméticos",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Plaguicidas de uso doméstico",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Desinfectantes de uso doméstico y hospitalario",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Otros",
                        LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                    }
             };
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
