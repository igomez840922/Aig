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
