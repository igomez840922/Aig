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
        [Description("Apertura de Agencia")]
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
        [Description("Apertura de Fabricantes – Cosméticos y Desinfectantes")]
        AFC = 12,
        [Description("Guía BPM – Fabricantes de Medicamentos")]
        BPMFM = 13,
        [Description("Guía BPM – Acondicionadores de Medicamentos")]
        BPMAM = 14,
        [Description("Guía BPM – Fabricantes de Cosméticos y Desinfectantes")]
        BPMCD = 15,
        [Description("Guía BPM – Fabricantes de Productos Naturales Medicinales")]
        BPMMN = 16,
        [Description("Guía de BPA")]
        BPA = 17,
        [Description("Apertura – Cosméticos Artesanales")]
        AECA = 18,
        //[Description("Rutina o vigilancia de Establecimiento No Farmacéutico")]
        //VENF = 19,
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

	//public enum enumAUD_TipoTramite
	//{
	//	[Description("Ninguna")]
	//	None = 0,
	//	[Description("Apertura")]
	//	Apertura = 1,
	//	[Description("Renovación")]
	//	Renovacion = 2,
	//	[Description("Modificación")]
	//	Modificacion = 3,
	//}

	public enum enumAUD_TipoSector
	{
		[Description("Ninguna")]
		None = 0,
		[Description("Privado")]
		Privado = 1,
		[Description("Estatal")]
        Estatal = 2,
    }

	public enum enumAUD_StatusEstablecimiento
	{
		[Description("Inactivo")]
		Inactivo = 0,
		[Description("Operando")]
		Operando = 1,
		[Description("Cerrado")]
		Cerrado = 2,
        [Description("Cierre Temporal")]
        CerradoTemp = 3,
        [Description("Cancelado")]
        Cancelado = 4,
        [Description("Vencido")]
        Vencido = 5, 
        [Description("Resolucion")]
        Resolucion = 6,
    }

    public enum enumAUD_ClasifEstablecimiento
    {
        [Description("N/A")]
        NA = 0,
        [Description("Apertura")]
        Apertura = 1,
        [Description("Renovación")]
        Renovacion = 2,
        [Description("Modificación")]
        Modificacion = 3,
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

    public enum enumAUD_TipoSolicitante
    {
        [Description("N/A")]
        NA = 0,
        [Description("Propietario")]
        Prop = 1,
        [Description("Representante Legal")]
        Rep = 2,
    }

    public enum enumAUD_TipoIluminacion
    {
        [Description("N/A")]
        NA = 0,
        [Description("Mala")]
        Mala = 1,
        [Description("Poca")]
        Poca = 2,
        [Description("Buena")]
        Buena = 3,
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
    /// <summary>
    /// 
    /// </summary>

    public enum enumFMV_StatusPMR
    {
        [Description("None")]
        None = -1,
        [Description("Pendiente")]
        Pending = 0,
        [Description("En Proceso")]
        InProcess = 1,
        [Description("Finalizado")]
        Completed = 2
    }

    //public enum enumFMV_AlertType
    //{
    //    [Description("Ninguna")]
    //    None = 0,
    //    [Description("Plan de Manejo de Riesgo")]
    //    PMR = 1,
    //    [Description("Informes Periódicos de Seguridad")]
    //    IPS = 2,
    //    [Description("RF")]
    //    RF = 3,
    //    [Description("Reacciones Adversas a Medicamentos")]
    //    RAM = 4,
    //}
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
        [Description("PAI")]
        Pai = 4,
    }
    public enum enumFMV_RAMNotificationType
    {
        [Description("No Reportado")]
        NOREP = 0,
        [Description("Médico")]
        MED = 1,
        [Description("Farmacéutico")]
        FAR = 2,
        [Description("Otro Profesional del la Salud")]
        OPS = 3,
        [Description("Paciente")]
        PAC = 4,
        [Description("Industria Farmacéutica")]
        INF = 5,
        [Description("Enfermera")]
        ENF = 6,
    }
    public enum enumFMV_RAMOrganizationType
    {
        [Description("No hay Información")]
        HHI = 0,
        [Description("CSS")]
        CSS = 1,
        [Description("MINSA")]
        MINSA = 2,
        [Description("Patronatos")]
        PAT = 3,
        [Description("Clínica Hospital Privado")]
        CHP = 4,
        [Description("Farmacia Privada")]
        FAP = 5,
        [Description("Industria Farmacéutica")]
        IFA = 6,
        [Description("No Aplica")]
        NA = 7,
    }

    public enum enumFMV_RAMStatus
    {
        [Description("Sin Evaluar")]
        SEVA = 0,
        [Description("Evaluada")]
        EVA = 1,
        [Description("Tramitada")]
        TRA = 2,
        [Description("Sin Tramitar")]
        STRA = 3,
    }

    public enum enumFMV_RAMDesenlace
    {
        [Description("N/A")]
        NA = 0,
        [Description("Desconocido")]
        DESC = 1,
        [Description("Recuperado con Secuelas")]
        RCSEC = 2,
        [Description("Recuperado sin Secuelas")]
        RSSEC = 3,
        [Description("En Recuperación")]
        REC = 4,
        [Description("No Recuperado")]
        NREC = 5,
        [Description("Muerte")]
        MUE = 6,
    }

    public enum enumFMV_RAMConductaDosis
    {
        [Description("N/A")]
        NA = 0,
        [Description("Disminuyó la dosis")]
        DISDOSIS = 1,
        [Description("No Disminuyó la dosis")]
        NODISDOSIS = 2,
    }

    public enum enumFMV_RAMEvolucionDosis
    {
        [Description("N/A")]
        NA = 0,
        [Description("Desapareció la reacción al disminuir la dosis")]
        DESREACC = 1,
        [Description("Permance la reacción al disminuir la dosis")]
        PERREACC = 2,
    }

    public enum enumFMV_RAMConductaTerapia
    {
        [Description("N/A")]
        NA = 0,
        [Description("Suspendió la terapia")]
        SUSTERAPIA = 1,
        [Description("Mantuvo la terapia")]
        MANTERAPIA = 2,
    }

    public enum enumFMV_RAMEvolucionTerapia
    {
        [Description("N/A")]
        NA = 0,
        [Description("Desapareció la reacción al suspender el uso del medicamento sospechoso")]
        DESREACC = 1,
        [Description("Permanece la reacción al suspender el uso del medicamento sospechoso")]
        PERREACC = 2,
    }

    public enum enumFMV_RAMConsecuenciaReexposicion
    {
        [Description("N/A")]
        NA = 0,
        [Description("Reapareció la reacción luego de reexposición")]
        REAP = 1,
        [Description("No Reaparece la reacción luego de reexposición")]
        NREAP = 2,
    }

    public enum enumFMV_RAMSecuenciaTemp
    {
        [Description("N/A")]
        NA = 0,
        [Description("Compatible")]
        COMP = 1,
        [Description("InCompatible")]
        INCOMP = 2,
        [Description("Compatible pero no Coherente")]
        COMPNOCOHE = 3,
        [Description("No hay Información")]
        NHI = 4,
        [Description("RAM aparecida por retirada del fármaco")]
        RAMAPAR = 5,
    }

    public enum enumFMV_RAMConocimientoPrev
    {
        [Description("N/A")]
        NA = 0,
        [Description("RAM bien conocida")]
        BIENCONOCIDA = 1,
        [Description("RAM conocida en referencias ocasionales")]
        CONOCIDAREF = 2,
        [Description("Desconocida")]
        DESCONOCIDA = 3,
        [Description("Existe información en contra de la relación fármaco-RAM")]
        EXISTEINFO = 4,
    }

    public enum enumFMV_RAMEfectoRetirada
    {
        [Description("N/A")]
        NA = 0,
        [Description("RAM mejora")]
        MEJORADA = 1,
        [Description("RAM no mejora")]
        NOMEJORADA = 2,
        [Description("No RETI y RAM no mejora")]
        NORETINOMEJORADA = 3,
        [Description("No RETI y RAM mejora")]
        NORETIMEJORADA = 4,
        [Description("No hay Información")]
        NOINFO = 5,
        [Description("RAM mortal o irreversible")]
        MORTALIRREV = 6,
        [Description("No RETI y RAM mejora por tolerancia")]
        NORETIMEJORTOLE = 7,
        [Description("No RETI y RAM mejora por tratamiento")]
        NORETIMEJORTRAT = 8,
    }

    public enum enumFMV_RAMEfectoReexposicion
    {
        [Description("N/A")]
        NA = 0,
        [Description("Reexposición positiva")]
        POSIT = 1,
        [Description("Reexposición negativa")]
        NEGAT = 2,
        [Description("No hay reexposición o información suficiente")]
        NOINFO = 3,
        [Description("RAM mortal o irreversible")]
        MORTAL = 4,
        [Description("Reacción previa similar con otras especialidades farmacéuticas con el mismo principio activo")]
        SIMILARESPECIAL = 5,
        [Description("Reacción previa similar con otro fármaco con mismo mecanismo de acción o reactividad cruzada\r\n")]
        SIMILARFARMACO = 6,
    }

    public enum enumFMV_RAMCausaAlternat
    {
        [Description("N/A")]
        NA = 0,
        [Description("Explicación alternativa más verosímil")]
        VEROSIMIL = 1,
        [Description("ALTER igual o menor")]
        IGUALMENOR = 2,
        [Description("No hay información")]
        NOINFO = 3,
        [Description("Se descarta")]
        DESCAR = 4,
    }

    public enum enumFMV_RAMFactContribuyente
    {
        [Description("N/A")]
        NA = 0,
        [Description("Factores que pueden haber contribuido a la presentación de la RAM")]
        SIFACT = 1,
        [Description("No hay factores contribuyentes")]
        NOFACT = 2,
    }

    public enum enumFMV_RAMExploracionContemp
    {
        [Description("N/A")]
        NA = 0,
        [Description("Existen exploraciones complementarias")]
        EXISTE = 1,
        [Description("No hay exploraciones complementarias")]
        NOEXISTE = 2,
    }

    public enum enumFMV_RAMIntensidad
    {
        [Description("N/A")]
        NA = 0,
        [Description("Ocasiona la muerte")]
        MUERTE = 1,
        [Description("Pueda poner en peligro la vida")]
        PELIGROVIDA = 2,
        [Description("Requiere o prolonga una hospitalización")]
        HOSPITALIZACION = 3,
        [Description("Produce una anomalía congénita o defecto al nacer")]
        ANOMALIACONGE = 4,
        [Description("Provoca una incapacidad persistente significativa")]
        INCAPSIG = 5,
        [Description("Enfermedad o síndrome médicamente significativo o importante")]
        SINDROMESIG = 6,
        [Description("Interfiere con las actividades habituales. Requieren intervención o tratamiento médico")]
        INTERFACT = 7,
        [Description("Fácilmente tolerado. No requieren terapia ni intervención médica")]
        TOLERADO = 8,
    }

    public enum enumFMV_FfTipoIncidenciaCaso
    {
        [Description("N/A")]
        NA = 0,
        [Description("Inicial")]
        INI = 1,
        [Description("Seguimiento")]
        SEG = 2,
    }

    public enum enumFMV_FfAcciones
    {
        [Description("N/A")]
        NA = 0,
        [Description("Pendiente")]
        PEND = 1,
        [Description("No Requerido")]
        NOREQ = 2,
        [Description("Realizado")]
        REAL = 3,
        [Description("Solicitado")]
        SOL = 4,
    }
    public enum enumFMV_FfResultControlCal
    {
        [Description("N/A")]
        NA = 0,
        [Description("En Espera")]
        ESP = 1,
        [Description("No Satisfactorio")]
        NOSAT = 2,
        [Description("Satisfactorio")]
        SAT = 3,
    }

    public enum enumFMV_FfRecomendAccRegulat
    {
        [Description("N/A")]
        NA = 0,
        [Description("No Requerido")]
        NOREQ = 1,
        [Description("Suspensión y retiro de lote(s)")]
        SUSPRETLOT = 2,
        [Description("Suspensión de Registro Sanitario")]
        SUSPREGSAN = 3,
    }

    public enum enumFMV_EsaviClasificacion
    {
        [Description("No hay ESAVI")]
        NA = 0,
        [Description("Si hay ESAVI")]
        SIESAVI = 1,
        [Description("Estudio Clínico")]
        ESTUDCLIN = 2,
        [Description("Literatura")]
        LITERAT = 3,
    }

    public enum enumFMV_EsaviSOC
    {
        [Description("N/A")]
        NA = 0,
        [Description("Embarazo, puerperio y enfermedades perinatales")]
        EMB = 1,
        [Description("Exploraciones complementarias")]
        EXPLCOM = 2,
        [Description("Infecciones e infestaciones")]
        INFECC = 3,
        [Description("Lesiones traumáticas, intoxicaciones y complicaciones de procedimientos terapéuticos")]
        LESIO = 4,
        [Description("Neoplasias benignas, malignas y no especificadas (incl quistes y pólipos)")]
        NEOPLA = 5,
        [Description("Problemas relativos a productos")]
        PRORELAT = 6,
        [Description("Procedimientos médicos y quirúrgicos")]
        PROCMEDQUI = 7,
        [Description("Trastornos cardíacos")]
        TRANSCARD = 8,
        [Description("Trastornos congénitos, familiares y genéticos")]
        TRANSCONG = 9,
        [Description("Trastornos de la piel y del tejido subcutáneo")]
        TRANSPIEL = 10,
        [Description("Trastornos de la sangre y del sistema linfático")]
        TRANSSANG = 11,
        [Description("Trastornos del aparato reproductor y de la mama")]
        TRANSREP = 12,
        [Description("Trastornos del metabolismo y de la nutrición")]
        TRANSMET = 13,
        [Description("Trastornos del oído y del laberinto")]
        TRANSOIDO = 14,
        [Description("Trastornos del sistema inmunológico")]
        TRANSINMU = 15,
        [Description("Trastornos del sistema nervioso")]
        TRANSSISNERV = 16,
        [Description("Trastornos endocrinos")]
        TRANSENDO = 17,
        [Description("Trastornos gastrointestinales")]
        TRANSGASTRO = 18,
        [Description("Trastornos generales y alteraciones en el lugar de administración")]
        TRANSGENERAL = 19,
        [Description("Trastornos hepatobiliares")]
        TRANSHEPATO = 20,
        [Description("Trastornos musculoesqueléticos y del tejido conjuntivo")]
        TRANSMUSC = 21,
        [Description("Trastornos oculares")]
        TRANSOCULA = 22,
        [Description("Trastornos psiquiátricos")]
        TRANSPSIQ = 23,
        [Description("Trastornos renales y urinarios")]
        TRANSRENA = 24,
        [Description("Trastornos respiratorios, torácicos y mediastínicos")]
        TRANSRESPI = 25,
    }

    public enum enumFMV_EsaviOtroCriterio
    {
        [Description("N/A")]
        NA = 0,
        [Description("Eventos nuevos o no descritos (inesperados)")]
        NUEVO = 1,
        [Description("Ocurrencia de eventos por encima de la tasa esperada o de gravedad inusual")]
        OCURRENCIA = 2,
        [Description("Clúster o conglomerados de casos")]
        CLUSTER = 3,
        [Description("Poblaciones vulnerables")]
        VULNERA = 4,
        [Description("Casos de interés especial")]
        ESPECIAL = 5,
    }
    public enum enumFMV_EsaviProbabilidadAsociacion
    {
        [Description("N/A")]
        NA = 0,
        [Description("Consistente con la vacuna")]
        VAC = 1,
        [Description("Consistente con un defecto de calidad de la vacuna")]
        DEFVAC = 2,
        [Description("Consistente con un error de inmunización")]
        ERRORINMU = 3,
        [Description("Consistente con reacción relacionada con la ansiedad")]
        REARELAANSI = 4,
        [Description("Indeterminado. La relación temporal es consistente pero no hay suficiente evidencia de que el evento causante es la vacuna")]
        INDETER1 = 5,
        [Description("Indeterminado. Los factores de calificación dan como resultado tendencias contradictorias de coherencia e inconsistencia con la asociación causal a la inmunización.")]
        INDETER2 = 6,
        [Description("Inconsistente")]
        INCONSIST = 7,
        [Description("Inclasificable")]
        INCLASIF = 8,
    }
    

    public enum enumSexo
    {
        [Description("N/A")]
        NA = 0,
        [Description("Masculino")]
        MAS = 1,
        [Description("Femenino")]
        FEM = 2,
    }

    public enum enumOpcionSiNo
    {
        [Description("N/A")]
        NA = 0,
        [Description("Si")]
        Si = 1,
        [Description("No")]
        No = 2,
        [Description("No Sabe")]
        NoSabe = 3,
    }

    public enum enumFMV_IpsPresentaCD
    {
        [Description("No Adjunta")]
        NoAdjunta = 0,
        [Description("Impresa")]
        Printed = 1,
        [Description("CD/USB")]
        CDUSB = 2,
    }
    public enum enumFMV_IpsStatusRecepcion
    {
        [Description("Pendiente")]
        Pending = 0,
        [Description("Aceptado")]
        Accepted = 1,
        [Description("Rechazado")]
        Rejected = 2,
    }

    //////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    public enum enumFMV_IpsStatusRegistro
    {
        [Description("Por Tramitar")]
        Pending = 0,
        [Description("Tramitado")]
        Processed = 1,
        [Description("Prioridad de Evaluación")]
        Evaluation = 2,
    }

    public enum enumFMV_IpsTipoPresentaiones
    {
        [Description("No Presentado")]
        NotPresent = 0,
        [Description("Presentado")]
        Presented = 1,
        [Description("Si")]
        Yes = 2,
        [Description("No")]
        No = 3,
    }

    public enum enumFMV_IpsStatusRevision
    {
        [Description("Por Evaluar")]
        Pending = 0,
        [Description("Evaluado")]
        Evaluated = 1,
    }

    public enum enumFMV_AlertType
    {
        //[Description("Alerta de Calidad")]
        //AlertaCalidad = 0,       
        //[Description("Nota Informativa")]
        //NotaInformativa = 2,
        [Description("Nota de Seguridad")]
        NotaSeguridad = 0,
        [Description("Boletines")]
        Boletines = 1,
        [Description("Comunicado")]
        Comunicado = 2,
    }

    public enum enumFMV_AlertaNotaStatus
    {
        [Description("Pendiente")]
        Pendiente = 0,
        [Description("Trabajada")]
        Trabajada = 1,
        [Description("Duplicada")]
        Duplicada = 2,
        [Description("Complementaria")]
        Complementaria = 3,
        [Description("N/A Nota de Seguridad")]
        NotaSeguridad = 4,
    }

    public enum enumFMV_NoteType
    {
        [Description("Interna")]
        Interna = 0,
        [Description("Externa")]
        Externa = 1,
        [Description("Hoja de Trámite")]
        HojaTramite = 2,
        [Description("Circular")]
        Circular = 3,
        [Description("Monitoreo")]
        Monitoreo = 4,
    }

    //////////////////////////////
    /// <summary>
    /// 
    /// </summary>

    public enum enum_UbicationType
    {
        [Description("Local")]
        Local = 0,
        [Description("Extranjero")]
        Foreign = 1,
    }

    public enum enum_LaboratoryType
    {
        [Description("Laboratorio")]
        Laboratory = 0,
        [Description("Distribuidora")]
        Distributor = 1,
    }

    //////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    public enum enum_TipoInspeccionDispFinal
    {
        [Description("Verificación del inventario")]
        VerifInventario = 0,
        [Description("Disposición Final")]
        DispFinal = 1,
    }

    public enum enum_TipoProductDispFinal
    {
        [Description("Controlado")]
        Controlado = 0,
        [Description("No Controlado")]
        NoControlado = 1,
    }
    public enum enum_TipoVerificacionDispFinal
    {
        [Description("N/A")]
        NA = 0,
        [Description("Total")]
        Total = 1,
        [Description("Parcial")]
        Parcial = 2,
    }

}
