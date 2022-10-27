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
        [Description("Farmacia Hospitalaria")]
        FH = 1,
        [Description("Farmacia Comunitaria")]
		F = 2,
        [Description("Radiofarmacia")]
        FR = 3,
        [Description("Agencia")]
        A = 4,
        [Description("Laboratorio Fabricante")]
        LF = 5,
        [Description("Laboratorio Acondiconador")]
        LA = 6,
        [Description("Droguería")]
        D = 7,
        [Description("Establecimiento No Farmacéutico")]
        ENF = 8,
        [Description("Máquina Expendedora de medicamentos de venta popular")]
        ENFM = 9,
        [Description("Botiquines de Pueblo")]
        B = 10,
        [Description("Elaborador de Cosméticos Artesanales")]
        ECA = 11,
	}

    public enum enumAUD_TipoActa //Tipo de Inspeccion
    {
        [Description("Ninguna")]
        None = 0,
        [Description("Apertura de Farmacia")]
        AF = 1,
        [Description("Cambio de ubicación de Farmacia")]
        CUF = 2,
        [Description("Apertura  de Agencia")]
        AA = 3,
        [Description("Cambio de Ubicación de Agencia")]
        CUA = 4,
        [Description("Rutina o Vigilancia de Farmacia")]
        VF = 5,
        [Description("Rutina o Vigilancia de Agencia")]
        VA = 6,
        [Description("Investigaciones")]
        INV = 7,
        [Description("Retención y Retiro de Productos")]
        RR = 8,
        [Description("Cierre de Operación")]
        COP = 9,
        [Description("Disposición Final de Productos")]
        DFP = 10,
        [Description("Apertura de Fabricantes - Medicamentos")]
        AFM = 11,
        [Description("Apertura Fabricantes – Cosméticos y Desinfectantes")]
        AFC = 12,
        [Description("Guía BPM – Fabricantes de Medicamentos")]
        BPMFM = 13,
        [Description("Guía BPM – Acondicionadores de Medicamentos")]
        BPMAM = 14,
        [Description("Guía BPM – Fabricantes Cosméticos y Desinfectantes")]
        BPMCD = 15,
        [Description("Guía BPM – Fabricantes de Naturales Medicinales")]
        BPMMN = 16,
        [Description("Guía de BPA")]
        BPA = 17,
        [Description("Apertura – Cosméticos Artesanales")]
        AECA = 18,
        [Description("Rutina o vigilancia de Establecimiento No Farmacéutico")]
        VENF = 19,
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

    

    public enum enum_StatusInspecciones
    {
        [Description("None")]
        None = -1,
        [Description("Pendiente")]
        Pending = 0,
        [Description("Reprogramar")]
        Reprograming = 1,
        [Description("Finalizado")]
        Completed = 2
    }

    public enum enum_InspRetiroRetencionType
    {
        [Description("Retención")]
        Withholding = 0,
        [Description("Retención y Retiro")]
        WithholdingWithdrawal = 1
    }

    //////////////////////////////
    ///

    public enum enumFMV_RAMType
    {
        [Description("No hay RAM")]
        NoRam = 0,
        [Description("Si hay RAM")]
        SiRam = 1,
        [Description("Estudio Clínico")]
        EstClinico = 2,
        [Description("Literatura")]
        Literatura = 3,
    }
    public enum enumFMV_RAMOrigenType
    {
        [Description("Alta Manual")]
        AltaManual = 0,
        [Description("Servicio Web")]
        ServicioWeb = 1,
        [Description("En Papel")]
        Papel = 2,
        [Description("Facedra")]
        Facedra = 3,
    }
}
