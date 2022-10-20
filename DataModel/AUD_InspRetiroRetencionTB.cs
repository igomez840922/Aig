using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class AUD_InspRetiroRetencionTB:SystemId
    {
        //nombre del producto
        private string seccionOficinaRegional;
        [StringLength(250)]
        public string SeccionOficinaRegional { get => seccionOficinaRegional; set => SetProperty(ref seccionOficinaRegional, value); }

        //nombre de licencia o aviso de operaciones
        private string licenseNumber;
        [StringLength(250)]
        public string LicenseNumber { get => licenseNumber; set => SetProperty(ref licenseNumber, value); }


        public virtual List<AUD_ProdRetiroRetencionTB> LProductos { get; set; }

        //private AUD_InspeccionTB? inspeccion;
        //public virtual AUD_InspeccionTB? Inspeccion { get => inspeccion; set => SetProperty(ref inspeccion, value); }

    }
}
