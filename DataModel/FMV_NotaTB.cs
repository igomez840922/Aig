using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{   
    public class FMV_NotaTB : SystemId
    {
        public FMV_NotaTB()
        {
            Adjunto = new AttachmentData();
            Instituciones = new FMV_NotaInstitucion();
            NotaContactos=new FMV_NotaContactos();
        }

        //Fecha
        private DateTime? fecha;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha { get => fecha; set => SetProperty(ref fecha, value); }

        //Numero de Nota
        private string numNota;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string NumNota { get => numNota; set => SetProperty(ref numNota, value); }

        // Evaluador
        private long? evaluadorId;
        public long? EvaluadorId { get => evaluadorId; set => SetProperty(ref evaluadorId, value); }
        private PersonalTrabajadorTB? evaluador;
        public virtual PersonalTrabajadorTB? Evaluador { get => evaluador; set => SetProperty(ref evaluador, value); }
                
        //Tipo de Nota o Alerta
        private enumFMV_NoteType tipoNota;
        [Required(ErrorMessage = "requerido")]
        public enumFMV_NoteType TipoNota { get => tipoNota; set => SetProperty(ref tipoNota, value); }

        //Asunto
        private string asunto;
        [StringLength(500)]
        public string Asunto { get => asunto; set => SetProperty(ref asunto, value); }

        //Descripcion
        private string descripcion;
        [Required(ErrorMessage = "requerido")]
        public string Descripcion { get => descripcion; set => SetProperty(ref descripcion, value); }

        //// Institucion Destino
        //private long? institucionDestinoId;
        //public long? InstitucionDestinoId { get => institucionDestinoId; set => SetProperty(ref institucionDestinoId, value); }
        //private InstitucionDestinoTB? institucionDestino;
        //public virtual InstitucionDestinoTB? InstitucionDestino { get => institucionDestino; set => SetProperty(ref institucionDestino, value); }

        //Ficheros Adjuntos
        private AttachmentData adjunto;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AttachmentData Adjunto { get => adjunto; set => SetProperty(ref adjunto, value); }


        //Instituciones
        private FMV_NotaInstitucion instituciones;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual FMV_NotaInstitucion Instituciones { get => instituciones; set => SetProperty(ref instituciones, value); }


        //loa destinatarios ... correos de destinos
        private FMV_NotaContactos notaContactos;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual FMV_NotaContactos NotaContactos { get => notaContactos; set => SetProperty(ref notaContactos, value); }

    }

}
