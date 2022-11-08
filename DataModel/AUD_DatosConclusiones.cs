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
        //Observaciones
        private string observacionesFinales;
        public string ObservacionesFinales { get => observacionesFinales; set => SetProperty(ref observacionesFinales, value); }

        //También debe permitir la opción de adjuntar evidencia como fotos o algún documento escaneado.
        private List<AttachmentTB> lAttachments;
        public virtual List<AttachmentTB> LAttachments { get => lAttachments; set => SetProperty(ref lAttachments, value); }


        //Según criterio técnico se concluye que el local cumple  o no cumple con los requisitos mínimos para operar
        private bool cumpleRequisitosMinOperacion;
        public bool CumpleRequisitosMinOperacion { get => cumpleRequisitosMinOperacion; set => SetProperty(ref cumpleRequisitosMinOperacion, value); }

        /// <summary>
        /// Sección de Inspectores y aprobaciones
        /// </summary>
        /// 

        //Inspector 1 Nombre
        private string nombreInspector1;
        [StringLength(250)]
        public string NombreInspector1 { get => nombreInspector1; set => SetProperty(ref nombreInspector1, value); }

        //Inspector 1 registro
        private string registroInspector1;
        [StringLength(250)]
        public string RegistroInspector1 { get => registroInspector1; set => SetProperty(ref registroInspector1, value); }

        //Inspector 1 cargo
        private string cargoInspector1;
        [StringLength(250)]
        public string CargoInspector1 { get => cargoInspector1; set => SetProperty(ref cargoInspector1, value); }

        //Inspector 1 firma
        private string firmaInspector1;
        public string FirmaInspector1 { get => firmaInspector1; set => SetProperty(ref firmaInspector1, value); }


        //Inspector 2 Nombre
        private string nombreInspector2;
        [StringLength(250)]
        public string NombreInspector2 { get => nombreInspector2; set => SetProperty(ref nombreInspector2, value); }

        //Inspector 2 registro
        private string registroInspector2;
        [StringLength(250)]
        public string RegistroInspector2 { get => registroInspector2; set => SetProperty(ref registroInspector2, value); }

        //Inspector 2 cargo
        private string cargoInspector2;
        [StringLength(250)]
        public string CargoInspector2 { get => cargoInspector2; set => SetProperty(ref cargoInspector2, value); }

        //Inspector 2 firma
        private string firmaInspector2;
        public string FirmaInspector2 { get => firmaInspector2; set => SetProperty(ref firmaInspector2, value); }


        //Inspector 3 Nombre
        private string nombreInspector3;
        [StringLength(250)]
        public string NombreInspector3 { get => nombreInspector3; set => SetProperty(ref nombreInspector3, value); }

        //Inspector 3 registro
        private string registroInspector3;
        [StringLength(250)]
        public string RegistroInspector3 { get => registroInspector3; set => SetProperty(ref registroInspector3, value); }

        //Inspector 3 cargo
        private string cargoInspector3;
        [StringLength(250)]
        public string CargoInspector3 { get => cargoInspector3; set => SetProperty(ref cargoInspector3, value); }

        //Inspector 3 firma
        private string firmaInspector3;
        public string FirmaInspector3 { get => firmaInspector3; set => SetProperty(ref firmaInspector3, value); }

        //Inspector 4 Nombre
        private string nombreInspector4;
        [StringLength(250)]
        public string NombreInspector4 { get => nombreInspector4; set => SetProperty(ref nombreInspector4, value); }

        //Inspector 4 registro
        private string registroInspector4;
        [StringLength(250)]
        public string RegistroInspector4 { get => registroInspector4; set => SetProperty(ref registroInspector4, value); }

        //Inspector 4 cargo
        private string cargoInspector4;
        [StringLength(250)]
        public string CargoInspector4 { get => cargoInspector4; set => SetProperty(ref cargoInspector4, value); }

        //Inspector 4 firma
        private string firmaInspector4;
        public string FirmaInspector4 { get => firmaInspector4; set => SetProperty(ref firmaInspector4, value); }


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

        //firma representante legal
        private string firmaRepresentanteLegal;
        public string FirmaRepresentanteLegal { get => firmaRepresentanteLegal; set => SetProperty(ref firmaRepresentanteLegal, value); }

        //nombre representante legal
        private string nombreRegente;
        [StringLength(250)]
        public string NombreRegente { get => nombreRegente; set => SetProperty(ref nombreRegente, value); }

        //cedula representante legal
        private string cedulaRegente;
        [StringLength(250)]
        public string CedulaRegente { get => cedulaRegente; set => SetProperty(ref cedulaRegente, value); }

        //registro representante legal
        private string registroRegente;
        [StringLength(250)]
        public string RegistroRegente { get => registroRegente; set => SetProperty(ref registroRegente, value); }

        //firma representante legal
        private string firmaRegente;
        public string FirmaRegente { get => firmaRegente; set => SetProperty(ref firmaRegente, value); }

        //fecha y Hora de finalizacion
        private DateTime? fechaFinalizacion;
        public DateTime? FechaFinalizacion { get => fechaFinalizacion; set => SetProperty(ref fechaFinalizacion, value); }

       

    }
}
