using Aig.FarmacoVigilancia.Pages.Note;
using Aig.FarmacoVigilancia.Pages.Settings.OrigenAlerta;
using Aig.FarmacoVigilancia.Services;
using DataAccess;
using DataModel;
using DataModel.DTO;
using DataModel.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
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


        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet("GetAllLaboratorios")]
        public async Task<IActionResult> GetAllLaboratorios()
        {
            try
            {
                var data = dalService.GetAll<LaboratorioTB>();
                return Ok(data);

            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }

            return BadRequest(new { message = "resultados no encontrados" });
        }

        [AllowAnonymous]
        [HttpGet("GetAllOrigenAlerta")]
        public async Task<IActionResult> GetAllOrigenAlerta()
        {
            try
            {
                var data = dalService.GetAll<FMV_OrigenAlertaTB>();
                return Ok(data);

            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }

            return BadRequest(new { message = "resultados no encontrados" });
        }

        [AllowAnonymous]
        [HttpPost("UpdateAlerta")]
        public async Task<IActionResult> UpdateAlerta([FromBody] AlertModel model)
        {
            try
            {
                var data = dalService.Get<FMV_AlertaTB>(model.IdTramite);

                if(data == null)
                {
                    data = new FMV_AlertaTB()
                    {
                        FechaRecepcion = model.FechaEntrada,
                        Producto = model.NombreComercial,
                        DCI = model.PrincipioActivo,
                        OrigenAlertaId = model.OrigenAlerta.Id,
                        Descripcion = model.Descripcion, //+ " " + model.LaboratorioFabricante?.Nombre ?? "" + " " + model.RegSanitario
                        Observaciones = model.LaboratorioFabricante?.Nombre ?? "" + " " + model.RegSanitario
                    };
                }
                
                if (model?.LAdjuntos?.Count > 0)
                {
                    data.Adjunto = data.Adjunto!=null? data.Adjunto: new AttachmentData() { };
                    data.Adjunto.LAttachments.Clear();

                    foreach (var item in model?.LAdjuntos)
                    {
                        data.Adjunto.LAttachments.Add(item);
                    }
                }
                var result = dalService.Save(data);
                if (result != null)
                {
                    return Ok(result.Id);
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }

            return BadRequest(new { message = "los datos no pueden actualizados" });
        }

        [AllowAnonymous]
        [HttpPost("UpdatePMR")]
        public async Task<IActionResult> UpdatePMR([FromBody] PmrModel model)
        {
            try
            {
                var data = dalService.Get<FMV_PmrTB>(model.IdTramite);

                if (data == null)
                {
                    data = new FMV_PmrTB()
                    {
                        FechaEntrada = model.FechaEntrada,
                        PmrProducto = new FMV_PmrProductoTB()
                        {
                            RegSanitario = model.RegSanitario,
                            NomComercial = model.NombreComercial,
                            LaboratorioId = model.LaboratorioFabricante.Id
                        },
                        PrincActivo = model.PrincipioActivo,
                    };
                }                    
                if (model?.LAdjuntos?.Count > 0)
                {
                    data.Adjunto = data.Adjunto != null ? data.Adjunto : new AttachmentData() { };
                    data.Adjunto.LAttachments.Clear();

                    foreach (var item in model?.LAdjuntos)
                    {
                        data.Adjunto.LAttachments.Add(item);
                    }
                }
                var result = dalService.Save(data);
                if (result != null)
                {
                    return Ok(result.Id);
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }

            return BadRequest(new { message = "los datos no pueden actualizados" });
        }

        [AllowAnonymous]
        [HttpPost("UpdateRF")]
        public async Task<IActionResult> UpdateRF([FromBody] RfModel model)
        {
            try
            {
                var data = dalService.Get<FMV_RfvTB>(model.IdTramite);
                if (data == null)
                {
                    data = new FMV_RfvTB()
                    {
                        FechaNotificacion = model.FechaEntrada,
                        Correos = model.Correo,
                        DireccionFisica = model.Direccion,
                        LaboratorioId = model.Empresa?.Id,
                        NombreCompleto = model.NombreCompleto,
                        Observaciones = model.Observaciones,
                        TipoCargo = model.Cargo,
                        TipoUbicacion = model.OrigenPersona,
                        Telefonos = model.Telefono,
                    };
                }
                 
                if (model?.LAdjuntos?.Count > 0)
                {
                    data.Adjunto = data.Adjunto != null ? data.Adjunto : new AttachmentData() { };
                    data.Adjunto.LAttachments.Clear();
                    foreach (var item in model?.LAdjuntos)
                    {
                        data.Adjunto.LAttachments.Add(item);
                    }
                }
                var result = dalService.Save(data);
                if (result != null)
                {
                    return Ok(result.Id);
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }

            return BadRequest(new { message = "los datos no pueden actualizados" });
        }

        [AllowAnonymous]
        [HttpPost("UpdateIPS")]
        public async Task<IActionResult> UpdateIPS([FromBody] IpsModel model)
        {
            try
            {
                var data = dalService.Get<FMV_IpsTB>(model.IdTramite);
                if(data == null)
                {
                    data = new FMV_IpsTB()
                    {
                        Biologico = model.Biologico == DataModel.Helper.enumAUD_TipoSeleccion.Si ? true : false,
                        FechaRecepcion = model.FechaEntrada,
                        PeriodoIni = model.FechaIni,
                        PeriodoFin = model.FechaFin,
                        Innovador = model.Innovador == DataModel.Helper.enumAUD_TipoSeleccion.Si ? true : false,
                        PrincActivo = model.PrincipioActivo,
                        ReqIntercam = model.ReqIntercam == DataModel.Helper.enumAUD_TipoSeleccion.Si ? true : false,
                        IpsData = new FMV_IpsData()
                        {
                            FechaAutPan = model.FechaAutorizacion,
                            PeriodoIni = model.FechaIni,
                            PeriodoFin = model.FechaFin,
                        },
                    };
                }
                
                if (model?.LMedicamentos?.Count > 0)
                {
                    data.LMedicamentos = data.LMedicamentos!=null? data.LMedicamentos: new List<FMV_IpsMedicamentoTB>() { };
                    foreach (var item in model?.LMedicamentos)
                    {
                        if(data.LMedicamentos.Find(x=>x.RegSanitario == item.RegSanitario) == null)
                        {
                            data.LMedicamentos.Add(new FMV_IpsMedicamentoTB()
                            {
                                LaboratorioId = item.Laboratorio?.Id ?? 0,
                                NomComercial = item.NomComercial,
                                NomDCI = item.NomDCI,
                                RegSanitario = item.RegSanitario,
                            });
                        }
                    }
                }

                data.Adjunto = data.Adjunto != null ? data.Adjunto : new AttachmentData() { };
                data.Adjunto.LAttachments = data.Adjunto.LAttachments?.Count > 0 ? data.Adjunto.LAttachments : new List<AttachmentTB>();
                data.Adjunto.LAttachments.Clear();
                if (model.LAdjuntos?.Count > 0)
                {
                    foreach (var item in model.LAdjuntos)
                    {
                        if (data.Adjunto.LAttachments.Find(x => x.FileName == item.FileName) == null)
                        {
                            data.Adjunto.LAttachments.Add(item);
                        }
                    }
                }
                //if (model.InformeAdjunto!=null)
                //{
                //    data.Adjunto.LAttachments.Add(model.InformeAdjunto);
                //}
                //if (model.ResumenAdjunto != null)
                //{
                //    data.Adjunto.LAttachments.Add(model.ResumenAdjunto);
                //}
                //if (model.NotaAdjunto != null)
                //{
                //    data.Adjunto.LAttachments.Add(model.NotaAdjunto);
                //}
                //if (model.InformeIPSAdjunto != null)
                //{
                //    data.Adjunto.LAttachments.Add(model.InformeIPSAdjunto);
                //}

                var result = dalService.Save(data);
                if (result != null)
                {
                    return Ok(result.Id);
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }

            return BadRequest(new { message = "los datos no pueden actualizados" });
        }

        [AllowAnonymous]
        [HttpPost("UpdateNOTA")]
        public async Task<IActionResult> UpdateNOTA([FromBody] NotaModel model)
        {
            try
            {
                var nota = dalService.Get<FMV_NotaTB>(model.IdTramite);
                if(nota == null)
                {
                    nota = new FMV_NotaTB() { 
                        Adjunto = new AttachmentData() { },
                         Descripcion = "--",
                        Fecha = System.DateTime.Now,
                    };
                }
                if (nota != null)
                {
                    nota.NumNota = model.NumNota;
                    nota.Descripcion = model.Comentarios;
                    
                    nota.Adjunto = nota.Adjunto != null ? nota.Adjunto : new AttachmentData() { };
                    nota.Adjunto.LAttachments = nota.Adjunto.LAttachments?.Count > 0 ? nota.Adjunto.LAttachments : new List<AttachmentTB>();
                    nota.Adjunto.LAttachments.Clear();
                    if (model.LAdjuntos?.Count > 0)
                    {
                        foreach (var item in model.LAdjuntos)
                        {
                            nota.Adjunto.LAttachments.Add(item);
                        }
                    }

                    nota.NotaContactos = nota.NotaContactos != null ? nota.NotaContactos : new FMV_NotaContactos();
                    nota.NotaContactos.LContactos = nota.NotaContactos.LContactos?.Count > 0 ? nota.NotaContactos.LContactos : new List<FMV_ContactosTB>();
                    nota.NotaContactos.LContactos.Clear();
                    if (model.LCorreos?.Count > 0)
                    {
                        foreach (var item in model.LCorreos)
                        {
                            nota.NotaContactos.LContactos.Add(new FMV_ContactosTB() { Cargo = item.Cargo, Correo = item.Correo, Nombre = item.NombreCompleto, Instalacion = item.Departamento });
                        }
                    }
                    var result = dalService.Save(nota);
                    if (result != null)
                    {
                        return Ok(result.Id);
                    }
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }

            return BadRequest(new { message = "los datos no pueden actualizados" });
        }


    }
}
