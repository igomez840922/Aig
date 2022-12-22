using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_IpsTB : SystemId
    {
		public FMV_IpsTB()
		{
			IpsData = new FMV_IpsData();
			Adjunto = new AttachmentData();
		}

		//Fecha de Recepcion en CNFV
		private DateTime? fechaRecepcion;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRecepcion { get => fechaRecepcion; set => SetProperty(ref fechaRecepcion, value); }

        //Fecha de entrega al registrador
        private DateTime? fechaRegistrador;
        [DisplayFormat(DataFormatString = "{:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRegistrador { get => fechaRegistrador; set => SetProperty(ref fechaRegistrador, value); }

        //Registrador
        private long? registradorId;
        public long? RegistradorId { get => registradorId; set => SetProperty(ref registradorId, value); }
        private PersonalTrabajadorTB? registrador;
        public virtual PersonalTrabajadorTB? Registrador { get => registrador; set => SetProperty(ref registrador, value); }

        private string nomComercial;
        [StringLength(500)]
        [Required(ErrorMessage = "requerido")]
        public string NomComercial { get => nomComercial; set => SetProperty(ref nomComercial, value); }

        //Principio Activo
        private string princActivo;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string PrincActivo { get => princActivo; set => SetProperty(ref princActivo, value); }

        //Titular
        //Laboratorio
        private long? laboratorioId;
        public long? LaboratorioId { get => laboratorioId; set => SetProperty(ref laboratorioId, value); }
        private LaboratorioTB? laboratorio;
        public virtual LaboratorioTB? Laboratorio { get => laboratorio; set => SetProperty(ref laboratorio, value); }


        ////FMV_IspProductTB
        //private List<FMV_IpsProductTB> lProducts;
        //[StringLength(250)]
        //public List<FMV_IpsProductTB> LProducts { get => lProducts; set => SetProperty(ref lProducts, value); }

        private string regSanitario;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string RegSanitario { get => regSanitario; set => SetProperty(ref regSanitario, value); }

        // Estatus Recepcion: Aceptado, Rechazado
        private enumFMV_IpsStatusRecepcion estatusRecepcion;
        public enumFMV_IpsStatusRecepcion EstatusRecepcion { get => estatusRecepcion; set => SetProperty(ref estatusRecepcion, value); }

        // Fecha de asignación para pre evaluación
        private DateTime? fechaAsignacion;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaAsignacion { get => fechaAsignacion; set => SetProperty(ref fechaAsignacion, value); }

        // Tramitador
        private long? tramitadorId;
        public long? TramitadorId { get => tramitadorId; set => SetProperty(ref tramitadorId, value); }
        private PersonalTrabajadorTB? tramitador;
        public virtual PersonalTrabajadorTB? Tramitador { get => tramitador; set => SetProperty(ref tramitador, value); }

        // Estatus de registro: Tramitado, Por Tramitar, Prioridad de Evaluacion
        private enumFMV_IpsStatusRegistro estatusRegistro;
        public enumFMV_IpsStatusRegistro EstatusRegistro { get => estatusRegistro; set => SetProperty(ref estatusRegistro, value); }

        // Fecha de asignación para evaluación
        private DateTime? fechaAsigEva;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaAsigEva { get => fechaAsigEva; set => SetProperty(ref fechaAsigEva, value); }

        // Evaluador
        private long? evaluadorId;
        public long? EvaluadorId { get => evaluadorId; set => SetProperty(ref evaluadorId, value); }
        private PersonalTrabajadorTB? evaluador;
        public virtual PersonalTrabajadorTB? Evaluador { get => evaluador; set => SetProperty(ref evaluador, value); }

        // Resumen ejecutivo: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones resumenEjec;
        public enumFMV_IpsTipoPresentaiones ResumenEjec { get => resumenEjec; set => SetProperty(ref resumenEjec, value); }

        // Resumen ejecutivo traducido: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones resumenEjecTrad;
        public enumFMV_IpsTipoPresentaiones ResumenEjecTrad { get => resumenEjecTrad; set => SetProperty(ref resumenEjecTrad, value); }

        // Prioridad
        private bool prioridad;
        public bool Prioridad { get => prioridad; set => SetProperty(ref prioridad, value); }

        // Fecha de revision
        private DateTime? fechaRev;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRev { get => fechaRev; set => SetProperty(ref fechaRev, value); }

        // Estatus de Revision
        private enumFMV_IpsStatusRevision statusRevision;
        public enumFMV_IpsStatusRevision StatusRevision { get => statusRevision; set => SetProperty(ref statusRevision, value); }

        // IPS confeccionado conforme a la normativa: Cumple, no cumple
        private bool confecConNormativa;
        public bool ConfecConNormativa { get => confecConNormativa; set => SetProperty(ref confecConNormativa, value); }

        // No. de Informe 
        private string noInforme;
        [StringLength(250)]
        public string NoInforme { get => noInforme; set => SetProperty(ref noInforme, value); }

        //Datos del Solicitante
        private FMV_IpsData ipsData;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_IpsData IpsData { get => ipsData; set => SetProperty(ref ipsData, value); }

		//Ficheros Adjuntos
		private AttachmentData adjunto;
		[System.ComponentModel.DataAnnotations.Schema.NotMapped]
		public virtual AttachmentData Adjunto { get => adjunto; set => SetProperty(ref adjunto, value); }


        public void UpdateRule()
        {
            Prioridad = false;

            if (IpsData != null)
            {
                if (IpsData.Innovador || IpsData.Biologico || IpsData.ReqIntercam)
                {
                    if (IpsData.FechaAutPan.HasValue && ((DateTime.Now - IpsData.FechaAutPan.Value).TotalDays / 365) < 5)
                    {
                        Prioridad = true;
                    }
                }
            }
        }
    }
}
