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
        
        private List<ContenidoPreguntas> lContenido;
        public List<ContenidoPreguntas> LContenido { get => lContenido; set => SetProperty(ref lContenido, value); }

        public void Inicializa()
        {
            LContenido = new List<ContenidoPreguntas>() {
                        new ContenidoPreguntas(){
                            Titulo = "Esta identificada y delimitada",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "El espacio físico de almacenamiento es adecuado para el movimiento y operaciones del personal permitiendo un despacho oportuno a las estanterías del área de recetario",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "En el área de almacenamiento debe existir un sistema de inventario que permita determinar la vigencia de los medicamentos de tal forma que puedan abastecer o retirar los mismos en tiempo oportuno (de acuerdo con las políticas de devolución). Se almacenarán las existencias utilizando los sistemas FIFO (primero que entra que sale) o FEFO (primero que expira primero que sale).",
                            IsHeader=true,
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Higrotermómetro y formato de registro de temperatura y humedad relativa. El registro y control de los parámetros debe ser como mínimo tres veces al día.",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Limpio y ordenado",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Iluminación",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Los productos farmacéuticos se almacenan sobre anaqueles, racks, tarimas u otros. Manteniendo suficiente distancia de paredes, piso y techo",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Las condiciones de paredes, piso y techo deben ser adecuadas para evitar posible contaminación de los medicamentos",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Cuenta con cortina de aire a la entrada del almacén para evitar posible contaminación de los medicamentos (aplíquese cuando el almacén este fuera de las instalaciones de la farmacia)",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Extintores contra incendios (vigentes y aprobados por el Cuerpo de Bomberos)",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Alarmas contra incendios o detector de humo",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Luces de emergencia",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Existe un sistema para el control de fauna nociva (Cebadera y certificado de fumigación)",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Área de productos devueltos y vencidos identificada, delimitada y asegurada",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Área de productos controlados, delimitada y asegurada bajo llave",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Área de almacenamiento de Alcohol o productos inflamables separada con ventilación adecuada que evite la exposición a los vapores",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "Área de almacenamiento de un alto inventario o volumen de Alcohol o productos inflamables el cual cuenta con extintores, detectores de humo o alarma contra incendio, lámpara de emergencia en el área y kit de emergencia para el manejo de derrames de sustancias peligrosas o corrosivas",
                            LEvaluacion = new List<OpcionEvaluacion>(){ new OpcionEvaluacion()},
                        },
                        new ContenidoPreguntas(){
                            Titulo = "El establecimiento se compromete al fiel cumplimiento del Artículo 639 del Decreto Ejecutivo 115 De 16 de agosto de 2022",
                            IsHeader=true
                        },
             };
        }


        /// <summary>
        /// ///////////////////////
        /// </summary>




        //Areas de Almacenamiento
        private AUD_AlmacenAreas areaMateriaPrima;
        public AUD_AlmacenAreas AreaMateriaPrima { get => areaMateriaPrima; set => SetProperty(ref areaMateriaPrima, value); }

        private AUD_AlmacenAreas areaMaterialAcondicionamiento;
        public AUD_AlmacenAreas AreaMaterialAcondicionamiento { get => areaMaterialAcondicionamiento; set => SetProperty(ref areaMaterialAcondicionamiento, value); }

        private AUD_AlmacenAreas areaProductoTerminado;
        public AUD_AlmacenAreas AreaProductoTerminado { get => areaProductoTerminado; set => SetProperty(ref areaProductoTerminado, value); }

        private AUD_AlmacenAreas areaProductoAGranel;
        public AUD_AlmacenAreas AreaProductoAGranel { get => areaProductoAGranel; set => SetProperty(ref areaProductoAGranel, value); }

        private AUD_AlmacenAreas areaProductoInflamable;
        public AUD_AlmacenAreas AreaProductoInflamable { get => areaProductoInflamable; set => SetProperty(ref areaProductoInflamable, value); }

        private AUD_AlmacenAreas areaProductoRechazados;
        public AUD_AlmacenAreas AreaProductoRechazados { get => areaProductoRechazados; set => SetProperty(ref areaProductoRechazados, value); }

        private AUD_AlmacenAreas areaDevoluciones;
        public AUD_AlmacenAreas AreaDevoluciones { get => areaDevoluciones; set => SetProperty(ref areaDevoluciones, value); }
                

        //Dispone de área de Almacenamiento?
        private enumAUD_TipoSeleccion disponeAlmacenamiento;
        public enumAUD_TipoSeleccion DisponeAlmacenamiento { get => disponeAlmacenamiento; set => SetProperty(ref disponeAlmacenamiento, value); }
        //Describa el lugar donde se almacenan y las medidas de seguridad
        private string disponeAlmacenamientoDesc;
        [StringLength(500)]
        public string DisponeAlmacenamientoDesc { get => disponeAlmacenamientoDesc; set => SetProperty(ref disponeAlmacenamientoDesc, value); }

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
        private string ctrIncendioExtintoresDesc;
        public string CtrIncendioExtintoresDesc { get => ctrIncendioExtintoresDesc; set => SetProperty(ref ctrIncendioExtintoresDesc, value); }

        // Alarma
        private enumAUD_TipoSeleccion ctrIncendioAlarma;
        public enumAUD_TipoSeleccion CtrIncendioAlarma { get => ctrIncendioAlarma; set => SetProperty(ref ctrIncendioAlarma, value); }
        private string ctrIncendioAlarmaDesc;
        public string CtrIncendioAlarmaDesc { get => ctrIncendioAlarmaDesc; set => SetProperty(ref ctrIncendioAlarmaDesc, value); }

        // Detectores de Humo
        private enumAUD_TipoSeleccion ctrIncendioDetectHumo;
        public enumAUD_TipoSeleccion CtrIncendioDetectHumo { get => ctrIncendioDetectHumo; set => SetProperty(ref ctrIncendioDetectHumo, value); }
        private string ctrIncendioDetectHumoDesc;
        public string CtrIncendioDetectHumoDesc { get => ctrIncendioDetectHumoDesc; set => SetProperty(ref ctrIncendioDetectHumoDesc, value); }

        // Duchas
        private enumAUD_TipoSeleccion ctrIncendioDuchas;
        public enumAUD_TipoSeleccion CtrIncendioDuchas { get => ctrIncendioDuchas; set => SetProperty(ref ctrIncendioDuchas, value); }
        private string ctrIncendioDuchasDesc;
        public string CtrIncendioDuchasDesc { get => ctrIncendioDuchasDesc; set => SetProperty(ref ctrIncendioDuchasDesc, value); }

        // Mangueras
        private enumAUD_TipoSeleccion ctrIncendioMangueras;
        public enumAUD_TipoSeleccion CtrIncendioMangueras { get => ctrIncendioMangueras; set => SetProperty(ref ctrIncendioMangueras, value); }
        private string ctrIncendioManguerasDesc;
        public string CtrIncendioManguerasDesc { get => ctrIncendioManguerasDesc; set => SetProperty(ref ctrIncendioManguerasDesc, value); }

        // Otros
        private enumAUD_TipoSeleccion ctrIncendioOtros;
        public enumAUD_TipoSeleccion CtrIncendioOtros { get => ctrIncendioOtros; set => SetProperty(ref ctrIncendioOtros, value); }
        private string ctrIncendioOtrosDesc;
        public string CtrIncendioOtrosDesc { get => ctrIncendioOtrosDesc; set => SetProperty(ref ctrIncendioOtrosDesc, value); }

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
        private string prodSobreAnaquelesDesc;
        public string ProdSobreAnaquelesDesc { get => prodSobreAnaquelesDesc; set => SetProperty(ref prodSobreAnaquelesDesc, value); }


        private enumAUD_TipoSeleccion prodSobreRacks;
        public enumAUD_TipoSeleccion ProdSobreRacks { get => prodSobreRacks; set => SetProperty(ref prodSobreRacks, value); }
        private string prodSobreRacksDesc;
        public string ProdSobreRacksDesc { get => prodSobreRacksDesc; set => SetProperty(ref prodSobreRacksDesc, value); }


        private enumAUD_TipoSeleccion prodSobreTarimas;
        public enumAUD_TipoSeleccion ProdSobreTarimas { get => prodSobreTarimas; set => SetProperty(ref prodSobreTarimas, value); }
        private string prodSobreTarimasDesc;
        public string ProdSobreTarimasDesc { get => prodSobreTarimasDesc; set => SetProperty(ref prodSobreTarimasDesc, value); }


        private enumAUD_TipoSeleccion prodSobrePalets;
        public enumAUD_TipoSeleccion ProdSobrePalets { get => prodSobrePalets; set => SetProperty(ref prodSobrePalets, value); }
        private string prodSobrePaletsDesc;
        public string ProdSobrePaletsDesc { get => prodSobrePaletsDesc; set => SetProperty(ref prodSobrePaletsDesc, value); }


        private enumAUD_TipoSeleccion prodSobreOtros;
        public enumAUD_TipoSeleccion ProdSobreOtros { get => prodSobreOtros; set => SetProperty(ref prodSobreOtros, value); }

        private string prodSobreOtrosDesc;
        public string ProdSobreOtrosDesc { get => prodSobreOtrosDesc; set => SetProperty(ref prodSobreOtrosDesc, value); }

        private enumAUD_TipoSeleccion prodSobreEstantes;
        public enumAUD_TipoSeleccion ProdSobreEstantes { get => prodSobreEstantes; set => SetProperty(ref prodSobreEstantes, value); }

        private string prodSobreEstantesDesc;
        public string ProdSobreEstantesDesc { get => prodSobreEstantesDesc; set => SetProperty(ref prodSobreEstantesDesc, value); }

        private enumAUD_TipoSeleccion prodSobreTablillas;
        public enumAUD_TipoSeleccion ProdSobreTablillas { get => prodSobreTablillas; set => SetProperty(ref prodSobreTablillas, value); }
        private string prodSobreTablillasDesc;
        public string ProdSobreTablillasDesc { get => prodSobreTablillasDesc; set => SetProperty(ref prodSobreTablillasDesc, value); }

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

        //Se mantiene monitoreo de la temperatura y humedad de esta área
        private enumAUD_TipoSeleccion sistMonitorTempHumArea;
        public enumAUD_TipoSeleccion SistMonitorTempHumArea { get => sistMonitorTempHumArea; set => SetProperty(ref sistMonitorTempHumArea, value); }

        // Observaciones
        private string sistMonitorTempHumAreaDesc;
        [StringLength(500)]
        public string SistMonitorTempHumAreaDesc { get => sistMonitorTempHumAreaDesc; set => SetProperty(ref sistMonitorTempHumAreaDesc, value); }


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

        //Existe letrero visible que identifique los rangos de temperatura y humedad
        private enumAUD_TipoSeleccion letreroVisibleIdentTempHum;
        public enumAUD_TipoSeleccion LetreroVisibleIdentTempHum { get => letreroVisibleIdentTempHum; set => SetProperty(ref letreroVisibleIdentTempHum, value); }
        private string letreroVisibleIdentTempHumDesc;
        public string LetreroVisibleIdentTempHumDesc { get => letreroVisibleIdentTempHumDesc; set => SetProperty(ref letreroVisibleIdentTempHumDesc, value); }

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


        // Los productos cumplen con las normas de etiquetado?
        private enumAUD_TipoSeleccion normasEtiquetado;
        public enumAUD_TipoSeleccion NormasEtiquetado { get => normasEtiquetado; set => SetProperty(ref normasEtiquetado, value); }
        private string normasEtiquetadoDesc;
        public string NormasEtiquetadoDesc { get => normasEtiquetadoDesc; set => SetProperty(ref normasEtiquetadoDesc, value); }

        // Existe un sistema de codificación que permite la rápida ubicación del producto?
        private enumAUD_TipoSeleccion sitemaCodificacion;
        public enumAUD_TipoSeleccion SitemaCodificacion { get => sitemaCodificacion; set => SetProperty(ref sitemaCodificacion, value); }
        private string sitemaCodificacionDesc;
        public string SitemaCodificacionDesc { get => sitemaCodificacionDesc; set => SetProperty(ref sitemaCodificacionDesc, value); }


        // El establecimiento utiliza el sistema FIFO/FEFO para el almacenamiento?
        private enumAUD_TipoSeleccion sitemaFifoFefo;
        public enumAUD_TipoSeleccion SitemaFifoFefo { get => sitemaFifoFefo; set => SetProperty(ref sitemaFifoFefo, value); }
        private string sitemaFifoFefoDesc;
        public string SitemaFifoFefoDesc { get => sitemaFifoFefoDesc; set => SetProperty(ref sitemaFifoFefoDesc, value); }

        // Dispone de un área destinada exclusivamente para almacenar materiales y productos de limpieza.?
        private enumAUD_TipoSeleccion areaAlmacenProdLimp;
        public enumAUD_TipoSeleccion AreaAlmacenProdLimp { get => areaAlmacenProdLimp; set => SetProperty(ref areaAlmacenProdLimp, value); }
        private string areaAlmacenProdLimpDesc;
        public string AreaAlmacenProdLimpDesc { get => areaAlmacenProdLimpDesc; set => SetProperty(ref areaAlmacenProdLimpDesc, value); }

        // Esta área es exclusiva para almacenar medicamentos y otros productos para la salud humana y no están mezclados o juntos con otros productos (alimentos, hidrocarburos, plaguicidas, otros) que pudieran afectar adversamente a los mismos?
        private enumAUD_TipoSeleccion areaExclusivaMedicam;
        public enumAUD_TipoSeleccion AreaExclusivaMedicam { get => areaExclusivaMedicam; set => SetProperty(ref areaExclusivaMedicam, value); }
        private string areaExclusivaMedicamDesc;
        public string AreaExclusivaMedicamDesc { get => areaExclusivaMedicamDesc; set => SetProperty(ref areaExclusivaMedicamDesc, value); }



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

        /////////////////////
        ///

        //Material Acondicionamiento
        private enumAUD_TipoSeleccion areaMaterialAcondicionado;
        public enumAUD_TipoSeleccion AreaMaterialAcondicionado { get => areaMaterialAcondicionado; set => SetProperty(ref areaMaterialAcondicionado, value); }

        // Observaciones
        private string areaMaterialAcondicionadoDesc;
        [StringLength(500)]
        public string AreaMaterialAcondicionadoDesc { get => areaMaterialAcondicionadoDesc; set => SetProperty(ref areaMaterialAcondicionadoDesc, value); }


        // Capacidad suficiente para permitir el almacenamiento ordenado de los productos y que facilite el manejo y circulación en el área   
        private enumAUD_TipoSeleccion capacidadAlmacenamientoOrdenado;
        public enumAUD_TipoSeleccion CapacidadAlmacenamientoOrdenado { get => capacidadAlmacenamientoOrdenado; set => SetProperty(ref capacidadAlmacenamientoOrdenado, value); }

        // Observaciones
        private string capacidadAlmacenamientoOrdenadoDesc;
        [StringLength(500)]
        public string CapacidadAlmacenamientoOrdenadoDesc { get => capacidadAlmacenamientoOrdenadoDesc; set => SetProperty(ref capacidadAlmacenamientoOrdenadoDesc, value); }


        //Area Seca
        private enumAUD_TipoSeleccion areaSeca;
        public enumAUD_TipoSeleccion AreaSeca { get => areaSeca; set => SetProperty(ref areaSeca, value); }

        // Observaciones
        private string areaSecaDesc;
        [StringLength(500)]
        public string AreaSecaDesc { get => areaSecaDesc; set => SetProperty(ref areaSecaDesc, value); }

        //Control Tempratura y Humedad
        private enumAUD_TipoSeleccion controlTempHumedad;
        public enumAUD_TipoSeleccion ControlTempHumedad { get => controlTempHumedad; set => SetProperty(ref controlTempHumedad, value); }

        // Observaciones
        private string controlTempHumedadDesc;
        [StringLength(500)]
        public string ControlTempHumedadDesc { get => controlTempHumedadDesc; set => SetProperty(ref controlTempHumedadDesc, value); }


        //Registro de Tempratura y Humedad
        private enumAUD_TipoSeleccion registroTempHumedad;
        public enumAUD_TipoSeleccion RegistroTempHumedad { get => registroTempHumedad; set => SetProperty(ref registroTempHumedad, value); }

        // Observaciones
        private string registroTempHumedadDesc;
        [StringLength(500)]
        public string RegistroTempHumedadDesc { get => registroTempHumedadDesc; set => SetProperty(ref registroTempHumedadDesc, value); }


        //Registro de Tempratura y Humedad
        private enumAUD_TipoSeleccion letrerosVisibleTempHumedad;
        public enumAUD_TipoSeleccion LetrerosVisibleTempHumedad { get => letrerosVisibleTempHumedad; set => SetProperty(ref letrerosVisibleTempHumedad, value); }

        // Observaciones
        private string letrerosVisibleTempHumedadDesc;
        [StringLength(500)]
        public string LetrerosVisibleTempHumedadDesc { get => letrerosVisibleTempHumedadDesc; set => SetProperty(ref letrerosVisibleTempHumedadDesc, value); }


        // Recepción y despacho protegida de las inclemencias del tiempo. 
        private enumAUD_TipoSeleccion recepDespachoProtegida;
        public enumAUD_TipoSeleccion RecepDespachoProtegida { get => recepDespachoProtegida; set => SetProperty(ref recepDespachoProtegida, value); }

        // Observaciones
        private string recepDespachoProtegidaDesc;
        [StringLength(500)]
        public string RecepDespachoProtegidaDesc { get => recepDespachoProtegidaDesc; set => SetProperty(ref recepDespachoProtegidaDesc, value); }

        // Áreas de cuarentena: identificadas y de acceso restringido
        private enumAUD_TipoSeleccion areaCuarentenaIdentif;
        public enumAUD_TipoSeleccion AreaCuarentenaIdentif { get => areaCuarentenaIdentif; set => SetProperty(ref areaCuarentenaIdentif, value); }

        // Observaciones
        private string areaCuarentenaIdentifDesc;
        [StringLength(500)]
        public string AreaCuarentenaIdentifDesc { get => areaCuarentenaIdentifDesc; set => SetProperty(ref areaCuarentenaIdentifDesc, value); }

        // Área para almacenar productos rechazados, retirados o devueltos
        private enumAUD_TipoSeleccion areaProductosRechazados;
        public enumAUD_TipoSeleccion AreaProductosRechazados { get => areaProductosRechazados; set => SetProperty(ref areaProductosRechazados, value); }

        // Observaciones
        private string areaProductosRechazadosDesc;
        [StringLength(500)]
        public string AreaProductosRechazadosDesc { get => areaProductosRechazadosDesc; set => SetProperty(ref areaProductosRechazadosDesc, value); }


        // Área para almacenar sustancias con riesgo a fuego o explosión
        private enumAUD_TipoSeleccion areaAlmacenProdRiesgoExplosion;
        public enumAUD_TipoSeleccion AreaAlmacenProdRiesgoExplosion { get => areaAlmacenProdRiesgoExplosion; set => SetProperty(ref areaAlmacenProdRiesgoExplosion, value); }

        // Observaciones
        private string areaAlmacenProdRiesgoExplosionDesc;
        [StringLength(500)]
        public string AreaAlmacenProdRiesgoExplosionDesc { get => areaAlmacenProdRiesgoExplosionDesc; set => SetProperty(ref areaAlmacenProdRiesgoExplosionDesc, value); }


        // Área de almacenamiento para Etiquetas, material impreso
        private enumAUD_TipoSeleccion areaAlmEtiquetasMatImpreso;
        public enumAUD_TipoSeleccion AreaAlmEtiquetasMatImpreso { get => areaAlmEtiquetasMatImpreso; set => SetProperty(ref areaAlmEtiquetasMatImpreso, value); }

        // Observaciones
        private string areaAlmEtiquetasMatImpresoDesc;
        [StringLength(500)]
        public string AreaAlmEtiquetasMatImpresoDesc { get => areaAlmEtiquetasMatImpresoDesc; set => SetProperty(ref areaAlmEtiquetasMatImpresoDesc, value); }


        // Existen advertencias o prohibiciones de: no comer, no beber, no fumar,  no guardar plantas comidas y bebidas
        private enumAUD_TipoSeleccion advertenciaNoComerBeberEtc;
        public enumAUD_TipoSeleccion AdvertenciaNoComerBeberEtc { get => advertenciaNoComerBeberEtc; set => SetProperty(ref advertenciaNoComerBeberEtc, value); }

        // Observaciones
        private string advertenciaNoComerBeberEtcDesc;
        [StringLength(500)]
        public string AdvertenciaNoComerBeberEtcDesc { get => advertenciaNoComerBeberEtcDesc; set => SetProperty(ref advertenciaNoComerBeberEtcDesc, value); }


        // Los servicios sanitarios no comunican directamente
        // MATERIA PRIMA
        private enumAUD_TipoSeleccion servSanitarioNoComDirect;
        public enumAUD_TipoSeleccion ServSanitarioNoComDirect { get => servSanitarioNoComDirect; set => SetProperty(ref servSanitarioNoComDirect, value); }

        // Observaciones
        private string servSanitarioNoComDirectDesc;
        [StringLength(500)]
        public string ServSanitarioNoComDirectDesc { get => servSanitarioNoComDirectDesc; set => SetProperty(ref servSanitarioNoComDirectDesc, value); }

        // Señalización de las vías o rutas de evacuación en casos de siniestro o catástrofe
        // MATERIA PRIMA
        private enumAUD_TipoSeleccion senalRutasEvacuacion;
        public enumAUD_TipoSeleccion SenalRutasEvacuacion { get => senalRutasEvacuacion; set => SetProperty(ref senalRutasEvacuacion, value); }

        // Observaciones
        private string senalRutasEvacuacionDesc;
        [StringLength(500)]
        public string SenalRutasEvacuacionDesc { get => senalRutasEvacuacionDesc; set => SetProperty(ref senalRutasEvacuacionDesc, value); }

        // Señalización de las vías o rutas de evacuación en casos de siniestro o catástrofe
        // MATERIA PRIMA
        private enumAUD_TipoSeleccion ctrIncendio;
        public enumAUD_TipoSeleccion CtrIncendio { get => ctrIncendio; set => SetProperty(ref ctrIncendio, value); }


        // De acuerdo al criterio técnico del Farmacéutico inspector, la capacidad del área es suficiente para almacenar productos, manejo adecuado de productos y circulación del personal Sí  No  , de ser negativa la respuesta, indicar motivo
        private enumAUD_TipoSeleccion criterioTecInspector;
        public enumAUD_TipoSeleccion CriterioTecInspector { get => criterioTecInspector; set => SetProperty(ref criterioTecInspector, value); }
        // Observaciones
        private string criterioTecInspectorDesc;
        [StringLength(500)]
        public string CriterioTecInspectorDesc { get => criterioTecInspectorDesc; set => SetProperty(ref criterioTecInspectorDesc, value); }


        // Los muebles son colocados manteniendo un pie de distancia de las paredes y del techo
        private enumAUD_TipoSeleccion areaDesperdicio;
        public enumAUD_TipoSeleccion AreaDesperdicio { get => areaDesperdicio; set => SetProperty(ref areaDesperdicio, value); }

        // Observaciones
        private string areaDesperdicioDesc;
        [StringLength(500)]
        public string AreaDesperdicioDesc { get => areaDesperdicioDesc; set => SetProperty(ref areaDesperdicioDesc, value); }


        // Los muebles son colocados manteniendo un pie de distancia de las paredes y del techo
        private enumAUD_TipoSeleccion almacenLibrePolvo;
        public enumAUD_TipoSeleccion AlmacenLibrePolvo { get => almacenLibrePolvo; set => SetProperty(ref almacenLibrePolvo, value); }

        // Observaciones
        private string almacenLibrePolvoDesc;
        [StringLength(500)]
        public string AlmacenLibrePolvoDesc { get => almacenLibrePolvoDesc; set => SetProperty(ref almacenLibrePolvoDesc, value); }

    }

    public class AUD_AlmacenAreas : SystemId
    {
        //Están debidamente identificadas
        private enumAUD_TipoSeleccion identificada;
        public enumAUD_TipoSeleccion Identificada { get => identificada; set => SetProperty(ref identificada, value); }

        //Los pisos, paredes, techos de los almacenes están construidos de tal forma que no afectan la calidad de los materiales y productos que se almacenan y permite la fácil limpieza
        private enumAUD_TipoSeleccion pisoParedesTechosCalidad;
        public enumAUD_TipoSeleccion PisoParedesTechosCalidad { get => pisoParedesTechosCalidad; set => SetProperty(ref pisoParedesTechosCalidad, value); }

        //Tienen las áreas de almacenamiento suficiente capacidad para permitir el almacenamiento ordenado de las diferentes categorías de materiales y productos?
        private enumAUD_TipoSeleccion capacidadSuficiente;
        public enumAUD_TipoSeleccion CapacidadSuficiente { get => capacidadSuficiente; set => SetProperty(ref capacidadSuficiente, value); }

        //Las instalaciones eléctricas están diseñadas y ubicadas de tal forma que facilitan la limpieza?
        private enumAUD_TipoSeleccion instElectFacilitaLimpieza;
        public enumAUD_TipoSeleccion InstElectFacilitaLimpieza { get => instElectFacilitaLimpieza; set => SetProperty(ref instElectFacilitaLimpieza, value); }

        //Hay instrumentos para medir la temperatura y humedad y estas mediciones están dentro de los parámetros establecidos para los materiales y productos almacenados?
        private enumAUD_TipoSeleccion instrumentoMedHumTemp;
        public enumAUD_TipoSeleccion InstrumentoMedHumTemp { get => instrumentoMedHumTemp; set => SetProperty(ref instrumentoMedHumTemp, value); }

        //Para las materias primas y productos que requieren condiciones especiales de enfriamiento, existe cámara fría?
        private enumAUD_TipoSeleccion existeCamaraFria;
        public enumAUD_TipoSeleccion ExisteCamaraFria { get => existeCamaraFria; set => SetProperty(ref existeCamaraFria, value); }

        //Están protegidas de las condiciones ambientales las áreas de recepción y despacho
        private enumAUD_TipoSeleccion protegidaCondiAmbientales;
        public enumAUD_TipoSeleccion ProtegidaCondiAmbientales { get => protegidaCondiAmbientales; set => SetProperty(ref protegidaCondiAmbientales, value); }

        //Existe un área de despacho de producto terminado? 
        private enumAUD_TipoSeleccion existeAreaDespachoProd;
        public enumAUD_TipoSeleccion ExisteAreaDespachoProd { get => existeAreaDespachoProd; set => SetProperty(ref existeAreaDespachoProd, value); }

        //Las áreas donde se almacenan materiales y productos sometidos a cuarentena están claramente definidas y marcadas, el acceso a las mismas está limitado sólo al personal autorizado? 
        private enumAUD_TipoSeleccion areaCuarentenaDefinida;
        public enumAUD_TipoSeleccion AreaCuarentenaDefinida { get => areaCuarentenaDefinida; set => SetProperty(ref areaCuarentenaDefinida, value); }

        //El muestreo de materia prima se efectúa en área separada o en el área de pesaje o dispensado? 
        private enumAUD_TipoSeleccion muestreoMateriaPrima;
        public enumAUD_TipoSeleccion MuestreoMateriaPrima { get => muestreoMateriaPrima; set => SetProperty(ref muestreoMateriaPrima, value); }

        //Se utilizan materias primas psicotrópicas o estupefacientes? 
        private enumAUD_TipoSeleccion materiaPrimaPsicotropica;
        public enumAUD_TipoSeleccion MateriaPrimaPsicotropica { get => materiaPrimaPsicotropica; set => SetProperty(ref materiaPrimaPsicotropica, value); }

        //Existen áreas separadas, bajo llave, de acceso restringido e identificadas para almacenar materias primas y productos psicotrópicos y estupefacientes
        private enumAUD_TipoSeleccion areaBajoLlaveStupefacientes;
        public enumAUD_TipoSeleccion AreaBajoLlaveStupefacientes { get => areaBajoLlaveStupefacientes; set => SetProperty(ref areaBajoLlaveStupefacientes, value); }

        //Cuenta el laboratorio con áreas de almacenamiento separadas para productos rechazados, retirados y devueltos? 
        private enumAUD_TipoSeleccion areaProdRechazados;
        public enumAUD_TipoSeleccion AreaProdRechazados { get => areaProdRechazados; set => SetProperty(ref areaProdRechazados, value); }

        //Tienen estas áreas acceso restringido y bajo llave?
        private enumAUD_TipoSeleccion areaProdRechazadosRestring;
        public enumAUD_TipoSeleccion AreaProdRechazadosRestring { get => areaProdRechazadosRestring; set => SetProperty(ref areaProdRechazadosRestring, value); }

        //Existe un área separada y de acceso restringido para almacenar material impreso (etiquetas, estuches, insertos y envases impresos)?
        private enumAUD_TipoSeleccion almacenMaterialImpreso;
        public enumAUD_TipoSeleccion AlmacenMaterialImpreso { get => almacenMaterialImpreso; set => SetProperty(ref almacenMaterialImpreso, value); }

        //Está identificada?
        private enumAUD_TipoSeleccion almacenMaterialImpresoIdentif;
        public enumAUD_TipoSeleccion AlmacenMaterialImpresoIdentif { get => almacenMaterialImpresoIdentif; set => SetProperty(ref almacenMaterialImpresoIdentif, value); }

        //Existe un área para almacenamiento de productos inflamables y explosivos alejada de las otras instalaciones, es ventilada y cuenta con medidas de seguridad contra incendios o explosiones según la legislación nacional?
        private enumAUD_TipoSeleccion almacenProdInflamables;
        public enumAUD_TipoSeleccion AlmacenProdInflamables { get => almacenProdInflamables; set => SetProperty(ref almacenProdInflamables, value); }

    }

    

}
