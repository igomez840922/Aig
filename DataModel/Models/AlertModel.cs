using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{

    public class AlertModel
    {
        public string NumNota { get; set; }
        public string Comentarios { get; set; }
        public List<AttachmentTB> LAdjuntos { get; set; }
        public List<PersonaDatos> LCorreos { get; set; }
        public long IdTramite { get; set; }
        public string NombreDirector { get; set; }
        public string TituloNota { get; set; }
        public string PrincipioActivo { get; set; }
        public string CuerpoNota { get; set; }
        public string FuentesBibliograficas { get; set; }

    }
}
