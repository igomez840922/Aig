using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class PersonalTecnico : SystemId
    {
        //Regente - Nombre
        private string nombre;
        [StringLength(250)]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //Numero de Registro de Identidad
        private string numRegistro;
        [StringLength(250)]
        public string NumRegistro { get => numRegistro; set => SetProperty(ref numRegistro, value); }

        //Regente de cedula ..... Al colocar el número de cédula debe validarse con el Web Service del Tribunal Electoral que se encuentra en el bus de integración de la AIG. Se debe alimentar de la solicitud de Licencia.
        private string cedula;
        [StringLength(250)]
        public string Cedula { get => cedula; set => SetProperty(ref cedula, value); }
    }
}
