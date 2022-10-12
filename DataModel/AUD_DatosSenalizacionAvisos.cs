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
    /// Datos de Señalizacion y Avisos
    /// </summary>
    public class AUD_DatosSenalizacionAvisos : SystemId
    {
        //salidas Emergencia
        private bool salidasEmergencia;
        public bool SalidasEmergencia { get => salidasEmergencia; set => SetProperty(ref salidasEmergencia, value); }

        //no Comer en Instalacion
        private bool noComerInstalac;
        public bool NoComerInstalac { get => noComerInstalac; set => SetProperty(ref noComerInstalac, value); }

        //no Beber en Instalacion
        private bool noBeberInstalac;
        public bool NoBeberInstalac { get => noBeberInstalac; set => SetProperty(ref noBeberInstalac, value); }

        //no Fumar en Instalacion
        private bool noFumarInstalac;
        public bool NoFumarInstalac { get => noFumarInstalac; set => SetProperty(ref noFumarInstalac, value); }

        //no guardar plantas en Instalacion
        private bool noPlantasInstalac;
        public bool NoPlantasInstalac { get => noPlantasInstalac; set => SetProperty(ref noPlantasInstalac, value); }

        //Existe un sistema para el control de fauna nociva (Cebadera y certificado de fumigación).
        private bool existeSistemaControlFauna;
        public bool ExisteSistemaControlFauna { get => existeSistemaControlFauna; set => SetProperty(ref existeSistemaControlFauna, value); }

        //Área de Asesoría Farmacéutica delimitada e identificada que permita la interacción privada entre farmacéutico y paciente.
        private bool areaAsesoriaFarmaceutica;
        public bool AreaAsesoriaFarmaceutica { get => areaAsesoriaFarmaceutica; set => SetProperty(ref areaAsesoriaFarmaceutica, value); }

        //Área de consultas bibliográficas
        private bool areaConsultasBibliograficas;
        public bool AreaConsultasBibliograficas { get => areaConsultasBibliograficas; set => SetProperty(ref areaConsultasBibliograficas, value); }

        //Área delimitada, segregada e identificada de productos vencidos (devolución)
        private bool areaProductosVencidos;
        public bool AreaProductosVencidos { get => areaProductosVencidos; set => SetProperty(ref areaProductosVencidos, value); }

        //Refrigeradora para productos que requiere condiciones especiales de temperatura
        private bool refrigeradoraProductosEspeciales;
        public bool RefrigeradoraProductosEspeciales { get => refrigeradoraProductosEspeciales; set => SetProperty(ref refrigeradoraProductosEspeciales, value); }

        //Termómetro para el refrigerador y formato de registro de temperatura 
        private bool termometroRefrigeradora;
        public bool TermometroRefrigeradora { get => termometroRefrigeradora; set => SetProperty(ref termometroRefrigeradora, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string termometroRefrigeradoraDescrip;
        public string TermometroRefrigeradoraDescrip { get => termometroRefrigeradoraDescrip; set => SetProperty(ref termometroRefrigeradoraDescrip, value); }

        //Termómetro para el refrigerador y formato de registro de temperatura 
        private bool farmaciaRelaDirectaClinica;
        public bool FarmaciaRelaDirectaClinica { get => farmaciaRelaDirectaClinica; set => SetProperty(ref farmaciaRelaDirectaClinica, value); }
        // Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
        private string farmaciaRelaDirectaClinicaDescrip;
        public string FarmaciaRelaDirectaClinicaDescrip { get => farmaciaRelaDirectaClinicaDescrip; set => SetProperty(ref farmaciaRelaDirectaClinicaDescrip, value); }

    }
}
