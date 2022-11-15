using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class AUD_DatosAreaTransporte:SystemId
	{
		// TRANSPORTE
		// El transporte cuenta con controles y registro  de Temperatura y Humedad relativa
		private enumAUD_TipoSeleccion controlRegistroHumTemp;
		public enumAUD_TipoSeleccion ControlRegistroHumTemp { get => controlRegistroHumTemp; set => SetProperty(ref controlRegistroHumTemp, value); }

		// Observaciones
		private string controlRegistroHumTempDesc;
		[StringLength(500)]
		public string ControlRegistroHumTempDesc { get => controlRegistroHumTempDesc; set => SetProperty(ref controlRegistroHumTempDesc, value); }


		// El transporte mantiene los productos protegidos de la luz solar
		private enumAUD_TipoSeleccion proteccionLuzSolar;
		public enumAUD_TipoSeleccion ProteccionLuzSolar { get => proteccionLuzSolar; set => SetProperty(ref proteccionLuzSolar, value); }

		// Observaciones
		private string proteccionLuzSolarDesc;
		[StringLength(500)]
		public string ProteccionLuzSolarDesc { get => proteccionLuzSolarDesc; set => SetProperty(ref proteccionLuzSolarDesc, value); }


		// Los productos que requieren cadena de frío, se trasladan en vehículos o envases que permiten mantener la temperatura requerida
		private enumAUD_TipoSeleccion prodReqCadenaFrio;
		public enumAUD_TipoSeleccion ProdReqCadenaFrio { get => prodReqCadenaFrio; set => SetProperty(ref prodReqCadenaFrio, value); }

		// Observaciones
		private string prodReqCadenaFrioDesc;
		[StringLength(500)]
		public string ProdReqCadenaFrioDesc { get => prodReqCadenaFrioDesc; set => SetProperty(ref prodReqCadenaFrioDesc, value); }

		// En los camiones se colocan los productos sobre tarimas
		private enumAUD_TipoSeleccion camionesProdTarimas;
		public enumAUD_TipoSeleccion CamionesProdTarimas { get => camionesProdTarimas; set => SetProperty(ref camionesProdTarimas, value); }

		// Observaciones
		private string camionesProdTarimasDesc;
		[StringLength(500)]
		public string CamionesProdTarimasDesc { get => camionesProdTarimasDesc; set => SetProperty(ref camionesProdTarimasDesc, value); }

		
		// Los vehículos motorizados están identificados como transporte de medicamentos y otros productos para la salud humana
		private enumAUD_TipoSeleccion vehicIdentifTranspMed;
		public enumAUD_TipoSeleccion VehicIdentifTranspMed { get => vehicIdentifTranspMed; set => SetProperty(ref vehicIdentifTranspMed, value); }

		// Observaciones
		private string vehicIdentifTranspMedDesc;
		[StringLength(500)]
		public string VehicIdentifTranspMedDesc { get => vehicIdentifTranspMedDesc; set => SetProperty(ref vehicIdentifTranspMedDesc, value); }


		// Presenta formato de verificación de mantenimiento y condiciones del vehículo
		private enumAUD_TipoSeleccion formatVerifMantenimiento;
		public enumAUD_TipoSeleccion FormatVerifMantenimiento { get => formatVerifMantenimiento; set => SetProperty(ref formatVerifMantenimiento, value); }

		// Observacion
		private string formatVerifMantenimientoDesc;
		[StringLength(500)]
		public string FormatVerifMantenimientoDesc { get => formatVerifMantenimientoDesc; set => SetProperty(ref formatVerifMantenimientoDesc, value); }

		// En caso de tercerización del transporte presenta contrato con la empresa que brindará el servicio
		private enumAUD_TipoSeleccion tranTercerizacion;
		public enumAUD_TipoSeleccion TranTercerizacion { get => tranTercerizacion; set => SetProperty(ref tranTercerizacion, value); }

		// Observaciones
		private string tranTercerizacionDesc;
		[StringLength(500)]
		public string TranTercerizacionDesc { get => tranTercerizacionDesc; set => SetProperty(ref tranTercerizacionDesc, value); }


		// Existe transporte según la normativa sanitaria vigente para el traslado de los productos.
		private enumAUD_TipoSeleccion existeNormSanitariaVigente;
		public enumAUD_TipoSeleccion ExisteNormSanitariaVigente { get => existeNormSanitariaVigente; set => SetProperty(ref existeNormSanitariaVigente, value); }

		// Observaciones
		private string existeNormSanitariaVigenteDesc;
		[StringLength(500)]
		public string ExisteNormSanitariaVigenteDesc { get => existeNormSanitariaVigenteDesc; set => SetProperty(ref existeNormSanitariaVigenteDesc, value); }

	}
}
