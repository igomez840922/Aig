using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class PersonaDatos
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        //cedula, pasaporte
        //public TipoIdentificaion TipoIdentificaion { get; set; }
        public string Identificacion { get; set; }

        public string NumIdoneidad { get; set; }

        public string Firma { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

        public string NombreCompleto
        {
            get
            {
                string[] nameArray = { PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido };
                return string.Join(" ", nameArray.Where(s => !string.IsNullOrEmpty(s)));
            }
        }

        /////////////////////
        ///
       
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public string Direccion { get; set; }
        public string Observaciones { get; set; }
        public string Historial { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Corregimiento { get; set; }
        public bool VisitadorMed { get; set; }
    }
}
