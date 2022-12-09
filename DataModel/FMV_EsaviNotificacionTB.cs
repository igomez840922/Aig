using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_EsaviNotificacionTB:SystemId
    {
        private long esaviId;
        public long EsaviId { get => esaviId; set => SetProperty(ref esaviId, value); }
        private FMV_EsaviTB esavi;
        public virtual FMV_EsaviTB Esavi { get => esavi; set => SetProperty(ref esavi, value); }


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
        private string dosisEsavi;
        [StringLength(200)]
        public string DosisEsavi { get => dosisEsavi; set => SetProperty(ref dosisEsavi, value); }

    }
}
