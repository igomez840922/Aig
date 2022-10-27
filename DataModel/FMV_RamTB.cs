using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    //Notificaciones de Reacciones Adversas a Medicamentos
    public class FMV_RamTB:SystemId
    {
        //fecha y Hora de inicio del acta
        private DateTime? fechaRecibido;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRecibido { get => fechaRecibido; set => SetProperty(ref fechaRecibido, value); }

        //fecha de entrega al evaluador
        private DateTime? fechaEntregaEvaluador;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEntregaEvaluador { get => fechaEntregaEvaluador; set => SetProperty(ref fechaEntregaEvaluador, value); }

        //Establecimiento
        private long? evaluadorId;
        public long? EvaluadorId { get => evaluadorId; set => SetProperty(ref evaluadorId, value); }
        private FMV_EvaluadorTB? evaluador;
        public virtual FMV_EvaluadorTB? Evaluador { get => evaluador; set => SetProperty(ref evaluador, value); }

        private string farmacoSospechosoComercial;
        [StringLength(250)]
        public string FarmacoSospechosoComercial { get => farmacoSospechosoComercial; set => SetProperty(ref farmacoSospechosoComercial, value); }

        private string farmacoSospechosoDci;
        [StringLength(250)]
        public string FarmacoSospechosoDci { get => farmacoSospechosoDci; set => SetProperty(ref farmacoSospechosoDci, value); }

        private string atc;
        [StringLength(250)]
        public string Atc { get => atc; set => SetProperty(ref atc, value); }

        private string subGrupoTerapeutico;
        [StringLength(250)]
        public string SubGrupoTerapeutico { get => subGrupoTerapeutico; set => SetProperty(ref subGrupoTerapeutico, value); }

        private enumFMV_RAMType ramType;
        public enumFMV_RAMType RamType { get => ramType; set => SetProperty(ref ramType, value); }

        private enumFMV_RAMOrigenType ramOrigenType;
        public enumFMV_RAMOrigenType RamOrigenType { get => ramOrigenType; set => SetProperty(ref ramOrigenType, value); }

        private string codigoNotiFacedra;
        [StringLength(250)]
        public string CodigoNotiFacedra { get => codigoNotiFacedra; set => SetProperty(ref codigoNotiFacedra, value); }

        private string idFacedra;
        [StringLength(250)]
        public string IdFacedra { get => idFacedra; set => SetProperty(ref idFacedra, value); }

        private string codigoCNFV;
        [StringLength(250)]
        public string CodigoCNFV { get => codigoCNFV; set => SetProperty(ref codigoCNFV, value); }


        private List<FMV_RamProductTB> lProducts;
        [StringLength(250)]
        public List<FMV_RamProductTB> LProducts { get => lProducts; set => SetProperty(ref lProducts, value); }


    }
}
