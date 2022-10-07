using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Helper
{
	public enum enumAUD_TipoEstablecimiento
	{
		[Description("Ninguna")]
		None = 0,
		[Description("Farmacias")]
		Farmacias = 1,
		[Description("Agencias Distribuidoras")]
		AgenciasDistribuidoras = 2,
		[Description("Laboratorio Fabricante")]
		LaboratorioFabricante = 3,
		[Description("Laboratorio Acondicionador")]
		LaboratorioAcondicionador = 4,
		[Description("Droguería")]
		Drogueria = 5,
		[Description("Establecimiento No Farmacéuticos")]
		EstablecimientoNoFarmaceuticos = 6,
		[Description("Botiquín de Pueblo")]
		BotiquinPueblo = 7,
	}

	public enum enumAUD_ClasificacionTramite
	{
		[Description("Ninguna")]
		None = 0,
		[Description("Licencia de Operación")]
		LicOperacion = 1,
		[Description("Certificado de Buenas Prácticas")]
		CertBuenasPracticas = 2,
		[Description("Problemas Relacionados a Buenas Prácticas")]
		ProbRelacionadosBuenasPracticas = 3,
		[Description("Inscripción de Materia Prima")]
		InscMateriaPrima = 4,
		[Description("Carnet de Visitador Médico")]
		CarnetVisitadorMedico = 5,
		[Description("Disposición Final de Desechos Farmacéuticos")]
		DispFinalDesechosFarmaceuticos = 6,
	}

	public enum enumAUD_TipoTramite
	{
		[Description("Ninguna")]
		None = 0,
		[Description("Apertura")]
		Apertura = 1,
		[Description("Renovación")]
		Renovacion = 2,
		[Description("Modificación")]
		Modificacion = 3,
	}

	public enum enumAUD_TipoSector
	{
		[Description("Ninguna")]
		None = 0,
		[Description("Privado")]
		Privado = 1,
		[Description("Público")]
		Publico = 2
	}

	public enum enumAUD_StatusEstablecimiento
	{
		[Description("Inactivo")]
		Inactivo = 0,
		[Description("Operando")]
		Operando = 1,
		[Description("Cerrado")]
		Cerrado = 2,
	}

	public enum enumAUD_TipoInspeccion
	{
		[Description("Ninguna")]
		None = 0,
		[Description("Apertura / Cambio de Ubicación")]
		AperturaCambioUbicación = 1,
		[Description("Cerrado")]
		Cerrado = 2,
	}

	public enum enumAUD_TipoSeleccion
	{
		[Description("N/A")]
		NA = 0,
		[Description("Si")]
		Si = 1,
		[Description("No")]
		No = 2,
	}
}
