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

        //cedula 1 registro
        private string cedulaInspector1;
        [StringLength(250)]
        public string CedulaInspector1 { get => cedulaInspector1; set => SetProperty(ref cedulaInspector1, value); }

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

        //cedula 2 registro
        private string cedulaInspector2;
        [StringLength(250)]
        public string CedulaInspector2 { get => cedulaInspector2; set => SetProperty(ref cedulaInspector2, value); }

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

        //cedula 3 registro
        private string cedulaInspector3;
        [StringLength(250)]
        public string CedulaInspector3 { get => cedulaInspector3; set => SetProperty(ref cedulaInspector3, value); }

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

        //cedula 4 registro
        private string cedulaInspector4;
        [StringLength(250)]
        public string CedulaInspector4 { get => cedulaInspector4; set => SetProperty(ref cedulaInspector4, value); }


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


        //Inspector 5 Nombre
        private string nombreInspector5;
        [StringLength(250)]
        public string NombreInspector5 { get => nombreInspector5; set => SetProperty(ref nombreInspector5, value); }

        //cedula 5 registro
        private string cedulaInspector5;
        [StringLength(250)]
        public string CedulaInspector5 { get => cedulaInspector5; set => SetProperty(ref cedulaInspector5, value); }

        //Inspector 5 registro
        private string registroInspector5;
        [StringLength(250)]
        public string RegistroInspector5 { get => registroInspector5; set => SetProperty(ref registroInspector5, value); }

        //Inspector 5 cargo
        private string cargoInspector5;
        [StringLength(250)]
        public string CargoInspector5 { get => cargoInspector5; set => SetProperty(ref cargoInspector5, value); }

        //Inspector 5 firma
        private string firmaInspector5;
        public string FirmaInspector5 { get => firmaInspector5; set => SetProperty(ref firmaInspector5, value); }


        //Inspector 6 Nombre
        private string nombreInspector6;
        [StringLength(250)]
        public string NombreInspector6 { get => nombreInspector6; set => SetProperty(ref nombreInspector6, value); }

        //cedula 6 registro
        private string cedulaInspector6;
        [StringLength(250)]
        public string CedulaInspector6 { get => cedulaInspector6; set => SetProperty(ref cedulaInspector6, value); }

        //Inspector 6 registro
        private string registroInspector6;
        [StringLength(250)]
        public string RegistroInspector6 { get => registroInspector6; set => SetProperty(ref registroInspector6, value); }

        //Inspector 6 cargo
        private string cargoInspector6;
        [StringLength(250)]
        public string CargoInspector6 { get => cargoInspector6; set => SetProperty(ref cargoInspector6, value); }

        //Inspector 6 firma
        private string firmaInspector6;
        public string FirmaInspector6 { get => firmaInspector6; set => SetProperty(ref firmaInspector6, value); }


        //Inspector 7 Nombre
        private string nombreInspector7;
        [StringLength(250)]
        public string NombreInspector7 { get => nombreInspector7; set => SetProperty(ref nombreInspector7, value); }

        //cedula 7 registro
        private string cedulaInspector7;
        [StringLength(250)]
        public string CedulaInspector7 { get => cedulaInspector7; set => SetProperty(ref cedulaInspector7, value); }


        //Inspector 7 registro
        private string registroInspector7;
        [StringLength(250)]
        public string RegistroInspector7 { get => registroInspector7; set => SetProperty(ref registroInspector7, value); }

        //Inspector 7 cargo
        private string cargoInspector7;
        [StringLength(250)]
        public string CargoInspector7 { get => cargoInspector7; set => SetProperty(ref cargoInspector7, value); }

        //Inspector 7 firma
        private string firmaInspector7;
        public string FirmaInspector7 { get => firmaInspector7; set => SetProperty(ref firmaInspector7, value); }

        //Inspector 8 Nombre
        private string nombreInspector8;
        [StringLength(250)]
        public string NombreInspector8 { get => nombreInspector8; set => SetProperty(ref nombreInspector8, value); }

        //cedula 7 registro
        private string cedulaInspector8;
        [StringLength(250)]
        public string CedulaInspector8 { get => cedulaInspector8; set => SetProperty(ref cedulaInspector8, value); }

        //Inspector 8 registro
        private string registroInspector8;
        [StringLength(250)]
        public string RegistroInspector8 { get => registroInspector8; set => SetProperty(ref registroInspector8, value); }

        //Inspector 8 cargo
        private string cargoInspector8;
        [StringLength(250)]
        public string CargoInspector8 { get => cargoInspector8; set => SetProperty(ref cargoInspector8, value); }

        //Inspector 8 firma
        private string firmaInspector8;
        public string FirmaInspector8 { get => firmaInspector8; set => SetProperty(ref firmaInspector8, value); }


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


        //fecha y Hora de finalizacion
        private DateTime? fechaFinalizacion;
        public DateTime? FechaFinalizacion { get => fechaFinalizacion; set => SetProperty(ref fechaFinalizacion, value); }

       

    }
}
