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
        [HttpGet("GetAllInstituciones")]
        public async Task<IActionResult> GetAllInstituciones()
        {
            try
            {
                var data = dalService.GetAll<InstitucionDestinoTB>();
                return Ok(data);

            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }

            return BadRequest(new { message = "resultados no encontrados" });
        }

        [AllowAnonymous]
        [HttpGet("GetAllTipoInstituciones")]
        public async Task<IActionResult> GetAllTipoInstituciones()
        {
            try
            {
                var data = dalService.GetAll<TipoInstitucionTB>();
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

        [AllowAnonymous]
        [HttpPost("UpdateFT")]
        public async Task<IActionResult> UpdateFT([FromBody]FTModel model)
        {
            try
            {
                var ft = dalService.Get<FMV_FtTB>(model.IdTramite);
                if (ft == null)
                {
                    ft = new FMV_FtTB()
                    {
                        CodCNFV = "-",
                        NombreComercial = "-",
                        NombreDci = "-",
                        Notificador = "-",
                    };
                }

                if (ft != null)
                {
                    ft.CodExt = model.Num;
					ft.FechaRecibidoCNFV = model.DatosNotificador?.FechaNotificacion??null;
					ft.NombreComercial = model.DatosMedicamento?.NomComercial??"";
                    ft.NombreDci = model.DatosMedicamento?.NomDCI ?? "";
                    ft.Presentacion = model.DatosMedicamento?.Presentacion ?? "";
                    ft.Concentracion = model.DatosMedicamento?.Concentracion ?? "";
                    ft.FormaFarmaceutica = model.DatosMedicamento?.FormaFarmaceutica ?? "";
                    ft.FabricanteId = model.DatosMedicamento?.Laboratorio?.Id ?? null;
                    ft.RegSanitario = model.DatosMedicamento?.RegSanitario ?? "";
                    ft.TipoNotificacion = model.DatosNotificador?.TipoNotificador ?? DataModel.Helper.enumFMV_RAMNotificationType.NOREP;
                    //ft.ProvinciaId = model.DatosNotificador?.Provincia?.Id ?? 0;
                    var codProv = model.DatosNotificador?.Provincia?.Codigo ?? null;
                    ft.ProvinciaId = string.IsNullOrEmpty(codProv)? null : (dalService.Find<ProvinciaTB>(x => x.Codigo == codProv)?.Id ?? null);
                    ft.InstitucionId = model.DatosNotificador?.InstalacionSalud?.Id ?? null;
                    ft.Notificador = model.DatosNotificador?.Notificador?.NombreCompleto ?? "";
                    ft.Notificador = model.DatosNotificador?.Notificador?.NombreCompleto ?? "";
                    if(!string.IsNullOrEmpty(model.DatosMedicamento?.Lotes ?? null))
                    {
                        ft.LLotes = ft.LLotes?.Count > 0 ? ft.LLotes : new List<FMV_LoteTB>();
                        ft.LLotes.RemoveAll(x=>x.Nombre == model.DatosMedicamento.Lotes);
                        ft.LLotes.Add(new FMV_LoteTB() { Nombre = model.DatosMedicamento.Lotes, FechaExpira = model.DatosMedicamento.FechaExp });
                    }
                    ft.DetalleFalla = model.SospechaFallaTerapeutica?.Razones ?? "";

                    ft.DatosPaciente.NombrePaciente = model.DatosPaciente?.Paciente?.NombreCompleto ?? "";
                    ft.DatosPaciente.Sexo = model.DatosPaciente?.Sexo ??  DataModel.Helper.enumSexo.NA;
                    ft.DatosPaciente.Edad = model.DatosPaciente?.Edad ?? "";
                    ft.DatosPaciente.HistClinica = "";
                    if (model.DatosPaciente != null)
                    {
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Alergias? ("Alergias: si " + model.DatosPaciente.AlergiasDesc) : "Alergias: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Embarazo ? ("Embarazo: si " + model.DatosPaciente.EmbarazoDesc) : "Embarazo: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Alcohol ? ("Alcohol: si " + model.DatosPaciente.AlcoholDesc) : "Alcohol: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Droga ? ("Drogas: si " + model.DatosPaciente.DrogaDesc) : "Drogas: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Tabaquismo ? ("Tabaquismo: si " + model.DatosPaciente.TabaquismoDesc) : "Tabaquismo: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Diabetes ? ("Diabetes: si " + model.DatosPaciente.DiabetesDesc) : "Diabetes: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Hta ? ("Hta: si " + model.DatosPaciente.HtaDesc) : "Hta: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Hepatico ? ("Hepático: si " + model.DatosPaciente.HepaticoDesc) : "Hepático: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Renal ? ("Renal: si " + model.DatosPaciente.RenalDesc) : "Renal: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Cardiaco ? ("Cardiaco: si " + model.DatosPaciente.CardiacoDesc) : "Cardiaco: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Respiratorio ? ("Respiratorio: si " + model.DatosPaciente.RespiratorioDesc) : "Respiratorio: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Hematologico ? ("Hematológico: si " + model.DatosPaciente.HematologicoDesc) : "Hematológico: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Gi ? ("GI: si " + model.DatosPaciente.GiDesc) : "GI: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Piel ? ("Piel: si " + model.DatosPaciente.PielDesc) : "Piel: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Neurologico ? ("Neurológico: si " + model.DatosPaciente.NeurologicoDesc) : "Neurológico: no");
                        ft.DatosPaciente.HistClinica += "\r\n" + (model.DatosPaciente.Otros ? ("Otros: si " + model.DatosPaciente.OtrosDesc) : "Otros: no");
                    }
                    ft.DatosPaciente.FechaTratInicial = model.DatosMedicamento?.FechaIni?.ToString("dd/MM/yyyy") ?? "";
                    ft.DatosPaciente.FechaTratFinal = model.DatosMedicamento?.FechaFin?.ToString("dd/MM/yyyy") ?? "";
                    ft.DatosPaciente.FechaFT = model.SospechaFallaTerapeutica?.FechaFalla?.ToString("dd/MM/yyyy") ?? "";
                    ft.DatosPaciente.Indicacion = model.DatosMedicamento?.Diagnostigo??"";
                    ft.DatosPaciente.ViaAdministracion = model.DatosMedicamento?.DosisPosologiaPrescrita ?? "";
                    if(model.SospechaFallaTerapeutica?.LMedicamentoSospechoso?.Count > 0)
                    {
                        ft.Concominantes.LProductos = ft.Concominantes?.LProductos?.Count > 0 ? ft.Concominantes.LProductos : new List<FMV_RamFarmacoConcominante>();
                        ft.Concominantes.LProductos.Clear();

                        foreach(var prd in model.SospechaFallaTerapeutica.LMedicamentoSospechoso)
                        {
                            ft.Concominantes.LProductos.Add(new FMV_RamFarmacoConcominante() 
                            {
                                 Nombre = prd.NomComercial,
                                ViaAdministracion = prd.ViaAdministracion,
                                FechaTratamiento = prd.FechaIni?.ToString("dd/MM/yyyy") ?? "",
                                Indicacion = prd.Diagnostico,
                            });
                        }
                    }
                    if (model.LAdjuntos?.Count > 0)
                    {
                        ft.Adjunto.LAttachments = ft.Adjunto.LAttachments?.Count > 0 ? ft.Adjunto.LAttachments : new List<AttachmentTB>();
                        ft.Adjunto.LAttachments.Clear();

                        foreach (var attch in model.LAdjuntos)
                        {
                            ft.Adjunto.LAttachments.Add(attch);
                        }
                    }
                                        
                    var result = dalService.Save(ft);
                    if (result != null)
                    {
                        return Ok(result.Id);
                    }
                }
            }
            catch (Exception ex) { return BadRequest(new { message = ex.Message }); }

            return BadRequest(new { message = "los datos no pueden actualizados" });
        }

        [AllowAnonymous]
        [HttpPost("UpdateFTNote")]
        public async Task<IActionResult> UpdateFTNote([FromBody] FTNoteModel model)
        {
            try
            {
                var ft = dalService.Find<FMV_FtTB>(x=>x.CodCNFV == model.CodCNFV);
                if (ft != null)
                {
                    ft.Adjunto.LAttachments = ft.Adjunto.LAttachments?.Count > 0 ? ft.Adjunto.LAttachments : new List<AttachmentTB>();

                    var adjunto = ft.Adjunto.LAttachments.Find(x=>x.Description == model.Adjunto.Description);
                    if(adjunto != null)
                    {
                        ft.Adjunto.LAttachments.Remove(adjunto);
                    }
                    ft.Adjunto.LAttachments.Add(model.Adjunto);

                    var result = dalService.Save(ft);
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
