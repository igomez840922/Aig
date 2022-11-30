using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_FtTB : SystemId
    {
        public FMV_FtTB()
        {
            LNotificaciones = new List<FMV_FtNotificacionTB>();
        }

        // Código del CNFV
        private string codCNFV;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string CodCNFV { get => codCNFV; set => SetProperty(ref codCNFV, value); }

        // Código externo
        private string codExt;
        [StringLength(250)]
        public string CodExt { get => codExt; set => SetProperty(ref codExt, value); }

        // Fecha de recibido (CNFV)
        private DateTime? fechaRecibidoCNFV;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRecibidoCNFV { get => fechaRecibidoCNFV; set => SetProperty(ref fechaRecibidoCNFV, value); }

        // Fecha de entrega al evaluador
        private DateTime? fechaEntregaEva;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEntregaEva { get => fechaEntregaEva; set => SetProperty(ref fechaEntregaEva, value); }

        // Evaluador
        private long? evaluadorId;
        public long? EvaluadorId { get => evaluadorId; set => SetProperty(ref evaluadorId, value); }
        private PersonalTrabajadorTB? evaluador;
        public virtual PersonalTrabajadorTB? Evaluador { get => evaluador; set => SetProperty(ref evaluador, value); }

        private string farmacoSospechosoComercial;
        [Required(ErrorMessage = "requerido")]
        [StringLength(300)]
        public string FarmacoSospechosoComercial { get => farmacoSospechosoComercial; set => SetProperty(ref farmacoSospechosoComercial, value); }

        private string farmacoSospechosoDci;
        [Required(ErrorMessage = "requerido")]
        [StringLength(300)]
        public string FarmacoSospechosoDci { get => farmacoSospechosoDci; set => SetProperty(ref farmacoSospechosoDci, value); }

        //PROCEDENCIA DE NOTIFICACION - Lista de Notificaciones
        private List<FMV_FtNotificacionTB> lNotificaciones;
        public virtual List<FMV_FtNotificacionTB> LNotificaciones { get => lNotificaciones; set => SetProperty(ref lNotificaciones, value); }

    }
}
