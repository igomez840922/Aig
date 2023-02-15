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
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Está prohibido operar en unifamiliares habitadas o en áreas no clasificadas para la actividad comercial o áreas residenciales",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe letrero visible que identifique al establecimiento?",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con área separada para la conservación y consumo de alimentos?",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }
        public void Inicializa_AreaAdministrativa()
        {
            AreaAdministrativa = new AUD_ContenidoGenerico();
            AreaAdministrativa.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de área administrativa?",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Dirección del área administrativa",
                        IsHeader = true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Mantiene almacenados productos o áreas de almacenamiento en el área descrita como área administrativa?",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }
        public void Inicializa_AreaRecepcionProducto()
        {
            AreaRecepcionProducto = new AUD_ContenidoGenerico();
            AreaRecepcionProducto.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Existe el área de recepción de productos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Separada (cuando sea posible)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ordenada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de estructuras en esta área (Tarimas, mesa de trabajo).",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Está esta área protegida de las inclemencias del tiempo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe rampa para carga y descarga (cuando sea necesario)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }
        public void Inicializa_AreaAlmacenamiento()
        {
            AreaAlmacenamiento = new AUD_ContenidoGenerico();
            AreaAlmacenamiento.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ordenada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Seca",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tamaño aproximado del Depósito",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "La capacidad del área es suficiente para almacenar productos, manejo adecuado de productos y circulación del personal (de ser negativa la respuesta, indicar motivo)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "SON ADECUADAS LAS CONDICIONES",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Piso",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Techo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Paredes",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Iluminación",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Luces de emergencia",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ventilación",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Suministro eléctrico",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "DISPONEN DE SUFICIENTE EQUIPO PARA EL CONTROL DE INCENDIOS",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Alarma",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Detectores de humo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Extintores Vigentes",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Otros",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe señalización de rutas de evacuación en caso de siniestros",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe salida de emergencia identificada del local",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "DISPONE DE ESTRUCTURAS DONDE ALMACENAN LOS PRODUCTOS",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Anaqueles",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Estantes",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tablillas",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Tarimas",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Otros",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Son adecuadas, suficientes e identificadas estas estructuras",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los muebles son colocados manteniendo un pie de distancia de las paredes y del techo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con área de desperdicios",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "CONDICIONES GENERALES",
                        IsHeader=true,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El área de almacenamiento está libre de polvo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un sistema para monitorear la temperatura y humedad relativa de acuerdo con las especificaciones de almacenamiento del fabricante",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene monitoreo de la Temperatura",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene monitoreo de la Humedad Relativa",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene registro",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los registros se registran por lo menos tres veces al día",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Es adecuada la temperatura de almacenamiento de los productos allí almacenados (verifique)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe letrero visible que identifique los rangos de temperatura y humedad",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe un sistema para el control de fauna nociva (cebadera y certificado de fumigación)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe flujo lógico de operaciones",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Disponen de un sistema interno de codificación que permita la localización de los productos en el mercado",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con un sistema para el almacenamiento de productos. Sistema FIFO/FEFO (Primera fecha de entrada, primera salida/ Primera fecha de expiración, primera salida",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
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
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Las condiciones del área pueden afectar los productos devueltos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    }
             };
        }
        public void Inicializa_AreaProductosRetiradosMercado()
        {
            AreaProductosRetiradosMercado = new AUD_ContenidoGenerico();
            AreaProductosRetiradosMercado.LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Separados en un área segura e identificada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "En el área existen condiciones que pueden afectar los productos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Valor Informativo: \r\nLos productos retirados del mercado deben ser identificados y almacenados separadamente en un área segura e identificada, en espera de la orden de reexportación hacia el laboratorio fabricante o su destrucción en el país. Art. 435. Decreto Ejecutivo 115 de 16 de agosto de 2022.",
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
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Separada (cuando sea posible).",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Dispone de estructuras en esta área (Tarimas, mesa de trabajo)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Está esta área protegida de las inclemencias del tiempo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Existe rampa para carga y descarga (cuando sea necesario)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    }
             };
        }
        public void Inicializa_AreaAlmacenProdReqCadenaFrio()
        {
            AreaAlmacenProdReqCadenaFrio = new AUD_ContenidoGenerico();
            AreaAlmacenProdReqCadenaFrio.LContenido = new List<ContenidoPreguntas>() {
                        
                    new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene monitoreo de la Temperatura",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene monitoreo de la Humedad Relativa",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuentan con el equipo necesario para la conservación de la temperatura de este tipo de productos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene registro",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El área de almacenamiento con temperatura controlada posee sistema de alarma",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El espacio es suficiente",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Codificación de ubicación de almacén",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }
        public void Inicializa_AreaAlmacenProdVolatiles()
        {
            AreaAlmacenProdVolatiles = new AUD_ContenidoGenerico();
            AreaAlmacenProdVolatiles.LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Separada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ordenada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con kit de derrame",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con control de incendio",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cuenta con adecuada ventilación, que impida la concentración de olores",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    }
             };
        }
        public void Inicializa_AreaAlmacenPlaguicidas()
        {
            AreaAlmacenPlaguicidas = new AUD_ContenidoGenerico();
            AreaAlmacenPlaguicidas.LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Separada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ordenada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Codificación interna de ubicación en el almacén",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se cumple la prohibición de almacenar en conjunto con medicamentos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }
        public void Inicializa_AreaAlmacenMateriaPrima()
        {
            AreaAlmacenMateriaPrima = new AUD_ContenidoGenerico();
            AreaAlmacenMateriaPrima.LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Separada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Ordenada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Codificación interna de ubicación en el almacén",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }
        public void Inicializa_AreaAlmacenProdSujetosControl()
        {
            AreaAlmacenProdSujetosControl = new AUD_ContenidoGenerico();
            AreaAlmacenProdSujetosControl.LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas(){
                        Titulo = "Aseada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Asegurada (llave y/o candado)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Delimitada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                    new ContenidoPreguntas(){
                        Titulo = "Identificada",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Independiente de otras áreas",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Iluminación y Ventilación",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Posee un área identificada de vencidos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene monitoreo de la Temperatura",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene monitoreo de la Humedad Relativa",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene registro",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Responsable del Área",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Describa el lugar donde se almacenan y las medidas de seguridad",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Codificación interna de ubicación en el almacén",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se mantiene un registro para el manejo de las sustancias controladas",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Se lleva un registro de las sustancias a distribuir",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los vales están con copia de la factura, pre declaración y archivados en orden cronológico",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Los permisos de importación, exportación o reexportación están archivados por secuencia numérica y con toda la documentación de la transacción",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El inventario físico de las sustancias controladas coinciden con los registros en el libro o sistema automatizado",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "El establecimiento cumple con la prohibición del manejo de muestras médicas",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
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
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Organigrama",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de recepción de producto",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de manejo de productos de cadena de frio (cuando aplique)",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de transporte",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de mantenimiento preventivo del local",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de retiro de producto",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de devolución de producto",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de disposición final de productos o materia prima del mercado",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Cuenta con Manual de Procedimientos Operativos Estandarizados y correspondientes registros de control de fauna nociva",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }
        public void Inicializa_Transporte()
        {
            Transporte = new AUD_ContenidoGenerico();
            Transporte.LContenido = new List<ContenidoPreguntas>() {
                     new ContenidoPreguntas(){
                        Titulo = "Existe transporte para el traslado de los productos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "El transporte cuenta con controles y registro de Temperatura y Humedad relativa",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Se mantienen registros",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "El transporte mantiene los productos protegidos de la luz",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Los productos que requieren cadena de frío se trasladan en vehículos o envases que permiten mantener la temperatura requerida",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "En los camiones se colocan los productos sobre tarimas",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "Presenta formato de verificación de mantenimiento y condiciones del vehículo",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "En caso de tercerización del transporte presenta contrato con la empresa que brindará el servicio",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },new ContenidoPreguntas(){
                        Titulo = "El transporte está identificado con el nombre de la empresa con licencia de operación vigente ante la Dirección Nacional de Farmacia y Drogas.  Si es tercerizado se permite coloque un letrero removible o en acrílico (colocar en la parte de enfrente del vidrio) o similar",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
             };
        }
        public void Inicializa_Actividades()
        {
            Actividades = new AUD_ContenidoGenerico();
            Actividades.LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas(){
                        Titulo = "Importación",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Exportación",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Reexportación",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Almacenamiento",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Distribución",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Transporte",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Comercialización al por mayor de materia prima para la industria farmacéutica",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Otros",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    }
             };
        }
        public void Inicializa_Productos()
        {
            Productos = new AUD_ContenidoGenerico();
            Productos.LContenido = new List<ContenidoPreguntas>() {
                    new ContenidoPreguntas(){
                        Titulo = "Materia prima para la industria farmacéutica",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Medicamentos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Suplementos vitamínicos con propiedad terapéutica",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Cosméticos",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Plaguicidas de uso doméstico",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Desinfectantes de uso doméstico y hospitalario",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
                    },
                        new ContenidoPreguntas(){
                        Titulo = "Otros",
                        Evaluacion = Helper.enumAUD_TipoSeleccion.NA,
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
