using DataAccess.FarmacoVigilancia;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace Aig.FarmacoVigilancia.Services
{    
    public class ESAVIService : IESAVIService
    {
        private readonly IDalService DalService;
        public ESAVIService(IDalService dalService)
        {
            DalService = dalService;
        }

        public async Task<GenericModel<FMV_EsaviTB>> FindAll(GenericModel<FMV_EsaviTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_EsaviTB>()
                              where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.CodCNFV.Contains(model.Filter) || data.CodExt.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter)))&&
                              (model.FromDate==null?true:(data.FechaRecibidoCNFV >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId ))
                              orderby data.CreatedDate
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_EsaviTB>()
                               where data.Deleted == false &&
                               (string.IsNullOrEmpty(model.Filter) ? true : (data.CodCNFV.Contains(model.Filter) || data.CodExt.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter))) &&
                               (model.FromDate == null ? true : (data.FechaRecibidoCNFV >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecibidoCNFV <= model.ToDate)) &&
                               (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<FMV_EsaviTB> model)
        {
            try
            {
                //model.PagIdx = 0; model.PagAmt = int.MaxValue;

                //model = await FindAll(model);

                //if (model.Ldata != null && model.Ldata.Count > 0)
                //{
                //    var wb = new XLWorkbook();
                //    wb.Properties.Author = "INFORMES_PERIODICOS_SEGURIDAD";
                //    wb.Properties.Title = "INFORMES_PERIODICOS_SEGURIDAD";
                //    wb.Properties.Subject = "INFORMES_PERIODICOS_SEGURIDAD";

                //    var ws = wb.Worksheets.Add("INFORMES_PERIODICOS_SEGURIDAD");

                //    ws.Cell(1, 1).Value = "Fecha de recepción en CNFV";
                //    ws.Cell(1, 2).Value = "Fecha de entrega al registrador";
                //    ws.Cell(1, 3).Value = "Registrador";
                //    ws.Cell(1, 4).Value = "Nombre comercial";
                //    ws.Cell(1, 5).Value = "Principio Activo";
                //    ws.Cell(1, 6).Value = "Titular";
                //    ws.Cell(1, 7).Value = "No. Registro Sanitario";
                //    ws.Cell(1, 8).Value = "Presenta CD";
                //    ws.Cell(1, 9).Value = "Periodo que cubre";
                //    ws.Cell(1, 10).Value = "Fecha de Registro";
                //    ws.Cell(1, 11).Value = "Estatus de Recepción";
                //    ws.Cell(1, 12).Value = "Fecha de Asignación para Pre-Evaluación";
                //    ws.Cell(1, 13).Value = "Tramitador";
                //    ws.Cell(1, 14).Value = "Innovador";
                //    ws.Cell(1, 15).Value = "Biológico";
                //    ws.Cell(1, 16).Value = "Requiere Intercambiabilidad";
                //    ws.Cell(1, 17).Value = "Fecha de autorización en Panamá";
                //    ws.Cell(1, 18).Value = "Fecha de Pre-Evaluación";
                //    ws.Cell(1, 19).Value = "Estatus de Registro";
                //    ws.Cell(1, 20).Value = "Prioridad";
                //    ws.Cell(1, 21).Value = "Fecha de Asignación para Evaluación";
                //    ws.Cell(1, 22).Value = "Evaluador";
                //    ws.Cell(1, 23).Value = "Resumen Ejecutivo";
                //    ws.Cell(1, 24).Value = "Resumen Ejecutivo Traducido";
                //    ws.Cell(1, 25).Value = "Tabla de contenido";
                //    ws.Cell(1, 26).Value = "Introducción";
                //    ws.Cell(1, 27).Value = "Situación Mundial de Autorización de comercialización";
                //    ws.Cell(1, 28).Value = "Medidas adoptadas por ARNs o TRS";
                //    ws.Cell(1, 29).Value = "Cambios a la información de seguridad";
                //    ws.Cell(1, 30).Value = "Monografía/Inserto";
                //    ws.Cell(1, 31).Value = "Exposición estimada y patrones de uso";
                //    ws.Cell(1, 32).Value = "Presentación de casos (RAMs reportadas)";
                //    ws.Cell(1, 33).Value = "Resumen de hallazgos significantes de seguridad";
                //    ws.Cell(1, 34).Value = "Otra información relacionada";
                //    ws.Cell(1, 35).Value = "Falta de eficacia en ensayos clínicos controlados";
                //    ws.Cell(1, 36).Value = "Revisión de señales";
                //    ws.Cell(1, 37).Value = "Evaluación de señales y riesgos";
                //    ws.Cell(1, 38).Value = "Evaluación del beneficio";
                //    ws.Cell(1, 39).Value = "Análisis de beneficio/riesgo";
                //    ws.Cell(1, 40).Value = "Conclusiones y acciones";
                //    ws.Cell(1, 41).Value = "Anexos y Apendices";
                //    ws.Cell(1, 42).Value = "Ha cambiado el balance B/R?";
                //    ws.Cell(1, 43).Value = "Hay propuestas de un plan de acción?";
                //    ws.Cell(1, 44).Value = "Solicitud de información al fabricante";
                //    ws.Cell(1, 45).Value = "Fecha de revisión";
                //    ws.Cell(1, 46).Value = "Estatus de Revisión";
                //    ws.Cell(1, 47).Value = "IPS confeccionado conforme a normativa?";
                //    ws.Cell(1, 48).Value = "No. de Informe";
                //    ws.Cell(1, 49).Value = "OBSERVACIONES";

                //    for (int row = 1; row <= model.Ldata.Count; row++)
                //    {
                //        var prod = model.Ldata[row - 1];
                //        ws.Cell(row + 1, 1).Value = prod.FechaRecepcion?.ToString("dd/MM/yyyy") ?? "";
                //        ws.Cell(row + 1, 2).Value = prod.FechaRegistrador?.ToString("dd/MM/yyyy") ?? "";
                //        ws.Cell(row + 1, 3).Value = prod.Registrador?.NombreCompleto ?? "";
                //        ws.Cell(row + 1, 4).Value = prod.NomComercial;
                //        ws.Cell(row + 1, 5).Value = prod.PrincActivo;
                //        ws.Cell(row + 1, 6).Value = prod.Laboratorio?.Nombre??"";
                //        ws.Cell(row + 1, 7).Value = prod.RegSanitario;
                //        ws.Cell(row + 1, 8).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData.PresentaCd);
                //        ws.Cell(row + 1, 9).Value = prod.IpsData?.PeriodoIni?.ToString("dd/MM/yyyy") ?? "" + " " + prod.IpsData?.PeriodoFin?.ToString("dd/MM/yyyy") ?? "";
                //        ws.Cell(row + 1, 10).Value = prod.IpsData?.FechaRegistro?.ToString("dd/MM/yyyy") ?? "";
                //        ws.Cell(row + 1, 11).Value = DataModel.Helper.Helper.GetDescription(prod.EstatusRecepcion);
                //        ws.Cell(row + 1, 12).Value = prod.IpsData?.FechaAsigPreEva?.ToString("dd/MM/yyyy") ?? "";
                //        ws.Cell(row + 1, 13).Value = prod.Tramitador?.NombreCompleto ?? "";
                //        ws.Cell(row + 1, 14).Value = prod.IpsData !=null && prod.IpsData.Innovador?"Si":"No";
                //        ws.Cell(row + 1, 15).Value = prod.IpsData != null && prod.IpsData.Biologico ? "Si" : "No";
                //        ws.Cell(row + 1, 16).Value = prod.IpsData != null && prod.IpsData.ReqIntercam ? "Si" : "No";
                //        ws.Cell(row + 1, 17).Value = prod.IpsData?.FechaAutPan?.ToString("dd/MM/yyyy") ?? "";
                //        ws.Cell(row + 1, 18).Value = prod.IpsData?.FechaPreEva?.ToString("dd/MM/yyyy") ?? "";
                //        ws.Cell(row + 1, 19).Value = DataModel.Helper.Helper.GetDescription(prod.EstatusRegistro);
                //        ws.Cell(row + 1, 20).Value = prod.Prioridad ? "Si" : "No";
                //        ws.Cell(row + 1, 21).Value = prod.FechaAsigEva?.ToString("dd/MM/yyyy") ?? "";
                //        ws.Cell(row + 1, 22).Value = prod.Evaluador?.NombreCompleto ?? "";
                //        ws.Cell(row + 1, 23).Value = DataModel.Helper.Helper.GetDescription(prod.ResumenEjec);
                //        ws.Cell(row + 1, 24).Value = DataModel.Helper.Helper.GetDescription(prod.ResumenEjecTrad);
                //        ws.Cell(row + 1, 25).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.TablaContenido?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 26).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.Introduccion ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 27).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.SitMunAutCom ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 28).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.MedAdoptada ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 29).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.CamInfoSeg ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 30).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.Monografia ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 31).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.ExpEstimada ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 32).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.PresCasos ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 33).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.ResHallazgo ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 34).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.OtraInfRel ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 35).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.FaltaEficacia ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 36).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.RevisionSenales ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 37).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.EvaluacionSenales ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 38).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.EvaluacionBeneficio ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 39).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.AnaBenRiesgo ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 40).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.ConcluAcciones ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 41).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.AnexoApendice ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 42).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.CambioBalance ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 43).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.PropPlanAccion ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 44).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.SolInfoFabricante ?? enumFMV_IpsTipoPresentaiones.No);
                //        ws.Cell(row + 1, 45).Value = prod.FechaRev?.ToString("dd/MM/yyyy") ?? "";
                //        ws.Cell(row + 1, 46).Value = DataModel.Helper.Helper.GetDescription(prod.StatusRevision);
                //        ws.Cell(row + 1, 47).Value = prod.ConfecConNormativa ? "Si" : "No";
                //        ws.Cell(row + 1, 48).Value = prod.NoInforme;
                //        ws.Cell(row + 1, 49).Value = prod.IpsData?.Observaciones?? "";
                //    }

                //    MemoryStream XLSStream = new();
                //    wb.SaveAs(XLSStream);

                //    return XLSStream;
                //}
           
            
            }
            catch (Exception ex)
            { }

            return null;
        }


        public async Task<List<FMV_EsaviTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_EsaviTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_EsaviTB> Get(long Id)
        {
            var result = DalService.Get<FMV_EsaviTB>(Id);
            return result;
        }

        public async Task<FMV_EsaviTB> Save(FMV_EsaviTB data)
        {            
            //if (data.LNotificaciones != null)
            //{
            //    foreach (var item in data.LNotificaciones)
            //    {
            //        //ctx.Entry(designHubProject).Property(b => b.SectionStatuses).IsModified = true;
            //        DalService.DBContext.Entry(item).Property(b => b.FallaReportada).IsModified = true;
            //        DalService.DBContext.Entry(item).Property(b => b.EvaluacionCausalidad).IsModified = true;
            //    }
            //}

            var result = DalService.Save(data);

            return result;           
        }

        public async Task<FMV_EsaviTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_EsaviTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_EsaviTB>(); }
            catch { }return 0;
        }
    }

}
