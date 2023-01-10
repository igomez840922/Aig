using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_FfFallaReportada:SystemId
    {
        // Olor
        private enumOpcionSiNo olor;
        public enumOpcionSiNo Olor { get => olor; set => SetProperty(ref olor, value); }

        // Color
        private enumOpcionSiNo color;
        public enumOpcionSiNo Color { get => color; set => SetProperty(ref color, value); }

        // Sabor
        private enumOpcionSiNo sabor;
        public enumOpcionSiNo Sabor { get => sabor; set => SetProperty(ref sabor, value); }

        // Separación de Fases
        private enumOpcionSiNo sepFases;
        public enumOpcionSiNo SepFases { get => sepFases; set => SetProperty(ref sepFases, value); }

        // Partículas extrañas
        private enumOpcionSiNo parExtrana;
        public enumOpcionSiNo ParExtrana { get => parExtrana; set => SetProperty(ref parExtrana, value); }

        // Contaminación
        private enumOpcionSiNo contaminacion;
        public enumOpcionSiNo Contaminacion { get => contaminacion; set => SetProperty(ref contaminacion, value); }

        // Problemas de Disolución
        private enumOpcionSiNo proDisolucion;
        public enumOpcionSiNo ProDisolucion { get => proDisolucion; set => SetProperty(ref proDisolucion, value); }

        // Precipitación
        private enumOpcionSiNo precipitacion;
        public enumOpcionSiNo Precipitacion { get => precipitacion; set => SetProperty(ref precipitacion, value); }

        // Problemas de Desintegración
        private enumOpcionSiNo proDesintegracion;
        public enumOpcionSiNo ProDesintegracion { get => proDesintegracion; set => SetProperty(ref proDesintegracion, value); }

        // Otros
        private enumOpcionSiNo otros;
        public enumOpcionSiNo Otros { get => otros; set => SetProperty(ref otros, value); }

        // Detalle de falla reportada
        private string detFallaReport;
        public string DetFallaReport { get => detFallaReport; set => SetProperty(ref detFallaReport, value); }

    }
}
