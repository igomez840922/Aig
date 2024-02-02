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
        private readonly IWebHostEnvironment env;
        private readonly IDalService dalService;
        private readonly IPdfGenerationService pdfGenerationService;
        private readonly IInspectionsService inspectionsService;
        //
        public ActasController(IDalService dalService,IPdfGenerationService pdfGenerationService, 
            IWebHostEnvironment env, IInspectionsService inspectionsService)
        {
            this.dalService= dalService;
            this.pdfGenerationService = pdfGenerationService;
            this.env = env;
            this.inspectionsService= inspectionsService;
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
            catch (Exception ex) { return BadRequest(new ApiResponse { Result = false, Message = ex.Message }); }
            return BadRequest(new ApiResponse { Result = false, Message = "dato no encontrado" });
        }


        [HttpPost("UploadPending")]
        public async Task<IActionResult> UploadPending([FromBody] AUD_InspeccionTB inspeccion)
        {
            try
            {
                if(inspeccion.EstablecimientoId == 0)
                {
                    inspeccion.Establecimiento = dalService.Find<AUD_EstablecimientoTB>(x=>x.NumLicencia == inspeccion.DatosEstablecimiento.NumLicencia);
                    inspeccion.Establecimiento = inspeccion.Establecimiento != null? inspeccion.Establecimiento : dalService.First<AUD_EstablecimientoTB>();
                    inspeccion.EstablecimientoId = inspeccion.Establecimiento?.Id;
                    inspeccion.DatosEstablecimiento.Establecimiento = inspeccion.Establecimiento;
                    inspeccion.DatosEstablecimiento.EstablecimientoId = inspeccion.EstablecimientoId;

                    inspeccion.DatosEstablecimiento.Direccion = !string.IsNullOrEmpty(inspeccion.Establecimiento.Ubicacion)? inspeccion.Establecimiento.Ubicacion: inspeccion.DatosEstablecimiento.Direccion;
                    inspeccion.DatosEstablecimiento.Telefono = !string.IsNullOrEmpty(inspeccion.Establecimiento.Telefono1) ? inspeccion.Establecimiento.Telefono1: inspeccion.DatosEstablecimiento.Telefono;
                    inspeccion.DatosEstablecimiento.Correo = !string.IsNullOrEmpty(inspeccion.Establecimiento.Email) ? inspeccion.Establecimiento.Email: inspeccion.DatosEstablecimiento.Correo;
                    inspeccion.DatosEstablecimiento.Nombre = !string.IsNullOrEmpty(inspeccion.Establecimiento.Nombre) ? inspeccion.Establecimiento.Nombre: inspeccion.DatosEstablecimiento.Nombre;
                    inspeccion.DatosEstablecimiento.NumLicencia = !string.IsNullOrEmpty(inspeccion.Establecimiento.NumLicencia) ? inspeccion.Establecimiento.NumLicencia: inspeccion.DatosEstablecimiento.NumLicencia;
                    inspeccion.DatosEstablecimiento.AvisoOperaciones = !string.IsNullOrEmpty(inspeccion.Establecimiento.AvisoOperaciones) ? inspeccion.Establecimiento.AvisoOperaciones: inspeccion.DatosEstablecimiento.AvisoOperaciones;
                    inspeccion.DatosEstablecimiento.Provincia = inspeccion.Establecimiento.Provincia!=null? inspeccion.Establecimiento.Provincia: inspeccion.DatosEstablecimiento.Provincia;
                    inspeccion.DatosEstablecimiento.ProvinciaId = inspeccion.Establecimiento.Provincia != null ? inspeccion.Establecimiento.Provincia.Id: inspeccion.DatosEstablecimiento.ProvinciaId;
                    inspeccion.DatosEstablecimiento.Distrito = inspeccion.Establecimiento.Distrito!=null? inspeccion.Establecimiento.Distrito: inspeccion.DatosEstablecimiento.Distrito;
                    inspeccion.DatosEstablecimiento.Corregimiento = inspeccion.Establecimiento.Corregimiento!=null? inspeccion.Establecimiento.Corregimiento: inspeccion.DatosEstablecimiento.Corregimiento;
                    inspeccion.DatosEstablecimiento.ReciboPago = !string.IsNullOrEmpty(inspeccion.Establecimiento.ReciboPago) ? inspeccion.Establecimiento.ReciboPago: inspeccion.DatosEstablecimiento.ReciboPago;

                    inspeccion.DatosEstablecimiento.PendingUpdate = true;
                    inspeccion.NumActa = inspectionsService.GetInspectNum(inspeccion);
                    inspeccion = dalService.Save<AUD_InspeccionTB>(inspeccion);                    
                }

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
                        //Inspeccion.Inspeccion.DatosConclusiones.LAttachments
                        if (inspeccion.DatosConclusiones?.LAttachments?.Count > 0)
                        {
                            foreach(var attach in inspeccion.DatosConclusiones.LAttachments)
                            {
                                try 
                                {
                                    if (!string.IsNullOrEmpty(attach.Base64) && string.IsNullOrEmpty(attach.Url))
                                    {
                                        var fileBytes = Helper.Helper.ReturnByteArrayFromBase64(attach.Base64);
                                        if(fileBytes?.Length > 0)
                                        {
                                            var dir = Path.Combine(env.WebRootPath, "files");//Path.GetRandomFileName()
                                            if (!Directory.Exists(dir))
                                            {
                                                Directory.CreateDirectory(dir);
                                            }

                                            var fileName = string.Format("{0}.{1}", Guid.NewGuid().ToString(), attach.FileName.Split(".").LastOrDefault());
                                            var path = System.IO.Path.Combine(dir, fileName);

                                            System.IO.File.WriteAllBytes(path, fileBytes);

                                            attach.AbsolutePath = path;
                                            attach.Url = string.Format("./files/{0}", fileName);
                                            attach.FileName = fileName;
                                            //attach.Base64 = null;                                           
                                        }
                                    }
                                }
                                catch (Exception ex) { }
                            }
                        }

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
                        case DataModel.Helper.enumAUD_TipoActa.DFP:
                            {
                                inspeccion.InspDisposicionFinal.PendingUpdate = false;
                                if (inspeccion.InspDisposicionFinal?.DatosAtendidosPor?.PendingUpdate ?? false)
                                {
                                    data.InspDisposicionFinal.DatosAtendidosPor = inspeccion.InspDisposicionFinal.DatosAtendidosPor;
                                    data.InspDisposicionFinal.DatosAtendidosPor.PendingUpdate = false;
                                }
                                if (inspeccion.InspDisposicionFinal?.DatosInspeccion?.PendingUpdate ?? false)
                                {
                                    data.InspDisposicionFinal.DatosInspeccion = inspeccion.InspDisposicionFinal.DatosInspeccion;
                                    data.InspDisposicionFinal.DatosInspeccion.PendingUpdate = false;
                                }
                                if (inspeccion.InspDisposicionFinal?.InventarioMedicamento?.PendingUpdate ?? false)
                                {
                                    data.InspDisposicionFinal.InventarioMedicamento = inspeccion.InspDisposicionFinal.InventarioMedicamento;
                                    data.InspDisposicionFinal.InventarioMedicamento.PendingUpdate = false;
                                }

                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.AFM:
                            {
                                inspeccion.InspAperFabricante.PendingUpdate = false;
                                if (inspeccion.InspAperFabricante?.DatosRepresentLegal?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricante.DatosRepresentLegal = inspeccion.InspAperFabricante.DatosRepresentLegal;
                                    data.InspAperFabricante.DatosRepresentLegal.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricante?.DatosRegente?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricante.DatosRegente = inspeccion.InspAperFabricante.DatosRegente;
                                    data.InspAperFabricante.DatosRegente.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricante?.ProdFabrican?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricante.ProdFabrican = inspeccion.InspAperFabricante.ProdFabrican;
                                    data.InspAperFabricante.ProdFabrican.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricante?.Personal?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricante.Personal = inspeccion.InspAperFabricante.Personal;
                                    data.InspAperFabricante.Personal.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricante?.Instalaciones?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricante.Instalaciones = inspeccion.InspAperFabricante.Instalaciones;
                                    data.InspAperFabricante.Instalaciones.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricante?.AreaAlmacenamiento?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricante.AreaAlmacenamiento = inspeccion.InspAperFabricante.AreaAlmacenamiento;
                                    data.InspAperFabricante.AreaAlmacenamiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricante?.AreaDispMateriaPrima?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricante.AreaDispMateriaPrima = inspeccion.InspAperFabricante.AreaDispMateriaPrima;
                                    data.InspAperFabricante.AreaDispMateriaPrima.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricante?.AreaProduccion?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricante.AreaProduccion = inspeccion.InspAperFabricante.AreaProduccion;
                                    data.InspAperFabricante.AreaProduccion.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricante?.AreaAcondSecundario?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricante.AreaAcondSecundario = inspeccion.InspAperFabricante.AreaAcondSecundario;
                                    data.InspAperFabricante.AreaAcondSecundario.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricante?.ControlCalidad?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricante.ControlCalidad = inspeccion.InspAperFabricante.ControlCalidad;
                                    data.InspAperFabricante.ControlCalidad.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricante?.AreaAuxiliares?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricante.AreaAuxiliares = inspeccion.InspAperFabricante.AreaAuxiliares;
                                    data.InspAperFabricante.AreaAuxiliares.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricante?.Equipos?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricante.Equipos = inspeccion.InspAperFabricante.Equipos;
                                    data.InspAperFabricante.Equipos.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricante?.MaterialesProductos?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricante.MaterialesProductos = inspeccion.InspAperFabricante.MaterialesProductos;
                                    data.InspAperFabricante.MaterialesProductos.PendingUpdate = false;
                                }

                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.AFC:
                            {
                                inspeccion.InspAperFabricanteCosmetMed.PendingUpdate = false;
                                if (inspeccion.InspAperFabricanteCosmetMed?.DatosRepresentLegal?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.DatosRepresentLegal = inspeccion.InspAperFabricanteCosmetMed.DatosRepresentLegal;
                                    data.InspAperFabricanteCosmetMed.DatosRepresentLegal.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.DatosRegente?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.DatosRegente = inspeccion.InspAperFabricanteCosmetMed.DatosRegente;
                                    data.InspAperFabricanteCosmetMed.DatosRegente.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.ProdFabrican?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.ProdFabrican = inspeccion.InspAperFabricanteCosmetMed.ProdFabrican;
                                    data.InspAperFabricanteCosmetMed.ProdFabrican.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.EstructuraOrganizativa?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.EstructuraOrganizativa = inspeccion.InspAperFabricanteCosmetMed.EstructuraOrganizativa;
                                    data.InspAperFabricanteCosmetMed.EstructuraOrganizativa.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.Almacenes?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.Almacenes = inspeccion.InspAperFabricanteCosmetMed.Almacenes;
                                    data.InspAperFabricanteCosmetMed.Almacenes.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.Almacenes2?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.Almacenes2 = inspeccion.InspAperFabricanteCosmetMed.Almacenes2;
                                    data.InspAperFabricanteCosmetMed.Almacenes2.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.Documantacion?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.Documantacion = inspeccion.InspAperFabricanteCosmetMed.Documantacion;
                                    data.InspAperFabricanteCosmetMed.Documantacion.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.AreasAuxiliares?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.AreasAuxiliares = inspeccion.InspAperFabricanteCosmetMed.AreasAuxiliares;
                                    data.InspAperFabricanteCosmetMed.AreasAuxiliares.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.SistemaCriticoApoyo?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.SistemaCriticoApoyo = inspeccion.InspAperFabricanteCosmetMed.SistemaCriticoApoyo;
                                    data.InspAperFabricanteCosmetMed.SistemaCriticoApoyo.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.SistemaCriticoApoyo?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.SistemaCriticoApoyo = inspeccion.InspAperFabricanteCosmetMed.SistemaCriticoApoyo;
                                    data.InspAperFabricanteCosmetMed.SistemaCriticoApoyo.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.AreaProduccion?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.AreaProduccion = inspeccion.InspAperFabricanteCosmetMed.AreaProduccion;
                                    data.InspAperFabricanteCosmetMed.AreaProduccion.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.Acondicionamiento?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.Acondicionamiento = inspeccion.InspAperFabricanteCosmetMed.Acondicionamiento;
                                    data.InspAperFabricanteCosmetMed.Acondicionamiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.Acondicionamiento?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.Acondicionamiento = inspeccion.InspAperFabricanteCosmetMed.Acondicionamiento;
                                    data.InspAperFabricanteCosmetMed.Acondicionamiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.ControlCalidad?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.ControlCalidad = inspeccion.InspAperFabricanteCosmetMed.ControlCalidad;
                                    data.InspAperFabricanteCosmetMed.ControlCalidad.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperFabricanteCosmetMed?.InspeccionAuditoria?.PendingUpdate ?? false)
                                {
                                    data.InspAperFabricanteCosmetMed.InspeccionAuditoria = inspeccion.InspAperFabricanteCosmetMed.InspeccionAuditoria;
                                    data.InspAperFabricanteCosmetMed.InspeccionAuditoria.PendingUpdate = false;
                                }


                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.BPMFM:
                            {
                                inspeccion.InspGuiaBPMFabricanteMed.PendingUpdate = false;
                                if (inspeccion.InspGuiaBPMFabricanteMed?.DatosRepresentLegal?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.DatosRepresentLegal = inspeccion.InspGuiaBPMFabricanteMed.DatosRepresentLegal;
                                    data.InspGuiaBPMFabricanteMed.DatosRepresentLegal.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.DatosRegente?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.DatosRegente = inspeccion.InspGuiaBPMFabricanteMed.DatosRegente;
                                    data.InspGuiaBPMFabricanteMed.DatosRegente.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.OtrosFuncionarios?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.OtrosFuncionarios = inspeccion.InspGuiaBPMFabricanteMed.OtrosFuncionarios;
                                    data.InspGuiaBPMFabricanteMed.OtrosFuncionarios.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.RequisitosLegales?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.RequisitosLegales = inspeccion.InspGuiaBPMFabricanteMed.RequisitosLegales;
                                    data.InspGuiaBPMFabricanteMed.RequisitosLegales.PendingUpdate = false;

                                    data.InspGuiaBPMFabricanteMed.Observaciones = inspeccion.InspGuiaBPMFabricanteMed.Observaciones;
                                    data.InspGuiaBPMFabricanteMed.ProcesoVigilanciaSanit = inspeccion.InspGuiaBPMFabricanteMed.ProcesoVigilanciaSanit;
                                    data.InspGuiaBPMFabricanteMed.FechaUltimaVista = inspeccion.InspGuiaBPMFabricanteMed.FechaUltimaVista;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.ClasifActComerciales?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.ClasifActComerciales = inspeccion.InspGuiaBPMFabricanteMed.ClasifActComerciales;
                                    data.InspGuiaBPMFabricanteMed.ClasifActComerciales.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.ClasifEstablecimiento?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.ClasifEstablecimiento = inspeccion.InspGuiaBPMFabricanteMed.ClasifEstablecimiento;
                                    data.InspGuiaBPMFabricanteMed.ClasifEstablecimiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.OrganizacionPersonal?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.OrganizacionPersonal = inspeccion.InspGuiaBPMFabricanteMed.OrganizacionPersonal;
                                    data.InspGuiaBPMFabricanteMed.OrganizacionPersonal.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.EdifInstalaciones?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.EdifInstalaciones = inspeccion.InspGuiaBPMFabricanteMed.EdifInstalaciones;
                                    data.InspGuiaBPMFabricanteMed.EdifInstalaciones.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.Almacenes?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.Almacenes = inspeccion.InspGuiaBPMFabricanteMed.Almacenes;
                                    data.InspGuiaBPMFabricanteMed.Almacenes.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.AreaDispMatPrima?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.AreaDispMatPrima = inspeccion.InspGuiaBPMFabricanteMed.AreaDispMatPrima;
                                    data.InspGuiaBPMFabricanteMed.AreaDispMatPrima.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.AreaProduccion?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.AreaProduccion = inspeccion.InspGuiaBPMFabricanteMed.AreaProduccion;
                                    data.InspGuiaBPMFabricanteMed.AreaProduccion.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.AreaAcondicionamiento?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.AreaAcondicionamiento = inspeccion.InspGuiaBPMFabricanteMed.AreaAcondicionamiento;
                                    data.InspGuiaBPMFabricanteMed.AreaAcondicionamiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.EquiposGeneralidades?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.EquiposGeneralidades = inspeccion.InspGuiaBPMFabricanteMed.EquiposGeneralidades;
                                    data.InspGuiaBPMFabricanteMed.EquiposGeneralidades.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.Equipos?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.Equipos = inspeccion.InspGuiaBPMFabricanteMed.Equipos;
                                    data.InspGuiaBPMFabricanteMed.Equipos.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.MatProducts?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.MatProducts = inspeccion.InspGuiaBPMFabricanteMed.MatProducts;
                                    data.InspGuiaBPMFabricanteMed.MatProducts.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.Documentacion?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.Documentacion = inspeccion.InspGuiaBPMFabricanteMed.Documentacion;
                                    data.InspGuiaBPMFabricanteMed.Documentacion.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.Produccion?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.Produccion = inspeccion.InspGuiaBPMFabricanteMed.Produccion;
                                    data.InspGuiaBPMFabricanteMed.Produccion.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.GarantiaCalidad?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.GarantiaCalidad = inspeccion.InspGuiaBPMFabricanteMed.GarantiaCalidad;
                                    data.InspGuiaBPMFabricanteMed.GarantiaCalidad.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.ControlCalidad?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.ControlCalidad = inspeccion.InspGuiaBPMFabricanteMed.ControlCalidad;
                                    data.InspGuiaBPMFabricanteMed.ControlCalidad.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.ProdAnalisisContrato?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.ProdAnalisisContrato = inspeccion.InspGuiaBPMFabricanteMed.ProdAnalisisContrato;
                                    data.InspGuiaBPMFabricanteMed.ProdAnalisisContrato.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.ValGenerales?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.ValGenerales = inspeccion.InspGuiaBPMFabricanteMed.ValGenerales;
                                    data.InspGuiaBPMFabricanteMed.ValGenerales.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.QuejasReclamos?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.QuejasReclamos = inspeccion.InspGuiaBPMFabricanteMed.QuejasReclamos;
                                    data.InspGuiaBPMFabricanteMed.QuejasReclamos.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.AutoInspecAuditCal?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.AutoInspecAuditCal = inspeccion.InspGuiaBPMFabricanteMed.AutoInspecAuditCal;
                                    data.InspGuiaBPMFabricanteMed.AutoInspecAuditCal.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.FabProdFarmEsteril_A?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A = inspeccion.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A;
                                    data.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.FabProdFarmEsteril_Gen?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_Gen = inspeccion.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_Gen;
                                    data.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_Gen.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.FabProdFarmEsteril_A2?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A2 = inspeccion.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A2;
                                    data.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A2.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.FabProdFarmEsteril_A3?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A3 = inspeccion.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A3;
                                    data.InspGuiaBPMFabricanteMed.FabProdFarmEsteril_A3.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.Lactamicos?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.Lactamicos = inspeccion.InspGuiaBPMFabricanteMed.Lactamicos;
                                    data.InspGuiaBPMFabricanteMed.Lactamicos.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.ProdCitostatico?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.ProdCitostatico = inspeccion.InspGuiaBPMFabricanteMed.ProdCitostatico;
                                    data.InspGuiaBPMFabricanteMed.ProdCitostatico.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMFabricanteMed?.ProdCitostatico?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMFabricanteMed.ProdCitostatico = inspeccion.InspGuiaBPMFabricanteMed.ProdCitostatico;
                                    data.InspGuiaBPMFabricanteMed.ProdCitostatico.PendingUpdate = false;
                                }

                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.BPMAM:
                            {
                                inspeccion.InspGuiaBPMLabAcondicionador.PendingUpdate = false;
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.DatosRepresentLegal?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.DatosRepresentLegal = inspeccion.InspGuiaBPMLabAcondicionador.DatosRepresentLegal;
                                    data.InspGuiaBPMLabAcondicionador.DatosRepresentLegal.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.DatosRegente?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.DatosRegente = inspeccion.InspGuiaBPMLabAcondicionador.DatosRegente;
                                    data.InspGuiaBPMLabAcondicionador.DatosRegente.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.OtrosFuncionarios?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.OtrosFuncionarios = inspeccion.InspGuiaBPMLabAcondicionador.OtrosFuncionarios;
                                    data.InspGuiaBPMLabAcondicionador.OtrosFuncionarios.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.RequisitosLegales?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.RequisitosLegales = inspeccion.InspGuiaBPMLabAcondicionador.RequisitosLegales;
                                    data.InspGuiaBPMLabAcondicionador.RequisitosLegales.PendingUpdate = false;

                                    data.InspGuiaBPMLabAcondicionador.Observaciones = inspeccion.InspGuiaBPMLabAcondicionador.Observaciones;
                                    data.InspGuiaBPMLabAcondicionador.ProcesoVigilanciaSanit = inspeccion.InspGuiaBPMLabAcondicionador.ProcesoVigilanciaSanit;
                                    data.InspGuiaBPMLabAcondicionador.FechaUltimaVista = inspeccion.InspGuiaBPMLabAcondicionador.FechaUltimaVista;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.ClasifActComerciales?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.ClasifActComerciales = inspeccion.InspGuiaBPMLabAcondicionador.ClasifActComerciales;
                                    data.InspGuiaBPMLabAcondicionador.ClasifActComerciales.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.ClasifEstablecimiento?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.ClasifEstablecimiento = inspeccion.InspGuiaBPMLabAcondicionador.ClasifEstablecimiento;
                                    data.InspGuiaBPMLabAcondicionador.ClasifEstablecimiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.OrganizacionPersonal?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.OrganizacionPersonal = inspeccion.InspGuiaBPMLabAcondicionador.OrganizacionPersonal;
                                    data.InspGuiaBPMLabAcondicionador.OrganizacionPersonal.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.EdifInstalaciones?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.EdifInstalaciones = inspeccion.InspGuiaBPMLabAcondicionador.EdifInstalaciones;
                                    data.InspGuiaBPMLabAcondicionador.EdifInstalaciones.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.Almacenes?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.Almacenes = inspeccion.InspGuiaBPMLabAcondicionador.Almacenes;
                                    data.InspGuiaBPMLabAcondicionador.Almacenes.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.AreaAcondicionamiento?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.AreaAcondicionamiento = inspeccion.InspGuiaBPMLabAcondicionador.AreaAcondicionamiento;
                                    data.InspGuiaBPMLabAcondicionador.AreaAcondicionamiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.EquiposGeneralidades?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.EquiposGeneralidades = inspeccion.InspGuiaBPMLabAcondicionador.EquiposGeneralidades;
                                    data.InspGuiaBPMLabAcondicionador.EquiposGeneralidades.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.MatProducts?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.MatProducts = inspeccion.InspGuiaBPMLabAcondicionador.MatProducts;
                                    data.InspGuiaBPMLabAcondicionador.MatProducts.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.Documentacion?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.Documentacion = inspeccion.InspGuiaBPMLabAcondicionador.Documentacion;
                                    data.InspGuiaBPMLabAcondicionador.Documentacion.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.Acondicionamiento?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.Acondicionamiento = inspeccion.InspGuiaBPMLabAcondicionador.Acondicionamiento;
                                    data.InspGuiaBPMLabAcondicionador.Acondicionamiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.GarantiaCalidad?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.GarantiaCalidad = inspeccion.InspGuiaBPMLabAcondicionador.GarantiaCalidad;
                                    data.InspGuiaBPMLabAcondicionador.GarantiaCalidad.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.ControlCalidad?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.ControlCalidad = inspeccion.InspGuiaBPMLabAcondicionador.ControlCalidad;
                                    data.InspGuiaBPMLabAcondicionador.ControlCalidad.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.ProdAnalisisContrato?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.ProdAnalisisContrato = inspeccion.InspGuiaBPMLabAcondicionador.ProdAnalisisContrato;
                                    data.InspGuiaBPMLabAcondicionador.ProdAnalisisContrato.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.ValGenerales?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.ValGenerales = inspeccion.InspGuiaBPMLabAcondicionador.ValGenerales;
                                    data.InspGuiaBPMLabAcondicionador.ValGenerales.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.QuejasReclamos?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.QuejasReclamos = inspeccion.InspGuiaBPMLabAcondicionador.QuejasReclamos;
                                    data.InspGuiaBPMLabAcondicionador.QuejasReclamos.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPMLabAcondicionador?.AutoInspecAuditCal?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPMLabAcondicionador.AutoInspecAuditCal = inspeccion.InspGuiaBPMLabAcondicionador.AutoInspecAuditCal;
                                    data.InspGuiaBPMLabAcondicionador.AutoInspecAuditCal.PendingUpdate = false;
                                }
                                

                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.BPMCD:
                            {
                                inspeccion.InspGuiBPMFabCosmeticoMed.PendingUpdate = false;
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.DatosRepresentLegal?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.DatosRepresentLegal = inspeccion.InspGuiBPMFabCosmeticoMed.DatosRepresentLegal;
                                    data.InspGuiBPMFabCosmeticoMed.DatosRepresentLegal.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.DatosRegente?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.DatosRegente = inspeccion.InspGuiBPMFabCosmeticoMed.DatosRegente;
                                    data.InspGuiBPMFabCosmeticoMed.DatosRegente.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.OtrosFuncionarios?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.OtrosFuncionarios = inspeccion.InspGuiBPMFabCosmeticoMed.OtrosFuncionarios;
                                    data.InspGuiBPMFabCosmeticoMed.OtrosFuncionarios.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.RequisitosLegales?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.RequisitosLegales = inspeccion.InspGuiBPMFabCosmeticoMed.RequisitosLegales;
                                    data.InspGuiBPMFabCosmeticoMed.RequisitosLegales.PendingUpdate = false;

                                    data.InspGuiBPMFabCosmeticoMed.Observaciones = inspeccion.InspGuiBPMFabCosmeticoMed.Observaciones;
                                    data.InspGuiBPMFabCosmeticoMed.ProcesoVigilanciaSanit = inspeccion.InspGuiBPMFabCosmeticoMed.ProcesoVigilanciaSanit;
                                    data.InspGuiBPMFabCosmeticoMed.FechaUltimaVista = inspeccion.InspGuiBPMFabCosmeticoMed.FechaUltimaVista;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.ClasifActComerciales?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.ClasifActComerciales = inspeccion.InspGuiBPMFabCosmeticoMed.ClasifActComerciales;
                                    data.InspGuiBPMFabCosmeticoMed.ClasifActComerciales.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.ClasifEstablecimiento?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.ClasifEstablecimiento = inspeccion.InspGuiBPMFabCosmeticoMed.ClasifEstablecimiento;
                                    data.InspGuiBPMFabCosmeticoMed.ClasifEstablecimiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.AdminInfoGeneral?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.AdminInfoGeneral = inspeccion.InspGuiBPMFabCosmeticoMed.AdminInfoGeneral;
                                    data.InspGuiBPMFabCosmeticoMed.AdminInfoGeneral.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.CondExtAlmacenas?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.CondExtAlmacenas = inspeccion.InspGuiBPMFabCosmeticoMed.CondExtAlmacenas;
                                    data.InspGuiBPMFabCosmeticoMed.CondExtAlmacenas.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.CondIntAlmacenas?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.CondIntAlmacenas = inspeccion.InspGuiBPMFabCosmeticoMed.CondIntAlmacenas;
                                    data.InspGuiBPMFabCosmeticoMed.CondIntAlmacenas.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.AreaRecepMateriaPrima?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.AreaRecepMateriaPrima = inspeccion.InspGuiBPMFabCosmeticoMed.AreaRecepMateriaPrima;
                                    data.InspGuiBPMFabCosmeticoMed.AreaRecepMateriaPrima.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.AlmacenMateriaPrima?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.AlmacenMateriaPrima = inspeccion.InspGuiBPMFabCosmeticoMed.AlmacenMateriaPrima;
                                    data.InspGuiBPMFabCosmeticoMed.AlmacenMateriaPrima.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.AlmacenMatAcondicionamineto?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.AlmacenMatAcondicionamineto = inspeccion.InspGuiBPMFabCosmeticoMed.AlmacenMatAcondicionamineto;
                                    data.InspGuiBPMFabCosmeticoMed.AlmacenMatAcondicionamineto.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.RecepProductoTerminado?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.RecepProductoTerminado = inspeccion.InspGuiBPMFabCosmeticoMed.RecepProductoTerminado;
                                    data.InspGuiBPMFabCosmeticoMed.RecepProductoTerminado.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.AlmacenProductoTerminado?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.AlmacenProductoTerminado = inspeccion.InspGuiBPMFabCosmeticoMed.AlmacenProductoTerminado;
                                    data.InspGuiBPMFabCosmeticoMed.AlmacenProductoTerminado.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.ProductoDevueltoRechazado?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.ProductoDevueltoRechazado = inspeccion.InspGuiBPMFabCosmeticoMed.ProductoDevueltoRechazado;
                                    data.InspGuiBPMFabCosmeticoMed.ProductoDevueltoRechazado.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.DistProductoTerminado?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.DistProductoTerminado = inspeccion.InspGuiBPMFabCosmeticoMed.DistProductoTerminado;
                                    data.InspGuiBPMFabCosmeticoMed.DistProductoTerminado.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.ManejoQuejaReclamos?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.ManejoQuejaReclamos = inspeccion.InspGuiBPMFabCosmeticoMed.ManejoQuejaReclamos;
                                    data.InspGuiBPMFabCosmeticoMed.ManejoQuejaReclamos.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.RetiroProcMercado?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.RetiroProcMercado = inspeccion.InspGuiBPMFabCosmeticoMed.RetiroProcMercado;
                                    data.InspGuiBPMFabCosmeticoMed.RetiroProcMercado.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.SistemaInstAgua?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.SistemaInstAgua = inspeccion.InspGuiBPMFabCosmeticoMed.SistemaInstAgua;
                                    data.InspGuiBPMFabCosmeticoMed.SistemaInstAgua.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.OsmosisInversa?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.OsmosisInversa = inspeccion.InspGuiBPMFabCosmeticoMed.OsmosisInversa;
                                    data.InspGuiBPMFabCosmeticoMed.OsmosisInversa.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.SistemaDeIonizacion?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.SistemaDeIonizacion = inspeccion.InspGuiBPMFabCosmeticoMed.SistemaDeIonizacion;
                                    data.InspGuiBPMFabCosmeticoMed.SistemaDeIonizacion.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.CalibraVerifEquipo?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.CalibraVerifEquipo = inspeccion.InspGuiBPMFabCosmeticoMed.CalibraVerifEquipo;
                                    data.InspGuiBPMFabCosmeticoMed.CalibraVerifEquipo.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.Validaciones?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.Validaciones = inspeccion.InspGuiBPMFabCosmeticoMed.Validaciones;
                                    data.InspGuiBPMFabCosmeticoMed.Validaciones.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.MantAreaEquipos?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.MantAreaEquipos = inspeccion.InspGuiBPMFabCosmeticoMed.MantAreaEquipos;
                                    data.InspGuiBPMFabCosmeticoMed.MantAreaEquipos.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.AreaProdCondExternas?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.AreaProdCondExternas = inspeccion.InspGuiBPMFabCosmeticoMed.AreaProdCondExternas;
                                    data.InspGuiBPMFabCosmeticoMed.AreaProdCondExternas.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.AreaProdCondInternas?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.AreaProdCondInternas = inspeccion.InspGuiBPMFabCosmeticoMed.AreaProdCondInternas;
                                    data.InspGuiBPMFabCosmeticoMed.AreaProdCondInternas.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.AreaOrganizaDocumentacion?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.AreaOrganizaDocumentacion = inspeccion.InspGuiBPMFabCosmeticoMed.AreaOrganizaDocumentacion;
                                    data.InspGuiBPMFabCosmeticoMed.AreaOrganizaDocumentacion.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.AreaDispensionOrdFab?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.AreaDispensionOrdFab = inspeccion.InspGuiBPMFabCosmeticoMed.AreaDispensionOrdFab;
                                    data.InspGuiBPMFabCosmeticoMed.AreaDispensionOrdFab.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.FabProdDesinfectante?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.FabProdDesinfectante = inspeccion.InspGuiBPMFabCosmeticoMed.FabProdDesinfectante;
                                    data.InspGuiBPMFabCosmeticoMed.FabProdDesinfectante.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.FabPlaguicida?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.FabPlaguicida = inspeccion.InspGuiBPMFabCosmeticoMed.FabPlaguicida;
                                    data.InspGuiBPMFabCosmeticoMed.FabPlaguicida.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.FabCosmeticos?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.FabCosmeticos = inspeccion.InspGuiBPMFabCosmeticoMed.FabCosmeticos;
                                    data.InspGuiBPMFabCosmeticoMed.FabCosmeticos.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.AreaEnvasado?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.AreaEnvasado = inspeccion.InspGuiBPMFabCosmeticoMed.AreaEnvasado;
                                    data.InspGuiBPMFabCosmeticoMed.AreaEnvasado.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.AreaEtiquetadoEmpaque?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.AreaEtiquetadoEmpaque = inspeccion.InspGuiBPMFabCosmeticoMed.AreaEtiquetadoEmpaque;
                                    data.InspGuiBPMFabCosmeticoMed.AreaEtiquetadoEmpaque.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.LabControlCalidad?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.LabControlCalidad = inspeccion.InspGuiBPMFabCosmeticoMed.LabControlCalidad;
                                    data.InspGuiBPMFabCosmeticoMed.LabControlCalidad.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.AnalisisContrato?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.AnalisisContrato = inspeccion.InspGuiBPMFabCosmeticoMed.AnalisisContrato;
                                    data.InspGuiBPMFabCosmeticoMed.AnalisisContrato.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.InspeccionAudito?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.InspeccionAudito = inspeccion.InspGuiBPMFabCosmeticoMed.InspeccionAudito;
                                    data.InspGuiBPMFabCosmeticoMed.InspeccionAudito.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabCosmeticoMed?.InspeccionAudito?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabCosmeticoMed.InspeccionAudito = inspeccion.InspGuiBPMFabCosmeticoMed.InspeccionAudito;
                                    data.InspGuiBPMFabCosmeticoMed.InspeccionAudito.PendingUpdate = false;
                                }



                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.BPMMN:
                            {
                                inspeccion.InspGuiBPMFabNatMedicina.PendingUpdate = false;
                                if (inspeccion.InspGuiBPMFabNatMedicina?.DatosRepresentLegal?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.DatosRepresentLegal = inspeccion.InspGuiBPMFabNatMedicina.DatosRepresentLegal;
                                    data.InspGuiBPMFabNatMedicina.DatosRepresentLegal.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.DatosRegente?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.DatosRegente = inspeccion.InspGuiBPMFabNatMedicina.DatosRegente;
                                    data.InspGuiBPMFabNatMedicina.DatosRegente.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.OtrosFuncionarios?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.OtrosFuncionarios = inspeccion.InspGuiBPMFabNatMedicina.OtrosFuncionarios;
                                    data.InspGuiBPMFabNatMedicina.OtrosFuncionarios.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.InfoGeneral?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.InfoGeneral = inspeccion.InspGuiBPMFabNatMedicina.InfoGeneral;
                                    data.InspGuiBPMFabNatMedicina.InfoGeneral.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.AuthFuncionamiento?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.AuthFuncionamiento = inspeccion.InspGuiBPMFabNatMedicina.AuthFuncionamiento;
                                    data.InspGuiBPMFabNatMedicina.AuthFuncionamiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Organizacion?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Organizacion = inspeccion.InspGuiBPMFabNatMedicina.Organizacion;
                                    data.InspGuiBPMFabNatMedicina.Organizacion.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Personal?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Personal = inspeccion.InspGuiBPMFabNatMedicina.Personal;
                                    data.InspGuiBPMFabNatMedicina.Personal.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.ResponPersonal?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.ResponPersonal = inspeccion.InspGuiBPMFabNatMedicina.ResponPersonal;
                                    data.InspGuiBPMFabNatMedicina.ResponPersonal.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Capacitacion?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Capacitacion = inspeccion.InspGuiBPMFabNatMedicina.Capacitacion;
                                    data.InspGuiBPMFabNatMedicina.Capacitacion.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.HigieneSalud?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.HigieneSalud = inspeccion.InspGuiBPMFabNatMedicina.HigieneSalud;
                                    data.InspGuiBPMFabNatMedicina.HigieneSalud.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.UbicacionDisenoConstruc?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.UbicacionDisenoConstruc = inspeccion.InspGuiBPMFabNatMedicina.UbicacionDisenoConstruc;
                                    data.InspGuiBPMFabNatMedicina.UbicacionDisenoConstruc.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Almacenes?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Almacenes = inspeccion.InspGuiBPMFabNatMedicina.Almacenes;
                                    data.InspGuiBPMFabNatMedicina.Almacenes.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.AreaRecepLimpieza?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.AreaRecepLimpieza = inspeccion.InspGuiBPMFabNatMedicina.AreaRecepLimpieza;
                                    data.InspGuiBPMFabNatMedicina.AreaRecepLimpieza.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.AreaSecadoMolienda?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.AreaSecadoMolienda = inspeccion.InspGuiBPMFabNatMedicina.AreaSecadoMolienda;
                                    data.InspGuiBPMFabNatMedicina.AreaSecadoMolienda.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.AreaDispensadoMatPrima?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.AreaDispensadoMatPrima = inspeccion.InspGuiBPMFabNatMedicina.AreaDispensadoMatPrima;
                                    data.InspGuiBPMFabNatMedicina.AreaDispensadoMatPrima.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.AreaProduccion?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.AreaProduccion = inspeccion.InspGuiBPMFabNatMedicina.AreaProduccion;
                                    data.InspGuiBPMFabNatMedicina.AreaProduccion.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.AreaEnvasadoEmpaque?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.AreaEnvasadoEmpaque = inspeccion.InspGuiBPMFabNatMedicina.AreaEnvasadoEmpaque;
                                    data.InspGuiBPMFabNatMedicina.AreaEnvasadoEmpaque.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.AreaAuxiliares?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.AreaAuxiliares = inspeccion.InspGuiBPMFabNatMedicina.AreaAuxiliares;
                                    data.InspGuiBPMFabNatMedicina.AreaAuxiliares.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.AreaControlCalidad?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.AreaControlCalidad = inspeccion.InspGuiBPMFabNatMedicina.AreaControlCalidad;
                                    data.InspGuiBPMFabNatMedicina.AreaControlCalidad.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Generalidades8?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Generalidades8 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades8;
                                    data.InspGuiBPMFabNatMedicina.Generalidades8.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Calibracion?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Calibracion = inspeccion.InspGuiBPMFabNatMedicina.Calibracion;
                                    data.InspGuiBPMFabNatMedicina.Calibracion.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.SistemaAgua?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.SistemaAgua = inspeccion.InspGuiBPMFabNatMedicina.SistemaAgua;
                                    data.InspGuiBPMFabNatMedicina.SistemaAgua.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.SistemaAire?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.SistemaAire = inspeccion.InspGuiBPMFabNatMedicina.SistemaAire;
                                    data.InspGuiBPMFabNatMedicina.SistemaAire.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Generalidades9?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Generalidades9 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades9;
                                    data.InspGuiBPMFabNatMedicina.Generalidades9.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.DispensadoMatPrima?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.DispensadoMatPrima = inspeccion.InspGuiBPMFabNatMedicina.DispensadoMatPrima;
                                    data.InspGuiBPMFabNatMedicina.DispensadoMatPrima.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.MatAcondicionamiento?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.MatAcondicionamiento = inspeccion.InspGuiBPMFabNatMedicina.MatAcondicionamiento;
                                    data.InspGuiBPMFabNatMedicina.MatAcondicionamiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.ProdAGranel?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.ProdAGranel = inspeccion.InspGuiBPMFabNatMedicina.ProdAGranel;
                                    data.InspGuiBPMFabNatMedicina.ProdAGranel.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.ProdTerminados?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.ProdTerminados = inspeccion.InspGuiBPMFabNatMedicina.ProdTerminados;
                                    data.InspGuiBPMFabNatMedicina.ProdTerminados.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.ProdRechazados?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.ProdRechazados = inspeccion.InspGuiBPMFabNatMedicina.ProdRechazados;
                                    data.InspGuiBPMFabNatMedicina.ProdRechazados.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.ProdDevueltos?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.ProdDevueltos = inspeccion.InspGuiBPMFabNatMedicina.ProdDevueltos;
                                    data.InspGuiBPMFabNatMedicina.ProdDevueltos.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Generalidades10?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Generalidades10 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades10;
                                    data.InspGuiBPMFabNatMedicina.Generalidades10.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.DocumentosExigido?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.DocumentosExigido = inspeccion.InspGuiBPMFabNatMedicina.DocumentosExigido;
                                    data.InspGuiBPMFabNatMedicina.DocumentosExigido.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.ProcedimientoReg?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.ProcedimientoReg = inspeccion.InspGuiBPMFabNatMedicina.ProcedimientoReg;
                                    data.InspGuiBPMFabNatMedicina.ProcedimientoReg.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.ProdControlProceso?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.ProdControlProceso = inspeccion.InspGuiBPMFabNatMedicina.ProdControlProceso;
                                    data.InspGuiBPMFabNatMedicina.ProdControlProceso.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Generalidades12?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Generalidades12 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades12;
                                    data.InspGuiBPMFabNatMedicina.Generalidades12.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.GarantiaCalidad?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.GarantiaCalidad = inspeccion.InspGuiBPMFabNatMedicina.GarantiaCalidad;
                                    data.InspGuiBPMFabNatMedicina.GarantiaCalidad.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Generalidades13?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Generalidades13 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades13;
                                    data.InspGuiBPMFabNatMedicina.Generalidades13.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Muestreo?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Muestreo = inspeccion.InspGuiBPMFabNatMedicina.Muestreo;
                                    data.InspGuiBPMFabNatMedicina.Muestreo.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.MetodologiaAnalitica?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.MetodologiaAnalitica = inspeccion.InspGuiBPMFabNatMedicina.MetodologiaAnalitica;
                                    data.InspGuiBPMFabNatMedicina.MetodologiaAnalitica.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.MaterialesReferencia?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.MaterialesReferencia = inspeccion.InspGuiBPMFabNatMedicina.MaterialesReferencia;
                                    data.InspGuiBPMFabNatMedicina.MaterialesReferencia.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Estabilidad?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Estabilidad = inspeccion.InspGuiBPMFabNatMedicina.Estabilidad;
                                    data.InspGuiBPMFabNatMedicina.Estabilidad.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Generalidades14?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Generalidades14 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades14;
                                    data.InspGuiBPMFabNatMedicina.Generalidades14.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Retiros?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Retiros = inspeccion.InspGuiBPMFabNatMedicina.Retiros;
                                    data.InspGuiBPMFabNatMedicina.Retiros.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Generalidades15?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Generalidades15 = inspeccion.InspGuiBPMFabNatMedicina.Generalidades15;
                                    data.InspGuiBPMFabNatMedicina.Generalidades15.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Contratante?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Contratante = inspeccion.InspGuiBPMFabNatMedicina.Contratante;
                                    data.InspGuiBPMFabNatMedicina.Contratante.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.Contratista?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.Contratista = inspeccion.InspGuiBPMFabNatMedicina.Contratista;
                                    data.InspGuiBPMFabNatMedicina.Contratista.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiBPMFabNatMedicina?.AuditoriaCalidad?.PendingUpdate ?? false)
                                {
                                    data.InspGuiBPMFabNatMedicina.AuditoriaCalidad = inspeccion.InspGuiBPMFabNatMedicina.AuditoriaCalidad;
                                    data.InspGuiBPMFabNatMedicina.AuditoriaCalidad.PendingUpdate = false;
                                }


                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.BPA:
                            {
                                inspeccion.InspGuiaBPM_Bpa.PendingUpdate = false;
                                if (inspeccion.InspGuiaBPM_Bpa?.DatosRepresentLegal?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPM_Bpa.DatosRepresentLegal = inspeccion.InspGuiaBPM_Bpa.DatosRepresentLegal;
                                    data.InspGuiaBPM_Bpa.DatosRepresentLegal.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPM_Bpa?.DatosRegente?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPM_Bpa.DatosRegente = inspeccion.InspGuiaBPM_Bpa.DatosRegente;
                                    data.InspGuiaBPM_Bpa.DatosRegente.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPM_Bpa?.OtrosFuncionarios?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPM_Bpa.OtrosFuncionarios = inspeccion.InspGuiaBPM_Bpa.OtrosFuncionarios;
                                    data.InspGuiaBPM_Bpa.OtrosFuncionarios.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPM_Bpa?.PropositoInsp?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPM_Bpa.PropositoInsp = inspeccion.InspGuiaBPM_Bpa.PropositoInsp;
                                    data.InspGuiaBPM_Bpa.PropositoInsp.PendingUpdate = false;

                                    data.InspGuiaBPM_Bpa.ActComercialAprobada = inspeccion.InspGuiaBPM_Bpa.ActComercialAprobada;
                                    data.InspGuiaBPM_Bpa.FechaUltimaInspeccion = inspeccion.InspGuiaBPM_Bpa.FechaUltimaInspeccion;
                                    data.InspGuiaBPM_Bpa.HorarioEstFarmaceutico = inspeccion.InspGuiaBPM_Bpa.HorarioEstFarmaceutico;
                                    data.InspGuiaBPM_Bpa.HorarioRegFarmaceutica = inspeccion.InspGuiaBPM_Bpa.HorarioRegFarmaceutica;
                                }
                                if (inspeccion.InspGuiaBPM_Bpa?.DispGenerlestablecimiento?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPM_Bpa.DispGenerlestablecimiento = inspeccion.InspGuiaBPM_Bpa.DispGenerlestablecimiento;
                                    data.InspGuiaBPM_Bpa.DispGenerlestablecimiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPM_Bpa?.AreasEstablecimiento?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPM_Bpa.AreasEstablecimiento = inspeccion.InspGuiaBPM_Bpa.AreasEstablecimiento;
                                    data.InspGuiaBPM_Bpa.AreasEstablecimiento.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPM_Bpa?.Distribucion?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPM_Bpa.Distribucion = inspeccion.InspGuiaBPM_Bpa.Distribucion;
                                    data.InspGuiaBPM_Bpa.Distribucion.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPM_Bpa?.TransProdFarmaceuticos?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPM_Bpa.TransProdFarmaceuticos = inspeccion.InspGuiaBPM_Bpa.TransProdFarmaceuticos;
                                    data.InspGuiaBPM_Bpa.TransProdFarmaceuticos.PendingUpdate = false;
                                }
                                if (inspeccion.InspGuiaBPM_Bpa?.AutoInspec?.PendingUpdate ?? false)
                                {
                                    data.InspGuiaBPM_Bpa.AutoInspec = inspeccion.InspGuiaBPM_Bpa.AutoInspec;
                                    data.InspGuiaBPM_Bpa.AutoInspec.PendingUpdate = false;
                                }

                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.AECA:
                            {
                                inspeccion.InspAperturaCosmetArtesanal.PendingUpdate = false;
                                if (inspeccion.InspAperturaCosmetArtesanal?.DatosRepresentLegal?.PendingUpdate ?? false)
                                {
                                    data.InspAperturaCosmetArtesanal.DatosRepresentLegal = inspeccion.InspAperturaCosmetArtesanal.DatosRepresentLegal;
                                    data.InspAperturaCosmetArtesanal.DatosRepresentLegal.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperturaCosmetArtesanal?.Documentacion?.PendingUpdate ?? false)
                                {
                                    data.InspAperturaCosmetArtesanal.Documentacion = inspeccion.InspAperturaCosmetArtesanal.Documentacion;
                                    data.InspAperturaCosmetArtesanal.Documentacion.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperturaCosmetArtesanal?.Locales?.PendingUpdate ?? false)
                                {
                                    data.InspAperturaCosmetArtesanal.Locales = inspeccion.InspAperturaCosmetArtesanal.Locales;
                                    data.InspAperturaCosmetArtesanal.Locales.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperturaCosmetArtesanal?.AreaAlmacenamiento?.PendingUpdate ?? false)
                                {
                                    data.InspAperturaCosmetArtesanal.AreaAlmacenamiento = inspeccion.InspAperturaCosmetArtesanal.AreaAlmacenamiento;
                                    data.InspAperturaCosmetArtesanal.AreaAlmacenamiento.PendingUpdate = false;
                                }

                                break;
                            }
                        case DataModel.Helper.enumAUD_TipoActa.ABP:
                        case DataModel.Helper.enumAUD_TipoActa.CUBP:
                            {
                                inspeccion.InspAperCambUbicBotiquin.PendingUpdate = false;
                                if (inspeccion.InspAperCambUbicBotiquin?.DatosRepresentLegal?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicBotiquin.DatosRepresentLegal = inspeccion.InspAperCambUbicBotiquin.DatosRepresentLegal;
                                    data.InspAperCambUbicBotiquin.DatosRepresentLegal.PendingUpdate = false;
                                }
                                if (inspeccion.InspAperCambUbicBotiquin?.CondCaractEstablecimiento?.PendingUpdate ?? false)
                                {
                                    data.InspAperCambUbicBotiquin.CondCaractEstablecimiento = inspeccion.InspAperCambUbicBotiquin.CondCaractEstablecimiento;
                                    data.InspAperCambUbicBotiquin.CondCaractEstablecimiento.PendingUpdate = false;
                                }

                                break;
                            }


                    }

                    data.PendingUpdate = false;

                    data = dalService.Save<AUD_InspeccionTB>(data);

                    if(data!=null)
                        return Ok(new InspectionApiResponse { Result = true , Id= data.Id});
                }
            }
            catch (Exception ex) { return BadRequest(new InspectionApiResponse { Result=false, Message = ex.Message }); }
            return BadRequest(new InspectionApiResponse { Result = false, Message = "dato no encontrado" });
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
