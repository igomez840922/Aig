using DataBindable;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    /// <summary>
    /// Datos de Preguntas Genericas
    /// </summary>
    public class AUD_DatosPreguntasGenericas : SystemId
    {
        //Anuncio visible y legible frente al recetario con la instrucción del Art. 151 de la Ley 1 de 10 de enero de 2001
        private bool anuncioVisibleLeyArt151;
        public bool AnuncioVisibleLeyArt151 { get => anuncioVisibleLeyArt151; set => SetProperty(ref anuncioVisibleLeyArt151, value); }


        //Anuncio visible y legible de Tabla de Promedio y Precio Mínimo Unitario de la Canasta básica de Medicamentos (De Referencia y Genéricos), según monitoreo de precios realizado en las principales farmacias. Resolución No. 774 de lunes 7 de octubre de 2019. "Por medio de la cual se amplía la Canasta Básica de Medicamentos (CABAMED) DE 40 A 153 Productos Farmacéuticos":
        private bool anuncioVisibleTablaPromPrecio;
        public bool AnuncioVisibleTablaPromPrecio { get => anuncioVisibleTablaPromPrecio; set => SetProperty(ref anuncioVisibleTablaPromPrecio, value); }

        //Anuncio visible y legible de Art. 1 y Art. 2 de Ley 17 de 12 de septiembre de 2014. “Que adiciona disposiciones a la Ley 1 de 2001, sobre medicamentos y otros productos para la salud humana, para prohibir la venta o cobro de bebidas alcohólicas en los establecimientos farmacéuticos”.
        private bool anuncioVisibleLeyArt1;
        public bool AnuncioVisibleLeyArt1 { get => anuncioVisibleLeyArt1; set => SetProperty(ref anuncioVisibleLeyArt1, value); }

        //Farmacia Privada: Anuncio visible y legible Art. 655 y Art. 656 del Decreto Ejecutivo 115 de 16 de agosto de 2022.
        private bool anuncioVisibleLeyArt656;
        public bool AnuncioVisibleLeyArt656 { get => anuncioVisibleLeyArt656; set => SetProperty(ref anuncioVisibleLeyArt656, value); }

        //Higrótermometro y formato de registro de temperatura y humedad relativa. El registro y control de los parámetros debe ser como mínimo dos veces al día de preferencia en horas de la mañana y mediodía.
        private bool registroTempHumedadRelat;
        public bool RegistroTempHumedadRelat { get => registroTempHumedadRelat; set => SetProperty(ref registroTempHumedadRelat, value); }

        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string registroTempHumedadRelatDescrip;
        public string RegistroTempHumedadRelatDescrip { get => registroTempHumedadRelatDescrip; set => SetProperty(ref registroTempHumedadRelatDescrip, value); }

        //Cuenta con programa de calibración de equipos como equipo para la medición de temperatura y humedad relativa.
        private bool programaCalibracion;
        public bool ProgramaCalibracion { get => programaCalibracion; set => SetProperty(ref programaCalibracion, value); }

        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string programaCalibracionDescrip;
        public string ProgramaCalibracionDescrip { get => programaCalibracionDescrip; set => SetProperty(ref programaCalibracionDescrip, value); }

        //El espacio físico es de un mínimo de 20 metros cuadrados. Esto incluye la ubicación de los medicamentos y otros productos para la salud humana, el área de consulta farmacéutica, el área de asesoría bibliográfica, el área administrativa del farmacéutico. Que permita adecuada y cómodamente las labores al personal. No incluye el área de Almacén de Medicamentos y Otros Productos para la Salud Humana.
        private bool espacioFisicoMin20;
        public bool EspacioFisicoMin20 { get => espacioFisicoMin20; set => SetProperty(ref espacioFisicoMin20, value); }

        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string espacioFisicoMin20Descrip;
        public string EspacioFisicoMin20Descrip { get => espacioFisicoMin20Descrip; set => SetProperty(ref espacioFisicoMin20Descrip, value); }

        //Área de gestión administrativa del farmacéutico indentificada.
        private bool areaGestionAdmin;
        public bool AreaGestionAdmin { get => areaGestionAdmin; set => SetProperty(ref areaGestionAdmin, value); }

        //Área separada para la alimentación del personal
        private bool areaSeparadaAlimentPersonal;
        public bool AreaSeparadaAlimentPersonal { get => areaSeparadaAlimentPersonal; set => SetProperty(ref areaSeparadaAlimentPersonal, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string areaSeparadaAlimentPersonalDescrip;
        public string AreaSeparadaAlimentPersonalDescrip { get => areaSeparadaAlimentPersonalDescrip; set => SetProperty(ref areaSeparadaAlimentPersonalDescrip, value); }

        //Sanitario para el personal. En caso de que la farmacia esté ubicada en locales comerciales o similares y el mismo posea baños comunes (para compartir entre los locales comerciales). Será permitido siempre y cuando el personal de la farmacia mantenga los debidos cuidados de higiene.
        private bool sanitarioPersonal;
        public bool SanitarioPersonal { get => sanitarioPersonal; set => SetProperty(ref sanitarioPersonal, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string sanitarioPersonalDescrip;
        public string SanitarioPersonalDescrip { get => sanitarioPersonalDescrip; set => SetProperty(ref sanitarioPersonalDescrip, value); }

        //Aire acondicionado para mantener las condiciones de almacenamiento
        private bool aireAcondicionadoCondAliment;
        public bool AireAcondicionadoCondAliment { get => aireAcondicionadoCondAliment; set => SetProperty(ref aireAcondicionadoCondAliment, value); }

        //Extintores contra incendios(vigentes y aprobados por el cuerpo de Bomberos)
        private bool extintoresIncendio;
        public bool ExtintoresIncendio { get => extintoresIncendio; set => SetProperty(ref extintoresIncendio, value); }

        //Alarmas contra incendio  o detector de humo
        private bool alarmaIntrusoIncendio;
        public bool AlarmaIntrusoIncendio { get => alarmaIntrusoIncendio; set => SetProperty(ref alarmaIntrusoIncendio, value); }

        //Luces de Emergencia
        private bool lucesEmergencias;
        public bool LucesEmergencias { get => lucesEmergencias; set => SetProperty(ref lucesEmergencias, value); }

        //salida emergencia
        private bool salidaEmergencias;
        public bool SalidaEmergencias { get => salidaEmergencias; set => SetProperty(ref salidaEmergencias, value); }

        //No Comer
        private bool noComer;
        public bool NoComer { get => noComer; set => SetProperty(ref noComer, value); }

        //No Beber
        private bool noBeber;
        public bool NoBeber { get => noBeber; set => SetProperty(ref noBeber, value); }

        //No Fumar
        private bool noFumar;
        public bool NoFumar { get => noFumar; set => SetProperty(ref noFumar, value); }

        //No Fumar
        private bool noGuardarPlantasComidasBebidas;
        public bool NoGuardarPlantasComidasBebidas { get => noGuardarPlantasComidasBebidas; set => SetProperty(ref noGuardarPlantasComidasBebidas, value); }

        ////Asesoria Farmaceutica
        //private bool asesoriaFarmaceutica;
        //public bool AsesoriaFarmaceutica { get => asesoriaFarmaceutica; set => SetProperty(ref asesoriaFarmaceutica, value); }

        ////Consulta Bibliografica
        //private bool consultaBibliografica;
        //public bool ConsultaBibliografica { get => consultaBibliografica; set => SetProperty(ref consultaBibliografica, value); }

        ////productos Vencidos
        //private bool productosVencidos;
        //public bool ProductosVencidos { get => productosVencidos; set => SetProperty(ref productosVencidos, value); }

        ////Refrigeradora para productos que requiere condiciones especiales de temperatura
        //private bool refriProductosCondEspeciales;
        //public bool RefriProductosCondEspeciales { get => refriProductosCondEspeciales; set => SetProperty(ref refriProductosCondEspeciales, value); }

    }
}
