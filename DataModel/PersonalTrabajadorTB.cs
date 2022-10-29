using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class PersonalTrabajadorTB : SystemId
    {
        //num de licencia o aviso de operaciones
        private string nombreCompleto;
        [StringLength(500)]
        [Required(ErrorMessage = "RequiredField")]
        public string NombreCompleto { get => nombreCompleto; set => SetProperty(ref nombreCompleto, value); }

        private string telefono;
        [StringLength(250)]
        public string Telefono { get => telefono; set => SetProperty(ref telefono, value); }

        private string correo;
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "InvalidEmail")]
        [StringLength(250)]
        public string Correo { get => correo; set => SetProperty(ref correo, value); }

        private bool evaluador;
        public bool Evaluador { get => evaluador; set => SetProperty(ref evaluador, value); }

        private bool tramitador;
        public bool Tramitador { get => tramitador; set => SetProperty(ref tramitador, value); }

        private bool registrador;
        public bool Registrador { get => registrador; set => SetProperty(ref registrador, value); }


        private List<FMV_PmrTB> lPmr;
        public virtual List<FMV_PmrTB> LPmr { get => lPmr; set => SetProperty(ref lPmr, value); }


        private List<FMV_IpsTB> lIpsRegistrador;
        public virtual List<FMV_IpsTB> LIpsRegistrador { get => lIpsRegistrador; set => SetProperty(ref lIpsRegistrador, value); }

        private List<FMV_IpsTB> lIpsTramitador;
        public virtual List<FMV_IpsTB> LIpsTramitador { get => lIpsTramitador; set => SetProperty(ref lIpsTramitador, value); }

        private List<FMV_IpsTB> lIpsEvaluador;
        public virtual List<FMV_IpsTB> LIpsEvaluador { get => lIpsEvaluador; set => SetProperty(ref lIpsEvaluador, value); }

        //private List<FMV_IpsProductTB> lIpsProducts;
        //public virtual List<FMV_IpsProductTB> LIpsProducts { get => lIpsProducts; set => SetProperty(ref lIpsProducts, value); }
    }
}
