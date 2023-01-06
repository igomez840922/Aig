using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    //Responsables de Farmaco Vigilancia
    public class FMV_RfvTB:SystemId
    {
        public FMV_RfvTB()
        {
            Adjunto = new AttachmentData();
        }

        //nombre
        private string nombreCompleto;
        [StringLength(500)]
        [Required(ErrorMessage = "requerido")]
        public string NombreCompleto { get => nombreCompleto; set => SetProperty(ref nombreCompleto, value); }


        ////cargo
        //private string cargo;
        //[StringLength(250)]
        //public string Cargo { get => cargo; set => SetProperty(ref cargo, value); }
        private enum_Cargos tipoCargo;
        public enum_Cargos TipoCargo { get => tipoCargo; set => SetProperty(ref tipoCargo, value); }



        //direccion
        private string direccionFisica;
        [StringLength(500)]
        public string DireccionFisica { get => direccionFisica; set => SetProperty(ref direccionFisica, value); }


        //Telefonos
        private string telefonos;
        [StringLength(500)]
        public string Telefonos { get => telefonos; set => SetProperty(ref telefonos, value); }


        //Correos
        private string correos;
        [StringLength(500)]
        public string Correos { get => correos; set => SetProperty(ref correos, value); }


        private enum_UbicationType tipoUbicacion;
        public enum_UbicationType TipoUbicacion { get => tipoUbicacion; set => SetProperty(ref tipoUbicacion, value); }


        private string observaciones;
        public string Observaciones { get => observaciones; set => SetProperty(ref observaciones, value); }


        //Fecha de Notificacion
        private DateTime? fechaNotificacion;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "requerido")]
        public DateTime? FechaNotificacion { get => fechaNotificacion; set => SetProperty(ref fechaNotificacion, value); }


        //Laboratorio
        private long? laboratorioId;
        public long? LaboratorioId { get => laboratorioId; set => SetProperty(ref laboratorioId, value); }
        private LaboratorioTB? laboratorio;
        public virtual LaboratorioTB? Laboratorio { get => laboratorio; set => SetProperty(ref laboratorio, value); }

        //Ficheros Adjuntos
        private AttachmentData adjunto;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AttachmentData Adjunto { get => adjunto; set => SetProperty(ref adjunto, value); }

    }
}
