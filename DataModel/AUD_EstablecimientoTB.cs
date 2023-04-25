using DataModel.Helper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModel
{	

	/// <summary>
	/// Tabla que guarda los Establecimientos con Lic. de Operaciones 
	/// </summary>
	public class AUD_EstablecimientoTB: SystemId
	{
		public AUD_EstablecimientoTB()
		{
            FarmaceuticoTablas = new AUD_FarmaceuticoTablas();

        }

        //nombre de establecimiento -- NOMB_ESTA
        private string nombre; 
		[StringLength(250)]
		[Required(ErrorMessage = "requerido")]
		public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

        //Numero de Licencia -- debe ser campo unico -- LICENCIA_N
        private string numLicencia;
		[StringLength(250)]
		//[Required(ErrorMessage = "requerido")]
		public string NumLicencia { get => numLicencia; set => SetProperty(ref numLicencia, value); }

        //Aviso Operaciones
        private string avisoOperaciones;
        [StringLength(250)]
        public string AvisoOperaciones { get => avisoOperaciones; set => SetProperty(ref avisoOperaciones, value); }

        //Año -- PER_ODO
        private int? periodo;
		public int? Periodo { get => periodo; set => SetProperty(ref periodo, value); }

        //TIPO_ESTAB
        private enumAUD_TipoEstablecimiento tipoEstablecimiento;
        public enumAUD_TipoEstablecimiento TipoEstablecimiento { get => tipoEstablecimiento; set => SetProperty(ref tipoEstablecimiento, value); }

        //clasificacion -- CLASIF
        private enumAUD_ClasifEstablecimiento clasificacion;
		public enumAUD_ClasifEstablecimiento Clasificacion { get => clasificacion; set => SetProperty(ref clasificacion, value); }

        //sector -- SECTOR
        private enumAUD_TipoSector sector;
		public enumAUD_TipoSector Sector { get => sector; set => SetProperty(ref sector, value); }

		//institución
		private string institucion;
		[StringLength(250)]
		public string Institucion { get => institucion; set => SetProperty(ref institucion, value); }

        //fecha expedicion -- EXPEDIDA
        private DateTime? fechaexpedida;
		public DateTime? FechaExpedida { get => fechaexpedida; set => SetProperty(ref fechaexpedida, value); }

        //fecha expiracion -- EXPIRA
        private DateTime? fechaExpiracion;
		public DateTime? FechaExpiracion { get => fechaExpiracion; set => SetProperty(ref fechaExpiracion, value); }

		//fecha modificacion
		private DateTime? fechaModificacion;
		public DateTime? FechaModificacion { get => fechaModificacion; set => SetProperty(ref fechaModificacion, value); }

		//fecha vigencia
		private DateTime? fechaVigencia;
		public DateTime? FechaVigencia { get => fechaVigencia; set => SetProperty(ref fechaVigencia, value); }


        //fecha vigencia inicial -- VIGENCIA
        private DateTime? fechaVigenciaIni;
		public DateTime? FechaVigenciaIni { get => fechaVigenciaIni; set => SetProperty(ref fechaVigenciaIni, value); }

		//fecha vigencia final
		private DateTime? fechaVigenciaFin;
		public DateTime? FechaVigenciaFin { get => fechaVigenciaFin; set => SetProperty(ref fechaVigenciaFin, value); }

        //Numero o ID de Maquina
        private string reciboPago;
        [StringLength(250)]
        public string ReciboPago { get => reciboPago; set => SetProperty(ref reciboPago, value); }

        //Numero o ID de Maquina
        private string noMaquina;
		[StringLength(250)]
		public string NoMaquina { get => noMaquina; set => SetProperty(ref noMaquina, value); }

		//fecha de duplicado
		private DateTime? fechaDuplicado;
		public DateTime? FechaDuplicado { get => fechaDuplicado; set => SetProperty(ref fechaDuplicado, value); }

        //Provincia -- PROV
        private long? provinciaId;
        public long? ProvinciaId { get => provinciaId; set => SetProperty(ref provinciaId, value); }
		private ProvinciaTB? provincia;
		public virtual ProvinciaTB? Provincia { get => provincia; set => SetProperty(ref provincia, value); }

        //distrito -- DISTRITO
        private long? distritoId;
		public long? DistritoId { get => distritoId; set => SetProperty(ref distritoId, value); }
		private DistritoTB? distrito;
		public virtual DistritoTB? Distrito { get => distrito; set => SetProperty(ref distrito, value); }

        //distrito -- CORREG
        private long? corregimientoId;
		public long? CorregimientoId { get => corregimientoId; set => SetProperty(ref corregimientoId, value); }
		private CorregimientoTB? corregimiento;
		public virtual CorregimientoTB? Corregimiento { get => corregimiento; set => SetProperty(ref corregimiento, value); }

        //ubicacion -- UBICACI_N_
        private string ubicacion;
		[StringLength(500)]
		public string Ubicacion { get => ubicacion; set => SetProperty(ref ubicacion, value); }

		//Direccion
		private string direccion;
		[StringLength(500)]
		public string Direccion { get => direccion; set => SetProperty(ref direccion, value); }

        //telefono1 -- N__TEL_FON
        private string telefono1;
		[StringLength(250)]
		public string Telefono1 { get => telefono1; set => SetProperty(ref telefono1, value); }

		//telefono1
		private string telefono2;
		[StringLength(250)]
		public string Telefono2 { get => telefono2; set => SetProperty(ref telefono2, value); }

		//correo electronico
		private string email;
		[StringLength(250)]
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "inválido")]
		public string Email { get => email; set => SetProperty(ref email, value); }

        //horarios del establecimiento -- HORARIO__E
        [StringLength(300)]
        private string horariosEstablecimiento;
		public string HorariosEstablecimiento { get => horariosEstablecimiento; set => SetProperty(ref horariosEstablecimiento, value); }

        //area de controlados
        private string areaControlado;
        [StringLength(250)]
        public string AreaControlado { get => areaControlado; set => SetProperty(ref areaControlado, value); }
		      
		//tipo de actividad del establecimiento
		private string tipoActividad;
		public string TipoActividad { get => tipoActividad; set => SetProperty(ref tipoActividad, value); }

		//Solicitante de Licencia
		private string solicitanteLicNombre;
		[StringLength(250)]
		public string SolicitanteLicNombre { get => solicitanteLicNombre; set => SetProperty(ref solicitanteLicNombre, value); }

		//Solicitante de cedula
		private string solicitanteLicCedula;
		[StringLength(250)]
		public string SolicitanteLicCedula { get => solicitanteLicCedula; set => SetProperty(ref solicitanteLicCedula, value); }

        //Estatus -- STATUS
        private enumAUD_StatusEstablecimiento status;
		public enumAUD_StatusEstablecimiento Status { get => status; set => SetProperty(ref status, value); }

		//fecha de cierre
		private DateTime? fechaCierre;
		public DateTime? FechaCierre { get => fechaCierre; set => SetProperty(ref fechaCierre, value); }


        //Representante legal -- REPR_O__PR
        private string repLegalNombre;
		[StringLength(250)]
		public string RepLegalNombre { get => repLegalNombre; set => SetProperty(ref repLegalNombre, value); }

        //Representante legal cedula -- CED_REP
        private string repLegalCedula;
		[StringLength(250)]
		public string RepLegalCedula { get => repLegalCedula; set => SetProperty(ref repLegalCedula, value); }

		//Representante legal
		private string corregidorNombre;
		[StringLength(250)]
		public string CorregidorNombre { get => corregidorNombre; set => SetProperty(ref corregidorNombre, value); }

        //nombre de establecimiento -- NOMB__SOCI
        private string nombreSociedad;
		[StringLength(250)]
		public string NombreSociedad { get => nombreSociedad; set => SetProperty(ref nombreSociedad, value); }

		//nombre del farmaceutico #1
		private string farmac1Nombre;
		[StringLength(250)]
		public string Farmac1Nombre { get => farmac1Nombre; set => SetProperty(ref farmac1Nombre, value); }

		//Num. registro del farmaceutico #1
		private string farmac1NumRegistro;
		[StringLength(250)]
		public string Farmac1NumRegistro { get => farmac1NumRegistro; set => SetProperty(ref farmac1NumRegistro, value); }

		//Sector del farmaceutico #1
		private string farmac1Sector;
		[StringLength(250)]
		public string Farmac1Sector { get => farmac1Sector; set => SetProperty(ref farmac1Sector, value); }

		//vmedico del farmaceutico #1
		private string farmac1VMedico;
		[StringLength(250)]
		public string Farmac1VMedico { get => farmac1VMedico; set => SetProperty(ref farmac1VMedico, value); }

		//nombre del farmaceutico #2
		private string farmac2Nombre;
		[StringLength(250)]
		public string Farmac2Nombre { get => farmac2Nombre; set => SetProperty(ref farmac2Nombre, value); }

		//Num. registro del farmaceutico #2
		private string farmac2NumRegistro;
		[StringLength(250)]
		public string Farmac2NumRegistro { get => farmac2NumRegistro; set => SetProperty(ref farmac2NumRegistro, value); }

		//Sector del farmaceutico #2
		private string farmac2Sector;
		[StringLength(250)]
		public string Farmac2Sector { get => farmac2Sector; set => SetProperty(ref farmac2Sector, value); }

		//vmedico del farmaceutico #2
		private string farmac2VMedico;
		[StringLength(250)]
		public string Farmac2VMedico { get => farmac2VMedico; set => SetProperty(ref farmac2VMedico, value); }

		//observaciones
		private string observaciones;
		public string Observaciones { get => observaciones; set => SetProperty(ref observaciones, value); }

        private List<AUD_InspeccionTB> lInspections;
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual List<AUD_InspeccionTB> LInspections { get => lInspections; set => SetProperty(ref lInspections, value); }


		private string nameAndRegNum;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string NameAndRegNum { 
			get { return string.Format("{0} - {1}", NumLicencia, Nombre); } 
			set => SetProperty(ref nameAndRegNum, value); 
		}

        //1. Farmaceuticos
        private AUD_FarmaceuticoTablas farmaceuticoTablas;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public AUD_FarmaceuticoTablas FarmaceuticoTablas { get => farmaceuticoTablas; set => SetProperty(ref farmaceuticoTablas, value); }

        //1. Representante Legal
        private PersonaDatos representanteLegal;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public PersonaDatos RepresentanteLegal { get => representanteLegal; set => SetProperty(ref representanteLegal, value); }

        //1. Regente Farmaceutico
        private PersonaDatos regente;
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public PersonaDatos Regente { get => regente; set => SetProperty(ref regente, value); }

    }
}
