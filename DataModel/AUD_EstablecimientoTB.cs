using DataModel.Helper;
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
	public enum enumAUD_TipoEstablecimiento
	{
		[Description("User")]
		None = 0,
		[Description("Admin")]
		Admin = 1,
		[Description("PosUser")]
		Manager = 2,
	}

	/// <summary>
	/// Tabla que guarda los Establecimientos con Lic. de Operaciones 
	/// </summary>
	public class AUD_EstablecimientoTB: SystemId
	{
		//nombre de establecimiento
		private string nombre; 
		[StringLength(250)]
		[Required(ErrorMessage = "RequiredField")]
		public string Nombre { get => nombre; set => SetProperty(ref nombre, value); }

		//Numero de Licencia -- debe ser campo unico
		private string numLicencia;
		[StringLength(250)]
		[Required(ErrorMessage = "RequiredField")]
		public string NumLicencia { get => numLicencia; set => SetProperty(ref numLicencia, value); }

		//Año
		private int periodo;
		public int Periodo { get => periodo; set => SetProperty(ref periodo, value); }

		//tipo de establecimiento
		private long? tipoEstablecimientoId;
		public long? TipoEstablecimientoId { get => tipoEstablecimientoId; set => SetProperty(ref tipoEstablecimientoId, value); }
		private AUD_TipoEstablecimientoTB? tipoEstablecimiento;
		public virtual AUD_TipoEstablecimientoTB? TipoEstablecimiento { get => tipoEstablecimiento; set => SetProperty(ref tipoEstablecimiento, value); }

		//clasificacion
		private enumAUD_TipoTramite clasificacion;
		public enumAUD_TipoTramite Clasificacion { get => clasificacion; set => SetProperty(ref clasificacion, value); }

		//sector
		private enumAUD_TipoSector sector;
		public enumAUD_TipoSector Sector { get => sector; set => SetProperty(ref sector, value); }


		//institución
		private string institucion;
		[StringLength(250)]
		public string Institucion { get => institucion; set => SetProperty(ref institucion, value); }

		//fecha expedicion
		private DateTime? fechaexpedida;
		public DateTime? FechaExpedida { get => fechaexpedida; set => SetProperty(ref fechaexpedida, value); }

		//fecha expiracion
		private DateTime? fechaExpiracion;
		public DateTime? FechaExpiracion { get => fechaExpiracion; set => SetProperty(ref fechaExpiracion, value); }

		//fecha modificacion
		private DateTime? fechaModificacion;
		public DateTime? FechaModificacion { get => fechaModificacion; set => SetProperty(ref fechaModificacion, value); }

		//fecha vigencia
		private DateTime? fechaVigencia;
		public DateTime? FechaVigencia { get => fechaVigencia; set => SetProperty(ref fechaVigencia, value); }


		//fecha vigencia inicial
		private DateTime? fechaVigenciaIni;
		public DateTime? FechaVigenciaIni { get => fechaVigenciaIni; set => SetProperty(ref fechaVigenciaIni, value); }

		//fecha vigencia final
		private DateTime? fechaVigenciaFin;
		public DateTime? FechaVigenciaFin { get => fechaVigenciaFin; set => SetProperty(ref fechaVigenciaFin, value); }


		//Numero o ID de Maquina
		private string noMaquina;
		[StringLength(250)]
		public string NoMaquina { get => noMaquina; set => SetProperty(ref noMaquina, value); }

		//fecha de duplicado
		private DateTime? fechaDuplicado;
		public DateTime? FechaDuplicado { get => fechaDuplicado; set => SetProperty(ref fechaDuplicado, value); }


		//Provincia
		private long? provinciaId;
		public long? ProvinciaId { get => provinciaId; set => SetProperty(ref provinciaId, value); }
		private ProvinciaTB? provincia;
		public virtual ProvinciaTB? Provincia { get => provincia; set => SetProperty(ref provincia, value); }

		//distrito
		private long? distritoId;
		public long? DistritoId { get => distritoId; set => SetProperty(ref distritoId, value); }
		private DistritoTB? distrito;
		public virtual DistritoTB? Distrito { get => distrito; set => SetProperty(ref distrito, value); }

		//distrito
		private long? corregimientoId;
		public long? CorregimientoId { get => corregimientoId; set => SetProperty(ref corregimientoId, value); }
		private CorregimientoTB? corregimiento;
		public virtual CorregimientoTB? Corregimiento { get => corregimiento; set => SetProperty(ref corregimiento, value); }

		//ubicacion
		private string ubicacion;
		[StringLength(500)]
		public string Ubicacion { get => ubicacion; set => SetProperty(ref ubicacion, value); }

		//Direccion
		private string direccion;
		[StringLength(500)]
		public string Direccion { get => direccion; set => SetProperty(ref direccion, value); }

		//telefono1
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
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "InvalidEmail")]
		public string Email { get => email; set => SetProperty(ref email, value); }

		


	}
}
