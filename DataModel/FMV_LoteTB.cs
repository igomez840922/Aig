using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModel {
    public class FMV_LoteTB : SystemId 
    {
        //Falla farmaceutica
        private long? ffId;
        public long? FfId { get => ffId; set => SetProperty(ref ffId, value); }
        private FMV_FfTB? ff;
        [JsonIgnore]
        public virtual FMV_FfTB? Ff { get => ff; set => SetProperty(ref ff, value); }


        //Falla farmaceutica
        private long? ftId;
        public long? FtId { get => ftId; set => SetProperty(ref ftId, value); }
        private FMV_FtTB? ft;
        [JsonIgnore]
        public virtual FMV_FtTB? Ft { get => ft; set => SetProperty(ref ft, value); }


        //nombre
        private string nombre;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        /// Fecha de Expiracion
        private DateTime? fechaExpira;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaExpira { get => fechaExpira; set => SetProperty(ref fechaExpira, value); }

    }
}
