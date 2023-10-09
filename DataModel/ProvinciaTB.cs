using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class ProvinciaTB : SystemId
	{
		//nombre
		private string nombre;
		[StringLength(250)]
		[Required(ErrorMessage = "requerido")]
		public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

		//codigo
		private string codigo;
		[StringLength(250)]
		public string Codigo { get => codigo; set => SetProperty(ref codigo, value); }

		//pais
		private long? paisId;
		public long? PaisId { get => paisId; set => SetProperty(ref paisId, value); }
		private PaisTB? pais;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual PaisTB? Pais { get => pais; set => SetProperty(ref pais, value); }

        private List<DistritoTB> lDistritos;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<DistritoTB> LDistritos { get => lDistritos; set => SetProperty(ref lDistritos, value); }


        //private List<InstitucionDestinoTB> lInstitucion;
        //[System.Text.Json.Serialization.JsonIgnore]
        //public virtual List<InstitucionDestinoTB> LInstitucion { get => lInstitucion; set => SetProperty(ref lInstitucion, value); }

        //private List<FMV_EsaviTB> lEsavi;
        //[System.Text.Json.Serialization.JsonIgnore]
        //public virtual List<FMV_EsaviTB> LEsavi { get => lEsavi; set => SetProperty(ref lEsavi, value); }

        //private List<FMV_FfTB> lFf;
        //[System.Text.Json.Serialization.JsonIgnore]
        //public virtual List<FMV_FfTB> LFf { get => lFf; set => SetProperty(ref lFf, value); }

        //private List<FMV_RamTB> lRam;
        //[System.Text.Json.Serialization.JsonIgnore]
        //public virtual List<FMV_RamTB> LRam { get => lRam; set => SetProperty(ref lRam, value); }

        //private List<FMV_Ram2TB> lRam2;
        //[System.Text.Json.Serialization.JsonIgnore]
        //public virtual List<FMV_Ram2TB> LRam2 { get => lRam2; set => SetProperty(ref lRam2, value); }

        //private List<FMV_Esavi2TB> lEsavi2;
        //[System.Text.Json.Serialization.JsonIgnore]
        //public virtual List<FMV_Esavi2TB> LEsavi2 { get => lEsavi2; set => SetProperty(ref lEsavi2, value); }
    }
}
