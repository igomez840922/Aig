using Aig.FarmacoVigilancia.Services;
using DataAccess;
using DataModel;
using DataModel.DTO;
using DataModel.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static ClosedXML.Excel.XLPredefinedFormat;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace Aig.FarmacoVigilancia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentalsController : ControllerBase
    {
        private readonly IDalService dalService;
        public DepartamentalsController(IDalService dalService)
        {
            this.dalService= dalService;
        }

        
        [HttpPost("UpdateFVRE")]
        public async Task<IActionResult> UpdateFVRE([FromBody] UpdateDepartamentalModel model)
        {
            try {
                switch (model.TipoTramiteFVRE)
                {
                    case DataModel.Helper.TipoTramiteFVRE.RAM:
                        {
                            var result = dalService.Find<FMV_Ram2TB>(x => x.CodigoCNFV == model.NumTramite);
                            result.Adjunto = result.Adjunto != null ? result.Adjunto : new AttachmentData();
                            if (model?.LAttachments?.Count > 0)
                            {
                                result.Adjunto.LAttachments = result.Adjunto.LAttachments != null ? result.Adjunto.LAttachments : new List<AttachmentTB>();

                                foreach (var attachments in model.LAttachments)
                                {
                                    result.Adjunto.LAttachments.Add(attachments);
                                }
                            }
                            result = dalService.Save(result);
                            if (result != null)
                            {
                                return Ok(result);
                            }

                            break;
                        }
                    case DataModel.Helper.TipoTramiteFVRE.ESAVI:
                        {
                            var result = dalService.Find<FMV_Esavi2TB>(x => x.CodCNFV == model.NumTramite);
                            //message.Attachment.InspeccionId = Inspeccion.Id;
                            result.Adjunto = result.Adjunto != null ? result.Adjunto : new AttachmentData();
                            if (model?.LAttachments?.Count > 0)
                            {
                                result.Adjunto.LAttachments = result.Adjunto.LAttachments != null ? result.Adjunto.LAttachments : new List<AttachmentTB>();

                                foreach (var attachments in model.LAttachments)
                                {
                                    result.Adjunto.LAttachments.Add(attachments);
                                }
                            }
                            result = dalService.Save(result);
                            if (result != null)
                            {
                                return Ok(result);
                            }
                            break;
                        }
                }
            }
            catch(Exception ex) { return BadRequest(new { message = ex.Message }); }
            
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
