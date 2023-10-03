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
    public class InstitucionDestinoTB : SystemId
    {

        private long? tipoInstitucionId;
        public long? TipoInstitucionId { get => tipoInstitucionId; set => SetProperty(ref tipoInstitucionId, value); }
        private TipoInstitucionTB? tipoInstitucion;
        public virtual TipoInstitucionTB? TipoInstitucion { get => tipoInstitucion; set => SetProperty(ref tipoInstitucion, value); }

        private long? provinciaId;
        public long? ProvinciaId { get => provinciaId; set => SetProperty(ref provinciaId, value); }
        private ProvinciaTB? provincia;
        public virtual ProvinciaTB? Provincia { get => provincia; set => SetProperty(ref provincia, value); }

        //nombre de establecimiento
        private string nombre;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //descripcion de establecimiento
        private string descripcion;
        public string Descripcion { get => descripcion; set => SetProperty(ref descripcion, value); }

        ////Tipo de Nota o Alerta
        //private enumFMV_NoteType? tipoNota;
        //public enumFMV_NoteType? TipoNota { get => tipoNota; set => SetProperty(ref tipoNota, value); }


        private List<FMV_NotaTB> lNotas;
        [JsonIgnore]
        public virtual List<FMV_NotaTB> LNotas { get => lNotas; set => SetProperty(ref lNotas, value); }

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
        public virtual List<FMV_Ram2TB> LRam2{ get => lRam2; set => SetProperty(ref lRam2, value); }

        private List<FMV_Esavi2TB> lEsavi2;
        [JsonIgnore]
        public virtual List<FMV_Esavi2TB> LEsavi2 { get => lEsavi2; set => SetProperty(ref lEsavi2, value); }

    }
}
