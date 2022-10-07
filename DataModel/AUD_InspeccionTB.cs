using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
	public class AUD_InspeccionTB : SystemId
	{
		/// <summary>
		/// /////////Generalidades de la Farmacia y Solicitante
		/// </summary>

		//tipo de establecimiento
		private long? establecimientoId;
		public long? EstablecimientoId { get => establecimientoId; set => SetProperty(ref establecimientoId, value); }
		private AUD_EstablecimientoTB? establecimiento;
		public virtual AUD_EstablecimientoTB? Establecimiento { get => establecimiento; set => SetProperty(ref establecimiento, value); }

		//numero de acta ... debe ser Autogenerado Secuencial
		private int numActa;
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int NumActa { get => numActa; set => SetProperty(ref numActa, value); }

		//fecha y Hora de inicio del acta
		private DateTime fechaInicio;
		public DateTime FechaInicio { get => fechaInicio; set => SetProperty(ref fechaInicio, value); }
				
		//Tipo de Inspección
		private enumAUD_TipoInspeccion tipoInspeccion;
		public enumAUD_TipoInspeccion TipoInspeccion { get => tipoInspeccion; set => SetProperty(ref tipoInspeccion, value); }

		//codigo
		private string reciboPago;
		[StringLength(250)]
		public string ReciboPago { get => reciboPago; set => SetProperty(ref reciboPago, value); }

		//---- Estos los tenemos en la relación de establecimiento ---
		//Tipo de establecimiento
		//Nombre del Establecimiento 

		//Provincia
		private long? provinciaEstablecId;
		public long? ProvinciaEstablecId { get => provinciaEstablecId; set => SetProperty(ref provinciaEstablecId, value); }
		private ProvinciaTB? provinciaEstablec;
		public virtual ProvinciaTB? ProvinciaEstablec { get => provinciaEstablec; set => SetProperty(ref provinciaEstablec, value); }

		//distrito
		private long? distritoEstablecId;
		public long? DistritoEstablecId { get => distritoEstablecId; set => SetProperty(ref distritoEstablecId, value); }
		private DistritoTB? distritoEstablec;
		public virtual DistritoTB? DistritoEstablec { get => distritoEstablec; set => SetProperty(ref distritoEstablec, value); }

		//distrito
		private long? corregimientoEstablecId;
		public long? CorregimientoEstablecId { get => corregimientoEstablecId; set => SetProperty(ref corregimientoEstablecId, value); }
		private CorregimientoTB? corregimientoEstablec;
		public virtual CorregimientoTB? CorregimientoEstablec { get => corregimientoEstablec; set => SetProperty(ref corregimientoEstablec, value); }

		//ubicacion
		private string ubicacionEstablec;
		[StringLength(500)]
		public string UbicacionEstablec { get => ubicacionEstablec; set => SetProperty(ref ubicacionEstablec, value); }

		//telefono1
		private string telefonoEstablec;
		[StringLength(250)]
		public string TelefonoEstablec { get => telefonoEstablec; set => SetProperty(ref telefonoEstablec, value); }

		
		//Solicitante de Licencia
		private string nombreSolicitante;
		[StringLength(250)]
		public string NombreSolicitante { get => nombreSolicitante; set => SetProperty(ref nombreSolicitante, value); }

		//Solicitante de cedula
		private string cedulaSolicitante;
		[StringLength(250)]
		public string CedulaSolicitante { get => cedulaSolicitante; set => SetProperty(ref cedulaSolicitante, value); }

		//Nacionalidad
		private long? paisSolicitanteId;
		public long? PaisSolicitanteId { get => paisSolicitanteId; set => SetProperty(ref paisSolicitanteId, value); }
		private PaisTB? paisSolicitante;
		public virtual PaisTB? PaisSolicitante { get => paisSolicitante; set => SetProperty(ref paisSolicitante, value); }

		//Solicitante Telefono Oficina
		private string telefonoOficSolicitante;
		[StringLength(250)]
		public string TelefonoOficSolicitante { get => telefonoOficSolicitante; set => SetProperty(ref telefonoOficSolicitante, value); }

		//Solicitante Telefono Residencial
		private string telefonoRecidSolicitante;
		[StringLength(250)]
		public string TelefonoRecidSolicitante { get => telefonoRecidSolicitante; set => SetProperty(ref telefonoRecidSolicitante, value); }

		//Solicitante Telefono Movil
		private string telefonoMovilSolicitante;
		[StringLength(250)]
		public string TelefonoMovilSolicitante { get => telefonoMovilSolicitante; set => SetProperty(ref telefonoMovilSolicitante, value); }

		//correo electronico
		private string emailSolicitante;
		[StringLength(250)]
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "InvalidEmail")]
		public string EmailSolicitante { get => emailSolicitante; set => SetProperty(ref emailSolicitante, value); }

		//Solicitante Profesion
		private string profesionSolicitante;
		[StringLength(250)]
		public string ProfesionSolicitante { get => profesionSolicitante; set => SetProperty(ref profesionSolicitante, value); }

		/// <summary>
		/// Datos del Regente Farmacéutico de la Empresa
		/// </summary>
		/// 

		//Solicitante de Licencia
		private string nombreRegente;
		[StringLength(250)]
		public string NombreRegente { get => nombreRegente; set => SetProperty(ref nombreRegente, value); }

		//Numero de Registro de Identidad
		private string numregistroIdoneidad;
		[StringLength(250)]
		public string NumregistroIdoneidad { get => numregistroIdoneidad; set => SetProperty(ref numregistroIdoneidad, value); }

		//Solicitante de cedula ..... Al colocar el número de cédula debe validarse con el Web Service del Tribunal Electoral que se encuentra en el bus de integración de la AIG. Se debe alimentar de la solicitud de Licencia.
		private string cedulaRegente;
		[StringLength(250)]
		public string CedulaRegente { get => cedulaRegente; set => SetProperty(ref cedulaRegente, value); }

		//Provincia
		private long? provinciaRegentecId;
		public long? ProvinciaRegentecId { get => provinciaRegentecId; set => SetProperty(ref provinciaRegentecId, value); }
		private ProvinciaTB? provinciaRegente;
		public virtual ProvinciaTB? ProvinciaRegente { get => provinciaRegente; set => SetProperty(ref provinciaRegente, value); }

		//distrito
		private long? distritoRegenteId;
		public long? DistritoRegenteId { get => distritoRegenteId; set => SetProperty(ref distritoRegenteId, value); }
		private DistritoTB? distritoRegente;
		public virtual DistritoTB? DistritoRegente { get => distritoRegente; set => SetProperty(ref distritoRegente, value); }

		//distrito
		private long? corregimientoRegenteId;
		public long? CorregimientoRegenteId { get => corregimientoRegenteId; set => SetProperty(ref corregimientoRegenteId, value); }
		private CorregimientoTB? corregimientoRegente;
		public virtual CorregimientoTB? CorregimientoRegente { get => corregimientoRegente; set => SetProperty(ref corregimientoRegente, value); }

		//ubicacion
		private string ubicacionRegente;
		[StringLength(500)]
		public string UbicacionRegente { get => ubicacionRegente; set => SetProperty(ref ubicacionRegente, value); }

		//Regente Telefono Oficina
		private string telefonoOficRegente;
		[StringLength(250)]
		public string TelefonoOficRegente { get => telefonoOficRegente; set => SetProperty(ref telefonoOficRegente, value); }

		//Regente Telefono Residencial
		private string telefonoRecidRegente;
		[StringLength(250)]
		public string TelefonoRecidRegente { get => telefonoRecidRegente; set => SetProperty(ref telefonoRecidRegente, value); }

		//Regente Telefono Movil
		private string telefonoMovilRegente;
		[StringLength(250)]
		public string TelefonoMovilRegente { get => telefonoMovilRegente; set => SetProperty(ref telefonoMovilRegente, value); }

		//Regente correo electronico
		private string emailRegente;
		[StringLength(250)]
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "InvalidEmail")]
		public string EmailRegente { get => emailRegente; set => SetProperty(ref emailRegente, value); }

		//El establecimiento se compromete al fiel cumplimiento del Artículo 386 del Decreto Ejecutivo 115 De 16 de agosto de 2022? Firma de Regente Farmacéutico
		private string firmaRegente;
		public string FirmaRegente { get => firmaRegente; set => SetProperty(ref firmaRegente, value); }

		/// <summary>
		/// Estructura Organizacional de la Farmacia (Si/No)
		/// </summary>
		/// 

		//Dispone de su letrero de Identificación
		private bool letreroIdentificacion;
		public bool LetreroIdentificacion { get => letreroIdentificacion; set => SetProperty(ref letreroIdentificacion, value); }

		//El horario de Operación coincide con lo señalado en la solicitud de licencia de operación
		private bool horarioOpeIgualSolic;
		public bool HorarioOpeIgualSolic { get => horarioOpeIgualSolic; set => SetProperty(ref horarioOpeIgualSolic, value); }

		//El establecimiento utilizará plataformas tecnológicas para la comercialización de medicamentos de venta sin prescripción médica y otros productos para la salud humana
		private bool utilizaPlatafComercial;
		public bool UtilizaPlatafComercial { get => utilizaPlatafComercial; set => SetProperty(ref utilizaPlatafComercial, value); }

		
		//Horario de atención
		private string horarioAtencion;
		public string HorarioAtencion { get => horarioAtencion; set => SetProperty(ref horarioAtencion, value); }

		/// <summary>
		/// Infraestructura de la Farmacia
		/// </summary>
		/// 

		//Escribir el tipo de paredes y el estado en el que está
		private string tipoParedes;
		public string TipoParedes { get => tipoParedes; set => SetProperty(ref tipoParedes, value); }

		//Escribir el tipo de cielo raso y el estado en el que está
		private string tipoCieloRaso;
		public string TipoCieloRaso { get => tipoCieloRaso; set => SetProperty(ref tipoCieloRaso, value); }

		//Escribir el tipo de pisos y el estado en el que está.
		private string tipoPiso;
		public string TipoPiso { get => tipoPiso; set => SetProperty(ref tipoCieloRaso, value); }

		//El ambiente externo del establecimiento presenta un riesgo mínimo de cualquier contaminación
		private bool riesgoExterno;
		public bool RiesgoExterno { get => riesgoExterno; set => SetProperty(ref riesgoExterno, value); }

		// Debe dar breve explicación del por qué.
		private string riesgoExternoDescrip;
		public string RiesgoExternoDescrip { get => riesgoExternoDescrip; set => SetProperty(ref riesgoExternoDescrip, value); }

		/// <summary>
		/// Área Física de la Farmacia (Si/No)
		/// </summary>
		/// 

		//Debe seleccionar Si o No, dependiendo de su debido cumplimiento y describir estado del mismo.
		private bool presentaIluminacion;
		public bool PresentaIluminacion { get => presentaIluminacion; set => SetProperty(ref presentaIluminacion, value); }

		// Debe dar breve explicación del por qué.
		private string presentaIluminacionDescrip;
		public string PresentaIluminacionDescrip { get => presentaIluminacionDescrip; set => SetProperty(ref presentaIluminacionDescrip, value); }

		//Tipo y estado de mobiliario para medicamentos
		private bool mobiliarioMedicamentos;
		public bool MobiliarioMedicamentos { get => mobiliarioMedicamentos; set => SetProperty(ref mobiliarioMedicamentos, value); }

		// Debe dar breve explicación del por qué.
		private string mobiliarioMedicamentosDescrip;
		public string MobiliarioMedicamentosDescrip { get => mobiliarioMedicamentosDescrip; set => SetProperty(ref mobiliarioMedicamentosDescrip, value); }

		//Muebles separados de las paredes, pisos, y techos
		private bool mueblesSeparadosPared;
		public bool MueblesSeparadosPared { get => mueblesSeparadosPared; set => SetProperty(ref mueblesSeparadosPared, value); }

		/// <summary>
		/// PREGUNTAS (SI/NO)
		/// </summary>
		/// 

		//Anuncio visible y legible frente al recetario con la instrucción del Art. 151 de la Ley 1 de 10 de enero de 2001
		private bool anuncioVisibleLeyArt151;
		public bool AnuncioVisibleLeyArt151 { get => anuncioVisibleLeyArt151; set => SetProperty(ref anuncioVisibleLeyArt151, value); }


		//Anuncio visible y legible de Tabla de Promedio y Precio Mínimo Unitario de la Canasta básica de Medicamentos (De Referencia y Genéricos), según monitoreo de precios realizado en las principales farmacias. Resolución No. 774 de lunes 7 de octubre de 2019. "Por medio de la cual se amplía la Canasta Básica de Medicamentos (CABAMED) DE 40 A 153 Productos Farmacéuticos":
		private bool anuncioVisibleTablaPromPrecio;
		public bool AnuncioVisibleTablaPromPrecio { get => anuncioVisibleTablaPromPrecio; set => SetProperty(ref anuncioVisibleTablaPromPrecio, value); }

		//Anuncio visible y legible de Art. 1 y Art. 2 de Ley 17 de 12 de septiembre de 2014. “Que adiciona disposiciones a la Ley 1 de 2001, sobre medicamentos y otros productos para la salud humana, para prohibir la venta o cobro de bebidas alcohólicas en los establecimientos farmacéuticos”.
		private bool anuncioVisibleLeyArt1;
		public bool AnuncioVisibleLeyArt1 { get => anuncioVisibleLeyArt1; set => SetProperty(ref anuncioVisibleLeyArt1, value); }

		//Farmacia Privada: Anuncio visible y legible Art. 655 y Art. 656 del Decreto Ejecutivo 115 de 16 de agosto de 2022.
		private bool anuncioVisibleLeyArt665;
		public bool AnuncioVisibleLeyArt665 { get => anuncioVisibleLeyArt665; set => SetProperty(ref anuncioVisibleLeyArt665, value); }

		//Higrótermometro y formato de registro de temperatura y humedad relativa. El registro y control de los parámetros debe ser como mínimo dos veces al día de preferencia en horas de la mañana y mediodía.
		private bool registroTempHumedadRelat;
		public bool RegistroTempHumedadRelat { get => registroTempHumedadRelat; set => SetProperty(ref registroTempHumedadRelat, value); }

		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string registroTempHumedadRelatDescrip;
		public string RegistroTempHumedadRelatDescrip { get => mobiliarioMedicamentosDescrip; set => SetProperty(ref mobiliarioMedicamentosDescrip, value); }

		//Cuenta con programa de calibración de equipos como equipo para la medición de temperatura y humedad relativa.
		private bool programaCalibracion;
		public bool ProgramaCalibracion { get => programaCalibracion; set => SetProperty(ref programaCalibracion, value); }

		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string programaCalibracionDescrip;
		public string ProgramaCalibracionDescrip { get => programaCalibracionDescrip; set => SetProperty(ref programaCalibracionDescrip, value); }

		//El espacio físico es de un mínimo de 20 metros cuadrados. Esto incluye la ubicación de los medicamentos y otros productos para la salud humana, el área de consulta farmacéutica, el área de asesoría bibliográfica, el área administrativa del farmacéutico. Que permita adecuada y cómodamente las labores al personal. No incluye el área de Almacén de Medicamentos y Otros Productos para la Salud Humana.
		private bool espacioFisicoMin20;
		public bool EspacioFisicoMin20 { get => espacioFisicoMin20; set => SetProperty(ref espacioFisicoMin20, value); }

		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string espacioFisicoMin20Descrip;
		public string EspacioFisicoMin20Descrip { get => espacioFisicoMin20Descrip; set => SetProperty(ref espacioFisicoMin20Descrip, value); }

		//Área de gestión administrativa del farmacéutico indentificada.
		private bool areaGestionAdmin;
		public bool AreaGestionAdmin { get => areaGestionAdmin; set => SetProperty(ref areaGestionAdmin, value); }

		//Área separada para la alimentación del personal
		private bool areaSeparadaAlimentPersonal;
		public bool AreaSeparadaAlimentPersonal { get => areaSeparadaAlimentPersonal; set => SetProperty(ref areaSeparadaAlimentPersonal, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaSeparadaAlimentPersonalDescrip;
		public string AreaSeparadaAlimentPersonalDescrip { get => areaSeparadaAlimentPersonalDescrip; set => SetProperty(ref areaSeparadaAlimentPersonalDescrip, value); }

		//Sanitario para el personal. En caso de que la farmacia esté ubicada en locales comerciales o similares y el mismo posea baños comunes (para compartir entre los locales comerciales). Será permitido siempre y cuando el personal de la farmacia mantenga los debidos cuidados de higiene.
		private bool sanitarioPersonal;
		public bool SanitarioPersonal { get => sanitarioPersonal; set => SetProperty(ref sanitarioPersonal, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string sanitarioPersonalDescrip;
		public string SanitarioPersonalDescrip { get => sanitarioPersonalDescrip; set => SetProperty(ref sanitarioPersonalDescrip, value); }

		//Aire acondicionado para mantener las condiciones de almacenamiento
		private bool aireAcondicionadoCondAliment;
		public bool AireAcondicionadoCondAliment { get => aireAcondicionadoCondAliment; set => SetProperty(ref aireAcondicionadoCondAliment, value); }

		//Extintores contra incendios(vigentes y aprobados por el cuerpo de Bomberos)
		private bool extintoresIncendio;
		public bool ExtintoresIncendio { get => extintoresIncendio; set => SetProperty(ref extintoresIncendio, value); }

		//Alarmas contra incendio  o detector de humo
		private bool alarmaIntrusoIncendio;
		public bool AlarmaIntrusoIncendio { get => alarmaIntrusoIncendio; set => SetProperty(ref alarmaIntrusoIncendio, value); }

		//Luces de Emergencia
		private bool lucesEmergencias;
		public bool LucesEmergencias { get => lucesEmergencias; set => SetProperty(ref lucesEmergencias, value); }

		/// <summary>
		/// SEñALIZACIONES DE AVISOS
		/// </summary>
		/// 

		//salidas Emergencia
		private bool salidasEmergencia;
		public bool SalidasEmergencia { get => salidasEmergencia; set => SetProperty(ref salidasEmergencia, value); }

		//no Comer en Instalacion
		private bool noComerInstalac;
		public bool NoComerInstalac { get => noComerInstalac; set => SetProperty(ref noComerInstalac, value); }

		//no Beber en Instalacion
		private bool noBeberInstalac;
		public bool NoBeberInstalac { get => noBeberInstalac; set => SetProperty(ref noBeberInstalac, value); }

		//no Fumar en Instalacion
		private bool noFumarInstalac;
		public bool NoFumarInstalac { get => noFumarInstalac; set => SetProperty(ref noFumarInstalac, value); }

		//no guardar plantas en Instalacion
		private bool noPlantasInstalac;
		public bool NoPlantasInstalac { get => noPlantasInstalac; set => SetProperty(ref noPlantasInstalac, value); }

		//Existe un sistema para el control de fauna nociva (Cebadera y certificado de fumigación).
		private bool existeSistemaControlFauna;
		public bool ExisteSistemaControlFauna { get => existeSistemaControlFauna; set => SetProperty(ref existeSistemaControlFauna, value); }

		//Área de Asesoría Farmacéutica delimitada e identificada que permita la interacción privada entre farmacéutico y paciente.
		private bool areaAsesoriaFarmaceutica;
		public bool AreaAsesoriaFarmaceutica { get => areaAsesoriaFarmaceutica; set => SetProperty(ref areaAsesoriaFarmaceutica, value); }

		//Área de consultas bibliográficas
		private bool areaConsultasBibliograficas;
		public bool AreaConsultasBibliograficas { get => areaConsultasBibliograficas; set => SetProperty(ref areaConsultasBibliograficas, value); }


		//Área delimitada, segregada e identificada de productos vencidos (devolución)
		private bool areaProductosVencidos;
		public bool AreaProductosVencidos { get => areaProductosVencidos; set => SetProperty(ref areaProductosVencidos, value); }

		//Refrigeradora para productos que requiere condiciones especiales de temperatura
		private bool refrigeradoraProductosEspeciales;
		public bool RefrigeradoraProductosEspeciales { get => refrigeradoraProductosEspeciales; set => SetProperty(ref refrigeradoraProductosEspeciales, value); }

		//Termómetro para el refrigerador y formato de registro de temperatura 
		private bool termometroRefrigeradora;
		public bool TermometroRefrigeradora { get => termometroRefrigeradora; set => SetProperty(ref termometroRefrigeradora, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string termometroRefrigeradoraDescrip;
		public string TermometroRefrigeradoraDescrip { get => termometroRefrigeradoraDescrip; set => SetProperty(ref termometroRefrigeradoraDescrip, value); }

		//Termómetro para el refrigerador y formato de registro de temperatura 
		private bool farmaciaRelaDirectaClinica;
		public bool FarmaciaRelaDirectaClinica { get => farmaciaRelaDirectaClinica; set => SetProperty(ref farmaciaRelaDirectaClinica, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string farmaciaRelaDirectaClinicaDescrip;
		public string FarmaciaRelaDirectaClinicaDescrip { get => farmaciaRelaDirectaClinicaDescrip; set => SetProperty(ref farmaciaRelaDirectaClinicaDescrip, value); }

		/// <summary>
		/// Área de Productos Controlados (Cuando Aplique)
		/// </summary>
		/// 

		//El área se encuentra identificada
		private enumAUD_TipoSeleccion areaProductosIdentificada;
		public enumAUD_TipoSeleccion AreaProductosIdentificada { get => areaProductosIdentificada; set => SetProperty(ref areaProductosIdentificada, value); }
		//Debe desplegar un área de texto para las observaciones.
		private string areaProductosIdentificadaDesc;
		public string AreaProductosIdentificadaDesc { get => areaProductosIdentificadaDesc; set => SetProperty(ref areaProductosIdentificadaDesc, value); }

		//El área se encuentra asegurada(llave y/o candado)
		private enumAUD_TipoSeleccion areaProductosAsegurada;
		public enumAUD_TipoSeleccion AreaProductosAsegurada { get => areaProductosAsegurada; set => SetProperty(ref areaProductosAsegurada, value); }
		//Debe desplegar un área de texto para las observaciones.
		private string areaProductosAseguradaDesc;
		public string AreaProductosAseguradaDesc { get => areaProductosAseguradaDesc; set => SetProperty(ref areaProductosAseguradaDesc, value); }

		//El área se encuentra independiente de otras áreas
		private enumAUD_TipoSeleccion areaProductosIndependiente;
		public enumAUD_TipoSeleccion AreaProductosIndependiente { get => areaProductosIndependiente; set => SetProperty(ref areaProductosIndependiente, value); }
		//Debe desplegar un área de texto para las observaciones.
		private string areaProductosIndependienteDesc;
		public string AreaProductosIndependienteDesc { get => areaProductosIndependienteDesc; set => SetProperty(ref areaProductosIndependienteDesc, value); }

		//El área se encuentra delimitada
		private enumAUD_TipoSeleccion areaProductosDelimitada;
		public enumAUD_TipoSeleccion AreaProductosDelimitada { get => areaProductosDelimitada; set => SetProperty(ref areaProductosDelimitada, value); }
		//Debe desplegar un área de texto para las observaciones.
		private string areaProductosDelimitadaDesc;
		public string AreaProductosDelimitadaDesc { get => areaProductosDelimitadaDesc; set => SetProperty(ref areaProductosDelimitadaDesc, value); }

		//El área posee una ubicación  identificada para productos vencidos
		private enumAUD_TipoSeleccion areaProductosIdentProdVencido;
		public enumAUD_TipoSeleccion AreaProductosIdentProdVencido { get => areaProductosIdentProdVencido; set => SetProperty(ref areaProductosIdentProdVencido, value); }
		//Debe desplegar un área de texto para las observaciones.
		private string areaProductosIdentProdVencidoDesc;
		public string AreaProductosIdentProdVencidoDesc { get => areaProductosIdentProdVencidoDesc; set => SetProperty(ref areaProductosIdentProdVencidoDesc, value); }

		//El área se encuentra con iluminación y ventilación
		private enumAUD_TipoSeleccion areaProductosIluminaVentila;
		public enumAUD_TipoSeleccion AreaProductosIluminaVentila { get => areaProductosIluminaVentila; set => SetProperty(ref areaProductosIluminaVentila, value); }
		//Debe desplegar un área de texto para las observaciones.
		private string areaProductosIluminaVentilaDesc;
		public string AreaProductosIluminaVentilaDesc { get => areaProductosIluminaVentilaDesc; set => SetProperty(ref areaProductosIluminaVentilaDesc, value); }

		//Describa el lugar donde se almacenan y las medidas de seguridad
		private string lugarAlmacenMedidasSegDesc;
		public string LugarAlmacenMedidasSegDesc { get => lugarAlmacenMedidasSegDesc; set => SetProperty(ref lugarAlmacenMedidasSegDesc, value); }

		//Medidas aproximadas 
		private decimal areaProductosLargo;
		public decimal AreaProductosLargo { get => areaProductosLargo; set => SetProperty(ref areaProductosLargo, value); }
		private decimal areaProductosAncho;
		public decimal AreaProductosAncho { get => areaProductosAncho; set => SetProperty(ref areaProductosAncho, value); }
		private decimal areaProductosAltura;
		public decimal AreaProductosAltura { get => areaProductosAltura; set => SetProperty(ref areaProductosAltura, value); }

		/// <summary>
		/// Área de Almacenamiento de Medicamentos y otros  Productos para la Salud Humana (Depósito) / (Cuando Aplique)
		/// </summary>
		/// 

		//Está identificada y delimitada
		private enumAUD_TipoSeleccion areaAlmacenIdentificada;
		public enumAUD_TipoSeleccion AreaAlmacenIdentificada { get => areaAlmacenIdentificada; set => SetProperty(ref areaAlmacenIdentificada, value); }
		//Describa el lugar donde se almacenan y las medidas de seguridad
		private string areaAlmacenIdentificadaDesc;
		public string AreaAlmacenIdentificadaDesc { get => areaAlmacenIdentificadaDesc; set => SetProperty(ref areaAlmacenIdentificadaDesc, value); }

		//Está identificada y delimitada
		private enumAUD_TipoSeleccion areaAlmacenEspacioFisicoAdecuado;
		public enumAUD_TipoSeleccion AreaAlmacenEspacioFisicoAdecuado { get => areaAlmacenEspacioFisicoAdecuado; set => SetProperty(ref areaAlmacenEspacioFisicoAdecuado, value); }
		//Describa el lugar donde se almacenan y las medidas de seguridad
		private string areaAlmacenEspacioFisicoAdecuadoDesc;
		public string AreaAlmacenEspacioFisicoAdecuadoDesc { get => areaAlmacenEspacioFisicoAdecuadoDesc; set => SetProperty(ref areaAlmacenEspacioFisicoAdecuadoDesc, value); }
		
		//Higrótermometro y formato de registro de temperatura y humedad relativa. El registro y control de los parámetros debe ser como mínimo dos veces al día de preferencia en horas de la mañana y mediodía.
		private enumAUD_TipoSeleccion areaAlmacenTempHumedadRelat;
		public enumAUD_TipoSeleccion AreaAlmacenTempHumedadRelat { get => areaAlmacenTempHumedadRelat; set => SetProperty(ref areaAlmacenTempHumedadRelat, value); }

		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenTempHumedadRelatDescrip;
		public string AreaAlmacenTempHumedadRelatDescrip { get => areaAlmacenTempHumedadRelatDescrip; set => SetProperty(ref areaAlmacenTempHumedadRelatDescrip, value); }

		//Medidas aproximadas 
		private decimal areaAlmacenLargo;
		public decimal AreaAlmacenLargo { get => areaAlmacenLargo; set => SetProperty(ref areaAlmacenLargo, value); }
		private decimal areaAlmacenAncho;
		public decimal AreaAlmacenAncho { get => areaAlmacenAncho; set => SetProperty(ref areaAlmacenAncho, value); }
		private decimal areaAlmacenAltura;
		public decimal AreaAlmacenAltura { get => areaAlmacenAltura; set => SetProperty(ref areaAlmacenAltura, value); }

		//Limpio y ordenado
		private enumAUD_TipoSeleccion areaAlmacenLimpioOrdenado;
		public enumAUD_TipoSeleccion AreaAlmacenLimpioOrdenado { get => areaAlmacenLimpioOrdenado; set => SetProperty(ref areaAlmacenLimpioOrdenado, value); }

		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenLimpioOrdenadoDescrip;
		public string AreaAlmacenLimpioOrdenadoDescrip { get => areaAlmacenLimpioOrdenadoDescrip; set => SetProperty(ref areaAlmacenLimpioOrdenadoDescrip, value); }

		//Iluminación 
		private enumAUD_TipoSeleccion areaAlmacenIluminacion;
		public enumAUD_TipoSeleccion AreaAlmacenIluminacion { get => areaAlmacenIluminacion; set => SetProperty(ref areaAlmacenIluminacion, value); }

		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenIluminacionDescrip;
		public string AreaAlmacenIluminacionDescrip { get => areaAlmacenIluminacionDescrip; set => SetProperty(ref areaAlmacenIluminacionDescrip, value); }

		//Los productos farmacéuticos se almacenan sobre anaqueles, racks, tarimas o pallets 
		private enumAUD_TipoSeleccion areaAlmacenProdSobreAnaqueles;
		public enumAUD_TipoSeleccion AreaAlmacenProdSobreAnaqueles { get => areaAlmacenProdSobreAnaqueles; set => SetProperty(ref areaAlmacenProdSobreAnaqueles, value); }
		
		private enumAUD_TipoSeleccion areaAlmacenProdSobreRacks;
		public enumAUD_TipoSeleccion AreaAlmacenProdSobreRacks { get => areaAlmacenProdSobreRacks; set => SetProperty(ref areaAlmacenProdSobreRacks, value); }

		private enumAUD_TipoSeleccion areaAlmacenProdSobreTarimas;
		public enumAUD_TipoSeleccion AreaAlmacenProdSobreTarimas { get => areaAlmacenProdSobreTarimas; set => SetProperty(ref areaAlmacenProdSobreTarimas, value); }
		
		private enumAUD_TipoSeleccion areaAlmacenProdSobrePalets;
		public enumAUD_TipoSeleccion AreaAlmacenProdSobrePalets { get => areaAlmacenProdSobrePalets; set => SetProperty(ref areaAlmacenProdSobrePalets, value); }
		
		private enumAUD_TipoSeleccion areaAlmacenProdSobreOtros;
		public enumAUD_TipoSeleccion AreaAlmacenProdSobreOtros { get => areaAlmacenProdSobreOtros; set => SetProperty(ref areaAlmacenProdSobreOtros, value); }

		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenProdSobreDescrip;
		public string AreaAlmacenProdSobreDescrip { get => areaAlmacenProdSobreDescrip; set => SetProperty(ref areaAlmacenProdSobreDescrip, value); }

		//Las condiciones de paredes, piso y techo deben ser adecuadas para evitar posible contaminación de los medicamentos.
		private enumAUD_TipoSeleccion areaAlmacenCondParedesPisoTecho;
		public enumAUD_TipoSeleccion AreaAlmacenCondParedesPisoTecho { get => areaAlmacenCondParedesPisoTecho; set => SetProperty(ref areaAlmacenCondParedesPisoTecho, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenCondParedesPisoTechoDescrip;
		public string AreaAlmacenCondParedesPisoTechoDescrip { get => areaAlmacenCondParedesPisoTechoDescrip; set => SetProperty(ref areaAlmacenCondParedesPisoTechoDescrip, value); }

		//Área de cuarentena identificada, delimitada y asegurada bajo llave
		private enumAUD_TipoSeleccion areaAlmacenCuarentenaIdentDeli;
		public enumAUD_TipoSeleccion AreaAlmacenCuarentenaIdentDeli { get => areaAlmacenCuarentenaIdentDeli; set => SetProperty(ref areaAlmacenCuarentenaIdentDeli, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenCuarentenaIdentDeliDescrip;
		public string AreaAlmacenCuarentenaIdentDeliDescrip { get => areaAlmacenCuarentenaIdentDeliDescrip; set => SetProperty(ref areaAlmacenCuarentenaIdentDeliDescrip, value); }

		//Cuenta con cortina de aire a la entrada del almacén para evitar posible contaminación de los medicamentos (cuando aplique).
		private enumAUD_TipoSeleccion areaAlmacenCortinaAire;
		public enumAUD_TipoSeleccion AreaAlmacenCortinaAire { get => areaAlmacenCortinaAire; set => SetProperty(ref areaAlmacenCortinaAire, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenCortinaAireDescrip;
		public string AreaAlmacenCortinaAireDescrip { get => areaAlmacenCortinaAireDescrip; set => SetProperty(ref areaAlmacenCortinaAireDescrip, value); }

		//Extintores contra incendios (vigentes y aprobados por el Cuerpo de Bomberos).
		private enumAUD_TipoSeleccion areaAlmacenExtintoresIncendio;
		public enumAUD_TipoSeleccion AreaAlmacenExtintoresIncendio { get => areaAlmacenExtintoresIncendio; set => SetProperty(ref areaAlmacenExtintoresIncendio, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenExtintoresIncendioDescrip;
		public string AreaAlmacenExtintoresIncendioDescrip { get => areaAlmacenExtintoresIncendioDescrip; set => SetProperty(ref areaAlmacenExtintoresIncendioDescrip, value); }

		//Alarmas contra incendios o detector de humo.
		private enumAUD_TipoSeleccion areaAlmacenAlarmaIncendio;
		public enumAUD_TipoSeleccion AreaAlmacenAlarmaIncendio { get => areaAlmacenAlarmaIncendio; set => SetProperty(ref areaAlmacenAlarmaIncendio, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenAlarmaIncendioDescrip;
		public string AreaAlmacenAlarmaIncendioDescrip { get => areaAlmacenAlarmaIncendioDescrip; set => SetProperty(ref areaAlmacenAlarmaIncendioDescrip, value); }


		//Luces de emergencia..
		private enumAUD_TipoSeleccion areaAlmacenLucesEmergencias;
		public enumAUD_TipoSeleccion AreaAlmacenLucesEmergencias { get => areaAlmacenLucesEmergencias; set => SetProperty(ref areaAlmacenLucesEmergencias, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenLucesEmergenciasDescrip;
		public string AreaAlmacenLucesEmergenciasDescrip { get => areaAlmacenLucesEmergenciasDescrip; set => SetProperty(ref areaAlmacenLucesEmergenciasDescrip, value); }

		//Existe un sistema para el control de fauna nociva (Cebadera y certificado de fumigación).
		private enumAUD_TipoSeleccion areaAlmacenControlFaunaNociva;
		public enumAUD_TipoSeleccion AreaAlmacenControlFaunaNociva { get => areaAlmacenControlFaunaNociva; set => SetProperty(ref areaAlmacenControlFaunaNociva, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenControlFaunaNocivaDescrip;
		public string AreaAlmacenControlFaunaNocivaDescrip { get => areaAlmacenControlFaunaNocivaDescrip; set => SetProperty(ref areaAlmacenControlFaunaNocivaDescrip, value); }

		//Área de cuarentena identificada, delimitada y asegurada.
		private enumAUD_TipoSeleccion areaAlmacenAreaCuarentena;
		public enumAUD_TipoSeleccion AreaAlmacenAreaCuarentena { get => areaAlmacenAreaCuarentena; set => SetProperty(ref areaAlmacenAreaCuarentena, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenAreaCuarentenaDescrip;
		public string AreaAlmacenAreaCuarentenaDescrip { get => areaAlmacenAreaCuarentenaDescrip; set => SetProperty(ref areaAlmacenAreaCuarentenaDescrip, value); }

		//Área de productos controlados, delimitada y asegurada bajo llave.
		private enumAUD_TipoSeleccion areaAlmacenAreaProdControlados;
		public enumAUD_TipoSeleccion AreaAlmacenAreaProdControlados { get => areaAlmacenAreaProdControlados; set => SetProperty(ref areaAlmacenAreaProdControlados, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenAreaProdControladosDescrip;
		public string AreaAlmacenAreaProdControladosDescrip { get => areaAlmacenAreaProdControladosDescrip; set => SetProperty(ref areaAlmacenAreaProdControladosDescrip, value); }

		//Área de productos controlados, delimitada y asegurada bajo llave.
		private enumAUD_TipoSeleccion areaAlmacenAreaAlmacenAlcohol;
		public enumAUD_TipoSeleccion AreaAlmacenAreaAlmacenAlcohol { get => areaAlmacenAreaAlmacenAlcohol; set => SetProperty(ref areaAlmacenAreaAlmacenAlcohol, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenAreaAlmacenAlcoholDescrip;
		public string AreaAlmacenAreaAlmacenAlcoholDescrip { get => areaAlmacenAreaAlmacenAlcoholDescrip; set => SetProperty(ref areaAlmacenAreaAlmacenAlcoholDescrip, value); }


		//Área de almacenamiento de un alto inventario o volumen de Alcohol o productos inflamables el cual cuenta con extintores, detectores de humo o alarma contra incendio, lámpara de emergencia en el área y kit de emergencia para el manejo de derrames de sustancias peligrosas o corrosivas.
		private enumAUD_TipoSeleccion areaAlmacenAltoNivelInventario;
		public enumAUD_TipoSeleccion AreaAlmacenAltoNivelInventario { get => areaAlmacenAltoNivelInventario; set => SetProperty(ref areaAlmacenAltoNivelInventario, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenAltoNivelInventarioDescrip;
		public string AreaAlmacenAltoNivelInventarioDescrip { get => areaAlmacenAltoNivelInventarioDescrip; set => SetProperty(ref areaAlmacenAltoNivelInventarioDescrip, value); }


		//Área de vencidos o deteriorados separada e identificada. Asegurada bajo llave.
		private enumAUD_TipoSeleccion areaAlmacenVencidos;
		public enumAUD_TipoSeleccion AreaAlmacenVencidos { get => areaAlmacenVencidos; set => SetProperty(ref areaAlmacenVencidos, value); }
		// Debe mostrar las opciones Sí/No.  Debe desplegar un área de texto para las observaciones.
		private string areaAlmacenVencidosDescrip;
		public string AreaAlmacenVencidosDescrip { get => areaAlmacenVencidosDescrip; set => SetProperty(ref areaAlmacenVencidosDescrip, value); }

		// El establecimiento se compromete al fiel cumplimiento del Artículo 639 del Decreto Ejecutivo 115 De 16 de agosto de 2022. Firma de Regente Farmacéutico:
		//private string firmaRegente;
		//public string firmaRegente { get => areaAlmacenVencidosDescrip; set => SetProperty(ref areaAlmacenVencidosDescrip, value); }

		/// <summary>
		/// Conclusión de Inspección
		/// </summary>
		/// 

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
		public string NombreInspector4 { get => nombreInspector3; set => SetProperty(ref nombreInspector3, value); }

		//Inspector 4 registro
		private string registroInspector4;
		[StringLength(250)]
		public string RegistroInspector4 { get => registroInspector3; set => SetProperty(ref registroInspector3, value); }

		//Inspector 4 cargo
		private string cargoInspector4;
		[StringLength(250)]
		public string CargoInspector4 { get => cargoInspector3; set => SetProperty(ref cargoInspector3, value); }

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
		public string FirmaRepresentanteLegal { get => firmaRepresentanteLegal; set => SetProperty(ref registroRepresentanteLegal, value); }

		//fecha y Hora de finalizacion
		private DateTime fechaFinalizacion;
		public DateTime FechaFinalizacion { get => fechaFinalizacion; set => SetProperty(ref fechaFinalizacion, value); }

	}
}
