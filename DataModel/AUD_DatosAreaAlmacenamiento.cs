using DataBindable;
using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    /// <summary>
    /// Datos de Area Almacen
    /// </summary>
    public class AUD_DatosAreaAlmacenamiento : SystemId
    {
        //Está identificada y delimitada
        private enumAUD_TipoSeleccion identificada;
        public enumAUD_TipoSeleccion Identificada { get => identificada; set => SetProperty(ref identificada, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string identificadaDesc;
        public string IdentificadaDesc { get => identificadaDesc; set => SetProperty(ref identificadaDesc, value); }

        //Está identificada y delimitada
        private enumAUD_TipoSeleccion espacioFisicoAdecuado;
        public enumAUD_TipoSeleccion EspacioFisicoAdecuado { get => espacioFisicoAdecuado; set => SetProperty(ref espacioFisicoAdecuado, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string espacioFisicoAdecuadoDesc;
        public string EspacioFisicoAdecuadoDesc { get => espacioFisicoAdecuadoDesc; set => SetProperty(ref espacioFisicoAdecuadoDesc, value); }

        //Higrótermometro y formato de registro de temperatura y humedad relativa. El registro y control de los parámetros debe ser como mínimo dos veces al día de preferencia en horas de la mañana y mediodía.
        private enumAUD_TipoSeleccion tempHumedadRelat;
        public enumAUD_TipoSeleccion TempHumedadRelat { get => tempHumedadRelat; set => SetProperty(ref tempHumedadRelat, value); }

        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string tempHumedadRelatDescrip;
        public string TempHumedadRelatDescrip { get => tempHumedadRelatDescrip; set => SetProperty(ref tempHumedadRelatDescrip, value); }

        //Medidas aproximadas 
        private decimal dimLargo;
        public decimal DimLargo { get => dimLargo; set => SetProperty(ref dimLargo, value); }

        private decimal dimAncho;
        public decimal DimAncho { get => dimAncho; set => SetProperty(ref dimAncho, value); }

        private decimal dimAltura;
        public decimal DimAltura { get => dimAltura; set => SetProperty(ref dimAltura, value); }

        //Limpio y ordenado
        private enumAUD_TipoSeleccion limpioOrdenado;
        public enumAUD_TipoSeleccion LimpioOrdenado { get => limpioOrdenado; set => SetProperty(ref limpioOrdenado, value); }

        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string limpioOrdenadoDescrip;
        public string LimpioOrdenadoDescrip { get => limpioOrdenadoDescrip; set => SetProperty(ref limpioOrdenadoDescrip, value); }

        //Iluminación 
        private enumAUD_TipoSeleccion iluminacion;
        public enumAUD_TipoSeleccion Iluminacion { get => iluminacion; set => SetProperty(ref iluminacion, value); }

        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string iluminacionDescrip;
        public string IluminacionDescrip { get => iluminacionDescrip; set => SetProperty(ref iluminacionDescrip, value); }

        //Los productos farmacéuticos se almacenan sobre anaqueles, racks, tarimas o pallets 
        private enumAUD_TipoSeleccion prodSobreAnaqueles;
        public enumAUD_TipoSeleccion ProdSobreAnaqueles { get => prodSobreAnaqueles; set => SetProperty(ref prodSobreAnaqueles, value); }

        private enumAUD_TipoSeleccion prodSobreRacks;
        public enumAUD_TipoSeleccion ProdSobreRacks { get => prodSobreRacks; set => SetProperty(ref prodSobreRacks, value); }

        private enumAUD_TipoSeleccion prodSobreTarimas;
        public enumAUD_TipoSeleccion ProdSobreTarimas { get => prodSobreTarimas; set => SetProperty(ref prodSobreTarimas, value); }

        private enumAUD_TipoSeleccion prodSobrePalets;
        public enumAUD_TipoSeleccion ProdSobrePalets { get => prodSobrePalets; set => SetProperty(ref prodSobrePalets, value); }

        private enumAUD_TipoSeleccion prodSobreOtros;
        public enumAUD_TipoSeleccion ProdSobreOtros { get => prodSobreOtros; set => SetProperty(ref prodSobreOtros, value); }

        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string prodSobreDescrip;
        public string ProdSobreDescrip { get => prodSobreDescrip; set => SetProperty(ref prodSobreDescrip, value); }

        //Las condiciones de paredes, piso y techo deben ser adecuadas para evitar posible contaminación de los medicamentos.
        private enumAUD_TipoSeleccion condParedesPisoTecho;
        public enumAUD_TipoSeleccion CondParedesPisoTecho { get => condParedesPisoTecho; set => SetProperty(ref condParedesPisoTecho, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string condParedesPisoTechoDescrip;
        public string CondParedesPisoTechoDescrip { get => condParedesPisoTechoDescrip; set => SetProperty(ref condParedesPisoTechoDescrip, value); }

        //Área de cuarentena identificada, delimitada y asegurada bajo llave
        private enumAUD_TipoSeleccion cuarentenaIdentDeli;
        public enumAUD_TipoSeleccion CuarentenaIdentDeli { get => cuarentenaIdentDeli; set => SetProperty(ref cuarentenaIdentDeli, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.

        private string cuarentenaIdentDeliDescrip;
        public string CuarentenaIdentDeliDescrip { get => cuarentenaIdentDeliDescrip; set => SetProperty(ref cuarentenaIdentDeliDescrip, value); }

        //Cuenta con cortina de aire a la entrada del almacén para evitar posible contaminación de los medicamentos (cuando aplique).
        private enumAUD_TipoSeleccion cortinaAire;
        public enumAUD_TipoSeleccion CortinaAire { get => cortinaAire; set => SetProperty(ref cortinaAire, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string cortinaAireDescrip;
        public string CortinaAireDescrip { get => cortinaAireDescrip; set => SetProperty(ref cortinaAireDescrip, value); }

        //Extintores contra incendios (vigentes y aprobados por el Cuerpo de Bomberos).
        private enumAUD_TipoSeleccion extintoresIncendio;
        public enumAUD_TipoSeleccion ExtintoresIncendio { get => extintoresIncendio; set => SetProperty(ref extintoresIncendio, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string extintoresIncendioDescrip;
        public string ExtintoresIncendioDescrip { get => extintoresIncendioDescrip; set => SetProperty(ref extintoresIncendioDescrip, value); }

        //Alarmas contra incendios o detector de humo.
        private enumAUD_TipoSeleccion alarmaIncendio;
        public enumAUD_TipoSeleccion AlarmaIncendio { get => alarmaIncendio; set => SetProperty(ref alarmaIncendio, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string alarmaIncendioDescrip;
        public string AlarmaIncendioDescrip { get => alarmaIncendioDescrip; set => SetProperty(ref alarmaIncendioDescrip, value); }


        //Luces de emergencia..
        private enumAUD_TipoSeleccion lucesEmergencias;
        public enumAUD_TipoSeleccion LucesEmergencias { get => lucesEmergencias; set => SetProperty(ref lucesEmergencias, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string lucesEmergenciasDescrip;
        public string LucesEmergenciasDescrip { get => lucesEmergenciasDescrip; set => SetProperty(ref lucesEmergenciasDescrip, value); }

        //Existe un sistema para el control de fauna nociva (Cebadera y certificado de fumigación).
        private enumAUD_TipoSeleccion controlFaunaNociva;
        public enumAUD_TipoSeleccion ControlFaunaNociva { get => controlFaunaNociva; set => SetProperty(ref controlFaunaNociva, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string controlFaunaNocivaDescrip;
        public string ControlFaunaNocivaDescrip { get => controlFaunaNocivaDescrip; set => SetProperty(ref controlFaunaNocivaDescrip, value); }

        //Área de cuarentena identificada, delimitada y asegurada.
        private enumAUD_TipoSeleccion areaCuarentena;
        public enumAUD_TipoSeleccion AreaCuarentena { get => areaCuarentena; set => SetProperty(ref areaCuarentena, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string areaCuarentenaDescrip;
        public string AreaCuarentenaDescrip { get => areaCuarentenaDescrip; set => SetProperty(ref areaCuarentenaDescrip, value); }

        //Área de productos controlados, delimitada y asegurada bajo llave.
        private enumAUD_TipoSeleccion areaProdControlados;
        public enumAUD_TipoSeleccion AreaProdControlados { get => areaProdControlados; set => SetProperty(ref areaProdControlados, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string areaProdControladosDescrip;
        public string AreaProdControladosDescrip { get => areaProdControladosDescrip; set => SetProperty(ref areaProdControladosDescrip, value); }

        //Área de productos controlados, delimitada y asegurada bajo llave.
        private enumAUD_TipoSeleccion alcohol;
        public enumAUD_TipoSeleccion Alcohol { get => alcohol; set => SetProperty(ref alcohol, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string alcoholDescrip;
        public string AlcoholDescrip { get => alcoholDescrip; set => SetProperty(ref alcoholDescrip, value); }


        //Área de almacenamiento de un alto inventario o volumen de Alcohol o productos inflamables el cual cuenta con extintores, detectores de humo o alarma contra incendio, lámpara de emergencia en el área y kit de emergencia para el manejo de derrames de sustancias peligrosas o corrosivas.
        private enumAUD_TipoSeleccion altoNivelInventario;
        public enumAUD_TipoSeleccion AltoNivelInventario { get => altoNivelInventario; set => SetProperty(ref altoNivelInventario, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string altoNivelInventarioDescrip;
        public string AltoNivelInventarioDescrip { get => altoNivelInventarioDescrip; set => SetProperty(ref altoNivelInventarioDescrip, value); }

        //Área de vencidos o deteriorados separada e identificada. Asegurada bajo llave.
        private enumAUD_TipoSeleccion vencidos;
        public enumAUD_TipoSeleccion Vencidos { get => vencidos; set => SetProperty(ref vencidos, value); }

        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string vencidosDescrip;
        public string VencidosDescrip { get => vencidosDescrip; set => SetProperty(ref vencidosDescrip, value); }

    }
}
