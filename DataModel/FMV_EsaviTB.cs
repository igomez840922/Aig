using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_EsaviTB : SystemId
    {
        public FMV_EsaviTB()
        {
            LNotificaciones = new List<FMV_EsaviNotificacionTB>();
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

        //ORIGEN
        private enumFMV_RAMOrigenType origenNotificacion;
        public enumFMV_RAMOrigenType OrigenNotificacion { get => origenNotificacion; set => SetProperty(ref origenNotificacion, value); }

        private string codigoNotiFacedra;
        [StringLength(250)]
        public string CodigoNotiFacedra { get => codigoNotiFacedra; set => SetProperty(ref codigoNotiFacedra, value); }

        private string idFacedra;
        [StringLength(250)]
        public string IdFacedra { get => idFacedra; set => SetProperty(ref idFacedra, value); }

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

        //Tipo de Notificacion
        private enumFMV_RAMNotificationType tipoNotificacion;
        public enumFMV_RAMNotificationType TipoNotificacion { get => tipoNotificacion; set => SetProperty(ref tipoNotificacion, value); }

        // Tipo de Organización/Institución: CSS, Minsa, Patronatos, Clinica_Hospital_Privados, Farmacias_Privadas, Industria Farmacéutica, No_hay_información, No_aplica
        //private enumFMV_RAMOrganizationType tipoOrgInst;
        //public enumFMV_RAMOrganizationType TipoOrgInst { get => tipoOrgInst; set => SetProperty(ref tipoOrgInst, value); }
        private long? tipoInstitucionId;
        public long? TipoInstitucionId { get => tipoInstitucionId; set => SetProperty(ref tipoInstitucionId, value); }
        private TipoInstitucionTB? tipoInstitucion;
        public virtual TipoInstitucionTB? TipoInstitucion { get => tipoInstitucion; set => SetProperty(ref tipoInstitucion, value); }


        // Provincia/Región/Origen: Los valores de la lista varia según las filas
        //private string provRegionOrigen;
        //[StringLength(250)]
        //public string ProvRegionOrigen { get => provRegionOrigen; set => SetProperty(ref provRegionOrigen, value); }
        private long? provinciaId;
        public long? ProvinciaId { get => provinciaId; set => SetProperty(ref provinciaId, value); }
        private ProvinciaTB? provincia;
        public virtual ProvinciaTB? Provincia { get => provincia; set => SetProperty(ref provincia, value); }

        //// Nombre de Organización/Institución: Los valores de la lista varia según las filas 
        //private string nombreOrgInst;
        //[StringLength(250)]
        //public string NombreOrgInst { get => nombreOrgInst; set => SetProperty(ref nombreOrgInst, value); }
        private long? institucionId;
        public long? InstitucionId { get => institucionId; set => SetProperty(ref institucionId, value); }
        private InstitucionDestinoTB? institucionDestino;
        public virtual InstitucionDestinoTB? InstitucionDestino { get => institucionDestino; set => SetProperty(ref institucionDestino, value); }

        // Otros diagnosticos
        private string otrosDiagnosticos;
        [StringLength(500)]
        public string OtrosDiagnosticos { get => otrosDiagnosticos; set => SetProperty(ref otrosDiagnosticos, value); }

        // Sexo: Total=3. M, F, ND
        private enumSexo sexo;
        public enumSexo Sexo { get => sexo; set => SetProperty(ref sexo, value); }

        private int edad;
        public int Edad { get => edad; set => SetProperty(ref edad, value); }

        private string historiaClinica;
        [StringLength(500)]
        public string HistoriaClinica { get => historiaClinica; set => SetProperty(ref historiaClinica, value); }

        private string datosLab;
        [StringLength(500)]
        public string DatosLab { get => datosLab; set => SetProperty(ref datosLab, value); }

        private string nombreCompletoPersona;
        [StringLength(300)]
        public string NombreCompletoPersona { get => nombreCompletoPersona; set => SetProperty(ref nombreCompletoPersona, value); }

        private string inicialesPersona;
        [StringLength(200)]
        public string InicialesPersona { get => inicialesPersona; set => SetProperty(ref inicialesPersona, value); }

        private string cedula;
        [StringLength(200)]
        public string Cedula { get => cedula; set => SetProperty(ref cedula, value); }

        private string medicamentoContaminante;
        [StringLength(250)]
        public string MedicamentoContaminante { get => medicamentoContaminante; set => SetProperty(ref medicamentoContaminante, value); }

        private enumOpcionSiNo detallesCaso;
        public enumOpcionSiNo DetallesCaso { get => detallesCaso; set => SetProperty(ref detallesCaso, value); }

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

        //LIsta de Notificacions
        private List<FMV_EsaviNotificacionTB> lNotificaciones;
        public virtual List<FMV_EsaviNotificacionTB> LNotificaciones { get => lNotificaciones; set => SetProperty(ref lNotificaciones, value); }

    }
}
