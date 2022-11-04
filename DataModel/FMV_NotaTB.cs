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
        //Fecha
        private DateTime? fecha;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Fecha { get => fecha; set => SetProperty(ref fecha, value); }

        //Numero de Nota
        private string numNota;
        [StringLength(250)]
        public string NumNota { get => numNota; set => SetProperty(ref numNota, value); }

        // Evaluador
        private long? evaluadorId;
        public long? EvaluadorId { get => evaluadorId; set => SetProperty(ref evaluadorId, value); }
        private PersonalTrabajadorTB? evaluador;
        public virtual PersonalTrabajadorTB? Evaluador { get => evaluador; set => SetProperty(ref evaluador, value); }
                
        //Tipo de Nota o Alerta
        private enumFMV_NoteType tipoNota;
        public enumFMV_NoteType TipoNota { get => tipoNota; set => SetProperty(ref tipoNota, value); }

        //Descripcion
        private string descripcion;
        public string Descripcion { get => descripcion; set => SetProperty(ref descripcion, value); }

        // Institucion Destino
        private long? institucionDestinoId;
        public long? InstitucionDestinoId { get => institucionDestinoId; set => SetProperty(ref institucionDestinoId, value); }
        private InstitucionDestinoTB? institucionDestino;
        public virtual InstitucionDestinoTB? InstitucionDestino { get => institucionDestino; set => SetProperty(ref institucionDestino, value); }


        //Destinatario
        private string destinatario;
        [StringLength(250)]
        public string Destinatario { get => destinatario; set => SetProperty(ref destinatario, value); }

    }

}
