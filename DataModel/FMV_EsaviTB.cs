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
            //LNotificaciones = new List<FMV_EsaviNotificacionTB>();
            Adjunto=new AttachmentData();
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

        //InvDetalle del Caso
        private enumOpcionSiNo invDetalleCaso;
        public enumOpcionSiNo InvDetalleCaso { get => invDetalleCaso; set => SetProperty(ref invDetalleCaso, value); }

        //ORIGEN
        private enumFMV_RAMOrigenType origenNotificacion;
        public enumFMV_RAMOrigenType OrigenNotificacion { get => origenNotificacion; set => SetProperty(ref origenNotificacion, value); }

        private string codigoNotiFacedra;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string CodigoNotiFacedra { get => codigoNotiFacedra; set => SetProperty(ref codigoNotiFacedra, value); }

        private string idFacedra;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
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

        private string notificador;
        [StringLength(300)]
        [Required(ErrorMessage = "requerido")]
        public string Notificador { get => notificador; set => SetProperty(ref notificador, value); }

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

        ////LIsta de Notificacions
        //private List<FMV_EsaviNotificacionTB> lNotificaciones;
        //public virtual List<FMV_EsaviNotificacionTB> LNotificaciones { get => lNotificaciones; set => SetProperty(ref lNotificaciones, value); }


        // Hay Esavi?
        private enumFMV_EsaviClasificacion hayEsavi;
        public enumFMV_EsaviClasificacion HayEsavi { get => hayEsavi; set => SetProperty(ref hayEsavi, value); }

        // Fecha de Esavi
        private DateTime? fechaEsavi;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEsavi { get => fechaEsavi; set => SetProperty(ref fechaEsavi, value); }

        // Desenlace
        private enumFMV_RAMDesenlace desenlace;
        public enumFMV_RAMDesenlace Desenlace { get => desenlace; set => SetProperty(ref desenlace, value); }

        //ESAVI
        private string esaviDescripcion;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string EsaviDescripcion { get => esaviDescripcion; set => SetProperty(ref esaviDescripcion, value); }

        //Termino WhoArt
        private string terminoWhoArt;
        [StringLength(250)]
        public string TerminoWhoArt { get => terminoWhoArt; set => SetProperty(ref terminoWhoArt, value); }

        //// SOC
        //private enumFMV_EsaviSOC soc;
        //public enumFMV_EsaviSOC SOC { get => soc; set => SetProperty(ref soc, value); }
        // SOC: Los valores de la lista varia según las filas 
        private long? socId;
        public long? SocId { get => socId; set => SetProperty(ref socId, value); }
        // SOC: Los valores de la lista varia según las filas 
        private string soc;
        public string Soc { get => soc; set => SetProperty(ref soc, value); }

        ////Intensidad de la ESAV
        //private string intensidad;
        //[StringLength(250)]
        //public string Intensidad { get => intensidad; set => SetProperty(ref intensidad, value); }
        private long? intensidadEsaviId;
        public long? IntensidadEsaviId { get => intensidadEsaviId; set => SetProperty(ref intensidadEsaviId, value); }
        private IntensidadEsaviTB? intensidadEsavi;
        public virtual IntensidadEsaviTB? IntensidadEsavi { get => intensidadEsavi; set => SetProperty(ref intensidadEsavi, value); }

        //Gravedad
        private string gravedad;
        [StringLength(250)]
        public string Gravedad { get => gravedad; set => SetProperty(ref gravedad, value); }

        // Otros Criterios
        private enumFMV_EsaviOtroCriterio otrosCriterios;
        public enumFMV_EsaviOtroCriterio OtrosCriterios { get => otrosCriterios; set => SetProperty(ref otrosCriterios, value); }


        //Elegibilidad por Gravedad
        private string elegibilidadGravedad;
        [StringLength(250)]
        public string ElegibilidadGravedad { get => elegibilidadGravedad; set => SetProperty(ref elegibilidadGravedad, value); }

        //Elegibilidad por otros criterios
        private string elegibilidadOtroCriterio;
        [StringLength(250)]
        public string ElegibilidadOtroCriterio { get => elegibilidadOtroCriterio; set => SetProperty(ref elegibilidadOtroCriterio, value); }

        //Elegible para evaluación de causalidad
        private string elegibleEvaluacionCausal;
        [StringLength(250)]
        public string ElegibleEvaluacionCausal { get => elegibleEvaluacionCausal; set => SetProperty(ref elegibleEvaluacionCausal, value); }

        // Probabilidad de Asosiación Causal con la Inmunización
        private enumFMV_EsaviProbabilidadAsociacion probabilidadAsociacion;
        public enumFMV_EsaviProbabilidadAsociacion ProbabilidadAsociacion { get => probabilidadAsociacion; set => SetProperty(ref probabilidadAsociacion, value); }


        //Vacuna Sospechosa (Comercial)
        private string vacunaComercial;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string VacunaComercial { get => vacunaComercial; set => SetProperty(ref vacunaComercial, value); }

        ////Descripción de Vacuna
        //private string descripVacuna;
        //[StringLength(500)]
        //public string DescripVacuna { get => descripVacuna; set => SetProperty(ref descripVacuna, value); }
        private long? tipoVacunaId;
        public long? TipoVacunaId { get => tipoVacunaId; set => SetProperty(ref tipoVacunaId, value); }
        private TipoVacunaTB? tipoVacuna;
        public virtual TipoVacunaTB? TipoVacuna { get => tipoVacuna; set => SetProperty(ref tipoVacuna, value); }


        ////Fabricante
        //private string fabricante;
        //[StringLength(250)]
        //public string Fabricante { get => fabricante; set => SetProperty(ref fabricante, value); }
        private long? laboratorioId;
        public long? LaboratorioId { get => laboratorioId; set => SetProperty(ref laboratorioId, value); }
        private LaboratorioTB? laboratorio;
        public virtual LaboratorioTB? Laboratorio { get => laboratorio; set => SetProperty(ref laboratorio, value); }

        //Fabricante
        private string lote;
        [StringLength(250)]
        public string Lote { get => lote; set => SetProperty(ref lote, value); }

        // Fecha de Expiración
        private DateTime? fechaExp;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaExp { get => fechaExp; set => SetProperty(ref fechaExp, value); }

        //Registro Sanitario
        private string regSanitario;
        [StringLength(250)]
        public string RegSanitario { get => regSanitario; set => SetProperty(ref regSanitario, value); }

        // Fecha de Vacunación
        private DateTime? fechaVacunacion;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaVacunacion { get => fechaVacunacion; set => SetProperty(ref fechaVacunacion, value); }

        //Indicaciones
        private string indicaciones;
        [StringLength(500)]
        public string Indicaciones { get => indicaciones; set => SetProperty(ref indicaciones, value); }

        //Dosis y Vía de Administración
        private string dosisViaAdmin;
        [StringLength(500)]
        public string DosisViaAdmin { get => dosisViaAdmin; set => SetProperty(ref dosisViaAdmin, value); }

        //Dosis en que se presenta el ESAVI
        //private string dosisEsavi;
        //[StringLength(200)]
        //public string DosisEsavi { get => dosisEsavi; set => SetProperty(ref dosisEsavi, value); }        
        private enumFMV_DosisNumero dosisPresenta;
        public enumFMV_DosisNumero DosisPresenta { get => dosisPresenta; set => SetProperty(ref dosisPresenta, value); }

        //Ficheros Adjuntos
        private AttachmentData adjunto;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public virtual AttachmentData Adjunto { get => adjunto; set => SetProperty(ref adjunto, value); }

    }
}
