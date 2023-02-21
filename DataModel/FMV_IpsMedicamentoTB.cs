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
    public class FMV_IpsMedicamentoTB : SystemId
    {
        public FMV_IpsMedicamentoTB()
        {

        }

        //ESAVI
        private long? ipsId;
        public long? IpsId { get => ipsId; set => SetProperty(ref ipsId, value); }
        private FMV_IpsTB? ips;
        [JsonIgnore]
        public virtual FMV_IpsTB? Ips { get => ips; set => SetProperty(ref ips, value); }


        private string nomComercial;
        [StringLength(500)]
        [Required(ErrorMessage = "requerido")]
        public string NomComercial { get => nomComercial; set => SetProperty(ref nomComercial, value); }

        private string nomDCI;
        [StringLength(500)]
        public string NomDCI { get => nomDCI; set => SetProperty(ref nomDCI, value); }

        private string regSanitario;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string RegSanitario { get => regSanitario; set => SetProperty(ref regSanitario, value); }

        //Titular
        //Laboratorio
        private long? laboratorioId;
        public long? LaboratorioId { get => laboratorioId; set => SetProperty(ref laboratorioId, value); }
        private LaboratorioTB? laboratorio;
        public virtual LaboratorioTB? Laboratorio { get => laboratorio; set => SetProperty(ref laboratorio, value); }


    }

}
