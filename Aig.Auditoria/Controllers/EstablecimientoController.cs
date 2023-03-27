using Aig.Auditoria.Pages.Inspections;
using Aig.Auditoria.Services;
using DataAccess;
using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
                }
            }
            catch(Exception ex) { return BadRequest(new { message = ex.Message }); }
            return BadRequest(new { message = "data not found" });
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
