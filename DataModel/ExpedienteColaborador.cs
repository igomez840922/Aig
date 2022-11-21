using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ExpedienteColaborador:SystemId
    {
        //Regente - Nombre
        private string nombre;
        [StringLength(250)]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }
                
        //Regente de cedula ..... Al colocar el número de cédula debe validarse con el Web Service del Tribunal Electoral que se encuentra en el bus de integración de la AIG. Se debe alimentar de la solicitud de Licencia.
        private string cedula;
        [StringLength(250)]
        public string Cedula { get => cedula; set => SetProperty(ref cedula, value); }


        private bool tieneExpediente;
        public bool TieneExpediente { get => tieneExpediente; set => SetProperty(ref tieneExpediente, value); }

        private string numExpediente;
        [StringLength(250)]
        public string NumExpediente { get => numExpediente; set => SetProperty(ref numExpediente, value); }

        private string expedienteDesc;
        [StringLength(250)]
        public string ExpedienteDesc { get => expedienteDesc; set => SetProperty(ref expedienteDesc, value); }

    }
}
