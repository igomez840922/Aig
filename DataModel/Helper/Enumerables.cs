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
		[Description("Apertura")]
        Apertura = 1,
		[Description("Cambio de Ubicación")]
        CambioUbicacion = 2,
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

    public enum enumAUD_TipoActa
    {
        [Description("Ninguna")]
        None = 0,
        [Description("Apertura y Cambio de Ubicación de Farmacias")]
        AperturaCambioUbicacionFarmacias = 1,
        [Description("Apertura y Cambio de Ubicación de Agencias Distribuidoras de Productos Farmacéuticos")]
        AperturaCambioUbicacionAgencias = 2,
        [Description("Inspección de Rutina o Vigilancia a Farmacias")]
        InspecRutinaFarmacias = 3,
        [Description("Inspección de Rutina o Vigilancia a Agencias Distribuidoras de Productos Farmacéuticos")]
        InspecRutinaAgencias = 4,
        [Description("Inspección o Investigación")]
        InspecInvestigacion = 5,
        [Description("Retención o Retiro de Productos del Mercado")]
        RetencionRetiroProductos = 6,
        [Description("Cierre de Operaciones de Establecimientos")]
        CierreOperaciones = 7,
        [Description("Disposición Final de Desechos Farmaceuticos")]
        DisposicionFinalDesechosFarma= 8,
        [Description("Evaluación Técnica por Apertura a Fabricante de Medicamentos")]
        EvaluacionTecnicaAperturaFabMedicamento = 9,
        [Description("Evaluación Técnica por Apertura a Fabricante de Cosméticos y Desinfectantes")]
        EvaluacionTecnicaAperturaFabDesinfectantes = 10,
        [Description("Evaluación Técnica por Apertura para la Elaboración de Cosméticos Artesanales")]
        EvaluacionTecnicaAperturaCosmeticArtesanales = 11,
    }
}
