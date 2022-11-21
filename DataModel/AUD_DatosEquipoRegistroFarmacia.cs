using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosEquipoRegistroFarmacia : SystemId
    {
        // Aire acondicionado adecuado para mantener las condiciones de almacenamiento
        private enumAUD_TipoSeleccion aireAcondAdecuado;
        public enumAUD_TipoSeleccion AireAcondAdecuado { get => aireAcondAdecuado; set => SetProperty(ref aireAcondAdecuado, value); }

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

        // Cuenta con programa de calibración de equipos, como equipo para la medición de Temperatura y Humedad relativa
        private enumAUD_TipoSeleccion progCalibracionEquipo;
        public enumAUD_TipoSeleccion ProgCalibracionEquipo { get => progCalibracionEquipo; set => SetProperty(ref progCalibracionEquipo, value); }

        // Cuenta con programa de mantenimiento preventivo de cualquier defecto o condiciones no adecuadas de las estructuras 
        private enumAUD_TipoSeleccion progMantenimPrevent;
        public enumAUD_TipoSeleccion ProgMantenimPrevent { get => progMantenimPrevent; set => SetProperty(ref progMantenimPrevent, value); }


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

    }
}
