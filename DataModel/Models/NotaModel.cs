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
        public string NumNota { get; set; }
        public string Comentarios { get; set; }
        public List<AttachmentTB> LAdjuntos { get; set; }
        public List<PersonaDatos> LCorreos { get; set; }
        public long IdTramite { get; set; }
    }
}
