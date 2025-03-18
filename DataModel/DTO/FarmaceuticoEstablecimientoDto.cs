using DataModel.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DTO
{
    [Keyless]
    public class FarmaceuticoEstablecimientoDto
    {
        // Campos del farmaceutico 
        public string NombreCompleto { get; set; }
        public string NumReg { get; set; }
        public string Cedula { get; set; }
        public string Horario { get; set; }

        // Campos del establecimiento
        public string Nombre { get; set; }
        public string NumLicencia { get; set; }
        public enumAUD_TipoEstablecimiento TipoEstablecimiento { get; set; }
        public enumAUD_StatusEstablecimiento Status { get; set; }
    }

    [Keyless]
    public class RegenteEstablecimientoDto
    {
        // Campos del farmaceutico 
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }       
        public string Identificacion { get; set; }
        public string NumIdoneidad { get; set; }
        public string Observaciones { get; set; }
        

        public string NombreCompleto
        {
            get
            {
                string[] nameArray = { PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido };
                return string.Join(" ", nameArray.Where(s => !string.IsNullOrEmpty(s)));
            }
        }

        // Campos del establecimiento
        public string Nombre { get; set; }
        public string NumLicencia { get; set; }
        public enumAUD_TipoEstablecimiento TipoEstablecimiento { get; set; }
        public enumAUD_StatusEstablecimiento Status { get; set; }
    }
}
