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

        //Está identificada
        private enumAUD_TipoSeleccion identificada;
        public enumAUD_TipoSeleccion Identificada { get => identificada; set => SetProperty(ref identificada, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string identificadaDesc;
        [StringLength(500)]
        public string IdentificadaDesc { get => identificadaDesc; set => SetProperty(ref identificadaDesc, value); }

        //Está delimitada
        private enumAUD_TipoSeleccion delimitada;
        public enumAUD_TipoSeleccion Delimitada { get => delimitada; set => SetProperty(ref delimitada, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string delimitadaDesc;
        [StringLength(500)]
        public string DelimitadaDesc { get => delimitadaDesc; set => SetProperty(ref delimitadaDesc, value); }

        //Está limpia
        private enumAUD_TipoSeleccion limpia;
        public enumAUD_TipoSeleccion Limpia { get => limpia; set => SetProperty(ref limpia, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string limpiaDesc;
        [StringLength(500)]
        public string LimpiaDesc { get => limpiaDesc; set => SetProperty(ref limpiaDesc, value); }

        //Está limpia
        private enumAUD_TipoSeleccion ordenada;
        public enumAUD_TipoSeleccion Ordenada { get => ordenada; set => SetProperty(ref ordenada, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string ordenadaDesc;
        [StringLength(500)]
        public string OrdenadaDesc { get => ordenadaDesc; set => SetProperty(ref ordenadaDesc, value); }


        // Separada para la conservación y consumo de alimentos
        private enumAUD_TipoSeleccion separadaConservConsumoAlimentos;
        public enumAUD_TipoSeleccion SeparadaConservConsumoAlimentos { get => separadaConservConsumoAlimentos; set => SetProperty(ref separadaConservConsumoAlimentos, value); }
        
        private string separadaConservConsumoAlimentosDesc;
        [StringLength(500)]
        public string SeparadaConservConsumoAlimentosDesc { get => separadaConservConsumoAlimentosDesc; set => SetProperty(ref separadaConservConsumoAlimentosDesc, value); }

        //Está identificada y delimitada
        private enumAUD_TipoSeleccion espacioFisicoAdecuado;
        public enumAUD_TipoSeleccion EspacioFisicoAdecuado { get => espacioFisicoAdecuado; set => SetProperty(ref espacioFisicoAdecuado, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string espacioFisicoAdecuadoDesc;
        [StringLength(500)]
        public string EspacioFisicoAdecuadoDesc { get => espacioFisicoAdecuadoDesc; set => SetProperty(ref espacioFisicoAdecuadoDesc, value); }

        //Las condiciones de paredes, piso y techo deben ser adecuadas para evitar posible contaminación de los medicamentos.
        private enumAUD_TipoSeleccion condParedes;
        public enumAUD_TipoSeleccion CondParedes { get => condParedes; set => SetProperty(ref condParedes, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string condParedesDesc;
        [StringLength(500)]
        public string CondParedesDesc { get => condParedesDesc; set => SetProperty(ref condParedesDesc, value); }

        //Las condiciones de paredes, piso y techo deben ser adecuadas para evitar posible contaminación de los medicamentos.
        private enumAUD_TipoSeleccion condPiso;
        public enumAUD_TipoSeleccion CondPiso { get => condPiso; set => SetProperty(ref condPiso, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string condPisoDesc;
        [StringLength(500)]
        public string CondPisoDesc { get => condPisoDesc; set => SetProperty(ref condPisoDesc, value); }

        //Las condiciones de paredes, piso y techo deben ser adecuadas para evitar posible contaminación de los medicamentos.
        private enumAUD_TipoSeleccion condTecho;
        public enumAUD_TipoSeleccion CondTecho { get => condTecho; set => SetProperty(ref condTecho, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string condTechoDesc;
        [StringLength(500)]
        public string CondTechoDesc { get => condTechoDesc; set => SetProperty(ref condTechoDesc, value); }

        //Iluminación 
        private enumAUD_TipoSeleccion iluminacion;
        public enumAUD_TipoSeleccion Iluminacion { get => iluminacion; set => SetProperty(ref iluminacion, value); }

        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string iluminacionDescrip;
        [StringLength(500)]
        public string IluminacionDescrip { get => iluminacionDescrip; set => SetProperty(ref iluminacionDescrip, value); }

        //Luces de emergencia..
        private enumAUD_TipoSeleccion lucesEmergencias;
        public enumAUD_TipoSeleccion LucesEmergencias { get => lucesEmergencias; set => SetProperty(ref lucesEmergencias, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string lucesEmergenciasDescrip;
        [StringLength(500)]
        public string LucesEmergenciasDescrip { get => lucesEmergenciasDescrip; set => SetProperty(ref lucesEmergenciasDescrip, value); }

        //Luces de emergencia..
        private enumAUD_TipoSeleccion condVentilacion;
        public enumAUD_TipoSeleccion CondVentilacion { get => condVentilacion; set => SetProperty(ref condVentilacion, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string condVentilacionDesc;
        [StringLength(500)]
        public string CondVentilacionDesc { get => condVentilacionDesc; set => SetProperty(ref condVentilacionDesc, value); }


        // Son adecuadas las condiciones de suministros eléctricos.
        private enumAUD_TipoSeleccion condSumElectricos;
        public enumAUD_TipoSeleccion CondSumElectricos { get => condSumElectricos; set => SetProperty(ref condSumElectricos, value); }

        // Observaciones
        private string condSumElectricosDesc;
        [StringLength(500)]
        public string CondSumElectricosDesc { get => condSumElectricosDesc; set => SetProperty(ref condSumElectricosDesc, value); }

        // DISPONEN DE SUFICIENTE EQUIPOS PARA EL CONTROL DE INCENDIOS
        // Extintores
        private enumAUD_TipoSeleccion ctrIncendioExtintores;
        public enumAUD_TipoSeleccion CtrIncendioExtintores { get => ctrIncendioExtintores; set => SetProperty(ref ctrIncendioExtintores, value); }

        // Alarma
        private enumAUD_TipoSeleccion ctrIncendioAlarma;
        public enumAUD_TipoSeleccion CtrIncendioAlarma { get => ctrIncendioAlarma; set => SetProperty(ref ctrIncendioAlarma, value); }

        // Detectores de Humo
        private enumAUD_TipoSeleccion ctrIncendioDetectHumo;
        public enumAUD_TipoSeleccion CtrIncendioDetectHumo { get => ctrIncendioDetectHumo; set => SetProperty(ref ctrIncendioDetectHumo, value); }

        // Duchas
        private enumAUD_TipoSeleccion ctrIncendioDuchas;
        public enumAUD_TipoSeleccion CtrIncendioDuchas { get => ctrIncendioDuchas; set => SetProperty(ref ctrIncendioDuchas, value); }

        // Mangueras
        private enumAUD_TipoSeleccion ctrIncendioMangueras;
        public enumAUD_TipoSeleccion CtrIncendioMangueras { get => ctrIncendioMangueras; set => SetProperty(ref ctrIncendioMangueras, value); }

        // Otros
        private enumAUD_TipoSeleccion ctrIncendioOtros;
        public enumAUD_TipoSeleccion CtrIncendioOtros { get => ctrIncendioOtros; set => SetProperty(ref ctrIncendioOtros, value); }

        // Observaciones
        private string ctrIncendioDesc;
        [StringLength(500)]
        public string CtrIncendioDesc { get => ctrIncendioDesc; set => SetProperty(ref ctrIncendioDesc, value); }


        // ¿Existe señalización de rutas de evacuación en caso de siniestros?
        private enumAUD_TipoSeleccion senalizacionRutaEva;
        public enumAUD_TipoSeleccion SenalizacionRutaEva { get => senalizacionRutaEva; set => SetProperty(ref senalizacionRutaEva, value); }

        // Observaciones
        private string senalizacionRutaEvaDesc;
        [StringLength(500)]
        public string SenalizacionRutaEvaDesc { get => senalizacionRutaEvaDesc; set => SetProperty(ref senalizacionRutaEvaDesc, value); }

        // Existe salida de emergencia identificada del local
        private enumAUD_TipoSeleccion salidaEmerIdenficada;
        public enumAUD_TipoSeleccion SalidaEmerIdenficada { get => salidaEmerIdenficada; set => SetProperty(ref salidaEmerIdenficada, value); }

        // Observaciones
        private string salidaEmerIdenficadaDesc;
        [StringLength(500)]
        public string SalidaEmerIdenficadaDesc { get => salidaEmerIdenficadaDesc; set => SetProperty(ref salidaEmerIdenficadaDesc, value); }


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

        private enumAUD_TipoSeleccion prodSobreEstantes;
        public enumAUD_TipoSeleccion ProdSobreEstantes { get => prodSobreEstantes; set => SetProperty(ref prodSobreEstantes, value); }

        private enumAUD_TipoSeleccion prodSobreTablillas;
        public enumAUD_TipoSeleccion ProdSobreTablillas { get => prodSobreTablillas; set => SetProperty(ref prodSobreTablillas, value); }

        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string prodSobreDescrip;
        public string ProdSobreDescrip { get => prodSobreDescrip; set => SetProperty(ref prodSobreDescrip, value); }

        // ¿Son adecuadas y suficientes estas estructuras?
        private enumAUD_TipoSeleccion estructuraAdecuada;
        public enumAUD_TipoSeleccion EstructuraAdecuada { get => estructuraAdecuada; set => SetProperty(ref estructuraAdecuada, value); }

        // Observaciones
        private string estructuraAdecuadaDesc;
        [StringLength(500)]
        public string EstructuraAdecuadaDesc { get => estructuraAdecuadaDesc; set => SetProperty(ref estructuraAdecuadaDesc, value); }



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

        // Los muebles son colocados manteniendo un pie de distancia de las paredes y del techo
        private enumAUD_TipoSeleccion mueblesADistancia;
        public enumAUD_TipoSeleccion MueblesADistancia { get => mueblesADistancia; set => SetProperty(ref mueblesADistancia, value); }

        // Observaciones
        private string mueblesADistanciaDesc;
        [StringLength(500)]
        public string MueblesADistanciaDesc { get => mueblesADistanciaDesc; set => SetProperty(ref mueblesADistanciaDesc, value); }

        // ¿Existe un sistema para monitorear la temperatura y humedad  relativa  de acuerdo a las especificaciones de almacenamiento  del fabricante?
        private enumAUD_TipoSeleccion sistMonitorTemperatura;
        public enumAUD_TipoSeleccion SistMonitorTemperatura { get => sistMonitorTemperatura; set => SetProperty(ref sistMonitorTemperatura, value); }

        // Observaciones
        private string sistMonitorTemperaturaDesc;
        [StringLength(500)]
        public string SistMonitorTemperaturaDesc { get => sistMonitorTemperaturaDesc; set => SetProperty(ref sistMonitorTemperaturaDesc, value); }


        // Se mantiene registro del monitoreo de la temperatura y humedad de esta área?
        private enumAUD_TipoSeleccion sistRegistroTemperatura;
        public enumAUD_TipoSeleccion SistRegistroTemperatura { get => sistRegistroTemperatura; set => SetProperty(ref sistRegistroTemperatura, value); }

        // Observaciones
        private string sistRegistroTemperaturaDesc;
        [StringLength(500)]
        public string SistRegistroTemperaturaDesc { get => sistRegistroTemperaturaDesc; set => SetProperty(ref sistRegistroTemperaturaDesc, value); }

        // Se mantiene registro del monitoreo de la temperatura y humedad de esta área?
        private enumAUD_TipoSeleccion temperaturaActual;
        public enumAUD_TipoSeleccion TemperaturaActual { get => temperaturaActual; set => SetProperty(ref temperaturaActual, value); }

        // Observaciones
        private string temperaturaActualDesc;
        [StringLength(500)]
        public string TemperaturaActualDesc { get => temperaturaActualDesc; set => SetProperty(ref temperaturaActualDesc, value); }


        // Se mantiene registro del monitoreo de la temperatura y humedad de esta área?
        private enumAUD_TipoSeleccion humedadActual;
        public enumAUD_TipoSeleccion HumedadActual { get => humedadActual; set => SetProperty(ref humedadActual, value); }

        // Observaciones
        private string humedadActualDesc;
        [StringLength(500)]
        public string HumedadActualDesc { get => humedadActualDesc; set => SetProperty(ref humedadActualDesc, value); }

        // Es adecuada la temperatura de almacenamiento de  los productos allí almacenados (verificar)
        private enumAUD_TipoSeleccion tempAlmacenamientoAdecuada;
        public enumAUD_TipoSeleccion TempAlmacenamientoAdecuada { get => tempAlmacenamientoAdecuada; set => SetProperty(ref tempAlmacenamientoAdecuada, value); }

        // Observaciones
        private string tempAlmacenamientoAdecuadaDesc;
        [StringLength(500)]
        public string TempAlmacenamientoAdecuadaDesc { get => tempAlmacenamientoAdecuadaDesc; set => SetProperty(ref tempAlmacenamientoAdecuadaDesc, value); }

        //Existe un sistema para el control de fauna nociva (Cebadera y certificado de fumigación).
        private enumAUD_TipoSeleccion controlFaunaNociva;
        public enumAUD_TipoSeleccion ControlFaunaNociva { get => controlFaunaNociva; set => SetProperty(ref controlFaunaNociva, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string controlFaunaNocivaDescrip;
        public string ControlFaunaNocivaDescrip { get => controlFaunaNocivaDescrip; set => SetProperty(ref controlFaunaNocivaDescrip, value); }

        //No Comer
        private enumAUD_TipoSeleccion noComer;
        public enumAUD_TipoSeleccion NoComer { get => noComer; set => SetProperty(ref noComer, value); }

        //No Beber
        private enumAUD_TipoSeleccion noBeber;
        public enumAUD_TipoSeleccion NoBeber { get => noBeber; set => SetProperty(ref noBeber, value); }

        //No Fumar
        private enumAUD_TipoSeleccion noFumar;
        public enumAUD_TipoSeleccion NoFumar { get => noFumar; set => SetProperty(ref noFumar, value); }

        //No Fumar
        private enumAUD_TipoSeleccion noGuardarPlantasComidasBebidas;
        public enumAUD_TipoSeleccion NoGuardarPlantasComidasBebidas { get => noGuardarPlantasComidasBebidas; set => SetProperty(ref noGuardarPlantasComidasBebidas, value); }

        private string noComerBeberFumarDesc;
        public string NoComerBeberFumarDesc { get => noComerBeberFumarDesc; set => SetProperty(ref noComerBeberFumarDesc, value); }



        // ¿Existe flujo lógico de operaciones?
        private enumAUD_TipoSeleccion senalFlujoLogicoOpe;
        public enumAUD_TipoSeleccion SenalFlujoLogicoOpe { get => senalFlujoLogicoOpe; set => SetProperty(ref senalFlujoLogicoOpe, value); }
        private string senalFlujoLogicoOpeDesc;
        public string SenalFlujoLogicoOpeDesc { get => senalFlujoLogicoOpeDesc; set => SetProperty(ref senalFlujoLogicoOpeDesc, value); }




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
