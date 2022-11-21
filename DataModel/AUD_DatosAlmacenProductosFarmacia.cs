using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosAlmacenProductosFarmacia : SystemId
    {
        public AUD_DatosAlmacenProductosFarmacia()
        {
            ProductosInflamables = new AUD_DatosAlmacenProductosFarmaciaProductoInflamable();
        }

        //Área esta identificada y delimitada
        private enumAUD_TipoSeleccion identificadaDelimitada;
        public enumAUD_TipoSeleccion IdentificadaDelimitada { get => identificadaDelimitada; set => SetProperty(ref identificadaDelimitada, value); }

        //Posee espacio físico adecuado para el movimiento y operación del personal
        private enumAUD_TipoSeleccion espacioAdecuadoMovOperacional;
        public enumAUD_TipoSeleccion EspacioAdecuadoMovOperacional { get => espacioAdecuadoMovOperacional; set => SetProperty(ref espacioAdecuadoMovOperacional, value); }

        //Aire acondicionado adecuado para mantener las condiciones de almacenamiento
        private enumAUD_TipoSeleccion aireAcondAdecMantAlmacen;
        public enumAUD_TipoSeleccion AireAcondAdecMantAlmacen { get => aireAcondAdecMantAlmacen; set => SetProperty(ref aireAcondAdecMantAlmacen, value); }

        // Higrotermómetro                                       
        private enumAUD_TipoSeleccion higrotermometro;
        public enumAUD_TipoSeleccion Higrotermometro { get => higrotermometro; set => SetProperty(ref higrotermometro, value); }

        // Valor Temperatura
        private string higrotermometroTempVal;
        public string HigrotermometroTempVal { get => higrotermometroTempVal; set => SetProperty(ref higrotermometroTempVal, value); }

        // Valor Humedad Relativa
        private string higrotermometroHumVal;
        public string HigrotermometroHumVal { get => higrotermometroHumVal; set => SetProperty(ref higrotermometroHumVal, value); }

        // Formato de registro de Temperatura y Humedad de relativa (mínimo dos veces al día)
        private enumAUD_TipoSeleccion registroTempHumedad;
        public enumAUD_TipoSeleccion RegistroTempHumedad { get => registroTempHumedad; set => SetProperty(ref registroTempHumedad, value); }

        // Refrigeradora para productos que requieren condiciones especiales de temperatura
        private enumAUD_TipoSeleccion refrigProdCondEspecial;
        public enumAUD_TipoSeleccion RefrigProdCondEspecial { get => refrigProdCondEspecial; set => SetProperty(ref refrigProdCondEspecial, value); }

        // Termómetro para el refrigerador
        private enumAUD_TipoSeleccion termometRefri;
        public enumAUD_TipoSeleccion TermometRefri { get => termometRefri; set => SetProperty(ref termometRefri, value); }

        // Valor Temperatura
        private string termometRefriTempVal;
        public string TermometRefriTempVal { get => termometRefriTempVal; set => SetProperty(ref termometRefriTempVal, value); }

        // Valor Humedad Relativa
        private string termometRefriHumVal;
        public string TermometRefriHumVal { get => termometRefriHumVal; set => SetProperty(ref termometRefriHumVal, value); }

        // Formato de registro de temperatura de la refrigeradora
        private enumAUD_TipoSeleccion registroTempRefri;
        public enumAUD_TipoSeleccion RegistroTempRefri { get => registroTempRefri; set => SetProperty(ref registroTempRefri, value); }

        //Los productos farmacéuticos se almacenan sobre anaqueles, racks, tarimas o pallets (circular)
        private enumAUD_TipoSeleccion prodSobreAnaquelesRacksEtc;
        public enumAUD_TipoSeleccion ProdSobreAnaquelesRacksEtc { get => prodSobreAnaquelesRacksEtc; set => SetProperty(ref prodSobreAnaquelesRacksEtc, value); }

        // Muebles separados de las paredes, pisos y techos 
        private enumAUD_TipoSeleccion mueblesSeparados;
        public enumAUD_TipoSeleccion MueblesSeparados { get => mueblesSeparados; set => SetProperty(ref mueblesSeparados, value); }

        // Posee buena iluminación 
        private enumAUD_TipoSeleccion iluminacion;
        public enumAUD_TipoSeleccion Iluminacion { get => iluminacion; set => SetProperty(ref iluminacion, value); }

        // Existe un sistema de inventario que permita determinar la vigencia de los productos farmacéutico (FIFO/FEFO)
        private enumAUD_TipoSeleccion sitemaFifoFefo;
        public enumAUD_TipoSeleccion SitemaFifoFefo { get => sitemaFifoFefo; set => SetProperty(ref sitemaFifoFefo, value); }

        // Extintor contra incendios (vigentes y aprobado por el cuerpo de bomberos) 
        private enumAUD_TipoSeleccion extintorIncendio;
        public enumAUD_TipoSeleccion ExtintorIncendio { get => extintorIncendio; set => SetProperty(ref extintorIncendio, value); }

        // Alarmas contra incendios o detector de humo
        private enumAUD_TipoSeleccion alarmIncendio;
        public enumAUD_TipoSeleccion AlarmIncendio { get => alarmIncendio; set => SetProperty(ref alarmIncendio, value); }

        // Luces de emergencia
        private enumAUD_TipoSeleccion lucesEmergencia;
        public enumAUD_TipoSeleccion LucesEmergencia { get => lucesEmergencia; set => SetProperty(ref lucesEmergencia, value); }

        // Control de fauna nociva (cebadera y certificado de fumigación)
        private enumAUD_TipoSeleccion controlFaunaNociva;
        public enumAUD_TipoSeleccion ControlFaunaNociva { get => controlFaunaNociva; set => SetProperty(ref controlFaunaNociva, value); }

        //Área de vencidos o deteriorados separada e identificada
        private enumAUD_TipoSeleccion areaVencidos;
        public enumAUD_TipoSeleccion AreaVencidos { get => areaVencidos; set => SetProperty(ref areaVencidos, value); }

        //Área de desperdicios, identificada y delimitada
        private enumAUD_TipoSeleccion areaDesperdicios;
        public enumAUD_TipoSeleccion AreaDesperdicios { get => areaDesperdicios; set => SetProperty(ref areaDesperdicios, value); }

        //Productos Inflamables - Alcohol
        private AUD_DatosAlmacenProductosFarmaciaProductoInflamable productosInflamables;
        public AUD_DatosAlmacenProductosFarmaciaProductoInflamable ProductosInflamables { get => productosInflamables; set => SetProperty(ref productosInflamables, value); }

    }

    public class AUD_DatosAlmacenProductosFarmaciaProductoInflamable : SystemId
    {
        //Se encuentra separada, ventilada 
        private enumAUD_TipoSeleccion separaVentilada;
        public enumAUD_TipoSeleccion SeparaVentilada { get => separaVentilada; set => SetProperty(ref separaVentilada, value); }

        // Extintor contra incendios (vigentes y aprobado por el cuerpo de bomberos) 
        private enumAUD_TipoSeleccion extintorIncendio;
        public enumAUD_TipoSeleccion ExtintorIncendio { get => extintorIncendio; set => SetProperty(ref extintorIncendio, value); }

        // Alarmas contra incendios o detector de humo
        private enumAUD_TipoSeleccion alarmIncendio;
        public enumAUD_TipoSeleccion AlarmIncendio { get => alarmIncendio; set => SetProperty(ref alarmIncendio, value); }

        // Luces de emergencia
        private enumAUD_TipoSeleccion lucesEmergencia;
        public enumAUD_TipoSeleccion LucesEmergencia { get => lucesEmergencia; set => SetProperty(ref lucesEmergencia, value); }


        // Kit de emergencia para el manejo de derrame de sustancias peligrosas o corrosivas
        private enumAUD_TipoSeleccion kitEmergenciaManejoDerrame;
        public enumAUD_TipoSeleccion KitEmergenciaManejoDerrame { get => kitEmergenciaManejoDerrame; set => SetProperty(ref kitEmergenciaManejoDerrame, value); }

    }
}
