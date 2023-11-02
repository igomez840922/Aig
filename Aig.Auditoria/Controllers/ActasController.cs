using Aig.Auditoria.Pages.Inspections;
using Aig.Auditoria.Services;
using DataAccess;
using DataModel;
using DataModel.DTO;
using DataModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace Aig.Auditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActasController : ControllerBase
    {
        private readonly IDalService dalService;
        private readonly IPdfGenerationService pdfGenerationService;
        public ActasController(IDalService dalService,IPdfGenerationService pdfGenerationService)
        {
            this.dalService= dalService;
            this.pdfGenerationService = pdfGenerationService;
        }

        [HttpGet("GetTest")]
        [AllowAnonymous]
        public async Task<IActionResult> GetTest()
        {
            try
            {
                var data = dalService.First<AUD_InspeccionTB>();
                if (data != null)
                {
                    return Ok(data);
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
            return BadRequest(new { message = "data not found" });
        }


        [HttpGet("GetByNumber")]
        public async Task<IActionResult> GetByNumber(string number)
        {
            try {
                if (!string.IsNullOrEmpty(number))
                {
                    var data = dalService.Find<AUD_InspeccionTB>(x => x.NumActa == number);
                    if(data!=null)
                    {
                        return Ok(data);
                    }
                }
            }
            catch(Exception ex) { return BadRequest(new { message = ex.Message }); }
            return BadRequest(new { message = "data not found" });
        }


        [HttpGet("CheckByNumber")]
        public async Task<IActionResult> CheckByNumber(string number) {
            try {
                if (!string.IsNullOrEmpty(number)) {
                    var data = dalService.Find<AUD_InspeccionTB>(x => x.NumActa == number);
                    if (data != null) {
                        return Ok(new InspeccionModel() { Nombre=DataModel.Helper.Helper.GetDescription(data.TipoActa), NumeroActa = data.NumActa, 
                            DatosEstablecimiento = new DatosEstablecimiento() { 
                                AvisoOperaciones=data.DatosEstablecimiento?.AvisoOperaciones??"",
                                 NumLicencia = data.DatosEstablecimiento?.NumLicencia ?? "",
                                Nombre = data.DatosEstablecimiento?.Nombre ?? "",
                                 ReciboPago = data.DatosEstablecimiento?.ReciboPago ?? "",
                                 CorregimientoCodigo = data.DatosEstablecimiento?.Corregimiento?.Codigo ?? "",
                                CorregimientoNombre = data.DatosEstablecimiento?.Corregimiento?.Nombre ?? "",
                                DistritoCodigo = data.DatosEstablecimiento?.Distrito?.Codigo ?? "",
                                DistritoNombre = data.DatosEstablecimiento?.Distrito?.Nombre ?? "",
                                ProvinciaCodigo = data.DatosEstablecimiento?.Provincia?.Codigo ?? "",
                                ProvinciaNombre = data.DatosEstablecimiento?.Provincia?.Nombre ?? "",
                                Correo = data.DatosEstablecimiento?.Correo ?? "",
                                Direccion = data.DatosEstablecimiento?.Direccion ?? "",
                                Telefono = data.DatosEstablecimiento?.Telefono ?? "",
                            } 
                        });
                    }
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
            return BadRequest(new { message = "data not found" });
        }

        [HttpGet("GetFileByNumber")]
        public async Task<IActionResult> GetFileByNumber(string number) {
            try {
                if (!string.IsNullOrEmpty(number)) {
                    var data = dalService.Find<AUD_InspeccionTB>(x => x.NumActa == number);
                    if (data != null) {

                        var stream = await pdfGenerationService.GenerateInspectionPDF(data.Id);
                        return File(stream, "application/octet-stream", string.Format("{0}.pdf", DataModel.Helper.Helper.GetDescription(data.TipoActa)));

                    }
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
            return BadRequest(new { message = "datos no encontrados" });
        }

        //////////////////////////////////////////
        ///
        //Servicios para la App Offline

        [HttpPost("DownloadPending")]
        public async Task<IActionResult> DownloadPending([FromBody] APP_Updates lastUpdate)
        {
            try
            {
                var data = dalService.FindAll<AUD_InspeccionTB>(x => x.StatusInspecciones !=  DataModel.Helper.enum_StatusInspecciones.Completed && !x.Deleted && x.UpdatedDate >= lastUpdate.InspectionsUpdate);
                if (data?.Count > 0)
                {
                    return Ok(data);
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
            return BadRequest(new { message = "dato no encontrado" });
        }


        [HttpPost("UploadPending")]
        public async Task<IActionResult> UploadPending([FromBody] AUD_InspeccionTB inspeccion)
        {
            try
            {
                var data = dalService.Get<AUD_InspeccionTB>(inspeccion.Id);
                if (data!=null)
                {
                    if (inspeccion.DatosEstablecimiento?.PendingUpdate ?? false)
                    {
                        data.DatosEstablecimiento = inspeccion.DatosEstablecimiento;
                        data.DatosEstablecimiento.PendingUpdate = false;
                    }
                    if (inspeccion.ParticipantesDNFD?.PendingUpdate ?? false)
                    {
                        data.ParticipantesDNFD = inspeccion.ParticipantesDNFD;
                        data.ParticipantesDNFD.PendingUpdate = false;
                    }
                    if (inspeccion.DatosConclusiones?.PendingUpdate ?? false)
                    {
                        data.DatosConclusiones = inspeccion.DatosConclusiones;
                        data.DatosConclusiones.PendingUpdate = false;
                    }

                    ///// tipos de inspecciones
                    ///
                    switch (data.TipoActa)
                    {
                        case DataModel.Helper.enumAUD_TipoActa.AF:
                        case DataModel.Helper.enumAUD_TipoActa.CUF:
                            {
                                inspeccion.InspAperCambUbicFarm.PendingUpdate = false;
                                if (inspeccion.InspAperCambUbicFarm?.DatosSolicitante?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicFarm.DatosSolicitante = inspeccion.InspAperCambUbicFarm.DatosSolicitante;
                                    data.InspAperCambUbicFarm.DatosSolicitante.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicFarm?.DatosRegente?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicFarm.DatosRegente = inspeccion.InspAperCambUbicFarm.DatosRegente;
                                    data.InspAperCambUbicFarm.DatosRegente.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicFarm?.HorariosAtencion?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicFarm.HorariosAtencion = inspeccion.InspAperCambUbicFarm.HorariosAtencion;
                                    data.InspAperCambUbicFarm.HorariosAtencion.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicFarm?.DatosEstructuraOrganizacional?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicFarm.DatosEstructuraOrganizacional = inspeccion.InspAperCambUbicFarm.DatosEstructuraOrganizacional;
                                    data.InspAperCambUbicFarm.DatosEstructuraOrganizacional.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicFarm?.DatosInfraEstructura?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicFarm.DatosInfraEstructura = inspeccion.InspAperCambUbicFarm.DatosInfraEstructura;
                                    data.InspAperCambUbicFarm.DatosInfraEstructura.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicFarm?.DatosAreaFisica?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicFarm.DatosAreaFisica = inspeccion.InspAperCambUbicFarm.DatosAreaFisica;
                                    data.InspAperCambUbicFarm.DatosAreaFisica.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicFarm?.DatosPreguntasGenericas?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicFarm.DatosPreguntasGenericas = inspeccion.InspAperCambUbicFarm.DatosPreguntasGenericas;
                                    data.InspAperCambUbicFarm.DatosPreguntasGenericas.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicFarm?.DatosAreaProductosControlados?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicFarm.DatosAreaProductosControlados = inspeccion.InspAperCambUbicFarm.DatosAreaProductosControlados;
                                    data.InspAperCambUbicFarm.DatosAreaProductosControlados.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicFarm?.DatosAreaAlmacenamiento?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicFarm.DatosAreaAlmacenamiento = inspeccion.InspAperCambUbicFarm.DatosAreaAlmacenamiento;
                                    data.InspAperCambUbicFarm.DatosAreaAlmacenamiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicFarm?.DatosAreaAlmacenamientoAlcohol?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicFarm.DatosAreaAlmacenamientoAlcohol = inspeccion.InspAperCambUbicFarm.DatosAreaAlmacenamientoAlcohol;
                                    data.InspAperCambUbicFarm.DatosAreaAlmacenamientoAlcohol.PendingUpdate = false;
                                }
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.AA:
                        case DataModel.Helper.enumAUD_TipoActa.CUA:
                            {
                                inspeccion.InspAperCambUbicAgen.PendingUpdate = false;
                                if (inspeccion.InspAperCambUbicAgen?.DatosSolicitante?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.DatosSolicitante = inspeccion.InspAperCambUbicAgen.DatosSolicitante;
                                    data.InspAperCambUbicAgen.DatosSolicitante.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.DatosRegente?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.DatosRegente = inspeccion.InspAperCambUbicAgen.DatosRegente;
                                    data.InspAperCambUbicAgen.DatosRegente.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.CondCaractEstablecimiento?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.CondCaractEstablecimiento = inspeccion.InspAperCambUbicAgen.CondCaractEstablecimiento;
                                    data.InspAperCambUbicAgen.CondCaractEstablecimiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.AreaAdministrativa?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.AreaAdministrativa = inspeccion.InspAperCambUbicAgen.AreaAdministrativa;
                                    data.InspAperCambUbicAgen.AreaAdministrativa.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.AreaRecepcionProducto?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.AreaRecepcionProducto = inspeccion.InspAperCambUbicAgen.AreaRecepcionProducto;
                                    data.InspAperCambUbicAgen.AreaRecepcionProducto.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.AreaAlmacenamiento?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.AreaAlmacenamiento = inspeccion.InspAperCambUbicAgen.AreaAlmacenamiento;
                                    data.InspAperCambUbicAgen.AreaAlmacenamiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.AreaProductosDevueltosVencidos?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.AreaProductosDevueltosVencidos = inspeccion.InspAperCambUbicAgen.AreaProductosDevueltosVencidos;
                                    data.InspAperCambUbicAgen.AreaProductosDevueltosVencidos.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.AreaProductosRetiradosMercado?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.AreaProductosRetiradosMercado = inspeccion.InspAperCambUbicAgen.AreaProductosRetiradosMercado;
                                    data.InspAperCambUbicAgen.AreaProductosRetiradosMercado.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.AreaDespachoProductos?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.AreaDespachoProductos = inspeccion.InspAperCambUbicAgen.AreaDespachoProductos;
                                    data.InspAperCambUbicAgen.AreaDespachoProductos.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.AreaAlmacenProdReqCadenaFrio?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.AreaAlmacenProdReqCadenaFrio = inspeccion.InspAperCambUbicAgen.AreaAlmacenProdReqCadenaFrio;
                                    data.InspAperCambUbicAgen.AreaAlmacenProdReqCadenaFrio.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.AreaAlmacenProdVolatiles?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.AreaAlmacenProdVolatiles = inspeccion.InspAperCambUbicAgen.AreaAlmacenProdVolatiles;
                                    data.InspAperCambUbicAgen.AreaAlmacenProdVolatiles.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.AreaAlmacenPlaguicidas?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.AreaAlmacenPlaguicidas = inspeccion.InspAperCambUbicAgen.AreaAlmacenPlaguicidas;
                                    data.InspAperCambUbicAgen.AreaAlmacenPlaguicidas.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.AreaAlmacenMateriaPrima?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.AreaAlmacenMateriaPrima = inspeccion.InspAperCambUbicAgen.AreaAlmacenMateriaPrima;
                                    data.InspAperCambUbicAgen.AreaAlmacenMateriaPrima.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.AreaAlmacenProdSujetosControl?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.AreaAlmacenProdSujetosControl = inspeccion.InspAperCambUbicAgen.AreaAlmacenProdSujetosControl;
                                    data.InspAperCambUbicAgen.AreaAlmacenProdSujetosControl.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.AreaDesperdicio?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.AreaDesperdicio = inspeccion.InspAperCambUbicAgen.AreaDesperdicio;
                                    data.InspAperCambUbicAgen.AreaDesperdicio.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.Requisitos?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.Requisitos = inspeccion.InspAperCambUbicAgen.Requisitos;
                                    data.InspAperCambUbicAgen.Requisitos.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.Actividades?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.Actividades = inspeccion.InspAperCambUbicAgen.Actividades;
                                    data.InspAperCambUbicAgen.Actividades.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicAgen?.Productos?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicAgen.Productos = inspeccion.InspAperCambUbicAgen.Productos;
                                    data.InspAperCambUbicAgen.Productos.PendingUpdate = false;
                                }
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.VF:
                            {
                                inspeccion.InspRutinaVigFarmacia.PendingUpdate = false;
                                if (inspeccion.InspRutinaVigFarmacia?.DatosRepresentLegal?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigFarmacia.DatosRepresentLegal = inspeccion.InspRutinaVigFarmacia.DatosRepresentLegal;
                                    data.InspRutinaVigFarmacia.DatosRepresentLegal.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigFarmacia?.DatosRegente?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigFarmacia.DatosRegente = inspeccion.InspRutinaVigFarmacia.DatosRegente;
                                    data.InspRutinaVigFarmacia.DatosRegente.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigFarmacia?.DatosFarmaceutico?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigFarmacia.DatosFarmaceutico = inspeccion.InspRutinaVigFarmacia.DatosFarmaceutico;
                                    data.InspRutinaVigFarmacia.DatosFarmaceutico.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigFarmacia?.ExpPersonalFarmacia?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigFarmacia.ExpPersonalFarmacia = inspeccion.InspRutinaVigFarmacia.ExpPersonalFarmacia;
                                    data.InspRutinaVigFarmacia.ExpPersonalFarmacia.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigFarmacia?.EstructOrganizFarmacia?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigFarmacia.EstructOrganizFarmacia = inspeccion.InspRutinaVigFarmacia.EstructOrganizFarmacia;
                                    data.InspRutinaVigFarmacia.EstructOrganizFarmacia.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigFarmacia?.EstructFarmacia?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigFarmacia.EstructFarmacia = inspeccion.InspRutinaVigFarmacia.EstructFarmacia;
                                    data.InspRutinaVigFarmacia.EstructFarmacia.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigFarmacia?.AreaFisicaFarmacia?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigFarmacia.AreaFisicaFarmacia = inspeccion.InspRutinaVigFarmacia.AreaFisicaFarmacia;
                                    data.InspRutinaVigFarmacia.AreaFisicaFarmacia.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigFarmacia?.AreaProdControlados?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigFarmacia.AreaProdControlados = inspeccion.InspRutinaVigFarmacia.AreaProdControlados;
                                    data.InspRutinaVigFarmacia.AreaProdControlados.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigFarmacia?.RegMovimientoExistencia?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigFarmacia.RegMovimientoExistencia = inspeccion.InspRutinaVigFarmacia.RegMovimientoExistencia;
                                    data.InspRutinaVigFarmacia.RegMovimientoExistencia.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigFarmacia?.AreaAlmacenMedicamentos?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigFarmacia.AreaAlmacenMedicamentos = inspeccion.InspRutinaVigFarmacia.AreaAlmacenMedicamentos;
                                    data.InspRutinaVigFarmacia.AreaAlmacenMedicamentos.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigFarmacia?.DatosAreaAlmacenamientoAlcohol?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigFarmacia.DatosAreaAlmacenamientoAlcohol = inspeccion.InspRutinaVigFarmacia.DatosAreaAlmacenamientoAlcohol;
                                    data.InspRutinaVigFarmacia.DatosAreaAlmacenamientoAlcohol.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigFarmacia?.InventarioMedicamento?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigFarmacia.InventarioMedicamento = inspeccion.InspRutinaVigFarmacia.InventarioMedicamento;
                                    data.InspRutinaVigFarmacia.InventarioMedicamento.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigFarmacia?.RegMovimientoExistencia2?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigFarmacia.RegMovimientoExistencia2 = inspeccion.InspRutinaVigFarmacia.RegMovimientoExistencia2;
                                    data.InspRutinaVigFarmacia.RegMovimientoExistencia2.PendingUpdate = false;
                                }
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.VA:
                            {
                                inspeccion.InspRutinaVigAgencia.PendingUpdate = false;
                                if (inspeccion.InspRutinaVigAgencia?.DatosRepresentLegal?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.DatosRepresentLegal = inspeccion.InspRutinaVigAgencia.DatosRepresentLegal;
                                    data.InspRutinaVigAgencia.DatosRepresentLegal.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.DatosRegente?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.DatosRegente = inspeccion.InspRutinaVigAgencia.DatosRegente;
                                    data.InspRutinaVigAgencia.DatosRegente.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.CondCaractEstablecimiento?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.CondCaractEstablecimiento = inspeccion.InspRutinaVigAgencia.CondCaractEstablecimiento;
                                    data.InspRutinaVigAgencia.CondCaractEstablecimiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.AreaRecepcionProducto?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.AreaRecepcionProducto = inspeccion.InspRutinaVigAgencia.AreaRecepcionProducto;
                                    data.InspRutinaVigAgencia.AreaRecepcionProducto.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.AreaAlmacenamiento?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.AreaAlmacenamiento = inspeccion.InspRutinaVigAgencia.AreaAlmacenamiento;
                                    data.InspRutinaVigAgencia.AreaAlmacenamiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.AreaProductosDevueltosVencidos?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.AreaProductosDevueltosVencidos = inspeccion.InspRutinaVigAgencia.AreaProductosDevueltosVencidos;
                                    data.InspRutinaVigAgencia.AreaProductosDevueltosVencidos.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.AreaProductosRetiradosMercado?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.AreaProductosRetiradosMercado = inspeccion.InspRutinaVigAgencia.AreaProductosRetiradosMercado;
                                    data.InspRutinaVigAgencia.AreaProductosRetiradosMercado.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.AreaDespachoProductos?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.AreaDespachoProductos = inspeccion.InspRutinaVigAgencia.AreaDespachoProductos;
                                    data.InspRutinaVigAgencia.AreaDespachoProductos.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.AreaAlmacenProdReqCadenaFrio?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.AreaAlmacenProdReqCadenaFrio = inspeccion.InspRutinaVigAgencia.AreaAlmacenProdReqCadenaFrio;
                                    data.InspRutinaVigAgencia.AreaAlmacenProdReqCadenaFrio.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.AreaAlmacenProdVolatiles?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.AreaAlmacenProdVolatiles = inspeccion.InspRutinaVigAgencia.AreaAlmacenProdVolatiles;
                                    data.InspRutinaVigAgencia.AreaAlmacenProdVolatiles.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.AreaAlmacenPlaguicidas?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.AreaAlmacenPlaguicidas = inspeccion.InspRutinaVigAgencia.AreaAlmacenPlaguicidas;
                                    data.InspRutinaVigAgencia.AreaAlmacenPlaguicidas.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.AreaAlmacenMateriaPrima?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.AreaAlmacenMateriaPrima = inspeccion.InspRutinaVigAgencia.AreaAlmacenMateriaPrima;
                                    data.InspRutinaVigAgencia.AreaAlmacenMateriaPrima.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.AreaAlmacenProdSujetosControl?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.AreaAlmacenProdSujetosControl = inspeccion.InspRutinaVigAgencia.AreaAlmacenProdSujetosControl;
                                    data.InspRutinaVigAgencia.AreaAlmacenProdSujetosControl.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.Procedimientos?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.Procedimientos = inspeccion.InspRutinaVigAgencia.Procedimientos;
                                    data.InspRutinaVigAgencia.Procedimientos.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.Transporte?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.Transporte = inspeccion.InspRutinaVigAgencia.Transporte;
                                    data.InspRutinaVigAgencia.Transporte.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.Actividades?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.Actividades = inspeccion.InspRutinaVigAgencia.Actividades;
                                    data.InspRutinaVigAgencia.Actividades.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.Productos?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.Productos = inspeccion.InspRutinaVigAgencia.Productos;
                                    data.InspRutinaVigAgencia.Productos.PendingUpdate = false;
                                }
                                if (inspeccion.InspRutinaVigAgencia?.InventarioMedicamento?.PendingUpdate ?? false)
                                {
                                    data.InspRutinaVigAgencia.InventarioMedicamento = inspeccion.InspRutinaVigAgencia.InventarioMedicamento;
                                    data.InspRutinaVigAgencia.InventarioMedicamento.PendingUpdate = false;
                                }
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.INV:
                            {
                                inspeccion.InspInvestigacion.PendingUpdate = false;
                                if (inspeccion.InspInvestigacion?.DatosAtendidosPor?.PendingUpdate ?? false)
                                {
                                    data.InspInvestigacion.DatosAtendidosPor = inspeccion.InspInvestigacion.DatosAtendidosPor;
                                    data.InspInvestigacion.DatosAtendidosPor.PendingUpdate = false;
                                }
                                if (inspeccion.InspInvestigacion?.DetallesInvestigacion?.PendingUpdate ?? false)
                                {
                                    data.InspInvestigacion.DetallesInvestigacion = inspeccion.InspInvestigacion.DetallesInvestigacion;
                                    data.InspInvestigacion.DetallesInvestigacion.PendingUpdate = false;
                                }
                                
                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.RR:
                            {
                                inspeccion.InspRetiroRetencion.PendingUpdate = false;
                                if (inspeccion.InspRetiroRetencion?.DatosRepresentLegal?.PendingUpdate ?? false)
                                {
                                    data.InspRetiroRetencion.DatosRepresentLegal = inspeccion.InspRetiroRetencion.DatosRepresentLegal;
                                    data.InspRetiroRetencion.DatosRepresentLegal.PendingUpdate = false;
                                }
                                if (inspeccion.InspRetiroRetencion?.DatosAtendidosPor?.PendingUpdate ?? false)
                                {
                                    data.InspRetiroRetencion.DatosAtendidosPor = inspeccion.InspRetiroRetencion.DatosAtendidosPor;
                                    data.InspRetiroRetencion.DatosAtendidosPor.PendingUpdate = false;
                                }
                                if (inspeccion.InspRetiroRetencion?.DatosRetiroRetencion?.PendingUpdate ?? false)
                                {
                                    data.InspRetiroRetencion.DatosRetiroRetencion = inspeccion.InspRetiroRetencion.DatosRetiroRetencion;
                                    data.InspRetiroRetencion.DatosRetiroRetencion.PendingUpdate = false;
                                }

                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.COP:
                            {
                                inspeccion.InspCierreOperacion.PendingUpdate = false;
                                if (inspeccion.InspCierreOperacion?.DatosRepresentLegal?.PendingUpdate ?? false)
                                {
                                    data.InspCierreOperacion.DatosRepresentLegal = inspeccion.InspCierreOperacion.DatosRepresentLegal;
                                    data.InspCierreOperacion.DatosRepresentLegal.PendingUpdate = false;
                                }
                                if (inspeccion.InspCierreOperacion?.DatosInspeccion?.PendingUpdate ?? false)
                                {
                                    data.InspCierreOperacion.DatosInspeccion = inspeccion.InspCierreOperacion.DatosInspeccion;
                                    data.InspCierreOperacion.DatosInspeccion.PendingUpdate = false;
                                }

                                break;
                            }


                    }

                    data.PendingUpdate = false;

                    dalService.Save<AUD_InspeccionTB>(data);

                    return Ok(data);
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
            return BadRequest(new { message = "dato no encontrado" });
        }



        [HttpPost("DownloadPaises")]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadPaises([FromBody] APP_Updates lastUpdate)
        {
            try
            {
                var data = dalService.FindAll<PaisTB>(x => !x.Deleted && x.UpdatedDate >= lastUpdate.SettingsUpdate);
                if (data?.Count > 0)
                {
                    return Ok(data);
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
            return BadRequest(new { message = "dato no encontrado" });
        }

        [HttpPost("DownloadProvincias")]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadProvincias([FromBody] APP_Updates lastUpdate)
        {
            try
            {
                var data = dalService.FindAll<ProvinciaTB>(x => !x.Deleted && x.UpdatedDate >= lastUpdate.SettingsUpdate);
                if (data?.Count > 0)
                {
                    return Ok(data);
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
            return BadRequest(new { message = "dato no encontrado" });
        }

        [HttpPost("DownloadDistritos")]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadDistritos([FromBody] APP_Updates lastUpdate)
        {
            try
            {
                var data = dalService.FindAll<DistritoTB>(x => !x.Deleted && x.UpdatedDate >= lastUpdate.SettingsUpdate);
                if (data?.Count > 0)
                {
                    return Ok(data);
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
            return BadRequest(new { message = "dato no encontrado" });
        }

        [HttpPost("DownloadCorregimientos")]
        [AllowAnonymous]
        public async Task<IActionResult> DownloadCorregimientos([FromBody] APP_Updates lastUpdate)
        {
            try
            {
                var data = dalService.FindAll<CorregimientoTB>(x => !x.Deleted && x.UpdatedDate >= lastUpdate.SettingsUpdate);
                if (data?.Count > 0)
                {
                    return Ok(data);
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
            return BadRequest(new { message = "dato no encontrado" });
        }


    }
}
