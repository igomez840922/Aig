using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_DatosGeneralesFarmacia: SystemId
    {
        //NOMBRE DEL ESTABLECIMIENTO:
        private string nombreEstablecimiento;
        [StringLength(250)]
        public string NombreEstablecimiento { get => nombreEstablecimiento; set => SetProperty(ref nombreEstablecimiento, value); }

        // Dispone de su letrero visible con su nombre
        private enumAUD_TipoSeleccion letreroVisibleNombre;
        public enumAUD_TipoSeleccion LetreroVisibleNombre { get => letreroVisibleNombre; set => SetProperty(ref letreroVisibleNombre, value); }

        // Actividades
        private enumAUD_TipoSeleccion actAdquisicionPorMayor;
        public enumAUD_TipoSeleccion ActAdquisicionPorMayor { get => actAdquisicionPorMayor; set => SetProperty(ref actAdquisicionPorMayor, value); }
        private enumAUD_TipoSeleccion actDispMedicamento;
        public enumAUD_TipoSeleccion ActDispMedicamento { get => actDispMedicamento; set => SetProperty(ref actDispMedicamento, value); }
        private enumAUD_TipoSeleccion actManejoSustControlada;
        public enumAUD_TipoSeleccion ActManejoSustControlada { get => actManejoSustControlada; set => SetProperty(ref actManejoSustControlada, value); }


        //Número de Licencia de Operación
        private string numLicOperacion;
        [StringLength(250)]
        public string NumLicOperacion { get => numLicOperacion; set => SetProperty(ref numLicOperacion, value); }

        private DateTime? fechaExpLicOperacion;
        [StringLength(250)]
        public DateTime? FechaExpLicOperacion { get => fechaExpLicOperacion; set => SetProperty(ref fechaExpLicOperacion, value); }

        // La licencia de Operación esta visible y legible a los clientes 
        private enumAUD_TipoSeleccion licOperacionVisible;
        public enumAUD_TipoSeleccion LicOperacionVisible { get => licOperacionVisible; set => SetProperty(ref licOperacionVisible, value); }

        //provincia
        private string provincia;
        [StringLength(250)]
        public string Provincia { get => provincia; set => SetProperty(ref provincia, value); }

        //distrito
        private string distrito;
        [StringLength(250)]
        public string Distrito { get => distrito; set => SetProperty(ref distrito, value); }

        //distrito
        private string corregimiento;
        [StringLength(250)]
        public string Corregimiento { get => corregimiento; set => SetProperty(ref corregimiento, value); }

        //ubicacion
        private string ubicacion;
        [StringLength(500)]
        public string Ubicacion { get => ubicacion; set => SetProperty(ref ubicacion, value); }

        //telefono1
        private string telefono;
        [StringLength(250)]
        public string Telefono { get => telefono; set => SetProperty(ref telefono, value); }

        //correo
        private string correo;
        [StringLength(250)]
        public string Correo { get => correo; set => SetProperty(ref correo, value); }

        //Atendidos por
        private string atendidosPor;
        [StringLength(500)]
        public string AtendidosPor { get => atendidosPor; set => SetProperty(ref atendidosPor, value); }

        //Atendidos por Cargo
        private string cargo;
        [StringLength(250)]
        public string Cargo { get => cargo; set => SetProperty(ref cargo, value); }

        //Horario de Operación coincide con la Licencia de Operación: 
        private enumAUD_TipoSeleccion horarioOperCoincideLicOper;
        public enumAUD_TipoSeleccion HorarioOperCoincideLicOper { get => horarioOperCoincideLicOper; set => SetProperty(ref horarioOperCoincideLicOper, value); }

        //Observación
        private string observacion;
        public string Observacion { get => observacion; set => SetProperty(ref observacion, value); }


    }
}
