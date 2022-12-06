using DataBindable;
using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    /// <summary>
    /// Datos de Conclusiones de Inspeccion
    /// </summary>
    public class AUD_DatosConclusiones : SystemId
    {
        public AUD_DatosConclusiones() {
            LAttachments=new List<AttachmentTB>();
            LParticipantes = new List<Participante>();
            LPartEstablecimiento = new List<Participante>();
        }

        //fecha y Hora de finalizacion
        private DateTime? fechaFinalizacion;
        public DateTime? FechaFinalizacion { get => fechaFinalizacion; set => SetProperty(ref fechaFinalizacion, value); }


        //Observaciones
        private string observacionesFinales;
        public string ObservacionesFinales { get => observacionesFinales; set => SetProperty(ref observacionesFinales, value); }

        //CRITERIO TÉCNICO DEL INSPECTOR
        private string criterioTecnicoInspector;
        public string CriterioTecnicoInspector { get => criterioTecnicoInspector; set => SetProperty(ref criterioTecnicoInspector, value); }

        //Inconformidades o desviaciones detectadas
        private string inconformidades;
        public string Inconformidades { get => inconformidades; set => SetProperty(ref inconformidades, value); }


        //También debe permitir la opción de adjuntar evidencia como fotos o algún documento escaneado.
        private List<AttachmentTB> lAttachments;
        public List<AttachmentTB> LAttachments { get => lAttachments; set => SetProperty(ref lAttachments, value); }


        //Según criterio técnico se concluye que el local cumple  o no cumple con los requisitos mínimos para operar
        private bool cumpleRequisitosMinOperacion;
        public bool CumpleRequisitosMinOperacion { get => cumpleRequisitosMinOperacion; set => SetProperty(ref cumpleRequisitosMinOperacion, value); }


        //Lista de Participantes
        private List<Participante> lParticipantes;
        public List<Participante> LParticipantes { get => lParticipantes; set => SetProperty(ref lParticipantes, value); }

        //Lista de Participantes Establecimiento
        private List<Participante> lPartEstablecimiento;
        public List<Participante> LPartEstablecimiento { get => lPartEstablecimiento; set => SetProperty(ref lPartEstablecimiento, value); }


        /// <summary>
        /// Sección de Inspectores y aprobaciones
        /// </summary>
        /// 

        //nombre representante legal
        private string nombreRepresentanteLegal;
        [StringLength(250)]
        public string NombreRepresentanteLegal { get => nombreRepresentanteLegal; set => SetProperty(ref nombreRepresentanteLegal, value); }

        //cedula representante legal
        private string cedulaRepresentanteLegal;
        [StringLength(250)]
        public string CedulaRepresentanteLegal { get => cedulaRepresentanteLegal; set => SetProperty(ref cedulaRepresentanteLegal, value); }

        //registro representante legal
        private string registroRepresentanteLegal;
        [StringLength(250)]
        public string RegistroRepresentanteLegal { get => registroRepresentanteLegal; set => SetProperty(ref registroRepresentanteLegal, value); }

        //registro representante legal
        private string cargoRepresentanteLegal;
        [StringLength(250)]
        public string CargoRepresentanteLegal { get => cargoRepresentanteLegal; set => SetProperty(ref cargoRepresentanteLegal, value); }


        //firma representante legal
        private string firmaRepresentanteLegal;
        public string FirmaRepresentanteLegal { get => firmaRepresentanteLegal; set => SetProperty(ref firmaRepresentanteLegal, value); }

        //nombre regente legal
        private string nombreRegente;
        [StringLength(250)]
        public string NombreRegente { get => nombreRegente; set => SetProperty(ref nombreRegente, value); }

        //cedula regente legal
        private string cedulaRegente;
        [StringLength(250)]
        public string CedulaRegente { get => cedulaRegente; set => SetProperty(ref cedulaRegente, value); }

        //registro regente legal
        private string registroRegente;
        [StringLength(250)]
        public string RegistroRegente { get => registroRegente; set => SetProperty(ref registroRegente, value); }

        //registro regente legal
        private string cargoRegente;
        [StringLength(250)]
        public string CargoRegente { get => cargoRegente; set => SetProperty(ref cargoRegente, value); }

        //firma regente legal
        private string firmaRegente;
        public string FirmaRegente { get => firmaRegente; set => SetProperty(ref firmaRegente, value); }



    }
}
