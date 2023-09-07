using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class RfModel
    {
        //public TipoTramitesRF TipoTramite { get; set; }
        public enum_Cargos Cargo { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        //public TipoRespuesta ProfesionalSalud { get; set; }
        //public string DescProfesionalSalud { get; set; }

        //public TipoRespuesta ConocimientoFarmacoVig { get; set; }
        public enum_UbicationType OrigenPersona { get; set; }
        //public TipoEmpresa TipoEmpresa { get; set; }
        public LaboratorioTB? Empresa { get; set; }

        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime FechaEntrada { get; set; }
        public string? Observaciones { get; set; }

        public string NombreCompleto
        {
            get
            {
                string[] nameArray = null;
                nameArray = new string[] { PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido };

                //string[] nameArray = { PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido };
                return string.Join(" ", nameArray.Where(s => !string.IsNullOrEmpty(s)));
            }
        }

        public List<AttachmentTB> LAdjuntos { get; set; }
        public long IdTramite { get; set; }



    }
}
