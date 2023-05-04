using Aig.Auditoria.Pages.Inspections;
using Aig.Auditoria.Services;
using DataAccess;
using DataModel;
using DataModel.DTO;
using DataModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static ClosedXML.Excel.XLPredefinedFormat;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace Aig.Auditoria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstablecimientoController : ControllerBase
    {
        private readonly IDalService dalService;
        private readonly IPdfGenerationService pdfGenerationService;
        public EstablecimientoController(IDalService dalService,IPdfGenerationService pdfGenerationService)
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
                    var data = dalService.Find<AUD_EstablecimientoTB>(x => x.NumLicencia == number);
                    if(data!=null)
                    {
                        return Ok(data);
                    }
                    data = dalService.Find<AUD_EstablecimientoTB>(x => x.ReciboPago == number);
                    if (data != null)
                    {
                        return Ok(data);
                    }
                }
            }
            catch(Exception ex) { return BadRequest(new { message = ex.Message }); }
            return BadRequest(new { message = "data not found" });
        }

        [HttpPost("SaveUpdate")]
        public async Task<IActionResult> SaveUpdate([FromBody] AUD_EstablecimientoTB establecimiento)
        {
            //if (userForRegistration == null || !ModelState.IsValid)
            //    return BadRequest();

            if (establecimiento?.Provincia != null)
            {
                establecimiento.ProvinciaId = dalService.Find<ProvinciaTB>(x => x.Codigo == establecimiento.Provincia.Codigo)?.Id??0;
                establecimiento.Provincia = null;
            }
            if (establecimiento?.Distrito != null)
            {
                establecimiento.DistritoId = dalService.Find<DistritoTB>(x => x.Codigo == establecimiento.Distrito.Codigo)?.Id ?? 0;
                establecimiento.Distrito=null;
            }
            if (establecimiento?.Corregimiento != null)
            {
                establecimiento.CorregimientoId = dalService.Find<CorregimientoTB>(x => x.Codigo == establecimiento.Corregimiento.Codigo)?.Id ?? 0;
                establecimiento.Corregimiento = null;
            }

            var data = dalService.Get<AUD_EstablecimientoTB>(establecimiento.Id);
            if(data == null )
            {
                data = dalService.Find<AUD_EstablecimientoTB>(x => x.NumLicencia == establecimiento.NumLicencia);
            }
            establecimiento.Id = data?.Id ?? establecimiento.Id;

            establecimiento = dalService.UpdateValues<AUD_EstablecimientoTB>(establecimiento);

           if (establecimiento!=null)
            {
                return Ok(establecimiento);
            }
            return BadRequest(new { message = "establecimiento no pudo ser actualizado" });
        }


        //[HttpGet("CheckByNumber")]
        //public async Task<IActionResult> CheckByNumber(string number) {
        //    try {
        //        if (!string.IsNullOrEmpty(number)) {
        //            var data = dalService.Find<AUD_EstablecimientoTB>(x => x.NumLicencia == number);
        //            if (data != null) {
        //                return Ok(new 
        //                    { 
        //                    Nombre= data.Nombre,
        //                    TipoEstablecimiento = data.TipoEstablecimiento,
        //                    NumLicencia = data.NumLicencia,
        //                    NumLicencia = data.NumLicencia,
        //                    NumeroActa = data.NumActa, 
        //                    DatosEstablecimiento = new DatosEstablecimiento() { 
        //                        AvisoOperaciones=data.DatosEstablecimiento?.AvisoOperaciones??"",
        //                         NumLicencia = data.DatosEstablecimiento?.NumLicencia ?? "",
        //                        Nombre = data.DatosEstablecimiento?.Nombre ?? "",
        //                         ReciboPago = data.DatosEstablecimiento?.ReciboPago ?? "",
        //                         CorregimientoCodigo = data.DatosEstablecimiento?.Corregimiento?.Codigo ?? "",
        //                        CorregimientoNombre = data.DatosEstablecimiento?.Corregimiento?.Nombre ?? "",
        //                        DistritoCodigo = data.DatosEstablecimiento?.Distrito?.Codigo ?? "",
        //                        DistritoNombre = data.DatosEstablecimiento?.Distrito?.Nombre ?? "",
        //                        ProvinciaCodigo = data.DatosEstablecimiento?.Provincia?.Codigo ?? "",
        //                        ProvinciaNombre = data.DatosEstablecimiento?.Provincia?.Nombre ?? "",
        //                        Correo = data.DatosEstablecimiento?.Correo ?? "",
        //                        Direccion = data.DatosEstablecimiento?.Direccion ?? "",
        //                        Telefono = data.DatosEstablecimiento?.Telefono ?? "",
        //                    } 
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex) { return BadRequest(new { message = ex.Message }); }
        //    return BadRequest(new { message = "data not found" });
        //}


    }
}
