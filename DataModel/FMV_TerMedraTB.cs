using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{    
    public class FMV_TerMedraTB : SystemId
    {
        // Soc
        private long? socId;
        public long? SocId { get => socId; set => SetProperty(ref socId, value); }
        private FMV_SocTB? soc;
        public virtual FMV_SocTB? Soc { get => soc; set => SetProperty(ref soc, value); }

        //nombre
        private string nombre;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

    }
}
