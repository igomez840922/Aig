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
    public class FMV_RamFarmacoTB : SystemId
    {
        public FMV_RamFarmacoTB() {
            LRams = new List<FMV_RamFarmacoRamTB>();
        }

        //RAM
        private long? ramId;
        public long? RamId { get => ramId; set => SetProperty(ref ramId, value); }
        private FMV_Ram2TB? ram;
        [JsonIgnore]
        public virtual FMV_Ram2TB? Ram { get => ram; set => SetProperty(ref ram, value); }


        private string farmacoSospechosoComercial;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string FarmacoSospechosoComercial { get => farmacoSospechosoComercial; set => SetProperty(ref farmacoSospechosoComercial, value); }

        private string farmacoSospechosoDci;
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string FarmacoSospechosoDci { get => farmacoSospechosoDci; set => SetProperty(ref farmacoSospechosoDci, value); }

        private string atc;
        [StringLength(250)]
        public string Atc { get => atc; set => SetProperty(ref atc, value); }

        private string atc2;
        [StringLength(250)]
        public string Atc2 { get => atc2; set => SetProperty(ref atc2, value); }

        private string subGrupoTerapeutico;
        [StringLength(250)]
        public string SubGrupoTerapeutico { get => subGrupoTerapeutico; set => SetProperty(ref subGrupoTerapeutico, value); }

        // Dosis, Frecuencia, Vía de Administración
        private string viaAdministracion;
        [StringLength(300)]
        public string ViaAdministracion { get => viaAdministracion; set => SetProperty(ref viaAdministracion, value); }

        // Indicación. null
        private string indicacion;
        [StringLength(300)]
        public string Indicacion { get => indicacion; set => SetProperty(ref indicacion, value); }

        // Fecha de Tratamiento. null
        private DateTime? fechaTratamiento;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaTratamiento { get => fechaTratamiento; set => SetProperty(ref fechaTratamiento, value); }

        // Conducta sobre Dosis. Total=3. Disminuyó la dosis, No disminuyó la dosis, null
        private enumFMV_RAMConductaDosis conductaDosis;
        public enumFMV_RAMConductaDosis ConductaDosis { get => conductaDosis; set => SetProperty(ref conductaDosis, value); }

        // Conducta sobre Terapia. Total=3. Suspendió la terapia, Mantuvo la terapia, null
        private enumFMV_RAMConductaTerapia conductaTerapia;
        public enumFMV_RAMConductaTerapia ConductaTerapia { get => conductaTerapia; set => SetProperty(ref conductaTerapia, value); }

        // Reexposición. Total=3. Si, No, null
        private enumOpcionSiNo reexposicion;
        public enumOpcionSiNo Reexposicion { get => reexposicion; set => SetProperty(ref reexposicion, value); }

        /////////////////////////////
        ///REACCIONES ADVERSAS

        private List<FMV_RamFarmacoRamTB> lRams;
        public virtual List<FMV_RamFarmacoRamTB> LRams { get => lRams; set => SetProperty(ref lRams, value); }


    }
}
