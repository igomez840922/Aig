using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModel
{
    public class TipoInstitucionTB : SystemId
    {
        //nombre de establecimiento
        private string nombre;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }


        //antigua BD
        private int iddb;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public int Iddb { get => iddb; set => SetProperty(ref iddb, value); }


        private List<InstitucionDestinoTB> lInstituciones;
        [JsonIgnore]
        public virtual List<InstitucionDestinoTB> LInstituciones { get => lInstituciones; set => SetProperty(ref lInstituciones, value); }

        private List<FMV_EsaviTB> lEsavi;
        [JsonIgnore]
        public virtual List<FMV_EsaviTB> LEsavi { get => lEsavi; set => SetProperty(ref lEsavi, value); }

        private List<FMV_FfTB> lFf;
        [JsonIgnore]
        public virtual List<FMV_FfTB> LFf { get => lFf; set => SetProperty(ref lFf, value); }

        private List<FMV_RamTB> lRam;
        [JsonIgnore]
        public virtual List<FMV_RamTB> LRam { get => lRam; set => SetProperty(ref lRam, value); }

        private List<FMV_Ram2TB> lRam2;
        [JsonIgnore]
        public virtual List<FMV_Ram2TB> LRam2 { get => lRam2; set => SetProperty(ref lRam2, value); }

        private List<FMV_Esavi2TB> lEsavi2;
        [JsonIgnore]
        public virtual List<FMV_Esavi2TB> LEsavi2 { get => lEsavi2; set => SetProperty(ref lEsavi2, value); }

    }
}
