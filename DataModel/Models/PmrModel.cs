using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class PmrModel
    {
        public string NombreComercial { get; set; }
        public string PrincipioActivo { get; set; }
        public string RegSanitario { get; set; }
        public string Descripcion { get; set; }
        public LaboratorioTB? LaboratorioFabricante { get; set; }
        //public FMV_OrigenAlertaTB? OrigenAlerta { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public List<AttachmentTB> LAdjuntos { get; set; }
        public long IdTramite { get; set; }
    }
}
