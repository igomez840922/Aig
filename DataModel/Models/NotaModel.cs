using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{

    public class NotaModel
    {
        public string NombreComercial { get; set; }
        public string PrincipioActivo { get; set; }
        public string RegSanitario { get; set; }
        public string Descripcion { get; set; }
        public LaboratorioTB? LaboratorioFabricante { get; set; }
        public FMV_OrigenAlertaTB? OrigenAlerta { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public List<AttachmentTB> LAdjuntos { get; set; }

        public long IdTramite { get; set; }
        public string NumNota { get; set; }
        public string Comentarios { get; set; }

        public List<DestinatarioCorreo> LCorreos { get; set; }
    }

    public class DestinatarioCorreo
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string NombreCompleto
        {
            get
            {
                string[] nameArray = { PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido };
                return string.Join(" ", nameArray.Where(s => !string.IsNullOrEmpty(s)));
            }
        }
    }
}
