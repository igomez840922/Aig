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

    }
}
