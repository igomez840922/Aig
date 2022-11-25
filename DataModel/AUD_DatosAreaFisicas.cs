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
    /// Datos de Areas Fisica
    /// </summary>
    public class AUD_DatosAreaFisicas : SystemId
    {
        //Debe seleccionar Si o No, dependiendo de su debido cumplimiento y describir estado del mismo.
        private bool presentaIluminacion;
        public bool PresentaIluminacion { get => presentaIluminacion; set => SetProperty(ref presentaIluminacion, value); }

        // Debe dar breve explicación del por qué.
        private string presentaIluminacionDescrip;
        public string PresentaIluminacionDescrip { get => presentaIluminacionDescrip; set => SetProperty(ref presentaIluminacionDescrip, value); }

        //Tipo y estado de mobiliario para medicamentos
        private bool mobiliarioMedicamentos;
        public bool MobiliarioMedicamentos { get => mobiliarioMedicamentos; set => SetProperty(ref mobiliarioMedicamentos, value); }

        // Debe dar breve explicación del por qué.
        private string mobiliarioMedicamentosDescrip;
        public string MobiliarioMedicamentosDescrip { get => mobiliarioMedicamentosDescrip; set => SetProperty(ref mobiliarioMedicamentosDescrip, value); }

        //Muebles separados de las paredes, pisos, y techos
        private bool mueblesSeparadosPared;
        public bool MueblesSeparadosPared { get => mueblesSeparadosPared; set => SetProperty(ref mueblesSeparadosPared, value); }
        private string mueblesSeparadosParedDesc;
        public string MueblesSeparadosParedDesc { get => mueblesSeparadosParedDesc; set => SetProperty(ref mueblesSeparadosParedDesc, value); }


        // Debe dar breve explicación del por qué.
        private string tipoMoviliario;
        public string TipoMoviliario { get => tipoMoviliario; set => SetProperty(ref tipoMoviliario, value); }
        // Debe dar breve explicación del por qué.
        private string tipoMoviliarioEstado;
        public string TipoMoviliarioEstado { get => tipoMoviliarioEstado; set => SetProperty(ref tipoMoviliarioEstado, value); }
       

    }
}
