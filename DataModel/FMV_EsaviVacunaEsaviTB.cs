using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_EsaviVacunaEsaviTB:SystemId
    {
        //VACUNA    
        private long? esaviVacunaId;
        public long? EsaviVacunaId { get => esaviVacunaId; set => SetProperty(ref esaviVacunaId, value); }
        private FMV_EsaviVacunaTB? esaviVacuna;
        [JsonIgnore]
        public virtual FMV_EsaviVacunaTB? EsaviVacuna { get => esaviVacuna; set => SetProperty(ref esaviVacuna, value); }


        // Hay Esavi?
        private enumFMV_EsaviClasificacion hayEsavi;
        public enumFMV_EsaviClasificacion HayEsavi { get => hayEsavi; set => SetProperty(ref hayEsavi, value); }

        //Eventos Supuestamente Atribuibles a la Vacunación o Inmunización
        private string esaviDescripcion;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string EsaviDescripcion { get => esaviDescripcion; set => SetProperty(ref esaviDescripcion, value); }


        // Fecha de Esavi
        private DateTime? fechaEsavi;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEsavi { get => fechaEsavi; set => SetProperty(ref fechaEsavi, value); }


        // Desenlace
        private enumFMV_RAMDesenlace desenlace;
        public enumFMV_RAMDesenlace Desenlace { get => desenlace; set => SetProperty(ref desenlace, value); }


        //// SOC
        private long? socId;
        public long? SocId { get => socId; set => SetProperty(ref socId, value); }
        // SOC: Los valores de la lista varia según las filas 
        private string soc;
        public string Soc { get => soc; set => SetProperty(ref soc, value); }


        // TERMINO WHOArt
        private long? terMedraId;
        public long? TerMedraId { get => terMedraId; set => SetProperty(ref terMedraId, value); }
        // TERMINO WHOArt (LLT) -- Término MedDRA
        private string terWhoArt;
        public string TerWhoArt { get => terWhoArt; set => SetProperty(ref terWhoArt, value); }


        //Intensidad de la ESAV
        private long? intensidadEsaviId;
        public long? IntensidadEsaviId { get => intensidadEsaviId; set => SetProperty(ref intensidadEsaviId, value); }
        private IntensidadEsaviTB? intensidadEsavi;
        public virtual IntensidadEsaviTB? IntensidadEsavi { get => intensidadEsavi; set => SetProperty(ref intensidadEsavi, value); }


        //EVALUACION DE LA CAUSALIDAD

        //Gravedad
        private string gravedad;
        [StringLength(250)]
        public string Gravedad { get => gravedad; set => SetProperty(ref gravedad, value); }

        //InvDetalle del Caso
        private enumOpcionSiNo invDetalleCaso;
        public enumOpcionSiNo InvDetalleCaso { get => invDetalleCaso; set => SetProperty(ref invDetalleCaso, value); }

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

    }
}
