using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models
{
    public class IpsModel
    {

        public DateTime? FechaEntrada { get; set; }
        public string? PrincipioActivo { get; set; }

        public List<FMV_IpsMedicamentoTB> LMedicamentos { get; set; }

        public DateTime? FechaIni { get; set; }
        public DateTime? FechaFin { get; set; }

        public enumAUD_TipoSeleccion Innovador { get; set; }
        public enumAUD_TipoSeleccion Biologico { get; set; }
        public enumAUD_TipoSeleccion ReqIntercam { get; set; }

        public DateTime? FechaAutorizacion { get; set; }

        public List<AttachmentTB> LAdjuntos { get; set; }

        public long IdTramite { get; set; }

        //public AttachmentTB InformeAdjunto { get; set; }
        //public AttachmentTB ResumenAdjunto { get; set; }
        //public AttachmentTB NotaAdjunto { get; set; }
        //public AttachmentTB InformeIPSAdjunto { get; set; }

    }
}
