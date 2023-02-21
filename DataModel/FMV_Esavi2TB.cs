using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_Esavi2TB : SystemId
    {
        public FMV_Esavi2TB()
        {
            LVacunas = new List<FMV_EsaviVacunaTB>();
            Concominantes = new FMV_RamConcominantes();
            Adjunto = new AttachmentData();
        }

        //ORIGEN
        private enumFMV_RAMOrigenType origenNotificacion;
        public enumFMV_RAMOrigenType OrigenNotificacion { get => origenNotificacion; set => SetProperty(ref origenNotificacion, value); }

        private string codigoNotiFacedra;
        [StringLength(250)]
        //[Required(ErrorMessage = "requerido")]
        public string CodigoNotiFacedra { get => codigoNotiFacedra; set => SetProperty(ref codigoNotiFacedra, value); }

        private string idFacedra;
        [StringLength(250)]
        //[Required(ErrorMessage = "requerido")]
        public string IdFacedra { get => idFacedra; set => SetProperty(ref idFacedra, value); }

        // Código externo
        private string codExt;
        [StringLength(250)]
        public string CodExt { get => codExt; set => SetProperty(ref codExt, value); }

        // Código del CNFV
        private string codCNFV;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string CodCNFV { get => codCNFV; set => SetProperty(ref codCNFV, value); }

        // Año
        private int year;
        public int Year { get => year; set => SetProperty(ref year, value); }

        // Fecha de recibido (CNFV)
        private DateTime? fechaRecibidoCNFV;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRecibidoCNFV { get => fechaRecibidoCNFV; set { SetProperty(ref fechaRecibidoCNFV, value); Year = value.HasValue ? value.Value.Year : 0; } }

        // Fecha de entrega al evaluador
        private DateTime? fechaEntregaEva;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEntregaEva { get => fechaEntregaEva; set => SetProperty(ref fechaEntregaEva, value); }

        // Evaluador
        private long? evaluadorId;
        public long? EvaluadorId { get => evaluadorId; set => SetProperty(ref evaluadorId, value); }
        private PersonalTrabajadorTB? evaluador;
        public virtual PersonalTrabajadorTB? Evaluador { get => evaluador; set => SetProperty(ref evaluador, value); }

        private string vacunasDesc;
        [StringLength(500)]
        public string VacunasDesc { get => vacunasDesc; set => SetProperty(ref vacunasDesc, value); }

        private string esaviDesc;
        [StringLength(500)]
        public string EsaviDesc { get => esaviDesc; set => SetProperty(ref esaviDesc, value); }

        //PROCEDENCIA DE LA NOTIFICACION

        //Tipo de Notificacion
        private enumFMV_RAMNotificationType tipoNotificacion;
        public enumFMV_RAMNotificationType TipoNotificacion { get => tipoNotificacion; set => SetProperty(ref tipoNotificacion, value); }


        private string notificador;
        [StringLength(300)]
        [Required(ErrorMessage = "requerido")]
        public string Notificador { get => notificador; set => SetProperty(ref notificador, value); }

        
        private long? tipoInstitucionId;
        public long? TipoInstitucionId { get => tipoInstitucionId; set => SetProperty(ref tipoInstitucionId, value); }
        private TipoInstitucionTB? tipoInstitucion;
        public virtual TipoInstitucionTB? TipoInstitucion { get => tipoInstitucion; set => SetProperty(ref tipoInstitucion, value); }


        private long? provinciaId;
        public long? ProvinciaId { get => provinciaId; set => SetProperty(ref provinciaId, value); }
        private ProvinciaTB? provincia;
        public virtual ProvinciaTB? Provincia { get => provincia; set => SetProperty(ref provincia, value); }

       
        private long? institucionId;
        public long? InstitucionId { get => institucionId; set => SetProperty(ref institucionId, value); }
        private InstitucionDestinoTB? institucionDestino;
        public virtual InstitucionDestinoTB? InstitucionDestino { get => institucionDestino; set => SetProperty(ref institucionDestino, value); }


        //PACIENTE

        private string nombreCompletoPersona;
        [StringLength(300)]
        public string NombreCompletoPersona { get => nombreCompletoPersona; set => SetProperty(ref nombreCompletoPersona, value); }

        private string inicialesPersona;
        [StringLength(200)]
        public string InicialesPersona { get => inicialesPersona; set => SetProperty(ref inicialesPersona, value); }

        private string cedula;
        [StringLength(200)]
        public string Cedula { get => cedula; set => SetProperty(ref cedula, value); }


        // Sexo: Total=3. M, F, ND
        private enumSexo sexo;
        public enumSexo Sexo { get => sexo; set => SetProperty(ref sexo, value); }

        private string edad;
        public string Edad { get => edad; set => SetProperty(ref edad, value); }

        private string historiaClinica;
        [StringLength(500)]
        public string HistoriaClinica { get => historiaClinica; set => SetProperty(ref historiaClinica, value); }

        // Otros diagnosticos
        private string otrosDiagnosticos;
        [StringLength(500)]
        public string OtrosDiagnosticos { get => otrosDiagnosticos; set => SetProperty(ref otrosDiagnosticos, value); }


        ///VACUNAS SOSPECHOSAS

        private List<FMV_EsaviVacunaTB> lVacunas;
        public virtual List<FMV_EsaviVacunaTB> LVacunas { get => lVacunas; set => SetProperty(ref lVacunas, value); }


        //FARMACOS CONCOMINANTES
        private FMV_RamConcominantes concominantes;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public FMV_RamConcominantes Concominantes { get => concominantes; set => SetProperty(ref concominantes, value); }

        //DATOS DEL LABORATORIO

        private string datosLab;
        [StringLength(500)]
        public string DatosLab { get => datosLab; set => SetProperty(ref datosLab, value); }

        //ESTATUS

        // Fecha de evaluación
        private DateTime? fechaEvalua;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEvalua { get => fechaEvalua; set => SetProperty(ref fechaEvalua, value); }

        // Estatus: Total=3. Por Tramitar, Tramitada, Evaluada
        private enumFMV_RAMStatus estatus;
        public enumFMV_RAMStatus Estatus { get => estatus; set => SetProperty(ref estatus, value); }

        // Observaciones
        private string observaciones;
        [StringLength(500)]
        public string Observaciones { get => observaciones; set => SetProperty(ref observaciones, value); }


        //Ficheros Adjuntos
        private AttachmentData adjunto;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AttachmentData Adjunto { get => adjunto; set => SetProperty(ref adjunto, value); }

    }
}
