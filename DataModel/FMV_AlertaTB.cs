using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{   
    public class FMV_AlertaTB : SystemId
    {
        public FMV_AlertaTB() {
            Adjunto = new AttachmentData();
        }

        // Año
        private int year;
        public int Year { get => year; set => SetProperty(ref year, value); }

        // Fecha de recibido (CNFV)
        private DateTime? fechaRecepcion;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRecepcion { get => fechaRecepcion; set { SetProperty(ref fechaRecepcion, value); Year = value.HasValue ? value.Value.Year : 0; } }

        // Fecha de entrega al evaluador
        private DateTime? fechaEntregaEvaluador;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEntregaEvaluador { get => fechaEntregaEvaluador; set => SetProperty(ref fechaEntregaEvaluador, value); }

        //Fecha de evaluacion
        private DateTime? fechaEvaluacion;
        [DisplayFormat(DataFormatString = "{:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEvaluacion { get => fechaEvaluacion; set => SetProperty(ref fechaEvaluacion, value); }

        // Evaluador
        private long? evaluadorId;
        public long? EvaluadorId { get => evaluadorId; set => SetProperty(ref evaluadorId, value); }
        private PersonalTrabajadorTB? evaluador;
        public virtual PersonalTrabajadorTB? Evaluador { get => evaluador; set => SetProperty(ref evaluador, value); }

        // Origen de la Nota
        private long? origenAlertaId;
        public long? OrigenAlertaId { get => origenAlertaId; set => SetProperty(ref origenAlertaId, value); }
        private FMV_OrigenAlertaTB? origenAlerta;
        public virtual FMV_OrigenAlertaTB? OrigenAlerta { get => origenAlerta; set => SetProperty(ref origenAlerta, value); }

        //Tipo de Nota o Alerta
        private enumFMV_AlertType tipoAlerta;
        public enumFMV_AlertType TipoAlerta { get => tipoAlerta; set => SetProperty(ref tipoAlerta, value); }

        //Producto
        private string producto;
        [StringLength(300)]
        public string Producto { get => producto; set => SetProperty(ref producto, value); }

        //DCI
        private string dci;
        [StringLength(300)]
        public string DCI { get => dci; set => SetProperty(ref dci, value); }

        //Descripcion
        private string descripcion;
        public string Descripcion { get => descripcion; set => SetProperty(ref descripcion, value); }


        private bool recomProfPaciente;
        public bool RecomProfPaciente { get => recomProfPaciente; set => SetProperty(ref recomProfPaciente, value); }


        private bool actualizaMonografias;
        public bool ActualizaMonografias { get => actualizaMonografias; set => SetProperty(ref actualizaMonografias, value); }

        private bool consentFirmado;
        public bool ConsentFirmado { get => consentFirmado; set => SetProperty(ref consentFirmado, value); }

        private bool suspencionRetiroLote;
        public bool SuspencionRetiroLote { get => suspencionRetiroLote; set => SetProperty(ref suspencionRetiroLote, value); }

        private bool suspencCancelRegSanitario;
        public bool SuspencCancelRegSanitario { get => suspencCancelRegSanitario; set => SetProperty(ref suspencCancelRegSanitario, value); }

        private bool monitoreo;
        public bool Monitoreo { get => monitoreo; set => SetProperty(ref monitoreo, value); }

        private bool otrasConsideraciones;
        public bool OtrasConsideraciones { get => otrasConsideraciones; set => SetProperty(ref otrasConsideraciones, value); }

        //Otras Descripcion
        private string otrasDescripcion;
        [StringLength(500)]
        public string OtrasDescripcion { get => otrasDescripcion; set => SetProperty(ref otrasDescripcion, value); }


        //Estatus de Nota o Alerta
        private enumFMV_AlertaNotaStatus estado;
        public enumFMV_AlertaNotaStatus Estado { get => estado; set => SetProperty(ref estado, value); }

        //Numero de Nota
        private string numNota;
        [StringLength(250)]
        public string NumNota { get => numNota; set => SetProperty(ref numNota, value); }

        //Observaciones
        private string observaciones;
        public string Observaciones { get => observaciones; set => SetProperty(ref observaciones, value); }

        //Ficheros Adjuntos
        private AttachmentData adjunto;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AttachmentData Adjunto { get => adjunto; set => SetProperty(ref adjunto, value); }

    }

}
