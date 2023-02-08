﻿using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_CorrespondenciaTB:SystemId
    {
        //Empresa establecimiento
        private string secNumberStr;
        [StringLength(250)]
        public string SecNumberStr { get => secNumberStr; set => SetProperty(ref secNumberStr, value); }

        //Empresa establecimiento
        private int secNumber;
        public int SecNumber { get => secNumber; set => SetProperty(ref secNumber, value); }

        //Fecha de Ingreso
        private DateTime? fechaIngreso;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaIngreso { get => fechaIngreso; set => SetProperty(ref fechaIngreso, value); }

        //Empresa establecimiento
        private string empresa;
        [StringLength(300)]
        [Required(ErrorMessage = "requerido")]
        public string Empresa { get => empresa; set => SetProperty(ref empresa, value); }

        //Número del documento que se está recibiendo
        private string numDocRecibido;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string NumDocRecibido { get => numDocRecibido; set => SetProperty(ref numDocRecibido, value); }

        //Asunto
        private string asunto;
        [StringLength(500)]
        public string Asunto { get => asunto; set => SetProperty(ref asunto, value); }


        //Asunto
        private long? correspondenciaAsuntoId;
        public long? CorrespondenciaAsuntoId { get => correspondenciaAsuntoId; set => SetProperty(ref correspondenciaAsuntoId, value); }
        private AUD_CorrespondenciaAsuntoTB? correspondenciaAsunto;
        public virtual AUD_CorrespondenciaAsuntoTB? CorrespondenciaAsunto { get => correspondenciaAsunto; set => SetProperty(ref correspondenciaAsunto, value); }
              
        //Status
        private enumAUD_StatusCorrespondencia status;
        public enumAUD_StatusCorrespondencia Status { get => status; set => SetProperty(ref status, value); }

        //Contacto
        private long? correspondenciaContactoId;
        public long? CorrespondenciaContactoId { get => correspondenciaContactoId; set => SetProperty(ref correspondenciaContactoId, value); }
        private AUD_CorrespondenciaContactoTB? correspondenciaContacto;
        public virtual AUD_CorrespondenciaContactoTB? CorrespondenciaContacto { get => correspondenciaContacto; set => SetProperty(ref correspondenciaContacto, value); }

        //Tipo Correspondencia
        private enumAUD_TipoCorrespondencia tipoCorrespondencia;
        public enumAUD_TipoCorrespondencia TipoCorrespondencia { get => tipoCorrespondencia; set => SetProperty(ref tipoCorrespondencia, value); }
        
        private string descTipoCorrespondencia;
        [StringLength(300)]
        public string DescTipoCorrespondencia { get => descTipoCorrespondencia; set => SetProperty(ref descTipoCorrespondencia, value); }

        //Reponsable
        private long? correspondenciaResponsableId;
        public long? CorrespondenciaResponsableId { get => correspondenciaResponsableId; set => SetProperty(ref correspondenciaResponsableId, value); }
        private AUD_CorrespondenciaRespRevisionTB? correspondenciaResponsable;
        public virtual AUD_CorrespondenciaRespRevisionTB? CorrespondenciaResponsable { get => correspondenciaResponsable; set => SetProperty(ref correspondenciaResponsable, value); }


        //Detalles
        private string detalles;
        public string Detalles { get => detalles; set => SetProperty(ref detalles, value); }

        //Fecha de Revision
        private DateTime? fechaRevision;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRevision { get => fechaRevision; set => SetProperty(ref fechaRevision, value); }

        //Nombre de persona que realiza la revision
        private string nombreRevision;
        [StringLength(300)]
        public string NombreRevision { get => nombreRevision; set => SetProperty(ref nombreRevision, value); }


        //Observaciones
        private string observaciones;
        public string Observaciones { get => observaciones; set => SetProperty(ref observaciones, value); }
                
        //Dpto y Seccion
        private enumUserRoleType dptoSeccionType;
        public enumUserRoleType DptoSeccionType { get => dptoSeccionType; set => SetProperty(ref dptoSeccionType, value); }

        //Dpto y Seccion
        private string dptoSeccion;
        [StringLength(300)]
        public string DptoSeccion { get => dptoSeccion; set => SetProperty(ref dptoSeccion, value); }

        //Nombre a quien va dirigido
        private string nombreDirigido;
        [StringLength(300)]
        public string NombreDirigido { get => nombreDirigido; set => SetProperty(ref nombreDirigido, value); }

        //Correo a quien va dirigido
        private string emailDirigido;
        [StringLength(250)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
        public string EmailDirigido { get => emailDirigido; set => SetProperty(ref emailDirigido, value); }

        //Nombre quien Recibe
        private string nombreRecibido;
        [StringLength(300)]
        public string NombreRecibido { get => nombreRecibido; set => SetProperty(ref nombreRecibido, value); }

        //Firma quien Recibe
        private string firmaRecibido;
        public string FirmaRecibido { get => firmaRecibido; set => SetProperty(ref firmaRecibido, value); }

        //Fecha de Recibo
        private DateTime? fechaRecibo;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRecibo { get => fechaRecibo; set => SetProperty(ref fechaRecibo, value); }

        //Seguimiento o Respuesta del Caso
        private string respuestaCaso;
        public string RespuestaCaso { get => respuestaCaso; set => SetProperty(ref respuestaCaso, value); }

        //Fecha de Recibo
        private DateTime? fechaRespuesta;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRespuesta { get => fechaRespuesta; set => SetProperty(ref fechaRespuesta, value); }

        //Se coloca el N° del documento que da respuesta a la solciitud
        private string numDocRespuesta;
        [StringLength(250)]
        public string NumDocRespuesta { get => numDocRespuesta; set => SetProperty(ref numDocRespuesta, value); }

        //DATOS DE ESTABLECIMIENTO

        //Empresa establecimiento
        private string establecimientoNumLic;
        [StringLength(250)]
        public string EstablecimientoNumLic { get => establecimientoNumLic; set => SetProperty(ref establecimientoNumLic, value); }

        //Empresa establecimiento
        private string establecimientoNombre;
        [StringLength(300)]
        public string EstablecimientoNombre { get => establecimientoNombre; set => SetProperty(ref establecimientoNombre, value); }

        //Empresa corregimientp
        private string establecimientoCorregimiento;
        [StringLength(300)]
        public string EstablecimientoCorregimiento { get => establecimientoCorregimiento; set => SetProperty(ref establecimientoCorregimiento, value); }

        //Empresa corregimientp
        private string establecimientoUbicacion;
        [StringLength(500)]
        public string EstablecimientoUbicacion { get => establecimientoUbicacion; set => SetProperty(ref establecimientoUbicacion, value); }

        //Empresa Asignado
        private string establecimientoAsignado;
        [StringLength(300)]
        public string EstablecimientoAsignado { get => establecimientoAsignado; set => SetProperty(ref establecimientoAsignado, value); }


        //Ficheros Adjuntos
        private AttachmentData adjuntoIngreso;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AttachmentData AdjuntoIngreso { get => adjuntoIngreso; set => SetProperty(ref adjuntoIngreso, value); }

        //Ficheros Adjuntos
        private AttachmentData adjuntoSeguimiento;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AttachmentData AdjuntoSeguimiento { get => adjuntoSeguimiento; set => SetProperty(ref adjuntoSeguimiento, value); }
    }
}
