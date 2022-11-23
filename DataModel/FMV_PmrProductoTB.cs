using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_PmrProductoTB:SystemId
    {
        private long pmrId;
        public long PmrId { get => pmrId; set => SetProperty(ref pmrId, value); }
        private FMV_PmrTB pmr;
        public virtual FMV_PmrTB Pmr { get => pmr; set => SetProperty(ref pmr, value); }

        private string regSanitario;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string RegSanitario { get => regSanitario; set => SetProperty(ref regSanitario, value); }

        private string nomComercial;
        [StringLength(500)]
        [Required(ErrorMessage = "requerido")]
        public string NomComercial { get => nomComercial; set => SetProperty(ref nomComercial, value); }
                
        //Laboratorio
        private long? laboratorioId;
        public long? LaboratorioId { get => laboratorioId; set => SetProperty(ref laboratorioId, value); }
        private LaboratorioTB? laboratorio;
        public virtual LaboratorioTB? Laboratorio { get => laboratorio; set => SetProperty(ref laboratorio, value); }

    }
}
