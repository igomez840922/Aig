using DataAccess;
using DataModel.Models;
using DataModel;
using Microsoft.AspNetCore.Identity;
using ClosedXML.Excel;
using DataModel.Helper;
using DocumentFormat.OpenXml.Drawing.Charts;
using Aig.FarmacoVigilancia.Pages.Settings.Laboratory;
using System.Linq.Expressions;

namespace Aig.FarmacoVigilancia.Services
{    
    public class IpsService : IIpsService
    {
        private readonly IDalService DalService;
        public IpsService(IDalService dalService)
        {
            DalService = dalService;
        }
        public async Task<List<FMV_IpsTB>> FindAll(Expression<Func<FMV_IpsTB, bool>> match)
        {
            try
            {
                return DalService.FindAll(match);
            }
            catch (Exception ex)
            { }

            return null;
        }
        public async Task<GenericModel<FMV_IpsTB>> FindAll(GenericModel<FMV_IpsTB> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata  =(from data in DalService.DBContext.Set<FMV_IpsTB>()
                where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.NoInforme.Contains(model.Filter) || data.LMedicamentos.Where(x=>x.RegSanitario.Contains(model.Filter) || x.NomComercial.Contains(model.Filter) || x.Laboratorio.Nombre.Contains(model.Filter)).Count()>0 || data.PrincActivo.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter) ))&&
                              (model.Priority == null ? true : (data.Prioridad == (model.Priority>0?true:false))) &&
                              (model.FromDate==null?true:(data.FechaRecepcion >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId )) &&
                              (model.RegisterId == null ? true : (data.RegistradorId == model.RegisterId)) &&
                              (model.IpsStatusRevision == null ? true : (data.StatusRevision == model.IpsStatusRevision))
                              orderby data.CreatedDate descending
                              select data).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                               where data.Deleted == false &&
                              (string.IsNullOrEmpty(model.Filter) ? true : (data.NoInforme.Contains(model.Filter) || data.LMedicamentos.Where(x => x.RegSanitario.Contains(model.Filter) || x.NomComercial.Contains(model.Filter) || x.Laboratorio.Nombre.Contains(model.Filter)).Count() > 0 || data.PrincActivo.Contains(model.Filter) || data.Evaluador.NombreCompleto.Contains(model.Filter))) &&
                              (model.Priority == null ? true : (data.Prioridad == (model.Priority > 0 ? true : false))) &&
                              (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                              (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate)) &&
                              (model.EvaluatorId == null ? true : (data.EvaluadorId == model.EvaluatorId)) &&
                              (model.RegisterId == null ? true : (data.RegistradorId == model.RegisterId)) &&
                              (model.IpsStatusRevision == null ? true : (data.StatusRevision == model.IpsStatusRevision))
                               select data).Count();  
            }
            catch (Exception ex)
            { }

            return model;
        }

        public async Task<Stream> ExportToExcel(GenericModel<FMV_IpsTB> model)
        {
            try
            {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;

                model = await FindAll(model);

                if (model.Ldata != null && model.Ldata.Count > 0)
                {
                    var wb = new XLWorkbook();
                    wb.Properties.Author = "INFORMES_PERIODICOS_SEGURIDAD";
                    wb.Properties.Title = "INFORMES_PERIODICOS_SEGURIDAD";
                    wb.Properties.Subject = "INFORMES_PERIODICOS_SEGURIDAD";

                    var ws = wb.Worksheets.Add("INFORMES_PERIODICOS_SEGURIDAD");

                    ws.Cell(1, 1).Value = "Fecha de recepción en CNFV";
                    ws.Cell(1, 2).Value = "Fecha de entrega al registrador";
                    ws.Cell(1, 3).Value = "Registrador";
                    ws.Cell(1, 4).Value = "Nombre comercial";
                    ws.Cell(1, 5).Value = "Principio Activo";
                    ws.Cell(1, 6).Value = "Titular";
                    ws.Cell(1, 7).Value = "No. Registro Sanitario";
                    ws.Cell(1, 8).Value = "Presenta CD";
                    ws.Cell(1, 9).Value = "Periodo que cubre";
                    ws.Cell(1, 10).Value = "Fecha de Registro";
                    ws.Cell(1, 11).Value = "Estatus de Recepción";
                    ws.Cell(1, 12).Value = "Fecha de Asignación para Pre-Evaluación";
                    ws.Cell(1, 13).Value = "Tramitador";
                    ws.Cell(1, 14).Value = "Innovador";
                    ws.Cell(1, 15).Value = "Biológico";
                    ws.Cell(1, 16).Value = "Requiere Intercambiabilidad";
                    ws.Cell(1, 17).Value = "Fecha de autorización en Panamá";
                    ws.Cell(1, 18).Value = "Fecha de Pre-Evaluación";
                    ws.Cell(1, 19).Value = "Estatus de Registro";
                    ws.Cell(1, 20).Value = "Prioridad";
                    ws.Cell(1, 21).Value = "Fecha de Asignación para Evaluación";
                    ws.Cell(1, 22).Value = "Evaluador";
                    ws.Cell(1, 23).Value = "Resumen Ejecutivo";
                    ws.Cell(1, 24).Value = "Resumen Ejecutivo Traducido";
                    ws.Cell(1, 25).Value = "Tabla de contenido";
                    ws.Cell(1, 26).Value = "Introducción";
                    ws.Cell(1, 27).Value = "Situación Mundial de Autorización de comercialización";
                    ws.Cell(1, 28).Value = "Medidas adoptadas por ARNs o TRS";
                    ws.Cell(1, 29).Value = "Cambios a la información de seguridad";
                    ws.Cell(1, 30).Value = "Monografía/Inserto";
                    ws.Cell(1, 31).Value = "Exposición estimada y patrones de uso";
                    ws.Cell(1, 32).Value = "Presentación de casos (RAMs reportadas)";
                    ws.Cell(1, 33).Value = "Resumen de hallazgos significantes de seguridad";
                    ws.Cell(1, 34).Value = "Otra información relacionada";
                    ws.Cell(1, 35).Value = "Falta de eficacia en ensayos clínicos controlados";
                    ws.Cell(1, 36).Value = "Revisión de señales";
                    ws.Cell(1, 37).Value = "Evaluación de señales y riesgos";
                    ws.Cell(1, 38).Value = "Evaluación del beneficio";
                    ws.Cell(1, 39).Value = "Análisis de beneficio/riesgo";
                    ws.Cell(1, 40).Value = "Conclusiones y acciones";
                    ws.Cell(1, 41).Value = "Anexos y Apendices";
                    ws.Cell(1, 42).Value = "Ha cambiado el balance B/R?";
                    ws.Cell(1, 43).Value = "Hay propuestas de un plan de acción?";
                    ws.Cell(1, 44).Value = "Solicitud de información al fabricante";
                    ws.Cell(1, 45).Value = "Fecha de revisión";
                    ws.Cell(1, 46).Value = "Estatus de Revisión";
                    ws.Cell(1, 47).Value = "IPS confeccionado conforme a normativa?";
                    ws.Cell(1, 48).Value = "No. de Informe";
                    ws.Cell(1, 49).Value = "OBSERVACIONES";

                    int row = 1;
                    for (int idx = 0; idx < model.Ldata.Count; idx++)
                    {                        
                        var prod = model.Ldata[idx];
                        if (prod.LMedicamentos?.Count> 0)
                        {                            
                            foreach (var med in prod.LMedicamentos)
                            {
                                row++;
                                ws.Cell(row, 1).Value = prod.FechaRecepcion?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(row, 2).Value = prod.FechaRegistrador?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(row, 3).Value = prod.Registrador?.NombreCompleto ?? "";
                                ws.Cell(row, 4).Value = med?.NomComercial; 
                                ws.Cell(row, 5).Value = prod.PrincActivo;
                                ws.Cell(row, 6).Value = med?.Laboratorio?.Nombre ?? "";
                                ws.Cell(row, 7).Value = med?.RegSanitario;
                                ws.Cell(row, 8).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData.PresentaCd);
                                ws.Cell(row, 9).Value = (prod.IpsData?.PeriodoIni?.ToString("dd/MM/yyyy") ?? "") + " - " + (prod.IpsData?.PeriodoFin?.ToString("dd/MM/yyyy") ?? "");
                                ws.Cell(row, 10).Value = prod.IpsData?.FechaRegistro?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(row, 11).Value = DataModel.Helper.Helper.GetDescription(prod.EstatusRecepcion);
                                ws.Cell(row, 12).Value = prod.IpsData?.FechaAsigPreEva?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(row, 13).Value = prod.Tramitador?.NombreCompleto ?? "";
                                ws.Cell(row, 14).Value = prod.IpsData != null && prod.Innovador ? "Si" : "No";
                                ws.Cell(row, 15).Value = prod.IpsData != null && prod.Biologico ? "Si" : "No";
                                ws.Cell(row, 16).Value = prod.IpsData != null && prod.ReqIntercam ? "Si" : "No";
                                ws.Cell(row, 17).Value = prod.IpsData?.FechaAutPan?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(row, 18).Value = prod.IpsData?.FechaPreEva?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(row, 19).Value = DataModel.Helper.Helper.GetDescription(prod.EstatusRegistro);
                                ws.Cell(row, 20).Value = prod.Prioridad ? "Si" : "No";
                                ws.Cell(row, 21).Value = prod.FechaAsigEva?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(row, 22).Value = prod.Evaluador?.NombreCompleto ?? "";
                                ws.Cell(row, 23).Value = DataModel.Helper.Helper.GetDescription(prod.ResumenEjec);
                                ws.Cell(row, 24).Value = DataModel.Helper.Helper.GetDescription(prod.ResumenEjecTrad);
                                ws.Cell(row, 25).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.TablaContenido ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 26).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.Introduccion ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 27).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.SitMunAutCom ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 28).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.MedAdoptada ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 29).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.CamInfoSeg ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 30).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.Monografia ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 31).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.ExpEstimada ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 32).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.PresCasos ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 33).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.ResHallazgo ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 34).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.OtraInfRel ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 35).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.FaltaEficacia ?? enumFMV_IpsTipoPresentaiones2.No);
                                ws.Cell(row, 36).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.RevisionSenales ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 37).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.EvaluacionSenales ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 38).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.EvaluacionBeneficio ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 39).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.AnaBenRiesgo ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 40).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.ConcluAcciones ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 41).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.AnexoApendice ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 42).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.CambioBalance ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 43).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.PropPlanAccion ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 44).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.SolInfoFabricante ?? enumFMV_IpsTipoPresentaiones.No);
                                ws.Cell(row, 45).Value = prod.FechaRev?.ToString("dd/MM/yyyy") ?? "";
                                ws.Cell(row, 46).Value = DataModel.Helper.Helper.GetDescription(prod.StatusRevision);
                                ws.Cell(row, 47).Value = DataModel.Helper.Helper.GetDescription(prod.ConfecConNormativa);
                                ws.Cell(row, 48).Value = prod.NoInforme;
                                ws.Cell(row, 49).Value = prod.IpsData?.Observaciones ?? "";
                            }
                        }
                        else
                        {
                            row++;
                            ws.Cell(row, 1).Value = prod.FechaRecepcion?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row, 2).Value = prod.FechaRegistrador?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row, 3).Value = prod.Registrador?.NombreCompleto ?? "";
                            ws.Cell(row, 4).Value = "";
                            ws.Cell(row, 5).Value = prod.PrincActivo;
                            ws.Cell(row, 6).Value = "";
                            ws.Cell(row, 7).Value = "";
                            ws.Cell(row, 8).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData.PresentaCd);
                            ws.Cell(row, 9).Value = (prod.IpsData?.PeriodoIni?.ToString("dd/MM/yyyy") ?? "") + " - " + (prod.IpsData?.PeriodoFin?.ToString("dd/MM/yyyy") ?? "");
                            ws.Cell(row, 10).Value = prod.IpsData?.FechaRegistro?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row, 11).Value = DataModel.Helper.Helper.GetDescription(prod.EstatusRecepcion);
                            ws.Cell(row, 12).Value = prod.IpsData?.FechaAsigPreEva?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row, 13).Value = prod.Tramitador?.NombreCompleto ?? "";
                            ws.Cell(row, 14).Value = prod.IpsData != null && prod.Innovador ? "Si" : "No";
                            ws.Cell(row, 15).Value = prod.IpsData != null && prod.Biologico ? "Si" : "No";
                            ws.Cell(row, 16).Value = prod.IpsData != null && prod.ReqIntercam ? "Si" : "No";
                            ws.Cell(row, 17).Value = prod.IpsData?.FechaAutPan?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row, 18).Value = prod.IpsData?.FechaPreEva?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row, 19).Value = DataModel.Helper.Helper.GetDescription(prod.EstatusRegistro);
                            ws.Cell(row, 20).Value = prod.Prioridad ? "Si" : "No";
                            ws.Cell(row, 21).Value = prod.FechaAsigEva?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row, 22).Value = prod.Evaluador?.NombreCompleto ?? "";
                            ws.Cell(row, 23).Value = DataModel.Helper.Helper.GetDescription(prod.ResumenEjec);
                            ws.Cell(row, 24).Value = DataModel.Helper.Helper.GetDescription(prod.ResumenEjecTrad);
                            ws.Cell(row, 25).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.TablaContenido ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 26).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.Introduccion ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 27).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.SitMunAutCom ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 28).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.MedAdoptada ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 29).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.CamInfoSeg ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 30).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.Monografia ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 31).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.ExpEstimada ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 32).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.PresCasos ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 33).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.ResHallazgo ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 34).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.OtraInfRel ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 35).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.FaltaEficacia ?? enumFMV_IpsTipoPresentaiones2.No);
                            ws.Cell(row, 36).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.RevisionSenales ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 37).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.EvaluacionSenales ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 38).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.EvaluacionBeneficio ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 39).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.AnaBenRiesgo ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 40).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.ConcluAcciones ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 41).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.AnexoApendice ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 42).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.CambioBalance ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 43).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.PropPlanAccion ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 44).Value = DataModel.Helper.Helper.GetDescription(prod.IpsData?.SolInfoFabricante ?? enumFMV_IpsTipoPresentaiones.No);
                            ws.Cell(row, 45).Value = prod.FechaRev?.ToString("dd/MM/yyyy") ?? "";
                            ws.Cell(row, 46).Value = DataModel.Helper.Helper.GetDescription(prod.StatusRevision);
                            ws.Cell(row, 47).Value = DataModel.Helper.Helper.GetDescription(prod.ConfecConNormativa);
                            ws.Cell(row, 48).Value = prod.NoInforme;
                            ws.Cell(row, 49).Value = prod.IpsData?.Observaciones ?? "";
                        }    
                    }

                    MemoryStream XLSStream = new();
                    wb.SaveAs(XLSStream);

                    return XLSStream;
                }
            }
            catch (Exception ex)
            { }

            return null;
        }


        public async Task<List<FMV_IpsTB>> GetAll()
        {
            return (from data in DalService.DBContext.Set<FMV_IpsTB>()
                    where data.Deleted == false
                    select data).ToList();
        }

        public async Task<FMV_IpsTB> Get(long Id)
        {
            var result = DalService.Get<FMV_IpsTB>(Id);
            return result;
        }

        public async Task<FMV_IpsTB> Save(FMV_IpsTB data)
        {
            data.PeriodoIni = data.IpsData?.PeriodoIni;
            data.PeriodoFin = data.IpsData?.PeriodoFin;

            var result = DalService.Save(data);

            if(result != null)
            {
                if (result.IpsData != null)
                {
                    DalService.DBContext.Entry(result).Property(b => b.IpsData).IsModified = true;					
                }
				DalService.DBContext.Entry(result).Property(b => b.Adjunto).IsModified = true;
				DalService.DBContext.SaveChanges();
			}
            return result;           
        }

        public async Task<FMV_IpsTB> Delete(long Id)
        {
            var data = DalService.Delete<FMV_IpsTB>(Id);
            return data;
        }

        public async Task<int> Count()
        {
            try { return DalService.Count<FMV_IpsTB>(); }
            catch { }return 0;
        }

        ////// REPORTES ///////////////
        ///

        //Nombre Comercial
        public async Task<ReportModel<ReportModelResponse>> Report1(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate)) &&
                               (data.NomComercial != null && data.NomComercial.Length > 0)
                               group data by data.NomComercial into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().NomComercial,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate)) &&
                               (data.NomComercial != null && data.NomComercial.Length > 0)
                               group data by data.NomComercial into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Nombre DCI
        public async Task<ReportModel<ReportModelResponse>> Report2(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate)) &&
                //               (data.NomDCI != null && data.NomDCI.Length > 0)
                //               group data by data.NomDCI into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   Name = g.FirstOrDefault().NomDCI,
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate)) &&
                //               (data.NomDCI != null && data.NomDCI.Length > 0)
                //               group data by data.NomComercial into g
                //               select g.Count()).Sum(x => x);

                model.Ldata = (from dataFinal in
                                 (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                                  where data.Deleted == false &&
                                (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                                (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate)) &&
                                (data.NomDCI != null && data.NomDCI.Length > 0)
                                  group data by new { data.NomDCI } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse {
                                      Name = g.FirstOrDefault().NomDCI,//.Substring(0, 3),
                                      Count = 1,//g.Count()
                                  })
                               group dataFinal by new { dataFinal.Name } into gFinal
                               orderby gFinal.Count() descending
                               select new ReportModelResponse {
                                   Name = gFinal.FirstOrDefault().Name,//.Substring(0, 3),
                                   Count = gFinal.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from dataFinal in
                                 (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                                  where data.Deleted == false &&
                                (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                                (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate)) &&
                                (data.NomDCI != null && data.NomDCI.Length > 0)
                                  group data by new { data.NomDCI } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse {
                                      Name = g.FirstOrDefault().NomDCI,//.Substring(0, 3),
                                      Count = 1,//g.Count()
                                  })
                               group dataFinal by new { dataFinal.Name } into gFinal
                               //orderby gFinal.Count() descending
                               select gFinal.Count()).Sum(x => x);

            }
            catch (Exception ex)
            { }

            return model;
        }

        //Titular
        public async Task<ReportModel<ReportModelResponse>> Report3(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from dataFinal in
                                 (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                                  where data.Deleted == false &&
                                (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                                (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate)) &&
                                (data.LaboratorioId != null && data.LaboratorioId > 0)
                                  group data by new { data.LaboratorioId } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse {
                                      Name = g.FirstOrDefault().Laboratorio.Nombre,//.Substring(0, 3),
                                      Count = 1,//g.Count()
                                  })
                               group dataFinal by new { dataFinal.Name } into gFinal
                               orderby gFinal.Count() descending
                               select new ReportModelResponse {
                                   Name = gFinal.FirstOrDefault().Name,//.Substring(0, 3),
                                   Count = gFinal.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from dataFinal in
                                 (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                                  where data.Deleted == false &&
                                (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                                (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate)) &&
                                (data.LaboratorioId != null && data.LaboratorioId > 0)
                                  group data by new { data.LaboratorioId } into g
                                  orderby g.Count() descending
                                  select new ReportModelResponse {
                                      Name = g.FirstOrDefault().Laboratorio.Nombre,//.Substring(0, 3),
                                      Count = 1,//g.Count()
                                  })
                               group dataFinal by new { dataFinal.Name } into gFinal
                               //orderby gFinal.Count() descending
                               select gFinal.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Reg Sanitario
        public async Task<ReportModel<ReportModelResponse>> Report4(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                var ldata = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate)) &&
                               (data.RegSanitario != null && data.RegSanitario.Length > 0 && data.IpsId > 0 && data.Ips.PeriodoIni != null && data.Ips.PeriodoFin != null)
                               //group data by data.RegSanitario into g
                               //orderby g.Count() descending
                               select new {
                                   Name = data.RegSanitario,
                                   PeriodoIni = data.Ips.PeriodoIni,
                                   PeriodoFin = data.Ips.PeriodoFin,
                               }).ToList();
                var ldateRanges = (from dateranges in ldata
                                  where dateranges.PeriodoIni!=null
                                  select new DateRangeModel { DateIni = dateranges.PeriodoIni.Value, DateEnd = dateranges.PeriodoFin.Value }).ToList();

                ldateRanges = GetNonOverlappingDateRanges(ldateRanges);

                foreach(var daterange in ldateRanges) {

                    var ltmpData = (from data in ldata
                                    where data.PeriodoIni >= daterange.DateIni && data.PeriodoFin <= daterange.DateEnd
                                   group data by data.Name into g
                                   select new ReportModelResponse {
                                       Name = g.FirstOrDefault().Name,
                                       Count = 1 //g.Count()
                                   }).ToList();
                    model.Ldata = model.Ldata != null ? model.Ldata : new List<ReportModelResponse>();
                    model.Ldata.AddRange(ltmpData);
                }

                model.Ldata = (from data in model.Ldata
                               group data by data.Name into g
                               orderby g.Count() descending
                               select new ReportModelResponse {
                                   Name = g.FirstOrDefault().Name,
                                   Count = g.Count()
                               }).OrderBy(x=>x.Name).ToList();

                model.Total = (from data in model.Ldata
                               group data by data.Name into g
                               orderby g.Count() descending
                               select g.Count()).Sum(x => x);

                model.PagAmt = model.Total;

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate)) &&
                //               (data.RegSanitario != null && data.RegSanitario.Length > 0)
                //               group data by data.RegSanitario into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   Name = g.FirstOrDefault().RegSanitario,
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate)) &&
                //               (data.RegSanitario != null && data.RegSanitario.Length > 0)
                //               group data by data.RegSanitario into g
                //               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        public List<DateRangeModel> GetNonOverlappingDateRanges(List<DateRangeModel> dateRanges) {
            dateRanges.Sort((x, y) => x.DateIni.CompareTo(y.DateIni));
            List<DateRangeModel> nonOverlappingRanges = new List<DateRangeModel>();
            foreach (var dateRange in dateRanges) {
                if (nonOverlappingRanges.Count == 0) {
                    nonOverlappingRanges.Add(dateRange);
                }
                else if (dateRange.DateIni > nonOverlappingRanges.Last().DateEnd) {
                    nonOverlappingRanges.Add(dateRange);
                }
                else {
                    nonOverlappingRanges[nonOverlappingRanges.Count - 1] = new DateRangeModel { DateIni = nonOverlappingRanges.Last().DateIni,
                        DateEnd = DateTime.Compare(nonOverlappingRanges.Last().DateEnd, dateRange.DateEnd) >= 0 ? nonOverlappingRanges.Last().DateEnd : dateRange.DateEnd};
                }
            }
            return nonOverlappingRanges;
        }



        //Prioridad
        public async Task<ReportModel<ReportModelResponse>> Report5(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate))
                               group data by data.Ips.Prioridad into g
                               orderby g.Count() descending
                               select new ReportModelResponse {
                                   Name = g.FirstOrDefault().Ips.Prioridad ? "SI" : "NO",
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate))
                               group data by data.Ips.Prioridad into g
                               select g.Count()).Sum(x => x);

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                //               group data by data.Prioridad into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   Name = g.FirstOrDefault().Prioridad?"SI":"NO",
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                //               group data by data.Prioridad into g
                //               select g.Count()).Sum(x => x);
                //select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Año de Recepción
        public async Task<ReportModel<ReportModelResponse>> Report6(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate))
                               group data by data.Ips.Year into g
                               orderby g.Count() descending
                               select new ReportModelResponse {
                                   Name = string.Format("FT Totales Año {0}", g.FirstOrDefault().Ips.Year),//.Substring(0, 3),
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate))
                               group data by data.Ips.Year into g
                               select g.Count()).Sum(x => x);

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                //               group data by data.Year into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   Name = string.Format("FT Totales Año {0}", g.FirstOrDefault().Year),//.Substring(0, 3),
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                //               group data by data.Year into g
                //               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Innovador
        public async Task<ReportModel<ReportModelResponse>> Report7(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate))
                               group data by data.Ips.Innovador into g
                               orderby g.Count() descending
                               select new ReportModelResponse {
                                   Name = g.FirstOrDefault().Ips.Innovador ? "SI" : "NO",
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate))
                               group data by data.Ips.Innovador into g
                               select g.Count()).Sum(x => x);

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                //               group data by data.Innovador into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   Name = g.FirstOrDefault().Innovador ? "SI" : "NO",
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                //               group data by data.Innovador into g
                //               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Biológico
        public async Task<ReportModel<ReportModelResponse>> Report8(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate))
                               group data by data.Ips.Biologico into g
                               orderby g.Count() descending
                               select new ReportModelResponse {
                                   Name = g.FirstOrDefault().Ips.Biologico ? "SI" : "NO",
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate))
                               group data by data.Ips.Biologico into g
                               select g.Count()).Sum(x => x);

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                //               group data by data.Biologico into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   Name = g.FirstOrDefault().Biologico ? "SI" : "NO",
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                //               group data by data.Biologico into g
                //               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Requiere intercambiabilidad
        public async Task<ReportModel<ReportModelResponse>> Report9(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                               group data by data.ReqIntercam into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().ReqIntercam ? "SI" : "NO",
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                               group data by data.ReqIntercam into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Estatus del  Registro
        public async Task<ReportModel<ReportModelResponse>> Report10(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate))
                               group data by data.Ips.EstatusRegistro into g
                               orderby g.Count() descending
                               select new ReportModelResponse {
                                   IpsStatusRegistro = g.FirstOrDefault().Ips.EstatusRegistro,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate))
                               group data by data.Ips.EstatusRegistro into g
                               select g.Count()).Sum(x => x);

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                //               group data by data.EstatusRegistro into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   IpsStatusRegistro = g.FirstOrDefault().EstatusRegistro,
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                //               group data by data.EstatusRegistro into g
                //               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Recibidos
        public async Task<ReportModel<ReportModelResponse>> Report11(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                               group data by data.NoInforme into g
                               orderby g.Count() descending
                               select new ReportModelResponse
                               {
                                   Name = g.FirstOrDefault().NoInforme,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                               where data.Deleted == false &&
                              (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                               group data by data.NoInforme into g
                               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }

        //Estatus de Revision
        public async Task<ReportModel<ReportModelResponse>> Report12(ReportModel<ReportModelResponse> model)
        {
            try
            {
                model.Ldata = null; model.Total = 0;

                model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate))
                               group data by data.Ips.StatusRevision into g
                               orderby g.Count() descending
                               select new ReportModelResponse {
                                   IpsStatusRevision = g.FirstOrDefault().Ips.StatusRevision,
                                   Count = g.Count()
                               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                model.Total = (from data in DalService.DBContext.Set<FMV_IpsMedicamentoTB>()
                               where data.Deleted == false &&
                               (model.FromDate == null ? true : (data.Ips.FechaRecepcion >= model.FromDate)) &&
                               (model.ToDate == null ? true : (data.Ips.FechaRecepcion <= model.ToDate))
                               group data by data.Ips.StatusRevision into g
                               select g.Count()).Sum(x => x);

                //model.Ldata = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                //               group data by data.StatusRevision into g
                //               orderby g.Count() descending
                //               select new ReportModelResponse
                //               {
                //                   IpsStatusRevision = g.FirstOrDefault().StatusRevision,
                //                   Count = g.Count()
                //               }).Skip(model.PagIdx * model.PagAmt).Take(model.PagAmt).ToList();

                //model.Total = (from data in DalService.DBContext.Set<FMV_IpsTB>()
                //               where data.Deleted == false &&
                //               (model.FromDate == null ? true : (data.FechaRecepcion >= model.FromDate)) &&
                //               (model.ToDate == null ? true : (data.FechaRecepcion <= model.ToDate))
                //               group data by data.StatusRevision into g
                //               select g.Count()).Sum(x => x);
            }
            catch (Exception ex)
            { }

            return model;
        }


        public async Task<Stream> ExportToExcelRpt(ReportModel<ReportModelResponse> model, int RptType) {
            try {
                model.PagIdx = 0; model.PagAmt = int.MaxValue;

                switch (RptType) {
                    case 1: {
                            model = await Report1(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Nombre_Comercial";
                                wb.Properties.Title = "Nombre_Comercial";
                                wb.Properties.Subject = "Nombre_Comercial";

                                var ws = wb.Worksheets.Add("Nombre_Comercial");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = prod.Name;
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 2: {
                            model = await Report2(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Nombre_DCI";
                                wb.Properties.Title = "Nombre_DCI";
                                wb.Properties.Subject = "Nombre_DCI";

                                var ws = wb.Worksheets.Add("Nombre_DCI");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = prod.Name;
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 3: {
                            model = await Report3(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Titular";
                                wb.Properties.Title = "Titular";
                                wb.Properties.Subject = "Titular";

                                var ws = wb.Worksheets.Add("Titular");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = prod.Name;
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 4: {
                            model = await Report4(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Reg_Sanitario";
                                wb.Properties.Title = "Reg_Sanitario";
                                wb.Properties.Subject = "Reg_Sanitario";

                                var ws = wb.Worksheets.Add("Reg_Sanitario");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = DataModel.Helper.Helper.GetDescription(prod.AlertType);
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 5: {
                            model = await Report5(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Prioridad";
                                wb.Properties.Title = "Prioridad";
                                wb.Properties.Subject = "Prioridad";

                                var ws = wb.Worksheets.Add("Prioridad");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = prod.Name;
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 6: {
                            model = await Report6(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Ano_Recepción";
                                wb.Properties.Title = "Ano_Recepción";
                                wb.Properties.Subject = "Ano_Recepción";

                                var ws = wb.Worksheets.Add("Ano_Recepción");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = prod.Name;
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 7: {
                            model = await Report7(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Innovador";
                                wb.Properties.Title = "Innovador";
                                wb.Properties.Subject = "Innovador";

                                var ws = wb.Worksheets.Add("Innovador");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = prod.Name;
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 8: {
                            model = await Report8(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Biológico";
                                wb.Properties.Title = "Biológico";
                                wb.Properties.Subject = "Biológico";

                                var ws = wb.Worksheets.Add("Biológico");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = prod.Name;
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 9: {
                            model = await Report9(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Requiere_intercambiabilidad";
                                wb.Properties.Title = "Requiere_intercambiabilidad";
                                wb.Properties.Subject = "Requiere_intercambiabilidad";

                                var ws = wb.Worksheets.Add("Requiere_intercambiabilidad");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = prod.Name;
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 10: {
                            model = await Report10(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Estatus_Registro";
                                wb.Properties.Title = "Estatus_Registro";
                                wb.Properties.Subject = "Estatus_Registro";

                                var ws = wb.Worksheets.Add("Estatus_Registro");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = DataModel.Helper.Helper.GetDescription(prod.IpsStatusRegistro);
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 11: {
                            model = await Report11(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Recibidos";
                                wb.Properties.Title = "Recibidos";
                                wb.Properties.Subject = "Recibidos";

                                var ws = wb.Worksheets.Add("Recibidos");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = prod.Name;
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                    case 12: {
                            model = await Report12(model);
                            if (model.Ldata != null && model.Ldata.Count > 0) {
                                var wb = new XLWorkbook();
                                wb.Properties.Author = "Estatus_Revision";
                                wb.Properties.Title = "Estatus_Revision";
                                wb.Properties.Subject = "Estatus_Revision";

                                var ws = wb.Worksheets.Add("Estatus_Revision");

                                ws.Cell(1, 1).Value = "Descripción";
                                ws.Cell(1, 2).Value = string.Format("Total: {0}", model.Total);

                                for (int row = 1; row <= model.Ldata.Count; row++) {//FechaRecepcion
                                    var prod = model.Ldata[row - 1];
                                    ws.Cell(row + 1, 1).Value = DataModel.Helper.Helper.GetDescription(prod.IpsStatusRevision);
                                    ws.Cell(row + 1, 2).Value = prod.Count;
                                }

                                MemoryStream XLSStream = new();
                                wb.SaveAs(XLSStream);

                                return XLSStream;
                            }

                            break;
                        }
                }
            }
            catch (Exception ex) { }

            return null;
        }


    }

}
