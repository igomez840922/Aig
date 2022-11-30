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
        public FMV_RamTB()
        {
            LNotificaciones = new List<FMV_RamNotificacionTB>();
        }

        // Fecha de recibido (CNFV)
        private DateTime? fechaRecibidoCNFV;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRecibidoCNFV { get => fechaRecibidoCNFV; set => SetProperty(ref fechaRecibidoCNFV, value); }

        // Fecha de entrega al evaluador
        private DateTime? fechaEntregaEva;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaEntregaEva { get => fechaEntregaEva; set => SetProperty(ref fechaEntregaEva, value); }

        // Evaluador
        private long? evaluadorId;
        public long? EvaluadorId { get => evaluadorId; set => SetProperty(ref evaluadorId, value); }
        private PersonalTrabajadorTB? evaluador;
        public virtual PersonalTrabajadorTB? Evaluador { get => evaluador; set => SetProperty(ref evaluador, value); }


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
        [Required(ErrorMessage = "requerido")]
        [StringLength(250)]
        public string CodigoCNFV { get => codigoCNFV; set => SetProperty(ref codigoCNFV, value); }

        // Valores Únicos - Código del CNFV. Total=2. 1, 0
        /*FÓRMULA: Si la cantidad de valores totales en toda la columna [codCNFV] es mayor que 1 entonces [valUnicos]=0 si no: [valUnicos]=1 */
        //Total
        private int valUnico;
        public int ValUnico { 
            get { return LNotificaciones?.Count > 1 ? 0 : 1; }
            set => SetProperty(ref valUnico, value); 
        }

        //PROCEDENCIA DE NOTIFICACION - Lista de Procedencias
        private List<FMV_RamNotificacionTB> lNotificaciones;
        public virtual List<FMV_RamNotificacionTB> LNotificaciones { get => lNotificaciones; set => SetProperty(ref lNotificaciones, value); }

    }
}
