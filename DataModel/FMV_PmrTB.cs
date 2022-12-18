using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_PmrTB:SystemId
    {
        public FMV_PmrTB() {
            PmrProducto=new FMV_PmrProductoTB();
            Adjunto=new AttachmentData();
        }

        //status del acta
        private enumFMV_StatusPMR status;
        public enumFMV_StatusPMR Status { get => status; set => SetProperty(ref status, value); }


        //fecha y Hora de inicio del acta
        private DateTime? fechaEntrada;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEntrada { get => fechaEntrada; set => SetProperty(ref fechaEntrada, value); }

        //fecha de entrega al evaluador
        private DateTime? fechaEntregaEvaluador;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEntregaEvaluador { get => fechaEntregaEvaluador; set => SetProperty(ref fechaEntregaEvaluador, value); }

        //fecha de tramite
        private DateTime? fechaTramite;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaTramite { get => fechaTramite; set => SetProperty(ref fechaTramite, value); }

        //Evaluador
        private long? evaluadorId;
        public long? EvaluadorId { get => evaluadorId; set => SetProperty(ref evaluadorId, value); }
        private PersonalTrabajadorTB? evaluador;
        public virtual PersonalTrabajadorTB? Evaluador { get => evaluador; set => SetProperty(ref evaluador, value); }

        private string princActivo;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string PrincActivo { get => princActivo; set => SetProperty(ref princActivo, value); }


        //private List<FMV_PmrProductoTB> lProductos;
        //public virtual List<FMV_PmrProductoTB> LProductos { get => lProductos; set => SetProperty(ref lProductos, value); }

        //Producto
        private long? pmrProductoId;
        public long? PmrProductoId { get => pmrProductoId; set => SetProperty(ref pmrProductoId, value); }
        private FMV_PmrProductoTB? pmrProducto;
        public virtual FMV_PmrProductoTB? PmrProducto { get => pmrProducto; set => SetProperty(ref pmrProducto, value); }

        //Ficheros Adjuntos
        private AttachmentData adjunto;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AttachmentData Adjunto { get => adjunto; set => SetProperty(ref adjunto, value); }

    }
}
