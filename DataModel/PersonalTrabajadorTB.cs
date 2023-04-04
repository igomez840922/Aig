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
        [Required(ErrorMessage = "requerido")]
        public string NombreCompleto { get => nombreCompleto; set => SetProperty(ref nombreCompleto, value); }

        private string cargo;
        [StringLength(250)]
        public string Cargo { get => cargo; set => SetProperty(ref cargo, value); }


        private string telefono;
        [StringLength(250)]
        public string Telefono { get => telefono; set => SetProperty(ref telefono, value); }

        private string correo;
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
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

        private List<FMV_AlertaTB> lAlertas;
        public virtual List<FMV_AlertaTB> LAlertas { get => lAlertas; set => SetProperty(ref lAlertas, value); }

        private List<FMV_NotaTB> lNotas;
        public virtual List<FMV_NotaTB> LNotas { get => lNotas; set => SetProperty(ref lNotas, value); }

        private List<FMV_RamTB> lRams;
        public virtual List<FMV_RamTB> LRams { get => lRams; set => SetProperty(ref lRams, value); }

        private List<FMV_Ram2TB> lRams2;
        public virtual List<FMV_Ram2TB> LRams2 { get => lRams2; set => SetProperty(ref lRams2, value); }

        private List<FMV_FfTB> lFf;
        public virtual List<FMV_FfTB> LFf { get => lFf; set => SetProperty(ref lFf, value); }

        private List<FMV_FtTB> lFt;
        public virtual List<FMV_FtTB> LFt { get => lFt; set => SetProperty(ref lFt, value); }

        private List<FMV_EsaviTB> lEsavi;
        public virtual List<FMV_EsaviTB> LEsavi { get => lEsavi; set => SetProperty(ref lEsavi, value); }

        private List<FMV_Esavi2TB> lEsavi2;
        public virtual List<FMV_Esavi2TB> LEsavi2 { get => lEsavi2; set => SetProperty(ref lEsavi2, value); }


        //private List<FMV_IpsProductTB> lIpsProducts;
        //public virtual List<FMV_IpsProductTB> LIpsProducts { get => lIpsProducts; set => SetProperty(ref lIpsProducts, value); }
    }
}
